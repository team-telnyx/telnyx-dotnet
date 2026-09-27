using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

namespace Telnyx.Sdk.Models.Texml.Accounts;

[JsonConverter(typeof(JsonModelConverter<TexmlGetCallRecordingResponseBody, TexmlGetCallRecordingResponseBodyFromRaw>))]
public sealed record class TexmlGetCallRecordingResponseBody : JsonModel
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

    public ApiEnum<long, TwimlRecordingChannels>? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, TwimlRecordingChannels>>(
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

    public string? ConferenceSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_sid"
            );
        }
        init { this._rawData.Set("conference_sid", value); }
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

    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
    }

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
    /// Defines how the recording was created.
    /// </summary>
    public ApiEnum<string, RecordingSource>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingSource>>(
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

    public System::DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// Subresources details for a recording if available.
    /// </summary>
    public TexmlRecordingSubresourcesUris? SubresourcesUris {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TexmlRecordingSubresourcesUris>(
                "subresources_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subresources_uris", value);
        }
    }

    /// <summary>
    /// The relative URI for this recording resource.
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
        this.Channels?.Validate();
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
        this.SubresourcesUris?.Validate();
        _ = this.Uri;
    }

    public TexmlGetCallRecordingResponseBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlGetCallRecordingResponseBody (
        TexmlGetCallRecordingResponseBody texmlGetCallRecordingResponseBody
    ) : base(texmlGetCallRecordingResponseBody)
    {  }
    #pragma warning restore CS8618

    public TexmlGetCallRecordingResponseBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlGetCallRecordingResponseBody (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlGetCallRecordingResponseBodyFromRaw.FromRawUnchecked"/>
    public static TexmlGetCallRecordingResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlGetCallRecordingResponseBodyFromRaw : IFromRawJson<TexmlGetCallRecordingResponseBody>
{
    /// <inheritdoc/>
    public TexmlGetCallRecordingResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlGetCallRecordingResponseBody.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress, Completed, Paused, Stopped
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
            "paused"=>Status.Paused,
            "stopped"=>Status.Stopped,
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
            Status.Paused=>"paused",
            Status.Stopped=>"stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}