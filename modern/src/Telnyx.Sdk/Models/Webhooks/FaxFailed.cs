using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<FaxFailed, FaxFailedFromRaw>))]
public sealed record class FaxFailed : JsonModel
{
    public FaxFailedData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxFailedData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <summary>
    /// Metadata about the webhook delivery.
    /// </summary>
    public FaxFailedMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxFailedMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Meta?.Validate();
    }

    public FaxFailed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxFailed (FaxFailed faxFailed) : base(faxFailed)
    {  }
    #pragma warning restore CS8618

    public FaxFailed (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxFailed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxFailedFromRaw.FromRawUnchecked"/>
    public static FaxFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxFailedFromRaw : IFromRawJson<FaxFailed>
{
    /// <inheritdoc/>
    public FaxFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxFailed.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FaxFailedData, FaxFailedDataFromRaw>))]
public sealed record class FaxFailedData : JsonModel
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
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, FaxFailedDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxFailedDataEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public FaxFailedDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxFailedDataPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, FaxFailedDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxFailedDataRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public FaxFailedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxFailedData (FaxFailedData faxFailedData) : base(faxFailedData)
    {  }
    #pragma warning restore CS8618

    public FaxFailedData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxFailedData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxFailedDataFromRaw.FromRawUnchecked"/>
    public static FaxFailedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxFailedDataFromRaw : IFromRawJson<FaxFailedData>
{
    /// <inheritdoc/>
    public FaxFailedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxFailedData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(FaxFailedDataEventTypeConverter))]
public enum FaxFailedDataEventType
{
    FaxFailed
}sealed class FaxFailedDataEventTypeConverter : JsonConverter<FaxFailedDataEventType>
{
    public override FaxFailedDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fax.failed"=>FaxFailedDataEventType.FaxFailed,
            _ =>(FaxFailedDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxFailedDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxFailedDataEventType.FaxFailed=>"fax.failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FaxFailedDataPayload, FaxFailedDataPayloadFromRaw>))]
public sealed record class FaxFailedDataPayload : JsonModel
{
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
    /// The direction of the fax.
    /// </summary>
    public ApiEnum<string, FaxFailedDataPayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxFailedDataPayloadDirection>>(
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
    /// Customer-facing cause of the fax failure. Mapped from the more granular `internal_failure_reason`.
    /// </summary>
    public string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failure_reason", value);
        }
    }

    /// <summary>
    /// Identifies the fax.
    /// </summary>
    public string? FaxID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fax_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fax_id", value);
        }
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
    /// Internal, more granular cause of the fax failure. Useful for deeper debugging
    /// beyond the customer-facing `failure_reason`.
    /// </summary>
    public string? InternalFailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "internal_failure_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("internal_failure_reason", value);
        }
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
    /// The original URL to the PDF used for the fax's media. If media_name was supplied,
    /// this is omitted
    /// </summary>
    public string? OriginalMediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "original_media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("original_media_url", value);
        }
    }

    /// <summary>
    /// The status of the fax.
    /// </summary>
    public ApiEnum<string, FaxFailedDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxFailedDataPayloadStatus>>(
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
    /// Identifier of the user to whom the fax belongs
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.Direction?.Validate();
        _ = this.FailureReason;
        _ = this.FaxID;
        _ = this.From;
        _ = this.InternalFailureReason;
        _ = this.MediaName;
        _ = this.OriginalMediaUrl;
        this.Status?.Validate();
        _ = this.To;
        _ = this.UserID;
    }

    public FaxFailedDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxFailedDataPayload (
        FaxFailedDataPayload faxFailedDataPayload
    ) : base(faxFailedDataPayload)
    {  }
    #pragma warning restore CS8618

    public FaxFailedDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxFailedDataPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxFailedDataPayloadFromRaw.FromRawUnchecked"/>
    public static FaxFailedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxFailedDataPayloadFromRaw : IFromRawJson<FaxFailedDataPayload>
{
    /// <inheritdoc/>
    public FaxFailedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxFailedDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(FaxFailedDataPayloadDirectionConverter))]
public enum FaxFailedDataPayloadDirection
{
    Inbound, Outbound
}sealed class FaxFailedDataPayloadDirectionConverter : JsonConverter<FaxFailedDataPayloadDirection>
{
    public override FaxFailedDataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>FaxFailedDataPayloadDirection.Inbound,
            "outbound"=>FaxFailedDataPayloadDirection.Outbound,
            _ =>(FaxFailedDataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxFailedDataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxFailedDataPayloadDirection.Inbound=>"inbound",
            FaxFailedDataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the fax.
/// </summary>
[JsonConverter(typeof(FaxFailedDataPayloadStatusConverter))]
public enum FaxFailedDataPayloadStatus
{
    Failed
}sealed class FaxFailedDataPayloadStatusConverter : JsonConverter<FaxFailedDataPayloadStatus>
{
    public override FaxFailedDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "failed"=>FaxFailedDataPayloadStatus.Failed,
            _ =>(FaxFailedDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxFailedDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxFailedDataPayloadStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(FaxFailedDataRecordTypeConverter))]
public enum FaxFailedDataRecordType
{
    Event
}sealed class FaxFailedDataRecordTypeConverter : JsonConverter<FaxFailedDataRecordType>
{
    public override FaxFailedDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>FaxFailedDataRecordType.Event,
            _ =>(FaxFailedDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxFailedDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxFailedDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Metadata about the webhook delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FaxFailedMeta, FaxFailedMetaFromRaw>))]
public sealed record class FaxFailedMeta : JsonModel
{
    /// <summary>
    /// The delivery attempt number.
    /// </summary>
    public long? Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "attempt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempt", value);
        }
    }

    /// <summary>
    /// The URL the webhook was delivered to.
    /// </summary>
    public string? DeliveredTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivered_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivered_to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempt;
        _ = this.DeliveredTo;
    }

    public FaxFailedMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxFailedMeta (FaxFailedMeta faxFailedMeta) : base(faxFailedMeta)
    {  }
    #pragma warning restore CS8618

    public FaxFailedMeta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxFailedMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxFailedMetaFromRaw.FromRawUnchecked"/>
    public static FaxFailedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxFailedMetaFromRaw : IFromRawJson<FaxFailedMeta>
{
    /// <inheritdoc/>
    public FaxFailedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxFailedMeta.FromRawUnchecked(rawData);
}