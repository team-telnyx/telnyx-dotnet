using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WhatsappAccountUpdate, WhatsappAccountUpdateFromRaw>))]
public sealed record class WhatsappAccountUpdate : JsonModel
{
    public required WhatsappAccountUpdateData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappAccountUpdateData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public WhatsappAccountUpdate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappAccountUpdate (
        WhatsappAccountUpdate whatsappAccountUpdate
    ) : base(whatsappAccountUpdate)
    {  }
    #pragma warning restore CS8618

    public WhatsappAccountUpdate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappAccountUpdate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappAccountUpdateFromRaw.FromRawUnchecked"/>
    public static WhatsappAccountUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WhatsappAccountUpdate (WhatsappAccountUpdateData data) : this()
    { this.Data = data; }
}

class WhatsappAccountUpdateFromRaw : IFromRawJson<WhatsappAccountUpdate>
{
    /// <inheritdoc/>
    public WhatsappAccountUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappAccountUpdate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappAccountUpdateData, WhatsappAccountUpdateDataFromRaw>))]
public sealed record class WhatsappAccountUpdateData : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, WhatsappAccountUpdateDataEventType> EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappAccountUpdateDataEventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required WhatsappAccountUpdateDataPayload Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappAccountUpdateDataPayload>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    public required ApiEnum<string, WhatsappAccountUpdateDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappAccountUpdateDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType.Validate();
        _ = this.OccurredAt;
        this.Payload.Validate();
        this.RecordType.Validate();
    }

    public WhatsappAccountUpdateData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappAccountUpdateData (
        WhatsappAccountUpdateData whatsappAccountUpdateData
    ) : base(whatsappAccountUpdateData)
    {  }
    #pragma warning restore CS8618

    public WhatsappAccountUpdateData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappAccountUpdateData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappAccountUpdateDataFromRaw.FromRawUnchecked"/>
    public static WhatsappAccountUpdateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappAccountUpdateDataFromRaw : IFromRawJson<WhatsappAccountUpdateData>
{
    /// <inheritdoc/>
    public WhatsappAccountUpdateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappAccountUpdateData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappAccountUpdateDataEventTypeConverter))]
public enum WhatsappAccountUpdateDataEventType
{
    WhatsappAccountUpdate
}sealed class WhatsappAccountUpdateDataEventTypeConverter : JsonConverter<WhatsappAccountUpdateDataEventType>
{
    public override WhatsappAccountUpdateDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp.account.update"=>WhatsappAccountUpdateDataEventType.WhatsappAccountUpdate,
            _ =>(WhatsappAccountUpdateDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappAccountUpdateDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappAccountUpdateDataEventType.WhatsappAccountUpdate=>"whatsapp.account.update",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WhatsappAccountUpdateDataPayload, WhatsappAccountUpdateDataPayloadFromRaw>))]
public sealed record class WhatsappAccountUpdateDataPayload : JsonModel
{
    /// <summary>
    /// Account event reported by Meta. Coexistence lifecycle values include `ACCOUNT_OFFBOARDED`,
    /// `ACCOUNT_RECONNECTED`, and `PARTNER_REMOVED`. Preserve unknown values for
    /// forward compatibility.
    /// </summary>
    public required string Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event"
            );
        }
        init { this._rawData.Set("event", value); }
    }

    public required ApiEnum<string, WhatsappAccountUpdateDataPayloadRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappAccountUpdateDataPayloadRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Meta WhatsApp Business Account identifier.
    /// </summary>
    public required string WabaID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "waba_id"
            );
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Event;
        this.RecordType.Validate();
        _ = this.WabaID;
    }

    public WhatsappAccountUpdateDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappAccountUpdateDataPayload (
        WhatsappAccountUpdateDataPayload whatsappAccountUpdateDataPayload
    ) : base(whatsappAccountUpdateDataPayload)
    {  }
    #pragma warning restore CS8618

    public WhatsappAccountUpdateDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappAccountUpdateDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappAccountUpdateDataPayloadFromRaw.FromRawUnchecked"/>
    public static WhatsappAccountUpdateDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappAccountUpdateDataPayloadFromRaw : IFromRawJson<WhatsappAccountUpdateDataPayload>
{
    /// <inheritdoc/>
    public WhatsappAccountUpdateDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappAccountUpdateDataPayload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappAccountUpdateDataPayloadRecordTypeConverter))]
public enum WhatsappAccountUpdateDataPayloadRecordType
{
    WhatsappAccount
}sealed class WhatsappAccountUpdateDataPayloadRecordTypeConverter : JsonConverter<WhatsappAccountUpdateDataPayloadRecordType>
{
    public override WhatsappAccountUpdateDataPayloadRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp_account"=>WhatsappAccountUpdateDataPayloadRecordType.WhatsappAccount,
            _ =>(WhatsappAccountUpdateDataPayloadRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappAccountUpdateDataPayloadRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappAccountUpdateDataPayloadRecordType.WhatsappAccount=>"whatsapp_account",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappAccountUpdateDataRecordTypeConverter))]
public enum WhatsappAccountUpdateDataRecordType
{
    Event
}sealed class WhatsappAccountUpdateDataRecordTypeConverter : JsonConverter<WhatsappAccountUpdateDataRecordType>
{
    public override WhatsappAccountUpdateDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>WhatsappAccountUpdateDataRecordType.Event,
            _ =>(WhatsappAccountUpdateDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappAccountUpdateDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappAccountUpdateDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}