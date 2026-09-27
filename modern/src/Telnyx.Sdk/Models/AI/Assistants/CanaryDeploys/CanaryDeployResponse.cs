using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

/// <summary>
/// Response shape.
///
/// <para>Always carries ``rules`` (canonical).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CanaryDeployResponse, CanaryDeployResponseFromRaw>))]
public sealed record class CanaryDeployResponse : JsonModel
{
    public required string AssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "assistant_id"
            );
        }
        init { this._rawData.Set("assistant_id", value); }
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

    public required IReadOnlyList<RuleOutput> Rules {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RuleOutput>>(
                "rules"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<RuleOutput>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssistantID;
        _ = this.CreatedAt;
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public CanaryDeployResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CanaryDeployResponse (
        CanaryDeployResponse canaryDeployResponse
    ) : base(canaryDeployResponse)
    {  }
    #pragma warning restore CS8618

    public CanaryDeployResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CanaryDeployResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CanaryDeployResponseFromRaw.FromRawUnchecked"/>
    public static CanaryDeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CanaryDeployResponseFromRaw : IFromRawJson<CanaryDeployResponse>
{
    /// <inheritdoc/>
    public CanaryDeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CanaryDeployResponse.FromRawUnchecked(rawData);
}