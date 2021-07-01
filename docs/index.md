# Wiki.Net

[![License](https://img.shields.io/github/license/Creepysin-Studios/Wiki.Net)](https://github.com/Voltstro-Studios/Wiki.Net/blob/Development/LICENSE.md) 
[![NuGet](https://img.shields.io/nuget/v/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/)
[![NuGet Download Count](https://img.shields.io/nuget/dt/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/)
[![Azure Build](https://dev.azure.com/Voltstro-Studios/Wiki.Net/_apis/build/status/Voltstro-Studios.Wiki.Net?branchName=Development)](https://dev.azure.com/Voltstro-Studios/Wiki.Net/_build?definitionId=4)
[![Discord](https://img.shields.io/badge/Discord-Voltstro-7289da.svg?logo=discord)](https://discord.voltstro.dev)

Wiki.Net – An unofficial C# Wikipedia API

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

You can install via NuGet using the package manager command:

```
Install-Package Wiki.Net
```

You can also download the binaries from the [releases](https://github.com/Voltstro-Studios/Wiki.Net/releases).

### Example

```c#
string searchString = "Computer";
WikiSearchSettings searchSettings = new WikiSearchSettings
	{RequestId = "Request ID", ResultLimit = 5, ResultOffset = 2, Language = "en"};

WikiSearchResponse response = WikiSearcher.Search(searchString, searchSettings);

Console.WriteLine($"\nResults found ({searchString}):\n");
foreach (WikiSearchResult result in response.Query.SearchResults)
{
	Console.WriteLine(
		$"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url(searchSettings.Language)}\n\tLast edited at {result.LastEdited}\n");
}

Console.ReadLine();
```

**Output**
```
Results found (Computer):

    Information technology (2836 words, 27146 bytes, id 36674345):  Information technology (IT) is the use of computers to store, retrieve, transmit, and manipulate data, or information, often in the context of a business...
    At https://en.wikipedia.org/?curid=36674345
    Last edited at 24/10/2019 11:53:39 AM

    Computer graphics (computer science) (1632 words, 18720 bytes, id 18567168):    Computer graphics is a sub-field of Computer Science which studies methods for digitally synthesizing and manipulating visual content. Although the term...
    At https://en.wikipedia.org/?curid=18567168
    Last edited at 17/09/2019 12:21:21 AM

    Computer hardware (2479 words, 22776 bytes, id 21808348):       Computer hardware includes the physical, tangible parts or components of a computer, such as the cabinet, central processing unit, monitor, keyboard,...
    At https://en.wikipedia.org/?curid=21808348
    Last edited at 16/10/2019 4:00:29 PM

    *More results*
```


### Upgrading from 2.x to 3.x

In 3.0, we simplified the namespace of Wiki.Net to `WikiDotNet`.

To upgrade from 2.x version of Wiki.Net to 3.x, you need to change all of the `using CreepysinStudios.WikiDotNet` to `using WikiDotNet` in your projects. The easiest way would just be to do a replace all in your entire solution.

## Authors

**EternalClickbait** - *Initial work* - [EternalClickbait](https://github.com/EternalClickbait)

**Voltstro** - *Current Maintainer / Initial Docs Writer* - [Voltstro](https://github.com/Voltstro)

## License

This project is licensed under the MIT license – see the [LICENSE.md](https://github.com/Voltstro-Studios/Wiki.Net/blob/Development/LICENSE.md) file for details.