using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateListPageResponse, TemplateListPageResponseFromRaw>))]
public sealed record class TemplateListPageResponse : JsonModel
{
    public IReadOnlyList<WhatsappTemplateData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WhatsappTemplateData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WhatsappTemplateData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingPaginationMeta0b38e7044b? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingPaginationMeta0b38e7044b>(
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

    public TemplateListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateListPageResponse (
        TemplateListPageResponse templateListPageResponse
    ) : base(templateListPageResponse)
    {  }
    #pragma warning restore CS8618

    public TemplateListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TemplateListPageResponseFromRaw.FromRawUnchecked"/>
    public static TemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TemplateListPageResponseFromRaw : IFromRawJson<TemplateListPageResponse>
{
    /// <inheritdoc/>
    public TemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TemplateListPageResponse.FromRawUnchecked(rawData);
}