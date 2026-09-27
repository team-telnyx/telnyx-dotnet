using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Brand;
using Telnyx.Sdk.Services.Messaging10dlc.Brand;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// Brand operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IExternalVettingService ExternalVetting { get; }

    /// <summary>
/// This endpoint is used to create a new brand. A brand is an entity created by The
/// Campaign Registry (TCR) that represents an organization or a company. It is this
/// entity that TCR created campaigns will be associated with. Each brand creation
/// will entail an upfront, non-refundable $4 expense.
/// </summary>
    Task<TelnyxBrand> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a 10DLC brand by its brandId, including the count of
/// campaigns associated with the brand.
/// </summary>
    Task<BrandRetrieveResponse> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<BrandRetrieveResponse> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update a brand's attributes by `brandId`.
/// </summary>
    Task<TelnyxBrand> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<TelnyxBrand> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This endpoint is used to list all brands associated with your organization.
/// </summary>
    Task<BrandListPage> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete Brand. This endpoint is used to delete a brand. Note the brand cannot be
/// deleted if it contains one or more active campaigns, the campaigns need to be
/// inactive and at least 3 months old due to billing purposes.
/// </summary>
    Task Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get feedback about a brand by ID. This endpoint can be used after creating or
/// revetting a brand.
/// 
/// <para>Possible values for `.category[].id`:</para>
/// 
/// <para>* `TAX_ID` - Data mismatch related to tax id and its associated
/// properties. * `STOCK_SYMBOL` - Non public entity registered as a public for
/// profit entity or   the stock information mismatch. * `GOVERNMENT_ENTITY` - Non
/// government entity registered as a government entity.   Must be a U.S. government
/// entity. * `NONPROFIT` - Not a recognized non-profit entity. No IRS tax-exempt
/// status   found. * `OTHERS` - Details of the data misrepresentation if any.</para>
/// </summary>
    Task<BrandGetFeedbackResponse> GetFeedback(
        BrandGetFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetFeedback(BrandGetFeedbackParams, CancellationToken)"/>
    Task<BrandGetFeedbackResponse> GetFeedback(
        string brandID,
        BrandGetFeedbackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Query the status of an SMS OTP (One-Time Password) for Sole Proprietor brand
/// verification.
/// 
/// <para>This endpoint allows you to check the delivery and verification status of
/// an OTP sent during the Sole Proprietor brand verification process. You can query
/// by either:</para>
/// 
/// <para>* `referenceId` - The reference ID returned when the OTP was initially
/// triggered * `brandId` - Query parameter for portal users to look up OTP status
/// by Brand ID</para>
/// 
/// <para>The response includes delivery status, verification dates, and detailed
/// delivery information.</para>
/// </summary>
    Task<BrandSmsOtpStatus> GetSmsOtpByReference(
        BrandGetSmsOtpByReferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetSmsOtpByReference(BrandGetSmsOtpByReferenceParams, CancellationToken)"/>
    Task<BrandSmsOtpStatus> GetSmsOtpByReference(
        string referenceID,
        BrandGetSmsOtpByReferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Requests a new two-factor authentication email for the specified 10DLC brand.
/// Complete verification through the link delivered to the brand contact before
/// continuing registration.
/// </summary>
    Task Resend2faEmail(
        BrandResend2faEmailParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Resend2faEmail(BrandResend2faEmailParams, CancellationToken)"/>
    Task Resend2faEmail(
        string brandID,
        BrandResend2faEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Query the status of an SMS OTP (One-Time Password) for Sole Proprietor brand
/// verification using the Brand ID.
/// 
/// <para>This endpoint allows you to check the delivery and verification status of
/// an OTP sent during the Sole Proprietor brand verification process by looking it
/// up with the brand ID.</para>
/// 
/// <para>The response includes delivery status, verification dates, and detailed
/// delivery information.</para>
/// 
/// <para>**Note:** This is an alternative to the
/// `/10dlc/brand/smsOtp/{referenceId}` endpoint when you have the Brand ID but not
/// the reference ID.</para>
/// </summary>
    Task<BrandSmsOtpStatus> RetrieveSmsOtpStatus(
        BrandRetrieveSmsOtpStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSmsOtpStatus(BrandRetrieveSmsOtpStatusParams, CancellationToken)"/>
    Task<BrandSmsOtpStatus> RetrieveSmsOtpStatus(
        string brandID,
        BrandRetrieveSmsOtpStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This operation allows you to revet the brand. However, revetting is allowed once
/// after the successful brand registration and thereafter limited to once every 3
/// months.
/// </summary>
    Task<TelnyxBrand> Revet(
        BrandRevetParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Revet(BrandRevetParams, CancellationToken)"/>
    Task<TelnyxBrand> Revet(
        string brandID,
        BrandRevetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Trigger or re-trigger an SMS OTP (One-Time Password) for Sole Proprietor brand
/// verification.
/// 
/// <para>**Important Notes:**</para>
/// 
/// <para>* Only allowed for Sole Proprietor (`SOLE_PROPRIETOR`) brands * Triggers
/// generation of a one-time password sent to the `mobilePhone` number in the
/// brand's profile * Campaigns cannot be created until OTP verification is complete
/// * US/CA numbers only for real OTPs; mock brands can use non-US/CA numbers for
/// testing * Returns a `referenceId` that can be used to check OTP status via the
/// GET `/10dlc/brand/smsOtp/{referenceId}` endpoint</para>
/// 
/// <para>**Use Cases:**</para>
/// 
/// <para>* Initial OTP trigger after Sole Proprietor brand creation * Re-triggering
/// OTP if the user didn't receive or needs a new code</para>
/// </summary>
    Task<BrandTriggerSmsOtpResponse> TriggerSmsOtp(
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="TriggerSmsOtp(BrandTriggerSmsOtpParams, CancellationToken)"/>
    Task<BrandTriggerSmsOtpResponse> TriggerSmsOtp(
        string brandID,
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Verify the SMS OTP (One-Time Password) for Sole Proprietor brand verification.
/// 
/// <para>**Verification Flow:**</para>
/// 
/// <para>1. User receives OTP via SMS after triggering 2. User submits the OTP pin
/// through this endpoint 3. Upon successful verification:    - A `BRAND_OTP_VERIFIED`
/// webhook event is sent to the CSP    - The brand's `identityStatus` changes to
/// `VERIFIED`    - Campaigns can now be created for this brand</para>
/// 
/// <para>**Error Handling:**</para>
/// 
/// <para>Provides proper error responses for: * Invalid OTP pins * Expired OTPs *
/// OTP verification failures</para>
/// </summary>
    Task VerifySmsOtp(
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="VerifySmsOtp(BrandVerifySmsOtpParams, CancellationToken)"/>
    Task VerifySmsOtp(
        string brandID,
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBrandService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IExternalVettingServiceWithRawResponse ExternalVetting { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/brand</c>, but is otherwise the
/// same as <see cref="IBrandService.Create(BrandCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxBrand>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand/{brandId}</c>, but is otherwise the
/// same as <see cref="IBrandService.Retrieve(BrandRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/brand/{brandId}</c>, but is otherwise the
/// same as <see cref="IBrandService.Update(BrandUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxBrand>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxBrand>> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand</c>, but is otherwise the
/// same as <see cref="IBrandService.List(BrandListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandListPage>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /10dlc/brand/{brandId}</c>, but is otherwise the
/// same as <see cref="IBrandService.Delete(BrandDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand/feedback/{brandId}</c>, but is otherwise the
/// same as <see cref="IBrandService.GetFeedback(BrandGetFeedbackParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandGetFeedbackResponse>> GetFeedback(
        BrandGetFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetFeedback(BrandGetFeedbackParams, CancellationToken)"/>
    Task<HttpResponse<BrandGetFeedbackResponse>> GetFeedback(
        string brandID,
        BrandGetFeedbackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand/smsOtp/{referenceId}</c>, but is otherwise the
/// same as <see cref="IBrandService.GetSmsOtpByReference(BrandGetSmsOtpByReferenceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandSmsOtpStatus>> GetSmsOtpByReference(
        BrandGetSmsOtpByReferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetSmsOtpByReference(BrandGetSmsOtpByReferenceParams, CancellationToken)"/>
    Task<HttpResponse<BrandSmsOtpStatus>> GetSmsOtpByReference(
        string referenceID,
        BrandGetSmsOtpByReferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/brand/{brandId}/2faEmail</c>, but is otherwise the
/// same as <see cref="IBrandService.Resend2faEmail(BrandResend2faEmailParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Resend2faEmail(
        BrandResend2faEmailParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Resend2faEmail(BrandResend2faEmailParams, CancellationToken)"/>
    Task<HttpResponse> Resend2faEmail(
        string brandID,
        BrandResend2faEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/brand/{brandId}/smsOtp</c>, but is otherwise the
/// same as <see cref="IBrandService.RetrieveSmsOtpStatus(BrandRetrieveSmsOtpStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandSmsOtpStatus>> RetrieveSmsOtpStatus(
        BrandRetrieveSmsOtpStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSmsOtpStatus(BrandRetrieveSmsOtpStatusParams, CancellationToken)"/>
    Task<HttpResponse<BrandSmsOtpStatus>> RetrieveSmsOtpStatus(
        string brandID,
        BrandRetrieveSmsOtpStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/brand/{brandId}/revet</c>, but is otherwise the
/// same as <see cref="IBrandService.Revet(BrandRevetParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxBrand>> Revet(
        BrandRevetParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Revet(BrandRevetParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxBrand>> Revet(
        string brandID,
        BrandRevetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/brand/{brandId}/smsOtp</c>, but is otherwise the
/// same as <see cref="IBrandService.TriggerSmsOtp(BrandTriggerSmsOtpParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandTriggerSmsOtpResponse>> TriggerSmsOtp(
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="TriggerSmsOtp(BrandTriggerSmsOtpParams, CancellationToken)"/>
    Task<HttpResponse<BrandTriggerSmsOtpResponse>> TriggerSmsOtp(
        string brandID,
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/brand/{brandId}/smsOtp</c>, but is otherwise the
/// same as <see cref="IBrandService.VerifySmsOtp(BrandVerifySmsOtpParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> VerifySmsOtp(
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="VerifySmsOtp(BrandVerifySmsOtpParams, CancellationToken)"/>
    Task<HttpResponse> VerifySmsOtp(
        string brandID,
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}