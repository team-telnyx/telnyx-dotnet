using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Conversations;

[JsonConverter(typeof(JsonModelConverter<ConversationRetrieveConversationsInsightsResponse, ConversationRetrieveConversationsInsightsResponseFromRaw>))]
public sealed record class ConversationRetrieveConversationsInsightsResponse : JsonModel
{
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
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

    public ConversationRetrieveConversationsInsightsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRetrieveConversationsInsightsResponse (
        ConversationRetrieveConversationsInsightsResponse conversationRetrieveConversationsInsightsResponse
    ) : base(conversationRetrieveConversationsInsightsResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationRetrieveConversationsInsightsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRetrieveConversationsInsightsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRetrieveConversationsInsightsResponseFromRaw.FromRawUnchecked"/>
    public static ConversationRetrieveConversationsInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationRetrieveConversationsInsightsResponseFromRaw : IFromRawJson<ConversationRetrieveConversationsInsightsResponse>
{
    /// <inheritdoc/>
    public ConversationRetrieveConversationsInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRetrieveConversationsInsightsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique identifier for the conversation insight.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// List of insights extracted from the conversation.
    /// </summary>
    public required IReadOnlyList<ConversationInsight> ConversationInsights {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ConversationInsight>>(
                "conversation_insights"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ConversationInsight>>(
                "conversation_insights",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp of when the object was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Current status of the insight generation for the conversation.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.ConversationInsights)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.Status.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ConversationInsight, ConversationInsightFromRaw>))]
public sealed record class ConversationInsight : JsonModel
{
    /// <summary>
    /// Unique identifier for the insight configuration.
    /// </summary>
    public required string InsightID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "insight_id"
            );
        }
        init { this._rawData.Set("insight_id", value); }
    }

    /// <summary>
    /// Insight result from the conversation. If the insight has a JSON schema, this
    /// will be stringified JSON object.
    /// </summary>
    public required string Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InsightID;
        _ = this.Result;
    }

    public ConversationInsight ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationInsight (ConversationInsight conversationInsight) : base(
        conversationInsight
    )
    {  }
    #pragma warning restore CS8618

    public ConversationInsight (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationInsight (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationInsightFromRaw.FromRawUnchecked"/>
    public static ConversationInsight FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ConversationInsightFromRaw : IFromRawJson<ConversationInsight>
{
    /// <inheritdoc/>
    public ConversationInsight FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationInsight.FromRawUnchecked(rawData);
}/// <summary>
/// Current status of the insight generation for the conversation.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, InProgress, Completed, Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "in_progress"=>Status.InProgress,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.InProgress=>"in_progress",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}