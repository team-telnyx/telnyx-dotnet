using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

[JsonConverter(typeof(JsonModelConverter<PortingAdditionalDocument, PortingAdditionalDocumentFromRaw>))]
public sealed record class PortingAdditionalDocument : JsonModel
{
    /// <summary>
    /// Uniquely identifies this additional document
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
    /// The content type of the related document.
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Identifies the associated document
    /// </summary>
    public string? DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "document_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of additional document
    /// </summary>
    public ApiEnum<string, PortingAdditionalDocumentDocumentType>? DocumentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingAdditionalDocumentDocumentType>>(
                "document_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_type", value);
        }
    }

    /// <summary>
    /// The filename of the related document.
    /// </summary>
    public string? Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "filename"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// Identifies the associated porting order
    /// </summary>
    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ContentType;
        _ = this.CreatedAt;
        _ = this.DocumentID;
        this.DocumentType?.Validate();
        _ = this.Filename;
        _ = this.PortingOrderID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingAdditionalDocument ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingAdditionalDocument (
        PortingAdditionalDocument portingAdditionalDocument
    ) : base(portingAdditionalDocument)
    {  }
    #pragma warning restore CS8618

    public PortingAdditionalDocument (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingAdditionalDocument (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingAdditionalDocumentFromRaw.FromRawUnchecked"/>
    public static PortingAdditionalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingAdditionalDocumentFromRaw : IFromRawJson<PortingAdditionalDocument>
{
    /// <inheritdoc/>
    public PortingAdditionalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingAdditionalDocument.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of additional document
/// </summary>
[JsonConverter(typeof(PortingAdditionalDocumentDocumentTypeConverter))]
public enum PortingAdditionalDocumentDocumentType
{
    Loa, Invoice, Csr, Other
}sealed class PortingAdditionalDocumentDocumentTypeConverter : JsonConverter<PortingAdditionalDocumentDocumentType>
{
    public override PortingAdditionalDocumentDocumentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loa"=>PortingAdditionalDocumentDocumentType.Loa,
            "invoice"=>PortingAdditionalDocumentDocumentType.Invoice,
            "csr"=>PortingAdditionalDocumentDocumentType.Csr,
            "other"=>PortingAdditionalDocumentDocumentType.Other,
            _ =>(PortingAdditionalDocumentDocumentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingAdditionalDocumentDocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingAdditionalDocumentDocumentType.Loa=>"loa",
            PortingAdditionalDocumentDocumentType.Invoice=>"invoice",
            PortingAdditionalDocumentDocumentType.Csr=>"csr",
            PortingAdditionalDocumentDocumentType.Other=>"other",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}