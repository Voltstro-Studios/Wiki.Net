#region

using System.Net.Http;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public sealed class WikiSearchResponse
	{
		// ReSharper disable once UnassignedField.Global
		public WikiQuery Query;

		// ReSharper disable once UnassignedField.Global
		public HttpResponseMessage ResponseMessage;

		public sealed class WikiQuery
		{
			[JsonProperty("search")] public WikiSearchResult[] SearchResults;
		}
	}
}