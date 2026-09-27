using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyAddressRetrieveResponse, DynamicEmergencyAddressRetrieveResponseFromRaw>))]
public sealed record class DynamicEmergencyAddressRetrieveResponse : JsonModel
{
    public DynamicEmergencyAddress? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DynamicEmergencyAddress>(
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

    public DynamicEmergencyAddressRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddressRetrieveResponse (
        DynamicEmergencyAddressRetrieveResponse dynamicEmergencyAddressRetrieveResponse
    ) : base(dynamicEmergencyAddressRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyAddressRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyAddressRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyAddressRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyAddressRetrieveResponseFromRaw : IFromRawJson<DynamicEmergencyAddressRetrieveResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyAddressRetrieveResponse.FromRawUnchecked(rawData);
}