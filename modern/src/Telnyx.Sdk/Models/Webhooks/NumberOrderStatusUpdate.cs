using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberOrders;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdate, NumberOrderStatusUpdateFromRaw>))]
public sealed record class NumberOrderStatusUpdate : JsonModel
{
    public required NumberOrderStatusUpdateData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderStatusUpdateData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required NumberOrderStatusUpdateMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderStatusUpdateMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Meta.Validate();
    }

    public NumberOrderStatusUpdate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdate (
        NumberOrderStatusUpdate numberOrderStatusUpdate
    ) : base(numberOrderStatusUpdate)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderStatusUpdateFromRaw : IFromRawJson<NumberOrderStatusUpdate>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateData, NumberOrderStatusUpdateDataFromRaw>))]
public sealed record class NumberOrderStatusUpdateData : JsonModel
{
    /// <summary>
    /// Unique identifier for the event
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The type of event being sent
    /// </summary>
    public required ApiEnum<string, NumberOrderStatusUpdateDataEventType> EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NumberOrderStatusUpdateDataEventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required NumberOrderWithPhoneNumbers Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderWithPhoneNumbers>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    /// <summary>
    /// Type of record
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
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
        _ = this.RecordType;
    }

    public NumberOrderStatusUpdateData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateData (
        NumberOrderStatusUpdateData numberOrderStatusUpdateData
    ) : base(numberOrderStatusUpdateData)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateDataFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberOrderStatusUpdateDataFromRaw : IFromRawJson<NumberOrderStatusUpdateData>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being sent
/// </summary>
[JsonConverter(typeof(NumberOrderStatusUpdateDataEventTypeConverter))]
public enum NumberOrderStatusUpdateDataEventType
{
    NumberOrderComplete
}sealed class NumberOrderStatusUpdateDataEventTypeConverter : JsonConverter<NumberOrderStatusUpdateDataEventType>
{
    public override NumberOrderStatusUpdateDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "number_order.complete"=>NumberOrderStatusUpdateDataEventType.NumberOrderComplete,
            _ =>(NumberOrderStatusUpdateDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumberOrderStatusUpdateDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberOrderStatusUpdateDataEventType.NumberOrderComplete=>"number_order.complete",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateMeta, NumberOrderStatusUpdateMetaFromRaw>))]
public sealed record class NumberOrderStatusUpdateMeta : JsonModel
{
    /// <summary>
    /// Webhook delivery attempt number
    /// </summary>
    public required long Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "attempt"
            );
        }
        init { this._rawData.Set("attempt", value); }
    }

    /// <summary>
    /// URL where the webhook was delivered
    /// </summary>
    public required string DeliveredTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "delivered_to"
            );
        }
        init { this._rawData.Set("delivered_to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempt;
        _ = this.DeliveredTo;
    }

    public NumberOrderStatusUpdateMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateMeta (
        NumberOrderStatusUpdateMeta numberOrderStatusUpdateMeta
    ) : base(numberOrderStatusUpdateMeta)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateMetaFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberOrderStatusUpdateMetaFromRaw : IFromRawJson<NumberOrderStatusUpdateMeta>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateMeta.FromRawUnchecked(rawData);
}