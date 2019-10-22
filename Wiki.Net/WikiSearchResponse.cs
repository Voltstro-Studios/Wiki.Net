#region

using System.Net.Http;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable NotAccessedField.Global
// ReSharper disable UnassignedField.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBeInternal

#endregion

namespace CreepysinStudios.WikiDotNet
{
	public sealed class WikiSearchResponse
	{
		//!Instead of having multiple nested objects, place the results directly in this
		/// <summary>
		/// The Query result, parsed from the json returned by the search
		/// </summary>
		public WikiQuery Query;
		/// <summary>
		/// The response message from which the <see cref="Query"/> and <see cref="JsonResult"/> are parsed
		/// </summary>
		public HttpResponseMessage ResponseMessage;
		/// <summary>
		/// The Json string from which the results were taken
		/// </summary>
		public string JsonResult;

		public sealed class WikiQuery
		{
			[JsonProperty("search")] public WikiSearchResult[] SearchResults;
		}
	}
}