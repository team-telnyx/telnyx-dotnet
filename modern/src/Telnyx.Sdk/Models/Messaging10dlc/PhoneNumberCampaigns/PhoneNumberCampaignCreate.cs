using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberCampaigns;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberCampaignCreate, PhoneNumberCampaignCreateFromRaw>))]
public sealed record class PhoneNumberCampaignCreate : JsonModel
{
    /// <summary>
    /// The ID of the campaign you want to link to the specified phone number.
    /// </summary>
    public required string CampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "campaignId"
            );
        }
        init { this._rawData.Set("campaignId", value); }
    }

    /// <summary>
    /// The phone number you want to link to a specified campaign.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phoneNumber"
            );
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CampaignID;
        _ = this.PhoneNumber;
    }

    public PhoneNumberCampaignCreate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberCampaignCreate (
        PhoneNumberCampaignCreate phoneNumberCampaignCreate
    ) : base(phoneNumberCampaignCreate)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberCampaignCreate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberCampaignCreate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberCampaignCreateFromRaw.FromRawUnchecked"/>
    public static PhoneNumberCampaignCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberCampaignCreateFromRaw : IFromRawJson<PhoneNumberCampaignCreate>
{
    /// <inheritdoc/>
    public PhoneNumberCampaignCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberCampaignCreate.FromRawUnchecked(rawData);
}