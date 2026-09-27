using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;
using Telnyx.Sdk.Models.Rcs.Agents;

namespace Telnyx.Sdk.Models.Messaging.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentListPageResponse, AgentListPageResponseFromRaw>))]
public sealed record class AgentListPageResponse : JsonModel
{
    public IReadOnlyList<RcsAgent>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsAgent>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RcsAgent>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingPaginationMeta0b38e7044b? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingPaginationMeta0b38e7044b>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public AgentListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentListPageResponse (
        AgentListPageResponse agentListPageResponse
    ) : base(agentListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AgentListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentListPageResponseFromRaw.FromRawUnchecked"/>
    public static AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentListPageResponseFromRaw : IFromRawJson<AgentListPageResponse>
{
    /// <inheritdoc/>
    public AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentListPageResponse.FromRawUnchecked(rawData);
}