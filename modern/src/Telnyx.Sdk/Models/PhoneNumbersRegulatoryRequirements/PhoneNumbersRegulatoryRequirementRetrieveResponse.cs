using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PhoneNumbersRegulatoryRequirements;

[JsonConverter(typeof(JsonModelConverter<PhoneNumbersRegulatoryRequirementRetrieveResponse, PhoneNumbersRegulatoryRequirementRetrieveResponseFromRaw>))]
public sealed record class PhoneNumbersRegulatoryRequirementRetrieveResponse : JsonModel
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

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public PhoneNumbersRegulatoryRequirementRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumbersRegulatoryRequirementRetrieveResponse (
        PhoneNumbersRegulatoryRequirementRetrieveResponse phoneNumbersRegulatoryRequirementRetrieveResponse
    ) : base(phoneNumbersRegulatoryRequirementRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumbersRegulatoryRequirementRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumbersRegulatoryRequirementRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumbersRegulatoryRequirementRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumbersRegulatoryRequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumbersRegulatoryRequirementRetrieveResponseFromRaw : IFromRawJson<PhoneNumbersRegulatoryRequirementRetrieveResponse>
{
    /// <inheritdoc/>
    public PhoneNumbersRegulatoryRequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumbersRegulatoryRequirementRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
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

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public IReadOnlyList<RegionInformation>? RegionInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RegionInformation>>(
                "region_information"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RegionInformation>?>(
                "region_information",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.PhoneNumber;
        _ = this.PhoneNumberType;
        _ = this.RecordType;
        foreach (var item in this.RegionInformation ?? [])
        {
            item.Validate();
        }
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
}[JsonConverter(typeof(JsonModelConverter<RegionInformation, RegionInformationFromRaw>))]
public sealed record class RegionInformation : JsonModel
{
    public string? RegionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_name", value);
        }
    }

    public string? RegionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RegionName;
        _ = this.RegionType;
    }

    public RegionInformation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegionInformation (RegionInformation regionInformation) : base(
        regionInformation
    )
    {  }
    #pragma warning restore CS8618

    public RegionInformation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegionInformation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegionInformationFromRaw.FromRawUnchecked"/>
    public static RegionInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegionInformationFromRaw : IFromRawJson<RegionInformation>
{
    /// <inheritdoc/>
    public RegionInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegionInformation.FromRawUnchecked(rawData);
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

    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
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
        _ = this.Label;
        _ = this.RecordType;
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

    public string? FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_value", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldType;
        _ = this.FieldValue;
        _ = this.LocalityLimit;
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