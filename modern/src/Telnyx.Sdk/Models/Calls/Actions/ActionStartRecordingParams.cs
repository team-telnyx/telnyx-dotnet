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
/// Start recording the call. Recording will stop on call hang-up, or can be initiated
/// via the Stop Recording command.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.recording.saved` - `call.recording.transcription.saved` - `call.recording.error`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartRecordingParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// When `dual`, final audio file will be stereo recorded with the first leg on
    /// channel A, and the rest on channel B.
    /// </summary>
    public required ApiEnum<string, Channels> Channels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Channels>>(
                "channels"
            );
        }
        init { this._rawBodyData.Set("channels", value); }
    }

    /// <summary>
    /// The audio file format used when storing the call recording. Can be either
    /// `mp3` or `wav`.
    /// </summary>
    public required ApiEnum<string, Format> Format {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init { this._rawBodyData.Set("format", value); }
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
    /// The custom recording file name to be used instead of the default `call_leg_id`.
    /// Telnyx will still add a Unix timestamp suffix.
    /// </summary>
    public string? CustomFileName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "custom_file_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("custom_file_name", value);
        }
    }

    /// <summary>
    /// Defines the maximum length for the recording in seconds. The minimum value
    /// is 0. The maximum value is 14400. The default value is 0 (infinite)
    /// </summary>
    public int? MaxLength {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "max_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_length", value);
        }
    }

    /// <summary>
    /// If enabled, a beep sound will be played at the start of a recording.
    /// </summary>
    public bool? PlayBeep {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "play_beep"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("play_beep", value);
        }
    }

    /// <summary>
    /// The audio track to be recorded. Can be either `both`, `inbound` or `outbound`.
    /// If only single track is specified (`inbound`, `outbound`), `channels` configuration
    /// is ignored and it will be recorded as mono (single channel).
    /// </summary>
    public ApiEnum<string, RecordingTrack>? RecordingTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordingTrack>>(
                "recording_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("recording_track", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// Please note that call transcription is used to detect silence and the related
    /// charge will be applied. The minimum value is 0. The default value is 0 (infinite)
    /// </summary>
    public int? TimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout_secs", value);
        }
    }

    /// <summary>
    /// Enable post recording transcription. The default value is false.
    /// </summary>
    public bool? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription", value);
        }
    }

    /// <summary>
    /// Engine to use for speech recognition. `A` - `Google`, `B` - `Telnyx`, `deepgram/nova-3`
    /// - `Deepgram Nova-3`. Note: `deepgram/nova-3` supports only `en` and `en-{Region}` languages.
    /// </summary>
    public ApiEnum<string, ActionStartRecordingParamsTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionStartRecordingParamsTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_engine", value);
        }
    }

    /// <summary>
    /// Language code for transcription. Note: Not all languages are supported by
    /// all transcription engines (google, telnyx, deepgram). See engine-specific
    /// documentation for supported values.
    /// </summary>
    public ApiEnum<string, TranscriptionLanguage>? TranscriptionLanguage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TranscriptionLanguage>>(
                "transcription_language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_language", value);
        }
    }

    /// <summary>
    /// Defines maximum number of speakers in the conversation. Applies to `google`
    /// engine only.
    /// </summary>
    public int? TranscriptionMaxSpeakerCount {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "transcription_max_speaker_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_max_speaker_count", value);
        }
    }

    /// <summary>
    /// Defines minimum number of speakers in the conversation. Applies to `google`
    /// engine only.
    /// </summary>
    public int? TranscriptionMinSpeakerCount {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "transcription_min_speaker_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_min_speaker_count", value);
        }
    }

    /// <summary>
    /// Enables profanity_filter. Applies to `google` engine only.
    /// </summary>
    public bool? TranscriptionProfanityFilter {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "transcription_profanity_filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_profanity_filter", value);
        }
    }

    /// <summary>
    /// Enables speaker diarization. Applies to `google` engine only.
    /// </summary>
    public bool? TranscriptionSpeakerDiarization {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "transcription_speaker_diarization"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_speaker_diarization", value);
        }
    }

    /// <summary>
    /// When set to `trim-silence`, silence will be removed from the beginning and
    /// end of the recording.
    /// </summary>
    public ApiEnum<string, Trim>? Trim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Trim>>(
                "trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("trim", value);
        }
    }

    public ActionStartRecordingParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartRecordingParams (
        ActionStartRecordingParams actionStartRecordingParams
    ) : base(actionStartRecordingParams)
    {
        this.CallControlID = actionStartRecordingParams.CallControlID;

        this._rawBodyData = new(actionStartRecordingParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartRecordingParams (
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
    ActionStartRecordingParams (
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
    public static ActionStartRecordingParams FromRawUnchecked(
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

    public virtual bool Equals(ActionStartRecordingParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/record_start",
            EncodePathSegment(this.CallControlID))
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
/// When `dual`, final audio file will be stereo recorded with the first leg on channel
/// A, and the rest on channel B.
/// </summary>
[JsonConverter(typeof(ChannelsConverter))]
public enum Channels
{
    Single, Dual
}

sealed class ChannelsConverter : JsonConverter<Channels>
{
    public override Channels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>Channels.Single, "dual"=>Channels.Dual, _ =>(Channels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Channels value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Channels.Single=>"single",
            Channels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio file format used when storing the call recording. Can be either `mp3`
/// or `wav`.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Wav, Mp3
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "wav"=>Format.Wav, "mp3"=>Format.Mp3, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Wav=>"wav",
            Format.Mp3=>"mp3",
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
[JsonConverter(typeof(RecordingTrackConverter))]
public enum RecordingTrack
{
    Both, Inbound, Outbound
}

sealed class RecordingTrackConverter : JsonConverter<RecordingTrack>
{
    public override RecordingTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>RecordingTrack.Both,
            "inbound"=>RecordingTrack.Inbound,
            "outbound"=>RecordingTrack.Outbound,
            _ =>(RecordingTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingTrack.Both=>"both",
            RecordingTrack.Inbound=>"inbound",
            RecordingTrack.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Engine to use for speech recognition. `A` - `Google`, `B` - `Telnyx`, `deepgram/nova-3`
/// - `Deepgram Nova-3`. Note: `deepgram/nova-3` supports only `en` and `en-{Region}` languages.
/// </summary>
[JsonConverter(typeof(ActionStartRecordingParamsTranscriptionEngineConverter))]
public enum ActionStartRecordingParamsTranscriptionEngine
{
    A, B, DeepgramNova3
}

sealed class ActionStartRecordingParamsTranscriptionEngineConverter : JsonConverter<ActionStartRecordingParamsTranscriptionEngine>
{
    public override ActionStartRecordingParamsTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "A"=>ActionStartRecordingParamsTranscriptionEngine.A,
            "B"=>ActionStartRecordingParamsTranscriptionEngine.B,
            "deepgram/nova-3"=>ActionStartRecordingParamsTranscriptionEngine.DeepgramNova3,
            _ =>(ActionStartRecordingParamsTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionStartRecordingParamsTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionStartRecordingParamsTranscriptionEngine.A=>"A",
            ActionStartRecordingParamsTranscriptionEngine.B=>"B",
            ActionStartRecordingParamsTranscriptionEngine.DeepgramNova3=>"deepgram/nova-3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Language code for transcription. Note: Not all languages are supported by all
/// transcription engines (google, telnyx, deepgram). See engine-specific documentation
/// for supported values.
/// </summary>
[JsonConverter(typeof(TranscriptionLanguageConverter))]
public enum TranscriptionLanguage
{
    Af,
    AfZa,
    Am,
    AmEt,
    Ar,
    ArAe,
    ArBh,
    ArDz,
    ArEg,
    ArIl,
    ArIq,
    ArJo,
    ArKw,
    ArLb,
    ArMa,
    ArMr,
    ArOm,
    ArPs,
    ArQa,
    ArSa,
    ArTn,
    ArYe,
    As,
    AutoDetect,
    Az,
    AzAz,
    Ba,
    Be,
    Bg,
    BgBg,
    Bn,
    BnBd,
    BnIn,
    Bo,
    Br,
    Bs,
    BsBa,
    Ca,
    CaEs,
    Cs,
    CsCz,
    Cy,
    Da,
    DaDk,
    De,
    DeAt,
    DeCh,
    DeDe,
    El,
    ElGr,
    En,
    EnAu,
    EnCa,
    EnGB,
    EnGh,
    EnHk,
    EnIe,
    EnIn,
    EnKe,
    EnNg,
    EnNz,
    EnPh,
    EnPk,
    EnSg,
    EnTz,
    EnUs,
    EnZa,
    Es,
    Es419,
    EsAr,
    EsBo,
    EsCl,
    EsCo,
    EsCr,
    EsDo,
    EsEc,
    EsEs,
    EsGt,
    EsHn,
    EsMx,
    EsNi,
    EsPa,
    EsPe,
    EsPr,
    EsPy,
    EsSv,
    EsUs,
    EsUy,
    EsVe,
    Et,
    EtEe,
    Eu,
    EuEs,
    Fa,
    FaIr,
    Fi,
    FiFi,
    FilPh,
    Fo,
    Fr,
    FrBe,
    FrCa,
    FrCh,
    FrFr,
    Gl,
    GlEs,
    Gu,
    GuIn,
    Ha,
    Haw,
    He,
    Hi,
    HiIn,
    Hr,
    HrHr,
    Ht,
    Hu,
    HuHu,
    Hy,
    HyAm,
    ID,
    IDID,
    Is,
    IsIs,
    It,
    ItCh,
    ItIt,
    IwIl,
    Ja,
    JaJp,
    JvID,
    Jw,
    Ka,
    KaGe,
    Kk,
    KkKz,
    Km,
    KmKh,
    Kn,
    KnIn,
    Ko,
    KoKr,
    La,
    Lb,
    Ln,
    Lo,
    LoLa,
    Lt,
    LtLt,
    Lv,
    LvLv,
    Mg,
    Mi,
    Mk,
    MkMk,
    Ml,
    MlIn,
    Mn,
    MnMn,
    Mr,
    MrIn,
    Ms,
    MsMy,
    Mt,
    My,
    MyMm,
    Ne,
    NeNp,
    Nl,
    NlBe,
    NlNl,
    Nn,
    No,
    NoNo,
    Oc,
    Pa,
    PaGuruIn,
    Pl,
    PlPl,
    Ps,
    Pt,
    PtBr,
    PtPt,
    Ro,
    RoRo,
    Ru,
    RuRu,
    RwRw,
    Sa,
    Sd,
    Si,
    SiLk,
    Sk,
    SkSk,
    Sl,
    SlSi,
    Sn,
    So,
    Sq,
    SqAl,
    Sr,
    SrRs,
    SSLatnZa,
    StZa,
    Su,
    SuID,
    Sv,
    SvSe,
    Sw,
    SwKe,
    SwTz,
    Ta,
    TaIn,
    TaLk,
    TaMy,
    TaSg,
    Te,
    TeIn,
    Tg,
    Th,
    ThTh,
    Tk,
    Tl,
    TnLatnZa,
    Tr,
    TrTr,
    TsZa,
    Tt,
    Uk,
    UkUa,
    Ur,
    UrIn,
    UrPk,
    Uz,
    UzUz,
    VeZa,
    Vi,
    ViVn,
    XhZa,
    Yi,
    Yo,
    YueHantHk,
    Zh,
    ZhTw,
    ZuZa
}

sealed class TranscriptionLanguageConverter : JsonConverter<TranscriptionLanguage>
{
    public override TranscriptionLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "af"=>TranscriptionLanguage.Af,
            "af-ZA"=>TranscriptionLanguage.AfZa,
            "am"=>TranscriptionLanguage.Am,
            "am-ET"=>TranscriptionLanguage.AmEt,
            "ar"=>TranscriptionLanguage.Ar,
            "ar-AE"=>TranscriptionLanguage.ArAe,
            "ar-BH"=>TranscriptionLanguage.ArBh,
            "ar-DZ"=>TranscriptionLanguage.ArDz,
            "ar-EG"=>TranscriptionLanguage.ArEg,
            "ar-IL"=>TranscriptionLanguage.ArIl,
            "ar-IQ"=>TranscriptionLanguage.ArIq,
            "ar-JO"=>TranscriptionLanguage.ArJo,
            "ar-KW"=>TranscriptionLanguage.ArKw,
            "ar-LB"=>TranscriptionLanguage.ArLb,
            "ar-MA"=>TranscriptionLanguage.ArMa,
            "ar-MR"=>TranscriptionLanguage.ArMr,
            "ar-OM"=>TranscriptionLanguage.ArOm,
            "ar-PS"=>TranscriptionLanguage.ArPs,
            "ar-QA"=>TranscriptionLanguage.ArQa,
            "ar-SA"=>TranscriptionLanguage.ArSa,
            "ar-TN"=>TranscriptionLanguage.ArTn,
            "ar-YE"=>TranscriptionLanguage.ArYe,
            "as"=>TranscriptionLanguage.As,
            "auto_detect"=>TranscriptionLanguage.AutoDetect,
            "az"=>TranscriptionLanguage.Az,
            "az-AZ"=>TranscriptionLanguage.AzAz,
            "ba"=>TranscriptionLanguage.Ba,
            "be"=>TranscriptionLanguage.Be,
            "bg"=>TranscriptionLanguage.Bg,
            "bg-BG"=>TranscriptionLanguage.BgBg,
            "bn"=>TranscriptionLanguage.Bn,
            "bn-BD"=>TranscriptionLanguage.BnBd,
            "bn-IN"=>TranscriptionLanguage.BnIn,
            "bo"=>TranscriptionLanguage.Bo,
            "br"=>TranscriptionLanguage.Br,
            "bs"=>TranscriptionLanguage.Bs,
            "bs-BA"=>TranscriptionLanguage.BsBa,
            "ca"=>TranscriptionLanguage.Ca,
            "ca-ES"=>TranscriptionLanguage.CaEs,
            "cs"=>TranscriptionLanguage.Cs,
            "cs-CZ"=>TranscriptionLanguage.CsCz,
            "cy"=>TranscriptionLanguage.Cy,
            "da"=>TranscriptionLanguage.Da,
            "da-DK"=>TranscriptionLanguage.DaDk,
            "de"=>TranscriptionLanguage.De,
            "de-AT"=>TranscriptionLanguage.DeAt,
            "de-CH"=>TranscriptionLanguage.DeCh,
            "de-DE"=>TranscriptionLanguage.DeDe,
            "el"=>TranscriptionLanguage.El,
            "el-GR"=>TranscriptionLanguage.ElGr,
            "en"=>TranscriptionLanguage.En,
            "en-AU"=>TranscriptionLanguage.EnAu,
            "en-CA"=>TranscriptionLanguage.EnCa,
            "en-GB"=>TranscriptionLanguage.EnGB,
            "en-GH"=>TranscriptionLanguage.EnGh,
            "en-HK"=>TranscriptionLanguage.EnHk,
            "en-IE"=>TranscriptionLanguage.EnIe,
            "en-IN"=>TranscriptionLanguage.EnIn,
            "en-KE"=>TranscriptionLanguage.EnKe,
            "en-NG"=>TranscriptionLanguage.EnNg,
            "en-NZ"=>TranscriptionLanguage.EnNz,
            "en-PH"=>TranscriptionLanguage.EnPh,
            "en-PK"=>TranscriptionLanguage.EnPk,
            "en-SG"=>TranscriptionLanguage.EnSg,
            "en-TZ"=>TranscriptionLanguage.EnTz,
            "en-US"=>TranscriptionLanguage.EnUs,
            "en-ZA"=>TranscriptionLanguage.EnZa,
            "es"=>TranscriptionLanguage.Es,
            "es-419"=>TranscriptionLanguage.Es419,
            "es-AR"=>TranscriptionLanguage.EsAr,
            "es-BO"=>TranscriptionLanguage.EsBo,
            "es-CL"=>TranscriptionLanguage.EsCl,
            "es-CO"=>TranscriptionLanguage.EsCo,
            "es-CR"=>TranscriptionLanguage.EsCr,
            "es-DO"=>TranscriptionLanguage.EsDo,
            "es-EC"=>TranscriptionLanguage.EsEc,
            "es-ES"=>TranscriptionLanguage.EsEs,
            "es-GT"=>TranscriptionLanguage.EsGt,
            "es-HN"=>TranscriptionLanguage.EsHn,
            "es-MX"=>TranscriptionLanguage.EsMx,
            "es-NI"=>TranscriptionLanguage.EsNi,
            "es-PA"=>TranscriptionLanguage.EsPa,
            "es-PE"=>TranscriptionLanguage.EsPe,
            "es-PR"=>TranscriptionLanguage.EsPr,
            "es-PY"=>TranscriptionLanguage.EsPy,
            "es-SV"=>TranscriptionLanguage.EsSv,
            "es-US"=>TranscriptionLanguage.EsUs,
            "es-UY"=>TranscriptionLanguage.EsUy,
            "es-VE"=>TranscriptionLanguage.EsVe,
            "et"=>TranscriptionLanguage.Et,
            "et-EE"=>TranscriptionLanguage.EtEe,
            "eu"=>TranscriptionLanguage.Eu,
            "eu-ES"=>TranscriptionLanguage.EuEs,
            "fa"=>TranscriptionLanguage.Fa,
            "fa-IR"=>TranscriptionLanguage.FaIr,
            "fi"=>TranscriptionLanguage.Fi,
            "fi-FI"=>TranscriptionLanguage.FiFi,
            "fil-PH"=>TranscriptionLanguage.FilPh,
            "fo"=>TranscriptionLanguage.Fo,
            "fr"=>TranscriptionLanguage.Fr,
            "fr-BE"=>TranscriptionLanguage.FrBe,
            "fr-CA"=>TranscriptionLanguage.FrCa,
            "fr-CH"=>TranscriptionLanguage.FrCh,
            "fr-FR"=>TranscriptionLanguage.FrFr,
            "gl"=>TranscriptionLanguage.Gl,
            "gl-ES"=>TranscriptionLanguage.GlEs,
            "gu"=>TranscriptionLanguage.Gu,
            "gu-IN"=>TranscriptionLanguage.GuIn,
            "ha"=>TranscriptionLanguage.Ha,
            "haw"=>TranscriptionLanguage.Haw,
            "he"=>TranscriptionLanguage.He,
            "hi"=>TranscriptionLanguage.Hi,
            "hi-IN"=>TranscriptionLanguage.HiIn,
            "hr"=>TranscriptionLanguage.Hr,
            "hr-HR"=>TranscriptionLanguage.HrHr,
            "ht"=>TranscriptionLanguage.Ht,
            "hu"=>TranscriptionLanguage.Hu,
            "hu-HU"=>TranscriptionLanguage.HuHu,
            "hy"=>TranscriptionLanguage.Hy,
            "hy-AM"=>TranscriptionLanguage.HyAm,
            "id"=>TranscriptionLanguage.ID,
            "id-ID"=>TranscriptionLanguage.IDID,
            "is"=>TranscriptionLanguage.Is,
            "is-IS"=>TranscriptionLanguage.IsIs,
            "it"=>TranscriptionLanguage.It,
            "it-CH"=>TranscriptionLanguage.ItCh,
            "it-IT"=>TranscriptionLanguage.ItIt,
            "iw-IL"=>TranscriptionLanguage.IwIl,
            "ja"=>TranscriptionLanguage.Ja,
            "ja-JP"=>TranscriptionLanguage.JaJp,
            "jv-ID"=>TranscriptionLanguage.JvID,
            "jw"=>TranscriptionLanguage.Jw,
            "ka"=>TranscriptionLanguage.Ka,
            "ka-GE"=>TranscriptionLanguage.KaGe,
            "kk"=>TranscriptionLanguage.Kk,
            "kk-KZ"=>TranscriptionLanguage.KkKz,
            "km"=>TranscriptionLanguage.Km,
            "km-KH"=>TranscriptionLanguage.KmKh,
            "kn"=>TranscriptionLanguage.Kn,
            "kn-IN"=>TranscriptionLanguage.KnIn,
            "ko"=>TranscriptionLanguage.Ko,
            "ko-KR"=>TranscriptionLanguage.KoKr,
            "la"=>TranscriptionLanguage.La,
            "lb"=>TranscriptionLanguage.Lb,
            "ln"=>TranscriptionLanguage.Ln,
            "lo"=>TranscriptionLanguage.Lo,
            "lo-LA"=>TranscriptionLanguage.LoLa,
            "lt"=>TranscriptionLanguage.Lt,
            "lt-LT"=>TranscriptionLanguage.LtLt,
            "lv"=>TranscriptionLanguage.Lv,
            "lv-LV"=>TranscriptionLanguage.LvLv,
            "mg"=>TranscriptionLanguage.Mg,
            "mi"=>TranscriptionLanguage.Mi,
            "mk"=>TranscriptionLanguage.Mk,
            "mk-MK"=>TranscriptionLanguage.MkMk,
            "ml"=>TranscriptionLanguage.Ml,
            "ml-IN"=>TranscriptionLanguage.MlIn,
            "mn"=>TranscriptionLanguage.Mn,
            "mn-MN"=>TranscriptionLanguage.MnMn,
            "mr"=>TranscriptionLanguage.Mr,
            "mr-IN"=>TranscriptionLanguage.MrIn,
            "ms"=>TranscriptionLanguage.Ms,
            "ms-MY"=>TranscriptionLanguage.MsMy,
            "mt"=>TranscriptionLanguage.Mt,
            "my"=>TranscriptionLanguage.My,
            "my-MM"=>TranscriptionLanguage.MyMm,
            "ne"=>TranscriptionLanguage.Ne,
            "ne-NP"=>TranscriptionLanguage.NeNp,
            "nl"=>TranscriptionLanguage.Nl,
            "nl-BE"=>TranscriptionLanguage.NlBe,
            "nl-NL"=>TranscriptionLanguage.NlNl,
            "nn"=>TranscriptionLanguage.Nn,
            "no"=>TranscriptionLanguage.No,
            "no-NO"=>TranscriptionLanguage.NoNo,
            "oc"=>TranscriptionLanguage.Oc,
            "pa"=>TranscriptionLanguage.Pa,
            "pa-Guru-IN"=>TranscriptionLanguage.PaGuruIn,
            "pl"=>TranscriptionLanguage.Pl,
            "pl-PL"=>TranscriptionLanguage.PlPl,
            "ps"=>TranscriptionLanguage.Ps,
            "pt"=>TranscriptionLanguage.Pt,
            "pt-BR"=>TranscriptionLanguage.PtBr,
            "pt-PT"=>TranscriptionLanguage.PtPt,
            "ro"=>TranscriptionLanguage.Ro,
            "ro-RO"=>TranscriptionLanguage.RoRo,
            "ru"=>TranscriptionLanguage.Ru,
            "ru-RU"=>TranscriptionLanguage.RuRu,
            "rw-RW"=>TranscriptionLanguage.RwRw,
            "sa"=>TranscriptionLanguage.Sa,
            "sd"=>TranscriptionLanguage.Sd,
            "si"=>TranscriptionLanguage.Si,
            "si-LK"=>TranscriptionLanguage.SiLk,
            "sk"=>TranscriptionLanguage.Sk,
            "sk-SK"=>TranscriptionLanguage.SkSk,
            "sl"=>TranscriptionLanguage.Sl,
            "sl-SI"=>TranscriptionLanguage.SlSi,
            "sn"=>TranscriptionLanguage.Sn,
            "so"=>TranscriptionLanguage.So,
            "sq"=>TranscriptionLanguage.Sq,
            "sq-AL"=>TranscriptionLanguage.SqAl,
            "sr"=>TranscriptionLanguage.Sr,
            "sr-RS"=>TranscriptionLanguage.SrRs,
            "ss-latn-za"=>TranscriptionLanguage.SSLatnZa,
            "st-ZA"=>TranscriptionLanguage.StZa,
            "su"=>TranscriptionLanguage.Su,
            "su-ID"=>TranscriptionLanguage.SuID,
            "sv"=>TranscriptionLanguage.Sv,
            "sv-SE"=>TranscriptionLanguage.SvSe,
            "sw"=>TranscriptionLanguage.Sw,
            "sw-KE"=>TranscriptionLanguage.SwKe,
            "sw-TZ"=>TranscriptionLanguage.SwTz,
            "ta"=>TranscriptionLanguage.Ta,
            "ta-IN"=>TranscriptionLanguage.TaIn,
            "ta-LK"=>TranscriptionLanguage.TaLk,
            "ta-MY"=>TranscriptionLanguage.TaMy,
            "ta-SG"=>TranscriptionLanguage.TaSg,
            "te"=>TranscriptionLanguage.Te,
            "te-IN"=>TranscriptionLanguage.TeIn,
            "tg"=>TranscriptionLanguage.Tg,
            "th"=>TranscriptionLanguage.Th,
            "th-TH"=>TranscriptionLanguage.ThTh,
            "tk"=>TranscriptionLanguage.Tk,
            "tl"=>TranscriptionLanguage.Tl,
            "tn-latn-za"=>TranscriptionLanguage.TnLatnZa,
            "tr"=>TranscriptionLanguage.Tr,
            "tr-TR"=>TranscriptionLanguage.TrTr,
            "ts-ZA"=>TranscriptionLanguage.TsZa,
            "tt"=>TranscriptionLanguage.Tt,
            "uk"=>TranscriptionLanguage.Uk,
            "uk-UA"=>TranscriptionLanguage.UkUa,
            "ur"=>TranscriptionLanguage.Ur,
            "ur-IN"=>TranscriptionLanguage.UrIn,
            "ur-PK"=>TranscriptionLanguage.UrPk,
            "uz"=>TranscriptionLanguage.Uz,
            "uz-UZ"=>TranscriptionLanguage.UzUz,
            "ve-ZA"=>TranscriptionLanguage.VeZa,
            "vi"=>TranscriptionLanguage.Vi,
            "vi-VN"=>TranscriptionLanguage.ViVn,
            "xh-ZA"=>TranscriptionLanguage.XhZa,
            "yi"=>TranscriptionLanguage.Yi,
            "yo"=>TranscriptionLanguage.Yo,
            "yue-Hant-HK"=>TranscriptionLanguage.YueHantHk,
            "zh"=>TranscriptionLanguage.Zh,
            "zh-TW"=>TranscriptionLanguage.ZhTw,
            "zu-ZA"=>TranscriptionLanguage.ZuZa,
            _ =>(TranscriptionLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionLanguage.Af=>"af",
            TranscriptionLanguage.AfZa=>"af-ZA",
            TranscriptionLanguage.Am=>"am",
            TranscriptionLanguage.AmEt=>"am-ET",
            TranscriptionLanguage.Ar=>"ar",
            TranscriptionLanguage.ArAe=>"ar-AE",
            TranscriptionLanguage.ArBh=>"ar-BH",
            TranscriptionLanguage.ArDz=>"ar-DZ",
            TranscriptionLanguage.ArEg=>"ar-EG",
            TranscriptionLanguage.ArIl=>"ar-IL",
            TranscriptionLanguage.ArIq=>"ar-IQ",
            TranscriptionLanguage.ArJo=>"ar-JO",
            TranscriptionLanguage.ArKw=>"ar-KW",
            TranscriptionLanguage.ArLb=>"ar-LB",
            TranscriptionLanguage.ArMa=>"ar-MA",
            TranscriptionLanguage.ArMr=>"ar-MR",
            TranscriptionLanguage.ArOm=>"ar-OM",
            TranscriptionLanguage.ArPs=>"ar-PS",
            TranscriptionLanguage.ArQa=>"ar-QA",
            TranscriptionLanguage.ArSa=>"ar-SA",
            TranscriptionLanguage.ArTn=>"ar-TN",
            TranscriptionLanguage.ArYe=>"ar-YE",
            TranscriptionLanguage.As=>"as",
            TranscriptionLanguage.AutoDetect=>"auto_detect",
            TranscriptionLanguage.Az=>"az",
            TranscriptionLanguage.AzAz=>"az-AZ",
            TranscriptionLanguage.Ba=>"ba",
            TranscriptionLanguage.Be=>"be",
            TranscriptionLanguage.Bg=>"bg",
            TranscriptionLanguage.BgBg=>"bg-BG",
            TranscriptionLanguage.Bn=>"bn",
            TranscriptionLanguage.BnBd=>"bn-BD",
            TranscriptionLanguage.BnIn=>"bn-IN",
            TranscriptionLanguage.Bo=>"bo",
            TranscriptionLanguage.Br=>"br",
            TranscriptionLanguage.Bs=>"bs",
            TranscriptionLanguage.BsBa=>"bs-BA",
            TranscriptionLanguage.Ca=>"ca",
            TranscriptionLanguage.CaEs=>"ca-ES",
            TranscriptionLanguage.Cs=>"cs",
            TranscriptionLanguage.CsCz=>"cs-CZ",
            TranscriptionLanguage.Cy=>"cy",
            TranscriptionLanguage.Da=>"da",
            TranscriptionLanguage.DaDk=>"da-DK",
            TranscriptionLanguage.De=>"de",
            TranscriptionLanguage.DeAt=>"de-AT",
            TranscriptionLanguage.DeCh=>"de-CH",
            TranscriptionLanguage.DeDe=>"de-DE",
            TranscriptionLanguage.El=>"el",
            TranscriptionLanguage.ElGr=>"el-GR",
            TranscriptionLanguage.En=>"en",
            TranscriptionLanguage.EnAu=>"en-AU",
            TranscriptionLanguage.EnCa=>"en-CA",
            TranscriptionLanguage.EnGB=>"en-GB",
            TranscriptionLanguage.EnGh=>"en-GH",
            TranscriptionLanguage.EnHk=>"en-HK",
            TranscriptionLanguage.EnIe=>"en-IE",
            TranscriptionLanguage.EnIn=>"en-IN",
            TranscriptionLanguage.EnKe=>"en-KE",
            TranscriptionLanguage.EnNg=>"en-NG",
            TranscriptionLanguage.EnNz=>"en-NZ",
            TranscriptionLanguage.EnPh=>"en-PH",
            TranscriptionLanguage.EnPk=>"en-PK",
            TranscriptionLanguage.EnSg=>"en-SG",
            TranscriptionLanguage.EnTz=>"en-TZ",
            TranscriptionLanguage.EnUs=>"en-US",
            TranscriptionLanguage.EnZa=>"en-ZA",
            TranscriptionLanguage.Es=>"es",
            TranscriptionLanguage.Es419=>"es-419",
            TranscriptionLanguage.EsAr=>"es-AR",
            TranscriptionLanguage.EsBo=>"es-BO",
            TranscriptionLanguage.EsCl=>"es-CL",
            TranscriptionLanguage.EsCo=>"es-CO",
            TranscriptionLanguage.EsCr=>"es-CR",
            TranscriptionLanguage.EsDo=>"es-DO",
            TranscriptionLanguage.EsEc=>"es-EC",
            TranscriptionLanguage.EsEs=>"es-ES",
            TranscriptionLanguage.EsGt=>"es-GT",
            TranscriptionLanguage.EsHn=>"es-HN",
            TranscriptionLanguage.EsMx=>"es-MX",
            TranscriptionLanguage.EsNi=>"es-NI",
            TranscriptionLanguage.EsPa=>"es-PA",
            TranscriptionLanguage.EsPe=>"es-PE",
            TranscriptionLanguage.EsPr=>"es-PR",
            TranscriptionLanguage.EsPy=>"es-PY",
            TranscriptionLanguage.EsSv=>"es-SV",
            TranscriptionLanguage.EsUs=>"es-US",
            TranscriptionLanguage.EsUy=>"es-UY",
            TranscriptionLanguage.EsVe=>"es-VE",
            TranscriptionLanguage.Et=>"et",
            TranscriptionLanguage.EtEe=>"et-EE",
            TranscriptionLanguage.Eu=>"eu",
            TranscriptionLanguage.EuEs=>"eu-ES",
            TranscriptionLanguage.Fa=>"fa",
            TranscriptionLanguage.FaIr=>"fa-IR",
            TranscriptionLanguage.Fi=>"fi",
            TranscriptionLanguage.FiFi=>"fi-FI",
            TranscriptionLanguage.FilPh=>"fil-PH",
            TranscriptionLanguage.Fo=>"fo",
            TranscriptionLanguage.Fr=>"fr",
            TranscriptionLanguage.FrBe=>"fr-BE",
            TranscriptionLanguage.FrCa=>"fr-CA",
            TranscriptionLanguage.FrCh=>"fr-CH",
            TranscriptionLanguage.FrFr=>"fr-FR",
            TranscriptionLanguage.Gl=>"gl",
            TranscriptionLanguage.GlEs=>"gl-ES",
            TranscriptionLanguage.Gu=>"gu",
            TranscriptionLanguage.GuIn=>"gu-IN",
            TranscriptionLanguage.Ha=>"ha",
            TranscriptionLanguage.Haw=>"haw",
            TranscriptionLanguage.He=>"he",
            TranscriptionLanguage.Hi=>"hi",
            TranscriptionLanguage.HiIn=>"hi-IN",
            TranscriptionLanguage.Hr=>"hr",
            TranscriptionLanguage.HrHr=>"hr-HR",
            TranscriptionLanguage.Ht=>"ht",
            TranscriptionLanguage.Hu=>"hu",
            TranscriptionLanguage.HuHu=>"hu-HU",
            TranscriptionLanguage.Hy=>"hy",
            TranscriptionLanguage.HyAm=>"hy-AM",
            TranscriptionLanguage.ID=>"id",
            TranscriptionLanguage.IDID=>"id-ID",
            TranscriptionLanguage.Is=>"is",
            TranscriptionLanguage.IsIs=>"is-IS",
            TranscriptionLanguage.It=>"it",
            TranscriptionLanguage.ItCh=>"it-CH",
            TranscriptionLanguage.ItIt=>"it-IT",
            TranscriptionLanguage.IwIl=>"iw-IL",
            TranscriptionLanguage.Ja=>"ja",
            TranscriptionLanguage.JaJp=>"ja-JP",
            TranscriptionLanguage.JvID=>"jv-ID",
            TranscriptionLanguage.Jw=>"jw",
            TranscriptionLanguage.Ka=>"ka",
            TranscriptionLanguage.KaGe=>"ka-GE",
            TranscriptionLanguage.Kk=>"kk",
            TranscriptionLanguage.KkKz=>"kk-KZ",
            TranscriptionLanguage.Km=>"km",
            TranscriptionLanguage.KmKh=>"km-KH",
            TranscriptionLanguage.Kn=>"kn",
            TranscriptionLanguage.KnIn=>"kn-IN",
            TranscriptionLanguage.Ko=>"ko",
            TranscriptionLanguage.KoKr=>"ko-KR",
            TranscriptionLanguage.La=>"la",
            TranscriptionLanguage.Lb=>"lb",
            TranscriptionLanguage.Ln=>"ln",
            TranscriptionLanguage.Lo=>"lo",
            TranscriptionLanguage.LoLa=>"lo-LA",
            TranscriptionLanguage.Lt=>"lt",
            TranscriptionLanguage.LtLt=>"lt-LT",
            TranscriptionLanguage.Lv=>"lv",
            TranscriptionLanguage.LvLv=>"lv-LV",
            TranscriptionLanguage.Mg=>"mg",
            TranscriptionLanguage.Mi=>"mi",
            TranscriptionLanguage.Mk=>"mk",
            TranscriptionLanguage.MkMk=>"mk-MK",
            TranscriptionLanguage.Ml=>"ml",
            TranscriptionLanguage.MlIn=>"ml-IN",
            TranscriptionLanguage.Mn=>"mn",
            TranscriptionLanguage.MnMn=>"mn-MN",
            TranscriptionLanguage.Mr=>"mr",
            TranscriptionLanguage.MrIn=>"mr-IN",
            TranscriptionLanguage.Ms=>"ms",
            TranscriptionLanguage.MsMy=>"ms-MY",
            TranscriptionLanguage.Mt=>"mt",
            TranscriptionLanguage.My=>"my",
            TranscriptionLanguage.MyMm=>"my-MM",
            TranscriptionLanguage.Ne=>"ne",
            TranscriptionLanguage.NeNp=>"ne-NP",
            TranscriptionLanguage.Nl=>"nl",
            TranscriptionLanguage.NlBe=>"nl-BE",
            TranscriptionLanguage.NlNl=>"nl-NL",
            TranscriptionLanguage.Nn=>"nn",
            TranscriptionLanguage.No=>"no",
            TranscriptionLanguage.NoNo=>"no-NO",
            TranscriptionLanguage.Oc=>"oc",
            TranscriptionLanguage.Pa=>"pa",
            TranscriptionLanguage.PaGuruIn=>"pa-Guru-IN",
            TranscriptionLanguage.Pl=>"pl",
            TranscriptionLanguage.PlPl=>"pl-PL",
            TranscriptionLanguage.Ps=>"ps",
            TranscriptionLanguage.Pt=>"pt",
            TranscriptionLanguage.PtBr=>"pt-BR",
            TranscriptionLanguage.PtPt=>"pt-PT",
            TranscriptionLanguage.Ro=>"ro",
            TranscriptionLanguage.RoRo=>"ro-RO",
            TranscriptionLanguage.Ru=>"ru",
            TranscriptionLanguage.RuRu=>"ru-RU",
            TranscriptionLanguage.RwRw=>"rw-RW",
            TranscriptionLanguage.Sa=>"sa",
            TranscriptionLanguage.Sd=>"sd",
            TranscriptionLanguage.Si=>"si",
            TranscriptionLanguage.SiLk=>"si-LK",
            TranscriptionLanguage.Sk=>"sk",
            TranscriptionLanguage.SkSk=>"sk-SK",
            TranscriptionLanguage.Sl=>"sl",
            TranscriptionLanguage.SlSi=>"sl-SI",
            TranscriptionLanguage.Sn=>"sn",
            TranscriptionLanguage.So=>"so",
            TranscriptionLanguage.Sq=>"sq",
            TranscriptionLanguage.SqAl=>"sq-AL",
            TranscriptionLanguage.Sr=>"sr",
            TranscriptionLanguage.SrRs=>"sr-RS",
            TranscriptionLanguage.SSLatnZa=>"ss-latn-za",
            TranscriptionLanguage.StZa=>"st-ZA",
            TranscriptionLanguage.Su=>"su",
            TranscriptionLanguage.SuID=>"su-ID",
            TranscriptionLanguage.Sv=>"sv",
            TranscriptionLanguage.SvSe=>"sv-SE",
            TranscriptionLanguage.Sw=>"sw",
            TranscriptionLanguage.SwKe=>"sw-KE",
            TranscriptionLanguage.SwTz=>"sw-TZ",
            TranscriptionLanguage.Ta=>"ta",
            TranscriptionLanguage.TaIn=>"ta-IN",
            TranscriptionLanguage.TaLk=>"ta-LK",
            TranscriptionLanguage.TaMy=>"ta-MY",
            TranscriptionLanguage.TaSg=>"ta-SG",
            TranscriptionLanguage.Te=>"te",
            TranscriptionLanguage.TeIn=>"te-IN",
            TranscriptionLanguage.Tg=>"tg",
            TranscriptionLanguage.Th=>"th",
            TranscriptionLanguage.ThTh=>"th-TH",
            TranscriptionLanguage.Tk=>"tk",
            TranscriptionLanguage.Tl=>"tl",
            TranscriptionLanguage.TnLatnZa=>"tn-latn-za",
            TranscriptionLanguage.Tr=>"tr",
            TranscriptionLanguage.TrTr=>"tr-TR",
            TranscriptionLanguage.TsZa=>"ts-ZA",
            TranscriptionLanguage.Tt=>"tt",
            TranscriptionLanguage.Uk=>"uk",
            TranscriptionLanguage.UkUa=>"uk-UA",
            TranscriptionLanguage.Ur=>"ur",
            TranscriptionLanguage.UrIn=>"ur-IN",
            TranscriptionLanguage.UrPk=>"ur-PK",
            TranscriptionLanguage.Uz=>"uz",
            TranscriptionLanguage.UzUz=>"uz-UZ",
            TranscriptionLanguage.VeZa=>"ve-ZA",
            TranscriptionLanguage.Vi=>"vi",
            TranscriptionLanguage.ViVn=>"vi-VN",
            TranscriptionLanguage.XhZa=>"xh-ZA",
            TranscriptionLanguage.Yi=>"yi",
            TranscriptionLanguage.Yo=>"yo",
            TranscriptionLanguage.YueHantHk=>"yue-Hant-HK",
            TranscriptionLanguage.Zh=>"zh",
            TranscriptionLanguage.ZhTw=>"zh-TW",
            TranscriptionLanguage.ZuZa=>"zu-ZA",
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
[JsonConverter(typeof(TrimConverter))]
public enum Trim
{
    TrimSilence
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "trim-silence"=>Trim.TrimSilence, _ =>(Trim)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Trim value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Trim.TrimSilence=>"trim-silence",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}