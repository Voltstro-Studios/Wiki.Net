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
		//!Create a constructor and make fields readonly
		/// <summary>
		///     The Json string from which the results were taken
		/// </summary>
		public string JsonResult;

		public WikiSearchResult[] SearchResults;

		/// <summary>
		///     The response message from which the <see cref="SearchResults" /> and <see cref="JsonResult" /> are parsed
		/// </summary>
		public HttpResponseMessage ResponseMessage;

	}
}