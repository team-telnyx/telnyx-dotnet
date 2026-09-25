using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Addresses;

/// <summary>
/// Returns a paginated list of the addresses on your account, with support for filtering
/// and sorting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AddressListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference][eq],
    /// filter[customer_reference][contains], filter[used_as_emergency], filter[street_address][contains], filter[address_book][eq]
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
    /// Specifies the sort order for results. By default sorting direction is ascending.
    /// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
    /// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;street_address&lt;/code&gt;:
    /// sorts the result by the     &lt;code&gt;street_address&lt;/code&gt; field
    /// in ascending order.   &lt;/li&gt;
    ///
    /// <para>  &lt;li&gt;     &lt;code&gt;-street_address&lt;/code&gt;: sorts the
    /// result by the     &lt;code&gt;street_address&lt;/code&gt; field in descending
    /// order.   &lt;/li&gt; &lt;/ul&gt; &lt;br/&gt; If not given, results are sorted
    /// by &lt;code&gt;created_at&lt;/code&gt; in descending order.</para>
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

    public AddressListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressListParams (AddressListParams addressListParams) : base(
        addressListParams
    )
    {  }
    #pragma warning restore CS8618

    public AddressListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AddressListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AddressListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/addresses"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference][eq],
/// filter[customer_reference][contains], filter[used_as_emergency], filter[street_address][contains], filter[address_book][eq]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public AddressBook? AddressBook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AddressBook>(
                "address_book"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address_book", value);
        }
    }

    /// <summary>
    /// If present, addresses with &lt;code&gt;customer_reference&lt;/code&gt; containing
    /// the given value will be returned. Matching is not case-sensitive.
    /// </summary>
    public CustomerReference? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerReference>(
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

    public StreetAddress? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StreetAddress>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <summary>
    /// If set as 'true', only addresses used as the emergency address for at least
    /// one active phone-number will be returned. When set to 'false', the opposite
    /// happens: only addresses not used as the emergency address from phone-numbers
    /// will be returned.
    /// </summary>
    public string? UsedAsEmergency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "used_as_emergency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("used_as_emergency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AddressBook?.Validate();
        this.CustomerReference?.Validate();
        this.StreetAddress?.Validate();
        _ = this.UsedAsEmergency;
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AddressBook, AddressBookFromRaw>))]
public sealed record class AddressBook : JsonModel
{
    /// <summary>
    /// If present, only returns results with the &lt;code&gt;address_book&lt;/code&gt;
    /// flag equal to the given value.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public AddressBook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressBook (AddressBook addressBook) : base(addressBook)
    {  }
    #pragma warning restore CS8618

    public AddressBook (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressBook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressBookFromRaw.FromRawUnchecked"/>
    public static AddressBook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AddressBookFromRaw : IFromRawJson<AddressBook>
{
    /// <inheritdoc/>
    public AddressBook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AddressBook.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, addresses with &lt;code&gt;customer_reference&lt;/code&gt; containing
/// the given value will be returned. Matching is not case-sensitive.
/// </summary>
[JsonConverter(typeof(CustomerReferenceConverter))]
public record class CustomerReference : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public CustomerReference (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerReference (
        CustomerReferenceMatcher value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerReference (JsonElement element)
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
/// type <see cref="CustomerReferenceMatcher"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMatcher(out var value)) {
///     // `value` is of type `CustomerReferenceMatcher`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMatcher(
        [NotNullWhen(true)] out CustomerReferenceMatcher? value
    )
    {
        value =this.Value as CustomerReferenceMatcher ;
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
///     (CustomerReferenceMatcher value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<CustomerReferenceMatcher> matcher
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case CustomerReferenceMatcher value:
                matcher(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CustomerReference");

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
///     (CustomerReferenceMatcher value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<CustomerReferenceMatcher, T> matcher
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            CustomerReferenceMatcher value=>matcher(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CustomerReference")
        } ;
    }

    public static implicit operator CustomerReference (
        string value
    )=> new(value) ;

    public static implicit operator CustomerReference (
        CustomerReferenceMatcher value
    )=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of CustomerReference");
        }
        this.Switch((_) => {}, (matcher) => matcher.Validate());
    }

    public virtual bool Equals(CustomerReference? other)
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
        { string _=>0, CustomerReferenceMatcher _=>1, _ =>-1 } ;
    }
}

sealed class CustomerReferenceConverter : JsonConverter<CustomerReference>
{
    public override CustomerReference? Read(
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
            var deserialized = JsonSerializer.Deserialize<CustomerReferenceMatcher>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerReference value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<CustomerReferenceMatcher, CustomerReferenceMatcherFromRaw>))]
public sealed record class CustomerReferenceMatcher : JsonModel
{
    /// <summary>
    /// Partial match for customer_reference. Matching is not case-sensitive.
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
    /// Exact match for customer_reference.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.Eq;
    }

    public CustomerReferenceMatcher ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerReferenceMatcher (
        CustomerReferenceMatcher customerReferenceMatcher
    ) : base(customerReferenceMatcher)
    {  }
    #pragma warning restore CS8618

    public CustomerReferenceMatcher (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerReferenceMatcher (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerReferenceMatcherFromRaw.FromRawUnchecked"/>
    public static CustomerReferenceMatcher FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerReferenceMatcherFromRaw : IFromRawJson<CustomerReferenceMatcher>
{
    /// <inheritdoc/>
    public CustomerReferenceMatcher FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerReferenceMatcher.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StreetAddress, StreetAddressFromRaw>))]
public sealed record class StreetAddress : JsonModel
{
    /// <summary>
    /// If present, addresses with &lt;code&gt;street_address&lt;/code&gt; containing
    /// the given value will be returned. Matching is not case-sensitive. Requires
    /// at least three characters.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public StreetAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreetAddress (StreetAddress streetAddress) : base(streetAddress)
    {  }
    #pragma warning restore CS8618

    public StreetAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StreetAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StreetAddressFromRaw.FromRawUnchecked"/>
    public static StreetAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StreetAddressFromRaw : IFromRawJson<StreetAddress>
{
    /// <inheritdoc/>
    public StreetAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StreetAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. By default sorting direction is ascending.
/// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
/// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;street_address&lt;/code&gt;:
/// sorts the result by the     &lt;code&gt;street_address&lt;/code&gt; field in
/// ascending order.   &lt;/li&gt;
///
/// <para>  &lt;li&gt;     &lt;code&gt;-street_address&lt;/code&gt;: sorts the result
/// by the     &lt;code&gt;street_address&lt;/code&gt; field in descending order.
///   &lt;/li&gt; &lt;/ul&gt; &lt;br/&gt; If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
/// in descending order.</para>
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt, FirstName, LastName, BusinessName, StreetAddress
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
            "created_at"=>Sort.CreatedAt,
            "first_name"=>Sort.FirstName,
            "last_name"=>Sort.LastName,
            "business_name"=>Sort.BusinessName,
            "street_address"=>Sort.StreetAddress,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.FirstName=>"first_name",
            Sort.LastName=>"last_name",
            Sort.BusinessName=>"business_name",
            Sort.StreetAddress=>"street_address",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}