using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingHostedNumberOrders.Actions;

namespace Telnyx.Sdk.Services.MessagingHostedNumberOrders;

/// <summary>
/// Manage your messaging hosted numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Uploads a supporting document to the specified hosted-messaging order.
/// </summary>
    Task<ActionUploadFileResponse> UploadFile(
        ActionUploadFileParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UploadFile(ActionUploadFileParams, CancellationToken)"/>
    Task<ActionUploadFileResponse> UploadFile(
        string id,
        ActionUploadFileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_hosted_number_orders/{id}/actions/file_upload</c>, but is otherwise the
/// same as <see cref="IActionService.UploadFile(ActionUploadFileParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUploadFileResponse>> UploadFile(
        ActionUploadFileParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UploadFile(ActionUploadFileParams, CancellationToken)"/>
    Task<HttpResponse<ActionUploadFileResponse>> UploadFile(
        string id,
        ActionUploadFileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}