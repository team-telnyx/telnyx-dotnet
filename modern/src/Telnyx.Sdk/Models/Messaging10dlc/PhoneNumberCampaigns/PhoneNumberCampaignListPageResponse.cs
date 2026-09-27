using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberCampaigns;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberCampaignListPageResponse, PhoneNumberCampaignListPageResponseFromRaw>))]
public sealed record class PhoneNumberCampaignListPageResponse : JsonModel
{
    public required long Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page"
            );
        }
        init { this._rawData.Set("page", value); }
    }

    public required IReadOnlyList<PhoneNumberCampaign> Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PhoneNumberCampaign>>(
                "records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<PhoneNumberCampaign>>(
                "records",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "totalRecords"
            );
        }
        init { this._rawData.Set("totalRecords", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        foreach (var item in this.Records)
        {
            item.Validate();
        }
        _ = this.TotalRecords;
    }

    public PhoneNumberCampaignListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberCampaignListPageResponse (
        PhoneNumberCampaignListPageResponse phoneNumberCampaignListPageResponse
    ) : base(phoneNumberCampaignListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberCampaignListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberCampaignListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberCampaignListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberCampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberCampaignListPageResponseFromRaw : IFromRawJson<PhoneNumberCampaignListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberCampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberCampaignListPageResponse.FromRawUnchecked(rawData);
}