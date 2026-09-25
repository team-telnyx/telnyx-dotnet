using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse, PhoneNumberAssignmentByProfileListPhoneNumberStatusResponseFromRaw>))]
public sealed record class PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse : JsonModel
{
    public required IReadOnlyList<ProfileAssignmentPhoneNumbers> Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProfileAssignmentPhoneNumbers>>(
                "records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ProfileAssignmentPhoneNumbers>>(
                "records",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Records)
        {
            item.Validate();
        }
    }

    public PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse (
        PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse phoneNumberAssignmentByProfileListPhoneNumberStatusResponse
    ) : base(phoneNumberAssignmentByProfileListPhoneNumberStatusResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAssignmentByProfileListPhoneNumberStatusResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse (
        IReadOnlyList<ProfileAssignmentPhoneNumbers> records
    ) : this()
    { this.Records = records; }
}

class PhoneNumberAssignmentByProfileListPhoneNumberStatusResponseFromRaw : IFromRawJson<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse.FromRawUnchecked(rawData);
}