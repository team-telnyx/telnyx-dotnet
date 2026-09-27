using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Filters;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <summary>
/// Create and manage agent inboxes, retrieve inbound messages and threads, and reply
/// to or forward messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFilterService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFilterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFilterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the inbox's sender allowlist and blocklist. Entries are normalized to
/// lowercase. A blocklist match takes precedence over an allowlist match; when both
/// lists are empty, all senders are accepted.
/// </summary>
    Task<FilterListResponse> List(
        FilterListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(FilterListParams, CancellationToken)"/>
    Task<FilterListResponse> List(
        string inboxID,
        FilterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Adds entries to either the allowlist or blocklist. The operation is an
/// idempotent set union: entries already present remain unchanged.
/// </summary>
    Task<FilterAddResponse> Add(
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(FilterAddParams, CancellationToken)"/>
    Task<FilterAddResponse> Add(
        string inboxID,
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes entries from either the allowlist or blocklist. The operation is
/// idempotent: removing an entry that is not present still returns the current
/// filter lists.
/// </summary>
    Task<FilterDeleteAllResponse> DeleteAll(
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(FilterDeleteAllParams, CancellationToken)"/>
    Task<FilterDeleteAllResponse> DeleteAll(
        string inboxID,
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces both sender filter lists atomically. Omitting either list clears that
/// list. Use `POST` or `DELETE` for incremental changes.
/// </summary>
    Task<FilterReplaceResponse> Replace(
        FilterReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(FilterReplaceParams, CancellationToken)"/>
    Task<FilterReplaceResponse> Replace(
        string inboxID,
        FilterReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFilterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFilterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFilterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_inboxes/{inbox_id}/filters</c>, but is otherwise the
/// same as <see cref="IFilterService.List(FilterListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FilterListResponse>> List(
        FilterListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(FilterListParams, CancellationToken)"/>
    Task<HttpResponse<FilterListResponse>> List(
        string inboxID,
        FilterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_inboxes/{inbox_id}/filters</c>, but is otherwise the
/// same as <see cref="IFilterService.Add(FilterAddParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FilterAddResponse>> Add(
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(FilterAddParams, CancellationToken)"/>
    Task<HttpResponse<FilterAddResponse>> Add(
        string inboxID,
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_inboxes/{inbox_id}/filters</c>, but is otherwise the
/// same as <see cref="IFilterService.DeleteAll(FilterDeleteAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FilterDeleteAllResponse>> DeleteAll(
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(FilterDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse<FilterDeleteAllResponse>> DeleteAll(
        string inboxID,
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /email_inboxes/{inbox_id}/filters</c>, but is otherwise the
/// same as <see cref="IFilterService.Replace(FilterReplaceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FilterReplaceResponse>> Replace(
        FilterReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(FilterReplaceParams, CancellationToken)"/>
    Task<HttpResponse<FilterReplaceResponse>> Replace(
        string inboxID,
        FilterReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}