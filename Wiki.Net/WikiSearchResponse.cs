#region

using System;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	//TODO: Make all constructors private
	/// <summary>
	///     An object returned by the Wikipedia API that contains a <see cref="WikiSearchQuery" /> and <see cref="RequestId" />
	/// </summary>
	//TODO: Add Error and warning class in case
	public sealed class WikiSearchResponse
	{
		/// <summary>
		///     The Query that the search returned
		/// </summary>
		[JsonProperty("query")] public readonly WikiSearchQuery Query;

		/// <summary>
		///     The Request ID that was passed during the request
		/// </summary>
		[JsonProperty("requestid")] public readonly string RequestId;

		/// <summary>
		///     The Wikipedia server that this request was served by
		/// </summary>
		[JsonProperty("servedby")] public readonly string ServedBy;

		/// <summary>
		///     The time at which the Wikipedia server received the search request
		/// </summary>
		[JsonProperty("curtimestamp")] public readonly DateTime Timestamp;
	}
}