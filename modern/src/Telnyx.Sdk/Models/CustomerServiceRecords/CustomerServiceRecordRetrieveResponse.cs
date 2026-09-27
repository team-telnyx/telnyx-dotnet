using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CustomerServiceRecords;

[JsonConverter(typeof(JsonModelConverter<CustomerServiceRecordRetrieveResponse, CustomerServiceRecordRetrieveResponseFromRaw>))]
public sealed record class CustomerServiceRecordRetrieveResponse : JsonModel
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

    public CustomerServiceRecordRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecordRetrieveResponse (
        CustomerServiceRecordRetrieveResponse customerServiceRecordRetrieveResponse
    ) : base(customerServiceRecordRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CustomerServiceRecordRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerServiceRecordRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerServiceRecordRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CustomerServiceRecordRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerServiceRecordRetrieveResponseFromRaw : IFromRawJson<CustomerServiceRecordRetrieveResponse>
{
    /// <inheritdoc/>
    public CustomerServiceRecordRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerServiceRecordRetrieveResponse.FromRawUnchecked(rawData);
}