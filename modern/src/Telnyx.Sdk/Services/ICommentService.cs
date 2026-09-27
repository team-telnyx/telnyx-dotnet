using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Comments;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number orders
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
/// Creates a comment associated with a supported number-order record. The response
/// contains the created comment.
/// </summary>
    Task<CommentCreateResponse> Create(
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the comment identified by `id`, including its associated record and
/// comment metadata.
/// </summary>
    Task<CommentRetrieveResponse> Retrieve(
        CommentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CommentRetrieveParams, CancellationToken)"/>
    Task<CommentRetrieveResponse> Retrieve(
        string id,
        CommentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns comments associated with number-order records. Results can be filtered
/// by record type and record ID and include pagination metadata.
/// </summary>
    Task<CommentListResponse> List(
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Marks the specified comment as read. The response contains the updated read
/// state for the comment.
/// </summary>
    Task<CommentMarkAsReadResponse> MarkAsRead(
        CommentMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="MarkAsRead(CommentMarkAsReadParams, CancellationToken)"/>
    Task<CommentMarkAsReadResponse> MarkAsRead(
        string id,
        CommentMarkAsReadParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /comments</c>, but is otherwise the
/// same as <see cref="ICommentService.Create(CommentCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentCreateResponse>> Create(
        CommentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /comments/{id}</c>, but is otherwise the
/// same as <see cref="ICommentService.Retrieve(CommentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentRetrieveResponse>> Retrieve(
        CommentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CommentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CommentRetrieveResponse>> Retrieve(
        string id,
        CommentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /comments</c>, but is otherwise the
/// same as <see cref="ICommentService.List(CommentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentListResponse>> List(
        CommentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /comments/{id}/read</c>, but is otherwise the
/// same as <see cref="ICommentService.MarkAsRead(CommentMarkAsReadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CommentMarkAsReadResponse>> MarkAsRead(
        CommentMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="MarkAsRead(CommentMarkAsReadParams, CancellationToken)"/>
    Task<HttpResponse<CommentMarkAsReadResponse>> MarkAsRead(
        string id,
        CommentMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}