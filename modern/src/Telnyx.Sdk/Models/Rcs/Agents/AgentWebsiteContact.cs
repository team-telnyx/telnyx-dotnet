using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentWebsiteContact, AgentWebsiteContactFromRaw>))]
public sealed record class AgentWebsiteContact : JsonModel
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

    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Label;
        _ = this.Url;
    }

    public AgentWebsiteContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentWebsiteContact (AgentWebsiteContact agentWebsiteContact) : base(
        agentWebsiteContact
    )
    {  }
    #pragma warning restore CS8618

    public AgentWebsiteContact (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentWebsiteContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentWebsiteContactFromRaw.FromRawUnchecked"/>
    public static AgentWebsiteContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentWebsiteContactFromRaw : IFromRawJson<AgentWebsiteContact>
{
    /// <inheritdoc/>
    public AgentWebsiteContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentWebsiteContact.FromRawUnchecked(rawData);
}