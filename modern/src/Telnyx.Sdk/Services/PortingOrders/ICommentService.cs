using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.Comments;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICommentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new comment for a porting order.
/// </summary>
    Task<CommentCreateResponse> Create(
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CommentCreateParams, CancellationToken)"/>
    Task<CommentCreateResponse> Create(
        string id,
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all comments of a porting order.
/// </summary>
    Task<CommentListPage> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CommentListParams, CancellationToken)"/>
    Task<CommentListPage> List(
        string id,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICommentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICommentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/comments</c>, but is otherwise the
/// same as <see cref="ICommentService.Create(CommentCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentCreateResponse>> Create(
        CommentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CommentCreateParams, CancellationToken)"/>
    Task<HttpResponse<CommentCreateResponse>> Create(
        string id,
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{id}/comments</c>, but is otherwise the
/// same as <see cref="ICommentService.List(CommentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentListPage>> List(
        CommentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CommentListParams, CancellationToken)"/>
    Task<HttpResponse<CommentListPage>> List(
        string id,
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}