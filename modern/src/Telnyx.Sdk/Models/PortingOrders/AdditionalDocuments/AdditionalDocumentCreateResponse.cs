using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

[JsonConverter(typeof(JsonModelConverter<AdditionalDocumentCreateResponse, AdditionalDocumentCreateResponseFromRaw>))]
public sealed record class AdditionalDocumentCreateResponse : JsonModel
{
    public IReadOnlyList<PortingAdditionalDocument>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingAdditionalDocument>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingAdditionalDocument>?>(
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

    public AdditionalDocumentCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalDocumentCreateResponse (
        AdditionalDocumentCreateResponse additionalDocumentCreateResponse
    ) : base(additionalDocumentCreateResponse)
    {  }
    #pragma warning restore CS8618

    public AdditionalDocumentCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalDocumentCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalDocumentCreateResponseFromRaw.FromRawUnchecked"/>
    public static AdditionalDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdditionalDocumentCreateResponseFromRaw : IFromRawJson<AdditionalDocumentCreateResponse>
{
    /// <inheritdoc/>
    public AdditionalDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdditionalDocumentCreateResponse.FromRawUnchecked(rawData);
}