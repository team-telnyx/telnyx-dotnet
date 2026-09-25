using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignListPageResponse, CampaignListPageResponseFromRaw>))]
public sealed record class CampaignListPageResponse : JsonModel
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

    public IReadOnlyList<CampaignListResponse>? Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CampaignListResponse>>(
                "records"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CampaignListResponse>?>(
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

    public CampaignListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListPageResponse (
        CampaignListPageResponse campaignListPageResponse
    ) : base(campaignListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListPageResponseFromRaw.FromRawUnchecked"/>
    public static CampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignListPageResponseFromRaw : IFromRawJson<CampaignListPageResponse>
{
    /// <inheritdoc/>
    public CampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignListPageResponse.FromRawUnchecked(rawData);
}