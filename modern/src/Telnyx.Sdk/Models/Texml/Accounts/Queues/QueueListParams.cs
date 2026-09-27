using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Queues;

/// <summary>
/// Returns a paginated list of queue resources for the account, with support for
/// filtering by creation or update dates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class QueueListParams : ParamsBase
{
    public string? AccountSid { get; init; }

    /// <summary>
    /// Filters conferences by the creation date. Expected format is YYYY-MM-DD.
    /// Also accepts inequality operators, e.g. DateCreated&gt;=2023-05-22.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "DateCreated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("DateCreated", value);
        }
    }

    /// <summary>
    /// Filters conferences by the time they were last updated. Expected format is
    /// YYYY-MM-DD. Also accepts inequality operators, e.g. DateUpdated&gt;=2023-05-22.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "DateUpdated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("DateUpdated", value);
        }
    }

    /// <summary>
    /// The number of the page to be displayed, zero-indexed, should be used in conjuction
    /// with PageToken.
    /// </summary>
    public long? Page {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "Page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("Page", value);
        }
    }

    /// <summary>
    /// The number of records to be displayed on a page
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "PageSize"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageSize", value);
        }
    }

    /// <summary>
    /// Used to request the next page of results.
    /// </summary>
    public string? PageToken {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "PageToken"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageToken", value);
        }
    }

    public QueueListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueListParams (QueueListParams queueListParams) : base(
        queueListParams
    )
    { this.AccountSid = queueListParams.AccountSid; }
    #pragma warning restore CS8618

    public QueueListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AccountSid = accountSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static QueueListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            accountSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(QueueListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountSid?.Equals(other.AccountSid) ?? other.AccountSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Queues",
            EncodePathSegment(this.AccountSid))
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