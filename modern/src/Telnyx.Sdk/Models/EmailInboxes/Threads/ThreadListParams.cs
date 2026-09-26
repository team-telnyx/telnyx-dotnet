using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

/// <summary>
/// Lists thread summaries newest first using stable cursor pagination.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ThreadListParams : ParamsBase
{
    public string? InboxID { get; init; }

    /// <summary>
    /// Returns only threads carrying this label. Thread labels are independent of
    /// the labels on the thread's messages.
    /// </summary>
    public string? FilterLabel {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[label]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[label]", value);
        }
    }

    /// <summary>
    /// Opaque cursor returned by the previous page.
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
    /// Number of results to return. Defaults to 25; maximum is 100.
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

    public ThreadListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadListParams (ThreadListParams threadListParams) : base(
        threadListParams
    )
    { this.InboxID = threadListParams.InboxID; }
    #pragma warning restore CS8618

    public ThreadListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string inboxID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.InboxID = inboxID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ThreadListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string inboxID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            inboxID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ThreadListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InboxID?.Equals(other.InboxID) ?? other.InboxID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_inboxes/{0}/threads",
            EncodePathSegment(this.InboxID))
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