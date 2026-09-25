using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

[JsonConverter(typeof(JsonModelConverter<VoicemailPrefResponse, VoicemailPrefResponseFromRaw>))]
public sealed record class VoicemailPrefResponse : JsonModel
{
    /// <summary>
    /// Whether voicemail is enabled.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Controls the greeting a caller hears before leaving a voicemail. Set `mode`
    /// to `default` to play the standard system greeting, or to `custom_greeting`
    /// to play your own audio. When `mode` is `custom_greeting`, `media_name` is
    /// required and must reference an audio file already uploaded to your account
    /// through the Media Storage API.
    /// </summary>
    public VoicemailPrefResponseGreeting? Greeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoicemailPrefResponseGreeting>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting", value);
        }
    }

    /// <summary>
    /// The pin used for the voicemail.
    /// </summary>
    public string? Pin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pin", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        this.Greeting?.Validate();
        _ = this.Pin;
    }

    public VoicemailPrefResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailPrefResponse (
        VoicemailPrefResponse voicemailPrefResponse
    ) : base(voicemailPrefResponse)
    {  }
    #pragma warning restore CS8618

    public VoicemailPrefResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailPrefResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailPrefResponseFromRaw.FromRawUnchecked"/>
    public static VoicemailPrefResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoicemailPrefResponseFromRaw : IFromRawJson<VoicemailPrefResponse>
{
    /// <inheritdoc/>
    public VoicemailPrefResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailPrefResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls the greeting a caller hears before leaving a voicemail. Set `mode` to
/// `default` to play the standard system greeting, or to `custom_greeting` to play
/// your own audio. When `mode` is `custom_greeting`, `media_name` is required and
/// must reference an audio file already uploaded to your account through the Media
/// Storage API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoicemailPrefResponseGreeting, VoicemailPrefResponseGreetingFromRaw>))]
public sealed record class VoicemailPrefResponseGreeting : JsonModel
{
    /// <summary>
    /// The name of the media file to play as the greeting. Required when `mode`
    /// is `custom_greeting`; ignored when `mode` is `default`. The value must match
    /// the `media_name` of a file you previously uploaded with the Media Storage
    /// API (`POST /v2/media`).
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init { this._rawData.Set("media_name", value); }
    }

    /// <summary>
    /// The greeting mode. `default` plays the standard system greeting. `custom_greeting`
    /// plays the audio referenced by `media_name`.
    /// </summary>
    public ApiEnum<string, VoicemailPrefResponseGreetingMode>? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoicemailPrefResponseGreetingMode>>(
                "mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaName;
        this.Mode?.Validate();
    }

    public VoicemailPrefResponseGreeting ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailPrefResponseGreeting (
        VoicemailPrefResponseGreeting voicemailPrefResponseGreeting
    ) : base(voicemailPrefResponseGreeting)
    {  }
    #pragma warning restore CS8618

    public VoicemailPrefResponseGreeting (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailPrefResponseGreeting (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailPrefResponseGreetingFromRaw.FromRawUnchecked"/>
    public static VoicemailPrefResponseGreeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoicemailPrefResponseGreetingFromRaw : IFromRawJson<VoicemailPrefResponseGreeting>
{
    /// <inheritdoc/>
    public VoicemailPrefResponseGreeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailPrefResponseGreeting.FromRawUnchecked(rawData);
}/// <summary>
/// The greeting mode. `default` plays the standard system greeting. `custom_greeting`
/// plays the audio referenced by `media_name`.
/// </summary>
[JsonConverter(typeof(VoicemailPrefResponseGreetingModeConverter))]
public enum VoicemailPrefResponseGreetingMode
{
    Default, CustomGreeting
}sealed class VoicemailPrefResponseGreetingModeConverter : JsonConverter<VoicemailPrefResponseGreetingMode>
{
    public override VoicemailPrefResponseGreetingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default"=>VoicemailPrefResponseGreetingMode.Default,
            "custom_greeting"=>VoicemailPrefResponseGreetingMode.CustomGreeting,
            _ =>(VoicemailPrefResponseGreetingMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoicemailPrefResponseGreetingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoicemailPrefResponseGreetingMode.Default=>"default",
            VoicemailPrefResponseGreetingMode.CustomGreeting=>"custom_greeting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}