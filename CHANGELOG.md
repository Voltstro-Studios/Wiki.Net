# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## 4.1.1 - 2024-01-21

### Changed

- Added support for .NET 8
- Bump deps
- Bump Copyright

## 4.1.0 - 2022-08-03

### Changed

- Updated lots of XML docs to make more sense
- Changed `WikiSearchSettings.Namespaces` to a property

## 4.0.0 - 2022-07-12

### Changed

- Use nullable
- WikiSearcher is now no longer static, it will have to be instantiated
    - Proxy options were removed, in favour of providing your own (global) `HttpClient`
- `ConstantUrl` & `Url` in `WikiSearchQuery` are now properties (instead of methods) and are `Uri`s. They will not need the language to be provided anymore
- Drop .NET 5 support for .NET 6

### Removed

- Removed HTTP support

## 3.1.0 - 2021-07-01

### Changed

- Support .NET 5
- Update Newtonsoft.Json to 13.0.1

### Fixed

- Fix Language property not being set correctly

## 3.0.0 - 2020-06-21

### Added

- Added possibility to define wiki language (PR by JayJay1989)

### Changed

- BREAKING: Changed namespace from `CreepysinStudios.WikiDotNet` to `WikiDotNet`
Updated package details

## 2.1.0 - 2020-01-02

### Changed

- Changed from .NET Core to .NET Standard
- Project is now under the MIT license
- Cleaned up code, minor XML document changes

## 2.0.1 - 2019-10-31

- IDK, we didn't keep a changelog at this point lol

## 1.0.0 - 2019-10-22

- Initial release