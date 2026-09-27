using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageSendLongCodeResponse, MessageSendLongCodeResponseFromRaw>))]
public sealed record class MessageSendLongCodeResponse : JsonModel
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

    public MessageSendLongCodeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendLongCodeResponse (
        MessageSendLongCodeResponse messageSendLongCodeResponse
    ) : base(messageSendLongCodeResponse)
    {  }
    #pragma warning restore CS8618

    public MessageSendLongCodeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendLongCodeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendLongCodeResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendLongCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageSendLongCodeResponseFromRaw : IFromRawJson<MessageSendLongCodeResponse>
{
    /// <inheritdoc/>
    public MessageSendLongCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageSendLongCodeResponse.FromRawUnchecked(rawData);
}