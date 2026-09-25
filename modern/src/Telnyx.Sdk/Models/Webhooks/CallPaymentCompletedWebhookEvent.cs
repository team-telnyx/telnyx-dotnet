using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPaymentCompletedWebhookEvent, CallPaymentCompletedWebhookEventFromRaw>))]
public sealed record class CallPaymentCompletedWebhookEvent : JsonModel
{
    public CallPaymentCompletedWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPaymentCompletedWebhookEventData>(
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

    public CallPaymentCompletedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentCompletedWebhookEvent (
        CallPaymentCompletedWebhookEvent callPaymentCompletedWebhookEvent
    ) : base(callPaymentCompletedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallPaymentCompletedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentCompletedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentCompletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallPaymentCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPaymentCompletedWebhookEventFromRaw : IFromRawJson<CallPaymentCompletedWebhookEvent>
{
    /// <inheritdoc/>
    public CallPaymentCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentCompletedWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallPaymentCompletedWebhookEventData, CallPaymentCompletedWebhookEventDataFromRaw>))]
public sealed record class CallPaymentCompletedWebhookEventData : JsonModel
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
    public ApiEnum<string, CallPaymentCompletedWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentCompletedWebhookEventDataEventType>>(
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

    public CallPaymentCompletedWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPaymentCompletedWebhookEventDataPayload>(
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
    public ApiEnum<string, CallPaymentCompletedWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentCompletedWebhookEventDataRecordType>>(
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

    public CallPaymentCompletedWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentCompletedWebhookEventData (
        CallPaymentCompletedWebhookEventData callPaymentCompletedWebhookEventData
    ) : base(callPaymentCompletedWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public CallPaymentCompletedWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentCompletedWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentCompletedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static CallPaymentCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPaymentCompletedWebhookEventDataFromRaw : IFromRawJson<CallPaymentCompletedWebhookEventData>
{
    /// <inheritdoc/>
    public CallPaymentCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentCompletedWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallPaymentCompletedWebhookEventDataEventTypeConverter))]
public enum CallPaymentCompletedWebhookEventDataEventType
{
    CallPaymentCompleted
}sealed class CallPaymentCompletedWebhookEventDataEventTypeConverter : JsonConverter<CallPaymentCompletedWebhookEventDataEventType>
{
    public override CallPaymentCompletedWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.payment.completed"=>CallPaymentCompletedWebhookEventDataEventType.CallPaymentCompleted,
            _ =>(CallPaymentCompletedWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentCompletedWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentCompletedWebhookEventDataEventType.CallPaymentCompleted=>"call.payment.completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallPaymentCompletedWebhookEventDataPayload, CallPaymentCompletedWebhookEventDataPayloadFromRaw>))]
public sealed record class CallPaymentCompletedWebhookEventDataPayload : JsonModel
{
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
    /// Charge identifier returned for a successful charge transaction.
    /// </summary>
    public string? ChargeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "charge_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("charge_id", value);
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
    /// Additional connector error information, when supplied by the processor.
    /// </summary>
    public ConnectorError? ConnectorError {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectorError>(
                "connector_error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connector_error", value);
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
    /// Error code returned by the payment connector or processor.
    /// </summary>
    public string? PayErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pay_error_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pay_error_code", value);
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
    public ApiEnum<string, PaymentCardType>? PaymentCardType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentCardType>>(
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
    /// Payment confirmation code returned by the processor, when available.
    /// </summary>
    public string? PaymentConfirmationCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_confirmation_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_confirmation_code", value);
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
    /// Step-level or processor error associated with the final result.
    /// </summary>
    public string? PaymentError {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_error", value);
        }
    }

    /// <summary>
    /// Payment method being collected.
    /// </summary>
    public ApiEnum<string, PaymentMethod>? PaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentMethod>>(
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
    /// Final Pay session result.
    /// </summary>
    public ApiEnum<string, CallPaymentCompletedWebhookEventDataPayloadResult>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallPaymentCompletedWebhookEventDataPayloadResult>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
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

    /// <summary>
    /// Token identifier returned for a successful tokenize transaction.
    /// </summary>
    public string? TokenID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BankAccountNumber;
        _ = this.BankAccountType;
        _ = this.BankRoutingNumber;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ChargeID;
        _ = this.ClientState;
        _ = this.ConnectionID;
        this.ConnectorError?.Validate();
        _ = this.ExpirationDate;
        _ = this.From;
        _ = this.PayErrorCode;
        _ = this.PaymentCardNumber;
        _ = this.PaymentCardPostalCode;
        this.PaymentCardType?.Validate();
        _ = this.PaymentConfirmationCode;
        _ = this.PaymentConnector;
        _ = this.PaymentError;
        this.PaymentMethod?.Validate();
        this.Result?.Validate();
        _ = this.SecurityCode;
        _ = this.To;
        _ = this.TokenID;
    }

    public CallPaymentCompletedWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPaymentCompletedWebhookEventDataPayload (
        CallPaymentCompletedWebhookEventDataPayload callPaymentCompletedWebhookEventDataPayload
    ) : base(callPaymentCompletedWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public CallPaymentCompletedWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPaymentCompletedWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPaymentCompletedWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static CallPaymentCompletedWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallPaymentCompletedWebhookEventDataPayloadFromRaw : IFromRawJson<CallPaymentCompletedWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public CallPaymentCompletedWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPaymentCompletedWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Additional connector error information, when supplied by the processor.
/// </summary>
[JsonConverter(typeof(ConnectorErrorConverter))]
public record class ConnectorError : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ConnectorError (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConnectorError (
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ConnectorError (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDetails(out var value)) {
///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDetails(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (string value) =&gt; {...},
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyDictionary<string, JsonElement>> connectorErrorDetails
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyDictionary<string, JsonElement> value:
                connectorErrorDetails(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ConnectorError");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (string value) =&gt; {...},
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> connectorErrorDetails
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            IReadOnlyDictionary<string, JsonElement> value=>connectorErrorDetails(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ConnectorError")
        } ;
    }

    public static implicit operator ConnectorError (string value)=> new(value) ;

    public static implicit operator ConnectorError (
        Dictionary<string, JsonElement> value
    )=> new((IReadOnlyDictionary<string, JsonElement>)value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of ConnectorError");
        }
    }

    public virtual bool Equals(ConnectorError? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { string _=>0, IReadOnlyDictionary<string, JsonElement> _=>1, _ =>-1 } ;
    }
}sealed class ConnectorErrorConverter : JsonConverter<ConnectorError>
{
    public override ConnectorError? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConnectorError value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Detected card type. Present only for the recognized card brands listed below.
/// </summary>
[JsonConverter(typeof(PaymentCardTypeConverter))]
public enum PaymentCardType
{
    Visa, Mastercard, Amex, Optima, Discover, DinersClub, Jcb, Maestro, Enroute
}sealed class PaymentCardTypeConverter : JsonConverter<PaymentCardType>
{
    public override PaymentCardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa"=>PaymentCardType.Visa,
            "mastercard"=>PaymentCardType.Mastercard,
            "amex"=>PaymentCardType.Amex,
            "optima"=>PaymentCardType.Optima,
            "discover"=>PaymentCardType.Discover,
            "diners-club"=>PaymentCardType.DinersClub,
            "jcb"=>PaymentCardType.Jcb,
            "maestro"=>PaymentCardType.Maestro,
            "enroute"=>PaymentCardType.Enroute,
            _ =>(PaymentCardType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCardType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentCardType.Visa=>"visa",
            PaymentCardType.Mastercard=>"mastercard",
            PaymentCardType.Amex=>"amex",
            PaymentCardType.Optima=>"optima",
            PaymentCardType.Discover=>"discover",
            PaymentCardType.DinersClub=>"diners-club",
            PaymentCardType.Jcb=>"jcb",
            PaymentCardType.Maestro=>"maestro",
            PaymentCardType.Enroute=>"enroute",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Payment method being collected.
/// </summary>
[JsonConverter(typeof(PaymentMethodConverter))]
public enum PaymentMethod
{
    CreditCard, AchDebit
}sealed class PaymentMethodConverter : JsonConverter<PaymentMethod>
{
    public override PaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit-card"=>PaymentMethod.CreditCard,
            "ach-debit"=>PaymentMethod.AchDebit,
            _ =>(PaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentMethod.CreditCard=>"credit-card",
            PaymentMethod.AchDebit=>"ach-debit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Final Pay session result.
/// </summary>
[JsonConverter(typeof(CallPaymentCompletedWebhookEventDataPayloadResultConverter))]
public enum CallPaymentCompletedWebhookEventDataPayloadResult
{
    Success,
    PaymentConnectorError,
    InternalError,
    TooManyFailedAttempts,
    Cancelled
}sealed class CallPaymentCompletedWebhookEventDataPayloadResultConverter : JsonConverter<CallPaymentCompletedWebhookEventDataPayloadResult>
{
    public override CallPaymentCompletedWebhookEventDataPayloadResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success"=>CallPaymentCompletedWebhookEventDataPayloadResult.Success,
            "payment-connector-error"=>CallPaymentCompletedWebhookEventDataPayloadResult.PaymentConnectorError,
            "internal-error"=>CallPaymentCompletedWebhookEventDataPayloadResult.InternalError,
            "too-many-failed-attempts"=>CallPaymentCompletedWebhookEventDataPayloadResult.TooManyFailedAttempts,
            "cancelled"=>CallPaymentCompletedWebhookEventDataPayloadResult.Cancelled,
            _ =>(CallPaymentCompletedWebhookEventDataPayloadResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentCompletedWebhookEventDataPayloadResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentCompletedWebhookEventDataPayloadResult.Success=>"success",
            CallPaymentCompletedWebhookEventDataPayloadResult.PaymentConnectorError=>"payment-connector-error",
            CallPaymentCompletedWebhookEventDataPayloadResult.InternalError=>"internal-error",
            CallPaymentCompletedWebhookEventDataPayloadResult.TooManyFailedAttempts=>"too-many-failed-attempts",
            CallPaymentCompletedWebhookEventDataPayloadResult.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallPaymentCompletedWebhookEventDataRecordTypeConverter))]
public enum CallPaymentCompletedWebhookEventDataRecordType
{
    Event
}sealed class CallPaymentCompletedWebhookEventDataRecordTypeConverter : JsonConverter<CallPaymentCompletedWebhookEventDataRecordType>
{
    public override CallPaymentCompletedWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallPaymentCompletedWebhookEventDataRecordType.Event,
            _ =>(CallPaymentCompletedWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallPaymentCompletedWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallPaymentCompletedWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}