#define USE_PROXY

#region

using System;
using System.IO;
using Newtonsoft.Json;

#endregion


namespace CreepysinStudios.WikiDotNet.Example
{
	internal static class Program
	{
		private static void Main()
		{
			string searchString = AskUserString("Enter a search query");

			bool stripHtml = AskUserBool("Strip HTML tags?");

			WikiSearchResponse response = WikiSearcher.Request(searchString, stripHtml);

			File.WriteAllText("./Output.txt", $"{JsonConvert.SerializeObject(response, Formatting.Indented)}");

			Console.WriteLine($"\nResults found ({searchString}):\n");
			for (int i = 0; i < response.Query.SearchResults.Length; i++)
			{
				WikiSearchResult result = response.Query.SearchResults[i];
				Console.WriteLine($"\t[Page {result.PageId}]\t{result.Title} ({result.WordCount} words, {result.Size} bytes):\t{result.Preview}...\n\tAt {result.Url}\n");
			}

			Console.ReadLine();
		}

		private static bool AskUserBool(string message, bool clearConsole = true)
		{
			if (clearConsole)
				Console.Clear();
			Console.WriteLine(message);
			// ReSharper disable once AssignNullToNotNullAttribute
			return bool.Parse(Console.ReadLine());
		}

		private static string AskUserString(string message, bool clearConsole = true)
		{
			if (clearConsole)
				Console.Clear();
			Console.WriteLine(message);
			return Console.ReadLine();
		}
	}
}