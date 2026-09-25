using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveRecordingsResponse, MeetingSessionRetrieveRecordingsResponseFromRaw>))]
public sealed record class MeetingSessionRetrieveRecordingsResponse : JsonModel
{
    public required IReadOnlyList<MeetingSessionRetrieveRecordingsResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MeetingSessionRetrieveRecordingsResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MeetingSessionRetrieveRecordingsResponseData>>(
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

    public MeetingSessionRetrieveRecordingsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveRecordingsResponse (
        MeetingSessionRetrieveRecordingsResponse meetingSessionRetrieveRecordingsResponse
    ) : base(meetingSessionRetrieveRecordingsResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveRecordingsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveRecordingsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveRecordingsResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveRecordingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionRetrieveRecordingsResponse (
        IReadOnlyList<MeetingSessionRetrieveRecordingsResponseData> data
    ) : this()
    { this.Data = data; }
}

class MeetingSessionRetrieveRecordingsResponseFromRaw : IFromRawJson<MeetingSessionRetrieveRecordingsResponse>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveRecordingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveRecordingsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MeetingSessionRetrieveRecordingsResponseData, MeetingSessionRetrieveRecordingsResponseDataFromRaw>))]
public sealed record class MeetingSessionRetrieveRecordingsResponseData : JsonModel
{
    /// <summary>
    /// Expiry timestamp when supplied by the provider, or null. The current adapter
    /// returns null.
    /// </summary>
    public required string? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "expires_at"
            );
        }
        init { this._rawData.Set("expires_at", value); }
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

    /// <summary>
    /// Current provider download URL. The API does not guarantee URL lifetime or
    /// refresh behavior.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        _ = this.Type;
        _ = this.Url;
    }

    public MeetingSessionRetrieveRecordingsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionRetrieveRecordingsResponseData (
        MeetingSessionRetrieveRecordingsResponseData meetingSessionRetrieveRecordingsResponseData
    ) : base(meetingSessionRetrieveRecordingsResponseData)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionRetrieveRecordingsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionRetrieveRecordingsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionRetrieveRecordingsResponseDataFromRaw.FromRawUnchecked"/>
    public static MeetingSessionRetrieveRecordingsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MeetingSessionRetrieveRecordingsResponseDataFromRaw : IFromRawJson<MeetingSessionRetrieveRecordingsResponseData>
{
    /// <inheritdoc/>
    public MeetingSessionRetrieveRecordingsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionRetrieveRecordingsResponseData.FromRawUnchecked(rawData);
}