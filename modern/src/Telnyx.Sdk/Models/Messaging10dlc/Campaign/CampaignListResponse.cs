using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignListResponse, CampaignListResponseFromRaw>))]
public sealed record class CampaignListResponse : JsonModel
{
    /// <summary>
    /// Age gated content in campaign.
    /// </summary>
    public bool? AgeGated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ageGated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ageGated", value);
        }
    }

    /// <summary>
    /// Number of phone numbers associated with the campaign
    /// </summary>
    public double? AssignedPhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "assignedPhoneNumbersCount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assignedPhoneNumbersCount", value);
        }
    }

    /// <summary>
    /// Campaign subscription auto-renewal status.
    /// </summary>
    public bool? AutoRenewal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "autoRenewal"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("autoRenewal", value);
        }
    }

    /// <summary>
    /// Campaign recent billed date.
    /// </summary>
    public string? BilledDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billedDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billedDate", value);
        }
    }

    /// <summary>
    /// Display or marketing name of the brand.
    /// </summary>
    public string? BrandDisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brandDisplayName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brandDisplayName", value);
        }
    }

    /// <summary>
    /// Unique identifier assigned to the brand.
    /// </summary>
    public string? BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brandId", value);
        }
    }

    /// <summary>
    /// Unique identifier for a campaign.
    /// </summary>
    public string? CampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "campaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("campaignId", value);
        }
    }

    /// <summary>
    /// Campaign status
    /// </summary>
    public ApiEnum<string, CampaignListResponseCampaignStatus>? CampaignStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CampaignListResponseCampaignStatus>>(
                "campaignStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("campaignStatus", value);
        }
    }

    /// <summary>
    /// Unix timestamp when campaign was created.
    /// </summary>
    public string? CreateDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "createDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createDate", value);
        }
    }

    /// <summary>
    /// Alphanumeric identifier of the CSP associated with this campaign.
    /// </summary>
    public string? CspID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cspId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cspId", value);
        }
    }

    /// <summary>
    /// Summary description of this campaign.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public bool? DirectLending {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "directLending"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("directLending", value);
        }
    }

    /// <summary>
    /// Does message generated by the campaign include URL link in SMS?
    /// </summary>
    public bool? EmbeddedLink {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "embeddedLink"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("embeddedLink", value);
        }
    }

    /// <summary>
    /// Sample of an embedded link that will be sent to subscribers.
    /// </summary>
    public string? EmbeddedLinkSample {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "embeddedLinkSample"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("embeddedLinkSample", value);
        }
    }

    /// <summary>
    /// Does message generated by the campaign include phone number in SMS?
    /// </summary>
    public bool? EmbeddedPhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "embeddedPhone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("embeddedPhone", value);
        }
    }

    /// <summary>
    /// Failure reasons if campaign submission failed
    /// </summary>
    public string? FailureReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failureReasons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failureReasons", value);
        }
    }

    /// <summary>
    /// Subscriber help keywords. Multiple keywords are comma separated without space.
    /// </summary>
    public string? HelpKeywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "helpKeywords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("helpKeywords", value);
        }
    }

    /// <summary>
    /// Help message of the campaign.
    /// </summary>
    public string? HelpMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "helpMessage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("helpMessage", value);
        }
    }

    /// <summary>
    /// Indicates whether the campaign has a T-Mobile number pool ID associated with it.
    /// </summary>
    public bool? IsTMobileNumberPoolingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isTMobileNumberPoolingEnabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isTMobileNumberPoolingEnabled", value);
        }
    }

    /// <summary>
    /// Indicates whether the campaign is registered with T-Mobile.
    /// </summary>
    public bool? IsTMobileRegistered {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isTMobileRegistered"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isTMobileRegistered", value);
        }
    }

    /// <summary>
    /// Indicates whether the campaign is suspended with T-Mobile.
    /// </summary>
    public bool? IsTMobileSuspended {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isTMobileSuspended"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isTMobileSuspended", value);
        }
    }

    /// <summary>
    /// Message flow description.
    /// </summary>
    public string? MessageFlow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messageFlow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messageFlow", value);
        }
    }

    /// <summary>
    /// Campaign created from mock brand. Mocked campaign cannot be shared with an
    /// upstream CNP.
    /// </summary>
    public bool? Mock {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mock"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mock", value);
        }
    }

    /// <summary>
    /// When the campaign would be due for its next renew/bill date.
    /// </summary>
    public string? NextRenewalOrExpirationDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "nextRenewalOrExpirationDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("nextRenewalOrExpirationDate", value);
        }
    }

    /// <summary>
    /// Does campaign utilize pool of phone numbers?
    /// </summary>
    public bool? NumberPool {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "numberPool"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("numberPool", value);
        }
    }

    /// <summary>
    /// Subscriber opt-in keywords. Multiple keywords are comma separated without space.
    /// </summary>
    public string? OptinKeywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optinKeywords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optinKeywords", value);
        }
    }

    /// <summary>
    /// Subscriber opt-in message.
    /// </summary>
    public string? OptinMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optinMessage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optinMessage", value);
        }
    }

    /// <summary>
    /// Subscriber opt-out keywords. Multiple keywords are comma separated without space.
    /// </summary>
    public string? OptoutKeywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optoutKeywords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optoutKeywords", value);
        }
    }

    /// <summary>
    /// Subscriber opt-out message.
    /// </summary>
    public string? OptoutMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "optoutMessage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optoutMessage", value);
        }
    }

    /// <summary>
    /// Link to the campaign's privacy policy.
    /// </summary>
    public string? PrivacyPolicyLink {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacyPolicyLink"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacyPolicyLink", value);
        }
    }

    /// <summary>
    /// Caller supplied campaign reference ID. If supplied, the value must be unique
    /// across all submitted campaigns. Can be used to prevent duplicate campaign registrations.
    /// </summary>
    public string? ReferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "referenceId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("referenceId", value);
        }
    }

    /// <summary>
    /// Alphanumeric identifier of the reseller that you want to associate with this campaign.
    /// </summary>
    public string? ResellerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resellerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resellerId", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 1 or more message samples.
    /// </summary>
    public string? Sample1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample1"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample1", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 2 or more message samples.
    /// </summary>
    public string? Sample2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample2", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 3 or more message samples.
    /// </summary>
    public string? Sample3 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample3"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample3", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 4 or more message samples.
    /// </summary>
    public string? Sample4 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample4"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample4", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 5 or more message samples.
    /// </summary>
    public string? Sample5 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sample5"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sample5", value);
        }
    }

    /// <summary>
    /// Current campaign status. Possible values: ACTIVE, EXPIRED. A newly created
    /// campaign defaults to ACTIVE status.
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Campaign submission status
    /// </summary>
    public ApiEnum<string, CampaignListResponseSubmissionStatus>? SubmissionStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CampaignListResponseSubmissionStatus>>(
                "submissionStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("submissionStatus", value);
        }
    }

    /// <summary>
    /// Does campaign responds to help keyword(s)?
    /// </summary>
    public bool? SubscriberHelp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "subscriberHelp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subscriberHelp", value);
        }
    }

    /// <summary>
    /// Does campaign require subscriber to opt-in before SMS is sent to subscriber?
    /// </summary>
    public bool? SubscriberOptin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "subscriberOptin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subscriberOptin", value);
        }
    }

    /// <summary>
    /// Does campaign support subscriber opt-out keyword(s)?
    /// </summary>
    public bool? SubscriberOptout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "subscriberOptout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subscriberOptout", value);
        }
    }

    /// <summary>
    /// Campaign sub-usecases. Must be of defined valid sub-usecase types. Use `/10dlc/enum/usecase`
    /// operation to retrieve list of valid sub-usecases
    /// </summary>
    public IReadOnlyList<string>? SubUsecases {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "subUsecases"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "subUsecases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Unique identifier assigned to the brand by the registry.
    /// </summary>
    public string? TcrBrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcrBrandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcrBrandId", value);
        }
    }

    /// <summary>
    /// Unique identifier assigned to the campaign by the registry.
    /// </summary>
    public string? TcrCampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcrCampaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcrCampaignId", value);
        }
    }

    /// <summary>
    /// Is terms &amp; conditions accepted?
    /// </summary>
    public bool? TermsAndConditions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "termsAndConditions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("termsAndConditions", value);
        }
    }

    /// <summary>
    /// Link to the campaign's terms and conditions.
    /// </summary>
    public string? TermsAndConditionsLink {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "termsAndConditionsLink"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("termsAndConditionsLink", value);
        }
    }

    /// <summary>
    /// Campaign usecase. Must be of defined valid types. Use `/10dlc/enum/usecase`
    /// operation to retrieve usecases available for given brand.
    /// </summary>
    public string? Usecase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "usecase"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("usecase", value);
        }
    }

    /// <summary>
    /// Business/industry segment of this campaign (Deprecated). Must be of defined
    /// valid types. Use `/registry/enum/vertical` operation to retrieve verticals
    /// available for given brand, vertical combination.
    ///
    /// <para>This field is deprecated.</para>
    /// </summary>
    [System::Obsolete("This field is deprecated and will be removed soon")]
    public string? Vertical {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vertical"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vertical", value);
        }
    }

    /// <summary>
    /// Failover webhook to which campaign status updates are sent.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhookFailoverURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhookFailoverURL", value);
        }
    }

    /// <summary>
    /// Webhook to which campaign status updates are sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhookURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhookURL", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgeGated;
        _ = this.AssignedPhoneNumbersCount;
        _ = this.AutoRenewal;
        _ = this.BilledDate;
        _ = this.BrandDisplayName;
        _ = this.BrandID;
        _ = this.CampaignID;
        this.CampaignStatus?.Validate();
        _ = this.CreateDate;
        _ = this.CspID;
        _ = this.Description;
        _ = this.DirectLending;
        _ = this.EmbeddedLink;
        _ = this.EmbeddedLinkSample;
        _ = this.EmbeddedPhone;
        _ = this.FailureReasons;
        _ = this.HelpKeywords;
        _ = this.HelpMessage;
        _ = this.IsTMobileNumberPoolingEnabled;
        _ = this.IsTMobileRegistered;
        _ = this.IsTMobileSuspended;
        _ = this.MessageFlow;
        _ = this.Mock;
        _ = this.NextRenewalOrExpirationDate;
        _ = this.NumberPool;
        _ = this.OptinKeywords;
        _ = this.OptinMessage;
        _ = this.OptoutKeywords;
        _ = this.OptoutMessage;
        _ = this.PrivacyPolicyLink;
        _ = this.ReferenceID;
        _ = this.ResellerID;
        _ = this.Sample1;
        _ = this.Sample2;
        _ = this.Sample3;
        _ = this.Sample4;
        _ = this.Sample5;
        _ = this.Status;
        this.SubmissionStatus?.Validate();
        _ = this.SubscriberHelp;
        _ = this.SubscriberOptin;
        _ = this.SubscriberOptout;
        _ = this.SubUsecases;
        _ = this.TcrBrandID;
        _ = this.TcrCampaignID;
        _ = this.TermsAndConditions;
        _ = this.TermsAndConditionsLink;
        _ = this.Usecase;
        _ = this.Vertical;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public CampaignListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListResponse (
        CampaignListResponse campaignListResponse
    ) : base(campaignListResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListResponseFromRaw.FromRawUnchecked"/>
    public static CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignListResponseFromRaw : IFromRawJson<CampaignListResponse>
{
    /// <inheritdoc/>
    public CampaignListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Campaign status
/// </summary>
[JsonConverter(typeof(CampaignListResponseCampaignStatusConverter))]
public enum CampaignListResponseCampaignStatus
{
    TcrPending,
    TcrSuspended,
    TcrExpired,
    TcrAccepted,
    TcrFailed,
    TelnyxAccepted,
    TelnyxFailed,
    MnoPending,
    MnoAccepted,
    MnoRejected,
    MnoProvisioned,
    MnoProvisioningFailed
}sealed class CampaignListResponseCampaignStatusConverter : JsonConverter<CampaignListResponseCampaignStatus>
{
    public override CampaignListResponseCampaignStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TCR_PENDING"=>CampaignListResponseCampaignStatus.TcrPending,
            "TCR_SUSPENDED"=>CampaignListResponseCampaignStatus.TcrSuspended,
            "TCR_EXPIRED"=>CampaignListResponseCampaignStatus.TcrExpired,
            "TCR_ACCEPTED"=>CampaignListResponseCampaignStatus.TcrAccepted,
            "TCR_FAILED"=>CampaignListResponseCampaignStatus.TcrFailed,
            "TELNYX_ACCEPTED"=>CampaignListResponseCampaignStatus.TelnyxAccepted,
            "TELNYX_FAILED"=>CampaignListResponseCampaignStatus.TelnyxFailed,
            "MNO_PENDING"=>CampaignListResponseCampaignStatus.MnoPending,
            "MNO_ACCEPTED"=>CampaignListResponseCampaignStatus.MnoAccepted,
            "MNO_REJECTED"=>CampaignListResponseCampaignStatus.MnoRejected,
            "MNO_PROVISIONED"=>CampaignListResponseCampaignStatus.MnoProvisioned,
            "MNO_PROVISIONING_FAILED"=>CampaignListResponseCampaignStatus.MnoProvisioningFailed,
            _ =>(CampaignListResponseCampaignStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignListResponseCampaignStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CampaignListResponseCampaignStatus.TcrPending=>"TCR_PENDING",
            CampaignListResponseCampaignStatus.TcrSuspended=>"TCR_SUSPENDED",
            CampaignListResponseCampaignStatus.TcrExpired=>"TCR_EXPIRED",
            CampaignListResponseCampaignStatus.TcrAccepted=>"TCR_ACCEPTED",
            CampaignListResponseCampaignStatus.TcrFailed=>"TCR_FAILED",
            CampaignListResponseCampaignStatus.TelnyxAccepted=>"TELNYX_ACCEPTED",
            CampaignListResponseCampaignStatus.TelnyxFailed=>"TELNYX_FAILED",
            CampaignListResponseCampaignStatus.MnoPending=>"MNO_PENDING",
            CampaignListResponseCampaignStatus.MnoAccepted=>"MNO_ACCEPTED",
            CampaignListResponseCampaignStatus.MnoRejected=>"MNO_REJECTED",
            CampaignListResponseCampaignStatus.MnoProvisioned=>"MNO_PROVISIONED",
            CampaignListResponseCampaignStatus.MnoProvisioningFailed=>"MNO_PROVISIONING_FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Campaign submission status
/// </summary>
[JsonConverter(typeof(CampaignListResponseSubmissionStatusConverter))]
public enum CampaignListResponseSubmissionStatus
{
    Created, Failed, Pending
}sealed class CampaignListResponseSubmissionStatusConverter : JsonConverter<CampaignListResponseSubmissionStatus>
{
    public override CampaignListResponseSubmissionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED"=>CampaignListResponseSubmissionStatus.Created,
            "FAILED"=>CampaignListResponseSubmissionStatus.Failed,
            "PENDING"=>CampaignListResponseSubmissionStatus.Pending,
            _ =>(CampaignListResponseSubmissionStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignListResponseSubmissionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CampaignListResponseSubmissionStatus.Created=>"CREATED",
            CampaignListResponseSubmissionStatus.Failed=>"FAILED",
            CampaignListResponseSubmissionStatus.Pending=>"PENDING",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}