using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<CallControlRetrievalTool, CallControlRetrievalToolFromRaw>))]
public sealed record class CallControlRetrievalTool : JsonModel
{
    public required CallControlBucketIds Retrieval {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CallControlBucketIds>(
                "retrieval"
            );
        }
        init { this._rawData.Set("retrieval", value); }
    }

    public required ApiEnum<string, CallControlRetrievalToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallControlRetrievalToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Retrieval.Validate();
        this.Type.Validate();
    }

    public CallControlRetrievalTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlRetrievalTool (
        CallControlRetrievalTool callControlRetrievalTool
    ) : base(callControlRetrievalTool)
    {  }
    #pragma warning restore CS8618

    public CallControlRetrievalTool (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlRetrievalTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlRetrievalToolFromRaw.FromRawUnchecked"/>
    public static CallControlRetrievalTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlRetrievalToolFromRaw : IFromRawJson<CallControlRetrievalTool>
{
    /// <inheritdoc/>
    public CallControlRetrievalTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlRetrievalTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CallControlRetrievalToolTypeConverter))]
public enum CallControlRetrievalToolType
{
    Retrieval
}sealed class CallControlRetrievalToolTypeConverter : JsonConverter<CallControlRetrievalToolType>
{
    public override CallControlRetrievalToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retrieval"=>CallControlRetrievalToolType.Retrieval,
            _ =>(CallControlRetrievalToolType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallControlRetrievalToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallControlRetrievalToolType.Retrieval=>"retrieval",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}