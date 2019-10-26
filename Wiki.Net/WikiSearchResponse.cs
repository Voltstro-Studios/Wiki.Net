#region

using System;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     A class that contains an array of <see cref="WikiSearchResult" />, returned from the Wikipedia servers
	/// </summary>
	public sealed class WikiSearchResponse
	{
		/// <summary>
		///     An array of results returned from the wikipedia servers
		/// </summary>
		public readonly WikiSearchResult[] SearchResults;
		
		/// <summary>
		///     A constructor that creates a new <see cref="WikiSearchResponse" />
		/// </summary>
		/// <param name="searchResults">An array of parsed search results</param>
		internal WikiSearchResponse(WikiSearchResult[] searchResults)
		{
			SearchResults = searchResults ?? throw new ArgumentNullException(nameof(searchResults));
		}
	}
}