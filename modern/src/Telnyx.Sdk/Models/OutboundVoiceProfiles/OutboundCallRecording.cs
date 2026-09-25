using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundCallRecording, OutboundCallRecordingFromRaw>))]
public sealed record class OutboundCallRecording : JsonModel
{
    /// <summary>
    /// When call_recording_type is 'by_caller_phone_number', only outbound calls
    /// using one of these numbers will be recorded. Numbers must be specified in
    /// E164 format.
    /// </summary>
    public IReadOnlyList<string>? CallRecordingCallerPhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "call_recording_caller_phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "call_recording_caller_phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When using 'dual' channels, the final audio file will be a stereo recording
    /// with the first leg on channel A, and the rest on channel B.
    /// </summary>
    public ApiEnum<string, CallRecordingChannels>? CallRecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingChannels>>(
                "call_recording_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording_channels", value);
        }
    }

    /// <summary>
    /// The audio file format for calls being recorded.
    /// </summary>
    public ApiEnum<string, CallRecordingFormat>? CallRecordingFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingFormat>>(
                "call_recording_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording_format", value);
        }
    }

    /// <summary>
    /// Specifies which calls are recorded.
    /// </summary>
    public ApiEnum<string, CallRecordingType>? CallRecordingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallRecordingType>>(
                "call_recording_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallRecordingCallerPhoneNumbers;
        this.CallRecordingChannels?.Validate();
        this.CallRecordingFormat?.Validate();
        this.CallRecordingType?.Validate();
    }

    public OutboundCallRecording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundCallRecording (
        OutboundCallRecording outboundCallRecording
    ) : base(outboundCallRecording)
    {  }
    #pragma warning restore CS8618

    public OutboundCallRecording (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundCallRecording (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundCallRecordingFromRaw.FromRawUnchecked"/>
    public static OutboundCallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundCallRecordingFromRaw : IFromRawJson<OutboundCallRecording>
{
    /// <inheritdoc/>
    public OutboundCallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundCallRecording.FromRawUnchecked(rawData);
}

/// <summary>
/// When using 'dual' channels, the final audio file will be a stereo recording with
/// the first leg on channel A, and the rest on channel B.
/// </summary>
[JsonConverter(typeof(CallRecordingChannelsConverter))]
public enum CallRecordingChannels
{
    Single, Dual
}sealed class CallRecordingChannelsConverter : JsonConverter<CallRecordingChannels>
{
    public override CallRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>CallRecordingChannels.Single,
            "dual"=>CallRecordingChannels.Dual,
            _ =>(CallRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingChannels.Single=>"single",
            CallRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The audio file format for calls being recorded.
/// </summary>
[JsonConverter(typeof(CallRecordingFormatConverter))]
public enum CallRecordingFormat
{
    Wav, Mp3
}sealed class CallRecordingFormatConverter : JsonConverter<CallRecordingFormat>
{
    public override CallRecordingFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>CallRecordingFormat.Wav,
            "mp3"=>CallRecordingFormat.Mp3,
            _ =>(CallRecordingFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingFormat.Wav=>"wav",
            CallRecordingFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Specifies which calls are recorded.
/// </summary>
[JsonConverter(typeof(CallRecordingTypeConverter))]
public enum CallRecordingType
{
    All, None, ByCallerPhoneNumber
}sealed class CallRecordingTypeConverter : JsonConverter<CallRecordingType>
{
    public override CallRecordingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all"=>CallRecordingType.All,
            "none"=>CallRecordingType.None,
            "by_caller_phone_number"=>CallRecordingType.ByCallerPhoneNumber,
            _ =>(CallRecordingType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRecordingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRecordingType.All=>"all",
            CallRecordingType.None=>"none",
            CallRecordingType.ByCallerPhoneNumber=>"by_caller_phone_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}