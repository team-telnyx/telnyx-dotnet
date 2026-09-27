using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomParticipants;

/// <summary>
/// Returns a paginated list of room participants across sessions. Filter participants
/// by session, join, update, or leave date and by participant context.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoomParticipantListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_joined_at][eq],
    /// filter[date_joined_at][gte], filter[date_joined_at][lte], filter[date_updated_at][eq],
    /// filter[date_updated_at][gte], filter[date_updated_at][lte], filter[date_left_at][eq],
    /// filter[date_left_at][gte], filter[date_left_at][lte], filter[context], filter[session_id]
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

    public RoomParticipantListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomParticipantListParams (
        RoomParticipantListParams roomParticipantListParams
    ) : base(roomParticipantListParams)
    {  }
    #pragma warning restore CS8618

    public RoomParticipantListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomParticipantListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RoomParticipantListParams FromRawUnchecked(
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

    public virtual bool Equals(RoomParticipantListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/room_participants"
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
/// filter[date_left_at][gte], filter[date_left_at][lte], filter[context], filter[session_id]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
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
    /// Session_id for filtering room participants.
    /// </summary>
    public string? SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("session_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
        this.DateJoinedAt?.Validate();
        this.DateLeftAt?.Validate();
        this.DateUpdatedAt?.Validate();
        _ = this.SessionID;
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

[JsonConverter(typeof(JsonModelConverter<DateUpdatedAt, DateUpdatedAtFromRaw>))]
public sealed record class DateUpdatedAt : JsonModel
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