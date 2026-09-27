using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Faxes;

[JsonConverter(typeof(JsonModelConverter<Fax, FaxFromRaw>))]
public sealed record class Fax : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// State received from a command.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// The ID of the connection used to send the fax.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when resource was created
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
    /// The direction of the fax.
    /// </summary>
    public ApiEnum<string, FaxDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxDirection>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// Customer-facing failure reason for the fax. Present on every fax object (null
    /// when the fax has not failed). Mapped from the more granular `internal_failure_reason`.
    /// Common values include: `receiver_call_dropped`, `sender_call_dropped`, `sender_canceled`,
    /// `carrier_lost`, `service_unavailable`, `fax_signaling_error`, `receiver_communication_error`,
    /// `sender_communication_error`, `receiver_decline`, `receiver_recovery_on_timer_expire`,
    /// `receiver_no_response`, `receiver_invalid_number_format`, `receiver_no_answer`,
    /// `receiver_incompatible_destination`, `receiver_unallocated_number`, `destination_unreachable`,
    /// `user_busy`, `invalid_ecm_response_from_receiver`, `fax_initial_communication_timeout`,
    /// `destination_not_in_service_plan`, `account_disabled`, `destination_invalid`,
    /// `no_outbound_profile`, `destination_not_in_countries_whitelist`, `user_channel_limit_exceeded`,
    /// `outbound_profile_channel_limit_exceeded`, `connection_channel_limit_exceeded`,
    /// `outbound_profile_daily_spend_limit_exceeded`, `unverified_origination_number`,
    /// `unverified_destination_not_allowed`, `file_format_invalid`, `file_download_failed`,
    /// `file_size_limit_exceeded`, `page_count_limit_exceeded`, `media_processing_exception`.
    /// </summary>
    public string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    /// <summary>
    /// The phone number, in E.164 format, the fax will be sent from.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The string used as the caller id name (SIP From Display Name) presented to
    /// the destination (`to` number).
    /// </summary>
    public string? FromDisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_display_name", value);
        }
    }

    /// <summary>
    /// Internal, more granular failure reason for the fax. Present on every fax
    /// object (null when the fax has not failed). Useful for deeper debugging beyond
    /// the customer-facing `failure_reason`.
    /// </summary>
    public string? InternalFailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "internal_failure_reason"
            );
        }
        init { this._rawData.Set("internal_failure_reason", value); }
    }

    /// <summary>
    /// The media_name used for the fax's media. Must point to a file previously uploaded
    /// to api.telnyx.com/v2/media by the same user/organization. Supported formats:
    /// PDF, TIFF, JPEG, PNG, DOC, DOCX, RTF, and TXT. media_name and media_url/contents
    /// can't be submitted together.
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_name", value);
        }
    }

    /// <summary>
    /// The URL (or list of URLs) to the fax document. Supported formats: PDF, TIFF,
    /// JPEG, PNG, DOC, DOCX, RTF, and TXT. media_url and media_name/contents can't
    /// be submitted together.
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
    /// If `store_preview` was set to `true`, this is a link to temporary location.
    /// Link expires after 10 minutes.
    /// </summary>
    public string? PreviewUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "preview_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("preview_url", value);
        }
    }

    /// <summary>
    /// The quality of the fax. The `ultra` settings provides the highest quality
    /// available, but also present longer fax processing times. `ultra_light` is
    /// best suited for images, wihle `ultra_dark` is best suited for text.
    /// </summary>
    public ApiEnum<string, Quality>? Quality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Quality>>(
                "quality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quality", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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
    /// Status of the fax
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
    /// Should fax media be stored on temporary URL. It does not support media_name.
    /// </summary>
    public bool? StoreMedia {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "store_media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("store_media", value);
        }
    }

    /// <summary>
    /// If store_media was set to true, this is a link to temporary location. Link
    /// expires after 10 minutes.
    /// </summary>
    public string? StoredMediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stored_media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stored_media_url", value);
        }
    }

    /// <summary>
    /// The phone number, in E.164 format, the fax will be sent to or SIP URI
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when resource was updated
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
    /// Optional failover URL that will receive fax webhooks if webhook_url doesn't
    /// return a 2XX response
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_failover_url", value);
        }
    }

    /// <summary>
    /// URL that will receive fax webhooks
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.CreatedAt;
        this.Direction?.Validate();
        _ = this.FailureReason;
        _ = this.From;
        _ = this.FromDisplayName;
        _ = this.InternalFailureReason;
        _ = this.MediaName;
        _ = this.MediaUrl;
        _ = this.PreviewUrl;
        this.Quality?.Validate();
        this.RecordType?.Validate();
        this.Status?.Validate();
        _ = this.StoreMedia;
        _ = this.StoredMediaUrl;
        _ = this.To;
        _ = this.UpdatedAt;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public Fax ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Fax (Fax fax) : base(fax)
    {  }
    #pragma warning restore CS8618

    public Fax (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Fax (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxFromRaw.FromRawUnchecked"/>
    public static Fax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxFromRaw : IFromRawJson<Fax>
{
    /// <inheritdoc/>
    public Fax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Fax.FromRawUnchecked(rawData);
}

/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(FaxDirectionConverter))]
public enum FaxDirection
{
    Inbound, Outbound
}sealed class FaxDirectionConverter : JsonConverter<FaxDirection>
{
    public override FaxDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>FaxDirection.Inbound,
            "outbound"=>FaxDirection.Outbound,
            _ =>(FaxDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FaxDirection value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxDirection.Inbound=>"inbound",
            FaxDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Fax
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "fax"=>RecordType.Fax, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Fax=>"fax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of the fax
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    MediaProcessed,
    Originated,
    Sending,
    Delivered,
    Failed,
    Initiated,
    Receiving,
    MediaProcessing,
    Received
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
            "queued"=>Status.Queued,
            "media.processed"=>Status.MediaProcessed,
            "originated"=>Status.Originated,
            "sending"=>Status.Sending,
            "delivered"=>Status.Delivered,
            "failed"=>Status.Failed,
            "initiated"=>Status.Initiated,
            "receiving"=>Status.Receiving,
            "media.processing"=>Status.MediaProcessing,
            "received"=>Status.Received,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            Status.MediaProcessed=>"media.processed",
            Status.Originated=>"originated",
            Status.Sending=>"sending",
            Status.Delivered=>"delivered",
            Status.Failed=>"failed",
            Status.Initiated=>"initiated",
            Status.Receiving=>"receiving",
            Status.MediaProcessing=>"media.processing",
            Status.Received=>"received",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}