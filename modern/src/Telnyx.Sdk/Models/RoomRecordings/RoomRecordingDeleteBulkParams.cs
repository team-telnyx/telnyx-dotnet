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
/// Deletes the room recordings that match the supplied filters and returns the number
/// of recordings affected. Filters support room, session, participant, recording
/// type, status, duration, and start or end dates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoomRecordingDeleteBulkParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[date_ended_at][eq],
    /// filter[date_ended_at][gte], filter[date_ended_at][lte], filter[date_started_at][eq],
    /// filter[date_started_at][gte], filter[date_started_at][lte], filter[room_id],
    /// filter[participant_id], filter[session_id], filter[status], filter[type], filter[duration_secs]
    /// </summary>
    public RoomRecordingDeleteBulkParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<RoomRecordingDeleteBulkParamsFilter>(
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

    public RoomRecordingDeleteBulkParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingDeleteBulkParams (
        RoomRecordingDeleteBulkParams roomRecordingDeleteBulkParams
    ) : base(roomRecordingDeleteBulkParams)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingDeleteBulkParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingDeleteBulkParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RoomRecordingDeleteBulkParams FromRawUnchecked(
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

    public virtual bool Equals(RoomRecordingDeleteBulkParams? other)
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
[JsonConverter(typeof(JsonModelConverter<RoomRecordingDeleteBulkParamsFilter, RoomRecordingDeleteBulkParamsFilterFromRaw>))]
public sealed record class RoomRecordingDeleteBulkParamsFilter : JsonModel
{
    public RoomRecordingDeleteBulkParamsFilterDateEndedAt? DateEndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomRecordingDeleteBulkParamsFilterDateEndedAt>(
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

    public RoomRecordingDeleteBulkParamsFilterDateStartedAt? DateStartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomRecordingDeleteBulkParamsFilterDateStartedAt>(
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

    public RoomRecordingDeleteBulkParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingDeleteBulkParamsFilter (
        RoomRecordingDeleteBulkParamsFilter roomRecordingDeleteBulkParamsFilter
    ) : base(roomRecordingDeleteBulkParamsFilter)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingDeleteBulkParamsFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingDeleteBulkParamsFilter (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingDeleteBulkParamsFilterFromRaw.FromRawUnchecked"/>
    public static RoomRecordingDeleteBulkParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingDeleteBulkParamsFilterFromRaw : IFromRawJson<RoomRecordingDeleteBulkParamsFilter>
{
    /// <inheritdoc/>
    public RoomRecordingDeleteBulkParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecordingDeleteBulkParamsFilter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RoomRecordingDeleteBulkParamsFilterDateEndedAt, RoomRecordingDeleteBulkParamsFilterDateEndedAtFromRaw>))]
public sealed record class RoomRecordingDeleteBulkParamsFilterDateEndedAt : JsonModel
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

    public RoomRecordingDeleteBulkParamsFilterDateEndedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingDeleteBulkParamsFilterDateEndedAt (
        RoomRecordingDeleteBulkParamsFilterDateEndedAt roomRecordingDeleteBulkParamsFilterDateEndedAt
    ) : base(roomRecordingDeleteBulkParamsFilterDateEndedAt)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingDeleteBulkParamsFilterDateEndedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingDeleteBulkParamsFilterDateEndedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingDeleteBulkParamsFilterDateEndedAtFromRaw.FromRawUnchecked"/>
    public static RoomRecordingDeleteBulkParamsFilterDateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingDeleteBulkParamsFilterDateEndedAtFromRaw : IFromRawJson<RoomRecordingDeleteBulkParamsFilterDateEndedAt>
{
    /// <inheritdoc/>
    public RoomRecordingDeleteBulkParamsFilterDateEndedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecordingDeleteBulkParamsFilterDateEndedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RoomRecordingDeleteBulkParamsFilterDateStartedAt, RoomRecordingDeleteBulkParamsFilterDateStartedAtFromRaw>))]
public sealed record class RoomRecordingDeleteBulkParamsFilterDateStartedAt : JsonModel
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

    public RoomRecordingDeleteBulkParamsFilterDateStartedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingDeleteBulkParamsFilterDateStartedAt (
        RoomRecordingDeleteBulkParamsFilterDateStartedAt roomRecordingDeleteBulkParamsFilterDateStartedAt
    ) : base(roomRecordingDeleteBulkParamsFilterDateStartedAt)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingDeleteBulkParamsFilterDateStartedAt (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingDeleteBulkParamsFilterDateStartedAt (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingDeleteBulkParamsFilterDateStartedAtFromRaw.FromRawUnchecked"/>
    public static RoomRecordingDeleteBulkParamsFilterDateStartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingDeleteBulkParamsFilterDateStartedAtFromRaw : IFromRawJson<RoomRecordingDeleteBulkParamsFilterDateStartedAt>
{
    /// <inheritdoc/>
    public RoomRecordingDeleteBulkParamsFilterDateStartedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecordingDeleteBulkParamsFilterDateStartedAt.FromRawUnchecked(rawData);
}