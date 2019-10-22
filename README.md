# Wiki.Net

[![License](https://img.shields.io/github/license/Creepysin-Studios/Wiki.Net)](/LICENSE) [![Requirements Status](https://requires.io/github/Creepysin-Studios/Wiki.Net/requirements.svg?branch=master)](https://requires.io/github/Creepysin-Studios/Wiki.Net/requirements/?branch=master) [![NuGet](https://img.shields.io/nuget/v/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/) 
[![Nuget](https://img.shields.io/nuget/dt/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/) [![Discord](https://img.shields.io/badge/Discord-Creepysin-7289da.svg?logo=discord)](https://discord.creepysin.com)

Wiki.Net – An unofficial C# Wikipedia API

## Features

Searches Wikipedia (duh!) and returns:
* Page ID
* Titles
* Word Count
* Size (bytes?)
* Text Preview
* URL of page

## Getting Started

### Installation

You can install via NuGet using the package manager command:

```
Install-Package Wiki.Net -Version 1.0.0
```

You can also download the binaries from the [releases](https://github.com/Creepysin-Studios/Wiki.Net/releases).

### Example

```csharp
string searchString = “Computer”;

WikiSearchResponse response = WikiSearcher.Search(searchString);

Console.WriteLine($"\nResults found ({searchString}):\n");
for (int i = 0; i < response.SearchResults.Length; i++)
{
	WikiSearchResult result = response.SearchResults[i];
	Console.WriteLine($"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url}\n\tLast edited at {result.LastEdited}\n");
}

Console.ReadLine();
```

**Output**
```
Computer (12154 words)
A computer is a machine that can be instructed to carry out sequences of arithmetic or logical operations automatically via computer programming. Modern...
https://en.wikipedia.org/?curid=7878457

Computer science (7267 words)
Computer science (sometimes called computation science or computing science, but not to be confused with computational science or software engineering)...
https://en.wikipedia.org/?curid=5323

*More results*
```

## Authors

**EternalClickbait** - *Initial work* - [EternalClickbait]( https://github.com/EternalClickbait)

## License

This project is licensed under the Mozilla Public License 2.0 – see the [LICENSE](/LICENSE) file for details.
