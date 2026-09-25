using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

[JsonConverter(typeof(JsonModelConverter<MemoryListResponse, MemoryListResponseFromRaw>))]
public sealed record class MemoryListResponse : JsonModel
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

    /// <summary>
    /// The source this memory was extracted from. Set for a fact, which comes from
    /// exactly one source; null for a memory derived from other memories. Read it
    /// with `GET .../sources/{source_id}`. A source deleted a moment ago can still
    /// be named here, and then answers 404.
    /// </summary>
    public required string? SourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source_id"
            );
        }
        init { this._rawData.Set("source_id", value); }
    }

    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    public string? RecordedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recorded_at"
            );
        }
        init { this._rawData.Set("recorded_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SourceID;
        _ = this.Text;
        _ = this.RecordedAt;
    }

    public MemoryListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListResponse (MemoryListResponse memoryListResponse) : base(
        memoryListResponse
    )
    {  }
    #pragma warning restore CS8618

    public MemoryListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MemoryListResponseFromRaw.FromRawUnchecked"/>
    public static MemoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MemoryListResponseFromRaw : IFromRawJson<MemoryListResponse>
{
    /// <inheritdoc/>
    public MemoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MemoryListResponse.FromRawUnchecked(rawData);
}