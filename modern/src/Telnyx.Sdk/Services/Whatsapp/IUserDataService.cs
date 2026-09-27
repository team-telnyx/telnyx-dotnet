using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.UserData;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <summary>
/// Manage Whatsapp business accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserDataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserDataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserDataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the WhatsApp user-data settings associated with the authenticated Telnyx
/// account.
/// </summary>
    Task<UserDataRetrieveResponse> Retrieve(
        UserDataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied WhatsApp user-data settings for the authenticated Telnyx
/// account.
/// </summary>
    Task<UserDataUpdateResponse> Update(
        UserDataUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUserDataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserDataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserDataServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/user_data</c>, but is otherwise the
/// same as <see cref="IUserDataService.Retrieve(UserDataRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserDataRetrieveResponse>> Retrieve(
        UserDataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp/user_data</c>, but is otherwise the
/// same as <see cref="IUserDataService.Update(UserDataUpdateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserDataUpdateResponse>> Update(
        UserDataUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}