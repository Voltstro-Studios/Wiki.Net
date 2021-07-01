using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace WikiDotNet
{
	/// <summary>
	/// Provides functionality for searching Wikipedia for string, and returns an array of results
	/// </summary>
	public static class WikiSearcher
    {
	    /// <summary>
	    /// The <see cref="HttpClientHandler" /> that we use to request our information
	    /// </summary>
	    private static readonly HttpClientHandler Handler = new HttpClientHandler();

	    /// <summary>
	    /// The <see cref="HttpClient" /> that we use to request our information
	    /// </summary>
	    private static readonly HttpClient Client = new HttpClient(Handler);

	    /// <summary>
	    /// The <see cref="JsonSerializerSettings" /> that are used during deserialization
	    /// </summary>
	    private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings();

	    /// <summary>
	    /// The path we use to get results from
	    /// </summary>
	    private static string WikiGetPath => $"{(UseHttps ? "https://" : "http://")}%LANG%.wikipedia.org/w/api.php";

	    /// <summary>
	    /// An optional proxy to route HTTP requests through when searching
	    /// </summary>
	    public static IWebProxy Proxy
        {
            // ReSharper disable once UnusedMember.Global
            get => Handler.Proxy;
            set => Handler.Proxy = value;
        }

	    /// <summary>
	    /// If we should use HTTPS for web requests or HTTP
	    /// </summary>
	    // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public static bool UseHttps { get; set; } = true;

	    /// <summary>
	    /// Searches Wikipedia using the given <paramref name="searchString" />
	    /// </summary>
	    /// <param name="searchString">The string to search for</param>
	    /// <param name="searchSettings">An optional set of settings to </param>
	    /// <exception cref="ArgumentOutOfRangeException"></exception>
	    /// <returns>A list of search results obtained from the Wikipedia API</returns>
	    public static WikiSearchResponse Search(string searchString, WikiSearchSettings searchSettings = null)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                throw new ArgumentNullException(nameof(searchString), "A search string must be provided");

            //Encode our values to be passed to the server
            string url;
            string apiLanguage = "en";
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                // ReSharper disable StringLiteralTypo

                //Query the Wiki API
                ["action"] = "query",
                ["list"] = "search",
                //Our search params
                ["srsearch"] = searchString,
                //Get results in Json
                ["format"] = "json",
                //Give errors in plain text
                ["errorformat"] = "plaintext"

                // ReSharper restore StringLiteralTypo
            };

            if (searchSettings != null)
            {
                // ReSharper disable StringLiteralTypo

                //Limit our results, and offset if required
                args.Add("srlimit", searchSettings.ResultLimit.ToString());
                args.Add("sroffset", searchSettings.ResultOffset.ToString());
                //If the namespaces list is null use "*" which means all of them
                args.Add("srnamespace",
                    searchSettings.Namespaces == null ? "*" : string.Join("|", searchSettings.Namespaces));
                //If we should search for the exact string
                args.Add("srwhat", searchSettings.ExactMatch ? "nearmatch" : "text");
                //Get which server we were served by
                args.Add("servedby", "true");
                //Request the current timestamp be included
                args.Add("curtimestamp", "true");
                if (searchSettings.RequestId != null)
                    args.Add("requestid", searchSettings.RequestId);
                apiLanguage = searchSettings.Language;

                // ReSharper restore StringLiteralTypo
            }

            using (FormUrlEncodedContent content = new FormUrlEncodedContent(args))
            {
                url = $"{WikiGetPath.Replace("%LANG%", apiLanguage)}?{content.ReadAsStringAsync().Result}";
            }

            //Get a response from the server
            HttpResponseMessage responseMessage = Client.GetAsync(url).Result;
            string jsonResult = responseMessage.Content.ReadAsStringAsync().Result;
            jsonResult = StripTags(jsonResult);

            WikiSearchResponse searchResponse =
                JsonConvert.DeserializeObject<WikiSearchResponse>(jsonResult, JsonSerializerSettings);

            return searchResponse;
        }

	    /// <summary>
	    /// Removes any HTML formatting tags and unescaped HTML entity codes and
	    /// </summary>
	    /// <param name="source">The source string to format</param>
	    /// <returns>A Json-parser friendly string with any html tags removed</returns>
	    private static string StripTags(string source)
        {
            //We need to replace any quotes before they get processed by the HTML decoder, or they don't get escaped and deal havoc with the Json
            string unquoted = source.Replace("&quot;", "\\\"");
            //Decode html entity codes like `&lt;` into their unicode counterparts (e.g. `&lt;` => `<`)
            string decoded = WebUtility.HtmlDecode(unquoted);
            //Remove html formatting tags like <span>, <div> etc.
            return Regex.Replace(decoded, "<.*?>", string.Empty);
        }
    }
}