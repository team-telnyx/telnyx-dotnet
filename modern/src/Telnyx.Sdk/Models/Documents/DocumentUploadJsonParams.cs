using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

/// <summary>
/// Upload a document.&lt;br /&gt;&lt;br /&gt;Uploaded files must be linked to a service
/// within 30 minutes or they will be automatically deleted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DocumentUploadJsonParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required DocumentUploadJsonParamsDocument Document {
        get {
            return WrappedJsonSerializer.GetNotNullClass<DocumentUploadJsonParamsDocument>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public DocumentUploadJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUploadJsonParams (
        DocumentUploadJsonParams documentUploadJsonParams
    ) : base(documentUploadJsonParams)
    { this.RawBodyData = documentUploadJsonParams.RawBodyData; }
    #pragma warning restore CS8618

    public DocumentUploadJsonParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUploadJsonParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DocumentUploadJsonParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DocumentUploadJsonParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/documents"
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

[JsonConverter(typeof(JsonModelConverter<DocumentUploadJsonParamsDocument, DocumentUploadJsonParamsDocumentFromRaw>))]
public sealed record class DocumentUploadJsonParamsDocument : JsonModel
{
    /// <summary>
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Alternatively, instead of the URL you can provide the Base64 encoded contents
    /// of the file you are uploading.
    /// </summary>
    public string? File {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file", value);
        }
    }

    /// <summary>
    /// The filename of the document.
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
    /// If the file is already hosted publicly, you can provide a URL and have the
    /// documents service fetch it for you.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomerReference;
        _ = this.File;
        _ = this.Filename;
        _ = this.Url;
    }

    public DocumentUploadJsonParamsDocument ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUploadJsonParamsDocument (
        DocumentUploadJsonParamsDocument documentUploadJsonParamsDocument
    ) : base(documentUploadJsonParamsDocument)
    {  }
    #pragma warning restore CS8618

    public DocumentUploadJsonParamsDocument (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUploadJsonParamsDocument (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentUploadJsonParamsDocumentFromRaw.FromRawUnchecked"/>
    public static DocumentUploadJsonParamsDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentUploadJsonParamsDocumentFromRaw : IFromRawJson<DocumentUploadJsonParamsDocument>
{
    /// <inheritdoc/>
    public DocumentUploadJsonParamsDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentUploadJsonParamsDocument.FromRawUnchecked(rawData);
}