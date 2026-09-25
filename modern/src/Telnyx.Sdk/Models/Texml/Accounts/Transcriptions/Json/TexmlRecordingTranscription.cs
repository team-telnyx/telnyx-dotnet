using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Transcriptions.Json;

[JsonConverter(typeof(JsonModelConverter<TexmlRecordingTranscription, TexmlRecordingTranscriptionFromRaw>))]
public sealed record class TexmlRecordingTranscription : JsonModel
{
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
    /// The version of the API that was used to make the request.
    /// </summary>
    public string? ApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_version", value);
        }
    }

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

    public System::DateTimeOffset? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public System::DateTimeOffset? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// The duration of this recording, given in seconds.
    /// </summary>
    public string? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "duration"
            );
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// Identifier of a resource.
    /// </summary>
    public string? RecordingSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_sid", value);
        }
    }

    /// <summary>
    /// Identifier of a resource.
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
    /// The status of the recording transcriptions. The transcription text will be
    /// available only when the status is completed.
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
    /// The recording's transcribed text
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
    /// The relative URI for the recording transcription resource.
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
        _ = this.ApiVersion;
        _ = this.CallSid;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.Duration;
        _ = this.RecordingSid;
        _ = this.Sid;
        this.Status?.Validate();
        _ = this.TranscriptionText;
        _ = this.Uri;
    }

    public TexmlRecordingTranscription ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlRecordingTranscription (
        TexmlRecordingTranscription texmlRecordingTranscription
    ) : base(texmlRecordingTranscription)
    {  }
    #pragma warning restore CS8618

    public TexmlRecordingTranscription (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlRecordingTranscription (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlRecordingTranscriptionFromRaw.FromRawUnchecked"/>
    public static TexmlRecordingTranscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlRecordingTranscriptionFromRaw : IFromRawJson<TexmlRecordingTranscription>
{
    /// <inheritdoc/>
    public TexmlRecordingTranscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlRecordingTranscription.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the recording transcriptions. The transcription text will be available
/// only when the status is completed.
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