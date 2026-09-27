using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Queues;

[JsonConverter(typeof(JsonModelConverter<global::Telnyx.Sdk.Models.Queues.Queue, QueueFromRaw>))]
public sealed record class Queue : JsonModel
{
    /// <summary>
    /// Uniquely identifies the queue
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
    /// The average time that the calls currently in the queue have spent waiting,
    /// given in seconds.
    /// </summary>
    public required long AverageWaitTimeSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "average_wait_time_secs"
            );
        }
        init { this._rawData.Set("average_wait_time_secs", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the queue was created
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The number of calls currently in the queue
    /// </summary>
    public required long CurrentSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "current_size"
            );
        }
        init { this._rawData.Set("current_size", value); }
    }

    /// <summary>
    /// The maximum number of calls allowed in the queue
    /// </summary>
    public required long MaxSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "max_size"
            );
        }
        init { this._rawData.Set("max_size", value); }
    }

    /// <summary>
    /// Name of the queue
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the queue was last updated
    /// </summary>
    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AverageWaitTimeSecs;
        _ = this.CreatedAt;
        _ = this.CurrentSize;
        _ = this.MaxSize;
        _ = this.Name;
        this.RecordType.Validate();
        _ = this.UpdatedAt;
    }

    public Queue ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Queue (global::Telnyx.Sdk.Models.Queues.Queue queue) : base(queue)
    {  }
    #pragma warning restore CS8618

    public Queue (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Queue (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueFromRaw.FromRawUnchecked"/>
    public static global::Telnyx.Sdk.Models.Queues.Queue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueFromRaw : IFromRawJson<global::Telnyx.Sdk.Models.Queues.Queue>
{
    /// <inheritdoc/>
    public global::Telnyx.Sdk.Models.Queues.Queue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>global::Telnyx.Sdk.Models.Queues.Queue.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Queue
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "queue"=>RecordType.Queue, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Queue=>"queue",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}