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

namespace Telnyx.Sdk.Models.InexplicitNumberOrders;

/// <summary>
/// Create an inexplicit number order to programmatically purchase phone numbers
/// without specifying exact numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InexplicitNumberOrderCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Group(s) of numbers to order. You can have multiple ordering_groups objects
    /// added to a single request.
    /// </summary>
    public required IReadOnlyList<OrderingGroup> OrderingGroups {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<OrderingGroup>>(
                "ordering_groups"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<OrderingGroup>>(
                "ordering_groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Billing group id to apply to phone numbers that are purchased
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Connection id to apply to phone numbers that are purchased
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// Reference label for the customer
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Messaging profile id to apply to phone numbers that are purchased
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("messaging_profile_id", value);
        }
    }

    public InexplicitNumberOrderCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderCreateParams (
        InexplicitNumberOrderCreateParams inexplicitNumberOrderCreateParams
    ) : base(inexplicitNumberOrderCreateParams)
    { this._rawBodyData = new(inexplicitNumberOrderCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public InexplicitNumberOrderCreateParams (
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
    InexplicitNumberOrderCreateParams (
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
    public static InexplicitNumberOrderCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InexplicitNumberOrderCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/inexplicit_number_orders"
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

[JsonConverter(typeof(JsonModelConverter<OrderingGroup, OrderingGroupFromRaw>))]
public sealed record class OrderingGroup : JsonModel
{
    /// <summary>
    /// Quantity of phone numbers to order
    /// </summary>
    public required string CountRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "count_requested"
            );
        }
        init { this._rawData.Set("count_requested", value); }
    }

    /// <summary>
    /// Country where you would like to purchase phone numbers. Allowable values:
    /// US, CA
    /// </summary>
    public required ApiEnum<string, CountryIso> CountryIso {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CountryIso>>(
                "country_iso"
            );
        }
        init { this._rawData.Set("country_iso", value); }
    }

    /// <summary>
    /// Number type (local, toll-free, etc.)
    /// </summary>
    public required string PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number_type"
            );
        }
        init { this._rawData.Set("phone_number_type", value); }
    }

    /// <summary>
    /// Filter for phone numbers in a given state / province
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// Filter to exclude phone numbers that are currently on hold/reserved for your account.
    /// </summary>
    public bool? ExcludeHeldNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "exclude_held_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("exclude_held_numbers", value);
        }
    }

    /// <summary>
    /// Filter for phone numbers that have the features to satisfy your use case (e.g., ["voice"])
    /// </summary>
    public IReadOnlyList<string>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter for phone numbers in a given city / region / rate center
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// Filter by area code
    /// </summary>
    public string? NationalDestinationCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "national_destination_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("national_destination_code", value);
        }
    }

    /// <summary>
    /// Phone number search criteria
    /// </summary>
    public PhoneNumber? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumber>(
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

    /// <summary>
    /// Filter to exclude phone numbers that need additional time after to purchase
    /// to activate. Only applicable for +1 toll_free numbers.
    /// </summary>
    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
        }
    }

    /// <summary>
    /// Ordering strategy. Define what action should be taken if we don't have enough
    /// phone numbers to fulfill your request. Allowable values are: always = proceed
    /// with ordering phone numbers, regardless of current inventory levels; never
    /// = do not place any orders unless there are enough phone numbers to satisfy
    /// the request. If not specified, the always strategy will be enforced.
    /// </summary>
    public ApiEnum<string, Strategy>? Strategy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Strategy>>(
                "strategy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("strategy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountRequested;
        this.CountryIso.Validate();
        _ = this.PhoneNumberType;
        _ = this.AdministrativeArea;
        _ = this.ExcludeHeldNumbers;
        _ = this.Features;
        _ = this.Locality;
        _ = this.NationalDestinationCode;
        this.PhoneNumber?.Validate();
        _ = this.Quickship;
        this.Strategy?.Validate();
    }

    public OrderingGroup ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrderingGroup (OrderingGroup orderingGroup) : base(orderingGroup)
    {  }
    #pragma warning restore CS8618

    public OrderingGroup (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OrderingGroup (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrderingGroupFromRaw.FromRawUnchecked"/>
    public static OrderingGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OrderingGroupFromRaw : IFromRawJson<OrderingGroup>
{
    /// <inheritdoc/>
    public OrderingGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OrderingGroup.FromRawUnchecked(rawData);
}

/// <summary>
/// Country where you would like to purchase phone numbers. Allowable values: US, CA
/// </summary>
[JsonConverter(typeof(CountryIsoConverter))]
public enum CountryIso
{
    Us, Ca
}

sealed class CountryIsoConverter : JsonConverter<CountryIso>
{
    public override CountryIso Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "US"=>CountryIso.Us, "CA"=>CountryIso.Ca, _ =>(CountryIso)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, CountryIso value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CountryIso.Us=>"US",
            CountryIso.Ca=>"CA",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Phone number search criteria
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// Filter for phone numbers that contain the digits specified
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// Filter by the ending digits of the phone number
    /// </summary>
    public string? EndsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ends_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ends_with", value);
        }
    }

    /// <summary>
    /// Filter by the starting digits of the phone number
    /// </summary>
    public string? StartsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "starts_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("starts_with", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.EndsWith;
        _ = this.StartsWith;
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
}

class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// Ordering strategy. Define what action should be taken if we don't have enough
/// phone numbers to fulfill your request. Allowable values are: always = proceed
/// with ordering phone numbers, regardless of current inventory levels; never =
/// do not place any orders unless there are enough phone numbers to satisfy the
/// request. If not specified, the always strategy will be enforced.
/// </summary>
[JsonConverter(typeof(StrategyConverter))]
public enum Strategy
{
    Always, Never
}

sealed class StrategyConverter : JsonConverter<Strategy>
{
    public override Strategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>Strategy.Always,
            "never"=>Strategy.Never,
            _ =>(Strategy)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Strategy value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Strategy.Always=>"always",
            Strategy.Never=>"never",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}