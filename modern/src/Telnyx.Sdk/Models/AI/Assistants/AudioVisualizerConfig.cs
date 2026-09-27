using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<AudioVisualizerConfig, AudioVisualizerConfigFromRaw>))]
public sealed record class AudioVisualizerConfig : JsonModel
{
    /// <summary>
    /// The color theme for the audio visualizer.
    /// </summary>
    public ApiEnum<string, Color>? Color {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Color>>(
                "color"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("color", value);
        }
    }

    /// <summary>
    /// The preset style for the audio visualizer.
    /// </summary>
    public string? Preset {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "preset"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("preset", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Color?.Validate();
        _ = this.Preset;
    }

    public AudioVisualizerConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioVisualizerConfig (
        AudioVisualizerConfig audioVisualizerConfig
    ) : base(audioVisualizerConfig)
    {  }
    #pragma warning restore CS8618

    public AudioVisualizerConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioVisualizerConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AudioVisualizerConfigFromRaw.FromRawUnchecked"/>
    public static AudioVisualizerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AudioVisualizerConfigFromRaw : IFromRawJson<AudioVisualizerConfig>
{
    /// <inheritdoc/>
    public AudioVisualizerConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AudioVisualizerConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The color theme for the audio visualizer.
/// </summary>
[JsonConverter(typeof(ColorConverter))]
public enum Color
{
    Verdant, Twilight, Bloom, Mystic, Flare, Glacier
}sealed class ColorConverter : JsonConverter<Color>
{
    public override Color Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "verdant"=>Color.Verdant,
            "twilight"=>Color.Twilight,
            "bloom"=>Color.Bloom,
            "mystic"=>Color.Mystic,
            "flare"=>Color.Flare,
            "glacier"=>Color.Glacier,
            _ =>(Color)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Color value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Color.Verdant=>"verdant",
            Color.Twilight=>"twilight",
            Color.Bloom=>"bloom",
            Color.Mystic=>"mystic",
            Color.Flare=>"flare",
            Color.Glacier=>"glacier",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}