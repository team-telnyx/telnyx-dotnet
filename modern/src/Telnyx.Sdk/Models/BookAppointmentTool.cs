using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<BookAppointmentTool, BookAppointmentToolFromRaw>))]
public sealed record class BookAppointmentTool : JsonModel
{
    public required BookAppointmentToolParams BookAppointment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BookAppointmentToolParams>(
                "book_appointment"
            );
        }
        init { this._rawData.Set("book_appointment", value); }
    }

    public required ApiEnum<string, BookAppointmentToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BookAppointmentToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BookAppointment.Validate();
        this.Type.Validate();
    }

    public BookAppointmentTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookAppointmentTool (BookAppointmentTool bookAppointmentTool) : base(
        bookAppointmentTool
    )
    {  }
    #pragma warning restore CS8618

    public BookAppointmentTool (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BookAppointmentTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BookAppointmentToolFromRaw.FromRawUnchecked"/>
    public static BookAppointmentTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BookAppointmentToolFromRaw : IFromRawJson<BookAppointmentTool>
{
    /// <inheritdoc/>
    public BookAppointmentTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BookAppointmentTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BookAppointmentToolTypeConverter))]
public enum BookAppointmentToolType
{
    BookAppointment
}sealed class BookAppointmentToolTypeConverter : JsonConverter<BookAppointmentToolType>
{
    public override BookAppointmentToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "book_appointment"=>BookAppointmentToolType.BookAppointment,
            _ =>(BookAppointmentToolType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BookAppointmentToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BookAppointmentToolType.BookAppointment=>"book_appointment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}