using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<RegionOut, RegionOutFromRaw>))]
public sealed record class RegionOut : JsonModel
{
    public Region? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Region>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// The region interface is deployed to.
    /// </summary>
    public string? RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Region?.Validate();
        _ = this.RegionCode;
    }

    public RegionOut ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegionOut (RegionOut regionOut) : base(regionOut)
    {  }
    #pragma warning restore CS8618

    public RegionOut (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegionOut (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegionOutFromRaw.FromRawUnchecked"/>
    public static RegionOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RegionOutFromRaw : IFromRawJson<RegionOut>
{
    /// <inheritdoc/>
    public RegionOut FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegionOut.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Region, RegionFromRaw>))]
public sealed record class Region : JsonModel
{
    /// <summary>
    /// Region code of the interface.
    /// </summary>
    public string? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Region name of the interface.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
        _ = this.RecordType;
    }

    public Region ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Region (Region region) : base(region)
    {  }
    #pragma warning restore CS8618

    public Region (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Region (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegionFromRaw.FromRawUnchecked"/>
    public static Region FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegionFromRaw : IFromRawJson<Region>
{
    /// <inheritdoc/>
    public Region FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Region.FromRawUnchecked(rawData);
}