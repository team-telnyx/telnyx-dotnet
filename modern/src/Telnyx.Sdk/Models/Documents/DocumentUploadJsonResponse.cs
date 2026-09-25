using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentUploadJsonResponse, DocumentUploadJsonResponseFromRaw>))]
public sealed record class DocumentUploadJsonResponse : JsonModel
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

    public DocumentUploadJsonResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUploadJsonResponse (
        DocumentUploadJsonResponse documentUploadJsonResponse
    ) : base(documentUploadJsonResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentUploadJsonResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUploadJsonResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentUploadJsonResponseFromRaw.FromRawUnchecked"/>
    public static DocumentUploadJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentUploadJsonResponseFromRaw : IFromRawJson<DocumentUploadJsonResponse>
{
    /// <inheritdoc/>
    public DocumentUploadJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentUploadJsonResponse.FromRawUnchecked(rawData);
}