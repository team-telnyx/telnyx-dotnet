using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TextToSpeech;

/// <summary>
/// Response when `output_type` is `base64_output`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TextToSpeechGenerateSpeechResponse, TextToSpeechGenerateSpeechResponseFromRaw>))]
public sealed record class TextToSpeechGenerateSpeechResponse : JsonModel
{
    /// <summary>
    /// Base64-encoded audio data.
    /// </summary>
    public string? Base64Audio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "base64_audio"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("base64_audio", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Base64Audio; }

    public TextToSpeechGenerateSpeechResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextToSpeechGenerateSpeechResponse (
        TextToSpeechGenerateSpeechResponse textToSpeechGenerateSpeechResponse
    ) : base(textToSpeechGenerateSpeechResponse)
    {  }
    #pragma warning restore CS8618

    public TextToSpeechGenerateSpeechResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextToSpeechGenerateSpeechResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TextToSpeechGenerateSpeechResponseFromRaw.FromRawUnchecked"/>
    public static TextToSpeechGenerateSpeechResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TextToSpeechGenerateSpeechResponseFromRaw : IFromRawJson<TextToSpeechGenerateSpeechResponse>
{
    /// <inheritdoc/>
    public TextToSpeechGenerateSpeechResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TextToSpeechGenerateSpeechResponse.FromRawUnchecked(rawData);
}