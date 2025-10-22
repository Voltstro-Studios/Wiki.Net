using System;
using System.Collections.Generic;

namespace WikiDotNet;

/// <summary>
/// A class containing settings for use when searching with <see cref="WikiSearcher.Search" />.
/// </summary>
public sealed class WikiSearchSettings
{
    internal const string DefaultWikiApiUrl = "https://{0}.wikipedia.org/w/api.php?{1}";
    
    /// <summary>
    /// Instantiates a new <see cref="WikiSearchSettings"/> instance
    /// </summary>
    public WikiSearchSettings()
    {
    }
    
    /// <summary>
    /// What namespaces to search in.
    /// <para>Default is none (<c>null</c>).</para>
    /// </summary>
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public List<int>? Namespaces { get; set; }
    
    /// <summary>
    /// [Backing Field] How many results to return
    /// </summary>
    private int resultLimit = 10;

    /// <summary>
    /// How many results to return.
    /// <para>Default is 10.</para>
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the given value is too high or low</exception>
    public int ResultLimit
    {
        get => resultLimit;
        set
        {
            const int min = 1;
            const int max = 50;
            if (value is < min or > max)
                throw new ArgumentOutOfRangeException(nameof(value),
                    $"Value {value} is out of range. Valid range is {min}-{max}");
            
            resultLimit = value;
        }
    }

    /// <summary>
    /// An amount to offset the search results by.
    /// <para>Useful when scrolling through large groups of pages.</para>
    /// </summary>
    public int ResultOffset { get; set; }

    /// <summary>
    /// A string that will be returned with the request results.
    /// <para>Useful to distinguish multiple requests.</para>
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// [Backing Field] The language of the wiki to search in.
    /// </summary>
    private string language = "en";
    
    /// <summary>
    /// What wikipedia language to search from.
    /// <para>Default is english (<c>en</c>).</para>
    /// </summary>
    /// <exception cref="ArgumentException">Occurs when the given value is <see langword="null" /> or white space</exception>
    public string Language
    {
        get => language;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or white space!", nameof(value));

            language = value;
        }
    }

    // ReSharper disable once CommentTypo
    /// <summary>
    /// Should we only find results that exactly match our search
    /// <example>
    ///     'Microsoft' results in 'Microsoft'
    ///     'Microsof' results in 'no results'
    /// </example>
    /// </summary>
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public bool ExactMatch { get; set; } = false;

    /// <summary>
    /// [Backing Field] API endpoint to use
    /// </summary>
    private string wikiApiEndpoint = DefaultWikiApiUrl;
    
    /// <summary>
    /// API endpoint to use.
    /// <para>Defaults to <c>https://{0}.wikipedia.org/w/api.php?{1}</c></para>
    /// </summary>
    /// <exception cref="ArgumentException">Occurs when the given value is <see langword="null" /> or white space</exception>
    public string WikiApiEndpoint
    {
        get => wikiApiEndpoint;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or white space!", nameof(value));
            
            wikiApiEndpoint = value;
        }
    }
    
    /// <summary>
    /// Your custom user agent that will be prepended on requests made to the API. It is generally recommended to include one.
    /// <para>Please note that the library will also include its identifier after.</para>
    /// <seealso href="https://foundation.wikimedia.org/wiki/Policy:Wikimedia_Foundation_User-Agent_Policy"/>
    /// </summary>
    public string? BotUserAgent { get; set; }
}