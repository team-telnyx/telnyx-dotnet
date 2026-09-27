using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageSendShortCodeResponse, MessageSendShortCodeResponseFromRaw>))]
public sealed record class MessageSendShortCodeResponse : JsonModel
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

    public MessageSendShortCodeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendShortCodeResponse (
        MessageSendShortCodeResponse messageSendShortCodeResponse
    ) : base(messageSendShortCodeResponse)
    {  }
    #pragma warning restore CS8618

    public MessageSendShortCodeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendShortCodeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendShortCodeResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendShortCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageSendShortCodeResponseFromRaw : IFromRawJson<MessageSendShortCodeResponse>
{
    /// <inheritdoc/>
    public MessageSendShortCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageSendShortCodeResponse.FromRawUnchecked(rawData);
}