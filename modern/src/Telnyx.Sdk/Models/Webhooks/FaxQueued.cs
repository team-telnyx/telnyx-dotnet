using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<FaxQueued, FaxQueuedFromRaw>))]
public sealed record class FaxQueued : JsonModel
{
    public FaxQueuedData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxQueuedData>(
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
    public FaxQueuedMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxQueuedMeta>(
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

    public FaxQueued ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxQueued (FaxQueued faxQueued) : base(faxQueued)
    {  }
    #pragma warning restore CS8618

    public FaxQueued (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxQueued (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxQueuedFromRaw.FromRawUnchecked"/>
    public static FaxQueued FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxQueuedFromRaw : IFromRawJson<FaxQueued>
{
    /// <inheritdoc/>
    public FaxQueued FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxQueued.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FaxQueuedData, FaxQueuedDataFromRaw>))]
public sealed record class FaxQueuedData : JsonModel
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
    public ApiEnum<string, FaxQueuedDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxQueuedDataEventType>>(
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

    public FaxQueuedDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxQueuedDataPayload>(
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
    public ApiEnum<string, FaxQueuedDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxQueuedDataRecordType>>(
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

    public FaxQueuedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxQueuedData (FaxQueuedData faxQueuedData) : base(faxQueuedData)
    {  }
    #pragma warning restore CS8618

    public FaxQueuedData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxQueuedData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxQueuedDataFromRaw.FromRawUnchecked"/>
    public static FaxQueuedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxQueuedDataFromRaw : IFromRawJson<FaxQueuedData>
{
    /// <inheritdoc/>
    public FaxQueuedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxQueuedData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(FaxQueuedDataEventTypeConverter))]
public enum FaxQueuedDataEventType
{
    FaxQueued
}sealed class FaxQueuedDataEventTypeConverter : JsonConverter<FaxQueuedDataEventType>
{
    public override FaxQueuedDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fax.queued"=>FaxQueuedDataEventType.FaxQueued,
            _ =>(FaxQueuedDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxQueuedDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxQueuedDataEventType.FaxQueued=>"fax.queued",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FaxQueuedDataPayload, FaxQueuedDataPayloadFromRaw>))]
public sealed record class FaxQueuedDataPayload : JsonModel
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
    public ApiEnum<string, FaxQueuedDataPayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxQueuedDataPayloadDirection>>(
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
    public ApiEnum<string, FaxQueuedDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxQueuedDataPayloadStatus>>(
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
        _ = this.FaxID;
        _ = this.From;
        _ = this.MediaName;
        _ = this.OriginalMediaUrl;
        this.Status?.Validate();
        _ = this.To;
        _ = this.UserID;
    }

    public FaxQueuedDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxQueuedDataPayload (
        FaxQueuedDataPayload faxQueuedDataPayload
    ) : base(faxQueuedDataPayload)
    {  }
    #pragma warning restore CS8618

    public FaxQueuedDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxQueuedDataPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxQueuedDataPayloadFromRaw.FromRawUnchecked"/>
    public static FaxQueuedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxQueuedDataPayloadFromRaw : IFromRawJson<FaxQueuedDataPayload>
{
    /// <inheritdoc/>
    public FaxQueuedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxQueuedDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(FaxQueuedDataPayloadDirectionConverter))]
public enum FaxQueuedDataPayloadDirection
{
    Inbound, Outbound
}sealed class FaxQueuedDataPayloadDirectionConverter : JsonConverter<FaxQueuedDataPayloadDirection>
{
    public override FaxQueuedDataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>FaxQueuedDataPayloadDirection.Inbound,
            "outbound"=>FaxQueuedDataPayloadDirection.Outbound,
            _ =>(FaxQueuedDataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxQueuedDataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxQueuedDataPayloadDirection.Inbound=>"inbound",
            FaxQueuedDataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the fax.
/// </summary>
[JsonConverter(typeof(FaxQueuedDataPayloadStatusConverter))]
public enum FaxQueuedDataPayloadStatus
{
    Queued
}sealed class FaxQueuedDataPayloadStatusConverter : JsonConverter<FaxQueuedDataPayloadStatus>
{
    public override FaxQueuedDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>FaxQueuedDataPayloadStatus.Queued,
            _ =>(FaxQueuedDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxQueuedDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxQueuedDataPayloadStatus.Queued=>"queued",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(FaxQueuedDataRecordTypeConverter))]
public enum FaxQueuedDataRecordType
{
    Event
}sealed class FaxQueuedDataRecordTypeConverter : JsonConverter<FaxQueuedDataRecordType>
{
    public override FaxQueuedDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>FaxQueuedDataRecordType.Event,
            _ =>(FaxQueuedDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxQueuedDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxQueuedDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Metadata about the webhook delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FaxQueuedMeta, FaxQueuedMetaFromRaw>))]
public sealed record class FaxQueuedMeta : JsonModel
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

    public FaxQueuedMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxQueuedMeta (FaxQueuedMeta faxQueuedMeta) : base(faxQueuedMeta)
    {  }
    #pragma warning restore CS8618

    public FaxQueuedMeta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxQueuedMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxQueuedMetaFromRaw.FromRawUnchecked"/>
    public static FaxQueuedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxQueuedMetaFromRaw : IFromRawJson<FaxQueuedMeta>
{
    /// <inheritdoc/>
    public FaxQueuedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxQueuedMeta.FromRawUnchecked(rawData);
}