using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<NetappsLocation, NetappsLocationFromRaw>))]
public sealed record class NetappsLocation : JsonModel
{
    /// <summary>
    /// Location code.
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
    /// Human readable name of location.
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
    /// Point of presence of location.
    /// </summary>
    public string? Pop {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pop", value);
        }
    }

    /// <summary>
    /// Identifies the geographical region of location.
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Site of location.
    /// </summary>
    public string? Site {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "site"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("site", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
        _ = this.Pop;
        _ = this.Region;
        _ = this.Site;
    }

    public NetappsLocation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetappsLocation (NetappsLocation netappsLocation) : base(
        netappsLocation
    )
    {  }
    #pragma warning restore CS8618

    public NetappsLocation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetappsLocation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetappsLocationFromRaw.FromRawUnchecked"/>
    public static NetappsLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetappsLocationFromRaw : IFromRawJson<NetappsLocation>
{
    /// <inheritdoc/>
    public NetappsLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetappsLocation.FromRawUnchecked(rawData);
}