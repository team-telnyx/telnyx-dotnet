using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RegulatoryRequirements;

[JsonConverter(typeof(JsonModelConverter<RegulatoryRequirementRetrieveResponse, RegulatoryRequirementRetrieveResponseFromRaw>))]
public sealed record class RegulatoryRequirementRetrieveResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public RegulatoryRequirementRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryRequirementRetrieveResponse (
        RegulatoryRequirementRetrieveResponse regulatoryRequirementRetrieveResponse
    ) : base(regulatoryRequirementRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RegulatoryRequirementRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryRequirementRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryRequirementRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RegulatoryRequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RegulatoryRequirementRetrieveResponseFromRaw : IFromRawJson<RegulatoryRequirementRetrieveResponse>
{
    /// <inheritdoc/>
    public RegulatoryRequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegulatoryRequirementRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public string? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
        }
    }

    public IReadOnlyList<RegulatoryRequirement>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RegulatoryRequirement>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RegulatoryRequirement>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        _ = this.CountryCode;
        _ = this.PhoneNumberType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
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
}[JsonConverter(typeof(JsonModelConverter<RegulatoryRequirement, RegulatoryRequirementFromRaw>))]
public sealed record class RegulatoryRequirement : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public AcceptanceCriteria? AcceptanceCriteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AcceptanceCriteria>(
                "acceptance_criteria"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("acceptance_criteria", value);
        }
    }

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

    public string? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "example"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("example", value);
        }
    }

    public string? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_type", value);
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AcceptanceCriteria?.Validate();
        _ = this.Description;
        _ = this.Example;
        _ = this.FieldType;
        _ = this.Name;
    }

    public RegulatoryRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryRequirement (
        RegulatoryRequirement regulatoryRequirement
    ) : base(regulatoryRequirement)
    {  }
    #pragma warning restore CS8618

    public RegulatoryRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegulatoryRequirementFromRaw : IFromRawJson<RegulatoryRequirement>
{
    /// <inheritdoc/>
    public RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegulatoryRequirement.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<AcceptanceCriteria, AcceptanceCriteriaFromRaw>))]
public sealed record class AcceptanceCriteria : JsonModel
{
    public string? AcceptableCharacters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "acceptable_characters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("acceptable_characters", value);
        }
    }

    public IReadOnlyList<string>? AcceptableValues {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "acceptable_values"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "acceptable_values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? CaseSensitive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "case_sensitive"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("case_sensitive", value);
        }
    }

    public string? LocalityLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality_limit", value);
        }
    }

    public string? MaxLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "max_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_length", value);
        }
    }

    public string? MinLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "min_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("min_length", value);
        }
    }

    public string? Regex {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "regex"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("regex", value);
        }
    }

    public string? TimeLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "time_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("time_limit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptableCharacters;
        _ = this.AcceptableValues;
        _ = this.CaseSensitive;
        _ = this.LocalityLimit;
        _ = this.MaxLength;
        _ = this.MinLength;
        _ = this.Regex;
        _ = this.TimeLimit;
    }

    public AcceptanceCriteria ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AcceptanceCriteria (AcceptanceCriteria acceptanceCriteria) : base(
        acceptanceCriteria
    )
    {  }
    #pragma warning restore CS8618

    public AcceptanceCriteria (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AcceptanceCriteria (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AcceptanceCriteriaFromRaw.FromRawUnchecked"/>
    public static AcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AcceptanceCriteriaFromRaw : IFromRawJson<AcceptanceCriteria>
{
    /// <inheritdoc/>
    public AcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AcceptanceCriteria.FromRawUnchecked(rawData);
}