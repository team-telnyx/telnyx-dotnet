using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.PhoneNumbers;

namespace Telnyx.Sdk.Services.Whatsapp.BusinessAccounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns phone numbers registered under the specified WhatsApp Business Account.
/// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<PhoneNumberListPage> List(
        string id,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts verification of a phone number for the specified WhatsApp Business
/// Account using the requested verification method.
/// </summary>
    Task InitializeVerification(
        PhoneNumberInitializeVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InitializeVerification(PhoneNumberInitializeVerificationParams, CancellationToken)"/>
    Task InitializeVerification(
        string id,
        PhoneNumberInitializeVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/business_accounts/{id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberListPage>> List(
        string id,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/whatsapp/business_accounts/{id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.InitializeVerification(PhoneNumberInitializeVerificationParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> InitializeVerification(
        PhoneNumberInitializeVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InitializeVerification(PhoneNumberInitializeVerificationParams, CancellationToken)"/>
    Task<HttpResponse> InitializeVerification(
        string id,
        PhoneNumberInitializeVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}