using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations;

/// <summary>
/// Retrieve a list of all AI conversations configured by the user. Supports [PostgREST-style
/// query parameters](https://postgrest.org/en/stable/api.html#horizontal-filtering-rows)
/// for filtering. Examples are included for the standard metadata fields, but you
/// can filter on any field in the metadata JSON object. For example, to filter by
/// a custom field `metadata-&gt;custom_field`, use `metadata-&gt;custom_field=eq.value`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConversationListParams : ParamsBase
{
    /// <summary>
    /// Filter by conversation ID (e.g. id=eq.123)
    /// </summary>
    public string? ID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("id", value);
        }
    }

    /// <summary>
    /// Filter by creation datetime (e.g., `created_at=gte.2025-01-01`)
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
    /// Filter by last message datetime (e.g., `last_message_at=lte.2025-06-01`)
    /// </summary>
    public string? LastMessageAt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "last_message_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("last_message_at", value);
        }
    }

    /// <summary>
    /// Limit the number of returned conversations (e.g., `limit=10`)
    /// </summary>
    public long? Limit {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by assistant ID (e.g., `metadata-&gt;assistant_id=eq.assistant-123`)
    /// </summary>
    public string? MetadataAssistantID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "metadata->assistant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata->assistant_id", value);
        }
    }

    /// <summary>
    /// Filter by call control ID (e.g., `metadata-&gt;call_control_id=eq.v3:123`)
    /// </summary>
    public string? MetadataCallControlID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "metadata->call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata->call_control_id", value);
        }
    }

    /// <summary>
    /// Filter by the phone number, SIP URI, or other identifier for the agent (e.g., `metadata-&gt;telnyx_agent_target=eq.+13128675309`)
    /// </summary>
    public string? MetadataTelnyxAgentTarget {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "metadata->telnyx_agent_target"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata->telnyx_agent_target", value);
        }
    }

    /// <summary>
    /// Filter by conversation channel (e.g., `metadata-&gt;telnyx_conversation_channel=eq.phone_call`)
    /// </summary>
    public string? MetadataTelnyxConversationChannel {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "metadata->telnyx_conversation_channel"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata->telnyx_conversation_channel", value);
        }
    }

    /// <summary>
    /// Filter by the phone number, SIP URI, or other identifier for the end user
    /// (e.g., `metadata-&gt;telnyx_end_user_target=eq.+13128675309`)
    /// </summary>
    public string? MetadataTelnyxEndUserTarget {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "metadata->telnyx_end_user_target"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("metadata->telnyx_end_user_target", value);
        }
    }

    /// <summary>
    /// Filter by conversation Name (e.g. `name=like.Voice%`)
    /// </summary>
    public string? Name {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("name", value);
        }
    }

    /// <summary>
    /// Apply OR conditions using PostgREST syntax (e.g., `or=(created_at.gte.2025-04-01,last_message_at.gte.2025-04-01)`)
    /// </summary>
    public string? Or {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "or"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("or", value);
        }
    }

    /// <summary>
    /// Order the results by specific fields (e.g., `order=created_at.desc` or `order=last_message_at.asc`)
    /// </summary>
    public string? Order {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "order"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("order", value);
        }
    }

    public ConversationListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListParams (
        ConversationListParams conversationListParams
    ) : base(conversationListParams)
    {  }
    #pragma warning restore CS8618

    public ConversationListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConversationListParams FromRawUnchecked(
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

    public virtual bool Equals(ConversationListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/conversations"
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