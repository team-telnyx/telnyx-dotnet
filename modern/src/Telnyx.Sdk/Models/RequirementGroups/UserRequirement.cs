using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RequirementGroups;

[JsonConverter(typeof(JsonModelConverter<UserRequirement, UserRequirementFromRaw>))]
public sealed record class UserRequirement : JsonModel
{
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

    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
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

    public ApiEnum<string, UserRequirementStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserRequirementStatus>>(
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
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.FieldType;
        _ = this.FieldValue;
        _ = this.RequirementID;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public UserRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRequirement (UserRequirement userRequirement) : base(
        userRequirement
    )
    {  }
    #pragma warning restore CS8618

    public UserRequirement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserRequirementFromRaw.FromRawUnchecked"/>
    public static UserRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserRequirementFromRaw : IFromRawJson<UserRequirement>
{
    /// <inheritdoc/>
    public UserRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserRequirement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UserRequirementStatusConverter))]
public enum UserRequirementStatus
{
    Approved, Unapproved, PendingApproval, Declined, Expired
}sealed class UserRequirementStatusConverter : JsonConverter<UserRequirementStatus>
{
    public override UserRequirementStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved"=>UserRequirementStatus.Approved,
            "unapproved"=>UserRequirementStatus.Unapproved,
            "pending-approval"=>UserRequirementStatus.PendingApproval,
            "declined"=>UserRequirementStatus.Declined,
            "expired"=>UserRequirementStatus.Expired,
            _ =>(UserRequirementStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRequirementStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UserRequirementStatus.Approved=>"approved",
            UserRequirementStatus.Unapproved=>"unapproved",
            UserRequirementStatus.PendingApproval=>"pending-approval",
            UserRequirementStatus.Declined=>"declined",
            UserRequirementStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}