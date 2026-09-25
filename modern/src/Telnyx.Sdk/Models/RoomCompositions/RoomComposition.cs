using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RoomCompositions;

[JsonConverter(typeof(JsonModelConverter<RoomComposition, RoomCompositionFromRaw>))]
public sealed record class RoomComposition : JsonModel
{
    /// <summary>
    /// A unique identifier for the room composition.
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
    /// ISO 8601 timestamp when the room composition has completed.
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
    /// ISO 8601 timestamp when the room composition was created.
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
    /// Url to download the composition.
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
    /// Shows the room composition duration in seconds.
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
    /// ISO 8601 timestamp when the room composition has ended.
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
    /// Shows format of the room composition.
    /// </summary>
    public ApiEnum<string, Format>? Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("format", value);
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
    /// The resolution of the room composition.
    /// </summary>
    public string? Resolution {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resolution"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resolution", value);
        }
    }

    /// <summary>
    /// Identify the room associated with the room composition.
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
    /// Identify the room session associated with the room composition.
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
    /// Shows the room composition size in MB.
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
    /// ISO 8601 timestamp when the room composition has stated.
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
    /// Shows the room composition status.
    /// </summary>
    public ApiEnum<string, RoomCompositionStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RoomCompositionStatus>>(
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
    /// ISO 8601 timestamp when the room composition was updated.
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

    /// <summary>
    /// Identify the user associated with the room composition.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// Describes the video layout of the room composition in terms of regions. Limited
    /// to 2 regions.
    /// </summary>
    public IReadOnlyDictionary<string, VideoRegion>? VideoLayout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, VideoRegion>>(
                "video_layout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, VideoRegion>?>(
                "video_layout",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this room composition will be
    /// sent if sending to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_failover_url", value);
        }
    }

    /// <summary>
    /// The URL where webhooks related to this room composition will be sent. Must
    /// include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_url", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_timeout_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CompletedAt;
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.DurationSecs;
        _ = this.EndedAt;
        this.Format?.Validate();
        _ = this.RecordType;
        _ = this.Resolution;
        _ = this.RoomID;
        _ = this.SessionID;
        _ = this.SizeMB;
        _ = this.StartedAt;
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.UserID;
        if (this.VideoLayout != null)
        {
            foreach (var item in this.VideoLayout.Values)
            {
                item.Validate();
            }
        }
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public RoomComposition ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomComposition (RoomComposition roomComposition) : base(
        roomComposition
    )
    {  }
    #pragma warning restore CS8618

    public RoomComposition (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomComposition (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomCompositionFromRaw.FromRawUnchecked"/>
    public static RoomComposition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomCompositionFromRaw : IFromRawJson<RoomComposition>
{
    /// <inheritdoc/>
    public RoomComposition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomComposition.FromRawUnchecked(rawData);
}

/// <summary>
/// Shows format of the room composition.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Mp4
}sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "mp4"=>Format.Mp4, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Mp4=>"mp4",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Shows the room composition status.
/// </summary>
[JsonConverter(typeof(RoomCompositionStatusConverter))]
public enum RoomCompositionStatus
{
    Completed, Enqueued, Processing
}sealed class RoomCompositionStatusConverter : JsonConverter<RoomCompositionStatus>
{
    public override RoomCompositionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed"=>RoomCompositionStatus.Completed,
            "enqueued"=>RoomCompositionStatus.Enqueued,
            "processing"=>RoomCompositionStatus.Processing,
            _ =>(RoomCompositionStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoomCompositionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RoomCompositionStatus.Completed=>"completed",
            RoomCompositionStatus.Enqueued=>"enqueued",
            RoomCompositionStatus.Processing=>"processing",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}