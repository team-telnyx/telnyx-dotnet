using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Organizations.Users;

[JsonConverter(typeof(JsonModelConverter<OrganizationUser, OrganizationUserFromRaw>))]
public sealed record class OrganizationUser : JsonModel
{
    /// <summary>
    /// Identifies the specific resource.
    /// </summary>
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The groups the user belongs to. Only included when include_groups parameter
    /// is true.
    /// </summary>
    public IReadOnlyList<UserGroupReference>? Groups {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UserGroupReference>>(
                "groups"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<UserGroupReference>?>(
                "groups",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource last signed into the
    /// portal. Null if the user has never signed in.
    /// </summary>
    public string? LastSignInAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_sign_in_at"
            );
        }
        init { this._rawData.Set("last_sign_in_at", value); }
    }

    /// <summary>
    /// Indicates whether this user is allowed to bypass SSO and use password authentication.
    /// </summary>
    public bool? OrganizationUserBypassesSso {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "organization_user_bypasses_sso"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_user_bypasses_sso", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource. Can be 'organization_owner' or 'organization_sub_user'.
    /// </summary>
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

    /// <summary>
    /// The status of the account.
    /// </summary>
    public ApiEnum<string, UserStatus>? UserStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserStatus>>(
                "user_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Email;
        foreach (var item in this.Groups ?? [])
        {
            item.Validate();
        }
        _ = this.LastSignInAt;
        _ = this.OrganizationUserBypassesSso;
        _ = this.RecordType;
        this.UserStatus?.Validate();
    }

    public OrganizationUser ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationUser (OrganizationUser organizationUser) : base(
        organizationUser
    )
    {  }
    #pragma warning restore CS8618

    public OrganizationUser (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationUser (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationUserFromRaw.FromRawUnchecked"/>
    public static OrganizationUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OrganizationUserFromRaw : IFromRawJson<OrganizationUser>
{
    /// <inheritdoc/>
    public OrganizationUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OrganizationUser.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the account.
/// </summary>
[JsonConverter(typeof(UserStatusConverter))]
public enum UserStatus
{
    Enabled, Disabled, Blocked
}sealed class UserStatusConverter : JsonConverter<UserStatus>
{
    public override UserStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>UserStatus.Enabled,
            "disabled"=>UserStatus.Disabled,
            "blocked"=>UserStatus.Blocked,
            _ =>(UserStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, UserStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UserStatus.Enabled=>"enabled",
            UserStatus.Disabled=>"disabled",
            UserStatus.Blocked=>"blocked",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}