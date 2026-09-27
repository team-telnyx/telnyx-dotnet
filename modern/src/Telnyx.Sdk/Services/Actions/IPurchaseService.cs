using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Actions.Purchase;

namespace Telnyx.Sdk.Services.Actions;

/// <summary>
/// SIM Cards operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPurchaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPurchaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPurchaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Purchases and registers the specified amount of eSIMs to the current user's
/// account.&lt;br/&gt;&lt;br/&gt; If &lt;code&gt;sim_card_group_id&lt;/code&gt; is
/// provided, the eSIMs will be associated with that group. Otherwise, the default
/// group for the current user will be used.&lt;br/&gt;&lt;br/&gt;
/// </summary>
    Task<PurchaseCreateResponse> Create(
        PurchaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPurchaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPurchaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPurchaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /actions/purchase/esims</c>, but is otherwise the
/// same as <see cref="IPurchaseService.Create(PurchaseCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PurchaseCreateResponse>> Create(
        PurchaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}