using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ReplacedLinkClickWebhookEvent, ReplacedLinkClickWebhookEventFromRaw>))]
public sealed record class ReplacedLinkClickWebhookEvent : JsonModel
{
    public ReplacedLinkClick? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacedLinkClick>(
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

    public ReplacedLinkClickWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplacedLinkClickWebhookEvent (
        ReplacedLinkClickWebhookEvent replacedLinkClickWebhookEvent
    ) : base(replacedLinkClickWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ReplacedLinkClickWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacedLinkClickWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReplacedLinkClickWebhookEventFromRaw.FromRawUnchecked"/>
    public static ReplacedLinkClickWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReplacedLinkClickWebhookEventFromRaw : IFromRawJson<ReplacedLinkClickWebhookEvent>
{
    /// <inheritdoc/>
    public ReplacedLinkClickWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReplacedLinkClickWebhookEvent.FromRawUnchecked(rawData);
}