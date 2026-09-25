using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<InsightSettings, InsightSettingsFromRaw>))]
public sealed record class InsightSettings : JsonModel
{
    /// <summary>
    /// Reference to an Insight Group. Insights in this group will be run automatically
    /// for all the assistant's conversations.
    /// </summary>
    public string? InsightGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "insight_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("insight_group_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.InsightGroupID; }

    public InsightSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightSettings (InsightSettings insightSettings) : base(
        insightSettings
    )
    {  }
    #pragma warning restore CS8618

    public InsightSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightSettingsFromRaw.FromRawUnchecked"/>
    public static InsightSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsightSettingsFromRaw : IFromRawJson<InsightSettings>
{
    /// <inheritdoc/>
    public InsightSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightSettings.FromRawUnchecked(rawData);
}