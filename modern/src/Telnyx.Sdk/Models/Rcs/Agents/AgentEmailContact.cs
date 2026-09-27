using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentEmailContact, AgentEmailContactFromRaw>))]
public sealed record class AgentEmailContact : JsonModel
{
    public required string Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "address"
            );
        }
        init { this._rawData.Set("address", value); }
    }

    public required string Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "label"
            );
        }
        init { this._rawData.Set("label", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.Label;
    }

    public AgentEmailContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentEmailContact (AgentEmailContact agentEmailContact) : base(
        agentEmailContact
    )
    {  }
    #pragma warning restore CS8618

    public AgentEmailContact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentEmailContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentEmailContactFromRaw.FromRawUnchecked"/>
    public static AgentEmailContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentEmailContactFromRaw : IFromRawJson<AgentEmailContact>
{
    /// <inheritdoc/>
    public AgentEmailContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentEmailContact.FromRawUnchecked(rawData);
}