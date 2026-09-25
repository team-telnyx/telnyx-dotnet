using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Conversations.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListPageResponse, MessageListPageResponseFromRaw>))]
public sealed record class MessageListPageResponse : JsonModel
{
    public required IReadOnlyList<MessageListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MessageListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
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