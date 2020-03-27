# Telnyx dotnet Library

[![image](https://img.shields.io/pypi/v/telnyx.svg)][pypi]
[![image](https://img.shields.io/pypi/l/telnyx.svg)][pypi]
[![image](https://img.shields.io/pypi/pyversions/telnyx.svg)][pypi]
[![Build Status](https://travis-ci.org/team-telnyx/telnyx-dotnet.svg?branch=master)][travis]
[![Coverage Status](https://coveralls.io/repos/github/team-telnyx/telnyx-dotnet/badge.svg?branch=master)][coveralls]

[pypi]: https://pypi.org/project/telnyx/
[travis]: https://travis-ci.org/team-telnyx/telnyx-dotnet
[coveralls]: https://coveralls.io/github/team-telnyx/telnyx-dotnet?branch=master

The Telnyx dotnet library provides convenient access to the Telnyx API from
applications written in the dotnet language. It includes a pre-defined set of
classes for API resources that initialize themselves dynamically from API
responses which makes it compatible with a wide range of versions of the Telnyx
API.

## Documentation

See the [API Reference](https://developers.telnyx.com/docs/api/v2/overview) and the [Setup Guides](https://developers.telnyx.com/docs/v2/development/dev-env-setup).

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package Telnyx.net
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install Telnyx.net
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package Telnyx.net
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Telnyx.net".
5. Click on the Telnyx.net package, select the appropriate version in the
   right-tab and click *Install*.

### Requirements

- .Net Framework (4.5+) or .Net Core 2.0+

## Usage

### Per-request configuration

All of the service methods accept an optional `RequestOptions` object. This is
used if you want to set an [idempotency key][idempotency-keys], if you are
using [Telnyx Connect][connect-auth], or if you want to pass the secret API
key on each method.

[Idempotency keys][idempotency-keys] are added to requests to guarantee that
retries are safe from duplication.

```c#
var requestOptions = new RequestOptions();
requestOptions.ApiKey = "SECRET API KEY";
requestOptions.IdempotencyKey = "SOME STRING";
```

### Using a custom `HttpClient`

You can configure the library with your own custom `HttpClient`:

```c#
TelnyxConfiguration.TelnyxClient = new TelnyxClient(
    apiKey,
    httpClient: new SystemNetHttpClient(httpClient));
```

## Development

The test suite depends on [Telnyx-mock][Telnyx-mock], so make sure to fetch
and run it from a background terminal
([Telnyx-mock's README][Telnyx-mock-usage] also contains instructions for
installing via Homebrew and other methods):

```sh
go get -u github.com/Telnyx/Telnyx-mock
Telnyx-mock
```

Run all tests from the `src/TelnyxTests` directory:

```sh
dotnet test
```

Run some tests, filtering by name:

```sh
dotnet test --filter FullyQualifiedName~InvoiceServiceTest
```

Run tests for a single target framework:

```sh
dotnet test --framework netcoreapp2.1
```

## Acknowledgments

The contributors and maintainers of Telnyx dotnet would like to extend their
deep gratitude to the authors of [Telnyx dotnet][Telnyx-dotnet], upon which
this project is based. Thank you for developing such elegant, usable, and
extensible code and for sharing it with the community.

[Telnyx-dotnet]: https://github.com/Telnyx/Telnyx-dotnet
