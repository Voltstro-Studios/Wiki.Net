using Newtonsoft.Json;

namespace WikiDotNet
{
    /// <summary>
    /// Contains an array of <see cref="WikiSearchResult" />s and a <see cref="SearchInfo" />
    /// </summary>
    // ReSharper disable once ClassCannotBeInstantiated
    public sealed class WikiSearchQuery
    {
        /// <summary>
        /// A read-only field that contains information such as the total amount of hits the search returned
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("searchinfo")] public readonly SearchInfo SearchInfo = null!;

        /// <summary>
        /// An array of results returned from the wikipedia servers
        /// </summary>
        [JsonProperty("search")] public readonly WikiSearchResult[] SearchResults = null!;
        
        private WikiSearchQuery()
        {
        }

        internal void SetLanguage(string language)
        {
            foreach (WikiSearchResult searchResult in SearchResults)
            {
                searchResult.Language = language;
            }
        }
    }
}