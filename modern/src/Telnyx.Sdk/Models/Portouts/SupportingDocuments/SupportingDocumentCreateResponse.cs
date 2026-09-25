using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts.SupportingDocuments;

[JsonConverter(typeof(JsonModelConverter<SupportingDocumentCreateResponse, SupportingDocumentCreateResponseFromRaw>))]
public sealed record class SupportingDocumentCreateResponse : JsonModel
{
    public IReadOnlyList<PortOutSupportingDocument>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortOutSupportingDocument>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortOutSupportingDocument>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public SupportingDocumentCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SupportingDocumentCreateResponse (
        SupportingDocumentCreateResponse supportingDocumentCreateResponse
    ) : base(supportingDocumentCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SupportingDocumentCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SupportingDocumentCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SupportingDocumentCreateResponseFromRaw.FromRawUnchecked"/>
    public static SupportingDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SupportingDocumentCreateResponseFromRaw : IFromRawJson<SupportingDocumentCreateResponse>
{
    /// <inheritdoc/>
    public SupportingDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SupportingDocumentCreateResponse.FromRawUnchecked(rawData);
}