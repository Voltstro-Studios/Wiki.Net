# Upgrading

Upgrading from an older version? You may want to read this to get an idea on what might be broken.

## From 3.x to 4.x

In 4.0, we changed `WikiSearcher` from being static, to a class that you must instantiate first. We made this change so that your program's global `HttpClient` may be passed through.

To upgrade, first instantiate `WikiSearcher`, then call `Search(string searchString, WikiSearchSettings? searchSettings = null)` with the newly created `WikiSearcher`.

The methods in `WikiSearchResult` for getting the URLs have also been removed, and replaced with properties. The language will have already been set to what you provided in `WikiSearchSettings`.

HTTP support was also dropped, you now MUST use HTTPS.

## From 2.x to 3.x

In 3.0, we simplified the namespace of Wiki.Net to `WikiDotNet`.

To upgrade from 2.x version of Wiki.Net to 3.x, you need to change all of the `using CreepysinStudios.WikiDotNet` to `using WikiDotNet` in your projects. The easiest way would just be to do a replace all in your entire solution.
