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
/// Bridge two call control calls.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.bridged` for Leg A - `call.bridged` for Leg B</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionBridgeParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlIDToBridge { get; init; }

    /// <summary>
    /// The Call Control ID of the call you want to bridge with, can't be used together
    /// with queue parameter or video_room_id parameter.
    /// </summary>
    public required string CallControlIDToBridgeWith {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawBodyData.Set("call_control_id", value); }
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
    /// Specifies behavior after the bridge ends. If set to `true`, the current leg
    /// will be put on hold after unbridge instead of being hung up.
    /// </summary>
    public bool? HoldAfterUnbridge {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "hold_after_unbridge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold_after_unbridge", value);
        }
    }

    /// <summary>
    /// When enabled, DTMF tones are not passed to the call participant. The webhooks
    /// containing the DTMF information will be sent.
    /// </summary>
    public ApiEnum<string, MuteDtmf>? MuteDtmf {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MuteDtmf>>(
                "mute_dtmf"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mute_dtmf", value);
        }
    }

    /// <summary>
    /// Specifies behavior after the bridge ends (i.e. the opposite leg either hangs
    /// up or is transferred). If supplied with the value `self`, the current leg
    /// will be parked after unbridge. If not set, the default behavior is to hang
    /// up the leg.
    /// </summary>
    public string? ParkAfterUnbridge {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "park_after_unbridge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("park_after_unbridge", value);
        }
    }

    /// <summary>
    /// Specifies whether to play a ringtone if the call you want to bridge with
    /// has not yet been answered.
    /// </summary>
    public bool? PlayRingtone {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "play_ringtone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("play_ringtone", value);
        }
    }

    /// <summary>
    /// When set to `true`, it prevents bridging if the target call is already bridged
    /// to another call. Disabled by default.
    /// </summary>
    public bool? PreventDoubleBridge {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "prevent_double_bridge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("prevent_double_bridge", value);
        }
    }

    /// <summary>
    /// The name of the queue you want to bridge with, can't be used together with
    /// call_control_id parameter or video_room_id parameter. Bridging with a queue
    /// means bridging with the first call in the queue. The call will always be
    /// removed from the queue regardless of whether bridging succeeds. Returns an
    /// error when the queue is empty.
    /// </summary>
    public string? Queue {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "queue"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("queue", value);
        }
    }

    /// <summary>
    /// Start recording automatically after an event. Disabled by default.
    /// </summary>
    public ApiEnum<string, ActionBridgeParamsRecord>? Record {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionBridgeParamsRecord>>(
                "record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record", value);
        }
    }

    /// <summary>
    /// Defines which channel should be recorded ('single' or 'dual') when `record`
    /// is specified.
    /// </summary>
    public ApiEnum<string, ActionBridgeParamsRecordChannels>? RecordChannels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionBridgeParamsRecordChannels>>(
                "record_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_channels", value);
        }
    }

    /// <summary>
    /// The custom recording file name to be used instead of the default `call_leg_id`.
    /// Telnyx will still add a Unix timestamp suffix.
    /// </summary>
    public string? RecordCustomFileName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "record_custom_file_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_custom_file_name", value);
        }
    }

    /// <summary>
    /// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
    /// </summary>
    public ApiEnum<string, ActionBridgeParamsRecordFormat>? RecordFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionBridgeParamsRecordFormat>>(
                "record_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_format", value);
        }
    }

    /// <summary>
    /// Defines the maximum length for the recording in seconds when `record` is
    /// specified. The minimum value is 0. The maximum value is 43200. The default
    /// value is 0 (infinite).
    /// </summary>
    public int? RecordMaxLength {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "record_max_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_max_length", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected when `record` is specified. The timer only starts
    /// when the speech is detected. Please note that call transcription is used
    /// to detect silence and the related charge will be applied. The minimum value
    /// is 0. The default value is 0 (infinite).
    /// </summary>
    public int? RecordTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "record_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_timeout_secs", value);
        }
    }

    /// <summary>
    /// The audio track to be recorded. Can be either `both`, `inbound` or `outbound`.
    /// If only single track is specified (`inbound`, `outbound`), `channels` configuration
    /// is ignored and it will be recorded as mono (single channel).
    /// </summary>
    public ApiEnum<string, ActionBridgeParamsRecordTrack>? RecordTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionBridgeParamsRecordTrack>>(
                "record_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_track", value);
        }
    }

    /// <summary>
    /// When set to `trim-silence`, silence will be removed from the beginning and
    /// end of the recording.
    /// </summary>
    public ApiEnum<string, ActionBridgeParamsRecordTrim>? RecordTrim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionBridgeParamsRecordTrim>>(
                "record_trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_trim", value);
        }
    }

    /// <summary>
    /// Specifies which country ringtone to play when `play_ringtone` is set to `true`.
    /// If not set, the US ringtone will be played.
    /// </summary>
    public ApiEnum<string, Ringtone>? Ringtone {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Ringtone>>(
                "ringtone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ringtone", value);
        }
    }

    /// <summary>
    /// The additional parameter that will be passed to the video conference. It
    /// is a text field and the user can decide how to use it. For example, you can
    /// set the participant name or pass JSON text. It can be used only with video_room_id parameter.
    /// </summary>
    public string? VideoRoomContext {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "video_room_context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("video_room_context", value);
        }
    }

    /// <summary>
    /// The ID of the video room you want to bridge with, can't be used together with
    /// call_control_id parameter or queue parameter.
    /// </summary>
    public string? VideoRoomID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "video_room_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("video_room_id", value);
        }
    }

    public ActionBridgeParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionBridgeParams (ActionBridgeParams actionBridgeParams) : base(
        actionBridgeParams
    )
    {
        this.CallControlIDToBridge = actionBridgeParams.CallControlIDToBridge;

        this._rawBodyData = new(actionBridgeParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionBridgeParams (
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
    ActionBridgeParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlIDToBridge
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlIDToBridge = callControlIDToBridge;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionBridgeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlIDToBridge
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlIDToBridge
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlIDToBridge"] = JsonSerializer.SerializeToElement(this.CallControlIDToBridge),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionBridgeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlIDToBridge?.Equals(other.CallControlIDToBridge) ?? other.CallControlIDToBridge == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/bridge",
            EncodePathSegment(this.CallControlIDToBridge))
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
/// When enabled, DTMF tones are not passed to the call participant. The webhooks
/// containing the DTMF information will be sent.
/// </summary>
[JsonConverter(typeof(MuteDtmfConverter))]
public enum MuteDtmf
{
    None, Both, Self, Opposite
}

sealed class MuteDtmfConverter : JsonConverter<MuteDtmf>
{
    public override MuteDtmf Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>MuteDtmf.None,
            "both"=>MuteDtmf.Both,
            "self"=>MuteDtmf.Self,
            "opposite"=>MuteDtmf.Opposite,
            _ =>(MuteDtmf)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, MuteDtmf value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MuteDtmf.None=>"none",
            MuteDtmf.Both=>"both",
            MuteDtmf.Self=>"self",
            MuteDtmf.Opposite=>"opposite",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Start recording automatically after an event. Disabled by default.
/// </summary>
[JsonConverter(typeof(ActionBridgeParamsRecordConverter))]
public enum ActionBridgeParamsRecord
{
    RecordFromAnswer
}

sealed class ActionBridgeParamsRecordConverter : JsonConverter<ActionBridgeParamsRecord>
{
    public override ActionBridgeParamsRecord Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "record-from-answer"=>ActionBridgeParamsRecord.RecordFromAnswer,
            _ =>(ActionBridgeParamsRecord)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionBridgeParamsRecord value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionBridgeParamsRecord.RecordFromAnswer=>"record-from-answer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines which channel should be recorded ('single' or 'dual') when `record` is specified.
/// </summary>
[JsonConverter(typeof(ActionBridgeParamsRecordChannelsConverter))]
public enum ActionBridgeParamsRecordChannels
{
    Single, Dual
}

sealed class ActionBridgeParamsRecordChannelsConverter : JsonConverter<ActionBridgeParamsRecordChannels>
{
    public override ActionBridgeParamsRecordChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>ActionBridgeParamsRecordChannels.Single,
            "dual"=>ActionBridgeParamsRecordChannels.Dual,
            _ =>(ActionBridgeParamsRecordChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionBridgeParamsRecordChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionBridgeParamsRecordChannels.Single=>"single",
            ActionBridgeParamsRecordChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
/// </summary>
[JsonConverter(typeof(ActionBridgeParamsRecordFormatConverter))]
public enum ActionBridgeParamsRecordFormat
{
    Wav, Mp3
}

sealed class ActionBridgeParamsRecordFormatConverter : JsonConverter<ActionBridgeParamsRecordFormat>
{
    public override ActionBridgeParamsRecordFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>ActionBridgeParamsRecordFormat.Wav,
            "mp3"=>ActionBridgeParamsRecordFormat.Mp3,
            _ =>(ActionBridgeParamsRecordFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionBridgeParamsRecordFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionBridgeParamsRecordFormat.Wav=>"wav",
            ActionBridgeParamsRecordFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to be recorded. Can be either `both`, `inbound` or `outbound`.
/// If only single track is specified (`inbound`, `outbound`), `channels` configuration
/// is ignored and it will be recorded as mono (single channel).
/// </summary>
[JsonConverter(typeof(ActionBridgeParamsRecordTrackConverter))]
public enum ActionBridgeParamsRecordTrack
{
    Both, Inbound, Outbound
}

sealed class ActionBridgeParamsRecordTrackConverter : JsonConverter<ActionBridgeParamsRecordTrack>
{
    public override ActionBridgeParamsRecordTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>ActionBridgeParamsRecordTrack.Both,
            "inbound"=>ActionBridgeParamsRecordTrack.Inbound,
            "outbound"=>ActionBridgeParamsRecordTrack.Outbound,
            _ =>(ActionBridgeParamsRecordTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionBridgeParamsRecordTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionBridgeParamsRecordTrack.Both=>"both",
            ActionBridgeParamsRecordTrack.Inbound=>"inbound",
            ActionBridgeParamsRecordTrack.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// When set to `trim-silence`, silence will be removed from the beginning and end
/// of the recording.
/// </summary>
[JsonConverter(typeof(ActionBridgeParamsRecordTrimConverter))]
public enum ActionBridgeParamsRecordTrim
{
    TrimSilence
}

sealed class ActionBridgeParamsRecordTrimConverter : JsonConverter<ActionBridgeParamsRecordTrim>
{
    public override ActionBridgeParamsRecordTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>ActionBridgeParamsRecordTrim.TrimSilence,
            _ =>(ActionBridgeParamsRecordTrim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionBridgeParamsRecordTrim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionBridgeParamsRecordTrim.TrimSilence=>"trim-silence",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Specifies which country ringtone to play when `play_ringtone` is set to `true`.
/// If not set, the US ringtone will be played.
/// </summary>
[JsonConverter(typeof(RingtoneConverter))]
public enum Ringtone
{
    At,
    Au,
    Be,
    Bg,
    Br,
    Ch,
    Cl,
    Cn,
    Cz,
    De,
    Dk,
    Ee,
    Es,
    Fi,
    Fr,
    Gr,
    Hu,
    Il,
    In,
    It,
    Jp,
    Lt,
    Mx,
    My,
    Nl,
    No,
    Nz,
    Ph,
    Pl,
    Pt,
    Ru,
    Se,
    Sg,
    Th,
    Tw,
    Uk,
    UsOld,
    Us,
    Ve,
    Za
}

sealed class RingtoneConverter : JsonConverter<Ringtone>
{
    public override Ringtone Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "at"=>Ringtone.At,
            "au"=>Ringtone.Au,
            "be"=>Ringtone.Be,
            "bg"=>Ringtone.Bg,
            "br"=>Ringtone.Br,
            "ch"=>Ringtone.Ch,
            "cl"=>Ringtone.Cl,
            "cn"=>Ringtone.Cn,
            "cz"=>Ringtone.Cz,
            "de"=>Ringtone.De,
            "dk"=>Ringtone.Dk,
            "ee"=>Ringtone.Ee,
            "es"=>Ringtone.Es,
            "fi"=>Ringtone.Fi,
            "fr"=>Ringtone.Fr,
            "gr"=>Ringtone.Gr,
            "hu"=>Ringtone.Hu,
            "il"=>Ringtone.Il,
            "in"=>Ringtone.In,
            "it"=>Ringtone.It,
            "jp"=>Ringtone.Jp,
            "lt"=>Ringtone.Lt,
            "mx"=>Ringtone.Mx,
            "my"=>Ringtone.My,
            "nl"=>Ringtone.Nl,
            "no"=>Ringtone.No,
            "nz"=>Ringtone.Nz,
            "ph"=>Ringtone.Ph,
            "pl"=>Ringtone.Pl,
            "pt"=>Ringtone.Pt,
            "ru"=>Ringtone.Ru,
            "se"=>Ringtone.Se,
            "sg"=>Ringtone.Sg,
            "th"=>Ringtone.Th,
            "tw"=>Ringtone.Tw,
            "uk"=>Ringtone.Uk,
            "us-old"=>Ringtone.UsOld,
            "us"=>Ringtone.Us,
            "ve"=>Ringtone.Ve,
            "za"=>Ringtone.Za,
            _ =>(Ringtone)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Ringtone value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Ringtone.At=>"at",
            Ringtone.Au=>"au",
            Ringtone.Be=>"be",
            Ringtone.Bg=>"bg",
            Ringtone.Br=>"br",
            Ringtone.Ch=>"ch",
            Ringtone.Cl=>"cl",
            Ringtone.Cn=>"cn",
            Ringtone.Cz=>"cz",
            Ringtone.De=>"de",
            Ringtone.Dk=>"dk",
            Ringtone.Ee=>"ee",
            Ringtone.Es=>"es",
            Ringtone.Fi=>"fi",
            Ringtone.Fr=>"fr",
            Ringtone.Gr=>"gr",
            Ringtone.Hu=>"hu",
            Ringtone.Il=>"il",
            Ringtone.In=>"in",
            Ringtone.It=>"it",
            Ringtone.Jp=>"jp",
            Ringtone.Lt=>"lt",
            Ringtone.Mx=>"mx",
            Ringtone.My=>"my",
            Ringtone.Nl=>"nl",
            Ringtone.No=>"no",
            Ringtone.Nz=>"nz",
            Ringtone.Ph=>"ph",
            Ringtone.Pl=>"pl",
            Ringtone.Pt=>"pt",
            Ringtone.Ru=>"ru",
            Ringtone.Se=>"se",
            Ringtone.Sg=>"sg",
            Ringtone.Th=>"th",
            Ringtone.Tw=>"tw",
            Ringtone.Uk=>"uk",
            Ringtone.UsOld=>"us-old",
            Ringtone.Us=>"us",
            Ringtone.Ve=>"ve",
            Ringtone.Za=>"za",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}