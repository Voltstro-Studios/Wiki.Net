# User Agent

The Wikimedia Foundation has policy that all API requests must include a User-Agent header. By default, Wiki.Net sends a User-Agent that looks something like:

```
WikiDotNet/x.x.x.x
```

With `x.x.x.x` representing the version of WikiDotNet being used, E.G `4.2.0.0`. This version number comes from the version of the Wiki.Net assembly.

It also generally recommended to include an additional form of an identifier that isn't going to be confused with many other bots. You can set a custom "bot" identifier as a prefix to the User-Agent using <xref:WikiDotNet.WikiSearchSettings.BotUserAgent>. The recommended format looks like:

```
CoolBot/0.0 (https://example.org/coolbot/; coolbot@example.org)
```

This will result in WikiDotNet that sends a User-Agent looking like:

```
CoolBot/0.0 (https://example.org/coolbot/; coolbot@example.org) WikiDotNet/x.x.x.x
```

Please read the full [Wikimedia Foundation's policy on User-Agents](https://foundation.wikimedia.org/wiki/Policy:Wikimedia_Foundation_User-Agent_Policy) to get a full understanding on the User-Agent header requirements.
