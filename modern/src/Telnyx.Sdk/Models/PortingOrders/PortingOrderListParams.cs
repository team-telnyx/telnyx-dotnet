using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

/// <summary>
/// Returns a paginated list of your porting orders. Supports filtering and sorting,
/// and can optionally include the phone numbers attached to each order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PortingOrderListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference],
    /// filter[customer_group_reference], filter[parent_support_key], filter[phone_numbers.country_code],
    /// filter[phone_numbers.carrier_name], filter[misc.type], filter[end_user.admin.entity_name],
    /// filter[end_user.admin.auth_person_name], filter[activation_settings.fast_port_eligible],
    /// filter[activation_settings.foc_datetime_requested][gt], filter[activation_settings.foc_datetime_requested][lt], filter[phone_numbers.phone_number][contains]
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
    /// Include the first 50 phone number objects in the results
    /// </summary>
    public bool? IncludePhoneNumbers {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_phone_numbers", value);
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
    /// Consolidated sort parameter (deepObject style). Originally: sort[value]
    /// </summary>
    public Sort? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Sort>(
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

    public PortingOrderListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderListParams (
        PortingOrderListParams portingOrderListParams
    ) : base(portingOrderListParams)
    {  }
    #pragma warning restore CS8618

    public PortingOrderListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PortingOrderListParams FromRawUnchecked(
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

    public virtual bool Equals(PortingOrderListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/porting_orders"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference],
/// filter[customer_group_reference], filter[parent_support_key], filter[phone_numbers.country_code],
/// filter[phone_numbers.carrier_name], filter[misc.type], filter[end_user.admin.entity_name],
/// filter[end_user.admin.auth_person_name], filter[activation_settings.fast_port_eligible],
/// filter[activation_settings.foc_datetime_requested][gt], filter[activation_settings.foc_datetime_requested][lt], filter[phone_numbers.phone_number][contains]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public FilterActivationSettings? ActivationSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FilterActivationSettings>(
                "activation_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activation_settings", value);
        }
    }

    /// <summary>
    /// Filter results by customer_group_reference
    /// </summary>
    public string? CustomerGroupReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_group_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_group_reference", value);
        }
    }

    /// <summary>
    /// Filter results by customer_reference
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

    public EndUser? EndUser {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EndUser>(
                "end_user"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_user", value);
        }
    }

    public Misc? Misc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Misc>(
                "misc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("misc", value);
        }
    }

    /// <summary>
    /// Filter results by parent_support_key
    /// </summary>
    public string? ParentSupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parent_support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parent_support_key", value);
        }
    }

    public FilterPhoneNumbers? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FilterPhoneNumbers>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_numbers", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ActivationSettings?.Validate();
        _ = this.CustomerGroupReference;
        _ = this.CustomerReference;
        this.EndUser?.Validate();
        this.Misc?.Validate();
        _ = this.ParentSupportKey;
        this.PhoneNumbers?.Validate();
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

[JsonConverter(typeof(JsonModelConverter<FilterActivationSettings, FilterActivationSettingsFromRaw>))]
public sealed record class FilterActivationSettings : JsonModel
{
    /// <summary>
    /// Filter results by fast port eligible
    /// </summary>
    public bool? FastPortEligible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "fast_port_eligible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fast_port_eligible", value);
        }
    }

    /// <summary>
    /// FOC datetime range filtering operations
    /// </summary>
    public FocDatetimeRequested? FocDatetimeRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FocDatetimeRequested>(
                "foc_datetime_requested"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foc_datetime_requested", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FastPortEligible;
        this.FocDatetimeRequested?.Validate();
    }

    public FilterActivationSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterActivationSettings (
        FilterActivationSettings filterActivationSettings
    ) : base(filterActivationSettings)
    {  }
    #pragma warning restore CS8618

    public FilterActivationSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterActivationSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterActivationSettingsFromRaw.FromRawUnchecked"/>
    public static FilterActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterActivationSettingsFromRaw : IFromRawJson<FilterActivationSettings>
{
    /// <inheritdoc/>
    public FilterActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterActivationSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// FOC datetime range filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FocDatetimeRequested, FocDatetimeRequestedFromRaw>))]
public sealed record class FocDatetimeRequested : JsonModel
{
    /// <summary>
    /// Filter results by foc date later than this value
    /// </summary>
    public string? Gt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gt", value);
        }
    }

    /// <summary>
    /// Filter results by foc date earlier than this value
    /// </summary>
    public string? Lt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gt;
        _ = this.Lt;
    }

    public FocDatetimeRequested ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FocDatetimeRequested (
        FocDatetimeRequested focDatetimeRequested
    ) : base(focDatetimeRequested)
    {  }
    #pragma warning restore CS8618

    public FocDatetimeRequested (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FocDatetimeRequested (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FocDatetimeRequestedFromRaw.FromRawUnchecked"/>
    public static FocDatetimeRequested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FocDatetimeRequestedFromRaw : IFromRawJson<FocDatetimeRequested>
{
    /// <inheritdoc/>
    public FocDatetimeRequested FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FocDatetimeRequested.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EndUser, EndUserFromRaw>))]
public sealed record class EndUser : JsonModel
{
    public Admin? Admin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Admin>(
                "admin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("admin", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Admin?.Validate(); }

    public EndUser ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EndUser (EndUser endUser) : base(endUser)
    {  }
    #pragma warning restore CS8618

    public EndUser (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EndUser (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EndUserFromRaw.FromRawUnchecked"/>
    public static EndUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EndUserFromRaw : IFromRawJson<EndUser>
{
    /// <inheritdoc/>
    public EndUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EndUser.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Admin, AdminFromRaw>))]
public sealed record class Admin : JsonModel
{
    /// <summary>
    /// Filter results by authorized person
    /// </summary>
    public string? AuthPersonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "auth_person_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("auth_person_name", value);
        }
    }

    /// <summary>
    /// Filter results by person or company name
    /// </summary>
    public string? EntityName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "entity_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("entity_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthPersonName;
        _ = this.EntityName;
    }

    public Admin ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Admin (Admin admin) : base(admin)
    {  }
    #pragma warning restore CS8618

    public Admin (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Admin (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdminFromRaw.FromRawUnchecked"/>
    public static Admin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdminFromRaw : IFromRawJson<Admin>
{
    /// <inheritdoc/>
    public Admin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Admin.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Misc, MiscFromRaw>))]
public sealed record class Misc : JsonModel
{
    /// <summary>
    /// Filter results by porting order type
    /// </summary>
    public ApiEnum<string, PortingOrderType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingOrderType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Type?.Validate(); }

    public Misc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Misc (Misc misc) : base(misc)
    {  }
    #pragma warning restore CS8618

    public Misc (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Misc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MiscFromRaw.FromRawUnchecked"/>
    public static Misc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MiscFromRaw : IFromRawJson<Misc>
{
    /// <inheritdoc/>
    public Misc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Misc.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FilterPhoneNumbers, FilterPhoneNumbersFromRaw>))]
public sealed record class FilterPhoneNumbers : JsonModel
{
    /// <summary>
    /// Filter results by old service provider
    /// </summary>
    public string? CarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <summary>
    /// Filter results by country ISO 3166-1 alpha-2 code
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Phone number pattern filtering operations
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierName;
        _ = this.CountryCode;
        this.PhoneNumber?.Validate();
    }

    public FilterPhoneNumbers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterPhoneNumbers (FilterPhoneNumbers filterPhoneNumbers) : base(
        filterPhoneNumbers
    )
    {  }
    #pragma warning restore CS8618

    public FilterPhoneNumbers (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterPhoneNumbers (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterPhoneNumbersFromRaw.FromRawUnchecked"/>
    public static FilterPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterPhoneNumbersFromRaw : IFromRawJson<FilterPhoneNumbers>
{
    /// <inheritdoc/>
    public FilterPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterPhoneNumbers.FromRawUnchecked(rawData);
}

/// <summary>
/// Phone number pattern filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// Filter results by full or partial phone_number
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
/// Consolidated sort parameter (deepObject style). Originally: sort[value]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sort, SortFromRaw>))]
public sealed record class Sort : JsonModel
{
    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// created_at in descending order.
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Value?.Validate(); }

    public Sort ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sort (Sort sort) : base(sort)
    {  }
    #pragma warning restore CS8618

    public Sort (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Sort (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SortFromRaw.FromRawUnchecked"/>
    public static Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SortFromRaw : IFromRawJson<Sort>
{
    /// <inheritdoc/>
    public Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Sort.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by created_at
/// in descending order.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    CreatedAt,
    CreatedAtDesc,
    ActivationSettingsFocDatetimeRequested,
    ActivationSettingsFocDatetimeRequestedDesc
}

sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>Value.CreatedAt,
            "-created_at"=>Value.CreatedAtDesc,
            "activation_settings.foc_datetime_requested"=>Value.ActivationSettingsFocDatetimeRequested,
            "-activation_settings.foc_datetime_requested"=>Value.ActivationSettingsFocDatetimeRequestedDesc,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.CreatedAt=>"created_at",
            Value.CreatedAtDesc=>"-created_at",
            Value.ActivationSettingsFocDatetimeRequested=>"activation_settings.foc_datetime_requested",
            Value.ActivationSettingsFocDatetimeRequestedDesc=>"-activation_settings.foc_datetime_requested",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}