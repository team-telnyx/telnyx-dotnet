using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<PhoneNumbersJobPhoneNumber, PhoneNumbersJobPhoneNumberFromRaw>))]
public sealed record class PhoneNumbersJobPhoneNumber : JsonModel
{
    /// <summary>
    /// The phone number's ID
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
    /// The phone number in e164 format.
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PhoneNumber;
    }

    public PhoneNumbersJobPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumbersJobPhoneNumber (
        PhoneNumbersJobPhoneNumber phoneNumbersJobPhoneNumber
    ) : base(phoneNumbersJobPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumbersJobPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumbersJobPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumbersJobPhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumbersJobPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumbersJobPhoneNumberFromRaw : IFromRawJson<PhoneNumbersJobPhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumbersJobPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumbersJobPhoneNumber.FromRawUnchecked(rawData);
}