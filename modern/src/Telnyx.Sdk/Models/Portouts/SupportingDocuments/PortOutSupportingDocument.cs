using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.SupportingDocuments;

[JsonConverter(typeof(JsonModelConverter<PortOutSupportingDocument, PortOutSupportingDocumentFromRaw>))]
public sealed record class PortOutSupportingDocument : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Supporting document creation timestamp in ISO 8601 format
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Identifies the associated document
    /// </summary>
    public required string DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "document_id"
            );
        }
        init { this._rawData.Set("document_id", value); }
    }

    /// <summary>
    /// Identifies the associated port request
    /// </summary>
    public required string PortoutID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "portout_id"
            );
        }
        init { this._rawData.Set("portout_id", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Identifies the type of the document
    /// </summary>
    public required ApiEnum<string, PortOutSupportingDocumentType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PortOutSupportingDocumentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Supporting document last changed timestamp in ISO 8601 format
    /// </summary>
    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DocumentID;
        _ = this.PortoutID;
        _ = this.RecordType;
        this.Type.Validate();
        _ = this.UpdatedAt;
    }

    public PortOutSupportingDocument ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortOutSupportingDocument (
        PortOutSupportingDocument portOutSupportingDocument
    ) : base(portOutSupportingDocument)
    {  }
    #pragma warning restore CS8618

    public PortOutSupportingDocument (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortOutSupportingDocument (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortOutSupportingDocumentFromRaw.FromRawUnchecked"/>
    public static PortOutSupportingDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortOutSupportingDocumentFromRaw : IFromRawJson<PortOutSupportingDocument>
{
    /// <inheritdoc/>
    public PortOutSupportingDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortOutSupportingDocument.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the document
/// </summary>
[JsonConverter(typeof(PortOutSupportingDocumentTypeConverter))]
public enum PortOutSupportingDocumentType
{
    Loa, Invoice
}sealed class PortOutSupportingDocumentTypeConverter : JsonConverter<PortOutSupportingDocumentType>
{
    public override PortOutSupportingDocumentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loa"=>PortOutSupportingDocumentType.Loa,
            "invoice"=>PortOutSupportingDocumentType.Invoice,
            _ =>(PortOutSupportingDocumentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortOutSupportingDocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortOutSupportingDocumentType.Loa=>"loa",
            PortOutSupportingDocumentType.Invoice=>"invoice",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}