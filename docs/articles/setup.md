# Setup

This guide will show you how to install and use Wiki.Net.

## Installation

You can install Wiki.Net via [NuGet](https://www.nuget.org/packages/Wiki.Net) by adding Wiki.Net to your project's `.csproj`:

```xml
<ItemGroup>
    <PackageReference Include="Wiki.Net" Version="4.2.0"/>
</ItemGroup>
```

## Usage

Once Wiki.Net is added to your project, you can then use it's APIs.

You can search for articles using the <xref:WikiDotNet.WikiSearcher> object. An optional <xref:System.Net.Http.HttpClient> can be passed if you have one.

When using the <xref:WikiDotNet.WikiSearcher.Search*> method, you will need to provide the search query you want. You may also want to provide an optional <xref:WikiDotNet.WikiSearchSettings>, to control the output you get. See the API reference to see what Properties you can change.

The <xref:WikiDotNet.WikiSearcher.Search*> method returns a <xref:WikiDotNet.WikiSearchResponse>, which will contain a <xref:WikiDotNet.WikiSearchResponse.Query> field for you to obtain the found search results that match your search query and settings.

The code below includes all 3 parts talked about above. Once the search response is obtained, the example code will just print out the results.

## Example Code

```csharp
string searchString = "Computer";
WikiSearcher searcher = new();
WikiSearchSettings searchSettings = new() {RequestId = "Request ID", ResultLimit = 5, ResultOffset = 2, Language = "en"};

WikiSearchResponse response = searcher.Search(searchString, searchSettings);

Console.WriteLine($"\nResults found ({searchString}):\n");
foreach (WikiSearchResult result in response.Query.SearchResults)
{
	Console.WriteLine(
                $"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url.AbsoluteUri} and {result.ConstantUrl.AbsoluteUri}\n\tLast edited at {result.LastEdited}\n");
}

Console.ReadLine();
```

### Output

```
Results found (Computer):

        Computer engineering (2533 words, 28125 bytes, id 50408):       Computer engineering (CoE or CpE) is a branch of electrical engineering that integrates several fields of computer science and electronic engineering required...
        At https://en.wikipedia.org/wiki/Computer engineering and https://en.wikipedia.org/?curid=50408
        Last edited at 27/6/2022 3:37:42 pm

        Computer science (6930 words, 72988 bytes, id 5323):    Fundamental areas of computer science Computer science is the study of computation, automation, and information. Computer science spans theoretical disciplines...
        At https://en.wikipedia.org/wiki/Computer science and https://en.wikipedia.org/?curid=5323
        Last edited at 3/7/2022 3:18:56 am

        Computer animation (4609 words, 40388 bytes, id 6777):  Computer animation is the process used for digitally generating animated images. The more general term computer-generated imagery (CGI) encompasses both...
        At https://en.wikipedia.org/wiki/Computer animation and https://en.wikipedia.org/?curid=6777
        Last edited at 16/6/2022 4:26:51 pm

        *More results*
```
