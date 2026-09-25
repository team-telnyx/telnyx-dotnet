using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WhatsappInteractive, WhatsappInteractiveFromRaw>))]
public sealed record class WhatsappInteractive : JsonModel
{
    public WhatsappInteractiveAction? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappInteractiveAction>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public WhatsappInteractiveBody? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappInteractiveBody>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    public Footer? Footer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Footer>(
                "footer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("footer", value);
        }
    }

    public WhatsappInteractiveHeader? Header {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappInteractiveHeader>(
                "header"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("header", value);
        }
    }

    public ApiEnum<string, WhatsappInteractiveType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WhatsappInteractiveType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        this.Body?.Validate();
        this.Footer?.Validate();
        this.Header?.Validate();
        this.Type?.Validate();
    }

    public WhatsappInteractive ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappInteractive (WhatsappInteractive whatsappInteractive) : base(
        whatsappInteractive
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappInteractive (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappInteractive (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappInteractiveFromRaw.FromRawUnchecked"/>
    public static WhatsappInteractive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappInteractiveFromRaw : IFromRawJson<WhatsappInteractive>
{
    /// <inheritdoc/>
    public WhatsappInteractive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappInteractive.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappInteractiveAction, WhatsappInteractiveActionFromRaw>))]
public sealed record class WhatsappInteractiveAction : JsonModel
{
    public string? Button {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "button"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("button", value);
        }
    }

    public IReadOnlyList<Button>? Buttons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Button>>(
                "buttons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Button>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Card>? Cards {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Card>>(
                "cards"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Card>?>(
                "cards",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? CatalogID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "catalog_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("catalog_id", value);
        }
    }

    public string? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    public Parameters? Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Parameters>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parameters", value);
        }
    }

    public string? ProductRetailerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product_retailer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_retailer_id", value);
        }
    }

    public IReadOnlyList<Section>? Sections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Section>>(
                "sections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Section>?>(
                "sections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Button;
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Cards ?? [])
        {
            item.Validate();
        }
        _ = this.CatalogID;
        _ = this.Mode;
        _ = this.Name;
        this.Parameters?.Validate();
        _ = this.ProductRetailerID;
        foreach (var item in this.Sections ?? [])
        {
            item.Validate();
        }
    }

    public WhatsappInteractiveAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappInteractiveAction (
        WhatsappInteractiveAction whatsappInteractiveAction
    ) : base(whatsappInteractiveAction)
    {  }
    #pragma warning restore CS8618

    public WhatsappInteractiveAction (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappInteractiveAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappInteractiveActionFromRaw.FromRawUnchecked"/>
    public static WhatsappInteractiveAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappInteractiveActionFromRaw : IFromRawJson<WhatsappInteractiveAction>
{
    /// <inheritdoc/>
    public WhatsappInteractiveAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappInteractiveAction.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
{
    public ButtonReply? Reply {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ButtonReply>(
                "reply"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reply", value);
        }
    }

    public ApiEnum<string, ButtonType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ButtonType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reply?.Validate();
        this.Type?.Validate();
    }

    public Button ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Button (Button button) : base(button)
    {  }
    #pragma warning restore CS8618

    public Button (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Button (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ButtonFromRaw.FromRawUnchecked"/>
    public static Button FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ButtonFromRaw : IFromRawJson<Button>
{
    /// <inheritdoc/>
    public Button FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Button.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ButtonReply, ButtonReplyFromRaw>))]
public sealed record class ButtonReply : JsonModel
{
    /// <summary>
    /// unique identifier for each button, 256 character maximum
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// button label, 20 character maximum
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
    }

    public ButtonReply ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ButtonReply (ButtonReply buttonReply) : base(buttonReply)
    {  }
    #pragma warning restore CS8618

    public ButtonReply (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ButtonReply (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ButtonReplyFromRaw.FromRawUnchecked"/>
    public static ButtonReply FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ButtonReplyFromRaw : IFromRawJson<ButtonReply>
{
    /// <inheritdoc/>
    public ButtonReply FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ButtonReply.FromRawUnchecked(rawData);
}[JsonConverter(typeof(ButtonTypeConverter))]
public enum ButtonType
{
    Reply
}sealed class ButtonTypeConverter : JsonConverter<ButtonType>
{
    public override ButtonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "reply"=>ButtonType.Reply, _ =>(ButtonType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ButtonType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ButtonType.Reply=>"reply",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Card, CardFromRaw>))]
public sealed record class Card : JsonModel
{
    public CardAction? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardAction>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public CardBody? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CardBody>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    /// <summary>
    /// unique index for each card (0-9)
    /// </summary>
    public long? CardIndex {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "card_index"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("card_index", value);
        }
    }

    public Header? Header {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Header>(
                "header"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("header", value);
        }
    }

    public ApiEnum<string, CardType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CardType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        this.Body?.Validate();
        _ = this.CardIndex;
        this.Header?.Validate();
        this.Type?.Validate();
    }

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
}[JsonConverter(typeof(JsonModelConverter<CardAction, CardActionFromRaw>))]
public sealed record class CardAction : JsonModel
{
    /// <summary>
    /// the unique ID of the catalog
    /// </summary>
    public string? CatalogID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "catalog_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("catalog_id", value);
        }
    }

    /// <summary>
    /// the unique retailer ID of the product
    /// </summary>
    public string? ProductRetailerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product_retailer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_retailer_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CatalogID;
        _ = this.ProductRetailerID;
    }

    public CardAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardAction (CardAction cardAction) : base(cardAction)
    {  }
    #pragma warning restore CS8618

    public CardAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CardAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CardActionFromRaw.FromRawUnchecked"/>
    public static CardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CardActionFromRaw : IFromRawJson<CardAction>
{
    /// <inheritdoc/>
    public CardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CardAction.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CardBody, CardBodyFromRaw>))]
public sealed record class CardBody : JsonModel
{
    /// <summary>
    /// 160 character maximum, up to 2 line breaks
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Text; }

    public CardBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardBody (CardBody cardBody) : base(cardBody)
    {  }
    #pragma warning restore CS8618

    public CardBody (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CardBody (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CardBodyFromRaw.FromRawUnchecked"/>
    public static CardBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CardBodyFromRaw : IFromRawJson<CardBody>
{
    /// <inheritdoc/>
    public CardBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CardBody.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Header, HeaderFromRaw>))]
public sealed record class Header : JsonModel
{
    public WhatsappMedia? Image {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "image"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("image", value);
        }
    }

    public ApiEnum<string, HeaderType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HeaderType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public WhatsappMedia? Video {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "video"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("video", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Image?.Validate();
        this.Type?.Validate();
        this.Video?.Validate();
    }

    public Header ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Header (Header header) : base(header)
    {  }
    #pragma warning restore CS8618

    public Header (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Header (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HeaderFromRaw.FromRawUnchecked"/>
    public static Header FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class HeaderFromRaw : IFromRawJson<Header>
{
    /// <inheritdoc/>
    public Header FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Header.FromRawUnchecked(rawData);
}[JsonConverter(typeof(HeaderTypeConverter))]
public enum HeaderType
{
    Image, Video
}sealed class HeaderTypeConverter : JsonConverter<HeaderType>
{
    public override HeaderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image"=>HeaderType.Image,
            "video"=>HeaderType.Video,
            _ =>(HeaderType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, HeaderType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HeaderType.Image=>"image",
            HeaderType.Video=>"video",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(CardTypeConverter))]
public enum CardType
{
    CtaUrl
}sealed class CardTypeConverter : JsonConverter<CardType>
{
    public override CardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "cta_url"=>CardType.CtaUrl, _ =>(CardType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, CardType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CardType.CtaUrl=>"cta_url",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Parameters, ParametersFromRaw>))]
public sealed record class Parameters : JsonModel
{
    /// <summary>
    /// button label text, 20 character maximum
    /// </summary>
    public string? DisplayText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "display_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("display_text", value);
        }
    }

    /// <summary>
    /// button URL to load when tapped by the user
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayText;
        _ = this.Url;
    }

    public Parameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parameters (Parameters parameters) : base(parameters)
    {  }
    #pragma warning restore CS8618

    public Parameters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Parameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParametersFromRaw.FromRawUnchecked"/>
    public static Parameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ParametersFromRaw : IFromRawJson<Parameters>
{
    /// <inheritdoc/>
    public Parameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Parameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Section, SectionFromRaw>))]
public sealed record class Section : JsonModel
{
    public IReadOnlyList<ProductItem>? ProductItems {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProductItem>>(
                "product_items"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ProductItem>?>(
                "product_items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Row>? Rows {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Row>>(
                "rows"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Row>?>(
                "rows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// section title, 24 character maximum
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ProductItems ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Rows ?? [])
        {
            item.Validate();
        }
        _ = this.Title;
    }

    public Section ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Section (Section section) : base(section)
    {  }
    #pragma warning restore CS8618

    public Section (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Section (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SectionFromRaw.FromRawUnchecked"/>
    public static Section FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SectionFromRaw : IFromRawJson<Section>
{
    /// <inheritdoc/>
    public Section FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Section.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ProductItem, ProductItemFromRaw>))]
public sealed record class ProductItem : JsonModel
{
    public string? ProductRetailerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product_retailer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_retailer_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ProductRetailerID; }

    public ProductItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductItem (ProductItem productItem) : base(productItem)
    {  }
    #pragma warning restore CS8618

    public ProductItem (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProductItemFromRaw.FromRawUnchecked"/>
    public static ProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProductItemFromRaw : IFromRawJson<ProductItem>
{
    /// <inheritdoc/>
    public ProductItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProductItem.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Row, RowFromRaw>))]
public sealed record class Row : JsonModel
{
    /// <summary>
    /// arbitrary string identifying the row, 200 character maximum
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// row description, 72 character maximum
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// row title, 24 character maximum
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Title;
    }

    public Row ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Row (Row row) : base(row)
    {  }
    #pragma warning restore CS8618

    public Row (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Row (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RowFromRaw.FromRawUnchecked"/>
    public static Row FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RowFromRaw : IFromRawJson<Row>
{
    /// <inheritdoc/>
    public Row FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Row.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WhatsappInteractiveBody, WhatsappInteractiveBodyFromRaw>))]
public sealed record class WhatsappInteractiveBody : JsonModel
{
    /// <summary>
    /// body text, 1024 character maximum
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Text; }

    public WhatsappInteractiveBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappInteractiveBody (
        WhatsappInteractiveBody whatsappInteractiveBody
    ) : base(whatsappInteractiveBody)
    {  }
    #pragma warning restore CS8618

    public WhatsappInteractiveBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappInteractiveBody (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappInteractiveBodyFromRaw.FromRawUnchecked"/>
    public static WhatsappInteractiveBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappInteractiveBodyFromRaw : IFromRawJson<WhatsappInteractiveBody>
{
    /// <inheritdoc/>
    public WhatsappInteractiveBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappInteractiveBody.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Footer, FooterFromRaw>))]
public sealed record class Footer : JsonModel
{
    /// <summary>
    /// footer text, 60 character maximum
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Text; }

    public Footer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Footer (Footer footer) : base(footer)
    {  }
    #pragma warning restore CS8618

    public Footer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Footer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FooterFromRaw.FromRawUnchecked"/>
    public static Footer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FooterFromRaw : IFromRawJson<Footer>
{
    /// <inheritdoc/>
    public Footer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Footer.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WhatsappInteractiveHeader, WhatsappInteractiveHeaderFromRaw>))]
public sealed record class WhatsappInteractiveHeader : JsonModel
{
    public WhatsappMedia? Document {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "document"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document", value);
        }
    }

    public WhatsappMedia? Image {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "image"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("image", value);
        }
    }

    public string? SubText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sub_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_text", value);
        }
    }

    /// <summary>
    /// header text, 60 character maximum
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public WhatsappMedia? Video {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "video"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("video", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Document?.Validate();
        this.Image?.Validate();
        _ = this.SubText;
        _ = this.Text;
        this.Video?.Validate();
    }

    public WhatsappInteractiveHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappInteractiveHeader (
        WhatsappInteractiveHeader whatsappInteractiveHeader
    ) : base(whatsappInteractiveHeader)
    {  }
    #pragma warning restore CS8618

    public WhatsappInteractiveHeader (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappInteractiveHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappInteractiveHeaderFromRaw.FromRawUnchecked"/>
    public static WhatsappInteractiveHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappInteractiveHeaderFromRaw : IFromRawJson<WhatsappInteractiveHeader>
{
    /// <inheritdoc/>
    public WhatsappInteractiveHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappInteractiveHeader.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappInteractiveTypeConverter))]
public enum WhatsappInteractiveType
{
    CtaUrl, List, Carousel, Button, LocationRequestMessage
}sealed class WhatsappInteractiveTypeConverter : JsonConverter<WhatsappInteractiveType>
{
    public override WhatsappInteractiveType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cta_url"=>WhatsappInteractiveType.CtaUrl,
            "list"=>WhatsappInteractiveType.List,
            "carousel"=>WhatsappInteractiveType.Carousel,
            "button"=>WhatsappInteractiveType.Button,
            "location_request_message"=>WhatsappInteractiveType.LocationRequestMessage,
            _ =>(WhatsappInteractiveType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappInteractiveType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappInteractiveType.CtaUrl=>"cta_url",
            WhatsappInteractiveType.List=>"list",
            WhatsappInteractiveType.Carousel=>"carousel",
            WhatsappInteractiveType.Button=>"button",
            WhatsappInteractiveType.LocationRequestMessage=>"location_request_message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}