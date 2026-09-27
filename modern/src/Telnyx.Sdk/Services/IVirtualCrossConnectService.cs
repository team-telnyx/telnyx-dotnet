using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VirtualCrossConnects;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Virtual Cross Connect operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVirtualCrossConnectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVirtualCrossConnectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVirtualCrossConnectService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new Virtual Cross Connect.&lt;br /&gt;&lt;br /&gt;For AWS and GCE, you
/// have the option of creating the primary connection first and the secondary
/// connection later. You also have the option of disabling the primary and/or
/// secondary connections at any time and later re-enabling them. With Azure, you do
/// not have this option. Azure requires both the primary and secondary connections
/// to be created at the same time and they can not be independantly disabled.
/// </summary>
    Task<VirtualCrossConnectCreateResponse> Create(
        VirtualCrossConnectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single virtual cross connect by its identifier.
/// </summary>
    Task<VirtualCrossConnectRetrieveResponse> Retrieve(
        VirtualCrossConnectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VirtualCrossConnectRetrieveParams, CancellationToken)"/>
    Task<VirtualCrossConnectRetrieveResponse> Retrieve(
        string id,
        VirtualCrossConnectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the Virtual Cross Connect.&lt;br /&gt;&lt;br /&gt;Cloud IPs can only be
/// patched during the `created` state, as GCE will only inform you of your
/// generated IP once the pending connection requested has been accepted. Once the
/// Virtual Cross Connect has moved to `provisioning`, the IPs can no longer be
/// patched.&lt;br /&gt;&lt;br /&gt;Once the Virtual Cross Connect has moved to
/// `provisioned` and you are ready to enable routing, you can toggle the routing
/// announcements to `true`.
/// </summary>
    Task<VirtualCrossConnectUpdateResponse> Update(
        VirtualCrossConnectUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VirtualCrossConnectUpdateParams, CancellationToken)"/>
    Task<VirtualCrossConnectUpdateResponse> Update(
        string id,
        VirtualCrossConnectUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the virtual cross connects on your account, with
/// support for filtering.
/// </summary>
    Task<VirtualCrossConnectListPage> List(
        VirtualCrossConnectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified virtual cross connect from your account.
/// </summary>
    Task<VirtualCrossConnectDeleteResponse> Delete(
        VirtualCrossConnectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VirtualCrossConnectDeleteParams, CancellationToken)"/>
    Task<VirtualCrossConnectDeleteResponse> Delete(
        string id,
        VirtualCrossConnectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVirtualCrossConnectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVirtualCrossConnectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVirtualCrossConnectServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /virtual_cross_connects</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectService.Create(VirtualCrossConnectCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectCreateResponse>> Create(
        VirtualCrossConnectCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /virtual_cross_connects/{id}</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectService.Retrieve(VirtualCrossConnectRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectRetrieveResponse>> Retrieve(
        VirtualCrossConnectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VirtualCrossConnectRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VirtualCrossConnectRetrieveResponse>> Retrieve(
        string id,
        VirtualCrossConnectRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /virtual_cross_connects/{id}</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectService.Update(VirtualCrossConnectUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectUpdateResponse>> Update(
        VirtualCrossConnectUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VirtualCrossConnectUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VirtualCrossConnectUpdateResponse>> Update(
        string id,
        VirtualCrossConnectUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /virtual_cross_connects</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectService.List(VirtualCrossConnectListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectListPage>> List(
        VirtualCrossConnectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /virtual_cross_connects/{id}</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectService.Delete(VirtualCrossConnectDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectDeleteResponse>> Delete(
        VirtualCrossConnectDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VirtualCrossConnectDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VirtualCrossConnectDeleteResponse>> Delete(
        string id,
        VirtualCrossConnectDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}