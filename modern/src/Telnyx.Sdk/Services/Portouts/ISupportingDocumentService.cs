using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Portouts.SupportingDocuments;

namespace Telnyx.Sdk.Services.Portouts;

/// <summary>
/// Number portout operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISupportingDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISupportingDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupportingDocumentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a list of supporting documents on a portout request.
/// </summary>
    Task<SupportingDocumentCreateResponse> Create(
        SupportingDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SupportingDocumentCreateParams, CancellationToken)"/>
    Task<SupportingDocumentCreateResponse> Create(
        string id,
        SupportingDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List every supporting documents for a portout request.
/// </summary>
    Task<SupportingDocumentListResponse> List(
        SupportingDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SupportingDocumentListParams, CancellationToken)"/>
    Task<SupportingDocumentListResponse> List(
        string id,
        SupportingDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISupportingDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISupportingDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupportingDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /portouts/{id}/supporting_documents</c>, but is otherwise the
/// same as <see cref="ISupportingDocumentService.Create(SupportingDocumentCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SupportingDocumentCreateResponse>> Create(
        SupportingDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SupportingDocumentCreateParams, CancellationToken)"/>
    Task<HttpResponse<SupportingDocumentCreateResponse>> Create(
        string id,
        SupportingDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /portouts/{id}/supporting_documents</c>, but is otherwise the
/// same as <see cref="ISupportingDocumentService.List(SupportingDocumentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SupportingDocumentListResponse>> List(
        SupportingDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SupportingDocumentListParams, CancellationToken)"/>
    Task<HttpResponse<SupportingDocumentListResponse>> List(
        string id,
        SupportingDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}