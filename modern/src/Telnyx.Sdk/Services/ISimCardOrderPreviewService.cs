using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardOrderPreview;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIM Card Orders operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISimCardOrderPreviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimCardOrderPreviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardOrderPreviewService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Previews a SIM card order purchase, returning estimated costs and details before
/// you place the order. The preview is processed asynchronously.
/// </summary>
    Task<SimCardOrderPreviewPreviewResponse> Preview(
        SimCardOrderPreviewPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISimCardOrderPreviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimCardOrderPreviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardOrderPreviewServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_order_preview</c>, but is otherwise the
/// same as <see cref="ISimCardOrderPreviewService.Preview(SimCardOrderPreviewPreviewParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardOrderPreviewPreviewResponse>> Preview(
        SimCardOrderPreviewPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}