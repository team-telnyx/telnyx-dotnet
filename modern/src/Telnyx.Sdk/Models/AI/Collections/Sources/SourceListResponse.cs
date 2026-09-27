using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

[JsonConverter(typeof(JsonModelConverter<SourceListResponse, SourceListResponseFromRaw>))]
public sealed record class SourceListResponse : JsonModel
{
    public IReadOnlyList<CollectionsSource>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CollectionsSource>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CollectionsSource>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public SourceListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceListResponse (SourceListResponse sourceListResponse) : base(
        sourceListResponse
    )
    {  }
    #pragma warning restore CS8618

    public SourceListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceListResponseFromRaw.FromRawUnchecked"/>
    public static SourceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SourceListResponseFromRaw : IFromRawJson<SourceListResponse>
{
    /// <inheritdoc/>
    public SourceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceListResponse.FromRawUnchecked(rawData);
}