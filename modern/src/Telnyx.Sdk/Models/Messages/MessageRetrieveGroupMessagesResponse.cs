using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageRetrieveGroupMessagesResponse, MessageRetrieveGroupMessagesResponseFromRaw>))]
public sealed record class MessageRetrieveGroupMessagesResponse : JsonModel
{
    public IReadOnlyList<OutboundMessagePayload>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutboundMessagePayload>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OutboundMessagePayload>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public MessageRetrieveGroupMessagesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveGroupMessagesResponse (
        MessageRetrieveGroupMessagesResponse messageRetrieveGroupMessagesResponse
    ) : base(messageRetrieveGroupMessagesResponse)
    {  }
    #pragma warning restore CS8618

    public MessageRetrieveGroupMessagesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveGroupMessagesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveGroupMessagesResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveGroupMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageRetrieveGroupMessagesResponseFromRaw : IFromRawJson<MessageRetrieveGroupMessagesResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveGroupMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageRetrieveGroupMessagesResponse.FromRawUnchecked(rawData);
}