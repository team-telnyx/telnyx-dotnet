using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants;
using Telnyx.Sdk.Models.AI.Assistants.Versions;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieves a specific version of an assistant by assistant_id and version_id
/// </summary>
    Task<InferenceEmbedding> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<InferenceEmbedding> Retrieve(
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the configuration of a specific assistant version. Can not update main
/// version
/// </summary>
    Task<InferenceEmbedding> Update(
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VersionUpdateParams, CancellationToken)"/>
    Task<InferenceEmbedding> Update(
        string versionID,
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves all versions of a specific assistant with complete configuration and
/// metadata
/// </summary>
    Task<AssistantsList> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<AssistantsList> List(
        string assistantID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently removes a specific version of an assistant. Can not delete main
/// version
/// </summary>
    Task Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Promotes a specific version to be the main/current version of the assistant.
/// This will delete any existing canary deploy configuration and send all live
/// production traffic to this version.
/// </summary>
    Task<InferenceEmbedding> Promote(
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Promote(VersionPromoteParams, CancellationToken)"/>
    Task<InferenceEmbedding> Promote(
        string versionID,
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/versions/{version_id}</c>, but is otherwise the
/// same as <see cref="IVersionService.Retrieve(VersionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Retrieve(
        string versionID,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/versions/{version_id}</c>, but is otherwise the
/// same as <see cref="IVersionService.Update(VersionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Update(
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VersionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Update(
        string versionID,
        VersionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/versions</c>, but is otherwise the
/// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AssistantsList>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<AssistantsList>> List(
        string assistantID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}/versions/{version_id}</c>, but is otherwise the
/// same as <see cref="IVersionService.Delete(VersionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string versionID,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/versions/{version_id}/promote</c>, but is otherwise the
/// same as <see cref="IVersionService.Promote(VersionPromoteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InferenceEmbedding>> Promote(
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Promote(VersionPromoteParams, CancellationToken)"/>
    Task<HttpResponse<InferenceEmbedding>> Promote(
        string versionID,
        VersionPromoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}