using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

/// <summary>
/// Optional header displayed at the top of the message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateHeaderComponent, WhatsappTemplateHeaderComponentFromRaw>))]
public sealed record class WhatsappTemplateHeaderComponent : JsonModel
{
    /// <summary>
    /// Header format type: TEXT (supports one variable), IMAGE, VIDEO, DOCUMENT,
    /// or LOCATION.
    /// </summary>
    public required ApiEnum<string, Format> Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init { this._rawData.Set("format", value); }
    }

    public required ApiEnum<string, WhatsappTemplateHeaderComponentType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappTemplateHeaderComponentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Sample values for header variables.
    /// </summary>
    public WhatsappTemplateHeaderComponentExample? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappTemplateHeaderComponentExample>(
                "example"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("example", value);
        }
    }

    /// <summary>
    /// Header text. Required when format is TEXT. Supports one variable ({{1}}).
    /// Variables cannot be at the start or end.
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
        this.Format.Validate();
        this.Type.Validate();
        this.Example?.Validate();
        _ = this.Text;
    }

    public WhatsappTemplateHeaderComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateHeaderComponent (
        WhatsappTemplateHeaderComponent whatsappTemplateHeaderComponent
    ) : base(whatsappTemplateHeaderComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateHeaderComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateHeaderComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateHeaderComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateHeaderComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappTemplateHeaderComponentFromRaw : IFromRawJson<WhatsappTemplateHeaderComponent>
{
    /// <inheritdoc/>
    public WhatsappTemplateHeaderComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateHeaderComponent.FromRawUnchecked(rawData);
}

/// <summary>
/// Header format type: TEXT (supports one variable), IMAGE, VIDEO, DOCUMENT, or LOCATION.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Text, Image, Video, Document, Location
}sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TEXT"=>Format.Text,
            "IMAGE"=>Format.Image,
            "VIDEO"=>Format.Video,
            "DOCUMENT"=>Format.Document,
            "LOCATION"=>Format.Location,
            _ =>(Format)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Text=>"TEXT",
            Format.Image=>"IMAGE",
            Format.Video=>"VIDEO",
            Format.Document=>"DOCUMENT",
            Format.Location=>"LOCATION",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappTemplateHeaderComponentTypeConverter))]
public enum WhatsappTemplateHeaderComponentType
{
    Header
}sealed class WhatsappTemplateHeaderComponentTypeConverter : JsonConverter<WhatsappTemplateHeaderComponentType>
{
    public override WhatsappTemplateHeaderComponentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HEADER"=>WhatsappTemplateHeaderComponentType.Header,
            _ =>(WhatsappTemplateHeaderComponentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappTemplateHeaderComponentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappTemplateHeaderComponentType.Header=>"HEADER",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Sample values for header variables.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateHeaderComponentExample, WhatsappTemplateHeaderComponentExampleFromRaw>))]
public sealed record class WhatsappTemplateHeaderComponentExample : JsonModel
{
    /// <summary>
    /// Media handle for IMAGE, VIDEO, or DOCUMENT headers.
    /// </summary>
    public IReadOnlyList<string>? HeaderHandle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "header_handle"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "header_handle",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sample values for text header variables.
    /// </summary>
    public IReadOnlyList<string>? HeaderText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "header_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "header_text",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HeaderHandle;
        _ = this.HeaderText;
    }

    public WhatsappTemplateHeaderComponentExample ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateHeaderComponentExample (
        WhatsappTemplateHeaderComponentExample whatsappTemplateHeaderComponentExample
    ) : base(whatsappTemplateHeaderComponentExample)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateHeaderComponentExample (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateHeaderComponentExample (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateHeaderComponentExampleFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateHeaderComponentExample FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappTemplateHeaderComponentExampleFromRaw : IFromRawJson<WhatsappTemplateHeaderComponentExample>
{
    /// <inheritdoc/>
    public WhatsappTemplateHeaderComponentExample FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateHeaderComponentExample.FromRawUnchecked(rawData);
}