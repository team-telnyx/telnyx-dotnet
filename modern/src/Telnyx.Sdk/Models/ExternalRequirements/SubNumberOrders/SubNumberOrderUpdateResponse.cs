using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderUpdateResponse, SubNumberOrderUpdateResponseFromRaw>))]
public sealed record class SubNumberOrderUpdateResponse : JsonModel
{
    public SubNumberOrderUpdateResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubNumberOrderUpdateResponseData>(
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

    public SubNumberOrderUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderUpdateResponse (
        SubNumberOrderUpdateResponse subNumberOrderUpdateResponse
    ) : base(subNumberOrderUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderUpdateResponseFromRaw : IFromRawJson<SubNumberOrderUpdateResponse>
{
    /// <inheritdoc/>
    public SubNumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderUpdateResponseData, SubNumberOrderUpdateResponseDataFromRaw>))]
public sealed record class SubNumberOrderUpdateResponseData : JsonModel
{
    public string? RegulatoryRequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "regulatory_requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("regulatory_requirement_id", value);
        }
    }

    public SubNumberOrderUpdateResponseDataRequirementAction? RequirementAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubNumberOrderUpdateResponseDataRequirementAction>(
                "requirement_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_action", value);
        }
    }

    public string? SubOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sub_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_order_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RegulatoryRequirementID;
        this.RequirementAction?.Validate();
        _ = this.SubOrderID;
    }

    public SubNumberOrderUpdateResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderUpdateResponseData (
        SubNumberOrderUpdateResponseData subNumberOrderUpdateResponseData
    ) : base(subNumberOrderUpdateResponseData)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderUpdateResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderUpdateResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SubNumberOrderUpdateResponseDataFromRaw : IFromRawJson<SubNumberOrderUpdateResponseData>
{
    /// <inheritdoc/>
    public SubNumberOrderUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderUpdateResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SubNumberOrderUpdateResponseDataRequirementAction, SubNumberOrderUpdateResponseDataRequirementActionFromRaw>))]
public sealed record class SubNumberOrderUpdateResponseDataRequirementAction : JsonModel
{
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// For Australia mobile ID verification, the unique Onfido verification link
    /// to share with the end user.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Value;
    }

    public SubNumberOrderUpdateResponseDataRequirementAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderUpdateResponseDataRequirementAction (
        SubNumberOrderUpdateResponseDataRequirementAction subNumberOrderUpdateResponseDataRequirementAction
    ) : base(subNumberOrderUpdateResponseDataRequirementAction)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderUpdateResponseDataRequirementAction (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderUpdateResponseDataRequirementAction (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderUpdateResponseDataRequirementActionFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderUpdateResponseDataRequirementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SubNumberOrderUpdateResponseDataRequirementActionFromRaw : IFromRawJson<SubNumberOrderUpdateResponseDataRequirementAction>
{
    /// <inheritdoc/>
    public SubNumberOrderUpdateResponseDataRequirementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderUpdateResponseDataRequirementAction.FromRawUnchecked(rawData);
}