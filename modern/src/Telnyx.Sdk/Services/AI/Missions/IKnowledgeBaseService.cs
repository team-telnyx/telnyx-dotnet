using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.KnowledgeBases;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IKnowledgeBaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKnowledgeBaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeBaseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new knowledge base for a mission
/// </summary>
    Task<JsonElement> CreateKnowledgeBase(
        KnowledgeBaseCreateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateKnowledgeBase(KnowledgeBaseCreateKnowledgeBaseParams, CancellationToken)"/>
    Task<JsonElement> CreateKnowledgeBase(
        string missionID,
        KnowledgeBaseCreateKnowledgeBaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Detaches the specified knowledge base from the mission so its content is no
/// longer available to agents in subsequent runs.
/// </summary>
    Task DeleteKnowledgeBase(
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteKnowledgeBase(KnowledgeBaseDeleteKnowledgeBaseParams, CancellationToken)"/>
    Task DeleteKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single knowledge base attached to the specified
/// mission.
/// </summary>
    Task<JsonElement> GetKnowledgeBase(
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetKnowledgeBase(KnowledgeBaseGetKnowledgeBaseParams, CancellationToken)"/>
    Task<JsonElement> GetKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the knowledge bases attached to the specified mission. Knowledge bases
/// provide reference content agents can draw on during runs.
/// </summary>
    Task<JsonElement> ListKnowledgeBases(
        KnowledgeBaseListKnowledgeBasesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListKnowledgeBases(KnowledgeBaseListKnowledgeBasesParams, CancellationToken)"/>
    Task<JsonElement> ListKnowledgeBases(
        string missionID,
        KnowledgeBaseListKnowledgeBasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the definition of the specified knowledge base on this mission.
/// </summary>
    Task<JsonElement> UpdateKnowledgeBase(
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateKnowledgeBase(KnowledgeBaseUpdateKnowledgeBaseParams, CancellationToken)"/>
    Task<JsonElement> UpdateKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IKnowledgeBaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKnowledgeBaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeBaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/knowledge-bases</c>, but is otherwise the
/// same as <see cref="IKnowledgeBaseService.CreateKnowledgeBase(KnowledgeBaseCreateKnowledgeBaseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> CreateKnowledgeBase(
        KnowledgeBaseCreateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateKnowledgeBase(KnowledgeBaseCreateKnowledgeBaseParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> CreateKnowledgeBase(
        string missionID,
        KnowledgeBaseCreateKnowledgeBaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/missions/{mission_id}/knowledge-bases/{knowledge_base_id}</c>, but is otherwise the
/// same as <see cref="IKnowledgeBaseService.DeleteKnowledgeBase(KnowledgeBaseDeleteKnowledgeBaseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteKnowledgeBase(
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteKnowledgeBase(KnowledgeBaseDeleteKnowledgeBaseParams, CancellationToken)"/>
    Task<HttpResponse> DeleteKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseDeleteKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/knowledge-bases/{knowledge_base_id}</c>, but is otherwise the
/// same as <see cref="IKnowledgeBaseService.GetKnowledgeBase(KnowledgeBaseGetKnowledgeBaseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> GetKnowledgeBase(
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetKnowledgeBase(KnowledgeBaseGetKnowledgeBaseParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseGetKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/knowledge-bases</c>, but is otherwise the
/// same as <see cref="IKnowledgeBaseService.ListKnowledgeBases(KnowledgeBaseListKnowledgeBasesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> ListKnowledgeBases(
        KnowledgeBaseListKnowledgeBasesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListKnowledgeBases(KnowledgeBaseListKnowledgeBasesParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> ListKnowledgeBases(
        string missionID,
        KnowledgeBaseListKnowledgeBasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/missions/{mission_id}/knowledge-bases/{knowledge_base_id}</c>, but is otherwise the
/// same as <see cref="IKnowledgeBaseService.UpdateKnowledgeBase(KnowledgeBaseUpdateKnowledgeBaseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> UpdateKnowledgeBase(
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateKnowledgeBase(KnowledgeBaseUpdateKnowledgeBaseParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> UpdateKnowledgeBase(
        string knowledgeBaseID,
        KnowledgeBaseUpdateKnowledgeBaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}