#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	public static class WikiSearcher
	{
		//The path we use to get results from
		private const string WikiGetPath = "https://en.wikipedia.org/w/api.php";

		private static readonly HttpClientHandler Handler = new HttpClientHandler();

		private static readonly HttpClient Client = new HttpClient(Handler);

		public static IWebProxy Proxy
		{
			get => Handler.Proxy;
			set => Handler.Proxy = value;
		}

		/// <summary>
		/// </summary>
		/// <param name="searchString"></param>
		/// <param name="stripHtmlTags"></param>
		/// <returns></returns>
		public static WikiSearchResponse Request(string searchString, bool stripHtmlTags = true)
		{
			//Encode our values to be passed to the server
			FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
			{
				//Get results in Json
				new KeyValuePair<string, string>("format", "json"),
				//Query the Wiki API
				new KeyValuePair<string, string>("action", "query"),
				//Give errors in plain text
				new KeyValuePair<string, string>("errorformat", "plaintext"),
				//Our search params
				new KeyValuePair<string, string>("list", "search"),
				new KeyValuePair<string, string>("srsearch", searchString)
			});

			//And add them to our url
			string url = $"{WikiGetPath}?{content.ReadAsStringAsync().Result}";

			//Get a response from the server
			HttpResponseMessage responseMessage = Client.GetAsync(url).Result;

			string jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

			if (stripHtmlTags) jsonResult = StripTagsRegex(jsonResult);

			Console.WriteLine($"Json Result: {jsonResult}");

			WikiSearchResponse searchResponse = JsonConvert.DeserializeObject<WikiSearchResponse>(jsonResult,
				new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
			searchResponse.ResponseMessage = responseMessage;

			//Add the urls to our queries. Very performance heavy, but this is simply a test
			for (int i = 0; i < searchResponse.Query.SearchResults.Length; i++)
				searchResponse.Query.SearchResults[i].Url =JsonConvert.DeserializeObject<dynamic>(Client
					.GetAsync($"{WikiGetPath}?action=query&format=json&prop=info&pageids={searchResponse.Query.SearchResults[i].PageId}&inprop=url").Result.Content.ReadAsStringAsync().Result).fullurl;
			return searchResponse;
		}

		private static string StripTagsRegex(string source)
		{
			//Remove html style tags e.g. <br/>
			string noHtml = Regex.Replace(source, "<.*?>", string.Empty);

			//Remove any escape codes
			string noEscape = Regex.Replace(noHtml, "((&*;)|(&..))", string.Empty);

			return noEscape;
		}
	}
}