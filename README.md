# Telnyx.net
[![Build Status](https://travis-ci.org/team-telnyx/telnyx-dotnet.svg?branch=master)](https://travis-ci.org/team-telnyx/telnyx-dotnet)
[![NuGet](https://img.shields.io/nuget/v/Telnyx.net.svg)](https://www.nuget.org/packages/Telnyx.net/)
[![Coverage Status](https://coveralls.io/repos/github/Telnyx/Telnyx-dotnet/badge.svg?branch=master)](https://coveralls.io/github/Telnyx/Telnyx-dotnet?branch=master)

The official Telnyx library, supporting .NET Standard 2.0, .NET Core 1.0+, and .NET Framework 4.5+

## Documentation

See the [.NET API docs](https://developers.telnyx.com/docs/api/v2/overview?lang=dotnet).

## Installation

### Install Telnyx.net via NuGet

From the command line:

	nuget install Telnyx.net

From Package Manager:

	PM> Install-Package Telnyx.net

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Telnyx.net".
5. Click on the Telnyx.net package, select the appropriate version in the right-tab and click *Install*.

### Set the API Key for your project

You can configure the Telnyx.net package to use your secret API key in one of two ways:

a) In your application initialization, set your API Key (only once during startup):

```csharp
TelnyxConfiguration.SetApiKey("YOUR_API_KEY");
```

b) Pass the API key to [RequestOptions](#requestoptions):

```csharp
var numberReservationsService = new NumberReservationsService();
numberReservationsService.Get("PHONE_NUMBER_ID", new RequestOptions { ApiKey = "YOUR_API_KEY" });
```

You can obtain your secret API key from the [Auth](https://portal.telnyx.com/#/app/auth/v2) section oin the Mission Control Portal.

### Xamarin/Mono Developers (Optional)

If you are using Xamarin/Mono, you may want to provide your own `HttpMessageHandler`. You can do so by passing an instance to `TelnyxConfiguration.HttpMessageHandler` on your application's startup.

## Support

* Make sure to review open [issues](https://github.com/team-telnyx/telnyx-dotnet/issues) and [pull requests](https://github.com/team-telnyx/telnyx-dotnet/pulls) before opening a new issue.
* Feel free to leave a comment or [reaction](https://github.com/blog/2119-add-reactions-to-pull-requests-issues-and-comments) on any existing issues.
* For all other support requests, please [reach out to the Telnyx support team](https://telnyx.com/contact-us).

## Helpful Library Information

### Run Test Project via Docker CLI

In order to run the tests you need to have the telnyx-mock running on your local port. This mock is used to mimic the Telnyx API in order to ensure responses will be correct. 

Steps to install and run the telynx-mock can be found here: [readme](https://github.com/team-telnyx/telnyx-mock/blob/master/README.md)

Explicit steps are as follows:

 * Make sure you have docker installed. This can be either windows/mac/linux. 
 * Run the docker pull cmd: `docker pull telnyx/telnyx-mock:latest` 
 * Verify the image is pulled correctly: `docker images`
 * If you see the image listed, now we can run the image: `docker run -p 12111-12112:12111-12112 telnyx/telnyx-mock`
 * Keep this powershell or cmdline window open and run the TelynxTests project via test runner or dotnet-cli
 * Add your API key to the appsettings file. For NET45+ use `App.config` for `netstandard/netcore use appsettings.json` found in the test project 

### Run Telnyx.Example Project with your API Key
 In oder to get the Example project to run properly, you can add your API Key to the `appsettings.json` file similar to above. 
 Here you can play around with the console app without requiring the telnyx-mock to run. 
 NOTE: This will hit the API directly so be aware of the different operations you are trying as rate limiting applies. 

### Request Options

All of the service methods accept an optional `RequestOptions` object. This is used if you want to pass the secret API key on each method.

```csharp
var requestOptions = new RequestOptions();
requestOptions.ApiKey = "YOUR_API_KEY";                        // (optional) set the api key on a per-request basis
```

### Responses

The [`TelnyxResponse`](https://github.com/team-telnyx/telnyx-dotnet/blob/master/src/Telnyx.net/Infrastructure/Public/TelnyxResponse.cs) object is an attribute (with the same name) attached to all entities in Telnyx.net when they are returned from a service call.

**Example: Access the TelnyxResponse**
```csharp
var numberReservationsService = new NumberReservationsService();
NumberReservation reservation = numberReservationsService.Create(...);
TelnyxResponse response = reservation.TelnyxResponse;
```

The information that can be derived from the `TelnyxResponse` is available from the [TelnyxResponse Class](https://github.com/team-telnyx/telnyx-dotnet/blob/master/src/Telnyx.net/Infrastructure/Public/TelnyxResponse.cs).

```csharp
public class TelnyxResponse
{
	// ResponseJson will always tell you the complete json Telnyx returned to Telnyx.net.
	// this will be the same as the ObjectJson when you execute a create/get/delete call.
	// however, if you execute a List() method, the ResponseJson will have the full api result
	// from Telnyx (a phone number list with 10 phone numbers, for example).
	public string ResponseJson { get; set; }

	// when you call a List() method, the object json is the object in the response array that represents
	// the entity. The ResponseJson will be the full array returned from Telnyx on every entity, however,
	// since that was the full response from Telnyx. ObjectJson is always the same as ResponseJson when
	// you are doing a regular create/get/delete, because you are dealing with a single object.
	public string ObjectJson { get; set; }

	// this is the request id of the call. I would recommend logging
	// this and/or saving it to your database. this is very useful when troubleshooting with Telnyx support
	public string RequestId { get; set; }

	// this is the request date and time of the call. I would also recommend logging this and/or
	// saving it to your database, as it tells you when Telnyx processed the request.
	public DateTime RequestDate { get; set; }
}
```

## Contribution Guidelines

We welcome contributions from anyone interested in Telnyx or Telnyx.net development. If you'd like to submit a pull request, it's best to start with an issue to describe what you'd like to build.

Once you've written your pull request, **please make sure you test your changes**.

## Acknowledgments

The contributors and maintainers of Telnyx .NET would like to extend their
deep gratitude to the authors of [Stripe .NET][stripe-dotnet], upon which
this project is based. Thank you for developing such elegant, usable, and
extensible code and for sharing it with the community.

[stripe-dotnet]: https://github.com/telnyx/telnyx-dotnet
