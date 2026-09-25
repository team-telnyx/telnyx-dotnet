using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallControlApplications;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Call Control applications operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallControlApplicationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallControlApplicationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallControlApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a call control application, which defines the webhook endpoints and
/// settings used to control calls on associated connections.
/// </summary>
    Task<CallControlApplicationCreateResponse> Create(
        CallControlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing call control application.
/// </summary>
    Task<CallControlApplicationRetrieveResponse> Retrieve(
        CallControlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallControlApplicationRetrieveParams, CancellationToken)"/>
    Task<CallControlApplicationRetrieveResponse> Retrieve(
        string id,
        CallControlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing call control application.
/// </summary>
    Task<CallControlApplicationUpdateResponse> Update(
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallControlApplicationUpdateParams, CancellationToken)"/>
    Task<CallControlApplicationUpdateResponse> Update(
        string id,
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return a list of call control applications.
/// </summary>
    Task<CallControlApplicationListPage> List(
        CallControlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified call control application and its webhook
/// configuration.
/// </summary>
    Task<CallControlApplicationDeleteResponse> Delete(
        CallControlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CallControlApplicationDeleteParams, CancellationToken)"/>
    Task<CallControlApplicationDeleteResponse> Delete(
        string id,
        CallControlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallControlApplicationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallControlApplicationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallControlApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /call_control_applications</c>, but is otherwise the
/// same as <see cref="ICallControlApplicationService.Create(CallControlApplicationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallControlApplicationCreateResponse>> Create(
        CallControlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /call_control_applications/{id}</c>, but is otherwise the
/// same as <see cref="ICallControlApplicationService.Retrieve(CallControlApplicationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallControlApplicationRetrieveResponse>> Retrieve(
        CallControlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallControlApplicationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallControlApplicationRetrieveResponse>> Retrieve(
        string id,
        CallControlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /call_control_applications/{id}</c>, but is otherwise the
/// same as <see cref="ICallControlApplicationService.Update(CallControlApplicationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallControlApplicationUpdateResponse>> Update(
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallControlApplicationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CallControlApplicationUpdateResponse>> Update(
        string id,
        CallControlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /call_control_applications</c>, but is otherwise the
/// same as <see cref="ICallControlApplicationService.List(CallControlApplicationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallControlApplicationListPage>> List(
        CallControlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /call_control_applications/{id}</c>, but is otherwise the
/// same as <see cref="ICallControlApplicationService.Delete(CallControlApplicationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallControlApplicationDeleteResponse>> Delete(
        CallControlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CallControlApplicationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CallControlApplicationDeleteResponse>> Delete(
        string id,
        CallControlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}