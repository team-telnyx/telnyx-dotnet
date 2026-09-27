using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CustomerServiceRecords;

[JsonConverter(typeof(JsonModelConverter<CustomerServiceRecordCreateResponse, CustomerServiceRecordCreateResponseFromRaw>))]
public sealed record class CustomerServiceRecordCreateResponse : JsonModel
{
    public CustomerServiceRecord? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerServiceRecord>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CustomerServiceRecordCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecordCreateResponse (
        CustomerServiceRecordCreateResponse customerServiceRecordCreateResponse
    ) : base(customerServiceRecordCreateResponse)
    {  }
    #pragma warning restore CS8618

    public CustomerServiceRecordCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerServiceRecordCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerServiceRecordCreateResponseFromRaw.FromRawUnchecked"/>
    public static CustomerServiceRecordCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerServiceRecordCreateResponseFromRaw : IFromRawJson<CustomerServiceRecordCreateResponse>
{
    /// <inheritdoc/>
    public CustomerServiceRecordCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerServiceRecordCreateResponse.FromRawUnchecked(rawData);
}