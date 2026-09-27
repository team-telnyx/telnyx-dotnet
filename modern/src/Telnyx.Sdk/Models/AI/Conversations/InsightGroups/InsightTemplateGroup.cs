using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.Insights;

namespace Telnyx.Sdk.Models.AI.Conversations.InsightGroups;

[JsonConverter(typeof(JsonModelConverter<InsightTemplateGroup, InsightTemplateGroupFromRaw>))]
public sealed record class InsightTemplateGroup : JsonModel
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

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public IReadOnlyList<InsightTemplate>? Insights {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InsightTemplate>>(
                "insights"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InsightTemplate>?>(
                "insights",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.Description;
        foreach (var item in this.Insights ?? [])
        {
            item.Validate();
        }
        _ = this.Webhook;
    }

    public InsightTemplateGroup ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightTemplateGroup (
        InsightTemplateGroup insightTemplateGroup
    ) : base(insightTemplateGroup)
    {  }
    #pragma warning restore CS8618

    public InsightTemplateGroup (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightTemplateGroup (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightTemplateGroupFromRaw.FromRawUnchecked"/>
    public static InsightTemplateGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsightTemplateGroupFromRaw : IFromRawJson<InsightTemplateGroup>
{
    /// <inheritdoc/>
    public InsightTemplateGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightTemplateGroup.FromRawUnchecked(rawData);
}