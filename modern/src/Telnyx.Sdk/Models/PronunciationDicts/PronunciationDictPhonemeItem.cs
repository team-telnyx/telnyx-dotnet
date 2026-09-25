using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PronunciationDicts;

/// <summary>
/// A phoneme pronunciation item. When the `text` value is found in input, it is
/// pronounced using the specified IPA phoneme notation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PronunciationDictPhonemeItem, PronunciationDictPhonemeItemFromRaw>))]
public sealed record class PronunciationDictPhonemeItem : JsonModel
{
    /// <summary>
    /// The phonetic alphabet used for the phoneme notation.
    /// </summary>
    public required ApiEnum<string, Alphabet> Alphabet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Alphabet>>(
                "alphabet"
            );
        }
        init { this._rawData.Set("alphabet", value); }
    }

    /// <summary>
    /// The phoneme notation representing the desired pronunciation.
    /// </summary>
    public required string Phoneme {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phoneme"
            );
        }
        init { this._rawData.Set("phoneme", value); }
    }

    /// <summary>
    /// The text to match in the input. Case-insensitive matching is used during synthesis.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The item type.
    /// </summary>
    public required ApiEnum<string, PronunciationDictPhonemeItemType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PronunciationDictPhonemeItemType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Alphabet.Validate();
        _ = this.Phoneme;
        _ = this.Text;
        this.Type.Validate();
    }

    public PronunciationDictPhonemeItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PronunciationDictPhonemeItem (
        PronunciationDictPhonemeItem pronunciationDictPhonemeItem
    ) : base(pronunciationDictPhonemeItem)
    {  }
    #pragma warning restore CS8618

    public PronunciationDictPhonemeItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PronunciationDictPhonemeItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PronunciationDictPhonemeItemFromRaw.FromRawUnchecked"/>
    public static PronunciationDictPhonemeItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PronunciationDictPhonemeItemFromRaw : IFromRawJson<PronunciationDictPhonemeItem>
{
    /// <inheritdoc/>
    public PronunciationDictPhonemeItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PronunciationDictPhonemeItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The phonetic alphabet used for the phoneme notation.
/// </summary>
[JsonConverter(typeof(AlphabetConverter))]
public enum Alphabet
{
    Ipa
}sealed class AlphabetConverter : JsonConverter<Alphabet>
{
    public override Alphabet Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "ipa"=>Alphabet.Ipa, _ =>(Alphabet)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Alphabet value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Alphabet.Ipa=>"ipa",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The item type.
/// </summary>
[JsonConverter(typeof(PronunciationDictPhonemeItemTypeConverter))]
public enum PronunciationDictPhonemeItemType
{
    Phoneme
}sealed class PronunciationDictPhonemeItemTypeConverter : JsonConverter<PronunciationDictPhonemeItemType>
{
    public override PronunciationDictPhonemeItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phoneme"=>PronunciationDictPhonemeItemType.Phoneme,
            _ =>(PronunciationDictPhonemeItemType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PronunciationDictPhonemeItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PronunciationDictPhonemeItemType.Phoneme=>"phoneme",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}