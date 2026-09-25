using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignGetSharingStatusResponse, CampaignGetSharingStatusResponseFromRaw>))]
public sealed record class CampaignGetSharingStatusResponse : JsonModel
{
    public CampaignSharingStatus? SharedByMe {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignSharingStatus>(
                "sharedByMe"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sharedByMe", value);
        }
    }

    public CampaignSharingStatus? SharedWithMe {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CampaignSharingStatus>(
                "sharedWithMe"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sharedWithMe", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SharedByMe?.Validate();
        this.SharedWithMe?.Validate();
    }

    public CampaignGetSharingStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignGetSharingStatusResponse (
        CampaignGetSharingStatusResponse campaignGetSharingStatusResponse
    ) : base(campaignGetSharingStatusResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignGetSharingStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignGetSharingStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignGetSharingStatusResponseFromRaw.FromRawUnchecked"/>
    public static CampaignGetSharingStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignGetSharingStatusResponseFromRaw : IFromRawJson<CampaignGetSharingStatusResponse>
{
    /// <inheritdoc/>
    public CampaignGetSharingStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignGetSharingStatusResponse.FromRawUnchecked(rawData);
}