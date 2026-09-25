using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailThreads;

/// <summary>
/// Returns a thread and a bounded page of its inbound and outbound messages, interleaved
/// in chronological order. The `inbox_id` returned by the list endpoint is required
/// because a thread ID can occur in multiple inboxes. Only messages matching that
/// `(inbox_id, thread_id)` pair are returned. Threads outside the account return
/// an opaque 404.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailThreadRetrieveParams : ParamsBase
{
    public string? ThreadID { get; init; }

    /// <summary>
    /// Inbox UUID that, together with `thread_id`, identifies the thread.
    /// </summary>
    public required string InboxID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "inbox_id"
            );
        }
        init { this._rawQueryData.Set("inbox_id", value); }
    }

    /// <summary>
    /// Opaque message cursor returned by the previous thread-detail page.
    /// </summary>
    public string? PageAfter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[after]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[after]", value);
        }
    }

    /// <summary>
    /// Number of thread messages to return. Defaults to 25; maximum is 100.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public EmailThreadRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailThreadRetrieveParams (
        EmailThreadRetrieveParams emailThreadRetrieveParams
    ) : base(emailThreadRetrieveParams)
    { this.ThreadID = emailThreadRetrieveParams.ThreadID; }
    #pragma warning restore CS8618

    public EmailThreadRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailThreadRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string threadID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ThreadID = threadID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailThreadRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string threadID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            threadID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ThreadID"] = JsonSerializer.SerializeToElement(this.ThreadID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailThreadRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ThreadID?.Equals(other.ThreadID) ?? other.ThreadID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_threads/{0}",
            this.ThreadID)
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