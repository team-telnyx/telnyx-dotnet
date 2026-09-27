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
/// List phone numbers, This endpoint is a lighter version of the /phone_numbers
/// endpoint having higher performance and rate limit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberSlimListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[tag],
    /// filter[phone_number], filter[status], filter[country_iso_alpha2], filter[connection_id],
    /// filter[voice.connection_name], filter[voice.usage_payment_method], filter[billing_group_id],
    /// filter[emergency_address_id], filter[customer_reference], filter[number_type], filter[source]
    /// </summary>
    public PhoneNumberSlimListParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<PhoneNumberSlimListParamsFilter>(
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
    /// Include the connection associated with the phone number.
    /// </summary>
    public bool? IncludeConnection {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_connection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_connection", value);
        }
    }

    /// <summary>
    /// Include the tags associated with the phone number.
    /// </summary>
    public bool? IncludeTags {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_tags", value);
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
    public ApiEnum<string, PhoneNumberSlimListParamsSort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListParamsSort>>(
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

    public PhoneNumberSlimListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListParams (
        PhoneNumberSlimListParams phoneNumberSlimListParams
    ) : base(phoneNumberSlimListParams)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberSlimListParams FromRawUnchecked(
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

    public virtual bool Equals(PhoneNumberSlimListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/phone_numbers/slim"
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
[JsonConverter(typeof(JsonModelConverter<PhoneNumberSlimListParamsFilter, PhoneNumberSlimListParamsFilterFromRaw>))]
public sealed record class PhoneNumberSlimListParamsFilter : JsonModel
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
    public PhoneNumberSlimListParamsFilterCountryIsoAlpha2? CountryIsoAlpha2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberSlimListParamsFilterCountryIsoAlpha2>(
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
    public PhoneNumberSlimListParamsFilterNumberType? NumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberSlimListParamsFilterNumberType>(
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
    public ApiEnum<string, PhoneNumberSlimListParamsFilterSource>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListParamsFilterSource>>(
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
    public ApiEnum<string, PhoneNumberSlimListParamsFilterStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListParamsFilterStatus>>(
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
    /// Filter by phone number tags. (This requires the include_tags param)
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
    /// Filter by voice connection name pattern matching (requires include_connection param).
    /// </summary>
    public PhoneNumberSlimListParamsFilterVoiceConnectionName? VoiceConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberSlimListParamsFilterVoiceConnectionName>(
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
    public ApiEnum<string, PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod>? VoiceUsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod>>(
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
    }

    public PhoneNumberSlimListParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListParamsFilter (
        PhoneNumberSlimListParamsFilter phoneNumberSlimListParamsFilter
    ) : base(phoneNumberSlimListParamsFilter)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListParamsFilter (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListParamsFilter (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSlimListParamsFilterFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSlimListParamsFilter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberSlimListParamsFilterFromRaw : IFromRawJson<PhoneNumberSlimListParamsFilter>
{
    /// <inheritdoc/>
    public PhoneNumberSlimListParamsFilter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberSlimListParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by phone number country ISO alpha-2 code. Can be a single value or an array
/// of values.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListParamsFilterCountryIsoAlpha2Converter))]
public record class PhoneNumberSlimListParamsFilterCountryIsoAlpha2 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public PhoneNumberSlimListParamsFilterCountryIsoAlpha2 (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PhoneNumberSlimListParamsFilterCountryIsoAlpha2 (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public PhoneNumberSlimListParamsFilterCountryIsoAlpha2 (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of PhoneNumberSlimListParamsFilterCountryIsoAlpha2");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of PhoneNumberSlimListParamsFilterCountryIsoAlpha2")
        } ;
    }

    public static implicit operator PhoneNumberSlimListParamsFilterCountryIsoAlpha2 (
        string value
    )=> new(value) ;

    public static implicit operator PhoneNumberSlimListParamsFilterCountryIsoAlpha2 (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of PhoneNumberSlimListParamsFilterCountryIsoAlpha2");
        }
    }

    public virtual bool Equals(
        PhoneNumberSlimListParamsFilterCountryIsoAlpha2? other
    )
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

sealed class PhoneNumberSlimListParamsFilterCountryIsoAlpha2Converter : JsonConverter<PhoneNumberSlimListParamsFilterCountryIsoAlpha2>
{
    public override PhoneNumberSlimListParamsFilterCountryIsoAlpha2? Read(
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
        PhoneNumberSlimListParamsFilterCountryIsoAlpha2 value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Filter phone numbers by phone number type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberSlimListParamsFilterNumberType, PhoneNumberSlimListParamsFilterNumberTypeFromRaw>))]
public sealed record class PhoneNumberSlimListParamsFilterNumberType : JsonModel
{
    /// <summary>
    /// Filter phone numbers by phone number type.
    /// </summary>
    public ApiEnum<string, PhoneNumberSlimListParamsFilterNumberTypeEq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberSlimListParamsFilterNumberTypeEq>>(
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

    public PhoneNumberSlimListParamsFilterNumberType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListParamsFilterNumberType (
        PhoneNumberSlimListParamsFilterNumberType phoneNumberSlimListParamsFilterNumberType
    ) : base(phoneNumberSlimListParamsFilterNumberType)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListParamsFilterNumberType (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListParamsFilterNumberType (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSlimListParamsFilterNumberTypeFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSlimListParamsFilterNumberType FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberSlimListParamsFilterNumberTypeFromRaw : IFromRawJson<PhoneNumberSlimListParamsFilterNumberType>
{
    /// <inheritdoc/>
    public PhoneNumberSlimListParamsFilterNumberType FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberSlimListParamsFilterNumberType.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter phone numbers by phone number type.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListParamsFilterNumberTypeEqConverter))]
public enum PhoneNumberSlimListParamsFilterNumberTypeEq
{
    Local, National, TollFree, Mobile, SharedCost
}

sealed class PhoneNumberSlimListParamsFilterNumberTypeEqConverter : JsonConverter<PhoneNumberSlimListParamsFilterNumberTypeEq>
{
    public override PhoneNumberSlimListParamsFilterNumberTypeEq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberSlimListParamsFilterNumberTypeEq.Local,
            "national"=>PhoneNumberSlimListParamsFilterNumberTypeEq.National,
            "toll_free"=>PhoneNumberSlimListParamsFilterNumberTypeEq.TollFree,
            "mobile"=>PhoneNumberSlimListParamsFilterNumberTypeEq.Mobile,
            "shared_cost"=>PhoneNumberSlimListParamsFilterNumberTypeEq.SharedCost,
            _ =>(PhoneNumberSlimListParamsFilterNumberTypeEq)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListParamsFilterNumberTypeEq value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListParamsFilterNumberTypeEq.Local=>"local",
            PhoneNumberSlimListParamsFilterNumberTypeEq.National=>"national",
            PhoneNumberSlimListParamsFilterNumberTypeEq.TollFree=>"toll_free",
            PhoneNumberSlimListParamsFilterNumberTypeEq.Mobile=>"mobile",
            PhoneNumberSlimListParamsFilterNumberTypeEq.SharedCost=>"shared_cost",
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
[JsonConverter(typeof(PhoneNumberSlimListParamsFilterSourceConverter))]
public enum PhoneNumberSlimListParamsFilterSource
{
    Ported, Purchased
}

sealed class PhoneNumberSlimListParamsFilterSourceConverter : JsonConverter<PhoneNumberSlimListParamsFilterSource>
{
    public override PhoneNumberSlimListParamsFilterSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ported"=>PhoneNumberSlimListParamsFilterSource.Ported,
            "purchased"=>PhoneNumberSlimListParamsFilterSource.Purchased,
            _ =>(PhoneNumberSlimListParamsFilterSource)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListParamsFilterSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListParamsFilterSource.Ported=>"ported",
            PhoneNumberSlimListParamsFilterSource.Purchased=>"purchased",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by phone number status.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListParamsFilterStatusConverter))]
public enum PhoneNumberSlimListParamsFilterStatus
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

sealed class PhoneNumberSlimListParamsFilterStatusConverter : JsonConverter<PhoneNumberSlimListParamsFilterStatus>
{
    public override PhoneNumberSlimListParamsFilterStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>PhoneNumberSlimListParamsFilterStatus.PurchasePending,
            "purchase-failed"=>PhoneNumberSlimListParamsFilterStatus.PurchaseFailed,
            "port_pending"=>PhoneNumberSlimListParamsFilterStatus.PortPending,
            "active"=>PhoneNumberSlimListParamsFilterStatus.Active,
            "deleted"=>PhoneNumberSlimListParamsFilterStatus.Deleted,
            "port-failed"=>PhoneNumberSlimListParamsFilterStatus.PortFailed,
            "emergency-only"=>PhoneNumberSlimListParamsFilterStatus.EmergencyOnly,
            "ported-out"=>PhoneNumberSlimListParamsFilterStatus.PortedOut,
            "port-out-pending"=>PhoneNumberSlimListParamsFilterStatus.PortOutPending,
            _ =>(PhoneNumberSlimListParamsFilterStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListParamsFilterStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListParamsFilterStatus.PurchasePending=>"purchase-pending",
            PhoneNumberSlimListParamsFilterStatus.PurchaseFailed=>"purchase-failed",
            PhoneNumberSlimListParamsFilterStatus.PortPending=>"port_pending",
            PhoneNumberSlimListParamsFilterStatus.Active=>"active",
            PhoneNumberSlimListParamsFilterStatus.Deleted=>"deleted",
            PhoneNumberSlimListParamsFilterStatus.PortFailed=>"port-failed",
            PhoneNumberSlimListParamsFilterStatus.EmergencyOnly=>"emergency-only",
            PhoneNumberSlimListParamsFilterStatus.PortedOut=>"ported-out",
            PhoneNumberSlimListParamsFilterStatus.PortOutPending=>"port-out-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by voice connection name pattern matching (requires include_connection param).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberSlimListParamsFilterVoiceConnectionName, PhoneNumberSlimListParamsFilterVoiceConnectionNameFromRaw>))]
public sealed record class PhoneNumberSlimListParamsFilterVoiceConnectionName : JsonModel
{
    /// <summary>
    /// Filter contains connection name. Requires at least three characters and the
    /// include_connection param.
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
    /// Filter ends with connection name. Requires at least three characters and the
    /// include_connection param.
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
    /// Filter starts with connection name. Requires at least three characters and
    /// the include_connection param.
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

    public PhoneNumberSlimListParamsFilterVoiceConnectionName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListParamsFilterVoiceConnectionName (
        PhoneNumberSlimListParamsFilterVoiceConnectionName phoneNumberSlimListParamsFilterVoiceConnectionName
    ) : base(phoneNumberSlimListParamsFilterVoiceConnectionName)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListParamsFilterVoiceConnectionName (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListParamsFilterVoiceConnectionName (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSlimListParamsFilterVoiceConnectionNameFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSlimListParamsFilterVoiceConnectionName FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberSlimListParamsFilterVoiceConnectionNameFromRaw : IFromRawJson<PhoneNumberSlimListParamsFilterVoiceConnectionName>
{
    /// <inheritdoc/>
    public PhoneNumberSlimListParamsFilterVoiceConnectionName FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberSlimListParamsFilterVoiceConnectionName.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by usage_payment_method.
/// </summary>
[JsonConverter(typeof(PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethodConverter))]
public enum PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod
{
    PayPerMinute, Channel
}

sealed class PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethodConverter : JsonConverter<PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod>
{
    public override PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod.PayPerMinute,
            "channel"=>PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod.Channel,
            _ =>(PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            PhoneNumberSlimListParamsFilterVoiceUsagePaymentMethod.Channel=>"channel",
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
[JsonConverter(typeof(PhoneNumberSlimListParamsSortConverter))]
public enum PhoneNumberSlimListParamsSort
{
    PurchasedAt, PhoneNumber, ConnectionName, UsagePaymentMethod
}

sealed class PhoneNumberSlimListParamsSortConverter : JsonConverter<PhoneNumberSlimListParamsSort>
{
    public override PhoneNumberSlimListParamsSort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchased_at"=>PhoneNumberSlimListParamsSort.PurchasedAt,
            "phone_number"=>PhoneNumberSlimListParamsSort.PhoneNumber,
            "connection_name"=>PhoneNumberSlimListParamsSort.ConnectionName,
            "usage_payment_method"=>PhoneNumberSlimListParamsSort.UsagePaymentMethod,
            _ =>(PhoneNumberSlimListParamsSort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberSlimListParamsSort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberSlimListParamsSort.PurchasedAt=>"purchased_at",
            PhoneNumberSlimListParamsSort.PhoneNumber=>"phone_number",
            PhoneNumberSlimListParamsSort.ConnectionName=>"connection_name",
            PhoneNumberSlimListParamsSort.UsagePaymentMethod=>"usage_payment_method",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}