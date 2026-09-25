using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<InboundThreadDetail, InboundThreadDetailFromRaw>))]
public sealed record class InboundThreadDetail : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string InboxID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "inbox_id"
            );
        }
        init { this._rawData.Set("inbox_id", value); }
    }

    /// <summary>
    /// Mutable thread labels used for agent workflow state. Independent of the labels
    /// on the thread's messages, and distinct from the send-time `tags` on outbound messages.
    /// </summary>
    public required IReadOnlyList<string> Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "labels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required DateTimeOffset LastMessageAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "last_message_at"
            );
        }
        init { this._rawData.Set("last_message_at", value); }
    }

    public required string LastMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "last_message_id"
            );
        }
        init { this._rawData.Set("last_message_id", value); }
    }

    /// <summary>
    /// Total inbound and outbound messages in the thread.
    /// </summary>
    public required long MessageCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "message_count"
            );
        }
        init { this._rawData.Set("message_count", value); }
    }

    public required string? Preview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "preview"
            );
        }
        init { this._rawData.Set("preview", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Unread inbound messages; outbound messages never increment this count.
    /// </summary>
    public required long UnreadCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "unread_count"
            );
        }
        init { this._rawData.Set("unread_count", value); }
    }

    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public required IReadOnlyList<ThreadMessage> Messages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ThreadMessage>>(
                "messages"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ThreadMessage>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator InboundThread (
        InboundThreadDetail inboundThreadDetail
    )=> new() {
        ID = inboundThreadDetail.ID,
        CreatedAt = inboundThreadDetail.CreatedAt,
        InboxID = inboundThreadDetail.InboxID,
        Labels = inboundThreadDetail.Labels,
        LastMessageAt = inboundThreadDetail.LastMessageAt,
        LastMessageID = inboundThreadDetail.LastMessageID,
        MessageCount = inboundThreadDetail.MessageCount,
        Preview = inboundThreadDetail.Preview,
        RecordType = inboundThreadDetail.RecordType,
        Subject = inboundThreadDetail.Subject,
        UnreadCount = inboundThreadDetail.UnreadCount,
        UpdatedAt = inboundThreadDetail.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.InboxID;
        _ = this.Labels;
        _ = this.LastMessageAt;
        _ = this.LastMessageID;
        _ = this.MessageCount;
        _ = this.Preview;
        this.RecordType.Validate();
        _ = this.Subject;
        _ = this.UnreadCount;
        _ = this.UpdatedAt;
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
    }

    public InboundThreadDetail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundThreadDetail (InboundThreadDetail inboundThreadDetail) : base(
        inboundThreadDetail
    )
    {  }
    #pragma warning restore CS8618

    public InboundThreadDetail (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundThreadDetail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundThreadDetailFromRaw.FromRawUnchecked"/>
    public static InboundThreadDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundThreadDetailFromRaw : IFromRawJson<InboundThreadDetail>
{
    /// <inheritdoc/>
    public InboundThreadDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundThreadDetail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public required IReadOnlyList<ThreadMessage> Messages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ThreadMessage>>(
                "messages"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ThreadMessage>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
    }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public IntersectionMember1 (IReadOnlyList<ThreadMessage> messages) : this()
    { this.Messages = messages; }
}class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}