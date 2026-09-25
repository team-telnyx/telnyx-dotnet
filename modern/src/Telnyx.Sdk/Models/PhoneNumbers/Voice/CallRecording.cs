using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

/// <summary>
/// The call recording settings for a phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallRecording, CallRecordingFromRaw>))]
public sealed record class CallRecording : JsonModel
{
    /// <summary>
    /// When using 'dual' channels, final audio file will be stereo recorded with
    /// the first leg on channel A, and the rest on channel B.
    /// </summary>
    public ApiEnum<string, InboundCallRecordingChannels>? InboundCallRecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundCallRecordingChannels>>(
                "inbound_call_recording_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_channels", value);
        }
    }

    /// <summary>
    /// When enabled, any inbound call to this number will be recorded.
    /// </summary>
    public bool? InboundCallRecordingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "inbound_call_recording_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_enabled", value);
        }
    }

    /// <summary>
    /// The audio file format for calls being recorded.
    /// </summary>
    public ApiEnum<string, InboundCallRecordingFormat>? InboundCallRecordingFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundCallRecordingFormat>>(
                "inbound_call_recording_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InboundCallRecordingChannels?.Validate();
        _ = this.InboundCallRecordingEnabled;
        this.InboundCallRecordingFormat?.Validate();
    }

    public CallRecording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecording (CallRecording callRecording) : base(callRecording)
    {  }
    #pragma warning restore CS8618

    public CallRecording (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecording (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingFromRaw.FromRawUnchecked"/>
    public static CallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingFromRaw : IFromRawJson<CallRecording>
{
    /// <inheritdoc/>
    public CallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecording.FromRawUnchecked(rawData);
}

/// <summary>
/// When using 'dual' channels, final audio file will be stereo recorded with the
/// first leg on channel A, and the rest on channel B.
/// </summary>
[JsonConverter(typeof(InboundCallRecordingChannelsConverter))]
public enum InboundCallRecordingChannels
{
    Single, Dual
}sealed class InboundCallRecordingChannelsConverter : JsonConverter<InboundCallRecordingChannels>
{
    public override InboundCallRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>InboundCallRecordingChannels.Single,
            "dual"=>InboundCallRecordingChannels.Dual,
            _ =>(InboundCallRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallRecordingChannels.Single=>"single",
            InboundCallRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The audio file format for calls being recorded.
/// </summary>
[JsonConverter(typeof(InboundCallRecordingFormatConverter))]
public enum InboundCallRecordingFormat
{
    Wav, Mp3
}sealed class InboundCallRecordingFormatConverter : JsonConverter<InboundCallRecordingFormat>
{
    public override InboundCallRecordingFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>InboundCallRecordingFormat.Wav,
            "mp3"=>InboundCallRecordingFormat.Mp3,
            _ =>(InboundCallRecordingFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallRecordingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallRecordingFormat.Wav=>"wav",
            InboundCallRecordingFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}