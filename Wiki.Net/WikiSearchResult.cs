#region

using System;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	/// <summary>
	/// A single search result from a wikipedia search 
	/// </summary>
	public sealed class WikiSearchResult
	{
		//Todo Add what categories the article falls into
		
		/// <summary>
		/// The numerical ID that corresponds internally (in Wikipedia's servers) to this page
		/// </summary>
		[JsonProperty("pageid")] public int PageId;
		/// <summary>
		/// A preview of the page
		/// </summary>
		[JsonProperty("snippet")] public string Preview;
		/// <summary>
		/// (Possibly) How large the entire page is (assumed in bytes). Unknown what this actually is/does.
		/// </summary>
		[JsonProperty("size")] public int Size;
		/// <summary>
		/// The last time this page was edited
		/// </summary>
		[JsonProperty("timestamp")] public DateTime LastEdited;
		/// <summary>
		/// The title of this page
		/// </summary>
		[JsonProperty("title")] public string Title;
		/// <summary>
		/// How many words are in the article
		/// </summary>
		[JsonProperty("wordcount")] public int WordCount;
		/// <summary>
		/// The URL that can be used to access the article online. Created using the Page ID
		/// </summary>
		//Todo Make this a property instead of assigning it in the wikisearcher class
		public string Url;
	}
}