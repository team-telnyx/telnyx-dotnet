using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyEndpointListPageResponse, DynamicEmergencyEndpointListPageResponseFromRaw>))]
public sealed record class DynamicEmergencyEndpointListPageResponse : JsonModel
{
    public IReadOnlyList<DynamicEmergencyEndpoint>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DynamicEmergencyEndpoint>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DynamicEmergencyEndpoint>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Metadata? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public DynamicEmergencyEndpointListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyEndpointListPageResponse (
        DynamicEmergencyEndpointListPageResponse dynamicEmergencyEndpointListPageResponse
    ) : base(dynamicEmergencyEndpointListPageResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyEndpointListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyEndpointListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyEndpointListPageResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyEndpointListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyEndpointListPageResponseFromRaw : IFromRawJson<DynamicEmergencyEndpointListPageResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyEndpointListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyEndpointListPageResponse.FromRawUnchecked(rawData);
}