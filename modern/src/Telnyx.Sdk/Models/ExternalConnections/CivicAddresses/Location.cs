using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

[JsonConverter(typeof(JsonModelConverter<Location, LocationFromRaw>))]
public sealed record class Location : JsonModel
{
    /// <summary>
    /// Uniquely identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? AdditionalInfo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "additional_info"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("additional_info", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Represents whether the location is the default or not.
    /// </summary>
    public bool? IsDefault {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_default"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_default", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AdditionalInfo;
        _ = this.Description;
        _ = this.IsDefault;
    }

    public Location ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Location (Location location) : base(location)
    {  }
    #pragma warning restore CS8618

    public Location (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Location (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LocationFromRaw.FromRawUnchecked"/>
    public static Location FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LocationFromRaw : IFromRawJson<Location>
{
    /// <inheritdoc/>
    public Location FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Location.FromRawUnchecked(rawData);
}