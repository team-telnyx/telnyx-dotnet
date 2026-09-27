using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.Whatsapp.BusinessAccounts;

[JsonConverter(typeof(JsonModelConverter<BusinessAccountListPageResponse, BusinessAccountListPageResponseFromRaw>))]
public sealed record class BusinessAccountListPageResponse : JsonModel
{
    public IReadOnlyList<BusinessAccountListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BusinessAccountListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<BusinessAccountListResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingPaginationMeta0b38e7044b? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingPaginationMeta0b38e7044b>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public BusinessAccountListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessAccountListPageResponse (
        BusinessAccountListPageResponse businessAccountListPageResponse
    ) : base(businessAccountListPageResponse)
    {  }
    #pragma warning restore CS8618

    public BusinessAccountListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessAccountListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BusinessAccountListPageResponseFromRaw.FromRawUnchecked"/>
    public static BusinessAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BusinessAccountListPageResponseFromRaw : IFromRawJson<BusinessAccountListPageResponse>
{
    /// <inheritdoc/>
    public BusinessAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BusinessAccountListPageResponse.FromRawUnchecked(rawData);
}