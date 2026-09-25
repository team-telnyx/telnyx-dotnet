using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Collect payment details from the caller using DTMF and either charge or tokenize
/// the payment method through a configured Pay connector. Pay pauses active call
/// recordings while sensitive payment details are collected.
///
/// <para>When `payment_token` is supplied, the DTMF collection steps are skipped
/// and the existing token is sent to the connector.</para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.payment.progress` - `call.payment.completed`</para>
///
/// <para>**Test mode card numbers:** `4111111111111111` (Visa), `5555555555554444`
/// (Mastercard), `378282246310005` (American Express), `6011111111111117` (Discover),
/// `3065930009020004` (Diners Club), `3566002020360505` (JCB), `6200000000000005`
/// (UnionPay), and `6771798021000008` (Maestro). Test-mode connectors reject other
/// card numbers before contacting the configured processor. The UnionPay and Maestro
/// numbers are accepted for processor testing, but Pay currently does not emit a
/// card type for them.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionPayParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Amount to charge. Required when `transaction_type` is `charge`.
    /// </summary>
    public double? Amount {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("amount", value);
        }
    }

    /// <summary>
    /// Base64-encoded state included in subsequent webhooks.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Idempotency key for the command. Telnyx ignores a duplicate command with the
    /// same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Name of the Pay connector used to process the transaction.
    /// </summary>
    public string? ConnectorName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connector_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connector_name", value);
        }
    }

    /// <summary>
    /// Currency used for the transaction. Pay currently supports USD only.
    /// </summary>
    public ApiEnum<string, Currency>? Currency {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Currency>>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("currency", value);
        }
    }

    /// <summary>
    /// Optional description forwarded with the payment transaction.
    /// </summary>
    public string? Description {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Time in milliseconds to wait between consecutive DTMF digits.
    /// </summary>
    public int? InterDigitTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "inter_digit_timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inter_digit_timeout_millis", value);
        }
    }

    /// <summary>
    /// Language used for payment prompts.
    /// </summary>
    public string? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    /// <summary>
    /// Maximum number of attempts for each payment collection step.
    /// </summary>
    public int? MaxAttempts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "max_attempts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_attempts", value);
        }
    }

    /// <summary>
    /// Metadata forwarded to the Pay connector.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Additional parameters forwarded to the Pay connector.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Parameters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Payment method to collect.
    /// </summary>
    public ApiEnum<string, PaymentMethod>? PaymentMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PaymentMethod>>(
                "payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("payment_method", value);
        }
    }

    /// <summary>
    /// Existing payment token. When supplied, payment-detail collection is skipped.
    /// </summary>
    public string? PaymentToken {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "payment_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("payment_token", value);
        }
    }

    /// <summary>
    /// Custom text-to-speech prompts keyed by payment collection step.
    /// </summary>
    public Prompts? Prompts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Prompts>(
                "prompts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("prompts", value);
        }
    }

    /// <summary>
    /// Speech synthesis service level used for payment prompts. Pay defaults to `premium`.
    /// </summary>
    public string? ServiceLevel {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "service_level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("service_level", value);
        }
    }

    /// <summary>
    /// Time in milliseconds to wait for DTMF input for each collection step.
    /// </summary>
    public int? TimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout_millis", value);
        }
    }

    /// <summary>
    /// Transaction to perform. If omitted, Pay infers `tokenize` when `amount` is
    /// absent or zero and `charge` when `amount` is positive.
    /// </summary>
    public ApiEnum<string, TransactionType>? TransactionType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TransactionType>>(
                "transaction_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transaction_type", value);
        }
    }

    /// <summary>
    /// Restricts accepted card numbers to the listed card types. When the caller
    /// enters a card number that does not match one of the listed types, Pay treats
    /// the input as invalid and re-prompts for the card number. Cannot be used together
    /// with `payment_token`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ValidCardType>>? ValidCardTypes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, ValidCardType>>>(
                "valid_card_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, ValidCardType>>?>(
                "valid_card_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Voice used for payment prompts. Accepts `male`, `female`, or a provider voice
    /// in `&lt;Provider&gt;.&lt;Model&gt;.&lt;VoiceId&gt;` format, for example `AWS.Polly.Joanna`
    /// or `Telnyx.KokoroTTS.af`.
    /// </summary>
    public string? Voice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice", value);
        }
    }

    public ActionPayParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionPayParams (ActionPayParams actionPayParams) : base(
        actionPayParams
    )
    {
        this.CallControlID = actionPayParams.CallControlID;

        this._rawBodyData = new(actionPayParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionPayParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionPayParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionPayParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionPayParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/pay",
            this.CallControlID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Currency used for the transaction. Pay currently supports USD only.
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    UsdUppercase, UsdLowercase
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD"=>Currency.UsdUppercase,
            "usd"=>Currency.UsdLowercase,
            _ =>(Currency)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Currency value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Currency.UsdUppercase=>"USD",
            Currency.UsdLowercase=>"usd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Payment method to collect.
/// </summary>
[JsonConverter(typeof(PaymentMethodConverter))]
public enum PaymentMethod
{
    CreditCard, AchDebit
}

sealed class PaymentMethodConverter : JsonConverter<PaymentMethod>
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
}

/// <summary>
/// Custom text-to-speech prompts keyed by payment collection step.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Prompts, PromptsFromRaw>))]
public sealed record class Prompts : JsonModel
{
    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? BankAccountNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "bank-account-number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bank-account-number", value);
        }
    }

    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? BankRoutingNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "bank-routing-number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bank-routing-number", value);
        }
    }

    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? ExpirationDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "expiration-date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expiration-date", value);
        }
    }

    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? PaymentCardNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "payment-card-number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment-card-number", value);
        }
    }

    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "postal-code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal-code", value);
        }
    }

    /// <summary>
    /// A default prompt string or an ordered list of qualified prompts.
    /// </summary>
    public PayPromptValue? SecurityCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PayPromptValue>(
                "security-code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("security-code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BankAccountNumber?.Validate();
        this.BankRoutingNumber?.Validate();
        this.ExpirationDate?.Validate();
        this.PaymentCardNumber?.Validate();
        this.PostalCode?.Validate();
        this.SecurityCode?.Validate();
    }

    public Prompts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Prompts (Prompts prompts) : base(prompts)
    {  }
    #pragma warning restore CS8618

    public Prompts (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Prompts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PromptsFromRaw.FromRawUnchecked"/>
    public static Prompts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PromptsFromRaw : IFromRawJson<Prompts>
{
    /// <inheritdoc/>
    public Prompts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Prompts.FromRawUnchecked(rawData);
}

/// <summary>
/// Transaction to perform. If omitted, Pay infers `tokenize` when `amount` is absent
/// or zero and `charge` when `amount` is positive.
/// </summary>
[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    Charge, Tokenize
}

sealed class TransactionTypeConverter : JsonConverter<TransactionType>
{
    public override TransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "charge"=>TransactionType.Charge,
            "tokenize"=>TransactionType.Tokenize,
            _ =>(TransactionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TransactionType.Charge=>"charge",
            TransactionType.Tokenize=>"tokenize",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(ValidCardTypeConverter))]
public enum ValidCardType
{
    Visa, Mastercard, Amex, Maestro, Discover, Optima, Jcb, DinersClub, Enroute
}

sealed class ValidCardTypeConverter : JsonConverter<ValidCardType>
{
    public override ValidCardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visa"=>ValidCardType.Visa,
            "mastercard"=>ValidCardType.Mastercard,
            "amex"=>ValidCardType.Amex,
            "maestro"=>ValidCardType.Maestro,
            "discover"=>ValidCardType.Discover,
            "optima"=>ValidCardType.Optima,
            "jcb"=>ValidCardType.Jcb,
            "diners-club"=>ValidCardType.DinersClub,
            "enroute"=>ValidCardType.Enroute,
            _ =>(ValidCardType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ValidCardType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ValidCardType.Visa=>"visa",
            ValidCardType.Mastercard=>"mastercard",
            ValidCardType.Amex=>"amex",
            ValidCardType.Maestro=>"maestro",
            ValidCardType.Discover=>"discover",
            ValidCardType.Optima=>"optima",
            ValidCardType.Jcb=>"jcb",
            ValidCardType.DinersClub=>"diners-club",
            ValidCardType.Enroute=>"enroute",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}