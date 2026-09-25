using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers;

/// <summary>
/// Returns phone numbers associated with the account. Results support pagination,
/// sorting, and filters for number attributes, status, source, connections, billing
/// groups, emergency addresses, tags, and customer references.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[tag],
    /// filter[phone_number], filter[status], filter[country_iso_alpha2], filter[connection_id],
    /// filter[voice.connection_name], filter[voice.usage_payment_method], filter[billing_group_id],
    /// filter[emergency_address_id], filter[customer_reference], filter[number_type], filter[source]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    /// <summary>
    /// Although it is an infrequent occurrence, due to the highly distributed nature
    /// of the Telnyx platform, it is possible that there will be an issue when loading
    /// in Messaging Profile information. As such, when this parameter is set to `true`
    /// and an error in fetching this information occurs, messaging profile related
    /// fields will be omitted in the response and an error message will be included
    /// instead of returning a 503 error.
    /// </summary>
    public ApiEnum<string, HandleMessagingProfileError>? HandleMessagingProfileError {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, HandleMessagingProfileError>>(
                "handle_messaging_profile_error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("handle_messaging_profile_error", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// created_at in descending order.
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public PhoneNumberListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListParams (
        PhoneNumberListParams phoneNumberListParams
    ) : base(phoneNumberListParams)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberListParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberListParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PhoneNumberListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/phone_numbers"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Consolidated filter parameter (deepObject style). Originally: filter[tag], filter[phone_number],
/// filter[status], filter[country_iso_alpha2], filter[connection_id], filter[voice.connection_name],
/// filter[voice.usage_payment_method], filter[billing_group_id], filter[emergency_address_id],
/// filter[customer_reference], filter[number_type], filter[source]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by the billing_group_id associated with phone numbers. To filter to
    /// only phone numbers that have no billing group associated them, set the value
    /// of this filter to the string 'null'.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Filter by connection_id.
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
    /// Filter by phone number country ISO alpha-2 code. Can be a single value or
    /// an array of values.
    /// </summary>
    public CountryIsoAlpha2? CountryIsoAlpha2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CountryIsoAlpha2>(
                "country_iso_alpha2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_iso_alpha2", value);
        }
    }

    /// <summary>
    /// Filter numbers via the customer_reference set.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Filter by the emergency_address_id associated with phone numbers. To filter
    /// only phone numbers that have no emergency address associated with them, set
    /// the value of this filter to the string 'null'.
    /// </summary>
    public string? EmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "emergency_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency_address_id", value);
        }
    }

    /// <summary>
    /// Filter phone numbers by phone number type.
    /// </summary>
    public NumberType? NumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberType>(
                "number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_type", value);
        }
    }

    /// <summary>
    /// Filter by phone number. Requires at least three digits.              Non-numerical
    /// characters will result in no values being returned.
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

    /// <summary>
    /// Filter phone numbers by their source. Use 'ported' for numbers ported from
    /// other carriers, or 'purchased' for numbers bought directly from Telnyx.
    /// </summary>
    public ApiEnum<string, Source>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Filter by phone number status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Filter by phone number tags.
    /// </summary>
    public string? Tag {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tag"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tag", value);
        }
    }

    /// <summary>
    /// Filter by voice connection name pattern matching.
    /// </summary>
    public VoiceConnectionName? VoiceConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceConnectionName>(
                "voice.connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice.connection_name", value);
        }
    }

    /// <summary>
    /// Filter by usage_payment_method.
    /// </summary>
    public ApiEnum<string, VoiceUsagePaymentMethod>? VoiceUsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceUsagePaymentMethod>>(
                "voice.usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice.usage_payment_method", value);
        }
    }

    /// <summary>
    /// When set to 'true', filters for phone numbers that do not have any tags applied.
    /// All other values are ignored.
    /// </summary>
    public ApiEnum<string, WithoutTags>? WithoutTags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithoutTags>>(
                "without_tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("without_tags", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingGroupID;
        _ = this.ConnectionID;
        this.CountryIsoAlpha2?.Validate();
        _ = this.CustomerReference;
        _ = this.EmergencyAddressID;
        this.NumberType?.Validate();
        _ = this.PhoneNumber;
        this.Source?.Validate();
        this.Status?.Validate();
        _ = this.Tag;
        this.VoiceConnectionName?.Validate();
        this.VoiceUsagePaymentMethod?.Validate();
        this.WithoutTags?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by phone number country ISO alpha-2 code. Can be a single value or an array
/// of values.
/// </summary>
[JsonConverter(typeof(CountryIsoAlpha2Converter))]
public record class CountryIsoAlpha2 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public CountryIsoAlpha2 (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CountryIsoAlpha2 (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CountryIsoAlpha2 (JsonElement element)
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
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CountryIsoAlpha2");

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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CountryIsoAlpha2")
        } ;
    }

    public static implicit operator CountryIsoAlpha2 (
        string value
    )=> new(value) ;

    public static implicit operator CountryIsoAlpha2 (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of CountryIsoAlpha2");
        }
    }

    public virtual bool Equals(CountryIsoAlpha2? other)
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
        { string _=>0, Generic::IReadOnlyList<string> _=>1, _ =>-1 } ;
    }
}

sealed class CountryIsoAlpha2Converter : JsonConverter<CountryIsoAlpha2>
{
    public override CountryIsoAlpha2? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
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
        CountryIsoAlpha2 value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Filter phone numbers by phone number type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumberType, NumberTypeFromRaw>))]
public sealed record class NumberType : JsonModel
{
    /// <summary>
    /// Filter phone numbers by phone number type.
    /// </summary>
    public ApiEnum<string, Eq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Eq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public NumberType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberType (NumberType numberType) : base(numberType)
    {  }
    #pragma warning restore CS8618

    public NumberType (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberTypeFromRaw.FromRawUnchecked"/>
    public static NumberType FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberTypeFromRaw : IFromRawJson<NumberType>
{
    /// <inheritdoc/>
    public NumberType FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberType.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter phone numbers by phone number type.
/// </summary>
[JsonConverter(typeof(EqConverter))]
public enum Eq
{
    Local, National, TollFree, Mobile, SharedCost
}

sealed class EqConverter : JsonConverter<Eq>
{
    public override Eq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>Eq.Local,
            "national"=>Eq.National,
            "toll_free"=>Eq.TollFree,
            "mobile"=>Eq.Mobile,
            "shared_cost"=>Eq.SharedCost,
            _ =>(Eq)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Eq value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Eq.Local=>"local",
            Eq.National=>"national",
            Eq.TollFree=>"toll_free",
            Eq.Mobile=>"mobile",
            Eq.SharedCost=>"shared_cost",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter phone numbers by their source. Use 'ported' for numbers ported from other
/// carriers, or 'purchased' for numbers bought directly from Telnyx.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Ported, Purchased
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ported"=>Source.Ported,
            "purchased"=>Source.Purchased,
            _ =>(Source)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Source value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Source.Ported=>"ported",
            Source.Purchased=>"purchased",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by phone number status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    PurchasePending,
    PurchaseFailed,
    PortPending,
    Active,
    Deleted,
    PortFailed,
    EmergencyOnly,
    PortedOut,
    PortOutPending
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>Status.PurchasePending,
            "purchase-failed"=>Status.PurchaseFailed,
            "port-pending"=>Status.PortPending,
            "active"=>Status.Active,
            "deleted"=>Status.Deleted,
            "port-failed"=>Status.PortFailed,
            "emergency-only"=>Status.EmergencyOnly,
            "ported-out"=>Status.PortedOut,
            "port-out-pending"=>Status.PortOutPending,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.PurchasePending=>"purchase-pending",
            Status.PurchaseFailed=>"purchase-failed",
            Status.PortPending=>"port-pending",
            Status.Active=>"active",
            Status.Deleted=>"deleted",
            Status.PortFailed=>"port-failed",
            Status.EmergencyOnly=>"emergency-only",
            Status.PortedOut=>"ported-out",
            Status.PortOutPending=>"port-out-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by voice connection name pattern matching.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceConnectionName, VoiceConnectionNameFromRaw>))]
public sealed record class VoiceConnectionName : JsonModel
{
    /// <summary>
    /// Filter contains connection name. Requires at least three characters.
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
    /// Filter ends with connection name. Requires at least three characters.
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
    /// Filter by connection name.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <summary>
    /// Filter starts with connection name. Requires at least three characters.
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
        _ = this.Eq;
        _ = this.StartsWith;
    }

    public VoiceConnectionName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceConnectionName (VoiceConnectionName voiceConnectionName) : base(
        voiceConnectionName
    )
    {  }
    #pragma warning restore CS8618

    public VoiceConnectionName (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceConnectionName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceConnectionNameFromRaw.FromRawUnchecked"/>
    public static VoiceConnectionName FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceConnectionNameFromRaw : IFromRawJson<VoiceConnectionName>
{
    /// <inheritdoc/>
    public VoiceConnectionName FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceConnectionName.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by usage_payment_method.
/// </summary>
[JsonConverter(typeof(VoiceUsagePaymentMethodConverter))]
public enum VoiceUsagePaymentMethod
{
    PayPerMinute, Channel
}

sealed class VoiceUsagePaymentMethodConverter : JsonConverter<VoiceUsagePaymentMethod>
{
    public override VoiceUsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>VoiceUsagePaymentMethod.PayPerMinute,
            "channel"=>VoiceUsagePaymentMethod.Channel,
            _ =>(VoiceUsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceUsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceUsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            VoiceUsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// When set to 'true', filters for phone numbers that do not have any tags applied.
/// All other values are ignored.
/// </summary>
[JsonConverter(typeof(WithoutTagsConverter))]
public enum WithoutTags
{
    True, False
}

sealed class WithoutTagsConverter : JsonConverter<WithoutTags>
{
    public override WithoutTags Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true"=>WithoutTags.True,
            "false"=>WithoutTags.False,
            _ =>(WithoutTags)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, WithoutTags value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithoutTags.True=>"true",
            WithoutTags.False=>"false",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Although it is an infrequent occurrence, due to the highly distributed nature
/// of the Telnyx platform, it is possible that there will be an issue when loading
/// in Messaging Profile information. As such, when this parameter is set to `true`
/// and an error in fetching this information occurs, messaging profile related fields
/// will be omitted in the response and an error message will be included instead
/// of returning a 503 error.
/// </summary>
[JsonConverter(typeof(HandleMessagingProfileErrorConverter))]
public enum HandleMessagingProfileError
{
    True, False
}

sealed class HandleMessagingProfileErrorConverter : JsonConverter<HandleMessagingProfileError>
{
    public override HandleMessagingProfileError Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true"=>HandleMessagingProfileError.True,
            "false"=>HandleMessagingProfileError.False,
            _ =>(HandleMessagingProfileError)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HandleMessagingProfileError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HandleMessagingProfileError.True=>"true",
            HandleMessagingProfileError.False=>"false",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by created_at
/// in descending order.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    PurchasedAt, PhoneNumber, ConnectionName, UsagePaymentMethod
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchased_at"=>Sort.PurchasedAt,
            "phone_number"=>Sort.PhoneNumber,
            "connection_name"=>Sort.ConnectionName,
            "usage_payment_method"=>Sort.UsagePaymentMethod,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.PurchasedAt=>"purchased_at",
            Sort.PhoneNumber=>"phone_number",
            Sort.ConnectionName=>"connection_name",
            Sort.UsagePaymentMethod=>"usage_payment_method",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}