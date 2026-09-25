using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageSendWithAlphanumericSenderResponse, MessageSendWithAlphanumericSenderResponseFromRaw>))]
public sealed record class MessageSendWithAlphanumericSenderResponse : JsonModel
{
    public OutboundMessagePayload? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayload>(
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

    public MessageSendWithAlphanumericSenderResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendWithAlphanumericSenderResponse (
        MessageSendWithAlphanumericSenderResponse messageSendWithAlphanumericSenderResponse
    ) : base(messageSendWithAlphanumericSenderResponse)
    {  }
    #pragma warning restore CS8618

    public MessageSendWithAlphanumericSenderResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendWithAlphanumericSenderResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendWithAlphanumericSenderResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendWithAlphanumericSenderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageSendWithAlphanumericSenderResponseFromRaw : IFromRawJson<MessageSendWithAlphanumericSenderResponse>
{
    /// <inheritdoc/>
    public MessageSendWithAlphanumericSenderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageSendWithAlphanumericSenderResponse.FromRawUnchecked(rawData);
}