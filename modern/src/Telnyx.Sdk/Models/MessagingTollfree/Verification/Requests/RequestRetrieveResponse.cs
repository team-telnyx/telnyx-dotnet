using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// A verification request and its status, suitable for returning to users
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequestRetrieveResponse, RequestRetrieveResponseFromRaw>))]
public sealed record class RequestRetrieveResponse : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AdditionalInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "additionalInformation"
            );
        }
        init { this._rawData.Set("additionalInformation", value); }
    }

    public required string BusinessAddr1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessAddr1"
            );
        }
        init { this._rawData.Set("businessAddr1", value); }
    }

    public required string BusinessCity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessCity"
            );
        }
        init { this._rawData.Set("businessCity", value); }
    }

    public required string BusinessContactEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactEmail"
            );
        }
        init { this._rawData.Set("businessContactEmail", value); }
    }

    public required string BusinessContactFirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactFirstName"
            );
        }
        init { this._rawData.Set("businessContactFirstName", value); }
    }

    public required string BusinessContactLastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactLastName"
            );
        }
        init { this._rawData.Set("businessContactLastName", value); }
    }

    public required string BusinessContactPhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessContactPhone"
            );
        }
        init { this._rawData.Set("businessContactPhone", value); }
    }

    public required string BusinessName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessName"
            );
        }
        init { this._rawData.Set("businessName", value); }
    }

    public required string BusinessState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessState"
            );
        }
        init { this._rawData.Set("businessState", value); }
    }

    public required string BusinessZip {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "businessZip"
            );
        }
        init { this._rawData.Set("businessZip", value); }
    }

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

    public required string OptInWorkflow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "optInWorkflow"
            );
        }
        init { this._rawData.Set("optInWorkflow", value); }
    }

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
    /// Tollfree verification status
    /// </summary>
    public required ApiEnum<string, TfVerificationStatus> VerificationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TfVerificationStatus>>(
                "verificationStatus"
            );
        }
        init { this._rawData.Set("verificationStatus", value); }
    }

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

    public string? BusinessRegistrationCountry {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationCountry"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("businessRegistrationCountry", value);
        }
    }

    public string? BusinessRegistrationNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationNumber"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("businessRegistrationNumber", value);
        }
    }

    public string? BusinessRegistrationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessRegistrationType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("businessRegistrationType", value);
        }
    }

    /// <summary>
    /// Campaign Verify Authorization Token required for Political use case submissions
    /// starting February 17, 2026
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

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "createdAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? DoingBusinessAs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "doingBusinessAs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("doingBusinessAs", value);
        }
    }

    /// <summary>
    /// Business entity classification
    /// </summary>
    public ApiEnum<string, MessagingTollFreeVerificationEntityType>? EntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingTollFreeVerificationEntityType>>(
                "entityType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("entityType", value);
        }
    }

    public string? HelpMessageResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "helpMessageResponse"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("helpMessageResponse", value);
        }
    }

    public string? IsvReseller {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "isvReseller"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isvReseller", value);
        }
    }

    public string? OptInConfirmationResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optInConfirmationResponse"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optInConfirmationResponse", value);
        }
    }

    public string? OptInKeywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optInKeywords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optInKeywords", value);
        }
    }

    public string? PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacyPolicyURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacyPolicyURL", value);
        }
    }

    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    public string? TermsAndConditionUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "termsAndConditionURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("termsAndConditionURL", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updatedAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

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
        _ = this.ID;
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
        this.VerificationStatus.Validate();
        _ = this.AgeGatedContent;
        _ = this.BusinessAddr2;
        _ = this.BusinessRegistrationCountry;
        _ = this.BusinessRegistrationNumber;
        _ = this.BusinessRegistrationType;
        _ = this.CampaignVerifyAuthorizationToken;
        _ = this.CreatedAt;
        _ = this.DoingBusinessAs;
        this.EntityType?.Validate();
        _ = this.HelpMessageResponse;
        _ = this.IsvReseller;
        _ = this.OptInConfirmationResponse;
        _ = this.OptInKeywords;
        _ = this.PrivacyPolicyUrl;
        _ = this.Reason;
        _ = this.TermsAndConditionUrl;
        _ = this.UpdatedAt;
        _ = this.WebhookUrl;
    }

    public RequestRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestRetrieveResponse (
        RequestRetrieveResponse requestRetrieveResponse
    ) : base(requestRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RequestRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequestRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RequestRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequestRetrieveResponseFromRaw : IFromRawJson<RequestRetrieveResponse>
{
    /// <inheritdoc/>
    public RequestRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequestRetrieveResponse.FromRawUnchecked(rawData);
}