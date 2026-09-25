using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

[JsonConverter(typeof(JsonModelConverter<WebhookDeliveryListPageResponse, WebhookDeliveryListPageResponseFromRaw>))]
public sealed record class WebhookDeliveryListPageResponse : JsonModel
{
    public IReadOnlyList<WebhookDelivery>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookDelivery>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookDelivery>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMetaSimple? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMetaSimple>(
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

    public WebhookDeliveryListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDeliveryListPageResponse (
        WebhookDeliveryListPageResponse webhookDeliveryListPageResponse
    ) : base(webhookDeliveryListPageResponse)
    {  }
    #pragma warning restore CS8618

    public WebhookDeliveryListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDeliveryListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDeliveryListPageResponseFromRaw.FromRawUnchecked"/>
    public static WebhookDeliveryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookDeliveryListPageResponseFromRaw : IFromRawJson<WebhookDeliveryListPageResponse>
{
    /// <inheritdoc/>
    public WebhookDeliveryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookDeliveryListPageResponse.FromRawUnchecked(rawData);
}