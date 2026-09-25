using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Brand.ExternalVetting;

namespace Telnyx.Sdk.Services.Messaging10dlc.Brand;

/// <summary>
/// Brand operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExternalVettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalVettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalVettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Get list of valid external vetting record for a given brand
/// </summary>
    Task<List<ExternalVettingExternalVetting>> List(
        ExternalVettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ExternalVettingListParams, CancellationToken)"/>
    Task<List<ExternalVettingExternalVetting>> List(
        string brandID,
        ExternalVettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This operation can be used to import an external vetting record from a
/// TCR-approved vetting provider. If the vetting provider confirms validity of the
/// record, it will be saved with the brand and will be considered for future
/// campaign qualification.
/// </summary>
    Task<ExternalVettingExternalVetting> Imports(
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Imports(ExternalVettingImportsParams, CancellationToken)"/>
    Task<ExternalVettingExternalVetting> Imports(
        string brandID,
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Order new external vetting for a brand.
/// 
/// <para>Duplicate orders for the same `evpId` and `vettingClass` return `400` with
/// code `10012` if a successful vetting exists within the last 180 days, or one is
/// currently being processed. Failed vettings can be retried immediately.</para>
/// </summary>
    Task<ExternalVettingExternalVetting> Order(
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Order(ExternalVettingOrderParams, CancellationToken)"/>
    Task<ExternalVettingExternalVetting> Order(
        string brandID,
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IExternalVettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalVettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalVettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand/{brandId}/externalVetting</c>, but is otherwise the
/// same as <see cref="IExternalVettingService.List(ExternalVettingListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<ExternalVettingExternalVetting>>> List(
        ExternalVettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ExternalVettingListParams, CancellationToken)"/>
    Task<HttpResponse<List<ExternalVettingExternalVetting>>> List(
        string brandID,
        ExternalVettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/brand/{brandId}/externalVetting</c>, but is otherwise the
/// same as <see cref="IExternalVettingService.Imports(ExternalVettingImportsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalVettingExternalVetting>> Imports(
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Imports(ExternalVettingImportsParams, CancellationToken)"/>
    Task<HttpResponse<ExternalVettingExternalVetting>> Imports(
        string brandID,
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/brand/{brandId}/externalVetting</c>, but is otherwise the
/// same as <see cref="IExternalVettingService.Order(ExternalVettingOrderParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalVettingExternalVetting>> Order(
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Order(ExternalVettingOrderParams, CancellationToken)"/>
    Task<HttpResponse<ExternalVettingExternalVetting>> Order(
        string brandID,
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}