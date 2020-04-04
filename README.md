# Wiki.Net

[![License](https://img.shields.io/github/license/Creepysin-Studios/Wiki.Net)](/LICENSE.md) 
[![Requirements Status](https://requires.io/github/Creepysin-Studios/Wiki.Net/requirements.svg?branch=Development)](https://requires.io/github/Creepysin-Studios/Wiki.Net/requirements/?branch=Stable) 
[![NuGet](https://img.shields.io/nuget/v/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/)
[![NuGet Download Count](https://img.shields.io/nuget/dt/Wiki.Net)](https://www.nuget.org/packages/Wiki.Net/)
[![Azure Build](https://img.shields.io/azure-devops/build/Creepysin-Studios/c4df32aa-4dfd-4b92-bf94-fe6c31c47b03/4/Development)](https://dev.azure.com/Creepysin-Studios/Wiki.Net)
[![Discord](https://img.shields.io/badge/Discord-Voltstro-7289da.svg?logo=discord)](https://discord.voltstro.dev)

Wiki.Net – An unofficial C# Wikipedia API

## Features

Searches Wikipedia (duh!) and returns (per result):
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
Install-Package Wiki.Net -Version 2.1.0
```

You can also download the binaries from the [releases](https://github.com/Creepysin-Studios/Wiki.Net/releases).

### Example

```c#
string searchString = "Computer";
WikiSearchSettings searchSettings = new WikiSearchSettings
	{RequestId = "Request ID", ResultLimit = 5, ResultOffset = 2};

WikiSearchResponse response = WikiSearcher.Search(searchString, searchSettings);

Console.WriteLine($"\nResults found ({searchString}):\n");
foreach (WikiSearchResult result in response.Query.SearchResults)
{
	Console.WriteLine(
		$"\t{result.Title} ({result.WordCount} words, {result.Size} bytes, id {result.PageId}):\t{result.Preview}...\n\tAt {result.Url}\n\tLast edited at {result.LastEdited}\n");
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

## Authors

**EternalClickbait** - *Initial work* - [EternalClickbait](https://github.com/EternalClickbait)

**Voltstro** - *Current Maintainer / Initial Docs Writer* - [Voltstro](https://github.com/Voltstro)

## License

This project is licensed under the MIT license – see the [LICENSE.md](/LICENSE.md) file for details.
