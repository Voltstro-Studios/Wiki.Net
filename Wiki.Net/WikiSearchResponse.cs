#region

using System;
using System.Net.Http;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     A class that contains an array of <see cref="WikiSearchResult" />, returned from the wikipedia servers
	/// </summary>
	public sealed class WikiSearchResponse
	{
		/// <summary>
		///     The Json string from which the results were taken
		/// </summary>
		public readonly string JsonResult;

		/// <summary>
		///     The response message from which the <see cref="SearchResults" /> and <see cref="JsonResult" /> are parsed
		/// </summary>
		public readonly HttpResponseMessage ResponseMessage;

		/// <summary>
		///     An array of results returned from the wikipedia servers
		/// </summary>
		public readonly WikiSearchResult[] SearchResults;

		/// <summary>
		///     A constructor that creates a new <see cref="WikiSearchResponse" />
		/// </summary>
		/// <param name="jsonResult">The Json string used to parse the search results</param>
		/// <param name="responseMessage">The <see cref="HttpResponseMessage" /> that was returned from the server</param>
		/// <param name="searchResults">An array of parsed search results</param>
		public WikiSearchResponse(string jsonResult,
			HttpResponseMessage responseMessage, WikiSearchResult[] searchResults)
		{
			JsonResult = jsonResult ?? throw new ArgumentNullException(nameof(jsonResult));
			SearchResults = searchResults ?? throw new ArgumentNullException(nameof(searchResults));
			ResponseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
		}
	}
}