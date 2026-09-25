using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveTranscriptResponse, MeetingSessionRetrieveTranscriptResponseFromRaw>))]
public sealed record class MeetingSessionRetrieveTranscriptResponse : JsonModel
{
    public required IReadOnlyList<MeetingSessionRetrieveTranscriptResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeetingSessionRetrieveTranscriptResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MeetingSessionRetrieveTranscriptResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public MeetingSessionRetrieveTranscriptResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveTranscriptResponse (
        MeetingSessionRetrieveTranscriptResponse meetingSessionRetrieveTranscriptResponse
    ) : base(meetingSessionRetrieveTranscriptResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveTranscriptResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveTranscriptResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveTranscriptResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveTranscriptResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MeetingSessionRetrieveTranscriptResponseFromRaw : IFromRawJson<MeetingSessionRetrieveTranscriptResponse>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveTranscriptResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveTranscriptResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveTranscriptResponseData, MeetingSessionRetrieveTranscriptResponseDataFromRaw>))]
public sealed record class MeetingSessionRetrieveTranscriptResponseData : JsonModel
{
    public required double? Confidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "confidence"
            );
        }
        init { this._rawData.Set("confidence", value); }
    }

    public required DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required double? RelativeTs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "relative_ts"
            );
        }
        init { this._rawData.Set("relative_ts", value); }
    }

    public required long Seq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "seq"
            );
        }
        init { this._rawData.Set("seq", value); }
    }

    public required string? SpeakerLabel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "speaker_label"
            );
        }
        init { this._rawData.Set("speaker_label", value); }
    }

    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.OccurredAt;
        _ = this.RelativeTs;
        _ = this.Seq;
        _ = this.SpeakerLabel;
        _ = this.Text;
    }

    public MeetingSessionRetrieveTranscriptResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveTranscriptResponseData (
        MeetingSessionRetrieveTranscriptResponseData meetingSessionRetrieveTranscriptResponseData
    ) : base(meetingSessionRetrieveTranscriptResponseData)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveTranscriptResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveTranscriptResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveTranscriptResponseDataFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveTranscriptResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MeetingSessionRetrieveTranscriptResponseDataFromRaw : IFromRawJson<MeetingSessionRetrieveTranscriptResponseData>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveTranscriptResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveTranscriptResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Cursor to pass as `after` on the next request, or null when the response
    /// contains no segments.
    /// </summary>
    public required long? NextAfter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "next_after"
            );
        }
        init { this._rawData.Set("next_after", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.NextAfter; }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Meta (long? nextAfter) : this()
    { this.NextAfter = nextAfter; }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}