using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<NumberOrderPhoneNumberUpdateRequirementGroupResponse, NumberOrderPhoneNumberUpdateRequirementGroupResponseFromRaw>))]
public sealed record class NumberOrderPhoneNumberUpdateRequirementGroupResponse : JsonModel
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

    public NumberOrderPhoneNumberUpdateRequirementGroupResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderPhoneNumberUpdateRequirementGroupResponse (
        NumberOrderPhoneNumberUpdateRequirementGroupResponse numberOrderPhoneNumberUpdateRequirementGroupResponse
    ) : base(numberOrderPhoneNumberUpdateRequirementGroupResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderPhoneNumberUpdateRequirementGroupResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderPhoneNumberUpdateRequirementGroupResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderPhoneNumberUpdateRequirementGroupResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderPhoneNumberUpdateRequirementGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderPhoneNumberUpdateRequirementGroupResponseFromRaw : IFromRawJson<NumberOrderPhoneNumberUpdateRequirementGroupResponse>
{
    /// <inheritdoc/>
    public NumberOrderPhoneNumberUpdateRequirementGroupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderPhoneNumberUpdateRequirementGroupResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public string? BundleID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bundle_id"
            );
        }
        init { this._rawData.Set("bundle_id", value); }
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

    public DateTimeOffset? Deadline {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "deadline"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deadline", value);
        }
    }

    public bool? IsBlockNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_block_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_block_number", value);
        }
    }

    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    public string? OrderRequestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_request_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_request_id", value);
        }
    }

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

    public bool? RequirementsMet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "requirements_met"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_met", value);
        }
    }

    public string? RequirementsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirements_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_status", value);
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? SubNumberOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sub_number_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_number_order_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BundleID;
        _ = this.CountryCode;
        _ = this.Deadline;
        _ = this.IsBlockNumber;
        _ = this.Locality;
        _ = this.OrderRequestID;
        _ = this.PhoneNumber;
        _ = this.PhoneNumberType;
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        _ = this.RequirementsStatus;
        _ = this.Status;
        _ = this.SubNumberOrderID;
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

    public string? RequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_id", value);
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldType;
        _ = this.FieldValue;
        _ = this.RequirementID;
        _ = this.Status;
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
}