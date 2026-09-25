using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyAddressListPageResponse, DynamicEmergencyAddressListPageResponseFromRaw>))]
public sealed record class DynamicEmergencyAddressListPageResponse : JsonModel
{
    public IReadOnlyList<DynamicEmergencyAddress>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DynamicEmergencyAddress>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DynamicEmergencyAddress>?>(
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

    public DynamicEmergencyAddressListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddressListPageResponse (
        DynamicEmergencyAddressListPageResponse dynamicEmergencyAddressListPageResponse
    ) : base(dynamicEmergencyAddressListPageResponse)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyAddressListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyAddressListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyAddressListPageResponseFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyAddressListPageResponseFromRaw : IFromRawJson<DynamicEmergencyAddressListPageResponse>
{
    /// <inheritdoc/>
    public DynamicEmergencyAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyAddressListPageResponse.FromRawUnchecked(rawData);
}