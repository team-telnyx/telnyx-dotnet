using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentTestingConfiguration, AgentTestingConfigurationFromRaw>))]
public sealed record class AgentTestingConfiguration : JsonModel
{
    /// <summary>
    /// A publicly accessible test video or evidence URL.
    /// </summary>
    public required string TestUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "test_url"
            );
        }
        init { this._rawData.Set("test_url", value); }
    }

    public string? AdditionalInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "additional_information"
            );
        }
        init { this._rawData.Set("additional_information", value); }
    }

    public string? MessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_id"
            );
        }
        init { this._rawData.Set("message_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TestUrl;
        _ = this.AdditionalInformation;
        _ = this.MessageID;
    }

    public AgentTestingConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTestingConfiguration (
        AgentTestingConfiguration agentTestingConfiguration
    ) : base(agentTestingConfiguration)
    {  }
    #pragma warning restore CS8618

    public AgentTestingConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentTestingConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentTestingConfigurationFromRaw.FromRawUnchecked"/>
    public static AgentTestingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentTestingConfiguration (string testUrl) : this()
    { this.TestUrl = testUrl; }
}

class AgentTestingConfigurationFromRaw : IFromRawJson<AgentTestingConfiguration>
{
    /// <inheritdoc/>
    public AgentTestingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentTestingConfiguration.FromRawUnchecked(rawData);
}