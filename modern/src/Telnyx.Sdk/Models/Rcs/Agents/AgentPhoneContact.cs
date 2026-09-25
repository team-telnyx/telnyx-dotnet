using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentPhoneContact, AgentPhoneContactFromRaw>))]
public sealed record class AgentPhoneContact : JsonModel
{
    public required string Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "label"
            );
        }
        init { this._rawData.Set("label", value); }
    }

    public required string Number {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "number"
            );
        }
        init { this._rawData.Set("number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Label;
        _ = this.Number;
    }

    public AgentPhoneContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentPhoneContact (AgentPhoneContact agentPhoneContact) : base(
        agentPhoneContact
    )
    {  }
    #pragma warning restore CS8618

    public AgentPhoneContact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentPhoneContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentPhoneContactFromRaw.FromRawUnchecked"/>
    public static AgentPhoneContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentPhoneContactFromRaw : IFromRawJson<AgentPhoneContact>
{
    /// <inheritdoc/>
    public AgentPhoneContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentPhoneContact.FromRawUnchecked(rawData);
}