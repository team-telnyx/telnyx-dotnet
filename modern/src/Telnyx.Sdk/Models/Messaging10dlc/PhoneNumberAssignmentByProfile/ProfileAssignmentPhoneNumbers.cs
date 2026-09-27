using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(JsonModelConverter<ProfileAssignmentPhoneNumbers, ProfileAssignmentPhoneNumbersFromRaw>))]
public sealed record class ProfileAssignmentPhoneNumbers : JsonModel
{
    /// <summary>
    /// The phone number that the status is being checked for.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phoneNumber"
            );
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <summary>
    /// The status of the associated phone number assignment.
    /// </summary>
    public required string Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ID of the task associated with the phone number.
    /// </summary>
    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "taskId"
            );
        }
        init { this._rawData.Set("taskId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.Status;
        _ = this.TaskID;
    }

    public ProfileAssignmentPhoneNumbers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileAssignmentPhoneNumbers (
        ProfileAssignmentPhoneNumbers profileAssignmentPhoneNumbers
    ) : base(profileAssignmentPhoneNumbers)
    {  }
    #pragma warning restore CS8618

    public ProfileAssignmentPhoneNumbers (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileAssignmentPhoneNumbers (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileAssignmentPhoneNumbersFromRaw.FromRawUnchecked"/>
    public static ProfileAssignmentPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProfileAssignmentPhoneNumbersFromRaw : IFromRawJson<ProfileAssignmentPhoneNumbers>
{
    /// <inheritdoc/>
    public ProfileAssignmentPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileAssignmentPhoneNumbers.FromRawUnchecked(rawData);
}