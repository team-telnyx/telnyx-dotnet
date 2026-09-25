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

[JsonConverter(typeof(JsonModelConverter<RcsAgentMessage, RcsAgentMessageFromRaw>))]
public sealed record class RcsAgentMessage : JsonModel
{
    public ContentMessage? ContentMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContentMessage>(
                "content_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_message", value);
        }
    }

    /// <summary>
    /// RCS Event to send to the recipient
    /// </summary>
    public Event? Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Event>(
                "event"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event", value);
        }
    }

    /// <summary>
    /// Timestamp in UTC of when this message is considered expired
    /// </summary>
    public System::DateTimeOffset? ExpireTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expire_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expire_time", value);
        }
    }

    /// <summary>
    /// Duration in seconds ending with 's'
    /// </summary>
    public string? Ttl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ttl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ttl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentMessage?.Validate();
        this.Event?.Validate();
        _ = this.ExpireTime;
        _ = this.Ttl;
    }

    public RcsAgentMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsAgentMessage (RcsAgentMessage rcsAgentMessage) : base(
        rcsAgentMessage
    )
    {  }
    #pragma warning restore CS8618

    public RcsAgentMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsAgentMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsAgentMessageFromRaw.FromRawUnchecked"/>
    public static RcsAgentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsAgentMessageFromRaw : IFromRawJson<RcsAgentMessage>
{
    /// <inheritdoc/>
    public RcsAgentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsAgentMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ContentMessage, ContentMessageFromRaw>))]
public sealed record class ContentMessage : JsonModel
{
    public RcsContentInfo? ContentInfo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsContentInfo>(
                "content_info"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_info", value);
        }
    }

    public RichCard? RichCard {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RichCard>(
                "rich_card"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rich_card", value);
        }
    }

    /// <summary>
    /// List of suggested actions and replies
    /// </summary>
    public IReadOnlyList<RcsSuggestion>? Suggestions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsSuggestion>>(
                "suggestions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RcsSuggestion>?>(
                "suggestions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Text (maximum 3072 characters)
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
    {
        this.ContentInfo?.Validate();
        this.RichCard?.Validate();
        foreach (var item in this.Suggestions ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
    }

    public ContentMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContentMessage (ContentMessage contentMessage) : base(contentMessage)
    {  }
    #pragma warning restore CS8618

    public ContentMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContentMessageFromRaw.FromRawUnchecked"/>
    public static ContentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ContentMessageFromRaw : IFromRawJson<ContentMessage>
{
    /// <inheritdoc/>
    public ContentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ContentMessage.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<RichCard, RichCardFromRaw>))]
public sealed record class RichCard : JsonModel
{
    /// <summary>
    /// Carousel of cards.
    /// </summary>
    public CarouselCard? CarouselCard {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CarouselCard>(
                "carousel_card"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carousel_card", value);
        }
    }

    /// <summary>
    /// Standalone card
    /// </summary>
    public StandaloneCard? StandaloneCard {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StandaloneCard>(
                "standalone_card"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("standalone_card", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CarouselCard?.Validate();
        this.StandaloneCard?.Validate();
    }

    public RichCard ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RichCard (RichCard richCard) : base(richCard)
    {  }
    #pragma warning restore CS8618

    public RichCard (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RichCard (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RichCardFromRaw.FromRawUnchecked"/>
    public static RichCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RichCardFromRaw : IFromRawJson<RichCard>
{
    /// <inheritdoc/>
    public RichCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RichCard.FromRawUnchecked(rawData);
}/// <summary>
/// Carousel of cards.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CarouselCard, CarouselCardFromRaw>))]
public sealed record class CarouselCard : JsonModel
{
    /// <summary>
    /// The list of contents for each card in the carousel. A carousel can have a
    /// minimum of 2 cards and a maximum 10 cards.
    /// </summary>
    public required IReadOnlyList<RcsCardContent> CardContents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RcsCardContent>>(
                "card_contents"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<RcsCardContent>>(
                "card_contents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The width of the cards in the carousel.
    /// </summary>
    public required ApiEnum<string, CardWidth> CardWidth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardWidth>>(
                "card_width"
            );
        }
        init { this._rawData.Set("card_width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.CardContents)
        {
            item.Validate();
        }
        this.CardWidth.Validate();
    }

    public CarouselCard ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CarouselCard (CarouselCard carouselCard) : base(carouselCard)
    {  }
    #pragma warning restore CS8618

    public CarouselCard (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CarouselCard (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CarouselCardFromRaw.FromRawUnchecked"/>
    public static CarouselCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CarouselCardFromRaw : IFromRawJson<CarouselCard>
{
    /// <inheritdoc/>
    public CarouselCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CarouselCard.FromRawUnchecked(rawData);
}/// <summary>
/// The width of the cards in the carousel.
/// </summary>
[JsonConverter(typeof(CardWidthConverter))]
public enum CardWidth
{
    CardWidthUnspecified, Small, Medium
}sealed class CardWidthConverter : JsonConverter<CardWidth>
{
    public override CardWidth Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD_WIDTH_UNSPECIFIED"=>CardWidth.CardWidthUnspecified,
            "SMALL"=>CardWidth.Small,
            "MEDIUM"=>CardWidth.Medium,
            _ =>(CardWidth)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CardWidth value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CardWidth.CardWidthUnspecified=>"CARD_WIDTH_UNSPECIFIED",
            CardWidth.Small=>"SMALL",
            CardWidth.Medium=>"MEDIUM",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Standalone card
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StandaloneCard, StandaloneCardFromRaw>))]
public sealed record class StandaloneCard : JsonModel
{
    public required RcsCardContent CardContent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RcsCardContent>(
                "card_content"
            );
        }
        init { this._rawData.Set("card_content", value); }
    }

    /// <summary>
    /// Orientation of the card.
    /// </summary>
    public required ApiEnum<string, CardOrientation> CardOrientation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CardOrientation>>(
                "card_orientation"
            );
        }
        init { this._rawData.Set("card_orientation", value); }
    }

    /// <summary>
    /// Image preview alignment for standalone cards with horizontal layout.
    /// </summary>
    public required ApiEnum<string, ThumbnailImageAlignment> ThumbnailImageAlignment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ThumbnailImageAlignment>>(
                "thumbnail_image_alignment"
            );
        }
        init { this._rawData.Set("thumbnail_image_alignment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CardContent.Validate();
        this.CardOrientation.Validate();
        this.ThumbnailImageAlignment.Validate();
    }

    public StandaloneCard ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StandaloneCard (StandaloneCard standaloneCard) : base(standaloneCard)
    {  }
    #pragma warning restore CS8618

    public StandaloneCard (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StandaloneCard (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StandaloneCardFromRaw.FromRawUnchecked"/>
    public static StandaloneCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class StandaloneCardFromRaw : IFromRawJson<StandaloneCard>
{
    /// <inheritdoc/>
    public StandaloneCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StandaloneCard.FromRawUnchecked(rawData);
}/// <summary>
/// Orientation of the card.
/// </summary>
[JsonConverter(typeof(CardOrientationConverter))]
public enum CardOrientation
{
    CardOrientationUnspecified, Horizontal, Vertical
}sealed class CardOrientationConverter : JsonConverter<CardOrientation>
{
    public override CardOrientation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD_ORIENTATION_UNSPECIFIED"=>CardOrientation.CardOrientationUnspecified,
            "HORIZONTAL"=>CardOrientation.Horizontal,
            "VERTICAL"=>CardOrientation.Vertical,
            _ =>(CardOrientation)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CardOrientation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CardOrientation.CardOrientationUnspecified=>"CARD_ORIENTATION_UNSPECIFIED",
            CardOrientation.Horizontal=>"HORIZONTAL",
            CardOrientation.Vertical=>"VERTICAL",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Image preview alignment for standalone cards with horizontal layout.
/// </summary>
[JsonConverter(typeof(ThumbnailImageAlignmentConverter))]
public enum ThumbnailImageAlignment
{
    ThumbnailImageAlignmentUnspecified, Left, Right
}sealed class ThumbnailImageAlignmentConverter : JsonConverter<ThumbnailImageAlignment>
{
    public override ThumbnailImageAlignment Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "THUMBNAIL_IMAGE_ALIGNMENT_UNSPECIFIED"=>ThumbnailImageAlignment.ThumbnailImageAlignmentUnspecified,
            "LEFT"=>ThumbnailImageAlignment.Left,
            "RIGHT"=>ThumbnailImageAlignment.Right,
            _ =>(ThumbnailImageAlignment)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThumbnailImageAlignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ThumbnailImageAlignment.ThumbnailImageAlignmentUnspecified=>"THUMBNAIL_IMAGE_ALIGNMENT_UNSPECIFIED",
            ThumbnailImageAlignment.Left=>"LEFT",
            ThumbnailImageAlignment.Right=>"RIGHT",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// RCS Event to send to the recipient
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    public ApiEnum<string, EventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.EventType?.Validate(); }

    public Event ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event (Event event_) : base(event_)
    {  }
    #pragma warning restore CS8618

    public Event (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Event (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Event.FromRawUnchecked(rawData);
}[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    TypeUnspecified, IsTyping, Read
}sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TYPE_UNSPECIFIED"=>EventType.TypeUnspecified,
            "IS_TYPING"=>EventType.IsTyping,
            "READ"=>EventType.Read,
            _ =>(EventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EventType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EventType.TypeUnspecified=>"TYPE_UNSPECIFIED",
            EventType.IsTyping=>"IS_TYPING",
            EventType.Read=>"READ",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}