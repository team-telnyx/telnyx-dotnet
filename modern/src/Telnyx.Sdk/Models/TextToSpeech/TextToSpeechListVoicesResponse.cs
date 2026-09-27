using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TextToSpeech;

/// <summary>
/// List of available voices.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TextToSpeechListVoicesResponse, TextToSpeechListVoicesResponseFromRaw>))]
public sealed record class TextToSpeechListVoicesResponse : JsonModel
{
    public IReadOnlyList<Voice>? Voices {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Voice>>(
                "voices"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Voice>?>(
                "voices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Voices ?? [])
        {
            item.Validate();
        }
    }

    public TextToSpeechListVoicesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextToSpeechListVoicesResponse (
        TextToSpeechListVoicesResponse textToSpeechListVoicesResponse
    ) : base(textToSpeechListVoicesResponse)
    {  }
    #pragma warning restore CS8618

    public TextToSpeechListVoicesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextToSpeechListVoicesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TextToSpeechListVoicesResponseFromRaw.FromRawUnchecked"/>
    public static TextToSpeechListVoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TextToSpeechListVoicesResponseFromRaw : IFromRawJson<TextToSpeechListVoicesResponse>
{
    /// <inheritdoc/>
    public TextToSpeechListVoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TextToSpeechListVoicesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A voice available for text-to-speech synthesis.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Voice, VoiceFromRaw>))]
public sealed record class Voice : JsonModel
{
    /// <summary>
    /// Voice gender.
    /// </summary>
    public string? Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gender"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gender", value);
        }
    }

    /// <summary>
    /// Whether this voice runs on Telnyx-hosted infrastructure (`true`) or is provided
    /// by a third-party vendor (`false`).
    /// </summary>
    public bool? Hosted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "hosted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hosted", value);
        }
    }

    /// <summary>
    /// Language code.
    /// </summary>
    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// Voice name.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The TTS provider.
    /// </summary>
    public string? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <summary>
    /// Voice identifier.
    /// </summary>
    public string? VoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gender;
        _ = this.Hosted;
        _ = this.Language;
        _ = this.Name;
        _ = this.Provider;
        _ = this.VoiceID;
    }

    public Voice ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Voice (Voice voice) : base(voice)
    {  }
    #pragma warning restore CS8618

    public Voice (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Voice (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceFromRaw.FromRawUnchecked"/>
    public static Voice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoiceFromRaw : IFromRawJson<Voice>
{
    /// <inheritdoc/>
    public Voice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Voice.FromRawUnchecked(rawData);
}