using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Recordings;

/// <summary>
/// Returns a paginated list of your call recordings, with support for filtering
/// to locate specific recordings.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RecordingListParams : ParamsBase
{
    /// <summary>
    /// Filter recordings by various attributes.
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

    public RecordingListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingListParams (RecordingListParams recordingListParams) : base(
        recordingListParams
    )
    {  }
    #pragma warning restore CS8618

    public RecordingListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RecordingListParams FromRawUnchecked(
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

    public virtual bool Equals(RecordingListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/recordings"
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
/// Filter recordings by various attributes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// If present, recordings will be filtered to those with a matching `call_control_id`.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching call_leg_id.
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching call_session_id.
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <summary>
    /// Returns only recordings associated with a given conference.
    /// </summary>
    public string? ConferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_id", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching `conference_region`.
    /// </summary>
    public string? ConferenceRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_region", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching `connection_id`
    /// attribute (case-sensitive).
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    public CreatedAt? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedAt>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public EndTime? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EndTime>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching `from` attribute (case-sensitive).
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching `sip_call_id`
    /// attribute. Matching is case-sensitive.
    /// </summary>
    public string? SipCallID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_call_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_call_id", value);
        }
    }

    public StartTime? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StartTime>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// If present, recordings will be filtered to those with a matching `to` attribute (case-sensitive).
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ConferenceID;
        _ = this.ConferenceRegion;
        _ = this.ConnectionID;
        this.CreatedAt?.Validate();
        this.EndTime?.Validate();
        _ = this.From;
        _ = this.SipCallID;
        this.StartTime?.Validate();
        _ = this.To;
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

[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Returns only recordings created later than or at given ISO 8601 datetime.
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
    /// Returns only recordings created earlier than or at given ISO 8601 datetime.
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
        _ = this.Gte;
        _ = this.Lte;
    }

    public CreatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt (CreatedAt createdAt) : base(createdAt)
    {  }
    #pragma warning restore CS8618

    public CreatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EndTime, EndTimeFromRaw>))]
public sealed record class EndTime : JsonModel
{
    /// <summary>
    /// Returns only recordings with an end time later than or equal to the given
    /// ISO 8601 datetime.
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
    /// Returns only recordings with an end time earlier than or equal to the given
    /// ISO 8601 datetime.
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
        _ = this.Gte;
        _ = this.Lte;
    }

    public EndTime ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EndTime (EndTime endTime) : base(endTime)
    {  }
    #pragma warning restore CS8618

    public EndTime (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EndTime (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EndTimeFromRaw.FromRawUnchecked"/>
    public static EndTime FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EndTimeFromRaw : IFromRawJson<EndTime>
{
    /// <inheritdoc/>
    public EndTime FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EndTime.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StartTime, StartTimeFromRaw>))]
public sealed record class StartTime : JsonModel
{
    /// <summary>
    /// Returns only recordings with a start time later than or equal to the given
    /// ISO 8601 datetime.
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
    /// Returns only recordings with a start time earlier than or equal to the given
    /// ISO 8601 datetime.
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
        _ = this.Gte;
        _ = this.Lte;
    }

    public StartTime ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StartTime (StartTime startTime) : base(startTime)
    {  }
    #pragma warning restore CS8618

    public StartTime (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StartTime (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StartTimeFromRaw.FromRawUnchecked"/>
    public static StartTime FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StartTimeFromRaw : IFromRawJson<StartTime>
{
    /// <inheritdoc/>
    public StartTime FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StartTime.FromRawUnchecked(rawData);
}