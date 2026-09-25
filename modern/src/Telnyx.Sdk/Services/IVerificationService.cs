using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Verifications;
using Verifications = Telnyx.Sdk.Services.Verifications;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Two factor authentication API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Verifications::IByPhoneNumberService ByPhoneNumber { get; }

    Verifications::IActionService Actions { get; }

    /// <summary>
/// Returns the verification identified by ID, including its channel, phone number,
/// Verify profile, timeout, and current status.
/// </summary>
    Task<VerificationRetrieveResponse> Retrieve(
        VerificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerificationRetrieveParams, CancellationToken)"/>
    Task<VerificationRetrieveResponse> Retrieve(
        string verificationID,
        VerificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts a verification for the specified phone number and delivers its code in a
/// voice call using the selected Verify profile. Returns the pending verification
/// record.
/// </summary>
    Task<CreateVerificationResponse> TriggerCall(
        VerificationTriggerCallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts a verification for the specified phone number and places a brief call
/// with the code embedded in the caller ID. Returns the pending verification
/// record.
/// </summary>
    Task<CreateVerificationResponse> TriggerFlashcall(
        VerificationTriggerFlashcallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts a verification for the specified phone number and sends its code by SMS
/// using the selected Verify profile. Returns the pending verification record.
/// </summary>
    Task<CreateVerificationResponse> TriggerSms(
        VerificationTriggerSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts a verification for the specified phone number and sends its code over
/// WhatsApp using the selected Verify profile. Returns the pending verification
/// record.
/// </summary>
    Task<CreateVerificationResponse> TriggerWhatsappVerification(
        VerificationTriggerWhatsappVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVerificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Verifications::IByPhoneNumberServiceWithRawResponse ByPhoneNumber { get; }

    Verifications::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /verifications/{verification_id}</c>, but is otherwise the
/// same as <see cref="IVerificationService.Retrieve(VerificationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerificationRetrieveResponse>> Retrieve(
        VerificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerificationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VerificationRetrieveResponse>> Retrieve(
        string verificationID,
        VerificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verifications/call</c>, but is otherwise the
/// same as <see cref="IVerificationService.TriggerCall(VerificationTriggerCallParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreateVerificationResponse>> TriggerCall(
        VerificationTriggerCallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verifications/flashcall</c>, but is otherwise the
/// same as <see cref="IVerificationService.TriggerFlashcall(VerificationTriggerFlashcallParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreateVerificationResponse>> TriggerFlashcall(
        VerificationTriggerFlashcallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verifications/sms</c>, but is otherwise the
/// same as <see cref="IVerificationService.TriggerSms(VerificationTriggerSmsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreateVerificationResponse>> TriggerSms(
        VerificationTriggerSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verifications/whatsapp</c>, but is otherwise the
/// same as <see cref="IVerificationService.TriggerWhatsappVerification(VerificationTriggerWhatsappVerificationParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreateVerificationResponse>> TriggerWhatsappVerification(
        VerificationTriggerWhatsappVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}