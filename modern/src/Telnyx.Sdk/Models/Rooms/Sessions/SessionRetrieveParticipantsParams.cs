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
/// Returns a paginated list of participants for the specified room session. Filter
/// participants by join, update, or leave date and by participant context.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionRetrieveParticipantsParams : ParamsBase
{
    public string? RoomSessionID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_joined_at][eq],
    /// filter[date_joined_at][gte], filter[date_joined_at][lte], filter[date_updated_at][eq],
    /// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_left_at][eq],
    /// filter[date_left_at][gte], filter[date_left_at][lte], filter[context]
    /// </summary>
    public SessionRetrieveParticipantsParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<SessionRetrieveParticipantsParamsFilter>(
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

    public SessionRetrieveParticipantsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionRetrieveParticipantsParams (
        SessionRetrieveParticipantsParams sessionRetrieveParticipantsParams
    ) : base(sessionRetrieveParticipantsParams)
    { this.RoomSessionID = sessionRetrieveParticipantsParams.RoomSessionID; }
    #pragma warning restore CS8618

    public SessionRetrieveParticipantsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionRetrieveParticipantsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string roomSessionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RoomSessionID = roomSessionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionRetrieveParticipantsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string roomSessionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            roomSessionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["RoomSessionID"] = JsonSerializer.SerializeToElement(this.RoomSessionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SessionRetrieveParticipantsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RoomSessionID?.Equals(other.RoomSessionID) ?? other.RoomSessionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/room_sessions/{0}/participants",
            EncodePathSegment(this.RoomSessionID))
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
/// Consolidated filter parameter (deepObject style). Originally: filter[date_joined_at][eq],
/// filter[date_joined_at][gte], filter[date_joined_at][lte], filter[date_updated_at][eq],
/// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_left_at][eq],
/// filter[date_left_at][gte], filter[date_left_at][lte], filter[context]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SessionRetrieveParticipantsParamsFilter, SessionRetrieveParticipantsParamsFilterFromRaw>))]
public sealed record class SessionRetrieveParticipantsParamsFilter : JsonModel
{
    /// <summary>
    /// Filter room participants based on the context.
    /// </summary>
    public string? Context {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    public DateJoinedAt? DateJoinedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateJoinedAt>(
                "date_joined_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_joined_at", value);
        }
    }

    public DateLeftAt? DateLeftAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateLeftAt>(
                "date_left_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_left_at", value);
        }
    }

    public SessionRetrieveParticipantsParamsFilterDateUpdatedAt? DateUpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SessionRetrieveParticipantsParamsFilterDateUpdatedAt>(
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
        _ = this.Context;
        this.DateJoinedAt?.Validate();
        this.DateLeftAt?.Validate();
        this.DateUpdatedAt?.Validate();
    }

    public SessionRetrieveParticipantsParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionRetrieveParticipantsParamsFilter (
        SessionRetrieveParticipantsParamsFilter sessionRetrieveParticipantsParamsFilter
    ) : base(sessionRetrieveParticipantsParamsFilter)
    {  }
    #pragma warning restore CS8618

    public SessionRetrieveParticipantsParamsFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionRetrieveParticipantsParamsFilter (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionRetrieveParticipantsParamsFilterFromRaw.FromRawUnchecked"/>
    public static SessionRetrieveParticipantsParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionRetrieveParticipantsParamsFilterFromRaw : IFromRawJson<SessionRetrieveParticipantsParamsFilter>
{
    /// <inheritdoc/>
    public SessionRetrieveParticipantsParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionRetrieveParticipantsParamsFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DateJoinedAt, DateJoinedAtFromRaw>))]
public sealed record class DateJoinedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room participants that joined on that date.
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
    /// ISO 8601 date for filtering room participants that joined on or after that date.
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
    /// ISO 8601 date for filtering room participants that joined on or before that date.
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

    public DateJoinedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateJoinedAt (DateJoinedAt dateJoinedAt) : base(dateJoinedAt)
    {  }
    #pragma warning restore CS8618

    public DateJoinedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateJoinedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateJoinedAtFromRaw.FromRawUnchecked"/>
    public static DateJoinedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateJoinedAtFromRaw : IFromRawJson<DateJoinedAt>
{
    /// <inheritdoc/>
    public DateJoinedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateJoinedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DateLeftAt, DateLeftAtFromRaw>))]
public sealed record class DateLeftAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room participants that left on that date.
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
    /// ISO 8601 date for filtering room participants that left on or after that date.
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
    /// ISO 8601 date for filtering room participants that left on or before that date.
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

    public DateLeftAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateLeftAt (DateLeftAt dateLeftAt) : base(dateLeftAt)
    {  }
    #pragma warning restore CS8618

    public DateLeftAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateLeftAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateLeftAtFromRaw.FromRawUnchecked"/>
    public static DateLeftAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateLeftAtFromRaw : IFromRawJson<DateLeftAt>
{
    /// <inheritdoc/>
    public DateLeftAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateLeftAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionRetrieveParticipantsParamsFilterDateUpdatedAt, SessionRetrieveParticipantsParamsFilterDateUpdatedAtFromRaw>))]
public sealed record class SessionRetrieveParticipantsParamsFilterDateUpdatedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room participants updated on that date.
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
    /// ISO 8601 date for filtering room participants updated on or after that date.
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
    /// ISO 8601 date for filtering room participants updated on or before that date.
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

    public SessionRetrieveParticipantsParamsFilterDateUpdatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionRetrieveParticipantsParamsFilterDateUpdatedAt (
        SessionRetrieveParticipantsParamsFilterDateUpdatedAt sessionRetrieveParticipantsParamsFilterDateUpdatedAt
    ) : base(sessionRetrieveParticipantsParamsFilterDateUpdatedAt)
    {  }
    #pragma warning restore CS8618

    public SessionRetrieveParticipantsParamsFilterDateUpdatedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionRetrieveParticipantsParamsFilterDateUpdatedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionRetrieveParticipantsParamsFilterDateUpdatedAtFromRaw.FromRawUnchecked"/>
    public static SessionRetrieveParticipantsParamsFilterDateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionRetrieveParticipantsParamsFilterDateUpdatedAtFromRaw : IFromRawJson<SessionRetrieveParticipantsParamsFilterDateUpdatedAt>
{
    /// <inheritdoc/>
    public SessionRetrieveParticipantsParamsFilterDateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionRetrieveParticipantsParamsFilterDateUpdatedAt.FromRawUnchecked(rawData);
}