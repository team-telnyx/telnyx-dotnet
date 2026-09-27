using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.CustomerServiceRecords;

[JsonConverter(typeof(JsonModelConverter<CustomerServiceRecordListPageResponse, CustomerServiceRecordListPageResponseFromRaw>))]
public sealed record class CustomerServiceRecordListPageResponse : JsonModel
{
    public IReadOnlyList<CustomerServiceRecord>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomerServiceRecord>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerServiceRecord>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public CustomerServiceRecordListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecordListPageResponse (
        CustomerServiceRecordListPageResponse customerServiceRecordListPageResponse
    ) : base(customerServiceRecordListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CustomerServiceRecordListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerServiceRecordListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerServiceRecordListPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerServiceRecordListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerServiceRecordListPageResponseFromRaw : IFromRawJson<CustomerServiceRecordListPageResponse>
{
    /// <inheritdoc/>
    public CustomerServiceRecordListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerServiceRecordListPageResponse.FromRawUnchecked(rawData);
}