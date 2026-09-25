using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OtaUpdates;

namespace Telnyx.Sdk.Services;

/// <summary>
/// OTA updates operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOtaUpdateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOtaUpdateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOtaUpdateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// This API returns the details of an Over the Air (OTA) update.
/// </summary>
    Task<OtaUpdateRetrieveResponse> Retrieve(
        OtaUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OtaUpdateRetrieveParams, CancellationToken)"/>
    Task<OtaUpdateRetrieveResponse> Retrieve(
        string id,
        OtaUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of over-the-air (OTA) update operations for your SIM
/// cards.
/// </summary>
    Task<OtaUpdateListPage> List(
        OtaUpdateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOtaUpdateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOtaUpdateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOtaUpdateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ota_updates/{id}</c>, but is otherwise the
/// same as <see cref="IOtaUpdateService.Retrieve(OtaUpdateRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OtaUpdateRetrieveResponse>> Retrieve(
        OtaUpdateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(OtaUpdateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OtaUpdateRetrieveResponse>> Retrieve(
        string id,
        OtaUpdateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ota_updates</c>, but is otherwise the
/// same as <see cref="IOtaUpdateService.List(OtaUpdateListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<OtaUpdateListPage>> List(
        OtaUpdateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}