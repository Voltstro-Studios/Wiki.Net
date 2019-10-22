#region

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

#endregion


namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     Provides functionality for searching wikipedia for string, and returns an array of results
	/// </summary>
	public static class WikiSearcher
	{
		//The path we use to get results from
		private const string WikiGetPath = "https://en.wikipedia.org/w/api.php";

		//Our HttpClient and handler that we use to request our information
		private static readonly HttpClientHandler Handler = new HttpClientHandler();
		private static readonly HttpClient Client = new HttpClient(Handler);

		//Todo Is reference loop handling necessary?
		private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
			{ReferenceLoopHandling = ReferenceLoopHandling.Ignore};

		/// <summary>
		///     An optional proxy to route HTTP requests through when searching
		/// </summary>
		public static IWebProxy Proxy
		{
			get => Handler.Proxy;
			set => Handler.Proxy = value;
		}

		/// <summary>
		///     Searches Wikipedia using the given <paramref name="searchString" />
		/// </summary>
		/// <param name="searchString">The string to search for</param>
		/// <returns>A list of search results obtained from the Wikipedia API</returns>
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

			//Deserialize our response
			//!Make this go into a temporary dynamic, then copy the results into this. Maybe use JObject not dynamic
			WikiSearchResponse searchResponse =
				JsonConvert.DeserializeObject<WikiSearchResponse>(jsonResult, JsonSerializerSettings);
			searchResponse.ResponseMessage = responseMessage;
			searchResponse.JsonResult = jsonResult;
			
			return searchResponse;
		}

		/// <summary>
		///     Removes any HTML formatting tags and unescapes HTML entity codes and
		/// </summary>
		/// <param name="source">The source string to format</param>
		/// <returns>A Json-parser friendly string with any html tags removed</returns>
		private static string StripTags(string source)
		{
			//Turn any characters like '\t' into their actual string version
			string unescaped = Regex.Unescape(source);
			//We need to replace any quotes before they get processed by the HTML decoder, or they don't get escaped and deal havoc with the Json
			unescaped = unescaped.Replace("&quot;", "\\\"");
			//Decode html entity codes like `&quot;` into their unicode counterparts (e.g. `&quot;` => `"`)
			string decoded = WebUtility.HtmlDecode(unescaped);
			//Remove html formatting tags like <span>, <div> etc.
			return Regex.Replace(decoded, "<.*?>", string.Empty);
		}
	}
}