using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentCampaignConfiguration, AgentCampaignConfigurationFromRaw>))]
public sealed record class AgentCampaignConfiguration : JsonModel
{
    public required string CompanyOverview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "company_overview"
            );
        }
        init { this._rawData.Set("company_overview", value); }
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

    public string? AgentOverview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_overview"
            );
        }
        init { this._rawData.Set("agent_overview", value); }
    }

    public AgentConsentConfiguration? ConsentSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentConsentConfiguration>(
                "consent_settings"
            );
        }
        init { this._rawData.Set("consent_settings", value); }
    }

    public IReadOnlyList<AgentInteraction>? Interactions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AgentInteraction>>(
                "interactions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentInteraction>?>(
                "interactions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? MessageExamples {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "message_examples"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "message_examples",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompanyOverview;
        _ = this.AdditionalInformation;
        _ = this.AgentOverview;
        this.ConsentSettings?.Validate();
        foreach (var item in this.Interactions ?? [])
        {
            item.Validate();
        }
        _ = this.MessageExamples;
    }

    public AgentCampaignConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentCampaignConfiguration (
        AgentCampaignConfiguration agentCampaignConfiguration
    ) : base(agentCampaignConfiguration)
    {  }
    #pragma warning restore CS8618

    public AgentCampaignConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCampaignConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentCampaignConfigurationFromRaw.FromRawUnchecked"/>
    public static AgentCampaignConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentCampaignConfiguration (string companyOverview) : this()
    { this.CompanyOverview = companyOverview; }
}

class AgentCampaignConfigurationFromRaw : IFromRawJson<AgentCampaignConfiguration>
{
    /// <inheritdoc/>
    public AgentCampaignConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentCampaignConfiguration.FromRawUnchecked(rawData);
}