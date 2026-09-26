using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

/// <summary>
/// Returns stored events ordered by ascending `seq`. To continue, pass the last
/// returned item's `seq` as `after`. An empty page means no later stored events existed
/// at read time; this operation returns no separate next-page cursor. Default `limit`
/// is 100 and maximum is 1,000.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MeetingSessionRetrieveEventsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Return results with a cursor position after this value.
    /// </summary>
    public long? After {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "after"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("after", value);
        }
    }

    /// <summary>
    /// Maximum number of results to return per page.
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

    public MeetingSessionRetrieveEventsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveEventsParams (
        MeetingSessionRetrieveEventsParams meetingSessionRetrieveEventsParams
    ) : base(meetingSessionRetrieveEventsParams)
    { this.ID = meetingSessionRetrieveEventsParams.ID; }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveEventsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveEventsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MeetingSessionRetrieveEventsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MeetingSessionRetrieveEventsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/meeting_sessions/{0}/events",
            EncodePathSegment(this.ID))
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