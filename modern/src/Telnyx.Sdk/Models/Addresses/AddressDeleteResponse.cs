using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressDeleteResponse, AddressDeleteResponseFromRaw>))]
public sealed record class AddressDeleteResponse : JsonModel
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

    public AddressDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressDeleteResponse (
        AddressDeleteResponse addressDeleteResponse
    ) : base(addressDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public AddressDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AddressDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AddressDeleteResponseFromRaw : IFromRawJson<AddressDeleteResponse>
{
    /// <inheritdoc/>
    public AddressDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AddressDeleteResponse.FromRawUnchecked(rawData);
}