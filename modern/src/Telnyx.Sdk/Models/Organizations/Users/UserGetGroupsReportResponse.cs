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

[JsonConverter(typeof(JsonModelConverter<UserGetGroupsReportResponse, UserGetGroupsReportResponseFromRaw>))]
public sealed record class UserGetGroupsReportResponse : JsonModel
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

    public UserGetGroupsReportResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserGetGroupsReportResponse (
        UserGetGroupsReportResponse userGetGroupsReportResponse
    ) : base(userGetGroupsReportResponse)
    {  }
    #pragma warning restore CS8618

    public UserGetGroupsReportResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserGetGroupsReportResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserGetGroupsReportResponseFromRaw.FromRawUnchecked"/>
    public static UserGetGroupsReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserGetGroupsReportResponseFromRaw : IFromRawJson<UserGetGroupsReportResponse>
{
    /// <inheritdoc/>
    public UserGetGroupsReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserGetGroupsReportResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An organization user with their group memberships always included.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Identifies the specific resource.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The groups the user belongs to.
    /// </summary>
    public required IReadOnlyList<UserGroupReference> Groups {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserGroupReference>>(
                "groups"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UserGroupReference>>(
                "groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the type of the resource. Can be 'organization_owner' or 'organization_sub_user'.
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// The status of the account.
    /// </summary>
    public required ApiEnum<string, DataUserStatus> UserStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataUserStatus>>(
                "user_status"
            );
        }
        init { this._rawData.Set("user_status", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Email;
        foreach (var item in this.Groups)
        {
            item.Validate();
        }
        _ = this.RecordType;
        this.UserStatus.Validate();
        _ = this.LastSignInAt;
        _ = this.OrganizationUserBypassesSso;
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
}/// <summary>
/// The status of the account.
/// </summary>
[JsonConverter(typeof(DataUserStatusConverter))]
public enum DataUserStatus
{
    Enabled, Disabled, Blocked
}sealed class DataUserStatusConverter : JsonConverter<DataUserStatus>
{
    public override DataUserStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>DataUserStatus.Enabled,
            "disabled"=>DataUserStatus.Disabled,
            "blocked"=>DataUserStatus.Blocked,
            _ =>(DataUserStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataUserStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataUserStatus.Enabled=>"enabled",
            DataUserStatus.Disabled=>"disabled",
            DataUserStatus.Blocked=>"blocked",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}