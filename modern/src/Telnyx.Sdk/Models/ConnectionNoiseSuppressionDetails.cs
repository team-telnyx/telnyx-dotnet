using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

/// <summary>
/// Configuration options for noise suppression. These settings are stored regardless
/// of the noise_suppression value, but only take effect when noise_suppression is
/// not 'disabled'. If you disable noise suppression and later re-enable it, the previously
/// configured settings will be used.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConnectionNoiseSuppressionDetails, ConnectionNoiseSuppressionDetailsFromRaw>))]
public sealed record class ConnectionNoiseSuppressionDetails : JsonModel
{
    /// <summary>
    /// The attenuation limit value for the selected engine. Default values vary by
    /// engine: 0 for 'denoiser', 80 for 'deep_filter_net', 'deep_filter_net_large',
    /// and all Krisp engines ('krisp_viva_tel', 'krisp_viva_tel_lite', 'krisp_viva_promodel',
    /// 'krisp_viva_ss'), 100 for 'quail_voice_focus'.
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
    /// The noise suppression engine to use. 'denoiser' is the default engine. 'deep_filter_net'
    /// and 'deep_filter_net_large' are alternative engines with different performance
    /// characteristics. Krisp engines ('krisp_viva_tel', 'krisp_viva_tel_lite', 'krisp_viva_promodel',
    /// 'krisp_viva_ss') provide advanced noise suppression capabilities. 'quail_voice_focus'
    /// provides Quail-based voice focus noise suppression.
    /// </summary>
    public ApiEnum<string, Engine>? Engine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Engine>>(
                "engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("engine", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttenuationLimit;
        this.Engine?.Validate();
    }

    public ConnectionNoiseSuppressionDetails ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionNoiseSuppressionDetails (
        ConnectionNoiseSuppressionDetails connectionNoiseSuppressionDetails
    ) : base(connectionNoiseSuppressionDetails)
    {  }
    #pragma warning restore CS8618

    public ConnectionNoiseSuppressionDetails (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionNoiseSuppressionDetails (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionNoiseSuppressionDetailsFromRaw.FromRawUnchecked"/>
    public static ConnectionNoiseSuppressionDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionNoiseSuppressionDetailsFromRaw : IFromRawJson<ConnectionNoiseSuppressionDetails>
{
    /// <inheritdoc/>
    public ConnectionNoiseSuppressionDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionNoiseSuppressionDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The noise suppression engine to use. 'denoiser' is the default engine. 'deep_filter_net'
/// and 'deep_filter_net_large' are alternative engines with different performance
/// characteristics. Krisp engines ('krisp_viva_tel', 'krisp_viva_tel_lite', 'krisp_viva_promodel',
/// 'krisp_viva_ss') provide advanced noise suppression capabilities. 'quail_voice_focus'
/// provides Quail-based voice focus noise suppression.
/// </summary>
[JsonConverter(typeof(EngineConverter))]
public enum Engine
{
    Denoiser,
    DeepFilterNet,
    DeepFilterNetLarge,
    KrispVivaTel,
    KrispVivaTelLite,
    KrispVivaPromodel,
    KrispVivaSS,
    QuailVoiceFocus
}sealed class EngineConverter : JsonConverter<Engine>
{
    public override Engine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "denoiser"=>Engine.Denoiser,
            "deep_filter_net"=>Engine.DeepFilterNet,
            "deep_filter_net_large"=>Engine.DeepFilterNetLarge,
            "krisp_viva_tel"=>Engine.KrispVivaTel,
            "krisp_viva_tel_lite"=>Engine.KrispVivaTelLite,
            "krisp_viva_promodel"=>Engine.KrispVivaPromodel,
            "krisp_viva_ss"=>Engine.KrispVivaSS,
            "quail_voice_focus"=>Engine.QuailVoiceFocus,
            _ =>(Engine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Engine value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Engine.Denoiser=>"denoiser",
            Engine.DeepFilterNet=>"deep_filter_net",
            Engine.DeepFilterNetLarge=>"deep_filter_net_large",
            Engine.KrispVivaTel=>"krisp_viva_tel",
            Engine.KrispVivaTelLite=>"krisp_viva_tel_lite",
            Engine.KrispVivaPromodel=>"krisp_viva_promodel",
            Engine.KrispVivaSS=>"krisp_viva_ss",
            Engine.QuailVoiceFocus=>"quail_voice_focus",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}