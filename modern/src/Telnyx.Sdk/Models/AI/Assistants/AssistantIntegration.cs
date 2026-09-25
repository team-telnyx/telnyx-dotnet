using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Reference to a connected integration attached to an assistant. Discover available
/// integrations with `/ai/integrations` and connected integrations with `/ai/integrations/connections`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssistantIntegration, AssistantIntegrationFromRaw>))]
public sealed record class AssistantIntegration : JsonModel
{
    /// <summary>
    /// Catalog integration ID to attach. This is the `id` from the integrations
    /// catalog at `/ai/integrations` (the same value also appears as `integration_id`
    /// on entries returned by `/ai/integrations/connections`). It is **not** the
    /// connection-level `id` from `/ai/integrations/connections`.
    /// </summary>
    public required string IntegrationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "integration_id"
            );
        }
        init { this._rawData.Set("integration_id", value); }
    }

    /// <summary>
    /// Optional per-assistant allowlist of integration tool names. When omitted or
    /// empty, all tools allowed by the connected integration are available to the assistant.
    /// </summary>
    public IReadOnlyList<string>? AllowedList {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_list"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_list",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IntegrationID;
        _ = this.AllowedList;
    }

    public AssistantIntegration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantIntegration (
        AssistantIntegration assistantIntegration
    ) : base(assistantIntegration)
    {  }
    #pragma warning restore CS8618

    public AssistantIntegration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantIntegration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantIntegrationFromRaw.FromRawUnchecked"/>
    public static AssistantIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AssistantIntegration (string integrationID) : this()
    { this.IntegrationID = integrationID; }
}

class AssistantIntegrationFromRaw : IFromRawJson<AssistantIntegration>
{
    /// <inheritdoc/>
    public AssistantIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantIntegration.FromRawUnchecked(rawData);
}