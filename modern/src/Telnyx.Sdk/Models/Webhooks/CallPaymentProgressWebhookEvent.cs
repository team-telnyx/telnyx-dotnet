using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPaymentProgressWebhookEvent, CallPaymentProgressWebhookEventFromRaw>))]
public sealed record class CallPaymentProgressWebhookEvent : JsonModel
{
    public CallPaymentProgressWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPaymentProgressWebhookEventData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CallPaymentProgressWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentProgressWebhookEvent (
        CallPaymentProgressWebhookEvent callPaymentProgressWebhookEvent
    ) : base(callPaymentProgressWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallPaymentProgressWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentProgressWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentProgressWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallPaymentProgressWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPaymentProgressWebhookEventFromRaw : IFromRawJson<CallPaymentProgressWebhookEvent>
{
    /// <inheritdoc/>
    public CallPaymentProgressWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentProgressWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallPaymentProgressWebhookEventData, CallPaymentProgressWebhookEventDataFromRaw>))]
public sealed record class CallPaymentProgressWebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
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
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, CallPaymentProgressWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentProgressWebhookEventDataEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public CallPaymentProgressWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPaymentProgressWebhookEventDataPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, CallPaymentProgressWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentProgressWebhookEventDataRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public CallPaymentProgressWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentProgressWebhookEventData (
        CallPaymentProgressWebhookEventData callPaymentProgressWebhookEventData
    ) : base(callPaymentProgressWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallPaymentProgressWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentProgressWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentProgressWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallPaymentProgressWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPaymentProgressWebhookEventDataFromRaw : IFromRawJson<CallPaymentProgressWebhookEventData>
{
    /// <inheritdoc/>
    public CallPaymentProgressWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentProgressWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallPaymentProgressWebhookEventDataEventTypeConverter))]
public enum CallPaymentProgressWebhookEventDataEventType
{
    CallPaymentProgress
}sealed class CallPaymentProgressWebhookEventDataEventTypeConverter : JsonConverter<CallPaymentProgressWebhookEventDataEventType>
{
    public override CallPaymentProgressWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.payment.progress"=>CallPaymentProgressWebhookEventDataEventType.CallPaymentProgress,
            _ =>(CallPaymentProgressWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentProgressWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentProgressWebhookEventDataEventType.CallPaymentProgress=>"call.payment.progress",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallPaymentProgressWebhookEventDataPayload, CallPaymentProgressWebhookEventDataPayloadFromRaw>))]
public sealed record class CallPaymentProgressWebhookEventDataPayload : JsonModel
{
    /// <summary>
    /// Current 1-based attempt number for the step.
    /// </summary>
    public int? Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "attempt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempt", value);
        }
    }

    /// <summary>
    /// Masked bank account number with only the last two digits visible.
    /// </summary>
    public string? BankAccountNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bank_account_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bank_account_number", value);
        }
    }

    /// <summary>
    /// Bank account type, when available.
    /// </summary>
    public string? BankAccountType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bank_account_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bank_account_type", value);
        }
    }

    /// <summary>
    /// Bank routing number collected from the caller.
    /// </summary>
    public string? BankRoutingNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bank_routing_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bank_routing_number", value);
        }
    }

    /// <summary>
    /// Call ID used to issue commands via Call Control API.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// ID unique to the call leg.
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// ID shared by related call legs in the same call session.
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <summary>
    /// Base64-encoded state received from the command.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Call Control App ID used in the call.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// Step-level error when payment collection fails.
    /// </summary>
    public ApiEnum<string, ErrorType>? ErrorType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ErrorType>>(
                "error_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_type", value);
        }
    }

    /// <summary>
    /// Card expiration date in MMYY format.
    /// </summary>
    public string? ExpirationDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "expiration_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <summary>
    /// Number or SIP URI placing the call.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// Masked card number with only the last four digits visible.
    /// </summary>
    public string? PaymentCardNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_card_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_card_number", value);
        }
    }

    /// <summary>
    /// Billing postal code collected from the caller.
    /// </summary>
    public string? PaymentCardPostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_card_postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_card_postal_code", value);
        }
    }

    /// <summary>
    /// Detected card type. Present only for the recognized card brands listed below.
    /// </summary>
    public ApiEnum<string, CallPaymentProgressWebhookEventDataPayloadPaymentCardType>? PaymentCardType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentProgressWebhookEventDataPayloadPaymentCardType>>(
                "payment_card_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_card_type", value);
        }
    }

    /// <summary>
    /// Name of the Pay connector used.
    /// </summary>
    public string? PaymentConnector {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_connector"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_connector", value);
        }
    }

    /// <summary>
    /// Payment method being collected.
    /// </summary>
    public ApiEnum<string, CallPaymentProgressWebhookEventDataPayloadPaymentMethod>? PaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentProgressWebhookEventDataPayloadPaymentMethod>>(
                "payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_method", value);
        }
    }

    /// <summary>
    /// Status of the current payment step.
    /// </summary>
    public ApiEnum<string, PaymentStatus>? PaymentStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentStatus>>(
                "payment_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_status", value);
        }
    }

    /// <summary>
    /// Current payment collection or processing step.
    /// </summary>
    public ApiEnum<string, PaymentStep>? PaymentStep {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentStep>>(
                "payment_step"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_step", value);
        }
    }

    /// <summary>
    /// Fully masked card security code.
    /// </summary>
    public string? SecurityCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "security_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("security_code", value);
        }
    }

    /// <summary>
    /// Destination number or SIP URI of the call.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempt;
        _ = this.BankAccountNumber;
        _ = this.BankAccountType;
        _ = this.BankRoutingNumber;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.ErrorType?.Validate();
        _ = this.ExpirationDate;
        _ = this.From;
        _ = this.PaymentCardNumber;
        _ = this.PaymentCardPostalCode;
        this.PaymentCardType?.Validate();
        _ = this.PaymentConnector;
        this.PaymentMethod?.Validate();
        this.PaymentStatus?.Validate();
        this.PaymentStep?.Validate();
        _ = this.SecurityCode;
        _ = this.To;
    }

    public CallPaymentProgressWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentProgressWebhookEventDataPayload (
        CallPaymentProgressWebhookEventDataPayload callPaymentProgressWebhookEventDataPayload
    ) : base(callPaymentProgressWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallPaymentProgressWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentProgressWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentProgressWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallPaymentProgressWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPaymentProgressWebhookEventDataPayloadFromRaw : IFromRawJson<CallPaymentProgressWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallPaymentProgressWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentProgressWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Step-level error when payment collection fails.
/// </summary>
[JsonConverter(typeof(ErrorTypeConverter))]
public enum ErrorType
{
    Timeout,
    InvalidCardNumber,
    InvalidCardType,
    InvalidDate,
    InvalidSecurityCode,
    InvalidPostalCode,
    InvalidBankRoutingNumber,
    InvalidBankAccountNumber,
    InputMatchingFailed
}sealed class ErrorTypeConverter : JsonConverter<ErrorType>
{
    public override ErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "timeout"=>ErrorType.Timeout,
            "invalid-card-number"=>ErrorType.InvalidCardNumber,
            "invalid-card-type"=>ErrorType.InvalidCardType,
            "invalid-date"=>ErrorType.InvalidDate,
            "invalid-security-code"=>ErrorType.InvalidSecurityCode,
            "invalid-postal-code"=>ErrorType.InvalidPostalCode,
            "invalid-bank-routing-number"=>ErrorType.InvalidBankRoutingNumber,
            "invalid-bank-account-number"=>ErrorType.InvalidBankAccountNumber,
            "input-matching-failed"=>ErrorType.InputMatchingFailed,
            _ =>(ErrorType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ErrorType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ErrorType.Timeout=>"timeout",
            ErrorType.InvalidCardNumber=>"invalid-card-number",
            ErrorType.InvalidCardType=>"invalid-card-type",
            ErrorType.InvalidDate=>"invalid-date",
            ErrorType.InvalidSecurityCode=>"invalid-security-code",
            ErrorType.InvalidPostalCode=>"invalid-postal-code",
            ErrorType.InvalidBankRoutingNumber=>"invalid-bank-routing-number",
            ErrorType.InvalidBankAccountNumber=>"invalid-bank-account-number",
            ErrorType.InputMatchingFailed=>"input-matching-failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Detected card type. Present only for the recognized card brands listed below.
/// </summary>
[JsonConverter(typeof(CallPaymentProgressWebhookEventDataPayloadPaymentCardTypeConverter))]
public enum CallPaymentProgressWebhookEventDataPayloadPaymentCardType
{
    Visa, Mastercard, Amex, Optima, Discover, DinersClub, Jcb, Maestro, Enroute
}sealed class CallPaymentProgressWebhookEventDataPayloadPaymentCardTypeConverter : JsonConverter<CallPaymentProgressWebhookEventDataPayloadPaymentCardType>
{
    public override CallPaymentProgressWebhookEventDataPayloadPaymentCardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Visa,
            "mastercard"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Mastercard,
            "amex"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Amex,
            "optima"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Optima,
            "discover"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Discover,
            "diners-club"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.DinersClub,
            "jcb"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Jcb,
            "maestro"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Maestro,
            "enroute"=>CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Enroute,
            _ =>(CallPaymentProgressWebhookEventDataPayloadPaymentCardType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentProgressWebhookEventDataPayloadPaymentCardType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Visa=>"visa",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Mastercard=>"mastercard",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Amex=>"amex",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Optima=>"optima",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Discover=>"discover",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.DinersClub=>"diners-club",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Jcb=>"jcb",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Maestro=>"maestro",
            CallPaymentProgressWebhookEventDataPayloadPaymentCardType.Enroute=>"enroute",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Payment method being collected.
/// </summary>
[JsonConverter(typeof(CallPaymentProgressWebhookEventDataPayloadPaymentMethodConverter))]
public enum CallPaymentProgressWebhookEventDataPayloadPaymentMethod
{
    CreditCard, AchDebit
}sealed class CallPaymentProgressWebhookEventDataPayloadPaymentMethodConverter : JsonConverter<CallPaymentProgressWebhookEventDataPayloadPaymentMethod>
{
    public override CallPaymentProgressWebhookEventDataPayloadPaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit-card"=>CallPaymentProgressWebhookEventDataPayloadPaymentMethod.CreditCard,
            "ach-debit"=>CallPaymentProgressWebhookEventDataPayloadPaymentMethod.AchDebit,
            _ =>(CallPaymentProgressWebhookEventDataPayloadPaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentProgressWebhookEventDataPayloadPaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentProgressWebhookEventDataPayloadPaymentMethod.CreditCard=>"credit-card",
            CallPaymentProgressWebhookEventDataPayloadPaymentMethod.AchDebit=>"ach-debit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of the current payment step.
/// </summary>
[JsonConverter(typeof(PaymentStatusConverter))]
public enum PaymentStatus
{
    Completed, Failed, Processing
}sealed class PaymentStatusConverter : JsonConverter<PaymentStatus>
{
    public override PaymentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed"=>PaymentStatus.Completed,
            "failed"=>PaymentStatus.Failed,
            "processing"=>PaymentStatus.Processing,
            _ =>(PaymentStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentStatus.Completed=>"completed",
            PaymentStatus.Failed=>"failed",
            PaymentStatus.Processing=>"processing",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current payment collection or processing step.
/// </summary>
[JsonConverter(typeof(PaymentStepConverter))]
public enum PaymentStep
{
    PaymentCardNumber,
    ExpirationDate,
    PostalCode,
    SecurityCode,
    BankRoutingNumber,
    BankAccountNumber,
    PaymentProcessing
}sealed class PaymentStepConverter : JsonConverter<PaymentStep>
{
    public override PaymentStep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "payment-card-number"=>PaymentStep.PaymentCardNumber,
            "expiration-date"=>PaymentStep.ExpirationDate,
            "postal-code"=>PaymentStep.PostalCode,
            "security-code"=>PaymentStep.SecurityCode,
            "bank-routing-number"=>PaymentStep.BankRoutingNumber,
            "bank-account-number"=>PaymentStep.BankAccountNumber,
            "payment-processing"=>PaymentStep.PaymentProcessing,
            _ =>(PaymentStep)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, PaymentStep value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentStep.PaymentCardNumber=>"payment-card-number",
            PaymentStep.ExpirationDate=>"expiration-date",
            PaymentStep.PostalCode=>"postal-code",
            PaymentStep.SecurityCode=>"security-code",
            PaymentStep.BankRoutingNumber=>"bank-routing-number",
            PaymentStep.BankAccountNumber=>"bank-account-number",
            PaymentStep.PaymentProcessing=>"payment-processing",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallPaymentProgressWebhookEventDataRecordTypeConverter))]
public enum CallPaymentProgressWebhookEventDataRecordType
{
    Event
}sealed class CallPaymentProgressWebhookEventDataRecordTypeConverter : JsonConverter<CallPaymentProgressWebhookEventDataRecordType>
{
    public override CallPaymentProgressWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallPaymentProgressWebhookEventDataRecordType.Event,
            _ =>(CallPaymentProgressWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentProgressWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentProgressWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}