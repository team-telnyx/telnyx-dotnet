using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

[JsonConverter(typeof(JsonModelConverter<PartnerCampaignListSharedByMePageResponse, PartnerCampaignListSharedByMePageResponseFromRaw>))]
public sealed record class PartnerCampaignListSharedByMePageResponse : JsonModel
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

    public IReadOnlyList<PartnerCampaignListSharedByMeResponse>? Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PartnerCampaignListSharedByMeResponse>>(
                "records"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PartnerCampaignListSharedByMeResponse>?>(
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

    public PartnerCampaignListSharedByMePageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PartnerCampaignListSharedByMePageResponse (
        PartnerCampaignListSharedByMePageResponse partnerCampaignListSharedByMePageResponse
    ) : base(partnerCampaignListSharedByMePageResponse)
    {  }
    #pragma warning restore CS8618

    public PartnerCampaignListSharedByMePageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PartnerCampaignListSharedByMePageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PartnerCampaignListSharedByMePageResponseFromRaw.FromRawUnchecked"/>
    public static PartnerCampaignListSharedByMePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PartnerCampaignListSharedByMePageResponseFromRaw : IFromRawJson<PartnerCampaignListSharedByMePageResponse>
{
    /// <inheritdoc/>
    public PartnerCampaignListSharedByMePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PartnerCampaignListSharedByMePageResponse.FromRawUnchecked(rawData);
}