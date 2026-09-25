using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VoiceSdkCallReports;

/// <summary>
/// A raw Voice SDK log entry. Additional SDK-specific fields may be present.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceSdkCallReportLogEntry, VoiceSdkCallReportLogEntryFromRaw>))]
public sealed record class VoiceSdkCallReportLogEntry : JsonModel
{
    /// <summary>
    /// Raw structured context attached to the log entry.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Context {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "context",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Log level emitted by the SDK.
    /// </summary>
    public ApiEnum<string, Level>? Level {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Level>>(
                "level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("level", value);
        }
    }

    /// <summary>
    /// Log message.
    /// </summary>
    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Time when the log entry was emitted.
    /// </summary>
    public System::DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
        this.Level?.Validate();
        _ = this.Message;
        _ = this.Timestamp;
    }

    public VoiceSdkCallReportLogEntry ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSdkCallReportLogEntry (
        VoiceSdkCallReportLogEntry voiceSdkCallReportLogEntry
    ) : base(voiceSdkCallReportLogEntry)
    {  }
    #pragma warning restore CS8618

    public VoiceSdkCallReportLogEntry (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSdkCallReportLogEntry (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSdkCallReportLogEntryFromRaw.FromRawUnchecked"/>
    public static VoiceSdkCallReportLogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceSdkCallReportLogEntryFromRaw : IFromRawJson<VoiceSdkCallReportLogEntry>
{
    /// <inheritdoc/>
    public VoiceSdkCallReportLogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceSdkCallReportLogEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Log level emitted by the SDK.
/// </summary>
[JsonConverter(typeof(LevelConverter))]
public enum Level
{
    Debug, Info, Warn, Error
}sealed class LevelConverter : JsonConverter<Level>
{
    public override Level Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "debug"=>Level.Debug,
            "info"=>Level.Info,
            "warn"=>Level.Warn,
            "error"=>Level.Error,
            _ =>(Level)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Level value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Level.Debug=>"debug",
            Level.Info=>"info",
            Level.Warn=>"warn",
            Level.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}