using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations.InsightGroups;

[JsonConverter(typeof(JsonModelConverter<InsightTemplateGroupDetail, InsightTemplateGroupDetailFromRaw>))]
public sealed record class InsightTemplateGroupDetail : JsonModel
{
    public required InsightTemplateGroup Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InsightTemplateGroup>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public InsightTemplateGroupDetail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightTemplateGroupDetail (
        InsightTemplateGroupDetail insightTemplateGroupDetail
    ) : base(insightTemplateGroupDetail)
    {  }
    #pragma warning restore CS8618

    public InsightTemplateGroupDetail (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightTemplateGroupDetail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightTemplateGroupDetailFromRaw.FromRawUnchecked"/>
    public static InsightTemplateGroupDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InsightTemplateGroupDetail (InsightTemplateGroup data) : this()
    { this.Data = data; }
}

class InsightTemplateGroupDetailFromRaw : IFromRawJson<InsightTemplateGroupDetail>
{
    /// <inheritdoc/>
    public InsightTemplateGroupDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightTemplateGroupDetail.FromRawUnchecked(rawData);
}