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

[JsonConverter(typeof(JsonModelConverter<WhatsappMessageContent, WhatsappMessageContentFromRaw>))]
public sealed record class WhatsappMessageContent : JsonModel
{
    public WhatsappMedia? Audio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "audio"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("audio", value);
        }
    }

    /// <summary>
    /// custom data to return with status update
    /// </summary>
    public string? BizOpaqueCallbackData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "biz_opaque_callback_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("biz_opaque_callback_data", value);
        }
    }

    public IReadOnlyList<WhatsappContact>? Contacts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WhatsappContact>>(
                "contacts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WhatsappContact>?>(
                "contacts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public WhatsappInteractive? Interactive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappInteractive>(
                "interactive"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interactive", value);
        }
    }

    public WhatsappLocation? Location {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappLocation>(
                "location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    public WhatsappReaction? Reaction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappReaction>(
                "reaction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reaction", value);
        }
    }

    public WhatsappMedia? Sticker {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMedia>(
                "sticker"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sticker", value);
        }
    }

    /// <summary>
    /// Template message object. Provide either template_id or name + language to
    /// identify the template.
    /// </summary>
    public Template? Template {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Template>(
                "template"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("template", value);
        }
    }

    /// <summary>
    /// Text message content. Can only be sent within a 24-hour customer service window.
    /// </summary>
    public WhatsappMessageContentText? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMessageContentText>(
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

    public ApiEnum<string, WhatsappMessageContentType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WhatsappMessageContentType>>(
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
        this.Audio?.Validate();
        _ = this.BizOpaqueCallbackData;
        foreach (var item in this.Contacts ?? [])
        {
            item.Validate();
        }
        this.Document?.Validate();
        this.Image?.Validate();
        this.Interactive?.Validate();
        this.Location?.Validate();
        this.Reaction?.Validate();
        this.Sticker?.Validate();
        this.Template?.Validate();
        this.Text?.Validate();
        this.Type?.Validate();
        this.Video?.Validate();
    }

    public WhatsappMessageContent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageContent (
        WhatsappMessageContent whatsappMessageContent
    ) : base(whatsappMessageContent)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageContent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageContent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageContentFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappMessageContentFromRaw : IFromRawJson<WhatsappMessageContent>
{
    /// <inheritdoc/>
    public WhatsappMessageContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageContent.FromRawUnchecked(rawData);
}

/// <summary>
/// Template message object. Provide either template_id or name + language to identify
/// the template.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    /// <summary>
    /// Template parameter values for header, body, and button components.
    /// </summary>
    public IReadOnlyList<Component>? Components {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Component>>(
                "components"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Component>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template language. Required unless template_id is provided.
    /// </summary>
    public Language? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Language>(
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
    /// Template name as registered with Meta. Required unless template_id is provided.
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
    /// Telnyx template ID (the id field from template list/get responses). When provided,
    /// name and language are resolved automatically.
    /// </summary>
    public string? TemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("template_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Components ?? [])
        {
            item.Validate();
        }
        this.Language?.Validate();
        _ = this.Name;
        _ = this.TemplateID;
    }

    public Template ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template (Template template) : base(template)
    {  }
    #pragma warning restore CS8618

    public Template (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Template (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Template.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Component, ComponentFromRaw>))]
public sealed record class Component : JsonModel
{
    /// <summary>
    /// Button index (required for button components)
    /// </summary>
    public long? Index {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "index"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("index", value);
        }
    }

    public IReadOnlyList<Parameter>? Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Parameter>>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Parameter>?>(
                "parameters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, SubType>? SubType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubType>>(
                "sub_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_type", value);
        }
    }

    public ApiEnum<string, ComponentType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ComponentType>>(
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
        _ = this.Index;
        foreach (var item in this.Parameters ?? [])
        {
            item.Validate();
        }
        this.SubType?.Validate();
        this.Type?.Validate();
    }

    public Component ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Component (Component component) : base(component)
    {  }
    #pragma warning restore CS8618

    public Component (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Component (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ComponentFromRaw.FromRawUnchecked"/>
    public static Component FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ComponentFromRaw : IFromRawJson<Component>
{
    /// <inheritdoc/>
    public Component FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Component.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Parameter, ParameterFromRaw>))]
public sealed record class Parameter : JsonModel
{
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

    public ApiEnum<string, ParameterType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParameterType>>(
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
        _ = this.Text;
        this.Type?.Validate();
    }

    public Parameter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parameter (Parameter parameter) : base(parameter)
    {  }
    #pragma warning restore CS8618

    public Parameter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Parameter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParameterFromRaw.FromRawUnchecked"/>
    public static Parameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ParameterFromRaw : IFromRawJson<Parameter>
{
    /// <inheritdoc/>
    public Parameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Parameter.FromRawUnchecked(rawData);
}[JsonConverter(typeof(ParameterTypeConverter))]
public enum ParameterType
{
    Text, Image, Video, Document, Currency, DateTime
}sealed class ParameterTypeConverter : JsonConverter<ParameterType>
{
    public override ParameterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text"=>ParameterType.Text,
            "image"=>ParameterType.Image,
            "video"=>ParameterType.Video,
            "document"=>ParameterType.Document,
            "currency"=>ParameterType.Currency,
            "date_time"=>ParameterType.DateTime,
            _ =>(ParameterType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParameterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ParameterType.Text=>"text",
            ParameterType.Image=>"image",
            ParameterType.Video=>"video",
            ParameterType.Document=>"document",
            ParameterType.Currency=>"currency",
            ParameterType.DateTime=>"date_time",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(SubTypeConverter))]
public enum SubType
{
    QuickReply, Url
}sealed class SubTypeConverter : JsonConverter<SubType>
{
    public override SubType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quick_reply"=>SubType.QuickReply,
            "url"=>SubType.Url,
            _ =>(SubType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SubType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SubType.QuickReply=>"quick_reply",
            SubType.Url=>"url",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(ComponentTypeConverter))]
public enum ComponentType
{
    Header, Body, Button
}sealed class ComponentTypeConverter : JsonConverter<ComponentType>
{
    public override ComponentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "header"=>ComponentType.Header,
            "body"=>ComponentType.Body,
            "button"=>ComponentType.Button,
            _ =>(ComponentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComponentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ComponentType.Header=>"header",
            ComponentType.Body=>"body",
            ComponentType.Button=>"button",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Template language. Required unless template_id is provided.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Language, LanguageFromRaw>))]
public sealed record class Language : JsonModel
{
    /// <summary>
    /// Language code (e.g. en_US)
    /// </summary>
    public required string Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    public string? Policy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "policy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("policy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Policy;
    }

    public Language ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Language (Language language) : base(language)
    {  }
    #pragma warning restore CS8618

    public Language (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Language (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LanguageFromRaw.FromRawUnchecked"/>
    public static Language FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Language (string code) : this()
    { this.Code = code; }
}class LanguageFromRaw : IFromRawJson<Language>
{
    /// <inheritdoc/>
    public Language FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Language.FromRawUnchecked(rawData);
}/// <summary>
/// Text message content. Can only be sent within a 24-hour customer service window.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappMessageContentText, WhatsappMessageContentTextFromRaw>))]
public sealed record class WhatsappMessageContentText : JsonModel
{
    /// <summary>
    /// The text message body.
    /// </summary>
    public required string Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "body"
            );
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Whether to show a URL preview in the message.
    /// </summary>
    public bool? PreviewUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "preview_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("preview_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.PreviewUrl;
    }

    public WhatsappMessageContentText ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageContentText (
        WhatsappMessageContentText whatsappMessageContentText
    ) : base(whatsappMessageContentText)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageContentText (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageContentText (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageContentTextFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageContentText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WhatsappMessageContentText (string body) : this()
    { this.Body = body; }
}class WhatsappMessageContentTextFromRaw : IFromRawJson<WhatsappMessageContentText>
{
    /// <inheritdoc/>
    public WhatsappMessageContentText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageContentText.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappMessageContentTypeConverter))]
public enum WhatsappMessageContentType
{
    Audio,
    Document,
    Image,
    Sticker,
    Video,
    Interactive,
    Location,
    Template,
    Reaction,
    Contacts,
    Text
}sealed class WhatsappMessageContentTypeConverter : JsonConverter<WhatsappMessageContentType>
{
    public override WhatsappMessageContentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio"=>WhatsappMessageContentType.Audio,
            "document"=>WhatsappMessageContentType.Document,
            "image"=>WhatsappMessageContentType.Image,
            "sticker"=>WhatsappMessageContentType.Sticker,
            "video"=>WhatsappMessageContentType.Video,
            "interactive"=>WhatsappMessageContentType.Interactive,
            "location"=>WhatsappMessageContentType.Location,
            "template"=>WhatsappMessageContentType.Template,
            "reaction"=>WhatsappMessageContentType.Reaction,
            "contacts"=>WhatsappMessageContentType.Contacts,
            "text"=>WhatsappMessageContentType.Text,
            _ =>(WhatsappMessageContentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageContentType.Audio=>"audio",
            WhatsappMessageContentType.Document=>"document",
            WhatsappMessageContentType.Image=>"image",
            WhatsappMessageContentType.Sticker=>"sticker",
            WhatsappMessageContentType.Video=>"video",
            WhatsappMessageContentType.Interactive=>"interactive",
            WhatsappMessageContentType.Location=>"location",
            WhatsappMessageContentType.Template=>"template",
            WhatsappMessageContentType.Reaction=>"reaction",
            WhatsappMessageContentType.Contacts=>"contacts",
            WhatsappMessageContentType.Text=>"text",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}