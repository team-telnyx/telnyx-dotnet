using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveEventsResponse, MeetingSessionRetrieveEventsResponseFromRaw>))]
public sealed record class MeetingSessionRetrieveEventsResponse : JsonModel
{
    public required IReadOnlyList<MeetingSessionRetrieveEventsResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeetingSessionRetrieveEventsResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MeetingSessionRetrieveEventsResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public MeetingSessionRetrieveEventsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveEventsResponse (
        MeetingSessionRetrieveEventsResponse meetingSessionRetrieveEventsResponse
    ) : base(meetingSessionRetrieveEventsResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveEventsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveEventsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveEventsResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionRetrieveEventsResponse (
        IReadOnlyList<MeetingSessionRetrieveEventsResponseData> data
    ) : this()
    { this.Data = data; }
}

class MeetingSessionRetrieveEventsResponseFromRaw : IFromRawJson<MeetingSessionRetrieveEventsResponse>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveEventsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveEventsResponseData, MeetingSessionRetrieveEventsResponseDataFromRaw>))]
public sealed record class MeetingSessionRetrieveEventsResponseData : JsonModel
{
    public required DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "payload"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "payload",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OccurredAt;
        _ = this.Payload;
        _ = this.Seq;
        _ = this.Type;
    }

    public MeetingSessionRetrieveEventsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveEventsResponseData (
        MeetingSessionRetrieveEventsResponseData meetingSessionRetrieveEventsResponseData
    ) : base(meetingSessionRetrieveEventsResponseData)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveEventsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveEventsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveEventsResponseDataFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MeetingSessionRetrieveEventsResponseDataFromRaw : IFromRawJson<MeetingSessionRetrieveEventsResponseData>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveEventsResponseData.FromRawUnchecked(rawData);
}