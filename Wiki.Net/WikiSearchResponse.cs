#region

using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	//TODO: Make all constructors private
	public sealed class WikiSearchResponse
	{
		[JsonProperty("query")] public readonly WikiSearchQuery Query;

		/// <summary>
		///     The Request ID that was passed during the request
		/// </summary>
		[JsonProperty("requestid")] public readonly string RequestId;
	}
}