using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderCheckEligibilityResponse, MessagingHostedNumberOrderCheckEligibilityResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderCheckEligibilityResponse : JsonModel
{
    /// <summary>
    /// List of phone numbers with their eligibility status.
    /// </summary>
    public IReadOnlyList<PhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
    }

    public MessagingHostedNumberOrderCheckEligibilityResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderCheckEligibilityResponse (
        MessagingHostedNumberOrderCheckEligibilityResponse messagingHostedNumberOrderCheckEligibilityResponse
    ) : base(messagingHostedNumberOrderCheckEligibilityResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderCheckEligibilityResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderCheckEligibilityResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderCheckEligibilityResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderCheckEligibilityResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderCheckEligibilityResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderCheckEligibilityResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderCheckEligibilityResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderCheckEligibilityResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// Detailed information about the eligibility status.
    /// </summary>
    public string? Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    /// <summary>
    /// Whether the phone number is eligible for hosted messaging.
    /// </summary>
    public bool? Eligible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "eligible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eligible", value);
        }
    }

    /// <summary>
    /// The eligibility status of the phone number.
    /// </summary>
    public ApiEnum<string, EligibleStatus>? EligibleStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EligibleStatus>>(
                "eligible_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eligible_status", value);
        }
    }

    /// <summary>
    /// The phone number in e164 format.
    /// </summary>
    public string? PhoneNumberValue {
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
        _ = this.Detail;
        _ = this.Eligible;
        this.EligibleStatus?.Validate();
        _ = this.PhoneNumberValue;
    }

    public PhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber (PhoneNumber phoneNumber) : base(phoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}/// <summary>
/// The eligibility status of the phone number.
/// </summary>
[JsonConverter(typeof(EligibleStatusConverter))]
public enum EligibleStatus
{
    NumberCanNotBeRepeated,
    NumberCanNotBeValidated,
    NumberCanNotBeWireless,
    NumberCanNotBeActiveInYourAccount,
    NumberCanNotHostedWithATelnyxSubscriber,
    NumberCanNotBeInTelnyx,
    NumberIsNotAUsNumber,
    NumberIsNotAValidRoutingNumber,
    NumberIsNotInE164Format,
    BillingAccountCheckFailed,
    BillingAccountIsAbolished,
    Eligible
}sealed class EligibleStatusConverter : JsonConverter<EligibleStatus>
{
    public override EligibleStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NUMBER_CAN_NOT_BE_REPEATED"=>EligibleStatus.NumberCanNotBeRepeated,
            "NUMBER_CAN_NOT_BE_VALIDATED"=>EligibleStatus.NumberCanNotBeValidated,
            "NUMBER_CAN_NOT_BE_WIRELESS"=>EligibleStatus.NumberCanNotBeWireless,
            "NUMBER_CAN_NOT_BE_ACTIVE_IN_YOUR_ACCOUNT"=>EligibleStatus.NumberCanNotBeActiveInYourAccount,
            "NUMBER_CAN_NOT_HOSTED_WITH_A_TELNYX_SUBSCRIBER"=>EligibleStatus.NumberCanNotHostedWithATelnyxSubscriber,
            "NUMBER_CAN_NOT_BE_IN_TELNYX"=>EligibleStatus.NumberCanNotBeInTelnyx,
            "NUMBER_IS_NOT_A_US_NUMBER"=>EligibleStatus.NumberIsNotAUsNumber,
            "NUMBER_IS_NOT_A_VALID_ROUTING_NUMBER"=>EligibleStatus.NumberIsNotAValidRoutingNumber,
            "NUMBER_IS_NOT_IN_E164_FORMAT"=>EligibleStatus.NumberIsNotInE164Format,
            "BILLING_ACCOUNT_CHECK_FAILED"=>EligibleStatus.BillingAccountCheckFailed,
            "BILLING_ACCOUNT_IS_ABOLISHED"=>EligibleStatus.BillingAccountIsAbolished,
            "ELIGIBLE"=>EligibleStatus.Eligible,
            _ =>(EligibleStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EligibleStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EligibleStatus.NumberCanNotBeRepeated=>"NUMBER_CAN_NOT_BE_REPEATED",
            EligibleStatus.NumberCanNotBeValidated=>"NUMBER_CAN_NOT_BE_VALIDATED",
            EligibleStatus.NumberCanNotBeWireless=>"NUMBER_CAN_NOT_BE_WIRELESS",
            EligibleStatus.NumberCanNotBeActiveInYourAccount=>"NUMBER_CAN_NOT_BE_ACTIVE_IN_YOUR_ACCOUNT",
            EligibleStatus.NumberCanNotHostedWithATelnyxSubscriber=>"NUMBER_CAN_NOT_HOSTED_WITH_A_TELNYX_SUBSCRIBER",
            EligibleStatus.NumberCanNotBeInTelnyx=>"NUMBER_CAN_NOT_BE_IN_TELNYX",
            EligibleStatus.NumberIsNotAUsNumber=>"NUMBER_IS_NOT_A_US_NUMBER",
            EligibleStatus.NumberIsNotAValidRoutingNumber=>"NUMBER_IS_NOT_A_VALID_ROUTING_NUMBER",
            EligibleStatus.NumberIsNotInE164Format=>"NUMBER_IS_NOT_IN_E164_FORMAT",
            EligibleStatus.BillingAccountCheckFailed=>"BILLING_ACCOUNT_CHECK_FAILED",
            EligibleStatus.BillingAccountIsAbolished=>"BILLING_ACCOUNT_IS_ABOLISHED",
            EligibleStatus.Eligible=>"ELIGIBLE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}