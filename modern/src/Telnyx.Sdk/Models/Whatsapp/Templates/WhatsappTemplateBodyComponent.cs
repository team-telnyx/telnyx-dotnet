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
/// The main text content of the message. Supports multiple variable parameters ({{1}},
/// {{2}}, etc.). Variables cannot be at the start or end. Maximum 1024 characters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateBodyComponent, WhatsappTemplateBodyComponentFromRaw>))]
public sealed record class WhatsappTemplateBodyComponent : JsonModel
{
    public required ApiEnum<string, global::Telnyx.Sdk.Models.Whatsapp.Templates.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.Whatsapp.Templates.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Sample values for body variables. Required when body text contains parameters.
    /// </summary>
    public Example? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Example>(
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
    /// Body text content. Use {{1}}, {{2}}, etc. for variable placeholders. Required
    /// for MARKETING and UTILITY templates. Optional for AUTHENTICATION templates
    /// where Meta provides the built-in OTP body.
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
        this.Type.Validate();
        this.Example?.Validate();
        _ = this.Text;
    }

    public WhatsappTemplateBodyComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateBodyComponent (
        WhatsappTemplateBodyComponent whatsappTemplateBodyComponent
    ) : base(whatsappTemplateBodyComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateBodyComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateBodyComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateBodyComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateBodyComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WhatsappTemplateBodyComponent (
        ApiEnum<string, global::Telnyx.Sdk.Models.Whatsapp.Templates.Type> type
    ) : this()
    { this.Type = type; }
}

class WhatsappTemplateBodyComponentFromRaw : IFromRawJson<WhatsappTemplateBodyComponent>
{
    /// <inheritdoc/>
    public WhatsappTemplateBodyComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateBodyComponent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Body
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Whatsapp.Templates.Type>
{
    public override global::Telnyx.Sdk.Models.Whatsapp.Templates.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BODY"=>global::Telnyx.Sdk.Models.Whatsapp.Templates.Type.Body,
            _ =>(global::Telnyx.Sdk.Models.Whatsapp.Templates.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Whatsapp.Templates.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Whatsapp.Templates.Type.Body=>"BODY",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Sample values for body variables. Required when body text contains parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Example, ExampleFromRaw>))]
public sealed record class Example : JsonModel
{
    /// <summary>
    /// Array containing one array of sample values, one per variable in order.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<string>>? BodyText {
        get {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<string>>>(
                "body_text"
            );
            if (value == null) {
                return null;
            }

            return ImmutableArray.ToImmutableArray(Enumerable.Select(value.Value, ( item )=>(IReadOnlyList<string>)item));
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<string>>?>(
                "body_text",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>ImmutableArray.ToImmutableArray(item)))
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.BodyText; }

    public Example ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Example (Example example) : base(example)
    {  }
    #pragma warning restore CS8618

    public Example (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Example (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExampleFromRaw.FromRawUnchecked"/>
    public static Example FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ExampleFromRaw : IFromRawJson<Example>
{
    /// <inheritdoc/>
    public Example FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Example.FromRawUnchecked(rawData);
}