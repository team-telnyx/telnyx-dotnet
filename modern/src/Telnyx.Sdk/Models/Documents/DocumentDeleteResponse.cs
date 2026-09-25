using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentDeleteResponse, DocumentDeleteResponseFromRaw>))]
public sealed record class DocumentDeleteResponse : JsonModel
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

    public DocumentDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentDeleteResponse (
        DocumentDeleteResponse documentDeleteResponse
    ) : base(documentDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public DocumentDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocumentDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DocumentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocumentDeleteResponseFromRaw : IFromRawJson<DocumentDeleteResponse>
{
    /// <inheritdoc/>
    public DocumentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocumentDeleteResponse.FromRawUnchecked(rawData);
}