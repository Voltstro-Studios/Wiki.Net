using Newtonsoft.Json;

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	///     A class that contains information about a Wikipedia search. Currently only contains an int for the total number of
	///     results.
	/// </summary>
	public class SearchInfo
	{
		/// <summary>
		///     How many hits did the search return (in total, including those not shown)
		/// </summary>
		// ReSharper disable once StringLiteralTypo
		[JsonProperty("totalhits")] public int TotalHits;

		private SearchInfo()
		{
		}
	}
}