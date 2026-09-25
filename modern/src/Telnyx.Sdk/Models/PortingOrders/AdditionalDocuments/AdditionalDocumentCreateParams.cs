using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

/// <summary>
/// Creates a list of additional documents for a porting order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AdditionalDocumentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public IReadOnlyList<AdditionalDocument>? AdditionalDocuments {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AdditionalDocument>>(
                "additional_documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AdditionalDocument>?>(
                "additional_documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AdditionalDocumentCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalDocumentCreateParams (
        AdditionalDocumentCreateParams additionalDocumentCreateParams
    ) : base(additionalDocumentCreateParams)
    {
        this.ID = additionalDocumentCreateParams.ID;

        this._rawBodyData = new(additionalDocumentCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AdditionalDocumentCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalDocumentCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AdditionalDocumentCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AdditionalDocumentCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/additional_documents",
            this.ID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<AdditionalDocument, AdditionalDocumentFromRaw>))]
public sealed record class AdditionalDocument : JsonModel
{
    /// <summary>
    /// The document identification
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
    /// The type of document being created.
    /// </summary>
    public ApiEnum<string, DocumentType>? DocumentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocumentType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentID;
        this.DocumentType?.Validate();
    }

    public AdditionalDocument ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalDocument (AdditionalDocument additionalDocument) : base(
        additionalDocument
    )
    {  }
    #pragma warning restore CS8618

    public AdditionalDocument (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalDocument (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalDocumentFromRaw.FromRawUnchecked"/>
    public static AdditionalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdditionalDocumentFromRaw : IFromRawJson<AdditionalDocument>
{
    /// <inheritdoc/>
    public AdditionalDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdditionalDocument.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of document being created.
/// </summary>
[JsonConverter(typeof(DocumentTypeConverter))]
public enum DocumentType
{
    Loa, Invoice, Csr, Other
}

sealed class DocumentTypeConverter : JsonConverter<DocumentType>
{
    public override DocumentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loa"=>DocumentType.Loa,
            "invoice"=>DocumentType.Invoice,
            "csr"=>DocumentType.Csr,
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
            DocumentType.Loa=>"loa",
            DocumentType.Invoice=>"invoice",
            DocumentType.Csr=>"csr",
            DocumentType.Other=>"other",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}