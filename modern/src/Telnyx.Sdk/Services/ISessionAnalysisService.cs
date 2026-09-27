using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SessionAnalysis;
using Telnyx.Sdk.Services.SessionAnalysis;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Analyze voice AI sessions, costs, and event hierarchies across Telnyx products.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISessionAnalysisService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISessionAnalysisServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionAnalysisService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IMetadataService Metadata { get; }

    /// <summary>
/// Retrieves a full session analysis tree for a given event, including costs, child
/// events, and product linkages.
/// </summary>
    Task<SessionAnalysisRetrieveResponse> Retrieve(
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SessionAnalysisRetrieveParams, CancellationToken)"/>
    Task<SessionAnalysisRetrieveResponse> Retrieve(
        string eventID,
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISessionAnalysisService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISessionAnalysisServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionAnalysisServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IMetadataServiceWithRawResponse Metadata { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /session_analysis/{record_type}/{event_id}</c>, but is otherwise the
/// same as <see cref="ISessionAnalysisService.Retrieve(SessionAnalysisRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SessionAnalysisRetrieveResponse>> Retrieve(
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SessionAnalysisRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SessionAnalysisRetrieveResponse>> Retrieve(
        string eventID,
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}