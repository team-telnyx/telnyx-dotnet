using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// The body of a tollfree verification request
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TfVerificationRequest, TfVerificationRequestFromRaw>))]
public sealed record class TfVerificationRequest : JsonModel
{
    /// <summary>
    /// Any additional information
    /// </summary>
    public required string AdditionalInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "additionalInformation"
            );
        }
        init { this._rawData.Set("additionalInformation", value); }
    }

    /// <summary>
    /// Line 1 of the business address
    /// </summary>
    public required string BusinessAddr1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessAddr1"
            );
        }
        init { this._rawData.Set("businessAddr1", value); }
    }

    /// <summary>
    /// The city of the business address; the first letter should be capitalized
    /// </summary>
    public required string BusinessCity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessCity"
            );
        }
        init { this._rawData.Set("businessCity", value); }
    }

    /// <summary>
    /// The email address of the business contact
    /// </summary>
    public required string BusinessContactEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactEmail"
            );
        }
        init { this._rawData.Set("businessContactEmail", value); }
    }

    /// <summary>
    /// First name of the business contact; there are no specific requirements on formatting
    /// </summary>
    public required string BusinessContactFirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactFirstName"
            );
        }
        init { this._rawData.Set("businessContactFirstName", value); }
    }

    /// <summary>
    /// Last name of the business contact; there are no specific requirements on formatting
    /// </summary>
    public required string BusinessContactLastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactLastName"
            );
        }
        init { this._rawData.Set("businessContactLastName", value); }
    }

    /// <summary>
    /// The phone number of the business contact in E.164 format
    /// </summary>
    public required string BusinessContactPhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactPhone"
            );
        }
        init { this._rawData.Set("businessContactPhone", value); }
    }

    /// <summary>
    /// Name of the business; there are no specific formatting requirements
    /// </summary>
    public required string BusinessName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessName"
            );
        }
        init { this._rawData.Set("businessName", value); }
    }

    /// <summary>
    /// The full name of the state (not the 2 letter code) of the business address;
    /// the first letter should be capitalized
    /// </summary>
    public required string BusinessState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessState"
            );
        }
        init { this._rawData.Set("businessState", value); }
    }

    /// <summary>
    /// The ZIP code of the business address
    /// </summary>
    public required string BusinessZip {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessZip"
            );
        }
        init { this._rawData.Set("businessZip", value); }
    }

    /// <summary>
    /// A URL, including the scheme, pointing to the corporate website
    /// </summary>
    public required string CorporateWebsite {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "corporateWebsite"
            );
        }
        init { this._rawData.Set("corporateWebsite", value); }
    }

    /// <summary>
    /// Message Volume Enums
    /// </summary>
    public required ApiEnum<string, Volume> MessageVolume {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Volume>>(
                "messageVolume"
            );
        }
        init { this._rawData.Set("messageVolume", value); }
    }

    /// <summary>
    /// Human-readable description of how end users will opt into receiving messages
    /// from the given phone numbers
    /// </summary>
    public required string OptInWorkflow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "optInWorkflow"
            );
        }
        init { this._rawData.Set("optInWorkflow", value); }
    }

    /// <summary>
    /// Images showing the opt-in workflow
    /// </summary>
    public required IReadOnlyList<Url> OptInWorkflowImageUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Url>>(
                "optInWorkflowImageURLs"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Url>>(
                "optInWorkflowImageURLs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The phone numbers to request the verification of
    /// </summary>
    public required IReadOnlyList<TfPhoneNumber> PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TfPhoneNumber>>(
                "phoneNumbers"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<TfPhoneNumber>>(
                "phoneNumbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An example of a message that will be sent from the given phone numbers
    /// </summary>
    public required string ProductionMessageContent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "productionMessageContent"
            );
        }
        init { this._rawData.Set("productionMessageContent", value); }
    }

    /// <summary>
    /// Tollfree usecase categories
    /// </summary>
    public required ApiEnum<string, UseCaseCategories> UseCase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UseCaseCategories>>(
                "useCase"
            );
        }
        init { this._rawData.Set("useCase", value); }
    }

    /// <summary>
    /// Human-readable summary of the desired use-case
    /// </summary>
    public required string UseCaseSummary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "useCaseSummary"
            );
        }
        init { this._rawData.Set("useCaseSummary", value); }
    }

    /// <summary>
    /// Indicates if messaging content requires age gating (e.g., 18+). Defaults
    /// to false if not provided.
    /// </summary>
    public bool? AgeGatedContent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ageGatedContent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ageGatedContent", value);
        }
    }

    /// <summary>
    /// Line 2 of the business address
    /// </summary>
    public string? BusinessAddr2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessAddr2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("businessAddr2", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the issuing business authority. Must be
    /// exactly 2 letters. Automatically converted to uppercase. Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationCountry {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationCountry"
            );
        }
        init { this._rawData.Set("businessRegistrationCountry", value); }
    }

    /// <summary>
    /// Official business registration number (e.g., Employer Identification Number
    /// (EIN) in the U.S.). Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationNumber"
            );
        }
        init { this._rawData.Set("businessRegistrationNumber", value); }
    }

    /// <summary>
    /// Type of business registration being provided. Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationType"
            );
        }
        init { this._rawData.Set("businessRegistrationType", value); }
    }

    /// <summary>
    /// Campaign Verify Authorization Token required for Political use case submissions
    /// starting February 17, 2026. This token is validated by Zipwhip and must be
    /// provided for all Political use case verifications after the deadline.
    /// </summary>
    public string? CampaignVerifyAuthorizationToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "campaignVerifyAuthorizationToken"
            );
        }
        init { this._rawData.Set("campaignVerifyAuthorizationToken", value); }
    }

    /// <summary>
    /// Doing Business As (DBA) name if different from legal name
    /// </summary>
    public string? DoingBusinessAs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "doingBusinessAs"
            );
        }
        init { this._rawData.Set("doingBusinessAs", value); }
    }

    /// <summary>
    /// Business entity classification
    /// </summary>
    public ApiEnum<string, TollFreeVerificationEntityType>? EntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TollFreeVerificationEntityType>>(
                "entityType"
            );
        }
        init { this._rawData.Set("entityType", value); }
    }

    /// <summary>
    /// The message returned when users text 'HELP'
    /// </summary>
    public string? HelpMessageResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "helpMessageResponse"
            );
        }
        init { this._rawData.Set("helpMessageResponse", value); }
    }

    /// <summary>
    /// ISV name
    /// </summary>
    public string? IsvReseller {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "isvReseller"
            );
        }
        init { this._rawData.Set("isvReseller", value); }
    }

    /// <summary>
    /// Message sent to users confirming their opt-in to receive messages
    /// </summary>
    public string? OptInConfirmationResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optInConfirmationResponse"
            );
        }
        init { this._rawData.Set("optInConfirmationResponse", value); }
    }

    /// <summary>
    /// Keywords used to collect and process consumer opt-ins
    /// </summary>
    public string? OptInKeywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optInKeywords"
            );
        }
        init { this._rawData.Set("optInKeywords", value); }
    }

    /// <summary>
    /// URL pointing to the business's privacy policy. Plain string, no URL format validation.
    /// </summary>
    public string? PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacyPolicyURL"
            );
        }
        init { this._rawData.Set("privacyPolicyURL", value); }
    }

    /// <summary>
    /// URL pointing to the business's terms and conditions. Plain string, no URL
    /// format validation.
    /// </summary>
    public string? TermsAndConditionUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "termsAndConditionURL"
            );
        }
        init { this._rawData.Set("termsAndConditionURL", value); }
    }

    /// <summary>
    /// URL that should receive webhooks relating to this verification request
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhookUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhookUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdditionalInformation;
        _ = this.BusinessAddr1;
        _ = this.BusinessCity;
        _ = this.BusinessContactEmail;
        _ = this.BusinessContactFirstName;
        _ = this.BusinessContactLastName;
        _ = this.BusinessContactPhone;
        _ = this.BusinessName;
        _ = this.BusinessState;
        _ = this.BusinessZip;
        _ = this.CorporateWebsite;
        this.MessageVolume.Validate();
        _ = this.OptInWorkflow;
        foreach (var item in this.OptInWorkflowImageUrls)
        {
            item.Validate();
        }
        foreach (var item in this.PhoneNumbers)
        {
            item.Validate();
        }
        _ = this.ProductionMessageContent;
        this.UseCase.Validate();
        _ = this.UseCaseSummary;
        _ = this.AgeGatedContent;
        _ = this.BusinessAddr2;
        _ = this.BusinessRegistrationCountry;
        _ = this.BusinessRegistrationNumber;
        _ = this.BusinessRegistrationType;
        _ = this.CampaignVerifyAuthorizationToken;
        _ = this.DoingBusinessAs;
        this.EntityType?.Validate();
        _ = this.HelpMessageResponse;
        _ = this.IsvReseller;
        _ = this.OptInConfirmationResponse;
        _ = this.OptInKeywords;
        _ = this.PrivacyPolicyUrl;
        _ = this.TermsAndConditionUrl;
        _ = this.WebhookUrl;
    }

    public TfVerificationRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TfVerificationRequest (
        TfVerificationRequest tfVerificationRequest
    ) : base(tfVerificationRequest)
    {  }
    #pragma warning restore CS8618

    public TfVerificationRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TfVerificationRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TfVerificationRequestFromRaw.FromRawUnchecked"/>
    public static TfVerificationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TfVerificationRequestFromRaw : IFromRawJson<TfVerificationRequest>
{
    /// <inheritdoc/>
    public TfVerificationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TfVerificationRequest.FromRawUnchecked(rawData);
}