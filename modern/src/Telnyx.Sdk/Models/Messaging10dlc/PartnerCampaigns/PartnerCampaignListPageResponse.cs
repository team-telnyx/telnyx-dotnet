using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

[JsonConverter(typeof(JsonModelConverter<PartnerCampaignListPageResponse, PartnerCampaignListPageResponseFromRaw>))]
public sealed record class PartnerCampaignListPageResponse : JsonModel
{
    public long? Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    public IReadOnlyList<TelnyxDownstreamCampaign>? Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TelnyxDownstreamCampaign>>(
                "records"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TelnyxDownstreamCampaign>?>(
                "records",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "totalRecords"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("totalRecords", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        foreach (var item in this.Records ?? [])
        {
            item.Validate();
        }
        _ = this.TotalRecords;
    }

    public PartnerCampaignListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PartnerCampaignListPageResponse (
        PartnerCampaignListPageResponse partnerCampaignListPageResponse
    ) : base(partnerCampaignListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PartnerCampaignListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PartnerCampaignListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PartnerCampaignListPageResponseFromRaw.FromRawUnchecked"/>
    public static PartnerCampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PartnerCampaignListPageResponseFromRaw : IFromRawJson<PartnerCampaignListPageResponse>
{
    /// <inheritdoc/>
    public PartnerCampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PartnerCampaignListPageResponse.FromRawUnchecked(rawData);
}