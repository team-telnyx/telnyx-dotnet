using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.Settings;

namespace Telnyx.Sdk.Services.Whatsapp.BusinessAccounts;

/// <summary>
/// Manage Whatsapp business accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns account-level settings for the specified WhatsApp Business Account.
/// </summary>
    Task<SettingRetrieveResponse> Retrieve(
        SettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SettingRetrieveParams, CancellationToken)"/>
    Task<SettingRetrieveResponse> Retrieve(
        string id,
        SettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied account-level settings for the specified WhatsApp Business
/// Account.
/// </summary>
    Task<SettingUpdateResponse> Update(
        SettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SettingUpdateParams, CancellationToken)"/>
    Task<SettingUpdateResponse> Update(
        string id,
        SettingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/business_accounts/{id}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.Retrieve(SettingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SettingRetrieveResponse>> Retrieve(
        SettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SettingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SettingRetrieveResponse>> Retrieve(
        string id,
        SettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp/business_accounts/{id}/settings</c>, but is otherwise the
/// same as <see cref="ISettingService.Update(SettingUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SettingUpdateResponse>> Update(
        SettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SettingUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SettingUpdateResponse>> Update(
        string id,
        SettingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}