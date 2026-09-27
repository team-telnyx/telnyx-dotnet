using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

[JsonConverter(typeof(JsonModelConverter<AdditionalDocumentListPageResponse, AdditionalDocumentListPageResponseFromRaw>))]
public sealed record class AdditionalDocumentListPageResponse : JsonModel
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

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public AdditionalDocumentListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalDocumentListPageResponse (
        AdditionalDocumentListPageResponse additionalDocumentListPageResponse
    ) : base(additionalDocumentListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AdditionalDocumentListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalDocumentListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalDocumentListPageResponseFromRaw.FromRawUnchecked"/>
    public static AdditionalDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdditionalDocumentListPageResponseFromRaw : IFromRawJson<AdditionalDocumentListPageResponse>
{
    /// <inheritdoc/>
    public AdditionalDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdditionalDocumentListPageResponse.FromRawUnchecked(rawData);
}