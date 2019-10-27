#region

using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     A class that contains an array of <see cref="WikiSearchResult" />, returned from the Wikipedia servers
	/// </summary>
	public sealed class WikiSearchResponse
	{
		[JsonProperty("query")] public readonly WikiSearchQuery Query;

		/// <summary>
		///     The Request ID that was passed during the request
		/// </summary>
		[JsonProperty("requestid")] public readonly string RequestId;
		
		public sealed class WikiSearchQuery
		{
			/// <summary>
			///     An array of results returned from the wikipedia servers
			/// </summary>
			[JsonProperty("search")] public readonly WikiSearchResult[] SearchResults;

			[JsonProperty("searchinfo")] public readonly SearchInfo SearchInfo;
		}

		public class SearchInfo
		{
			[JsonProperty("totalhits")] public int TotalHits;
		}
	}
}