# Wiki.Net

[![License](https://img.shields.io/github/license/Voltstro-Studios/Wiki.Net?label=License)](https://github.com/Voltstro-Studios/Wiki.Net/blob/master/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/Wiki.Net?label=NuGet)](https://www.nuget.org/packages/Wiki.Net/)
[![NuGet Download Count](https://img.shields.io/nuget/dt/Wiki.Net?label=Downloads&logo=nuget&color=blue&logoColor=blue)](https://www.nuget.org/packages/Wiki.Net/)
[![Build Status)](https://img.shields.io/azure-devops/build/Voltstro-Studios/c4df32aa-4dfd-4b92-bf94-fe6c31c47b03/4/master?label=Build&logo=azure-pipelines)](https://dev.azure.com/Voltstro-Studios/Wiki.Net/_build/latest?definitionId=4&branchName=master)
[![Discord](https://img.shields.io/badge/Discord-Voltstro-7289da.svg?logo=discord)](https://discord.voltstro.dev)

Wiki.Net – An unofficial .NET Wikipedia API wrapper.

## Features

Searches Wikipedia (duh!) in multiple defined languages and returns (per result):
* Title
* Page ID
* Word Count
* Size (bytes?)
* Text Preview
* URL of page
* Time of last edit

## Getting Started

### Installation

You can install via NuGet by adding Wiki.Net to your project's packages:

```xml
<ItemGroup>
    <PackageReference Include="Wiki.Net" Version="4.1.1"/>
</ItemGroup>
```

### Example

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

**Output**
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

### Upgrading

#### From 3.x to 4.x

In 4.0, we changed `WikiSearcher` from being static, to a class that you must instantiate first. We made this change so that your program's global `HttpClient` may be passed through.

To upgrade, first instantiate `WikiSearcher`, then call `Search(string searchString, WikiSearchSettings? searchSettings = null)` with the newly created `WikiSearcher`.

The methods in `WikiSearchResult` for getting the URLs have also been removed, and replaced with properties. The language will have already been set to what you provided in `WikiSearchSettings`.

HTTP support was also dropped, you now MUST use HTTPS.

#### From 2.x to 3.x

In 3.0, we simplified the namespace of Wiki.Net to `WikiDotNet`.

To upgrade from 2.x version of Wiki.Net to 3.x, you need to change all of the `using CreepysinStudios.WikiDotNet` to `using WikiDotNet` in your projects. The easiest way would just be to do a replace all in your entire solution.

## Authors

**Ararem** (Formally EternalClickbait) - *Initial work* - [Ararem](https://github.com/Ararem)

**Voltstro** - *Current Maintainer / Initial Docs Writer* - [Voltstro](https://github.com/Voltstro)

## License

This project is licensed under the MIT license – see the [LICENSE.md](https://github.com/Voltstro-Studios/Wiki.Net/blob/master/LICENSE.md) file for details.
