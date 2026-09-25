using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

[JsonConverter(typeof(JsonModelConverter<VoicemailRequest, VoicemailRequestFromRaw>))]
public sealed record class VoicemailRequest : JsonModel
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
    public VoicemailRequestGreeting? Greeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoicemailRequestGreeting>(
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
    /// The pin used for voicemail
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

    public VoicemailRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailRequest (VoicemailRequest voicemailRequest) : base(
        voicemailRequest
    )
    {  }
    #pragma warning restore CS8618

    public VoicemailRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailRequestFromRaw.FromRawUnchecked"/>
    public static VoicemailRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoicemailRequestFromRaw : IFromRawJson<VoicemailRequest>
{
    /// <inheritdoc/>
    public VoicemailRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls the greeting a caller hears before leaving a voicemail. Set `mode` to
/// `default` to play the standard system greeting, or to `custom_greeting` to play
/// your own audio. When `mode` is `custom_greeting`, `media_name` is required and
/// must reference an audio file already uploaded to your account through the Media
/// Storage API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoicemailRequestGreeting, VoicemailRequestGreetingFromRaw>))]
public sealed record class VoicemailRequestGreeting : JsonModel
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
    public ApiEnum<string, VoicemailRequestGreetingMode>? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoicemailRequestGreetingMode>>(
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

    public VoicemailRequestGreeting ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailRequestGreeting (
        VoicemailRequestGreeting voicemailRequestGreeting
    ) : base(voicemailRequestGreeting)
    {  }
    #pragma warning restore CS8618

    public VoicemailRequestGreeting (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailRequestGreeting (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailRequestGreetingFromRaw.FromRawUnchecked"/>
    public static VoicemailRequestGreeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoicemailRequestGreetingFromRaw : IFromRawJson<VoicemailRequestGreeting>
{
    /// <inheritdoc/>
    public VoicemailRequestGreeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailRequestGreeting.FromRawUnchecked(rawData);
}/// <summary>
/// The greeting mode. `default` plays the standard system greeting. `custom_greeting`
/// plays the audio referenced by `media_name`.
/// </summary>
[JsonConverter(typeof(VoicemailRequestGreetingModeConverter))]
public enum VoicemailRequestGreetingMode
{
    Default, CustomGreeting
}sealed class VoicemailRequestGreetingModeConverter : JsonConverter<VoicemailRequestGreetingMode>
{
    public override VoicemailRequestGreetingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default"=>VoicemailRequestGreetingMode.Default,
            "custom_greeting"=>VoicemailRequestGreetingMode.CustomGreeting,
            _ =>(VoicemailRequestGreetingMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoicemailRequestGreetingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoicemailRequestGreetingMode.Default=>"default",
            VoicemailRequestGreetingMode.CustomGreeting=>"custom_greeting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}