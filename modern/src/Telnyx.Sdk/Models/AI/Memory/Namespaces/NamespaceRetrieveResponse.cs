using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces;

[JsonConverter(typeof(JsonModelConverter<NamespaceRetrieveResponse, NamespaceRetrieveResponseFromRaw>))]
public sealed record class NamespaceRetrieveResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public NamespaceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamespaceRetrieveResponse (
        NamespaceRetrieveResponse namespaceRetrieveResponse
    ) : base(namespaceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NamespaceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NamespaceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NamespaceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NamespaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NamespaceRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class NamespaceRetrieveResponseFromRaw : IFromRawJson<NamespaceRetrieveResponse>
{
    /// <inheritdoc/>
    public NamespaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NamespaceRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string OperationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "operation_id"
            );
        }
        init { this._rawData.Set("operation_id", value); }
    }

    /// <summary>
    /// Where the write is. `completed`, `failed` and `cancelled` are terminal: stop
    /// polling at any of them, and treat `failed` and `cancelled` as writes that
    /// did not happen.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public string? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "completed_at"
            );
        }
        init { this._rawData.Set("completed_at", value); }
    }

    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OperationID;
        this.Status.Validate();
        _ = this.CompletedAt;
        _ = this.CreatedAt;
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
/// Where the write is. `completed`, `failed` and `cancelled` are terminal: stop polling
/// at any of them, and treat `failed` and `cancelled` as writes that did not happen.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Processing, Completed, Failed, Cancelled
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
            "pending"=>Status.Pending,
            "processing"=>Status.Processing,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            "cancelled"=>Status.Cancelled,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Processing=>"processing",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            Status.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}