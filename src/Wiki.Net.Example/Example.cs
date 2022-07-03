using System;

namespace WikiDotNet.Example;

internal static class Example
{
    private static void Main()
    {
        #region Loop until the user exits

        WikiSearcher searcher = new();
        WikiSearchSettings searchSettings = new()
            { RequestId = "Request ID", ResultLimit = 5, ResultOffset = 2, Language = "en" };
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
        PrintResults(req, searcher, searchSettings);
        //Wait until the user presses enter to search again
        Console.WriteLine("Press any key to search again");
        Console.ReadKey(true);
        goto Request;

        #endregion
    }

    private static void PrintResults(string searchString, WikiSearcher searcher, WikiSearchSettings searchSettings)
    {
        WikiSearchResponse response = searcher.Search(searchString, searchSettings);

        Console.WriteLine($"\nResults found ({searchString}):\n");
        foreach (WikiSearchResult result in response.Query.SearchResults)
            Console.WriteLine(
                $"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url.AbsoluteUri} and {result.ConstantUrl.AbsoluteUri}\n\tLast edited at {result.LastEdited}\n");
    }

    private static string AskUserString(string message, bool clearConsole = true)
    {
        if (clearConsole)
            Console.Clear();
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}