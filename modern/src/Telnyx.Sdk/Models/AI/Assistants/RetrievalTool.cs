using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Chat;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<RetrievalTool, RetrievalToolFromRaw>))]
public sealed record class RetrievalTool : JsonModel
{
    public required BucketIds Retrieval {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BucketIds>(
                "retrieval"
            );
        }
        init { this._rawData.Set("retrieval", value); }
    }

    public required ApiEnum<string, RetrievalToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RetrievalToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Retrieval.Validate();
        this.Type.Validate();
        _ = this.Shared;
    }

    public RetrievalTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalTool (RetrievalTool retrievalTool) : base(retrievalTool)
    {  }
    #pragma warning restore CS8618

    public RetrievalTool (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalToolFromRaw.FromRawUnchecked"/>
    public static RetrievalTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RetrievalToolFromRaw : IFromRawJson<RetrievalTool>
{
    /// <inheritdoc/>
    public RetrievalTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RetrievalTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetrievalToolTypeConverter))]
public enum RetrievalToolType
{
    Retrieval
}sealed class RetrievalToolTypeConverter : JsonConverter<RetrievalToolType>
{
    public override RetrievalToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retrieval"=>RetrievalToolType.Retrieval,
            _ =>(RetrievalToolType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetrievalToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RetrievalToolType.Retrieval=>"retrieval",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}