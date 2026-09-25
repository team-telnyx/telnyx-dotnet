using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<FaxDelivered, FaxDeliveredFromRaw>))]
public sealed record class FaxDelivered : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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
    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
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

    public FaxDelivered ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxDelivered (FaxDelivered faxDelivered) : base(faxDelivered)
    {  }
    #pragma warning restore CS8618

    public FaxDelivered (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxDelivered (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxDeliveredFromRaw.FromRawUnchecked"/>
    public static FaxDelivered FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxDeliveredFromRaw : IFromRawJson<FaxDelivered>
{
    /// <inheritdoc/>
    public FaxDelivered FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxDelivered.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public ApiEnum<string, DataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataEventType>>(
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

    public DataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPayload>(
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
    public ApiEnum<string, DataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataRecordType>>(
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

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

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
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(DataEventTypeConverter))]
public enum DataEventType
{
    FaxDelivered
}sealed class DataEventTypeConverter : JsonConverter<DataEventType>
{
    public override DataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fax.delivered"=>DataEventType.FaxDelivered, _ =>(DataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataEventType.FaxDelivered=>"fax.delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<DataPayload, DataPayloadFromRaw>))]
public sealed record class DataPayload : JsonModel
{
    /// <summary>
    /// The duration of the call in seconds.
    /// </summary>
    public long? CallDurationSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_duration_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_duration_secs", value);
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
    /// The direction of the fax.
    /// </summary>
    public ApiEnum<string, DataPayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPayloadDirection>>(
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
    /// Number of transferred pages
    /// </summary>
    public long? PageCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_count", value);
        }
    }

    /// <summary>
    /// The status of the fax.
    /// </summary>
    public ApiEnum<string, DataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPayloadStatus>>(
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
        _ = this.CallDurationSecs;
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.Direction?.Validate();
        _ = this.FaxID;
        _ = this.From;
        _ = this.MediaName;
        _ = this.OriginalMediaUrl;
        _ = this.PageCount;
        this.Status?.Validate();
        _ = this.To;
        _ = this.UserID;
    }

    public DataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPayload (DataPayload dataPayload) : base(dataPayload)
    {  }
    #pragma warning restore CS8618

    public DataPayload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataPayloadFromRaw.FromRawUnchecked"/>
    public static DataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataPayloadFromRaw : IFromRawJson<DataPayload>
{
    /// <inheritdoc/>
    public DataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(DataPayloadDirectionConverter))]
public enum DataPayloadDirection
{
    Inbound, Outbound
}sealed class DataPayloadDirectionConverter : JsonConverter<DataPayloadDirection>
{
    public override DataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>DataPayloadDirection.Inbound,
            "outbound"=>DataPayloadDirection.Outbound,
            _ =>(DataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataPayloadDirection.Inbound=>"inbound",
            DataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the fax.
/// </summary>
[JsonConverter(typeof(DataPayloadStatusConverter))]
public enum DataPayloadStatus
{
    Delivered
}sealed class DataPayloadStatusConverter : JsonConverter<DataPayloadStatus>
{
    public override DataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delivered"=>DataPayloadStatus.Delivered,
            _ =>(DataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataPayloadStatus.Delivered=>"delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(DataRecordTypeConverter))]
public enum DataRecordType
{
    Event
}sealed class DataRecordTypeConverter : JsonConverter<DataRecordType>
{
    public override DataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "event"=>DataRecordType.Event, _ =>(DataRecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Metadata about the webhook delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
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

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}