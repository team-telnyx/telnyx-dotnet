using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ShortCodes;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Short codes
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IShortCodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IShortCodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShortCodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the messaging configuration and assignment details for the specified
/// short code.
/// </summary>
    Task<ShortCodeRetrieveResponse> Retrieve(
        ShortCodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ShortCodeRetrieveParams, CancellationToken)"/>
    Task<ShortCodeRetrieveResponse> Retrieve(
        string id,
        ShortCodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the settings for a specific short code. To unbind a short code from a
/// profile, set the `messaging_profile_id` to `null` or an empty string. To add or
/// update tags, include the tags field as an array of strings.
/// </summary>
    Task<ShortCodeUpdateResponse> Update(
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ShortCodeUpdateParams, CancellationToken)"/>
    Task<ShortCodeUpdateResponse> Update(
        string id,
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns short codes owned by the authenticated account. Apply the documented
/// filters and pagination parameters to narrow the result set.
/// </summary>
    Task<ShortCodeListPage> List(
        ShortCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IShortCodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IShortCodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShortCodeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /short_codes/{id}</c>, but is otherwise the
/// same as <see cref="IShortCodeService.Retrieve(ShortCodeRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ShortCodeRetrieveResponse>> Retrieve(
        ShortCodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ShortCodeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ShortCodeRetrieveResponse>> Retrieve(
        string id,
        ShortCodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /short_codes/{id}</c>, but is otherwise the
/// same as <see cref="IShortCodeService.Update(ShortCodeUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ShortCodeUpdateResponse>> Update(
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ShortCodeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ShortCodeUpdateResponse>> Update(
        string id,
        ShortCodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /short_codes</c>, but is otherwise the
/// same as <see cref="IShortCodeService.List(ShortCodeListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ShortCodeListPage>> List(
        ShortCodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}