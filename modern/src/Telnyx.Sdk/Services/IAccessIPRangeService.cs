using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AccessIPRanges;

namespace Telnyx.Sdk.Services;

/// <summary>
/// IP Range Operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccessIPRangeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccessIPRangeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccessIPRangeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new access IP range on your account.
/// </summary>
    Task<AccessIPRange> Create(
        AccessIPRangeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of access IP ranges configured on your account.
/// </summary>
    Task<AccessIPRangeListPage> List(
        AccessIPRangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete an access IP range from your account.
/// </summary>
    Task<AccessIPRange> Delete(
        AccessIPRangeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AccessIPRangeDeleteParams, CancellationToken)"/>
    Task<AccessIPRange> Delete(
        string accessIPRangeID,
        AccessIPRangeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAccessIPRangeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccessIPRangeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccessIPRangeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /access_ip_ranges</c>, but is otherwise the
/// same as <see cref="IAccessIPRangeService.Create(AccessIPRangeCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPRange>> Create(
        AccessIPRangeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /access_ip_ranges</c>, but is otherwise the
/// same as <see cref="IAccessIPRangeService.List(AccessIPRangeListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPRangeListPage>> List(
        AccessIPRangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /access_ip_ranges/{access_ip_range_id}</c>, but is otherwise the
/// same as <see cref="IAccessIPRangeService.Delete(AccessIPRangeDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPRange>> Delete(
        AccessIPRangeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AccessIPRangeDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AccessIPRange>> Delete(
        string accessIPRangeID,
        AccessIPRangeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}