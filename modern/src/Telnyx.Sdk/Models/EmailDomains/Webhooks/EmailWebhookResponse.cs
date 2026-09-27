using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains.Webhooks;

[JsonConverter(typeof(JsonModelConverter<EmailWebhookResponse, EmailWebhookResponseFromRaw>))]
public sealed record class EmailWebhookResponse : JsonModel
{
    public required EmailWebhook Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailWebhook>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailWebhookResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailWebhookResponse (
        EmailWebhookResponse emailWebhookResponse
    ) : base(emailWebhookResponse)
    {  }
    #pragma warning restore CS8618

    public EmailWebhookResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailWebhookResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailWebhookResponseFromRaw.FromRawUnchecked"/>
    public static EmailWebhookResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailWebhookResponse (EmailWebhook data) : this()
    { this.Data = data; }
}

class EmailWebhookResponseFromRaw : IFromRawJson<EmailWebhookResponse>
{
    /// <inheritdoc/>
    public EmailWebhookResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailWebhookResponse.FromRawUnchecked(rawData);
}