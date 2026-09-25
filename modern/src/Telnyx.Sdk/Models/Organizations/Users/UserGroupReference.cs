using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Organizations.Users;

/// <summary>
/// A reference to a group that a user belongs to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserGroupReference, UserGroupReferenceFromRaw>))]
public sealed record class UserGroupReference : JsonModel
{
    /// <summary>
    /// The unique identifier of the group.
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
    /// The name of the group.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public UserGroupReference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserGroupReference (UserGroupReference userGroupReference) : base(
        userGroupReference
    )
    {  }
    #pragma warning restore CS8618

    public UserGroupReference (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserGroupReference (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserGroupReferenceFromRaw.FromRawUnchecked"/>
    public static UserGroupReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserGroupReferenceFromRaw : IFromRawJson<UserGroupReference>
{
    /// <inheritdoc/>
    public UserGroupReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserGroupReference.FromRawUnchecked(rawData);
}