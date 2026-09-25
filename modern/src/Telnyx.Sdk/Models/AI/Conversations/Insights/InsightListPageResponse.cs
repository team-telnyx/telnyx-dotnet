using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Conversations.Insights;

[JsonConverter(typeof(JsonModelConverter<InsightListPageResponse, InsightListPageResponseFromRaw>))]
public sealed record class InsightListPageResponse : JsonModel
{
    public required IReadOnlyList<InsightTemplate> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InsightTemplate>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InsightTemplate>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public InsightListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightListPageResponse (
        InsightListPageResponse insightListPageResponse
    ) : base(insightListPageResponse)
    {  }
    #pragma warning restore CS8618

    public InsightListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightListPageResponseFromRaw.FromRawUnchecked"/>
    public static InsightListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsightListPageResponseFromRaw : IFromRawJson<InsightListPageResponse>
{
    /// <inheritdoc/>
    public InsightListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightListPageResponse.FromRawUnchecked(rawData);
}