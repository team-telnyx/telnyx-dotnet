using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<FaxSendingStarted, FaxSendingStartedFromRaw>))]
public sealed record class FaxSendingStarted : JsonModel
{
    public FaxSendingStartedData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxSendingStartedData>(
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
    public FaxSendingStartedMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxSendingStartedMeta>(
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

    public FaxSendingStarted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxSendingStarted (FaxSendingStarted faxSendingStarted) : base(
        faxSendingStarted
    )
    {  }
    #pragma warning restore CS8618

    public FaxSendingStarted (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxSendingStarted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxSendingStartedFromRaw.FromRawUnchecked"/>
    public static FaxSendingStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxSendingStartedFromRaw : IFromRawJson<FaxSendingStarted>
{
    /// <inheritdoc/>
    public FaxSendingStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxSendingStarted.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FaxSendingStartedData, FaxSendingStartedDataFromRaw>))]
public sealed record class FaxSendingStartedData : JsonModel
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
    public ApiEnum<string, FaxSendingStartedDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxSendingStartedDataEventType>>(
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

    public FaxSendingStartedDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxSendingStartedDataPayload>(
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
    public ApiEnum<string, FaxSendingStartedDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxSendingStartedDataRecordType>>(
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

    public FaxSendingStartedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxSendingStartedData (
        FaxSendingStartedData faxSendingStartedData
    ) : base(faxSendingStartedData)
    {  }
    #pragma warning restore CS8618

    public FaxSendingStartedData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxSendingStartedData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxSendingStartedDataFromRaw.FromRawUnchecked"/>
    public static FaxSendingStartedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxSendingStartedDataFromRaw : IFromRawJson<FaxSendingStartedData>
{
    /// <inheritdoc/>
    public FaxSendingStartedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxSendingStartedData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(FaxSendingStartedDataEventTypeConverter))]
public enum FaxSendingStartedDataEventType
{
    FaxSendingStarted
}sealed class FaxSendingStartedDataEventTypeConverter : JsonConverter<FaxSendingStartedDataEventType>
{
    public override FaxSendingStartedDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fax.sending.started"=>FaxSendingStartedDataEventType.FaxSendingStarted,
            _ =>(FaxSendingStartedDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxSendingStartedDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxSendingStartedDataEventType.FaxSendingStarted=>"fax.sending.started",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FaxSendingStartedDataPayload, FaxSendingStartedDataPayloadFromRaw>))]
public sealed record class FaxSendingStartedDataPayload : JsonModel
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
    public ApiEnum<string, FaxSendingStartedDataPayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxSendingStartedDataPayloadDirection>>(
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
    public ApiEnum<string, FaxSendingStartedDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxSendingStartedDataPayloadStatus>>(
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

    public FaxSendingStartedDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxSendingStartedDataPayload (
        FaxSendingStartedDataPayload faxSendingStartedDataPayload
    ) : base(faxSendingStartedDataPayload)
    {  }
    #pragma warning restore CS8618

    public FaxSendingStartedDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxSendingStartedDataPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxSendingStartedDataPayloadFromRaw.FromRawUnchecked"/>
    public static FaxSendingStartedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxSendingStartedDataPayloadFromRaw : IFromRawJson<FaxSendingStartedDataPayload>
{
    /// <inheritdoc/>
    public FaxSendingStartedDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxSendingStartedDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the fax.
/// </summary>
[JsonConverter(typeof(FaxSendingStartedDataPayloadDirectionConverter))]
public enum FaxSendingStartedDataPayloadDirection
{
    Inbound, Outbound
}sealed class FaxSendingStartedDataPayloadDirectionConverter : JsonConverter<FaxSendingStartedDataPayloadDirection>
{
    public override FaxSendingStartedDataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>FaxSendingStartedDataPayloadDirection.Inbound,
            "outbound"=>FaxSendingStartedDataPayloadDirection.Outbound,
            _ =>(FaxSendingStartedDataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxSendingStartedDataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxSendingStartedDataPayloadDirection.Inbound=>"inbound",
            FaxSendingStartedDataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the fax.
/// </summary>
[JsonConverter(typeof(FaxSendingStartedDataPayloadStatusConverter))]
public enum FaxSendingStartedDataPayloadStatus
{
    Sending
}sealed class FaxSendingStartedDataPayloadStatusConverter : JsonConverter<FaxSendingStartedDataPayloadStatus>
{
    public override FaxSendingStartedDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sending"=>FaxSendingStartedDataPayloadStatus.Sending,
            _ =>(FaxSendingStartedDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxSendingStartedDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxSendingStartedDataPayloadStatus.Sending=>"sending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(FaxSendingStartedDataRecordTypeConverter))]
public enum FaxSendingStartedDataRecordType
{
    Event
}sealed class FaxSendingStartedDataRecordTypeConverter : JsonConverter<FaxSendingStartedDataRecordType>
{
    public override FaxSendingStartedDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>FaxSendingStartedDataRecordType.Event,
            _ =>(FaxSendingStartedDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxSendingStartedDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxSendingStartedDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Metadata about the webhook delivery.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FaxSendingStartedMeta, FaxSendingStartedMetaFromRaw>))]
public sealed record class FaxSendingStartedMeta : JsonModel
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

    public FaxSendingStartedMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxSendingStartedMeta (
        FaxSendingStartedMeta faxSendingStartedMeta
    ) : base(faxSendingStartedMeta)
    {  }
    #pragma warning restore CS8618

    public FaxSendingStartedMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxSendingStartedMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxSendingStartedMetaFromRaw.FromRawUnchecked"/>
    public static FaxSendingStartedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxSendingStartedMetaFromRaw : IFromRawJson<FaxSendingStartedMeta>
{
    /// <inheritdoc/>
    public FaxSendingStartedMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxSendingStartedMeta.FromRawUnchecked(rawData);
}