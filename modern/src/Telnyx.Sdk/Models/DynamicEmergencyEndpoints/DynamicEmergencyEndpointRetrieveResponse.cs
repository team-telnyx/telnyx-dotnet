using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyEndpointRetrieveResponse, DynamicEmergencyEndpointRetrieveResponseFromRaw>))]
public sealed record class DynamicEmergencyEndpointRetrieveResponse : JsonModel
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

    public DynamicEmergencyEndpointRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyEndpointRetrieveResponse (
        DynamicEmergencyEndpointRetrieveResponse dynamicEmergencyEndpointRetrieveResponse
    ) : base(dynamicEmergencyEndpointRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyEndpointRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyEndpointRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyEndpointRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyEndpointRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyEndpointRetrieveResponseFromRaw : IFromRawJson<DynamicEmergencyEndpointRetrieveResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyEndpointRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyEndpointRetrieveResponse.FromRawUnchecked(rawData);
}