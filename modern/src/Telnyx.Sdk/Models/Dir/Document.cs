using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// Id returned by the Telnyx Documents API after you upload the file (upload
    /// via `POST /v2/documents`; see https://developers.telnyx.com/api/documents).
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
    /// Type of supporting document. Pick the closest match to what the file actually
    /// contains; `other` triggers manual vetting and may slow approval. The matching
    /// short_name reference list is at `GET /v2/dir/document_types`.
    /// </summary>
    public required ApiEnum<string, DocumentType> DocumentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DocumentType>>(
                "document_type"
            );
        }
        init { this._rawData.Set("document_type", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentID;
        this.DocumentType.Validate();
        _ = this.Description;
    }

    public Document ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document (Document document) : base(document)
    {  }
    #pragma warning restore CS8618

    public Document (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Document (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Document.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of supporting document. Pick the closest match to what the file actually
/// contains; `other` triggers manual vetting and may slow approval. The matching
/// short_name reference list is at `GET /v2/dir/document_types`.
/// </summary>
[JsonConverter(typeof(DocumentTypeConverter))]
public enum DocumentType
{
    LetterOfAuthorization,
    BusinessRegistration,
    ArticlesOfIncorporation,
    TaxDocument,
    EinLetter,
    TrademarkRegistration,
    WebsiteOwnership,
    BusinessLicense,
    ProfessionalLicense,
    GovernmentID,
    UtilityBill,
    BankStatement,
    Other
}sealed class DocumentTypeConverter : JsonConverter<DocumentType>
{
    public override DocumentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "letter_of_authorization"=>DocumentType.LetterOfAuthorization,
            "business_registration"=>DocumentType.BusinessRegistration,
            "articles_of_incorporation"=>DocumentType.ArticlesOfIncorporation,
            "tax_document"=>DocumentType.TaxDocument,
            "ein_letter"=>DocumentType.EinLetter,
            "trademark_registration"=>DocumentType.TrademarkRegistration,
            "website_ownership"=>DocumentType.WebsiteOwnership,
            "business_license"=>DocumentType.BusinessLicense,
            "professional_license"=>DocumentType.ProfessionalLicense,
            "government_id"=>DocumentType.GovernmentID,
            "utility_bill"=>DocumentType.UtilityBill,
            "bank_statement"=>DocumentType.BankStatement,
            "other"=>DocumentType.Other,
            _ =>(DocumentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DocumentType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DocumentType.LetterOfAuthorization=>"letter_of_authorization",
            DocumentType.BusinessRegistration=>"business_registration",
            DocumentType.ArticlesOfIncorporation=>"articles_of_incorporation",
            DocumentType.TaxDocument=>"tax_document",
            DocumentType.EinLetter=>"ein_letter",
            DocumentType.TrademarkRegistration=>"trademark_registration",
            DocumentType.WebsiteOwnership=>"website_ownership",
            DocumentType.BusinessLicense=>"business_license",
            DocumentType.ProfessionalLicense=>"professional_license",
            DocumentType.GovernmentID=>"government_id",
            DocumentType.UtilityBill=>"utility_bill",
            DocumentType.BankStatement=>"bank_statement",
            DocumentType.Other=>"other",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}