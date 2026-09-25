using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations.ConversationInsights;

/// <summary>
/// Aggregate conversation insights by specified fields
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConversationInsightRetrieveAggregatesParams : ParamsBase
{
    /// <summary>
    /// Filter by creation datetime to scope the aggregation window. Supports range
    /// operators (e.g., `created_at=gte.2025-01-01T00:00:00Z` for the start of the
    /// range, `created_at=lt.2025-01-02T00:00:00Z` for the end). To build per-day
    /// time series (as the portal does for the 'Insights Over Time' chart), issue
    /// one request per day bounded by `created_at=gte.&lt;day_start&gt;` and `created_at=lt.&lt;next_day_start&gt;`.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Fields to group by (can be comma-separated or multiple parameters). Prefix
    /// a field with 'metadata.' (e.g. 'metadata.assistant_id') to group by the conversation's
    /// metadata instead of the insight result.
    ///
    /// <para>Common fields used for over-time charts: - `score` — Group by the insight's
    /// score value (e.g. for Agent Instruction Following, User Satisfaction). - `metadata.assistant_id`
    /// — Group by the assistant that handled the conversation. - `metadata.assistant_version_id`
    /// — Group by the assistant version, useful for comparing performance across
    /// versions in the portal's 'Insights Over Time' chart. - `metadata.telnyx_conversation_channel`
    /// — Group by conversation channel (phone_call, web_chat, etc.).</para>
    /// </summary>
    public IReadOnlyList<string>? GroupBy {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "group_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "group_by",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional insight ID to filter conversation insights. Only insights matching
    /// this ID will be included in the aggregation.
    /// </summary>
    public string? InsightID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "insight_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("insight_id", value);
        }
    }

    public Metadata? Metadata {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Metadata>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Fields to include in the result (can be comma-separated or multiple parameters).
    /// Supports the same 'metadata.&lt;key&gt;' prefix as group_by. Each returned
    /// row will contain the grouped field values plus a `record_count` indicating
    /// how many conversation insights match that combination.
    /// </summary>
    public IReadOnlyList<string>? Show {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "show"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "show",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ConversationInsightRetrieveAggregatesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationInsightRetrieveAggregatesParams (
        ConversationInsightRetrieveAggregatesParams conversationInsightRetrieveAggregatesParams
    ) : base(conversationInsightRetrieveAggregatesParams)
    {  }
    #pragma warning restore CS8618

    public ConversationInsightRetrieveAggregatesParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationInsightRetrieveAggregatesParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConversationInsightRetrieveAggregatesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(
        ConversationInsightRetrieveAggregatesParams? other
    )
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/conversations/conversation-insights/aggregates"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// Filter by assistant ID (e.g., `metadata.assistant_id=eq.&lt;assistant_id&gt;`).
    /// When provided, only conversation insights for the specified assistant are
    /// aggregated. Used by the portal to scope the 'Insights Over Time' chart to
    /// a single assistant.
    /// </summary>
    public string? AssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "assistant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assistant_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.AssistantID; }

    public Metadata ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata (Metadata metadata) : base(metadata)
    {  }
    #pragma warning restore CS8618

    public Metadata (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Metadata.FromRawUnchecked(rawData);
}