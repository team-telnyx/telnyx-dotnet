using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

[JsonConverter(typeof(JsonModelConverter<WebhookDeliveryRetrieveResponse, WebhookDeliveryRetrieveResponseFromRaw>))]
public sealed record class WebhookDeliveryRetrieveResponse : JsonModel
{
    /// <summary>
    /// Record of all attempts to deliver a webhook.
    /// </summary>
    public WebhookDelivery? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookDelivery>(
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

    public WebhookDeliveryRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDeliveryRetrieveResponse (
        WebhookDeliveryRetrieveResponse webhookDeliveryRetrieveResponse
    ) : base(webhookDeliveryRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public WebhookDeliveryRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDeliveryRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDeliveryRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WebhookDeliveryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookDeliveryRetrieveResponseFromRaw : IFromRawJson<WebhookDeliveryRetrieveResponse>
{
    /// <inheritdoc/>
    public WebhookDeliveryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookDeliveryRetrieveResponse.FromRawUnchecked(rawData);
}