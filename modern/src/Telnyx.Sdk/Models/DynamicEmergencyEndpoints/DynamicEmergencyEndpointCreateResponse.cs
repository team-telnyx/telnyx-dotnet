using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyEndpointCreateResponse, DynamicEmergencyEndpointCreateResponseFromRaw>))]
public sealed record class DynamicEmergencyEndpointCreateResponse : JsonModel
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

    public DynamicEmergencyEndpointCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyEndpointCreateResponse (
        DynamicEmergencyEndpointCreateResponse dynamicEmergencyEndpointCreateResponse
    ) : base(dynamicEmergencyEndpointCreateResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyEndpointCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyEndpointCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyEndpointCreateResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyEndpointCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyEndpointCreateResponseFromRaw : IFromRawJson<DynamicEmergencyEndpointCreateResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyEndpointCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyEndpointCreateResponse.FromRawUnchecked(rawData);
}