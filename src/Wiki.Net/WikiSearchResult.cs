using System;
using Newtonsoft.Json;

namespace WikiDotNet
{
    /// <summary>
    /// A single search result from a Wikipedia search
    /// </summary>
    // ReSharper disable once ClassCannotBeInstantiated
    public sealed class WikiSearchResult
    {
        /// <summary>
        /// The last time this page was edited
        /// </summary>
        [JsonProperty("timestamp")] public readonly DateTime LastEdited;

        /// <summary>
        /// Unknown what this number refers to, likely refers to 'namespace'
        /// </summary>
        [JsonProperty("ns")] public readonly int Ns;

        /// <summary>
        /// The numerical ID that corresponds internally (in Wikipedia's servers) to this page
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("pageid")] public readonly int PageId;

        /// <summary>
        /// A preview of the page
        /// </summary>
        [JsonProperty("snippet")] public readonly string Preview = null!;

        //TODO: Find out what 'size' is (Assumed bytes at the moment)
        /// <summary>
        /// (Possibly) How large the entire page is (assumed in bytes). Unknown what this actually is/does.
        /// </summary>
        [JsonProperty("size")] public readonly int Size;

        /// <summary>
        /// The title of this page
        /// </summary>
        [JsonProperty("title")] public readonly string Title = null!;

        /// <summary>
        /// How many words are in the article
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("wordcount")] public readonly int WordCount;

        internal string Language { set; private get; } = null!;
        
        private WikiSearchResult()
        {
        }

        /// <summary>
        /// A URL that can be used to access the article online. Created using the Page ID, and will point to the same article
        /// even if the title changes
        /// </summary>
        public Uri ConstantUrl => new Uri($"https://{Language}.wikipedia.org/?curid={PageId}");

        /// <summary>
        /// A URL that can be used to access the article. If the page gets renamed or moved, this will likely break, and point
        /// to a different or non-existent page
        /// </summary>
        public Uri Url => new Uri($"https://{Language}.wikipedia.org/wiki/{Title}");
    }
}