using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Collections.Settings;

/// <summary>
/// How documents are retrieved when searching the collection.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetrievalSettings, RetrievalSettingsFromRaw>))]
public sealed record class RetrievalSettings : JsonModel
{
    /// <summary>
    /// Retrieval strategy. `vector` runs semantic similarity search; `hybrid` combines
    /// vector similarity with keyword matching; `keyword` runs lexical (BM25) matching.
    /// `keyword` is not accepted yet: setting it returns 422 `unsupported_retrieval_type`.
    /// A collection set to `hybrid` is accepted here but cannot be searched until
    /// hybrid execution ships.
    /// </summary>
    public ApiEnum<string, RetrievalType>? RetrievalType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RetrievalType>>(
                "retrieval_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retrieval_type", value);
        }
    }

    /// <summary>
    /// Number of top results to retrieve (1–50).
    /// </summary>
    public long? TopK {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "top_k"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("top_k", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.RetrievalType?.Validate();
        _ = this.TopK;
    }

    public RetrievalSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalSettings (RetrievalSettings retrievalSettings) : base(
        retrievalSettings
    )
    {  }
    #pragma warning restore CS8618

    public RetrievalSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalSettingsFromRaw.FromRawUnchecked"/>
    public static RetrievalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RetrievalSettingsFromRaw : IFromRawJson<RetrievalSettings>
{
    /// <inheritdoc/>
    public RetrievalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RetrievalSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Retrieval strategy. `vector` runs semantic similarity search; `hybrid` combines
/// vector similarity with keyword matching; `keyword` runs lexical (BM25) matching.
/// `keyword` is not accepted yet: setting it returns 422 `unsupported_retrieval_type`.
/// A collection set to `hybrid` is accepted here but cannot be searched until hybrid
/// execution ships.
/// </summary>
[JsonConverter(typeof(RetrievalTypeConverter))]
public enum RetrievalType
{
    Vector, Hybrid
}sealed class RetrievalTypeConverter : JsonConverter<RetrievalType>
{
    public override RetrievalType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vector"=>RetrievalType.Vector,
            "hybrid"=>RetrievalType.Hybrid,
            _ =>(RetrievalType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetrievalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RetrievalType.Vector=>"vector",
            RetrievalType.Hybrid=>"hybrid",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}