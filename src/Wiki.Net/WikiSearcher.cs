using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WikiDotNet;

/// <summary>
/// Allows the ability to search Wikipedia using a search query
/// </summary>
public class WikiSearcher
{
    /// <summary>
    /// The <see cref="HttpClient" /> that we use to request our information
    /// </summary>
    private readonly HttpClient client;

    /// <summary>
    /// Creates a new <see cref="WikiSearcher" /> instance
    /// </summary>
    /// <param name="httpClient">Set if you have a global <see cref="HttpClient" /> to use</param>
    public WikiSearcher(HttpClient? httpClient = default)
    {
        client = httpClient ?? new HttpClient();
    }

    /// <summary>
    /// The path we use to get results from
    /// </summary>
    private static string WikiGetPath => "";

    /// <summary>
    /// Searches Wikipedia using the given <paramref name="searchString" />
    /// </summary>
    /// <param name="searchString">The string to search for</param>
    /// <param name="searchSettings">An optional set of settings to </param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <c>searchString</c> is null or whitespace.</exception>
    /// <returns>A list of search results obtained from the Wikipedia API</returns>
    public WikiSearchResponse Search(string searchString, WikiSearchSettings? searchSettings = null)
    {
        return SearchAsync(searchString, searchSettings).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Searches Wikipedia using the given <paramref name="searchString" />
    /// </summary>
    /// <param name="searchString">The string to search for</param>
    /// <param name="searchSettings">An optional set of settings to </param>
    /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to use</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <c>searchString</c> is null or whitespace.</exception>
    /// <returns>A list of search results obtained from the Wikipedia API</returns>
    public async Task<WikiSearchResponse> SearchAsync(string searchString, WikiSearchSettings? searchSettings = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            throw new ArgumentNullException(nameof(searchString), "A search string must be provided");
        
        //Encode our values to be passed to the server

        string url = WikiSearchSettings.DefaultWikiApiUrl;
        string userAgent = $"WikiDotNet/{ThisAssembly.AssemblyVersion}";
        string apiLanguage = "en";
        Dictionary<string, string> args = new()
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
            url = searchSettings.WikiApiEndpoint;

            if(!string.IsNullOrWhiteSpace(searchSettings.BotUserAgent))
                userAgent = $"{searchSettings.BotUserAgent} {userAgent}";

            // ReSharper restore StringLiteralTypo
        }

        using (FormUrlEncodedContent content = new(args))
        {
#if NET6_0_OR_GREATER
            string query = await content.ReadAsStringAsync(cancellationToken);
#else
            string query = await content.ReadAsStringAsync();
#endif
            url = string.Format(url, apiLanguage, query);
        }
        
        //Request
        using HttpRequestMessage request = new(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", userAgent);
        
        //Get a response from the server
        HttpResponseMessage responseMessage = await client.SendAsync(request, cancellationToken);
#if NET6_0_OR_GREATER
        string jsonResult = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        string jsonResult = await responseMessage.Content.ReadAsStringAsync();
#endif
        jsonResult = StripTags(jsonResult);

        WikiSearchResponse? searchResponse = JsonConvert.DeserializeObject<WikiSearchResponse>(jsonResult);
        if (searchResponse == null)
            throw new JsonSerializationException("The outputted deserialized object was null!");

        searchResponse.Query.SetLanguage(apiLanguage);
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