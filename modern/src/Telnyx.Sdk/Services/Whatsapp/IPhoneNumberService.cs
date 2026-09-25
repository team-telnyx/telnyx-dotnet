using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;
using Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <summary>
/// Manage Whatsapp phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    ICallingSettingService CallingSettings { get; }

    IProfileService Profile { get; }

    IConversationalComponentService ConversationalComponents { get; }

    /// <summary>
/// Returns WhatsApp phone numbers linked to the authenticated Telnyx account.
/// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified phone number from Telnyx WhatsApp management.
/// </summary>
    Task Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberDeleteParams, CancellationToken)"/>
    Task Delete(
        string phoneNumber,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of the phone numbers registered for WhatsApp on your account.
/// </summary>
    Task<PhoneNumberGetResponse> Get(
        PhoneNumberGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Requests a new verification code for the specified WhatsApp phone number.
/// </summary>
    Task ResendVerification(
        PhoneNumberResendVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResendVerification(PhoneNumberResendVerificationParams, CancellationToken)"/>
    Task ResendVerification(
        string phoneNumber,
        PhoneNumberResendVerificationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns whether the 24-hour conversation window is currently open for a given
/// source/destination pair. If window_active is false, only template messages may
/// be sent.
/// </summary>
    Task<PhoneNumberRetrieveConversationWindowResponse> RetrieveConversationWindow(
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConversationWindow(PhoneNumberRetrieveConversationWindowParams, CancellationToken)"/>
    Task<PhoneNumberRetrieveConversationWindowResponse> RetrieveConversationWindow(
        string phoneNumber,
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns one WhatsApp phone number linked to the authenticated Telnyx account.
/// For a coexistence number in the `syncing` state, the response includes
/// `sync_progress`.
/// </summary>
    Task<PhoneNumberRetrievePhoneNumberResponse> RetrievePhoneNumber(
        PhoneNumberRetrievePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrievePhoneNumber(PhoneNumberRetrievePhoneNumberParams, CancellationToken)"/>
    Task<PhoneNumberRetrievePhoneNumberResponse> RetrievePhoneNumber(
        string phoneNumber,
        PhoneNumberRetrievePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submits the verification code received for the specified WhatsApp phone number.
/// </summary>
    Task Verify(
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(PhoneNumberVerifyParams, CancellationToken)"/>
    Task Verify(
        string phoneNumber,
        PhoneNumberVerifyParams parameters,
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

    ICallingSettingServiceWithRawResponse CallingSettings { get; }

    IProfileServiceWithRawResponse Profile { get; }

    IConversationalComponentServiceWithRawResponse ConversationalComponents {
        get;
    }

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /v2/whatsapp/phone_numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Delete(PhoneNumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string phoneNumber,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /whatsapp/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Get(PhoneNumberGetParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberGetResponse>> Get(
        PhoneNumberGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/whatsapp/phone_numbers/{phone_number}/resend_verification</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.ResendVerification(PhoneNumberResendVerificationParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> ResendVerification(
        PhoneNumberResendVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ResendVerification(PhoneNumberResendVerificationParams, CancellationToken)"/>
    Task<HttpResponse> ResendVerification(
        string phoneNumber,
        PhoneNumberResendVerificationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers/{phone_number}/conversation_window</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.RetrieveConversationWindow(PhoneNumberRetrieveConversationWindowParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberRetrieveConversationWindowResponse>> RetrieveConversationWindow(
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConversationWindow(PhoneNumberRetrieveConversationWindowParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRetrieveConversationWindowResponse>> RetrieveConversationWindow(
        string phoneNumber,
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /whatsapp/phone_numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.RetrievePhoneNumber(PhoneNumberRetrievePhoneNumberParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberRetrievePhoneNumberResponse>> RetrievePhoneNumber(
        PhoneNumberRetrievePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrievePhoneNumber(PhoneNumberRetrievePhoneNumberParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRetrievePhoneNumberResponse>> RetrievePhoneNumber(
        string phoneNumber,
        PhoneNumberRetrievePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/whatsapp/phone_numbers/{phone_number}/verify</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Verify(PhoneNumberVerifyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Verify(
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(PhoneNumberVerifyParams, CancellationToken)"/>
    Task<HttpResponse> Verify(
        string phoneNumber,
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}