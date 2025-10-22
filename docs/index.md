<div class="hero container">
    <div class="hero-content">
        <h1>Wiki.Net</h1>
        <div class="lead">
            <p>Wiki.Net – An unofficial .NET Wikipedia search API wrapper</p>
        </div>
        <div class="actions">
            <a href="articles/" class="btn btn-primary btn-lg">
                Get Started
            </a>
        </div>
    </div>
</div>

### Simple to Use

Install Wiki.Net using [NuGet](https://www.nuget.org/packages/Wiki.Net).

```xml
<ItemGroup>
    <PackageReference Include="Wiki.Net" Version="4.2.0"/>
</ItemGroup>
```

### Then Start Using

Use its simple search API to search Wikipedia.

```csharp
WikiSearcher searcher = new();
WikiSearchResponse response = searcher.Search("Computer");
// Get results using response.Query.SearchResults
```
