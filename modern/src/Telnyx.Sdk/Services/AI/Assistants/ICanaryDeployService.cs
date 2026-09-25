using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICanaryDeployService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICanaryDeployServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICanaryDeployService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Endpoint to create a canary deploy configuration for an assistant.
/// 
/// <para>Creates a new canary deploy configuration with multiple version IDs and
/// their traffic percentages for A/B testing or gradual rollouts of assistant
/// versions.</para>
/// </summary>
    Task<CanaryDeployResponse> Create(
        CanaryDeployCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CanaryDeployCreateParams, CancellationToken)"/>
    Task<CanaryDeployResponse> Create(
        string assistantID,
        CanaryDeployCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Endpoint to get a canary deploy configuration for an assistant.
/// 
/// <para>Retrieves the current canary deploy configuration with all version IDs and
/// their traffic percentages for the specified assistant.</para>
/// </summary>
    Task<CanaryDeployResponse> Retrieve(
        CanaryDeployRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CanaryDeployRetrieveParams, CancellationToken)"/>
    Task<CanaryDeployResponse> Retrieve(
        string assistantID,
        CanaryDeployRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Endpoint to update a canary deploy configuration for an assistant.
/// 
/// <para>Updates the existing canary deploy configuration with new version IDs and
/// percentages.   All old versions and percentages are replaces by new ones from
/// this request.</para>
/// </summary>
    Task<CanaryDeployResponse> Update(
        CanaryDeployUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CanaryDeployUpdateParams, CancellationToken)"/>
    Task<CanaryDeployResponse> Update(
        string assistantID,
        CanaryDeployUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Endpoint to delete a canary deploy configuration for an assistant.
/// 
/// <para>Removes all canary deploy configurations for the specified assistant.</para>
/// </summary>
    Task Delete(
        CanaryDeployDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CanaryDeployDeleteParams, CancellationToken)"/>
    Task Delete(
        string assistantID,
        CanaryDeployDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICanaryDeployService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICanaryDeployServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICanaryDeployServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/canary-deploys</c>, but is otherwise the
/// same as <see cref="ICanaryDeployService.Create(CanaryDeployCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CanaryDeployResponse>> Create(
        CanaryDeployCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(CanaryDeployCreateParams, CancellationToken)"/>
    Task<HttpResponse<CanaryDeployResponse>> Create(
        string assistantID,
        CanaryDeployCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/assistants/{assistant_id}/canary-deploys</c>, but is otherwise the
/// same as <see cref="ICanaryDeployService.Retrieve(CanaryDeployRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CanaryDeployResponse>> Retrieve(
        CanaryDeployRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CanaryDeployRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CanaryDeployResponse>> Retrieve(
        string assistantID,
        CanaryDeployRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/assistants/{assistant_id}/canary-deploys</c>, but is otherwise the
/// same as <see cref="ICanaryDeployService.Update(CanaryDeployUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CanaryDeployResponse>> Update(
        CanaryDeployUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CanaryDeployUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CanaryDeployResponse>> Update(
        string assistantID,
        CanaryDeployUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/assistants/{assistant_id}/canary-deploys</c>, but is otherwise the
/// same as <see cref="ICanaryDeployService.Delete(CanaryDeployDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        CanaryDeployDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CanaryDeployDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string assistantID,
        CanaryDeployDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}