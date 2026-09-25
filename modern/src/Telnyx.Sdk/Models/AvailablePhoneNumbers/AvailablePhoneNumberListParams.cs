using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AvailablePhoneNumbers;

/// <summary>
/// Searches the Telnyx inventory for available phone numbers. Filters support number
/// patterns, location, number type, features, reservability, and other inventory
/// constraints; the response includes matching numbers and search metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AvailablePhoneNumberListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[phone_number],
    /// filter[locality], filter[administrative_area], filter[country_code], filter[national_destination_code],
    /// filter[rate_center], filter[phone_number_type], filter[features], filter[limit],
    /// filter[best_effort], filter[quickship], filter[reservable], filter[exclude_held_numbers]
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

    public AvailablePhoneNumberListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailablePhoneNumberListParams (
        AvailablePhoneNumberListParams availablePhoneNumberListParams
    ) : base(availablePhoneNumberListParams)
    {  }
    #pragma warning restore CS8618

    public AvailablePhoneNumberListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailablePhoneNumberListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AvailablePhoneNumberListParams FromRawUnchecked(
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

    public virtual bool Equals(AvailablePhoneNumberListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/available_phone_numbers"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[phone_number],
/// filter[locality], filter[administrative_area], filter[country_code], filter[national_destination_code],
/// filter[rate_center], filter[phone_number_type], filter[features], filter[limit],
/// filter[best_effort], filter[quickship], filter[reservable], filter[exclude_held_numbers]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Find numbers in a particular US state or CA province.
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
    /// Filter to determine if best effort results should be included. Only available
    /// in USA/CANADA.
    /// </summary>
    public bool? BestEffort {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "best_effort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("best_effort", value);
        }
    }

    /// <summary>
    /// Filter phone numbers by country.
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
    /// Filter phone numbers with specific features.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Feature>>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Feature>>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Feature>>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Limits the number of results.
    /// </summary>
    public long? Limit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter phone numbers by city.
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
    /// Filter by the national destination code of the number.
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
    /// Filter phone numbers by pattern matching.
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
    /// Filter phone numbers by number type.
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
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
    /// Filter phone numbers by rate center. This filter is only applicable to USA
    /// and Canada numbers.
    /// </summary>
    public string? RateCenter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate_center"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate_center", value);
        }
    }

    /// <summary>
    /// Filter to ensure only numbers that can be reserved are included in the results.
    /// </summary>
    public bool? Reservable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reservable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reservable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.BestEffort;
        _ = this.CountryCode;
        _ = this.ExcludeHeldNumbers;
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Locality;
        _ = this.NationalDestinationCode;
        this.PhoneNumber?.Validate();
        this.PhoneNumberType?.Validate();
        _ = this.Quickship;
        _ = this.RateCenter;
        _ = this.Reservable;
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

[JsonConverter(typeof(FeatureConverter))]
public enum Feature
{
    Sms, Mms, Voice, Fax, Emergency, HDVoice, InternationalSms, LocalCalling
}

sealed class FeatureConverter : JsonConverter<Feature>
{
    public override Feature Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>Feature.Sms,
            "mms"=>Feature.Mms,
            "voice"=>Feature.Voice,
            "fax"=>Feature.Fax,
            "emergency"=>Feature.Emergency,
            "hd_voice"=>Feature.HDVoice,
            "international_sms"=>Feature.InternationalSms,
            "local_calling"=>Feature.LocalCalling,
            _ =>(Feature)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Feature value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Feature.Sms=>"sms",
            Feature.Mms=>"mms",
            Feature.Voice=>"voice",
            Feature.Fax=>"fax",
            Feature.Emergency=>"emergency",
            Feature.HDVoice=>"hd_voice",
            Feature.InternationalSms=>"international_sms",
            Feature.LocalCalling=>"local_calling",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter phone numbers by pattern matching.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// Filter numbers containing a pattern (excludes NDC if used with `national_destination_code` filter).
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
    /// Filter numbers ending with a pattern (excludes NDC if used with `national_destination_code` filter).
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
    /// Filter numbers starting with a pattern (excludes NDC if used with `national_destination_code` filter).
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
/// Filter phone numbers by number type.
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local, TollFree, Mobile, National, SharedCost
}

sealed class PhoneNumberTypeConverter : JsonConverter<PhoneNumberType>
{
    public override PhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberType.Local,
            "toll_free"=>PhoneNumberType.TollFree,
            "mobile"=>PhoneNumberType.Mobile,
            "national"=>PhoneNumberType.National,
            "shared_cost"=>PhoneNumberType.SharedCost,
            _ =>(PhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberType.Local=>"local",
            PhoneNumberType.TollFree=>"toll_free",
            PhoneNumberType.Mobile=>"mobile",
            PhoneNumberType.National=>"national",
            PhoneNumberType.SharedCost=>"shared_cost",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}