using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RecordingTranscriptions;

[JsonConverter(typeof(JsonModelConverter<RecordingTranscription, RecordingTranscriptionFromRaw>))]
public sealed record class RecordingTranscription : JsonModel
{
    /// <summary>
    /// Uniquely identifies the recording transcription.
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
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The duration of the recording transcription in milliseconds.
    /// </summary>
    public int? DurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_millis", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// Uniquely identifies the recording associated with this transcription.
    /// </summary>
    public string? RecordingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_id", value);
        }
    }

    /// <summary>
    /// The status of the recording transcription. Only `completed` has transcription
    /// text available.
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
    /// The recording's transcribed text.
    /// </summary>
    public string? TranscriptionText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcription_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_text", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.CreatedAt;
        _ = this.DurationMillis;
        this.RecordType?.Validate();
        _ = this.RecordingID;
        this.Status?.Validate();
        _ = this.TranscriptionText;
        _ = this.UpdatedAt;
    }

    public RecordingTranscription ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingTranscription (
        RecordingTranscription recordingTranscription
    ) : base(recordingTranscription)
    {  }
    #pragma warning restore CS8618

    public RecordingTranscription (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingTranscription (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingTranscriptionFromRaw.FromRawUnchecked"/>
    public static RecordingTranscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingTranscriptionFromRaw : IFromRawJson<RecordingTranscription>
{
    /// <inheritdoc/>
    public RecordingTranscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingTranscription.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    RecordingTranscription
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "recording_transcription"=>RecordType.RecordingTranscription,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.RecordingTranscription=>"recording_transcription",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the recording transcription. Only `completed` has transcription
/// text available.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress, Completed
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
            "in-progress"=>Status.InProgress,
            "completed"=>Status.Completed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.InProgress=>"in-progress",
            Status.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}