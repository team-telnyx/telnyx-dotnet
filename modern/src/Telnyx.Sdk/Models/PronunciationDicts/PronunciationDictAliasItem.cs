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
/// An alias pronunciation item. When the `text` value is found in input, it is replaced
/// with the `alias` before speech synthesis.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PronunciationDictAliasItem, PronunciationDictAliasItemFromRaw>))]
public sealed record class PronunciationDictAliasItem : JsonModel
{
    /// <summary>
    /// The replacement text that will be spoken instead.
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
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
    public required ApiEnum<string, global::Telnyx.Sdk.Models.PronunciationDicts.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.PronunciationDicts.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        _ = this.Text;
        this.Type.Validate();
    }

    public PronunciationDictAliasItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PronunciationDictAliasItem (
        PronunciationDictAliasItem pronunciationDictAliasItem
    ) : base(pronunciationDictAliasItem)
    {  }
    #pragma warning restore CS8618

    public PronunciationDictAliasItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PronunciationDictAliasItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PronunciationDictAliasItemFromRaw.FromRawUnchecked"/>
    public static PronunciationDictAliasItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PronunciationDictAliasItemFromRaw : IFromRawJson<PronunciationDictAliasItem>
{
    /// <inheritdoc/>
    public PronunciationDictAliasItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PronunciationDictAliasItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The item type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Alias
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.PronunciationDicts.Type>
{
    public override global::Telnyx.Sdk.Models.PronunciationDicts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "alias"=>global::Telnyx.Sdk.Models.PronunciationDicts.Type.Alias,
            _ =>(global::Telnyx.Sdk.Models.PronunciationDicts.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.PronunciationDicts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.PronunciationDicts.Type.Alias=>"alias",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}