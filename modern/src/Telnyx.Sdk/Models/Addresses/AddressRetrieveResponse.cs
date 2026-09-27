using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressRetrieveResponse, AddressRetrieveResponseFromRaw>))]
public sealed record class AddressRetrieveResponse : JsonModel
{
    public Address? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>(
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

    public AddressRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressRetrieveResponse (
        AddressRetrieveResponse addressRetrieveResponse
    ) : base(addressRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public AddressRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AddressRetrieveResponseFromRaw : IFromRawJson<AddressRetrieveResponse>
{
    /// <inheritdoc/>
    public AddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AddressRetrieveResponse.FromRawUnchecked(rawData);
}