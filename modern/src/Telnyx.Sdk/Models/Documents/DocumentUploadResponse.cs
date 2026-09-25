using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentUploadResponse, DocumentUploadResponseFromRaw>))]
public sealed record class DocumentUploadResponse : JsonModel
{
    public DocServiceDocument? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocServiceDocument>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public DocumentUploadResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUploadResponse (
        DocumentUploadResponse documentUploadResponse
    ) : base(documentUploadResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentUploadResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUploadResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentUploadResponseFromRaw.FromRawUnchecked"/>
    public static DocumentUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentUploadResponseFromRaw : IFromRawJson<DocumentUploadResponse>
{
    /// <inheritdoc/>
    public DocumentUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentUploadResponse.FromRawUnchecked(rawData);
}