using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations.Insights;

[JsonConverter(typeof(JsonModelConverter<InsightTemplateDetail, InsightTemplateDetailFromRaw>))]
public sealed record class InsightTemplateDetail : JsonModel
{
    public required InsightTemplate Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InsightTemplate>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public InsightTemplateDetail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightTemplateDetail (
        InsightTemplateDetail insightTemplateDetail
    ) : base(insightTemplateDetail)
    {  }
    #pragma warning restore CS8618

    public InsightTemplateDetail (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightTemplateDetail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightTemplateDetailFromRaw.FromRawUnchecked"/>
    public static InsightTemplateDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InsightTemplateDetail (InsightTemplate data) : this()
    { this.Data = data; }
}

class InsightTemplateDetailFromRaw : IFromRawJson<InsightTemplateDetail>
{
    /// <inheritdoc/>
    public InsightTemplateDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightTemplateDetail.FromRawUnchecked(rawData);
}