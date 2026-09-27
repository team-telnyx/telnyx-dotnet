using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

/// <summary>
/// Optional footer displayed at the bottom of the message. Does not support variables.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateFooterComponent, WhatsappTemplateFooterComponentFromRaw>))]
public sealed record class WhatsappTemplateFooterComponent : JsonModel
{
    public required ApiEnum<string, WhatsappTemplateFooterComponentType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappTemplateFooterComponentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// OTP code expiration time in minutes. Used in AUTHENTICATION template footers
    /// instead of free-form text.
    /// </summary>
    public long? CodeExpirationMinutes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "code_expiration_minutes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code_expiration_minutes", value);
        }
    }

    /// <summary>
    /// Footer text. Maximum 60 characters. For non-authentication templates.
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
        _ = this.CodeExpirationMinutes;
        _ = this.Text;
    }

    public WhatsappTemplateFooterComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateFooterComponent (
        WhatsappTemplateFooterComponent whatsappTemplateFooterComponent
    ) : base(whatsappTemplateFooterComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateFooterComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateFooterComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateFooterComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateFooterComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WhatsappTemplateFooterComponent (
        ApiEnum<string, WhatsappTemplateFooterComponentType> type
    ) : this()
    { this.Type = type; }
}

class WhatsappTemplateFooterComponentFromRaw : IFromRawJson<WhatsappTemplateFooterComponent>
{
    /// <inheritdoc/>
    public WhatsappTemplateFooterComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateFooterComponent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WhatsappTemplateFooterComponentTypeConverter))]
public enum WhatsappTemplateFooterComponentType
{
    Footer
}sealed class WhatsappTemplateFooterComponentTypeConverter : JsonConverter<WhatsappTemplateFooterComponentType>
{
    public override WhatsappTemplateFooterComponentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FOOTER"=>WhatsappTemplateFooterComponentType.Footer,
            _ =>(WhatsappTemplateFooterComponentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappTemplateFooterComponentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappTemplateFooterComponentType.Footer=>"FOOTER",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}