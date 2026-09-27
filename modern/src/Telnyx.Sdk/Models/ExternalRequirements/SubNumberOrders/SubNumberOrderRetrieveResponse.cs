using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderRetrieveResponse, SubNumberOrderRetrieveResponseFromRaw>))]
public sealed record class SubNumberOrderRetrieveResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public SubNumberOrderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderRetrieveResponse (
        SubNumberOrderRetrieveResponse subNumberOrderRetrieveResponse
    ) : base(subNumberOrderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderRetrieveResponseFromRaw : IFromRawJson<SubNumberOrderRetrieveResponse>
{
    /// <inheritdoc/>
    public SubNumberOrderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The fields the end user must provide to fulfill this requirement.
    /// </summary>
    public IReadOnlyList<FieldsRequired>? FieldsRequired {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FieldsRequired>>(
                "fields_required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FieldsRequired>?>(
                "fields_required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public RequirementAction? RequirementAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RequirementAction>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.FieldsRequired ?? [])
        {
            item.Validate();
        }
        _ = this.RegulatoryRequirementID;
        this.RequirementAction?.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<FieldsRequired, FieldsRequiredFromRaw>))]
public sealed record class FieldsRequired : JsonModel
{
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The field name to send inside the `requirement` object on the POST.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

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
    /// The value already stored for this field, or null if not yet provided.
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
        _ = this.Description;
        _ = this.Name;
        _ = this.Type;
        _ = this.Value;
    }

    public FieldsRequired ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FieldsRequired (FieldsRequired fieldsRequired) : base(fieldsRequired)
    {  }
    #pragma warning restore CS8618

    public FieldsRequired (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FieldsRequired (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FieldsRequiredFromRaw.FromRawUnchecked"/>
    public static FieldsRequired FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FieldsRequiredFromRaw : IFromRawJson<FieldsRequired>
{
    /// <inheritdoc/>
    public FieldsRequired FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FieldsRequired.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<RequirementAction, RequirementActionFromRaw>))]
public sealed record class RequirementAction : JsonModel
{
    /// <summary>
    /// The type of action the end user must complete.
    /// </summary>
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
    /// The action value. For ID verification this is the verification link URL,
    /// or null until it has been generated.
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

    public RequirementAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementAction (RequirementAction requirementAction) : base(
        requirementAction
    )
    {  }
    #pragma warning restore CS8618

    public RequirementAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementActionFromRaw.FromRawUnchecked"/>
    public static RequirementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RequirementActionFromRaw : IFromRawJson<RequirementAction>
{
    /// <inheritdoc/>
    public RequirementAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementAction.FromRawUnchecked(rawData);
}