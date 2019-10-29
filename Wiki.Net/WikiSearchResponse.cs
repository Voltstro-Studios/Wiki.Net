#region

using System;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     An object returned by the Wikipedia API that contains a <see cref="WikiSearchQuery" /> and <see cref="RequestId" />
	/// </summary>
	//TODO: Add Error and warning class in case
	// ReSharper disable once ClassCannotBeInstantiated
	public sealed class WikiSearchResponse
	{
		[JsonProperty("errors")] public readonly Error[] Errors;

		/// <summary>
		///     The Query that the search returned
		/// </summary>
		[JsonProperty("query")] public readonly WikiSearchQuery Query;

		/// <summary>
		///     The Request ID that was passed during the request
		/// </summary>
		// ReSharper disable once StringLiteralTypo
		[JsonProperty("requestid")] public readonly string RequestId;

		/// <summary>
		///     The Wikipedia server that this request was served by
		/// </summary>
		// ReSharper disable once StringLiteralTypo
		[JsonProperty("servedby")] public readonly string ServedBy;

		/// <summary>
		///     The time at which the Wikipedia server received the search request
		/// </summary>
		// ReSharper disable once StringLiteralTypo
		[JsonProperty("curtimestamp")] public readonly DateTime Timestamp;

		[JsonProperty("warnings")] public readonly Warning[] Warnings;

		public bool WasSuccessful
		{
			get
			{
				if (Errors == null || Warnings == null) return false;
				return Errors.Length == 0 && Warnings.Length == 0;
			}
		}

		private WikiSearchResponse()
		{
		}
	}
}