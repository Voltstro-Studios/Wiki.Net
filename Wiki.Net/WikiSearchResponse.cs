#region

using System;
using System.Net.Http;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	public sealed class WikiSearchResponse
	{
		/// <summary>
		///     The Json string from which the results were taken
		/// </summary>
		public readonly string JsonResult;

		public readonly WikiSearchResult[] SearchResults;

		/// <summary>
		///     The response message from which the <see cref="SearchResults" /> and <see cref="JsonResult" /> are parsed
		/// </summary>
		public readonly HttpResponseMessage ResponseMessage;

		public WikiSearchResponse(string jsonResult,
			HttpResponseMessage responseMessage, WikiSearchResult[] searchResults)
		{
			JsonResult = jsonResult ?? throw new ArgumentNullException(nameof(jsonResult));
			SearchResults = searchResults ?? throw new ArgumentNullException(nameof(searchResults));
			ResponseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
		}
	}
}