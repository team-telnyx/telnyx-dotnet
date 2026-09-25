using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageSendGroupMmsResponse, MessageSendGroupMmsResponseFromRaw>))]
public sealed record class MessageSendGroupMmsResponse : JsonModel
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

    public MessageSendGroupMmsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendGroupMmsResponse (
        MessageSendGroupMmsResponse messageSendGroupMmsResponse
    ) : base(messageSendGroupMmsResponse)
    {  }
    #pragma warning restore CS8618

    public MessageSendGroupMmsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendGroupMmsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendGroupMmsResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendGroupMmsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageSendGroupMmsResponseFromRaw : IFromRawJson<MessageSendGroupMmsResponse>
{
    /// <inheritdoc/>
    public MessageSendGroupMmsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageSendGroupMmsResponse.FromRawUnchecked(rawData);
}