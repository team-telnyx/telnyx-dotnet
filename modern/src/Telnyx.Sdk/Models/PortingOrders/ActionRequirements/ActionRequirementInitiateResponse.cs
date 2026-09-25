using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.ActionRequirements;

[JsonConverter(typeof(JsonModelConverter<ActionRequirementInitiateResponse, ActionRequirementInitiateResponseFromRaw>))]
public sealed record class ActionRequirementInitiateResponse : JsonModel
{
    public PortingActionRequirement? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingActionRequirement>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ActionRequirementInitiateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRequirementInitiateResponse (
        ActionRequirementInitiateResponse actionRequirementInitiateResponse
    ) : base(actionRequirementInitiateResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRequirementInitiateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRequirementInitiateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRequirementInitiateResponseFromRaw.FromRawUnchecked"/>
    public static ActionRequirementInitiateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRequirementInitiateResponseFromRaw : IFromRawJson<ActionRequirementInitiateResponse>
{
    /// <inheritdoc/>
    public ActionRequirementInitiateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRequirementInitiateResponse.FromRawUnchecked(rawData);
}