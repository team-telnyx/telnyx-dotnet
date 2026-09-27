using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ChannelZones;

[JsonConverter(typeof(JsonModelConverter<GcbChannelZone, GcbChannelZoneFromRaw>))]
public sealed record class GcbChannelZone : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required long Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "channels"
            );
        }
        init { this._rawData.Set("channels", value); }
    }

    /// <summary>
    /// List of countries (in ISO 3166-2, capitalized) members of the billing channel zone
    /// </summary>
    public required IReadOnlyList<string> Countries {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "countries"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "countries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the channel zone was created
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
    /// ISO 8601 formatted date of when the channel zone was updated
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Channels;
        _ = this.Countries;
        _ = this.Name;
        this.RecordType.Validate();
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public GcbChannelZone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GcbChannelZone (GcbChannelZone gcbChannelZone) : base(gcbChannelZone)
    {  }
    #pragma warning restore CS8618

    public GcbChannelZone (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GcbChannelZone (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GcbChannelZoneFromRaw.FromRawUnchecked"/>
    public static GcbChannelZone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GcbChannelZoneFromRaw : IFromRawJson<GcbChannelZone>
{
    /// <inheritdoc/>
    public GcbChannelZone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GcbChannelZone.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    ChannelZone
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "channel_zone"=>RecordType.ChannelZone, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.ChannelZone=>"channel_zone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}