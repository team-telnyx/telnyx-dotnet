using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

/// <summary>
/// Adds the campaign and testing configuration, then starts asynchronous carrier
/// launch. Agent basics must already be submitted. Repeating a launch that is already
/// in progress returns the current agent without creating new work.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentLaunchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required Campaign Campaign {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Campaign>(
                "campaign"
            );
        }
        init { this._rawBodyData.Set("campaign", value); }
    }

    public required AgentTestingConfiguration Testing {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<AgentTestingConfiguration>(
                "testing"
            );
        }
        init { this._rawBodyData.Set("testing", value); }
    }

    public AgentLaunchParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentLaunchParams (AgentLaunchParams agentLaunchParams) : base(
        agentLaunchParams
    )
    {
        this.ID = agentLaunchParams.ID;

        this._rawBodyData = new(agentLaunchParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AgentLaunchParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentLaunchParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentLaunchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AgentLaunchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/rcs/agents/{0}/launch",
            EncodePathSegment(this.ID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<Campaign, CampaignFromRaw>))]
public sealed record class Campaign : JsonModel
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
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("consent_settings", value);
        }
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

    public static implicit operator AgentCampaignConfiguration (
        Campaign campaign
    )=> new() {
        CompanyOverview = campaign.CompanyOverview,
        AdditionalInformation = campaign.AdditionalInformation,
        AgentOverview = campaign.AgentOverview,
        ConsentSettings = campaign.ConsentSettings,
        Interactions = campaign.Interactions,
        MessageExamples = campaign.MessageExamples
    } ;

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

    public Campaign ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Campaign (Campaign campaign) : base(campaign)
    {  }
    #pragma warning restore CS8618

    public Campaign (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Campaign (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignFromRaw.FromRawUnchecked"/>
    public static Campaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignFromRaw : IFromRawJson<Campaign>
{
    /// <inheritdoc/>
    public Campaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Campaign.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public required string AgentOverview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "agent_overview"
            );
        }
        init { this._rawData.Set("agent_overview", value); }
    }

    public required AgentConsentConfiguration ConsentSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConsentConfiguration>(
                "consent_settings"
            );
        }
        init { this._rawData.Set("consent_settings", value); }
    }

    public required IReadOnlyList<AgentInteraction> Interactions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentInteraction>>(
                "interactions"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AgentInteraction>>(
                "interactions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<string> MessageExamples {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "message_examples"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "message_examples",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentOverview;
        this.ConsentSettings.Validate();
        foreach (var item in this.Interactions)
        {
            item.Validate();
        }
        _ = this.MessageExamples;
    }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}