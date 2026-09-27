using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

[JsonConverter(typeof(JsonModelConverter<SourceDeleteResponse, SourceDeleteResponseFromRaw>))]
public sealed record class SourceDeleteResponse : JsonModel
{
    public required SourceDeleteResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SourceDeleteResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public SourceDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceDeleteResponse (
        SourceDeleteResponse sourceDeleteResponse
    ) : base(sourceDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SourceDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SourceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SourceDeleteResponse (SourceDeleteResponseData data) : this()
    { this.Data = data; }
}

class SourceDeleteResponseFromRaw : IFromRawJson<SourceDeleteResponse>
{
    /// <inheritdoc/>
    public SourceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SourceDeleteResponseData, SourceDeleteResponseDataFromRaw>))]
public sealed record class SourceDeleteResponseData : JsonModel
{
    /// <summary>
    /// Memories the profile held and no longer does, counted before and after across
    /// the whole profile: it includes memories derived from this source together
    /// with others, and anything else the profile lost in between. A report rather
    /// than an audit. The status carries the outcome.
    /// </summary>
    public required long MemoriesDeleted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "memories_deleted"
            );
        }
        init { this._rawData.Set("memories_deleted", value); }
    }

    public required string ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "profile_id"
            );
        }
        init { this._rawData.Set("profile_id", value); }
    }

    /// <summary>
    /// Identifies one source within its profile: an ingested session, or one remembered
    /// fact. Returned by `ingest` and `remember` when the write is accepted. Re-ingesting
    /// a session keeps its source id.
    /// </summary>
    public required string SourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source_id"
            );
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoriesDeleted;
        _ = this.ProfileID;
        _ = this.SourceID;
    }

    public SourceDeleteResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceDeleteResponseData (
        SourceDeleteResponseData sourceDeleteResponseData
    ) : base(sourceDeleteResponseData)
    {  }
    #pragma warning restore CS8618

    public SourceDeleteResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceDeleteResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceDeleteResponseDataFromRaw.FromRawUnchecked"/>
    public static SourceDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SourceDeleteResponseDataFromRaw : IFromRawJson<SourceDeleteResponseData>
{
    /// <inheritdoc/>
    public SourceDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceDeleteResponseData.FromRawUnchecked(rawData);
}