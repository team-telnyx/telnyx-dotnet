using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WirelessBlocklists;

[JsonConverter(typeof(JsonModelConverter<WirelessWirelessBlocklist, WirelessWirelessBlocklistFromRaw>))]
public sealed record class WirelessWirelessBlocklist : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The wireless blocklist name.
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
    /// The type of the wireless blocklist.
    /// </summary>
    public ApiEnum<string, WirelessWirelessBlocklistType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WirelessWirelessBlocklistType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// Values to block. The values here depend on the `type` of Wireless Blocklist.
    /// </summary>
    public IReadOnlyList<string>? Values {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "values"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        this.Type?.Validate();
        _ = this.UpdatedAt;
        _ = this.Values;
    }

    public WirelessWirelessBlocklist ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessWirelessBlocklist (
        WirelessWirelessBlocklist wirelessWirelessBlocklist
    ) : base(wirelessWirelessBlocklist)
    {  }
    #pragma warning restore CS8618

    public WirelessWirelessBlocklist (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessWirelessBlocklist (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessWirelessBlocklistFromRaw.FromRawUnchecked"/>
    public static WirelessWirelessBlocklist FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessWirelessBlocklistFromRaw : IFromRawJson<WirelessWirelessBlocklist>
{
    /// <inheritdoc/>
    public WirelessWirelessBlocklist FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessWirelessBlocklist.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the wireless blocklist.
/// </summary>
[JsonConverter(typeof(WirelessWirelessBlocklistTypeConverter))]
public enum WirelessWirelessBlocklistType
{
    Country, Mcc, Plmn
}sealed class WirelessWirelessBlocklistTypeConverter : JsonConverter<WirelessWirelessBlocklistType>
{
    public override WirelessWirelessBlocklistType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country"=>WirelessWirelessBlocklistType.Country,
            "mcc"=>WirelessWirelessBlocklistType.Mcc,
            "plmn"=>WirelessWirelessBlocklistType.Plmn,
            _ =>(WirelessWirelessBlocklistType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WirelessWirelessBlocklistType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WirelessWirelessBlocklistType.Country=>"country",
            WirelessWirelessBlocklistType.Mcc=>"mcc",
            WirelessWirelessBlocklistType.Plmn=>"plmn",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}