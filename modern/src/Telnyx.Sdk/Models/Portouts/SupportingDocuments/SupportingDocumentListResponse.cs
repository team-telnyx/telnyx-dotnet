using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts.SupportingDocuments;

[JsonConverter(typeof(JsonModelConverter<SupportingDocumentListResponse, SupportingDocumentListResponseFromRaw>))]
public sealed record class SupportingDocumentListResponse : JsonModel
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

    public SupportingDocumentListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SupportingDocumentListResponse (
        SupportingDocumentListResponse supportingDocumentListResponse
    ) : base(supportingDocumentListResponse)
    {  }
    #pragma warning restore CS8618

    public SupportingDocumentListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SupportingDocumentListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SupportingDocumentListResponseFromRaw.FromRawUnchecked"/>
    public static SupportingDocumentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SupportingDocumentListResponseFromRaw : IFromRawJson<SupportingDocumentListResponse>
{
    /// <inheritdoc/>
    public SupportingDocumentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SupportingDocumentListResponse.FromRawUnchecked(rawData);
}