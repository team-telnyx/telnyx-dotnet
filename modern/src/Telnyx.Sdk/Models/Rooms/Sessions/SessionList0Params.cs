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
/// Returns a paginated list of room sessions across the account. Filter sessions
/// by room, creation, update, or end date and active status, and use `include_participants`
/// to include participant records.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionList0Params : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_created_at][eq],
    /// filter[date_created_at][gte], filter[date_created_at][lte], filter[date_updated_at][eq],
    /// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_ended_at][eq],
    /// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[room_id], filter[active]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
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

    public SessionList0Params ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList0Params (SessionList0Params sessionList0Params) : base(
        sessionList0Params
    )
    {  }
    #pragma warning restore CS8618

    public SessionList0Params (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList0Params (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionList0Params FromRawUnchecked(
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

    public virtual bool Equals(SessionList0Params? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/room_sessions"
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
/// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[room_id], filter[active]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
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

    public DateCreatedAt? DateCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateCreatedAt>(
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

    public DateEndedAt? DateEndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateEndedAt>(
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

    public DateUpdatedAt? DateUpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateUpdatedAt>(
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

    /// <summary>
    /// Room_id for filtering room sessions.
    /// </summary>
    public string? RoomID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "room_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("room_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        this.DateCreatedAt?.Validate();
        this.DateEndedAt?.Validate();
        this.DateUpdatedAt?.Validate();
        _ = this.RoomID;
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DateCreatedAt, DateCreatedAtFromRaw>))]
public sealed record class DateCreatedAt : JsonModel
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

    public DateCreatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateCreatedAt (DateCreatedAt dateCreatedAt) : base(dateCreatedAt)
    {  }
    #pragma warning restore CS8618

    public DateCreatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateCreatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateCreatedAtFromRaw.FromRawUnchecked"/>
    public static DateCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateCreatedAtFromRaw : IFromRawJson<DateCreatedAt>
{
    /// <inheritdoc/>
    public DateCreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateCreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DateEndedAt, DateEndedAtFromRaw>))]
public sealed record class DateEndedAt : JsonModel
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

    public DateEndedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateEndedAt (DateEndedAt dateEndedAt) : base(dateEndedAt)
    {  }
    #pragma warning restore CS8618

    public DateEndedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateEndedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateEndedAtFromRaw.FromRawUnchecked"/>
    public static DateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateEndedAtFromRaw : IFromRawJson<DateEndedAt>
{
    /// <inheritdoc/>
    public DateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateEndedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DateUpdatedAt, DateUpdatedAtFromRaw>))]
public sealed record class DateUpdatedAt : JsonModel
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

    public DateUpdatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateUpdatedAt (DateUpdatedAt dateUpdatedAt) : base(dateUpdatedAt)
    {  }
    #pragma warning restore CS8618

    public DateUpdatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateUpdatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateUpdatedAtFromRaw.FromRawUnchecked"/>
    public static DateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateUpdatedAtFromRaw : IFromRawJson<DateUpdatedAt>
{
    /// <inheritdoc/>
    public DateUpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateUpdatedAt.FromRawUnchecked(rawData);
}