using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageSendNumberPoolResponse, MessageSendNumberPoolResponseFromRaw>))]
public sealed record class MessageSendNumberPoolResponse : JsonModel
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

    public MessageSendNumberPoolResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendNumberPoolResponse (
        MessageSendNumberPoolResponse messageSendNumberPoolResponse
    ) : base(messageSendNumberPoolResponse)
    {  }
    #pragma warning restore CS8618

    public MessageSendNumberPoolResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendNumberPoolResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageSendNumberPoolResponseFromRaw.FromRawUnchecked"/>
    public static MessageSendNumberPoolResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageSendNumberPoolResponseFromRaw : IFromRawJson<MessageSendNumberPoolResponse>
{
    /// <inheritdoc/>
    public MessageSendNumberPoolResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageSendNumberPoolResponse.FromRawUnchecked(rawData);
}