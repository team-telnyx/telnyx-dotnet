using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.BusinessAccounts;
using BusinessAccounts = Telnyx.Sdk.Services.Whatsapp.BusinessAccounts;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <summary>
/// Manage Whatsapp business accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBusinessAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBusinessAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBusinessAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    BusinessAccounts::IPhoneNumberService PhoneNumbers { get; }

    BusinessAccounts::ISettingService Settings { get; }

    /// <summary>
/// Returns the configuration and status of the specified WhatsApp Business Account.
/// </summary>
    Task<BusinessAccountRetrieveResponse> Retrieve(
        BusinessAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BusinessAccountRetrieveParams, CancellationToken)"/>
    Task<BusinessAccountRetrieveResponse> Retrieve(
        string id,
        BusinessAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns WhatsApp Business Accounts linked to the authenticated Telnyx account.
/// </summary>
    Task<BusinessAccountListPage> List(
        BusinessAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Unlinks and deletes the specified WhatsApp Business Account resource from
/// Telnyx.
/// </summary>
    Task Delete(
        BusinessAccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BusinessAccountDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        BusinessAccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBusinessAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBusinessAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBusinessAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    BusinessAccounts::IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    BusinessAccounts::ISettingServiceWithRawResponse Settings { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/business_accounts/{id}</c>, but is otherwise the
/// same as <see cref="IBusinessAccountService.Retrieve(BusinessAccountRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BusinessAccountRetrieveResponse>> Retrieve(
        BusinessAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BusinessAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BusinessAccountRetrieveResponse>> Retrieve(
        string id,
        BusinessAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/business_accounts</c>, but is otherwise the
/// same as <see cref="IBusinessAccountService.List(BusinessAccountListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BusinessAccountListPage>> List(
        BusinessAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /v2/whatsapp/business_accounts/{id}</c>, but is otherwise the
/// same as <see cref="IBusinessAccountService.Delete(BusinessAccountDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        BusinessAccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BusinessAccountDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        BusinessAccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}