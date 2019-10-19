#region

using System;
using Newtonsoft.Json;

#endregion

namespace CreepysinStudios.WikiDotNet
{
	public sealed class WikiSearchResult
	{
		[JsonProperty("pageid")] public int PageId;
		[JsonProperty("snippet")] public string Preview;
		[JsonProperty("size")] public int Size;
		[JsonProperty("timestamp")] public DateTime Timestamp;
		[JsonProperty("title")] public string Title;
		[JsonProperty("wordcount")] public int WordCount;
		public string Url;
	}
}