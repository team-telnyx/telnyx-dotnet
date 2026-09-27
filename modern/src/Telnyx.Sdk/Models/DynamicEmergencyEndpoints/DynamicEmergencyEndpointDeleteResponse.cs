using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyEndpointDeleteResponse, DynamicEmergencyEndpointDeleteResponseFromRaw>))]
public sealed record class DynamicEmergencyEndpointDeleteResponse : JsonModel
{
    public DynamicEmergencyEndpoint? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DynamicEmergencyEndpoint>(
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

    public DynamicEmergencyEndpointDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyEndpointDeleteResponse (
        DynamicEmergencyEndpointDeleteResponse dynamicEmergencyEndpointDeleteResponse
    ) : base(dynamicEmergencyEndpointDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyEndpointDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyEndpointDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyEndpointDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyEndpointDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyEndpointDeleteResponseFromRaw : IFromRawJson<DynamicEmergencyEndpointDeleteResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyEndpointDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyEndpointDeleteResponse.FromRawUnchecked(rawData);
}