using Newtonsoft.Json;

namespace CreepysinStudios.WikiDotNet
{
	public sealed class WikiSearchQuery
	{
		/// <summary>
		///     An array of results returned from the wikipedia servers
		/// </summary>
		[JsonProperty("search")] public readonly WikiSearchResult[] SearchResults;

		[JsonProperty("searchinfo")] public readonly SearchInfo SearchInfo;
	}
}