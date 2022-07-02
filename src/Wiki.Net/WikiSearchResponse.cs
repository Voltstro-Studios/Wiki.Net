using System;
using Newtonsoft.Json;

namespace WikiDotNet
{
    /// <summary>
    /// An object returned by the Wikipedia API that contains a <see cref="WikiSearchQuery" /> and <see cref="RequestId" />
    /// </summary>
    //TODO: Add Error and warning class in case
    // ReSharper disable once ClassCannotBeInstantiated
    public sealed class WikiSearchResponse
    {
        /// <summary>
        /// Any errors returned with the request, or <see langword="null" /> if there weren't any
        /// </summary>
        [JsonProperty("errors")] public readonly Error[]? Errors;
        
        /// <summary>
        /// Any warnings returned with the request, or <see langword="null" /> if there weren't any
        /// </summary>
        [JsonProperty("warnings")] public readonly Warning[]? Warnings;

        /// <summary>
        /// The Query that the search returned
        /// </summary>
        [JsonProperty("query")] public readonly WikiSearchQuery Query = null!;

        /// <summary>
        /// The Request ID that was passed during the request
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("requestid")] public readonly string RequestId = null!;

        /// <summary>
        /// The Wikipedia server that this request was served by
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("servedby")] public readonly string ServedBy = null!;

        /// <summary>
        /// The time at which the Wikipedia server received the search request
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("curtimestamp")] public readonly DateTime Timestamp;

        private WikiSearchResponse()
        {
        }

        /// <summary>
        /// Was this request successful, or were there errors?
        /// </summary>
        public bool WasSuccessful
        {
            get
            {
                //If our errors and warnings arrays are null, we know this request was successful
                if (Errors == null && Warnings == null)
                    return true;

                return false;
            }
        }
    }
}