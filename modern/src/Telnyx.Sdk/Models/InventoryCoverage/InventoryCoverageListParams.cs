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

namespace Telnyx.Sdk.Models.InventoryCoverage;

/// <summary>
/// Creates an inventory coverage request. If locality, npa or national_destination_code
/// is used in groupBy, and no region or locality filters are used, the whole paginated
/// set is returned.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InventoryCoverageListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[npa],
    /// filter[nxx], filter[administrative_area], filter[phone_number_type], filter[country_code],
    /// filter[count], filter[features], filter[groupBy]
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

    public InventoryCoverageListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InventoryCoverageListParams (
        InventoryCoverageListParams inventoryCoverageListParams
    ) : base(inventoryCoverageListParams)
    {  }
    #pragma warning restore CS8618

    public InventoryCoverageListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InventoryCoverageListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InventoryCoverageListParams FromRawUnchecked(
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

    public virtual bool Equals(InventoryCoverageListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/inventory_coverage"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[npa], filter[nxx],
/// filter[administrative_area], filter[phone_number_type], filter[country_code],
/// filter[count], filter[features], filter[groupBy]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by administrative area
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
    /// Include count in the result
    /// </summary>
    public bool? Count {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// Filter by country. Defaults to US
    /// </summary>
    public ApiEnum<string, CountryCode>? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CountryCode>>(
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
    /// Filter if the phone number should be used for voice, fax, mms, sms, emergency.
    /// Returns features in the response when used.
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
    /// Filter to group results
    /// </summary>
    public ApiEnum<string, GroupBy>? GroupBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GroupBy>>(
                "groupBy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("groupBy", value);
        }
    }

    /// <summary>
    /// Filter by npa
    /// </summary>
    public long? Npa {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "npa"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("npa", value);
        }
    }

    /// <summary>
    /// Filter by nxx
    /// </summary>
    public long? Nxx {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "nxx"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("nxx", value);
        }
    }

    /// <summary>
    /// Filter by phone number type
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.Count;
        this.CountryCode?.Validate();
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        this.GroupBy?.Validate();
        _ = this.Npa;
        _ = this.Nxx;
        this.PhoneNumberType?.Validate();
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

/// <summary>
/// Filter by country. Defaults to US
/// </summary>
[JsonConverter(typeof(CountryCodeConverter))]
public enum CountryCode
{
    At,
    Au,
    Be,
    Bg,
    Ca,
    Ch,
    Cn,
    Cy,
    Cz,
    De,
    Dk,
    Ee,
    Es,
    Fi,
    Fr,
    GB,
    Gr,
    Hu,
    Hr,
    Ie,
    It,
    Lt,
    Lu,
    Lv,
    Nl,
    Nz,
    Mx,
    No,
    Pl,
    Pt,
    Ro,
    Se,
    Sg,
    Si,
    Sk,
    Us
}

sealed class CountryCodeConverter : JsonConverter<CountryCode>
{
    public override CountryCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AT"=>CountryCode.At,
            "AU"=>CountryCode.Au,
            "BE"=>CountryCode.Be,
            "BG"=>CountryCode.Bg,
            "CA"=>CountryCode.Ca,
            "CH"=>CountryCode.Ch,
            "CN"=>CountryCode.Cn,
            "CY"=>CountryCode.Cy,
            "CZ"=>CountryCode.Cz,
            "DE"=>CountryCode.De,
            "DK"=>CountryCode.Dk,
            "EE"=>CountryCode.Ee,
            "ES"=>CountryCode.Es,
            "FI"=>CountryCode.Fi,
            "FR"=>CountryCode.Fr,
            "GB"=>CountryCode.GB,
            "GR"=>CountryCode.Gr,
            "HU"=>CountryCode.Hu,
            "HR"=>CountryCode.Hr,
            "IE"=>CountryCode.Ie,
            "IT"=>CountryCode.It,
            "LT"=>CountryCode.Lt,
            "LU"=>CountryCode.Lu,
            "LV"=>CountryCode.Lv,
            "NL"=>CountryCode.Nl,
            "NZ"=>CountryCode.Nz,
            "MX"=>CountryCode.Mx,
            "NO"=>CountryCode.No,
            "PL"=>CountryCode.Pl,
            "PT"=>CountryCode.Pt,
            "RO"=>CountryCode.Ro,
            "SE"=>CountryCode.Se,
            "SG"=>CountryCode.Sg,
            "SI"=>CountryCode.Si,
            "SK"=>CountryCode.Sk,
            "US"=>CountryCode.Us,
            _ =>(CountryCode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CountryCode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CountryCode.At=>"AT",
            CountryCode.Au=>"AU",
            CountryCode.Be=>"BE",
            CountryCode.Bg=>"BG",
            CountryCode.Ca=>"CA",
            CountryCode.Ch=>"CH",
            CountryCode.Cn=>"CN",
            CountryCode.Cy=>"CY",
            CountryCode.Cz=>"CZ",
            CountryCode.De=>"DE",
            CountryCode.Dk=>"DK",
            CountryCode.Ee=>"EE",
            CountryCode.Es=>"ES",
            CountryCode.Fi=>"FI",
            CountryCode.Fr=>"FR",
            CountryCode.GB=>"GB",
            CountryCode.Gr=>"GR",
            CountryCode.Hu=>"HU",
            CountryCode.Hr=>"HR",
            CountryCode.Ie=>"IE",
            CountryCode.It=>"IT",
            CountryCode.Lt=>"LT",
            CountryCode.Lu=>"LU",
            CountryCode.Lv=>"LV",
            CountryCode.Nl=>"NL",
            CountryCode.Nz=>"NZ",
            CountryCode.Mx=>"MX",
            CountryCode.No=>"NO",
            CountryCode.Pl=>"PL",
            CountryCode.Pt=>"PT",
            CountryCode.Ro=>"RO",
            CountryCode.Se=>"SE",
            CountryCode.Sg=>"SG",
            CountryCode.Si=>"SI",
            CountryCode.Sk=>"SK",
            CountryCode.Us=>"US",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(FeatureConverter))]
public enum Feature
{
    Sms, Mms, Voice, Fax, Emergency
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
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter to group results
/// </summary>
[JsonConverter(typeof(GroupByConverter))]
public enum GroupBy
{
    Locality, Npa, NationalDestinationCode
}

sealed class GroupByConverter : JsonConverter<GroupBy>
{
    public override GroupBy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "locality"=>GroupBy.Locality,
            "npa"=>GroupBy.Npa,
            "national_destination_code"=>GroupBy.NationalDestinationCode,
            _ =>(GroupBy)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, GroupBy value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            GroupBy.Locality=>"locality",
            GroupBy.Npa=>"npa",
            GroupBy.NationalDestinationCode=>"national_destination_code",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by phone number type
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local, TollFree, National, Mobile, Landline, SharedCost
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
            "national"=>PhoneNumberType.National,
            "mobile"=>PhoneNumberType.Mobile,
            "landline"=>PhoneNumberType.Landline,
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
            PhoneNumberType.National=>"national",
            PhoneNumberType.Mobile=>"mobile",
            PhoneNumberType.Landline=>"landline",
            PhoneNumberType.SharedCost=>"shared_cost",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}