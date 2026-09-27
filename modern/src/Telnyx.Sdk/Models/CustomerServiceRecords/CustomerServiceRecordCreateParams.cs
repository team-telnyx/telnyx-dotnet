using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CustomerServiceRecords;

/// <summary>
/// Create a new customer service record for the provided phone number.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerServiceRecordCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A valid US phone number in E164 format.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawBodyData.Set("phone_number", value); }
    }

    public AdditionalData? AdditionalData {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AdditionalData>(
                "additional_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("additional_data", value);
        }
    }

    /// <summary>
    /// Callback URL to receive webhook notifications.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public CustomerServiceRecordCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecordCreateParams (
        CustomerServiceRecordCreateParams customerServiceRecordCreateParams
    ) : base(customerServiceRecordCreateParams)
    { this._rawBodyData = new(customerServiceRecordCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public CustomerServiceRecordCreateParams (
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
    CustomerServiceRecordCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomerServiceRecordCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CustomerServiceRecordCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/customer_service_records"
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

[JsonConverter(typeof(JsonModelConverter<AdditionalData, AdditionalDataFromRaw>))]
public sealed record class AdditionalData : JsonModel
{
    /// <summary>
    /// The account number of the customer service record.
    /// </summary>
    public string? AccountNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_number", value);
        }
    }

    /// <summary>
    /// The first line of the address of the customer service record.
    /// </summary>
    public string? AddressLine1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address_line_1"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address_line_1", value);
        }
    }

    /// <summary>
    /// The name of the authorized person.
    /// </summary>
    public string? AuthorizedPersonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorized_person_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authorized_person_name", value);
        }
    }

    /// <summary>
    /// The billing phone number of the customer service record.
    /// </summary>
    public string? BillingPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_phone_number", value);
        }
    }

    /// <summary>
    /// The city of the customer service record.
    /// </summary>
    public string? City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// The customer code of the customer service record.
    /// </summary>
    public string? CustomerCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_code", value);
        }
    }

    /// <summary>
    /// The name of the administrator of CSR.
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

    /// <summary>
    /// The PIN of the customer service record.
    /// </summary>
    public string? Pin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pin", value);
        }
    }

    /// <summary>
    /// The state of the customer service record.
    /// </summary>
    public string? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// The zip code of the customer service record.
    /// </summary>
    public string? ZipCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zip_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zip_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.AddressLine1;
        _ = this.AuthorizedPersonName;
        _ = this.BillingPhoneNumber;
        _ = this.City;
        _ = this.CustomerCode;
        _ = this.Name;
        _ = this.Pin;
        _ = this.State;
        _ = this.ZipCode;
    }

    public AdditionalData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdditionalData (AdditionalData additionalData) : base(additionalData)
    {  }
    #pragma warning restore CS8618

    public AdditionalData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdditionalData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdditionalDataFromRaw.FromRawUnchecked"/>
    public static AdditionalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdditionalDataFromRaw : IFromRawJson<AdditionalData>
{
    /// <inheritdoc/>
    public AdditionalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdditionalData.FromRawUnchecked(rawData);
}