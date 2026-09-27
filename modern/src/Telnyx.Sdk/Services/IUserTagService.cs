using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UserTags;

namespace Telnyx.Sdk.Services;

/// <summary>
/// User-defined tags for Telnyx resources
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserTagService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserTagServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserTagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the user tags defined on your account, with support for filtering. Tags
/// help organize resources such as phone numbers.
/// </summary>
    Task<UserTagListResponse> List(
        UserTagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUserTagService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserTagServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserTagServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /user_tags</c>, but is otherwise the
/// same as <see cref="IUserTagService.List(UserTagListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserTagListResponse>> List(
        UserTagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}