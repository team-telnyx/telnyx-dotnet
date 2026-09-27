using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomRecordings;

/// <summary>
/// Returns a paginated list of room recordings. Filter recordings by room, session,
/// participant, recording type, status, duration, or start and end dates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoomRecordingListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_ended_at][eq],
    /// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[date_started_at][eq],
    /// filter[date_started_at][gte], filter[date_started_at][lte], filter[room_id],
    /// filter[participant_id], filter[session_id], filter[status], filter[type], filter[duration_secs]
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

    public RoomRecordingListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingListParams (
        RoomRecordingListParams roomRecordingListParams
    ) : base(roomRecordingListParams)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RoomRecordingListParams FromRawUnchecked(
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

    public virtual bool Equals(RoomRecordingListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/room_recordings"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[date_ended_at][eq],
/// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[date_started_at][eq],
/// filter[date_started_at][gte], filter[date_started_at][lte], filter[room_id], filter[participant_id],
/// filter[session_id], filter[status], filter[type], filter[duration_secs]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
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

    public DateStartedAt? DateStartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DateStartedAt>(
                "date_started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_started_at", value);
        }
    }

    /// <summary>
    /// duration_secs greater or equal for filtering room recordings.
    /// </summary>
    public long? DurationSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "duration_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_secs", value);
        }
    }

    /// <summary>
    /// participant_id for filtering room recordings.
    /// </summary>
    public string? ParticipantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "participant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("participant_id", value);
        }
    }

    /// <summary>
    /// room_id for filtering room recordings.
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

    /// <summary>
    /// session_id for filtering room recordings.
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

    /// <summary>
    /// status for filtering room recordings.
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// type for filtering room recordings.
    /// </summary>
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DateEndedAt?.Validate();
        this.DateStartedAt?.Validate();
        _ = this.DurationSecs;
        _ = this.ParticipantID;
        _ = this.RoomID;
        _ = this.SessionID;
        _ = this.Status;
        _ = this.Type;
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

[JsonConverter(typeof(JsonModelConverter<DateEndedAt, DateEndedAtFromRaw>))]
public sealed record class DateEndedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room recordings ended on that date.
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
    /// ISO 8601 date for filtering room recordings ended on or after that date.
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
    /// ISO 8601 date for filtering room recordings ended on or before that date.
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

[JsonConverter(typeof(JsonModelConverter<DateStartedAt, DateStartedAtFromRaw>))]
public sealed record class DateStartedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date for filtering room recordings started on that date.
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
    /// ISO 8601 date for filtering room recordings started on or after that date.
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
    /// ISO 8601 date for filtering room recordings started on or before that date.
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

    public DateStartedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateStartedAt (DateStartedAt dateStartedAt) : base(dateStartedAt)
    {  }
    #pragma warning restore CS8618

    public DateStartedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateStartedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateStartedAtFromRaw.FromRawUnchecked"/>
    public static DateStartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateStartedAtFromRaw : IFromRawJson<DateStartedAt>
{
    /// <inheritdoc/>
    public DateStartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateStartedAt.FromRawUnchecked(rawData);
}