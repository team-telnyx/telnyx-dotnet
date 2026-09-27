using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RoomRecordings;

[JsonConverter(typeof(JsonModelConverter<RoomRecording, RoomRecordingFromRaw>))]
public sealed record class RoomRecording : JsonModel
{
    /// <summary>
    /// A unique identifier for the room recording.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Shows the codec used for the room recording.
    /// </summary>
    public string? Codec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "codec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("codec", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room recording has completed.
    /// </summary>
    public System::DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "completed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room recording was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <summary>
    /// Url to download the recording.
    /// </summary>
    public string? DownloadUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "download_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("download_url", value);
        }
    }

    /// <summary>
    /// Shows the room recording duration in seconds.
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
    /// ISO 8601 timestamp when the room recording has ended.
    /// </summary>
    public System::DateTimeOffset? EndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "ended_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ended_at", value);
        }
    }

    /// <summary>
    /// Identify the room participant associated with the room recording.
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

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Identify the room associated with the room recording.
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
    /// Identify the room session associated with the room recording.
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
    /// Shows the room recording size in MB.
    /// </summary>
    public float? SizeMB {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "size_mb"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size_mb", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room recording has stated.
    /// </summary>
    public System::DateTimeOffset? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <summary>
    /// Shows the room recording status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// Shows the room recording type.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.RoomRecordings.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.RoomRecordings.Type>>(
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

    /// <summary>
    /// ISO 8601 timestamp when the room recording was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Codec;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.DurationSecs;
        _ = this.EndedAt;
        _ = this.ParticipantID;
        _ = this.RecordType;
        _ = this.RoomID;
        _ = this.SessionID;
        _ = this.SizeMB;
        _ = this.StartedAt;
        this.Status?.Validate();
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public RoomRecording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecording (RoomRecording roomRecording) : base(roomRecording)
    {  }
    #pragma warning restore CS8618

    public RoomRecording (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecording (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingFromRaw.FromRawUnchecked"/>
    public static RoomRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingFromRaw : IFromRawJson<RoomRecording>
{
    /// <inheritdoc/>
    public RoomRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecording.FromRawUnchecked(rawData);
}

/// <summary>
/// Shows the room recording status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed, Processing
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed"=>Status.Completed,
            "processing"=>Status.Processing,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Completed=>"completed",
            Status.Processing=>"processing",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Shows the room recording type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Audio, Video
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.RoomRecordings.Type>
{
    public override global::Telnyx.Sdk.Models.RoomRecordings.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio"=>global::Telnyx.Sdk.Models.RoomRecordings.Type.Audio,
            "video"=>global::Telnyx.Sdk.Models.RoomRecordings.Type.Video,
            _ =>(global::Telnyx.Sdk.Models.RoomRecordings.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.RoomRecordings.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.RoomRecordings.Type.Audio=>"audio",
            global::Telnyx.Sdk.Models.RoomRecordings.Type.Video=>"video",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}