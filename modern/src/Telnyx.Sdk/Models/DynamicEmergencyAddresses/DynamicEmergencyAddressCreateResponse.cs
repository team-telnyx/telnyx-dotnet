using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyAddressCreateResponse, DynamicEmergencyAddressCreateResponseFromRaw>))]
public sealed record class DynamicEmergencyAddressCreateResponse : JsonModel
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

    public DynamicEmergencyAddressCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddressCreateResponse (
        DynamicEmergencyAddressCreateResponse dynamicEmergencyAddressCreateResponse
    ) : base(dynamicEmergencyAddressCreateResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyAddressCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyAddressCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyAddressCreateResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyAddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyAddressCreateResponseFromRaw : IFromRawJson<DynamicEmergencyAddressCreateResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyAddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyAddressCreateResponse.FromRawUnchecked(rawData);
}