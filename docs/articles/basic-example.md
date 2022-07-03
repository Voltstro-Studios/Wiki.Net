# Basic Example

Here is a basic example on how to use Wiki.Net. For version 3.0.0

```csharp
using System;
using WikiDotNet;

public class SimpleExample
	{
		public static void Main()
		{
			Console.WriteLine("Enter search: ");
			string search = Console.ReadLine();

			//Search Wikipedia
			WikiSearchResponse response = WikiSearcher.Search(search, new WikiSearchSettings
			{
				ResultLimit = 15 //Have a max limit of 15
			});

			foreach (WikiSearchResult result in response.Query.SearchResults)
			{
				Console.WriteLine(
					$"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url}\n\tLast edited at {result.LastEdited}\n");
			}

			Console.WriteLine("Press enter to quit...");
			Console.ReadLine();
		}
	}
```

All this does is ask the user to enter an input, and search Wikipedia with Wiki.Net with a result limit of 15.