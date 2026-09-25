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
/// Start noise suppression on an active call to reduce background noise. This feature
/// is currently in beta.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartNoiseSuppressionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

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
    /// The direction of the audio stream to be noise suppressed.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("direction", value);
        }
    }

    /// <summary>
    /// The engine to use for noise suppression. For backward compatibility, engines
    /// A, B, C, and D are also supported, but are deprecated:  A - Denoiser  B -
    /// DeepFilterNet  C - Krisp  D - AiCoustics
    /// </summary>
    public ApiEnum<string, NoiseSuppressionEngine>? NoiseSuppressionEngine {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, NoiseSuppressionEngine>>(
                "noise_suppression_engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("noise_suppression_engine", value);
        }
    }

    /// <summary>
    /// Configuration parameters for noise suppression engines. Different engines
    /// support different parameters.
    /// </summary>
    public NoiseSuppressionEngineConfig? NoiseSuppressionEngineConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NoiseSuppressionEngineConfig>(
                "noise_suppression_engine_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("noise_suppression_engine_config", value);
        }
    }

    public ActionStartNoiseSuppressionParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartNoiseSuppressionParams (
        ActionStartNoiseSuppressionParams actionStartNoiseSuppressionParams
    ) : base(actionStartNoiseSuppressionParams)
    {
        this.CallControlID = actionStartNoiseSuppressionParams.CallControlID;

        this._rawBodyData = new(actionStartNoiseSuppressionParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartNoiseSuppressionParams (
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
    ActionStartNoiseSuppressionParams (
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
    public static ActionStartNoiseSuppressionParams FromRawUnchecked(
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

    public virtual bool Equals(ActionStartNoiseSuppressionParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/suppression_start",
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
/// The direction of the audio stream to be noise suppressed.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound, Both
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>Direction.Inbound,
            "outbound"=>Direction.Outbound,
            "both"=>Direction.Both,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"inbound",
            Direction.Outbound=>"outbound",
            Direction.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The engine to use for noise suppression. For backward compatibility, engines A,
/// B, C, and D are also supported, but are deprecated:  A - Denoiser  B - DeepFilterNet
///  C - Krisp  D - AiCoustics
/// </summary>
[JsonConverter(typeof(NoiseSuppressionEngineConverter))]
public enum NoiseSuppressionEngine
{
    Denoiser,
    DeepFilterNet,
    Krisp,
    AICoustics,
    AicLQuail,
    AicLRook,
    AicSQuail,
    AicSRook,
    QuailVoiceFocusS,
    QuailVoiceFocusXs
}

sealed class NoiseSuppressionEngineConverter : JsonConverter<NoiseSuppressionEngine>
{
    public override NoiseSuppressionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Denoiser"=>NoiseSuppressionEngine.Denoiser,
            "DeepFilterNet"=>NoiseSuppressionEngine.DeepFilterNet,
            "Krisp"=>NoiseSuppressionEngine.Krisp,
            "AiCoustics"=>NoiseSuppressionEngine.AICoustics,
            "aic_l_quail"=>NoiseSuppressionEngine.AicLQuail,
            "aic_l_rook"=>NoiseSuppressionEngine.AicLRook,
            "aic_s_quail"=>NoiseSuppressionEngine.AicSQuail,
            "aic_s_rook"=>NoiseSuppressionEngine.AicSRook,
            "quail_voice_focus_s"=>NoiseSuppressionEngine.QuailVoiceFocusS,
            "quail_voice_focus_xs"=>NoiseSuppressionEngine.QuailVoiceFocusXs,
            _ =>(NoiseSuppressionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoiseSuppressionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NoiseSuppressionEngine.Denoiser=>"Denoiser",
            NoiseSuppressionEngine.DeepFilterNet=>"DeepFilterNet",
            NoiseSuppressionEngine.Krisp=>"Krisp",
            NoiseSuppressionEngine.AICoustics=>"AiCoustics",
            NoiseSuppressionEngine.AicLQuail=>"aic_l_quail",
            NoiseSuppressionEngine.AicLRook=>"aic_l_rook",
            NoiseSuppressionEngine.AicSQuail=>"aic_s_quail",
            NoiseSuppressionEngine.AicSRook=>"aic_s_rook",
            NoiseSuppressionEngine.QuailVoiceFocusS=>"quail_voice_focus_s",
            NoiseSuppressionEngine.QuailVoiceFocusXs=>"quail_voice_focus_xs",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Configuration parameters for noise suppression engines. Different engines support
/// different parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NoiseSuppressionEngineConfig, NoiseSuppressionEngineConfigFromRaw>))]
public sealed record class NoiseSuppressionEngineConfig : JsonModel
{
    /// <summary>
    /// The attenuation limit for noise suppression (0-100). Only applicable for DeepFilterNet.
    /// </summary>
    public long? AttenuationLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "attenuation_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attenuation_limit", value);
        }
    }

    /// <summary>
    /// Enhancement intensity (0.0-1.0). Only applicable for AiCoustics.
    /// </summary>
    public double? EnhancementLevel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "enhancement_level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enhancement_level", value);
        }
    }

    /// <summary>
    /// AiCoustics model family. 'sparrow' optimized for human-to-human calls, 'quail'
    /// optimized for Voice AI/STT. Only applicable for AiCoustics.
    /// </summary>
    public ApiEnum<string, Family>? Family {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Family>>(
                "family"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("family", value);
        }
    }

    /// <summary>
    /// Processing mode. Only applicable for DeepFilterNet.
    /// </summary>
    public ApiEnum<string, Mode>? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>(
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

    /// <summary>
    /// The Krisp model to use. Only applicable for Krisp.
    /// </summary>
    public ApiEnum<string, Model>? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Model>>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// AiCoustics model size. 's' and 'l' work with both families. 'xs' and 'xxs'
    /// are sparrow-only. 'vf_l' and 'vf_1_1_l' are quail-only. Only applicable for AiCoustics.
    /// </summary>
    public ApiEnum<string, Size>? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Size>>(
                "size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// Suppression level (0.0-100.0). Only applicable for Krisp.
    /// </summary>
    public double? SuppressionLevel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "suppression_level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("suppression_level", value);
        }
    }

    /// <summary>
    /// Voice gain multiplier (0.1-4.0). Only applicable for AiCoustics.
    /// </summary>
    public double? VoiceGain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "voice_gain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_gain", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttenuationLimit;
        _ = this.EnhancementLevel;
        this.Family?.Validate();
        this.Mode?.Validate();
        this.Model?.Validate();
        this.Size?.Validate();
        _ = this.SuppressionLevel;
        _ = this.VoiceGain;
    }

    public NoiseSuppressionEngineConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoiseSuppressionEngineConfig (
        NoiseSuppressionEngineConfig noiseSuppressionEngineConfig
    ) : base(noiseSuppressionEngineConfig)
    {  }
    #pragma warning restore CS8618

    public NoiseSuppressionEngineConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NoiseSuppressionEngineConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NoiseSuppressionEngineConfigFromRaw.FromRawUnchecked"/>
    public static NoiseSuppressionEngineConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NoiseSuppressionEngineConfigFromRaw : IFromRawJson<NoiseSuppressionEngineConfig>
{
    /// <inheritdoc/>
    public NoiseSuppressionEngineConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NoiseSuppressionEngineConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// AiCoustics model family. 'sparrow' optimized for human-to-human calls, 'quail'
/// optimized for Voice AI/STT. Only applicable for AiCoustics.
/// </summary>
[JsonConverter(typeof(FamilyConverter))]
public enum Family
{
    Sparrow, Quail
}

sealed class FamilyConverter : JsonConverter<Family>
{
    public override Family Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "sparrow"=>Family.Sparrow, "quail"=>Family.Quail, _ =>(Family)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Family value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Family.Sparrow=>"sparrow",
            Family.Quail=>"quail",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Processing mode. Only applicable for DeepFilterNet.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Standard, Advanced
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard"=>Mode.Standard, "advanced"=>Mode.Advanced, _ =>(Mode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Mode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Mode.Standard=>"standard",
            Mode.Advanced=>"advanced",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The Krisp model to use. Only applicable for Krisp.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    KrispVivaTelV2Kef,
    KrispVivaTelLiteV1Kef,
    KrispVivaProV1Kef,
    KrispVivaSSV1Kef
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "krisp-viva-tel-v2.kef"=>Model.KrispVivaTelV2Kef,
            "krisp-viva-tel-lite-v1.kef"=>Model.KrispVivaTelLiteV1Kef,
            "krisp-viva-pro-v1.kef"=>Model.KrispVivaProV1Kef,
            "krisp-viva-ss-v1.kef"=>Model.KrispVivaSSV1Kef,
            _ =>(Model)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Model value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Model.KrispVivaTelV2Kef=>"krisp-viva-tel-v2.kef",
            Model.KrispVivaTelLiteV1Kef=>"krisp-viva-tel-lite-v1.kef",
            Model.KrispVivaProV1Kef=>"krisp-viva-pro-v1.kef",
            Model.KrispVivaSSV1Kef=>"krisp-viva-ss-v1.kef",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// AiCoustics model size. 's' and 'l' work with both families. 'xs' and 'xxs' are
/// sparrow-only. 'vf_l' and 'vf_1_1_l' are quail-only. Only applicable for AiCoustics.
/// </summary>
[JsonConverter(typeof(SizeConverter))]
public enum Size
{
    S, L, Xs, Xxs, VfL, Vf1_1L
}

sealed class SizeConverter : JsonConverter<Size>
{
    public override Size Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "s"=>Size.S,
            "l"=>Size.L,
            "xs"=>Size.Xs,
            "xxs"=>Size.Xxs,
            "vf_l"=>Size.VfL,
            "vf_1_1_l"=>Size.Vf1_1L,
            _ =>(Size)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Size value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Size.S=>"s",
            Size.L=>"l",
            Size.Xs=>"xs",
            Size.Xxs=>"xxs",
            Size.VfL=>"vf_l",
            Size.Vf1_1L=>"vf_1_1_l",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}