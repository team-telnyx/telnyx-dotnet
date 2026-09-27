using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MeetingSessions;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionDeleteRecordingMediaResponse, MeetingSessionDeleteRecordingMediaResponseFromRaw>))]
public sealed record class MeetingSessionDeleteRecordingMediaResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MeetingSessionDeleteRecordingMediaResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionDeleteRecordingMediaResponse (
        MeetingSessionDeleteRecordingMediaResponse meetingSessionDeleteRecordingMediaResponse
    ) : base(meetingSessionDeleteRecordingMediaResponse)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionDeleteRecordingMediaResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionDeleteRecordingMediaResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionDeleteRecordingMediaResponseFromRaw.FromRawUnchecked"/>
    public static MeetingSessionDeleteRecordingMediaResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MeetingSessionDeleteRecordingMediaResponse (Data data) : this()
    { this.Data = data; }
}

class MeetingSessionDeleteRecordingMediaResponseFromRaw : IFromRawJson<MeetingSessionDeleteRecordingMediaResponse>
{
    /// <inheritdoc/>
    public MeetingSessionDeleteRecordingMediaResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionDeleteRecordingMediaResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required ApiEnum<string, DeletionStatus> DeletionStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeletionStatus>>(
                "deletion_status"
            );
        }
        init { this._rawData.Set("deletion_status", value); }
    }

    /// <summary>
    /// The account-scoped Meeting Session identifier.
    /// </summary>
    public required string MeetingSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "meeting_session_id"
            );
        }
        init { this._rawData.Set("meeting_session_id", value); }
    }

    public JsonElement Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    public JsonElement Scope {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "scope"
            );
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeletionStatus.Validate();
        _ = this.MeetingSessionID;
        if (!JsonElementEquality.DeepEquals(this.Provider, JsonSerializer.SerializeToElement("recall")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElementEquality.DeepEquals(this.Scope, JsonSerializer.SerializeToElement("provider_recording_media")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Data ()
    {
        this.Provider = JsonSerializer.SerializeToElement("recall");this.Scope = JsonSerializer.SerializeToElement("provider_recording_media");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Provider = JsonSerializer.SerializeToElement("recall");this.Scope = JsonSerializer.SerializeToElement("provider_recording_media");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(DeletionStatusConverter))]
public enum DeletionStatus
{
    Requested, AlreadyInProgress
}sealed class DeletionStatusConverter : JsonConverter<DeletionStatus>
{
    public override DeletionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requested"=>DeletionStatus.Requested,
            "already_in_progress"=>DeletionStatus.AlreadyInProgress,
            _ =>(DeletionStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeletionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeletionStatus.Requested=>"requested",
            DeletionStatus.AlreadyInProgress=>"already_in_progress",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}