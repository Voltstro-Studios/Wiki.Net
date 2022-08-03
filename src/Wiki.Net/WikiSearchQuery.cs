using Newtonsoft.Json;

namespace WikiDotNet;

/// <summary>
/// Contains an array of <see cref="WikiSearchResult" />s and a <see cref="SearchInfo" />
/// </summary>
// ReSharper disable once ClassCannotBeInstantiated
public sealed class WikiSearchQuery
{
    /// <summary>
    /// Contains information related to the search query
    /// </summary>
    // ReSharper disable once StringLiteralTypo
    [JsonProperty("searchinfo")] public readonly SearchInfo SearchInfo = null!;

    /// <summary>
    /// All of the <see cref="WikiSearchResult"/> that the API returned
    /// </summary>
    [JsonProperty("search")] public readonly WikiSearchResult[] SearchResults = null!;

    private WikiSearchQuery()
    {
    }

    internal void SetLanguage(string language)
    {
        foreach (WikiSearchResult searchResult in SearchResults) searchResult.Language = language;
    }
}