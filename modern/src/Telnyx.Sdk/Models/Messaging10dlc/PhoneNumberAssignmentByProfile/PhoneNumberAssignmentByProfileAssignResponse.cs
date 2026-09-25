using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberAssignmentByProfileAssignResponse, PhoneNumberAssignmentByProfileAssignResponseFromRaw>))]
public sealed record class PhoneNumberAssignmentByProfileAssignResponse : JsonModel
{
    /// <summary>
    /// The ID of the messaging profile that you want to link to the specified campaign.
    /// </summary>
    public required string MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "messagingProfileId"
            );
        }
        init { this._rawData.Set("messagingProfileId", value); }
    }

    /// <summary>
    /// The ID of the task associated with assigning a messaging profile to a campaign.
    /// </summary>
    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "taskId"
            );
        }
        init { this._rawData.Set("taskId", value); }
    }

    /// <summary>
    /// The ID of the campaign you want to link to the specified messaging profile.
    /// If you supply this ID in the request, do not also include a tcrCampaignId.
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
    /// The TCR ID of the shared campaign you want to link to the specified messaging
    /// profile (for campaigns not created using Telnyx 10DLC services only). If
    /// you supply this ID in the request, do not also include a campaignId.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessagingProfileID;
        _ = this.TaskID;
        _ = this.CampaignID;
        _ = this.TcrCampaignID;
    }

    public PhoneNumberAssignmentByProfileAssignResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileAssignResponse (
        PhoneNumberAssignmentByProfileAssignResponse phoneNumberAssignmentByProfileAssignResponse
    ) : base(phoneNumberAssignmentByProfileAssignResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileAssignResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignmentByProfileAssignResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAssignmentByProfileAssignResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberAssignmentByProfileAssignResponseFromRaw : IFromRawJson<PhoneNumberAssignmentByProfileAssignResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAssignmentByProfileAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberAssignmentByProfileAssignResponse.FromRawUnchecked(rawData);
}