using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<MinimaxVoiceSettings, MinimaxVoiceSettingsFromRaw>))]
public sealed record class MinimaxVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, MinimaxVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimaxVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Enhances recognition for specific languages and dialects during MiniMax TTS
    /// synthesis. Default is null (no boost). Set to 'auto' for automatic language detection.
    /// </summary>
    public ApiEnum<string, LanguageBoost>? LanguageBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LanguageBoost>>(
                "language_boost"
            );
        }
        init { this._rawData.Set("language_boost", value); }
    }

    /// <summary>
    /// Voice pitch adjustment. Default is 0.
    /// </summary>
    public long? Pitch {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "pitch"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pitch", value);
        }
    }

    /// <summary>
    /// Speech speed multiplier. Default is 1.0.
    /// </summary>
    public float? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <summary>
    /// Speech volume multiplier. Default is 1.0.
    /// </summary>
    public float? Vol {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "vol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vol", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.LanguageBoost?.Validate();
        _ = this.Pitch;
        _ = this.Speed;
        _ = this.Vol;
    }

    public MinimaxVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MinimaxVoiceSettings (
        MinimaxVoiceSettings minimaxVoiceSettings
    ) : base(minimaxVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public MinimaxVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimaxVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MinimaxVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static MinimaxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MinimaxVoiceSettings (
        ApiEnum<string, MinimaxVoiceSettingsType> type
    ) : this()
    { this.Type = type; }
}

class MinimaxVoiceSettingsFromRaw : IFromRawJson<MinimaxVoiceSettings>
{
    /// <inheritdoc/>
    public MinimaxVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MinimaxVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(MinimaxVoiceSettingsTypeConverter))]
public enum MinimaxVoiceSettingsType
{
    Minimax
}sealed class MinimaxVoiceSettingsTypeConverter : JsonConverter<MinimaxVoiceSettingsType>
{
    public override MinimaxVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimax"=>MinimaxVoiceSettingsType.Minimax,
            _ =>(MinimaxVoiceSettingsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxVoiceSettingsType.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Enhances recognition for specific languages and dialects during MiniMax TTS synthesis.
/// Default is null (no boost). Set to 'auto' for automatic language detection.
/// </summary>
[JsonConverter(typeof(LanguageBoostConverter))]
public enum LanguageBoost
{
    Auto,
    Chinese,
    ChineseYue,
    English,
    Arabic,
    Russian,
    Spanish,
    French,
    Portuguese,
    German,
    Turkish,
    Dutch,
    Ukrainian,
    Vietnamese,
    Indonesian,
    Japanese,
    Italian,
    Korean,
    Thai,
    Polish,
    Romanian,
    Greek,
    Czech,
    Finnish,
    Hindi,
    Bulgarian,
    Danish,
    Hebrew,
    Malay,
    Persian,
    Slovak,
    Swedish,
    Croatian,
    Filipino,
    Hungarian,
    Norwegian,
    Slovenian,
    Catalan,
    Nynorsk,
    Tamil,
    Afrikaans
}sealed class LanguageBoostConverter : JsonConverter<LanguageBoost>
{
    public override LanguageBoost Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto"=>LanguageBoost.Auto,
            "Chinese"=>LanguageBoost.Chinese,
            "Chinese,Yue"=>LanguageBoost.ChineseYue,
            "English"=>LanguageBoost.English,
            "Arabic"=>LanguageBoost.Arabic,
            "Russian"=>LanguageBoost.Russian,
            "Spanish"=>LanguageBoost.Spanish,
            "French"=>LanguageBoost.French,
            "Portuguese"=>LanguageBoost.Portuguese,
            "German"=>LanguageBoost.German,
            "Turkish"=>LanguageBoost.Turkish,
            "Dutch"=>LanguageBoost.Dutch,
            "Ukrainian"=>LanguageBoost.Ukrainian,
            "Vietnamese"=>LanguageBoost.Vietnamese,
            "Indonesian"=>LanguageBoost.Indonesian,
            "Japanese"=>LanguageBoost.Japanese,
            "Italian"=>LanguageBoost.Italian,
            "Korean"=>LanguageBoost.Korean,
            "Thai"=>LanguageBoost.Thai,
            "Polish"=>LanguageBoost.Polish,
            "Romanian"=>LanguageBoost.Romanian,
            "Greek"=>LanguageBoost.Greek,
            "Czech"=>LanguageBoost.Czech,
            "Finnish"=>LanguageBoost.Finnish,
            "Hindi"=>LanguageBoost.Hindi,
            "Bulgarian"=>LanguageBoost.Bulgarian,
            "Danish"=>LanguageBoost.Danish,
            "Hebrew"=>LanguageBoost.Hebrew,
            "Malay"=>LanguageBoost.Malay,
            "Persian"=>LanguageBoost.Persian,
            "Slovak"=>LanguageBoost.Slovak,
            "Swedish"=>LanguageBoost.Swedish,
            "Croatian"=>LanguageBoost.Croatian,
            "Filipino"=>LanguageBoost.Filipino,
            "Hungarian"=>LanguageBoost.Hungarian,
            "Norwegian"=>LanguageBoost.Norwegian,
            "Slovenian"=>LanguageBoost.Slovenian,
            "Catalan"=>LanguageBoost.Catalan,
            "Nynorsk"=>LanguageBoost.Nynorsk,
            "Tamil"=>LanguageBoost.Tamil,
            "Afrikaans"=>LanguageBoost.Afrikaans,
            _ =>(LanguageBoost)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LanguageBoost value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LanguageBoost.Auto=>"auto",
            LanguageBoost.Chinese=>"Chinese",
            LanguageBoost.ChineseYue=>"Chinese,Yue",
            LanguageBoost.English=>"English",
            LanguageBoost.Arabic=>"Arabic",
            LanguageBoost.Russian=>"Russian",
            LanguageBoost.Spanish=>"Spanish",
            LanguageBoost.French=>"French",
            LanguageBoost.Portuguese=>"Portuguese",
            LanguageBoost.German=>"German",
            LanguageBoost.Turkish=>"Turkish",
            LanguageBoost.Dutch=>"Dutch",
            LanguageBoost.Ukrainian=>"Ukrainian",
            LanguageBoost.Vietnamese=>"Vietnamese",
            LanguageBoost.Indonesian=>"Indonesian",
            LanguageBoost.Japanese=>"Japanese",
            LanguageBoost.Italian=>"Italian",
            LanguageBoost.Korean=>"Korean",
            LanguageBoost.Thai=>"Thai",
            LanguageBoost.Polish=>"Polish",
            LanguageBoost.Romanian=>"Romanian",
            LanguageBoost.Greek=>"Greek",
            LanguageBoost.Czech=>"Czech",
            LanguageBoost.Finnish=>"Finnish",
            LanguageBoost.Hindi=>"Hindi",
            LanguageBoost.Bulgarian=>"Bulgarian",
            LanguageBoost.Danish=>"Danish",
            LanguageBoost.Hebrew=>"Hebrew",
            LanguageBoost.Malay=>"Malay",
            LanguageBoost.Persian=>"Persian",
            LanguageBoost.Slovak=>"Slovak",
            LanguageBoost.Swedish=>"Swedish",
            LanguageBoost.Croatian=>"Croatian",
            LanguageBoost.Filipino=>"Filipino",
            LanguageBoost.Hungarian=>"Hungarian",
            LanguageBoost.Norwegian=>"Norwegian",
            LanguageBoost.Slovenian=>"Slovenian",
            LanguageBoost.Catalan=>"Catalan",
            LanguageBoost.Nynorsk=>"Nynorsk",
            LanguageBoost.Tamil=>"Tamil",
            LanguageBoost.Afrikaans=>"Afrikaans",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}