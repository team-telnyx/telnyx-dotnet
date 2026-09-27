using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RequirementGroups;

[JsonConverter(typeof(JsonModelConverter<RequirementGroup, RequirementGroupFromRaw>))]
public sealed record class RequirementGroup : JsonModel
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

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
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

    public IReadOnlyList<UserRequirement>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UserRequirement>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<UserRequirement>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, RequirementGroupStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequirementGroupStatus>>(
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

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Action;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.PhoneNumberType;
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public RequirementGroup ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementGroup (RequirementGroup requirementGroup) : base(
        requirementGroup
    )
    {  }
    #pragma warning restore CS8618

    public RequirementGroup (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementGroup (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementGroupFromRaw.FromRawUnchecked"/>
    public static RequirementGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementGroupFromRaw : IFromRawJson<RequirementGroup>
{
    /// <inheritdoc/>
    public RequirementGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementGroup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RequirementGroupStatusConverter))]
public enum RequirementGroupStatus
{
    Approved, Unapproved, PendingApproval, Declined, Expired
}sealed class RequirementGroupStatusConverter : JsonConverter<RequirementGroupStatus>
{
    public override RequirementGroupStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved"=>RequirementGroupStatus.Approved,
            "unapproved"=>RequirementGroupStatus.Unapproved,
            "pending-approval"=>RequirementGroupStatus.PendingApproval,
            "declined"=>RequirementGroupStatus.Declined,
            "expired"=>RequirementGroupStatus.Expired,
            _ =>(RequirementGroupStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequirementGroupStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RequirementGroupStatus.Approved=>"approved",
            RequirementGroupStatus.Unapproved=>"unapproved",
            RequirementGroupStatus.PendingApproval=>"pending-approval",
            RequirementGroupStatus.Declined=>"declined",
            RequirementGroupStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}