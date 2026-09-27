using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI;

/// <summary>
/// A single search result representing one chunk of a conversation history record.
/// Records are split into chunks of up to 480 tokens with 64-token overlap at ingestion time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AIRetrieveConversationHistoriesResponse, AIRetrieveConversationHistoriesResponseFromRaw>))]
public sealed record class AIRetrieveConversationHistoriesResponse : JsonModel
{
    /// <summary>
    /// Unique chunk identifier.
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
    /// Zero-based index of this chunk within the parent record.
    /// </summary>
    public required long ChunkIndex {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "chunk_index"
            );
        }
        init { this._rawData.Set("chunk_index", value); }
    }

    /// <summary>
    /// Total number of chunks the parent record was split into.
    /// </summary>
    public required long ChunkTotal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "chunk_total"
            );
        }
        init { this._rawData.Set("chunk_total", value); }
    }

    /// <summary>
    /// When the record was chunked, embedded, and indexed (ISO 8601).
    /// </summary>
    public required System::DateTimeOffset IngestedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "ingested_at"
            );
        }
        init { this._rawData.Set("ingested_at", value); }
    }

    /// <summary>
    /// Identifier of the organization that owns this record.
    /// </summary>
    public required string OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "organization_id"
            );
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// When the original record was created (ISO 8601).
    /// </summary>
    public required System::DateTimeOffset RecordCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "record_created_at"
            );
        }
        init { this._rawData.Set("record_created_at", value); }
    }

    /// <summary>
    /// Identifier of the parent record. Multiple chunks from the same record share
    /// this ID.
    /// </summary>
    public required string RecordID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_id"
            );
        }
        init { this._rawData.Set("record_id", value); }
    }

    /// <summary>
    /// The region where this record is stored.
    /// </summary>
    public required ApiEnum<string, AIRetrieveConversationHistoriesResponseRegion> Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AIRetrieveConversationHistoriesResponseRegion>>(
                "region"
            );
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Cosine similarity score between the query vector and this chunk's vector.
    /// Higher values indicate greater semantic relevance.
    /// </summary>
    public required float Score {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "score"
            );
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// The text content of this chunk (up to 480 tokens).
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Identifier of the user who owns this record.
    /// </summary>
    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Arbitrary metadata attached to the record at ingestion time. Filterable via
    /// filter[field]=value query parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChunkIndex;
        _ = this.ChunkTotal;
        _ = this.IngestedAt;
        _ = this.OrganizationID;
        _ = this.RecordCreatedAt;
        _ = this.RecordID;
        this.Region.Validate();
        _ = this.Score;
        _ = this.Text;
        _ = this.UserID;
        _ = this.Metadata;
    }

    public AIRetrieveConversationHistoriesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIRetrieveConversationHistoriesResponse (
        AIRetrieveConversationHistoriesResponse aiRetrieveConversationHistoriesResponse
    ) : base(aiRetrieveConversationHistoriesResponse)
    {  }
    #pragma warning restore CS8618

    public AIRetrieveConversationHistoriesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AIRetrieveConversationHistoriesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AIRetrieveConversationHistoriesResponseFromRaw.FromRawUnchecked"/>
    public static AIRetrieveConversationHistoriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AIRetrieveConversationHistoriesResponseFromRaw : IFromRawJson<AIRetrieveConversationHistoriesResponse>
{
    /// <inheritdoc/>
    public AIRetrieveConversationHistoriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AIRetrieveConversationHistoriesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The region where this record is stored.
/// </summary>
[JsonConverter(typeof(AIRetrieveConversationHistoriesResponseRegionConverter))]
public enum AIRetrieveConversationHistoriesResponseRegion
{
    Usa, Deu, Aus, Uae
}sealed class AIRetrieveConversationHistoriesResponseRegionConverter : JsonConverter<AIRetrieveConversationHistoriesResponseRegion>
{
    public override AIRetrieveConversationHistoriesResponseRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USA"=>AIRetrieveConversationHistoriesResponseRegion.Usa,
            "DEU"=>AIRetrieveConversationHistoriesResponseRegion.Deu,
            "AUS"=>AIRetrieveConversationHistoriesResponseRegion.Aus,
            "UAE"=>AIRetrieveConversationHistoriesResponseRegion.Uae,
            _ =>(AIRetrieveConversationHistoriesResponseRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRetrieveConversationHistoriesResponseRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AIRetrieveConversationHistoriesResponseRegion.Usa=>"USA",
            AIRetrieveConversationHistoriesResponseRegion.Deu=>"DEU",
            AIRetrieveConversationHistoriesResponseRegion.Aus=>"AUS",
            AIRetrieveConversationHistoriesResponseRegion.Uae=>"UAE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}