using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse, PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponseFromRaw>))]
public sealed record class PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse : JsonModel
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

    public PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse (
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse phoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse
    ) : base(phoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse (
        IReadOnlyList<ProfileAssignmentPhoneNumbers> records
    ) : this()
    { this.Records = records; }
}

class PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponseFromRaw : IFromRawJson<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse.FromRawUnchecked(rawData);
}