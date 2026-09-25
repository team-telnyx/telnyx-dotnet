using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignSubmitAppealResponse, CampaignSubmitAppealResponseFromRaw>))]
public sealed record class CampaignSubmitAppealResponse : JsonModel
{
    /// <summary>
    /// Timestamp when the appeal was submitted
    /// </summary>
    public DateTimeOffset? AppealedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "appealed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("appealed_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.AppealedAt; }

    public CampaignSubmitAppealResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignSubmitAppealResponse (
        CampaignSubmitAppealResponse campaignSubmitAppealResponse
    ) : base(campaignSubmitAppealResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignSubmitAppealResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignSubmitAppealResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignSubmitAppealResponseFromRaw.FromRawUnchecked"/>
    public static CampaignSubmitAppealResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignSubmitAppealResponseFromRaw : IFromRawJson<CampaignSubmitAppealResponse>
{
    /// <inheritdoc/>
    public CampaignSubmitAppealResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignSubmitAppealResponse.FromRawUnchecked(rawData);
}