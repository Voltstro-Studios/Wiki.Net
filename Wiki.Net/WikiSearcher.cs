//Uncomment to 
//#define DECODE_HTML

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
		/// <returns></returns>
		public static WikiSearchResponse Request(string searchString)
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

			jsonResult = StripTags(jsonResult);

			Console.WriteLine($"Json Result: {jsonResult}");

			WikiSearchResponse searchResponse = JsonConvert.DeserializeObject<WikiSearchResponse>(jsonResult,
				new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
			searchResponse.ResponseMessage = responseMessage;

			//Add the urls to our queries
			for (int i = 0; i < searchResponse.Query.SearchResults.Length; i++)
				//From https://stackoverflow.com/a/9793272
				searchResponse.Query.SearchResults[i].Url =
					$"https://en.wikipedia.org/?curid={searchResponse.Query.SearchResults[i].PageId}";

			return searchResponse;
		}

		private static string StripTags(string source)
		{
			//Turn any characters like '\t' into their actual string version
			string unescaped = Regex.Unescape(source);
			//We need to replace any quotes before they get processed by the HTML decoder, or they don't get escaped and deal havoc with the Json
			unescaped = unescaped.Replace("&quot;", "\\\"");
			//Decode html entity codes like `&quot;` into their unicode counterparts (e.g. `&quot;` => `"`)
			string decoded =  WebUtility.HtmlDecode(unescaped);
			//Remove html formatting tags like <span>, <div> etc.
			return Regex.Replace(decoded, "<.*?>", string.Empty);
		}
	}
}