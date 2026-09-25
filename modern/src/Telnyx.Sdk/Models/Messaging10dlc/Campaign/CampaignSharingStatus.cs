using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignSharingStatus, CampaignSharingStatusFromRaw>))]
public sealed record class CampaignSharingStatus : JsonModel
{
    public string? DownstreamCnpID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "downstreamCnpId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("downstreamCnpId", value);
        }
    }

    public string? SharedDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sharedDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sharedDate", value);
        }
    }

    public string? SharingStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sharingStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sharingStatus", value);
        }
    }

    public string? StatusDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "statusDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("statusDate", value);
        }
    }

    public string? UpstreamCnpID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "upstreamCnpId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("upstreamCnpId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownstreamCnpID;
        _ = this.SharedDate;
        _ = this.SharingStatus;
        _ = this.StatusDate;
        _ = this.UpstreamCnpID;
    }

    public CampaignSharingStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignSharingStatus (
        CampaignSharingStatus campaignSharingStatus
    ) : base(campaignSharingStatus)
    {  }
    #pragma warning restore CS8618

    public CampaignSharingStatus (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignSharingStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignSharingStatusFromRaw.FromRawUnchecked"/>
    public static CampaignSharingStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignSharingStatusFromRaw : IFromRawJson<CampaignSharingStatus>
{
    /// <inheritdoc/>
    public CampaignSharingStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignSharingStatus.FromRawUnchecked(rawData);
}