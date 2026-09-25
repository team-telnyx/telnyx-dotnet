using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tags;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITagServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve all tags that have been applied to your AI assistants.
/// </summary>
    Task<TagsResponse> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Add a tag to an AI assistant. Tags help you organize and filter your assistants.
/// </summary>
    Task<TagsResponse> Add(
        TagAddParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(TagAddParams, CancellationToken)"/>
    Task<TagsResponse> Add(
        string assistantID,
        TagAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified tag from the AI assistant and returns the assistant's
/// updated tag list.
/// </summary>
    Task<TagsResponse> Remove(
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(TagRemoveParams, CancellationToken)"/>
    Task<TagsResponse> Remove(
        string tag,
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITagService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITagServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/tags</c>, but is otherwise the
/// same as <see cref="ITagService.List(TagListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TagsResponse>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/tags</c>, but is otherwise the
/// same as <see cref="ITagService.Add(TagAddParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TagsResponse>> Add(
        TagAddParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(TagAddParams, CancellationToken)"/>
    Task<HttpResponse<TagsResponse>> Add(
        string assistantID,
        TagAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}/tags/{tag}</c>, but is otherwise the
/// same as <see cref="ITagService.Remove(TagRemoveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TagsResponse>> Remove(
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(TagRemoveParams, CancellationToken)"/>
    Task<HttpResponse<TagsResponse>> Remove(
        string tag,
        TagRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}