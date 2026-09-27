using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

[JsonConverter(typeof(JsonModelConverter<MemoryRetrieveResponse, MemoryRetrieveResponseFromRaw>))]
public sealed record class MemoryRetrieveResponse : JsonModel
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

    public MemoryRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryRetrieveResponse (
        MemoryRetrieveResponse memoryRetrieveResponse
    ) : base(memoryRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MemoryRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MemoryRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MemoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MemoryRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class MemoryRetrieveResponseFromRaw : IFromRawJson<MemoryRetrieveResponse>
{
    /// <inheritdoc/>
    public MemoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MemoryRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    /// The ids of the memories this one was derived from. Read each with `GET .../memories/{memory_id}`
    /// to reach its `source_id`. Set for a derived memory; null for a fact.
    /// </summary>
    public required IReadOnlyList<string>? DerivedFrom {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "derived_from"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>?>(
                "derived_from",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.DerivedFrom;
        _ = this.SourceID;
        _ = this.Text;
        _ = this.RecordedAt;
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
}