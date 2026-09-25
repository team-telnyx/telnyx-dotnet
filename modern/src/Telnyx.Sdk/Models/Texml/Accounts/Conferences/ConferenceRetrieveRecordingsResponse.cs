using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceRetrieveRecordingsResponse, ConferenceRetrieveRecordingsResponseFromRaw>))]
public sealed record class ConferenceRetrieveRecordingsResponse : JsonModel
{
    /// <summary>
    /// The number of the last element on the page, zero-indexed.
    /// </summary>
    public long? End {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end", value);
        }
    }

    /// <summary>
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Conferences/6dc6cc1a-1ba1-4351-86b8-4c22c95cd98f/Recordings.json?page=0&amp;pagesize=20
    /// </summary>
    public string? FirstPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "first_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_page_uri", value);
        }
    }

    /// <summary>
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Conferences/6dc6cc1a-1ba1-4351-86b8-4c22c95cd98f/Recordings.json?Page=1&amp;PageSize=1&amp;PageToken=MTY4AjgyNDkwNzIxMQ
    /// </summary>
    public string? NextPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next_page_uri", value);
        }
    }

    /// <summary>
    /// Current page number, zero-indexed.
    /// </summary>
    public long? Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// The number of items on the page
    /// </summary>
    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// List of participant resources.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Participants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "participants",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public IReadOnlyList<Recording>? Recordings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Recording>>(
                "recordings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Recording>?>(
                "recordings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of the first element on the page, zero-indexed.
    /// </summary>
    public long? Start {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "start"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <summary>
    /// The URI of the current page.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.FirstPageUri;
        _ = this.NextPageUri;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.Participants;
        foreach (var item in this.Recordings ?? [])
        {
            item.Validate();
        }
        _ = this.Start;
        _ = this.Uri;
    }

    public ConferenceRetrieveRecordingsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRetrieveRecordingsResponse (
        ConferenceRetrieveRecordingsResponse conferenceRetrieveRecordingsResponse
    ) : base(conferenceRetrieveRecordingsResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceRetrieveRecordingsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRetrieveRecordingsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRetrieveRecordingsResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceRetrieveRecordingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceRetrieveRecordingsResponseFromRaw : IFromRawJson<ConferenceRetrieveRecordingsResponse>
{
    /// <inheritdoc/>
    public ConferenceRetrieveRecordingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRetrieveRecordingsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Recording, RecordingFromRaw>))]
public sealed record class Recording : JsonModel
{
    /// <summary>
    /// The id of the account the resource belongs to.
    /// </summary>
    public string? AccountSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_sid", value);
        }
    }

    /// <summary>
    /// The identifier of the related participant's call.
    /// </summary>
    public string? CallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid", value);
        }
    }

    /// <summary>
    /// The number of channels in the recording.
    /// </summary>
    public long? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// The identifier of the related conference.
    /// </summary>
    public string? ConferenceSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_sid", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was created.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was last updated.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_updated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated", value);
        }
    }

    /// <summary>
    /// Duratin of the recording in seconds.
    /// </summary>
    public long? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// The recording error, if any.
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_code", value);
        }
    }

    /// <summary>
    /// The URL to use to download the recording.
    /// </summary>
    public string? MediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_url", value);
        }
    }

    /// <summary>
    /// The unique identifier of the recording.
    /// </summary>
    public string? Sid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sid", value);
        }
    }

    /// <summary>
    /// How the recording was started.
    /// </summary>
    public ApiEnum<string, Source>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// The timestamp of when the recording was started.
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The status of the recording.
    /// </summary>
    public ApiEnum<string, RecordingStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingStatus>>(
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
    /// A list of related resources identified by their relative URIs.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? SubresourceUris {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "subresource_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "subresource_uris",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The relative URI for this recording.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountSid;
        _ = this.CallSid;
        _ = this.Channels;
        _ = this.ConferenceSid;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.Duration;
        _ = this.ErrorCode;
        _ = this.MediaUrl;
        _ = this.Sid;
        this.Source?.Validate();
        _ = this.StartTime;
        this.Status?.Validate();
        _ = this.SubresourceUris;
        _ = this.Uri;
    }

    public Recording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Recording (Recording recording) : base(recording)
    {  }
    #pragma warning restore CS8618

    public Recording (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Recording (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingFromRaw.FromRawUnchecked"/>
    public static Recording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordingFromRaw : IFromRawJson<Recording>
{
    /// <inheritdoc/>
    public Recording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Recording.FromRawUnchecked(rawData);
}/// <summary>
/// How the recording was started.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    DialVerb,
    Conference,
    OutboundApi,
    Trunking,
    RecordVerb,
    StartCallRecordingApi,
    StartConferenceRecordingApi
}sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DialVerb"=>Source.DialVerb,
            "Conference"=>Source.Conference,
            "OutboundAPI"=>Source.OutboundApi,
            "Trunking"=>Source.Trunking,
            "RecordVerb"=>Source.RecordVerb,
            "StartCallRecordingAPI"=>Source.StartCallRecordingApi,
            "StartConferenceRecordingAPI"=>Source.StartConferenceRecordingApi,
            _ =>(Source)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Source value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Source.DialVerb=>"DialVerb",
            Source.Conference=>"Conference",
            Source.OutboundApi=>"OutboundAPI",
            Source.Trunking=>"Trunking",
            Source.RecordVerb=>"RecordVerb",
            Source.StartCallRecordingApi=>"StartCallRecordingAPI",
            Source.StartConferenceRecordingApi=>"StartConferenceRecordingAPI",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the recording.
/// </summary>
[JsonConverter(typeof(RecordingStatusConverter))]
public enum RecordingStatus
{
    Processing, Absent, Completed, Deleted
}sealed class RecordingStatusConverter : JsonConverter<RecordingStatus>
{
    public override RecordingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "processing"=>RecordingStatus.Processing,
            "absent"=>RecordingStatus.Absent,
            "completed"=>RecordingStatus.Completed,
            "deleted"=>RecordingStatus.Deleted,
            _ =>(RecordingStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingStatus.Processing=>"processing",
            RecordingStatus.Absent=>"absent",
            RecordingStatus.Completed=>"completed",
            RecordingStatus.Deleted=>"deleted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}