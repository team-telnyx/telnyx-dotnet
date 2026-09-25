using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

/// <summary>
/// Carousel component for multi-card templates. Each card can contain its own header,
/// body, and buttons.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateCarouselComponent, WhatsappTemplateCarouselComponentFromRaw>))]
public sealed record class WhatsappTemplateCarouselComponent : JsonModel
{
    /// <summary>
    /// Array of card objects, each with its own components.
    /// </summary>
    public required IReadOnlyList<Card> Cards {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Card>>(
                "cards"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Card>>(
                "cards",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, WhatsappTemplateCarouselComponentType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappTemplateCarouselComponentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Cards)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public WhatsappTemplateCarouselComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateCarouselComponent (
        WhatsappTemplateCarouselComponent whatsappTemplateCarouselComponent
    ) : base(whatsappTemplateCarouselComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateCarouselComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateCarouselComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateCarouselComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateCarouselComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappTemplateCarouselComponentFromRaw : IFromRawJson<WhatsappTemplateCarouselComponent>
{
    /// <inheritdoc/>
    public WhatsappTemplateCarouselComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateCarouselComponent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Card, CardFromRaw>))]
public sealed record class Card : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Components {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "components"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Components; }

    public Card ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Card (Card card) : base(card)
    {  }
    #pragma warning restore CS8618

    public Card (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Card (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CardFromRaw.FromRawUnchecked"/>
    public static Card FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CardFromRaw : IFromRawJson<Card>
{
    /// <inheritdoc/>
    public Card FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Card.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappTemplateCarouselComponentTypeConverter))]
public enum WhatsappTemplateCarouselComponentType
{
    Carousel
}sealed class WhatsappTemplateCarouselComponentTypeConverter : JsonConverter<WhatsappTemplateCarouselComponentType>
{
    public override WhatsappTemplateCarouselComponentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CAROUSEL"=>WhatsappTemplateCarouselComponentType.Carousel,
            _ =>(WhatsappTemplateCarouselComponentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappTemplateCarouselComponentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappTemplateCarouselComponentType.Carousel=>"CAROUSEL",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}