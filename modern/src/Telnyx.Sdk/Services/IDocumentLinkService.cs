using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DocumentLinks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Documents
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDocumentLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDocumentLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentLinkService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// List all documents links ordered by created_at descending.
/// </summary>
    Task<DocumentLinkListPage> List(
        DocumentLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDocumentLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDocumentLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /document_links</c>, but is otherwise the
/// same as <see cref="IDocumentLinkService.List(DocumentLinkListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DocumentLinkListPage>> List(
        DocumentLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}