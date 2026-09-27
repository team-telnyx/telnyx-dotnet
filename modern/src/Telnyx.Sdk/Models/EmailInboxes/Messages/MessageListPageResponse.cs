using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;
using Telnyx.Sdk.Models.Webhooks;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListPageResponse, MessageListPageResponseFromRaw>))]
public sealed record class MessageListPageResponse : JsonModel
{
    public required IReadOnlyList<InboundMessage> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InboundMessage>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InboundMessage>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required EmailPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPaginationMeta>(
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

    public MessageListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListPageResponse (
        MessageListPageResponse messageListPageResponse
    ) : base(messageListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessageListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageListPageResponseFromRaw : IFromRawJson<MessageListPageResponse>
{
    /// <inheritdoc/>
    public MessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageListPageResponse.FromRawUnchecked(rawData);
}