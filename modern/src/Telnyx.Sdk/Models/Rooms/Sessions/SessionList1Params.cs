using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Sessions;

/// <summary>
/// Returns a paginated list of sessions for the specified room. Filter sessions
/// by creation, update, or end date and active status, and use `include_participants`
/// to include participant records.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionList1Params : ParamsBase
{
    public string? RoomID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_created_at][eq],
    /// filter[date_created_at][gte], filter[date_created_at][lte], filter[date_updated_at][eq],
    /// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_ended_at][eq],
    /// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[active]
    /// </summary>
    public SessionList1ParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<SessionList1ParamsFilter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    /// <summary>
    /// To decide if room participants should be included in the response.
    /// </summary>
    public bool? IncludeParticipants {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_participants", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

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

    public SessionList1Params ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1Params (SessionList1Params sessionList1Params) : base(
        sessionList1Params
    )
    { this.RoomID = sessionList1Params.RoomID; }
    #pragma warning restore CS8618

    public SessionList1Params (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1Params (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string roomID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RoomID = roomID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionList1Params FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string roomID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            roomID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["RoomID"] = JsonSerializer.SerializeToElement(this.RoomID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SessionList1Params? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RoomID?.Equals(other.RoomID) ?? other.RoomID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/rooms/{0}/sessions",
            this.RoomID)
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

/// <summary>
/// Consolidated filter parameter (deepObject style). Originally: filter[date_created_at][eq],
/// filter[date_created_at][gte], filter[date_created_at][lte], filter[date_updated_at][eq],
/// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_ended_at][eq],
/// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[active]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SessionList1ParamsFilter, SessionList1ParamsFilterFromRaw>))]
public sealed record class SessionList1ParamsFilter : JsonModel
{
    /// <summary>
    /// Filter active or inactive room sessions.
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    public SessionList1ParamsFilterDateCreatedAt? DateCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionList1ParamsFilterDateCreatedAt>(
                "date_created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created_at", value);
        }
    }

    public SessionList1ParamsFilterDateEndedAt? DateEndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionList1ParamsFilterDateEndedAt>(
                "date_ended_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_ended_at", value);
        }
    }

    public SessionList1ParamsFilterDateUpdatedAt? DateUpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionList1ParamsFilterDateUpdatedAt>(
                "date_updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        this.DateCreatedAt?.Validate();
        this.DateEndedAt?.Validate();
        this.DateUpdatedAt?.Validate();
    }

    public SessionList1ParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1ParamsFilter (
        SessionList1ParamsFilter sessionList1ParamsFilter
    ) : base(sessionList1ParamsFilter)
    {  }
    #pragma warning restore CS8618

    public SessionList1ParamsFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1ParamsFilter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList1ParamsFilterFromRaw.FromRawUnchecked"/>
    public static SessionList1ParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList1ParamsFilterFromRaw : IFromRawJson<SessionList1ParamsFilter>
{
    /// <inheritdoc/>
    public SessionList1ParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList1ParamsFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionList1ParamsFilterDateCreatedAt, SessionList1ParamsFilterDateCreatedAtFromRaw>))]
public sealed record class SessionList1ParamsFilterDateCreatedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room sessions created on that date.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions created on or after that date.
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions created on or before that date.
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Eq;
        _ = this.Gte;
        _ = this.Lte;
    }

    public SessionList1ParamsFilterDateCreatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1ParamsFilterDateCreatedAt (
        SessionList1ParamsFilterDateCreatedAt sessionList1ParamsFilterDateCreatedAt
    ) : base(sessionList1ParamsFilterDateCreatedAt)
    {  }
    #pragma warning restore CS8618

    public SessionList1ParamsFilterDateCreatedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1ParamsFilterDateCreatedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList1ParamsFilterDateCreatedAtFromRaw.FromRawUnchecked"/>
    public static SessionList1ParamsFilterDateCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList1ParamsFilterDateCreatedAtFromRaw : IFromRawJson<SessionList1ParamsFilterDateCreatedAt>
{
    /// <inheritdoc/>
    public SessionList1ParamsFilterDateCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList1ParamsFilterDateCreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionList1ParamsFilterDateEndedAt, SessionList1ParamsFilterDateEndedAtFromRaw>))]
public sealed record class SessionList1ParamsFilterDateEndedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room sessions ended on that date.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions ended on or after that date.
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions ended on or before that date.
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Eq;
        _ = this.Gte;
        _ = this.Lte;
    }

    public SessionList1ParamsFilterDateEndedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1ParamsFilterDateEndedAt (
        SessionList1ParamsFilterDateEndedAt sessionList1ParamsFilterDateEndedAt
    ) : base(sessionList1ParamsFilterDateEndedAt)
    {  }
    #pragma warning restore CS8618

    public SessionList1ParamsFilterDateEndedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1ParamsFilterDateEndedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList1ParamsFilterDateEndedAtFromRaw.FromRawUnchecked"/>
    public static SessionList1ParamsFilterDateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList1ParamsFilterDateEndedAtFromRaw : IFromRawJson<SessionList1ParamsFilterDateEndedAt>
{
    /// <inheritdoc/>
    public SessionList1ParamsFilterDateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList1ParamsFilterDateEndedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionList1ParamsFilterDateUpdatedAt, SessionList1ParamsFilterDateUpdatedAtFromRaw>))]
public sealed record class SessionList1ParamsFilterDateUpdatedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room sessions updated on that date.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions updated on or after that date.
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// ISO 8601 date for filtering room sessions updated on or before that date.
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Eq;
        _ = this.Gte;
        _ = this.Lte;
    }

    public SessionList1ParamsFilterDateUpdatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1ParamsFilterDateUpdatedAt (
        SessionList1ParamsFilterDateUpdatedAt sessionList1ParamsFilterDateUpdatedAt
    ) : base(sessionList1ParamsFilterDateUpdatedAt)
    {  }
    #pragma warning restore CS8618

    public SessionList1ParamsFilterDateUpdatedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1ParamsFilterDateUpdatedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList1ParamsFilterDateUpdatedAtFromRaw.FromRawUnchecked"/>
    public static SessionList1ParamsFilterDateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList1ParamsFilterDateUpdatedAtFromRaw : IFromRawJson<SessionList1ParamsFilterDateUpdatedAt>
{
    /// <inheritdoc/>
    public SessionList1ParamsFilterDateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList1ParamsFilterDateUpdatedAt.FromRawUnchecked(rawData);
}