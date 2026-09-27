using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookListPageResponse, WebhookListPageResponseFromRaw>))]
public sealed record class WebhookListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailWebhook> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailWebhook>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailWebhook>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required OffsetPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OffsetPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public WebhookListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListPageResponse (
        WebhookListPageResponse webhookListPageResponse
    ) : base(webhookListPageResponse)
    {  }
    #pragma warning restore CS8618

    public WebhookListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListPageResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookListPageResponseFromRaw : IFromRawJson<WebhookListPageResponse>
{
    /// <inheritdoc/>
    public WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookListPageResponse.FromRawUnchecked(rawData);
}