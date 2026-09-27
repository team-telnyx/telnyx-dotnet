using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WebSearch;
using Telnyx.Sdk.Services.WebSearch;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebSearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebSearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebSearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IResearchService Research { get; }

    /// <summary>
/// Performs a real-time web search and returns structured, LLM-ready JSON results
/// with titles, URLs, descriptions, and snippets. Supports filtering by domain,
/// country, safe search, freshness, and live crawl.
/// 
/// <para>**Note:** `include_domains` and `exclude_domains` cannot be used in the
/// same request. Use one or the other.</para>
/// </summary>
    Task<WebSearchCreateResponse> Create(
        WebSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves clean HTML or Markdown content from a list of URLs. Supports up to 20
/// URLs per request (public API limit). Specify which formats to return: `html`,
/// `markdown`, `metadata`.
/// </summary>
    Task<WebSearchContentsResponse> Contents(
        WebSearchContentsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWebSearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebSearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebSearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IResearchServiceWithRawResponse Research { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /web_search</c>, but is otherwise the
/// same as <see cref="IWebSearchService.Create(WebSearchCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WebSearchCreateResponse>> Create(
        WebSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /web_search/contents</c>, but is otherwise the
/// same as <see cref="IWebSearchService.Contents(WebSearchContentsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WebSearchContentsResponse>> Contents(
        WebSearchContentsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}