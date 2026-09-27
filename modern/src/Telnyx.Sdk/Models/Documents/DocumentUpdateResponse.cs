using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentUpdateResponse, DocumentUpdateResponseFromRaw>))]
public sealed record class DocumentUpdateResponse : JsonModel
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

    public DocumentUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUpdateResponse (
        DocumentUpdateResponse documentUpdateResponse
    ) : base(documentUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentUpdateResponseFromRaw.FromRawUnchecked"/>
    public static DocumentUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentUpdateResponseFromRaw : IFromRawJson<DocumentUpdateResponse>
{
    /// <inheritdoc/>
    public DocumentUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentUpdateResponse.FromRawUnchecked(rawData);
}