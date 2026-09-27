using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignDeactivateResponse, CampaignDeactivateResponseFromRaw>))]
public sealed record class CampaignDeactivateResponse : JsonModel
{
    public required double Time {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "time"
            );
        }
        init { this._rawData.Set("time", value); }
    }

    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Time;
        _ = this.Message;
        _ = this.RecordType;
    }

    public CampaignDeactivateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignDeactivateResponse (
        CampaignDeactivateResponse campaignDeactivateResponse
    ) : base(campaignDeactivateResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignDeactivateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignDeactivateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static CampaignDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CampaignDeactivateResponse (double time) : this()
    { this.Time = time; }
}

class CampaignDeactivateResponseFromRaw : IFromRawJson<CampaignDeactivateResponse>
{
    /// <inheritdoc/>
    public CampaignDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignDeactivateResponse.FromRawUnchecked(rawData);
}