#region

using System;
using System.Net;

#endregion

namespace CreepysinStudios.WikiDotNet.Example
{
	internal static class Example
	{
		private static void Main()
		{
			#region Using a proxy for requests

			GetProxy:
			string useProxy = AskUserString("Use a proxy to connect?", false).ToLower();
			switch (useProxy)
			{
				case "true":
				case "yes":
				case "y":
					WikiSearcher.Proxy = new WebProxy(AskUserString("Enter the proxy address"))
					{
						Credentials = new NetworkCredential(AskUserString("Enter the proxy username"),
							AskUserString("Enter the proxy password"))
					};
					break;
				case "false":
				case "no":
				case "n":
					break;
				default:
					Console.Clear();
					Console.WriteLine("Enter a valid response (Y/N or true/false)");
					goto GetProxy;
			}

			#endregion

			#region Loop until the user exits

			Request:
			//Get a search from the user, or exit
			string req = AskUserString("Enter a search query, 'exit' or 'quit' to quit");
			// ReSharper disable once SwitchStatementMissingSomeCases
			switch (req.ToLower())
			{
				case "quit":
				case "exit":
					Console.WriteLine("Exiting...");
					return;
			}

			Console.Clear();
			PrintResults(req);
			//Wait until the user presses enter to search again
			Console.WriteLine("Press any key to search again");
			Console.ReadKey(true);
			goto Request;

			#endregion
		}

		private static void PrintResults(string searchString)
		{
			WikiSearchResponse response = WikiSearcher.Search(searchString);

			Console.WriteLine($"\nResults found ({searchString}):\n");
			for (int i = 0; i < response.SearchResults.Length; i++)
			{
				WikiSearchResult result = response.SearchResults[i];
				Console.WriteLine(
					$"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url}\n\tLast edited at {result.LastEdited}\n");
			}
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