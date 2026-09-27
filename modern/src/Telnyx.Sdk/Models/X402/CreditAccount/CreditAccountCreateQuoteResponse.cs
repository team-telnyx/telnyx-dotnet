using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.X402.CreditAccount;

[JsonConverter(typeof(JsonModelConverter<CreditAccountCreateQuoteResponse, CreditAccountCreateQuoteResponseFromRaw>))]
public sealed record class CreditAccountCreateQuoteResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public CreditAccountCreateQuoteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditAccountCreateQuoteResponse (
        CreditAccountCreateQuoteResponse creditAccountCreateQuoteResponse
    ) : base(creditAccountCreateQuoteResponse)
    {  }
    #pragma warning restore CS8618

    public CreditAccountCreateQuoteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditAccountCreateQuoteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreditAccountCreateQuoteResponseFromRaw.FromRawUnchecked"/>
    public static CreditAccountCreateQuoteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreditAccountCreateQuoteResponseFromRaw : IFromRawJson<CreditAccountCreateQuoteResponse>
{
    /// <inheritdoc/>
    public CreditAccountCreateQuoteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreditAccountCreateQuoteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique quote identifier. Use this to settle the payment.
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
    /// The equivalent amount in the payment cryptocurrency's smallest unit (e.g.
    /// USDC has 6 decimals, so $50.00 = "50000000").
    /// </summary>
    public string? AmountCrypto {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount_crypto"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount_crypto", value);
        }
    }

    /// <summary>
    /// The quoted amount in USD.
    /// </summary>
    public string? AmountUsd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount_usd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount_usd", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the quote expires.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// The blockchain network for the payment in CAIP-2 format (e.g. eip155:8453
    /// for Base).
    /// </summary>
    public string? Network {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "network"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network", value);
        }
    }

    /// <summary>
    /// x402 protocol v2 payment requirements. Contains all information needed to
    /// construct and sign a payment authorization.
    /// </summary>
    public PaymentRequirements? PaymentRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentRequirements>(
                "payment_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_requirements", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
        _ = this.AmountCrypto;
        _ = this.AmountUsd;
        _ = this.ExpiresAt;
        _ = this.Network;
        this.PaymentRequirements?.Validate();
        this.RecordType?.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// x402 protocol v2 payment requirements. Contains all information needed to construct
/// and sign a payment authorization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaymentRequirements, PaymentRequirementsFromRaw>))]
public sealed record class PaymentRequirements : JsonModel
{
    /// <summary>
    /// Accepted payment schemes. Currently only the `exact` EVM scheme is supported.
    /// </summary>
    public IReadOnlyList<Accept>? Accepts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Accept>>(
                "accepts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Accept>?>(
                "accepts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The resource being paid for. Included in the payment signature.
    /// </summary>
    public Resource? Resource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Resource>(
                "resource"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resource", value);
        }
    }

    /// <summary>
    /// x402 protocol version. Currently always 2.
    /// </summary>
    public ApiEnum<long, X402Version>? X402Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, X402Version>>(
                "x402Version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("x402Version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Accepts ?? [])
        {
            item.Validate();
        }
        this.Resource?.Validate();
        this.X402Version?.Validate();
    }

    public PaymentRequirements ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentRequirements (PaymentRequirements paymentRequirements) : base(
        paymentRequirements
    )
    {  }
    #pragma warning restore CS8618

    public PaymentRequirements (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRequirements (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaymentRequirementsFromRaw.FromRawUnchecked"/>
    public static PaymentRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PaymentRequirementsFromRaw : IFromRawJson<PaymentRequirements>
{
    /// <inheritdoc/>
    public PaymentRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaymentRequirements.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Accept, AcceptFromRaw>))]
public sealed record class Accept : JsonModel
{
    /// <summary>
    /// Amount in the token's smallest unit.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Token contract address (e.g. USDC on Base).
    /// </summary>
    public string? Asset {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "asset"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("asset", value);
        }
    }

    /// <summary>
    /// Additional scheme-specific parameters including EIP-712 domain info and the
    /// facilitator URL.
    /// </summary>
    public Extra? Extra {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Extra>(
                "extra"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extra", value);
        }
    }

    /// <summary>
    /// Maximum time in seconds before the payment authorization expires.
    /// </summary>
    public long? MaxTimeoutSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "maxTimeoutSeconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maxTimeoutSeconds", value);
        }
    }

    /// <summary>
    /// Blockchain network identifier in CAIP-2 format (e.g. "eip155:8453" for Base).
    /// </summary>
    public string? Network {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "network"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network", value);
        }
    }

    /// <summary>
    /// Recipient wallet address.
    /// </summary>
    public string? PayTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payTo"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payTo", value);
        }
    }

    /// <summary>
    /// Payment scheme (e.g. "exact").
    /// </summary>
    public string? Scheme {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "scheme"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("scheme", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Asset;
        this.Extra?.Validate();
        _ = this.MaxTimeoutSeconds;
        _ = this.Network;
        _ = this.PayTo;
        _ = this.Scheme;
    }

    public Accept ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Accept (Accept accept) : base(accept)
    {  }
    #pragma warning restore CS8618

    public Accept (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Accept (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AcceptFromRaw.FromRawUnchecked"/>
    public static Accept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AcceptFromRaw : IFromRawJson<Accept>
{
    /// <inheritdoc/>
    public Accept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Accept.FromRawUnchecked(rawData);
}/// <summary>
/// Additional scheme-specific parameters including EIP-712 domain info and the facilitator URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Extra, ExtraFromRaw>))]
public sealed record class Extra : JsonModel
{
    public string? FacilitatorUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "facilitatorUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("facilitatorUrl", value);
        }
    }

    /// <summary>
    /// EIP-712 domain name (e.g. "USD Coin").
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? QuoteID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "quoteId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quoteId", value);
        }
    }

    /// <summary>
    /// EIP-712 domain version.
    /// </summary>
    public string? Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FacilitatorUrl;
        _ = this.Name;
        _ = this.QuoteID;
        _ = this.Version;
    }

    public Extra ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Extra (Extra extra) : base(extra)
    {  }
    #pragma warning restore CS8618

    public Extra (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Extra (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExtraFromRaw.FromRawUnchecked"/>
    public static Extra FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ExtraFromRaw : IFromRawJson<Extra>
{
    /// <inheritdoc/>
    public Extra FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Extra.FromRawUnchecked(rawData);
}/// <summary>
/// The resource being paid for. Included in the payment signature.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Resource, ResourceFromRaw>))]
public sealed record class Resource : JsonModel
{
    /// <summary>
    /// Human-readable description of the payment.
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

    /// <summary>
    /// MIME type of the resource.
    /// </summary>
    public string? MimeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mimeType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mimeType", value);
        }
    }

    /// <summary>
    /// Canonical URL of the payment resource.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.MimeType;
        _ = this.Url;
    }

    public Resource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Resource (Resource resource) : base(resource)
    {  }
    #pragma warning restore CS8618

    public Resource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Resource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResourceFromRaw.FromRawUnchecked"/>
    public static Resource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResourceFromRaw : IFromRawJson<Resource>
{
    /// <inheritdoc/>
    public Resource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Resource.FromRawUnchecked(rawData);
}/// <summary>
/// x402 protocol version. Currently always 2.
/// </summary>
[JsonConverter(typeof(X402VersionConverter))]
public enum X402Version
{
    X402Version2
}sealed class X402VersionConverter : JsonConverter<X402Version>
{
    public override X402Version Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        { 2L=>X402Version.X402Version2, _ =>(X402Version)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, X402Version value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            X402Version.X402Version2=>2L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Quote
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "quote"=>RecordType.Quote, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Quote=>"quote",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}