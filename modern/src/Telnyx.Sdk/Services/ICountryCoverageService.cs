using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CountryCoverage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Country Coverage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICountryCoverageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICountryCoverageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICountryCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns Telnyx service coverage information for every country, including which
/// number types and features are available in each.
/// </summary>
    Task<CountryCoverageRetrieveResponse> Retrieve(
        CountryCoverageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns Telnyx service coverage information for the specified country, including
/// available number types and features.
/// </summary>
    Task<CountryCoverageRetrieveCountryResponse> RetrieveCountry(
        CountryCoverageRetrieveCountryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCountry(CountryCoverageRetrieveCountryParams, CancellationToken)"/>
    Task<CountryCoverageRetrieveCountryResponse> RetrieveCountry(
        string countryCode,
        CountryCoverageRetrieveCountryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICountryCoverageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICountryCoverageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICountryCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /country_coverage</c>, but is otherwise the
/// same as <see cref="ICountryCoverageService.Retrieve(CountryCoverageRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CountryCoverageRetrieveResponse>> Retrieve(
        CountryCoverageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /country_coverage/countries/{country_code}</c>, but is otherwise the
/// same as <see cref="ICountryCoverageService.RetrieveCountry(CountryCoverageRetrieveCountryParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CountryCoverageRetrieveCountryResponse>> RetrieveCountry(
        CountryCoverageRetrieveCountryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCountry(CountryCoverageRetrieveCountryParams, CancellationToken)"/>
    Task<HttpResponse<CountryCoverageRetrieveCountryResponse>> RetrieveCountry(
        string countryCode,
        CountryCoverageRetrieveCountryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}