using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Integrations;
using Integrations = Telnyx.Sdk.Services.AI.Integrations;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntegrationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntegrationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Integrations::IConnectionService Connections { get; }

    /// <summary>
/// Returns the details of a single available integration, including its
/// configuration details.
/// </summary>
    Task<Integration> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<Integration> Retrieve(
        string integrationID,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the list of third-party integrations available to connect to your AI
/// assistants and workflows.
/// </summary>
    Task<IntegrationListResponse> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IIntegrationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntegrationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Integrations::IConnectionServiceWithRawResponse Connections { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/integrations/{integration_id}</c>, but is otherwise the
/// same as <see cref="IIntegrationService.Retrieve(IntegrationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Integration>> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Integration>> Retrieve(
        string integrationID,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/integrations</c>, but is otherwise the
/// same as <see cref="IIntegrationService.List(IntegrationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IntegrationListResponse>> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}