using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<PortingOrdersExceptionType, PortingOrdersExceptionTypeFromRaw>))]
public sealed record class PortingOrdersExceptionType : JsonModel
{
    /// <summary>
    /// Identifier of an exception type
    /// </summary>
    public ApiEnum<string, Code>? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Code>>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Description of an exception type
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code?.Validate();
        _ = this.Description;
    }

    public PortingOrdersExceptionType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrdersExceptionType (
        PortingOrdersExceptionType portingOrdersExceptionType
    ) : base(portingOrdersExceptionType)
    {  }
    #pragma warning restore CS8618

    public PortingOrdersExceptionType (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrdersExceptionType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrdersExceptionTypeFromRaw.FromRawUnchecked"/>
    public static PortingOrdersExceptionType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrdersExceptionTypeFromRaw : IFromRawJson<PortingOrdersExceptionType>
{
    /// <inheritdoc/>
    public PortingOrdersExceptionType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrdersExceptionType.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifier of an exception type
/// </summary>
[JsonConverter(typeof(CodeConverter))]
public enum Code
{
    AccountNumberMismatch,
    AuthPersonMismatch,
    BtnAtnMismatch,
    EntityNameMismatch,
    FocExpired,
    FocRejected,
    LocationMismatch,
    LsrPending,
    MainBtnPorting,
    OspIrresponsive,
    Other,
    PasscodePinInvalid,
    PhoneNumberHasSpecialFeature,
    PhoneNumberMismatch,
    PhoneNumberNotPortable,
    PortTypeIncorrect,
    PortingOrderSplitRequired,
    PostalCodeMismatch,
    RateCenterNotPortable,
    SvConflict,
    SvUnknownFailure
}sealed class CodeConverter : JsonConverter<Code>
{
    public override Code Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACCOUNT_NUMBER_MISMATCH"=>Code.AccountNumberMismatch,
            "AUTH_PERSON_MISMATCH"=>Code.AuthPersonMismatch,
            "BTN_ATN_MISMATCH"=>Code.BtnAtnMismatch,
            "ENTITY_NAME_MISMATCH"=>Code.EntityNameMismatch,
            "FOC_EXPIRED"=>Code.FocExpired,
            "FOC_REJECTED"=>Code.FocRejected,
            "LOCATION_MISMATCH"=>Code.LocationMismatch,
            "LSR_PENDING"=>Code.LsrPending,
            "MAIN_BTN_PORTING"=>Code.MainBtnPorting,
            "OSP_IRRESPONSIVE"=>Code.OspIrresponsive,
            "OTHER"=>Code.Other,
            "PASSCODE_PIN_INVALID"=>Code.PasscodePinInvalid,
            "PHONE_NUMBER_HAS_SPECIAL_FEATURE"=>Code.PhoneNumberHasSpecialFeature,
            "PHONE_NUMBER_MISMATCH"=>Code.PhoneNumberMismatch,
            "PHONE_NUMBER_NOT_PORTABLE"=>Code.PhoneNumberNotPortable,
            "PORT_TYPE_INCORRECT"=>Code.PortTypeIncorrect,
            "PORTING_ORDER_SPLIT_REQUIRED"=>Code.PortingOrderSplitRequired,
            "POSTAL_CODE_MISMATCH"=>Code.PostalCodeMismatch,
            "RATE_CENTER_NOT_PORTABLE"=>Code.RateCenterNotPortable,
            "SV_CONFLICT"=>Code.SvConflict,
            "SV_UNKNOWN_FAILURE"=>Code.SvUnknownFailure,
            _ =>(Code)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Code value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Code.AccountNumberMismatch=>"ACCOUNT_NUMBER_MISMATCH",
            Code.AuthPersonMismatch=>"AUTH_PERSON_MISMATCH",
            Code.BtnAtnMismatch=>"BTN_ATN_MISMATCH",
            Code.EntityNameMismatch=>"ENTITY_NAME_MISMATCH",
            Code.FocExpired=>"FOC_EXPIRED",
            Code.FocRejected=>"FOC_REJECTED",
            Code.LocationMismatch=>"LOCATION_MISMATCH",
            Code.LsrPending=>"LSR_PENDING",
            Code.MainBtnPorting=>"MAIN_BTN_PORTING",
            Code.OspIrresponsive=>"OSP_IRRESPONSIVE",
            Code.Other=>"OTHER",
            Code.PasscodePinInvalid=>"PASSCODE_PIN_INVALID",
            Code.PhoneNumberHasSpecialFeature=>"PHONE_NUMBER_HAS_SPECIAL_FEATURE",
            Code.PhoneNumberMismatch=>"PHONE_NUMBER_MISMATCH",
            Code.PhoneNumberNotPortable=>"PHONE_NUMBER_NOT_PORTABLE",
            Code.PortTypeIncorrect=>"PORT_TYPE_INCORRECT",
            Code.PortingOrderSplitRequired=>"PORTING_ORDER_SPLIT_REQUIRED",
            Code.PostalCodeMismatch=>"POSTAL_CODE_MISMATCH",
            Code.RateCenterNotPortable=>"RATE_CENTER_NOT_PORTABLE",
            Code.SvConflict=>"SV_CONFLICT",
            Code.SvUnknownFailure=>"SV_UNKNOWN_FAILURE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}