using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<FaxMediaProcessed, FaxMediaProcessedFromRaw>))]
public sealed record class FaxMediaProcessed : JsonModel
{
    public FaxMediaProcessedData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxMediaProcessedData>(
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
    public FaxMediaProcessedMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxMediaProcessedMeta>(
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

    public FaxMediaProcessed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxMediaProcessed (FaxMediaProcessed faxMediaProcessed) : base(
        faxMediaProcessed
    )
    {  }
    #pragma warning restore CS8618

    public FaxMediaProcessed (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxMediaProcessed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxMediaProcessedFromRaw.FromRawUnchecked"/>
    public static FaxMediaProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxMediaProcessedFromRaw : IFromRawJson<FaxMediaProcessed>
{
    /// <inheritdoc/>
    public FaxMediaProcessed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxMediaProcessed.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FaxMediaProcessedData, FaxMediaProcessedDataFromRaw>))]
public sealed record class FaxMediaProcessedData : JsonModel
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
    public ApiEnum<string, FaxMediaProcessedDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxMediaProcessedDataEventType>>(
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

    public FaxMediaProcessedDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxMediaProcessedDataPayload>(
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
    public ApiEnum<string, FaxMediaProcessedDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxMediaProcessedDataRecordType>>(
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

    public FaxMediaProcessedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxMediaProcessedData (
        FaxMediaProcessedData faxMediaProcessedData
    ) : base(faxMediaProcessedData)
    {  }
    #pragma warning restore CS8618

    public FaxMediaProcessedData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxMediaProcessedData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxMediaProcessedDataFromRaw.FromRawUnchecked"/>
    public static FaxMediaProcessedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxMediaProcessedDataFromRaw : IFromRawJson<FaxMediaProcessedData>
{
    /// <inheritdoc/>
    public FaxMediaProcessedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxMediaProcessedData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(FaxMediaProcessedDataEventTypeConverter))]
public enum FaxMediaProcessedDataEventType
{
    FaxMediaProcessed
}sealed class FaxMediaProcessedDataEventTypeConverter : JsonConverter<FaxMediaProcessedDataEventType>
{
    public override FaxMediaProcessedDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fax.media.processed"=>FaxMediaProcessedDataEventType.FaxMediaProcessed,
            _ =>(FaxMediaProcessedDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxMediaProcessedDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxMediaProcessedDataEventType.FaxMediaProcessed=>"fax.media.processed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FaxMediaProcessedDataPayload, FaxMediaProcessedDataPayloadFromRaw>))]
public sealed record class FaxMediaProcessedDataPayload : JsonModel
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
    public ApiEnum<string, FaxMediaProcessedDataPayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxMediaProcessedDataPayloadDirection>>(
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
    public ApiEnum<string, FaxMediaProcessedDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxMediaProcessedDataPayloadStatus>>(
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

    public FaxMediaProcessedDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxMediaProcessedDataPayload (
        FaxMediaProcessedDataPayload faxMediaProcessedDataPayload
    ) : base(faxMediaProcessedDataPayload)
    {  }
    #pragma warning restore CS8618

    public FaxMediaProcessedDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxMediaProcessedDataPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxMediaProcessedDataPayloadFromRaw.FromRawUnchecked"/>
    public static FaxMediaProcessedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxMediaProcessedDataPayloadFromRaw : IFromRawJson<FaxMediaProcessedDataPayload>
{
    /// <inheritdoc/>
    public FaxMediaProcessedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxMediaProcessedDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(FaxMediaProcessedDataPayloadDirectionConverter))]
public enum FaxMediaProcessedDataPayloadDirection
{
    Inbound, Outbound
}sealed class FaxMediaProcessedDataPayloadDirectionConverter : JsonConverter<FaxMediaProcessedDataPayloadDirection>
{
    public override FaxMediaProcessedDataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>FaxMediaProcessedDataPayloadDirection.Inbound,
            "outbound"=>FaxMediaProcessedDataPayloadDirection.Outbound,
            _ =>(FaxMediaProcessedDataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxMediaProcessedDataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxMediaProcessedDataPayloadDirection.Inbound=>"inbound",
            FaxMediaProcessedDataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the fax.
/// </summary>
[JsonConverter(typeof(FaxMediaProcessedDataPayloadStatusConverter))]
public enum FaxMediaProcessedDataPayloadStatus
{
    MediaProcessed
}sealed class FaxMediaProcessedDataPayloadStatusConverter : JsonConverter<FaxMediaProcessedDataPayloadStatus>
{
    public override FaxMediaProcessedDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "media.processed"=>FaxMediaProcessedDataPayloadStatus.MediaProcessed,
            _ =>(FaxMediaProcessedDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxMediaProcessedDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxMediaProcessedDataPayloadStatus.MediaProcessed=>"media.processed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(FaxMediaProcessedDataRecordTypeConverter))]
public enum FaxMediaProcessedDataRecordType
{
    Event
}sealed class FaxMediaProcessedDataRecordTypeConverter : JsonConverter<FaxMediaProcessedDataRecordType>
{
    public override FaxMediaProcessedDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>FaxMediaProcessedDataRecordType.Event,
            _ =>(FaxMediaProcessedDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxMediaProcessedDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxMediaProcessedDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Metadata about the webhook delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FaxMediaProcessedMeta, FaxMediaProcessedMetaFromRaw>))]
public sealed record class FaxMediaProcessedMeta : JsonModel
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

    public FaxMediaProcessedMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxMediaProcessedMeta (
        FaxMediaProcessedMeta faxMediaProcessedMeta
    ) : base(faxMediaProcessedMeta)
    {  }
    #pragma warning restore CS8618

    public FaxMediaProcessedMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxMediaProcessedMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxMediaProcessedMetaFromRaw.FromRawUnchecked"/>
    public static FaxMediaProcessedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxMediaProcessedMetaFromRaw : IFromRawJson<FaxMediaProcessedMeta>
{
    /// <inheritdoc/>
    public FaxMediaProcessedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxMediaProcessedMeta.FromRawUnchecked(rawData);
}