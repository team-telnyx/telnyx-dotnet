using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumberLookup;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Look up phone number data
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberLookupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberLookupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberLookupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns information about the provided phone number.
/// </summary>
    Task<NumberLookupRetrieveResponse> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>
    Task<NumberLookupRetrieveResponse> Retrieve(
        string phoneNumber,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberLookupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberLookupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberLookupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_lookup/{phone_number}</c>, but is otherwise the
/// same as <see cref="INumberLookupService.Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        NumberLookupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberLookupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberLookupRetrieveResponse>> Retrieve(
        string phoneNumber,
        NumberLookupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}