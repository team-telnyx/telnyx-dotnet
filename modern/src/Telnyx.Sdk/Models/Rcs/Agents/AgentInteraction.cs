using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentInteraction, AgentInteractionFromRaw>))]
public sealed record class AgentInteraction : JsonModel
{
    public required ApiEnum<string, InteractionType> InteractionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InteractionType>>(
                "interaction_type"
            );
        }
        init { this._rawData.Set("interaction_type", value); }
    }

    /// <summary>
    /// Required when interaction_type is `OTHER`.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InteractionType.Validate();
        _ = this.Description;
    }

    public AgentInteraction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentInteraction (AgentInteraction agentInteraction) : base(
        agentInteraction
    )
    {  }
    #pragma warning restore CS8618

    public AgentInteraction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentInteraction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentInteractionFromRaw.FromRawUnchecked"/>
    public static AgentInteraction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentInteraction (
        ApiEnum<string, InteractionType> interactionType
    ) : this()
    { this.InteractionType = interactionType; }
}

class AgentInteractionFromRaw : IFromRawJson<AgentInteraction>
{
    /// <inheritdoc/>
    public AgentInteraction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentInteraction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InteractionTypeConverter))]
public enum InteractionType
{
    TransactionalUpdates,
    CustomerSupport,
    LoyaltyOrReward,
    MarketingOrPromotional,
    AccountAlerts,
    TwoWayConversation,
    Other
}sealed class InteractionTypeConverter : JsonConverter<InteractionType>
{
    public override InteractionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TRANSACTIONAL_UPDATES"=>InteractionType.TransactionalUpdates,
            "CUSTOMER_SUPPORT"=>InteractionType.CustomerSupport,
            "LOYALTY_OR_REWARD"=>InteractionType.LoyaltyOrReward,
            "MARKETING_OR_PROMOTIONAL"=>InteractionType.MarketingOrPromotional,
            "ACCOUNT_ALERTS"=>InteractionType.AccountAlerts,
            "TWO_WAY_CONVERSATION"=>InteractionType.TwoWayConversation,
            "OTHER"=>InteractionType.Other,
            _ =>(InteractionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InteractionType.TransactionalUpdates=>"TRANSACTIONAL_UPDATES",
            InteractionType.CustomerSupport=>"CUSTOMER_SUPPORT",
            InteractionType.LoyaltyOrReward=>"LOYALTY_OR_REWARD",
            InteractionType.MarketingOrPromotional=>"MARKETING_OR_PROMOTIONAL",
            InteractionType.AccountAlerts=>"ACCOUNT_ALERTS",
            InteractionType.TwoWayConversation=>"TWO_WAY_CONVERSATION",
            InteractionType.Other=>"OTHER",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}