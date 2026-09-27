using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SessionAnalysis.Metadata;

namespace Telnyx.Sdk.Services.SessionAnalysis;

/// <summary>
/// Analyze voice AI sessions, costs, and event hierarchies across Telnyx products.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMetadataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMetadataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns all available record types and supported query parameters for session
/// analysis.
/// </summary>
    Task<MetadataRetrieveResponse> Retrieve(
        MetadataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns detailed metadata for a specific record type, including relationships
/// and examples.
/// </summary>
    Task<MetadataRetrieveRecordTypeResponse> RetrieveRecordType(
        MetadataRetrieveRecordTypeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordType(MetadataRetrieveRecordTypeParams, CancellationToken)"/>
    Task<MetadataRetrieveRecordTypeResponse> RetrieveRecordType(
        string recordType,
        MetadataRetrieveRecordTypeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMetadataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMetadataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /session_analysis/metadata</c>, but is otherwise the
/// same as <see cref="IMetadataService.Retrieve(MetadataRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MetadataRetrieveResponse>> Retrieve(
        MetadataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /session_analysis/metadata/{record_type}</c>, but is otherwise the
/// same as <see cref="IMetadataService.RetrieveRecordType(MetadataRetrieveRecordTypeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MetadataRetrieveRecordTypeResponse>> RetrieveRecordType(
        MetadataRetrieveRecordTypeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordType(MetadataRetrieveRecordTypeParams, CancellationToken)"/>
    Task<HttpResponse<MetadataRetrieveRecordTypeResponse>> RetrieveRecordType(
        string recordType,
        MetadataRetrieveRecordTypeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}