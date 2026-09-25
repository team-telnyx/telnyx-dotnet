using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyAddressDeleteResponse, DynamicEmergencyAddressDeleteResponseFromRaw>))]
public sealed record class DynamicEmergencyAddressDeleteResponse : JsonModel
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

    public DynamicEmergencyAddressDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddressDeleteResponse (
        DynamicEmergencyAddressDeleteResponse dynamicEmergencyAddressDeleteResponse
    ) : base(dynamicEmergencyAddressDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyAddressDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyAddressDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyAddressDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyAddressDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyAddressDeleteResponseFromRaw : IFromRawJson<DynamicEmergencyAddressDeleteResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyAddressDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyAddressDeleteResponse.FromRawUnchecked(rawData);
}