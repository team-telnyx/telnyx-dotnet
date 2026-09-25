using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentRetrieveResponse, DocumentRetrieveResponseFromRaw>))]
public sealed record class DocumentRetrieveResponse : JsonModel
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

    public DocumentRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentRetrieveResponse (
        DocumentRetrieveResponse documentRetrieveResponse
    ) : base(documentRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DocumentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentRetrieveResponseFromRaw : IFromRawJson<DocumentRetrieveResponse>
{
    /// <inheritdoc/>
    public DocumentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentRetrieveResponse.FromRawUnchecked(rawData);
}