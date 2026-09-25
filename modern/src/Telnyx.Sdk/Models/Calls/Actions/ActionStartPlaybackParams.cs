using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Play an audio file on the call. If multiple play audio commands are issued consecutively,
/// the audio files will be placed in a queue awaiting playback.
///
/// <para>*Notes:*</para>
///
/// <para>- When `overlay` is enabled, `target_legs` is limited to `self`. - A customer
/// cannot Play Audio with `overlay=true` unless there is a Play Audio with `overlay=false`
/// actively playing.</para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.playback.started` - `call.playback.ended`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartPlaybackParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Specifies the type of audio provided in `audio_url` or `playback_content`.
    /// </summary>
    public ApiEnum<string, AudioType>? AudioType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AudioType>>(
                "audio_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("audio_type", value);
        }
    }

    /// <summary>
    /// The URL of a file to be played back on the call. The URL can point to either
    /// a WAV or MP3 file. media_name and audio_url cannot be used together in one request.
    /// </summary>
    public string? AudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("audio_url", value);
        }
    }

    /// <summary>
    /// Caches the audio file. Useful when playing the same audio file multiple times
    /// during the call.
    /// </summary>
    public bool? CacheAudio {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "cache_audio"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("cache_audio", value);
        }
    }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// The number of times the audio file should be played. If supplied, the value
    /// must be an integer between 1 and 100, or the special string `infinity` for
    /// an endless loop.
    /// </summary>
    public Loopcount? Loop {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Loopcount>(
                "loop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("loop", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played back on the call. The media_name must
    /// point to a file previously uploaded to api.telnyx.com/v2/media by the same
    /// user/organization. The file must either be a WAV or MP3 file.
    /// </summary>
    public string? MediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_name", value);
        }
    }

    /// <summary>
    /// When enabled, audio will be mixed on top of any other audio that is actively
    /// being played back. Note that `overlay: true` will only work if there is another
    /// audio file already being played on the call.
    /// </summary>
    public bool? Overlay {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "overlay"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("overlay", value);
        }
    }

    /// <summary>
    /// Allows a user to provide base64 encoded mp3 or wav. Note: when using this
    /// parameter, `media_url` and `media_name` in the `playback_started` and `playback_ended`
    /// webhooks will be empty
    /// </summary>
    public string? PlaybackContent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "playback_content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("playback_content", value);
        }
    }

    /// <summary>
    /// When specified, it stops the current audio being played. Specify `current`
    /// to stop the current audio being played, and to play the next file in the
    /// queue. Specify `all` to stop the current audio file being played and to also
    /// clear all audio files from the queue.
    /// </summary>
    public string? Stop {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "stop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stop", value);
        }
    }

    /// <summary>
    /// Specifies the leg or legs on which audio will be played. If supplied, the
    /// value must be either `self`, `opposite` or `both`.
    /// </summary>
    public string? TargetLegs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "target_legs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("target_legs", value);
        }
    }

    public ActionStartPlaybackParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartPlaybackParams (
        ActionStartPlaybackParams actionStartPlaybackParams
    ) : base(actionStartPlaybackParams)
    {
        this.CallControlID = actionStartPlaybackParams.CallControlID;

        this._rawBodyData = new(actionStartPlaybackParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartPlaybackParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartPlaybackParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionStartPlaybackParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionStartPlaybackParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/playback_start",
            this.CallControlID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Specifies the type of audio provided in `audio_url` or `playback_content`.
/// </summary>
[JsonConverter(typeof(AudioTypeConverter))]
public enum AudioType
{
    Mp3, Wav
}

sealed class AudioTypeConverter : JsonConverter<AudioType>
{
    public override AudioType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "mp3"=>AudioType.Mp3, "wav"=>AudioType.Wav, _ =>(AudioType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, AudioType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AudioType.Mp3=>"mp3",
            AudioType.Wav=>"wav",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}