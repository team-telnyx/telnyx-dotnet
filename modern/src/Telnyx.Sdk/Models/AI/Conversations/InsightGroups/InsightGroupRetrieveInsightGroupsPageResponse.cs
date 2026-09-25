using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Conversations.InsightGroups;

[JsonConverter(typeof(JsonModelConverter<InsightGroupRetrieveInsightGroupsPageResponse, InsightGroupRetrieveInsightGroupsPageResponseFromRaw>))]
public sealed record class InsightGroupRetrieveInsightGroupsPageResponse : JsonModel
{
    public required IReadOnlyList<InsightTemplateGroup> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InsightTemplateGroup>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InsightTemplateGroup>>(
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

    public InsightGroupRetrieveInsightGroupsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightGroupRetrieveInsightGroupsPageResponse (
        InsightGroupRetrieveInsightGroupsPageResponse insightGroupRetrieveInsightGroupsPageResponse
    ) : base(insightGroupRetrieveInsightGroupsPageResponse)
    {  }
    #pragma warning restore CS8618

    public InsightGroupRetrieveInsightGroupsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightGroupRetrieveInsightGroupsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightGroupRetrieveInsightGroupsPageResponseFromRaw.FromRawUnchecked"/>
    public static InsightGroupRetrieveInsightGroupsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsightGroupRetrieveInsightGroupsPageResponseFromRaw : IFromRawJson<InsightGroupRetrieveInsightGroupsPageResponse>
{
    /// <inheritdoc/>
    public InsightGroupRetrieveInsightGroupsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightGroupRetrieveInsightGroupsPageResponse.FromRawUnchecked(rawData);
}