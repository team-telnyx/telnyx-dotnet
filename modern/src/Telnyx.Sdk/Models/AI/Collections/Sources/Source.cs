using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
{
    /// <summary>
    /// Identifies one source within its profile: an ingested session, or one remembered
    /// fact. Returned by `ingest` and `remember` when the write is accepted. Re-ingesting
    /// a session keeps its source id.
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
    /// Memories extracted from this source. A memory derived from several sources
    /// is not counted here.
    /// </summary>
    public required long MemoryCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "memory_count"
            );
        }
        init { this._rawData.Set("memory_count", value); }
    }

    /// <summary>
    /// The session this source was ingested as. Null for a remembered fact.
    /// </summary>
    public required string? SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// When the source was first stored.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// When the source was last written; re-ingesting moves it.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.MemoryCount;
        _ = this.SessionID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public Source ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source (Source source) : base(source)
    {  }
    #pragma warning restore CS8618

    public Source (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Source (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Source.FromRawUnchecked(rawData);
}