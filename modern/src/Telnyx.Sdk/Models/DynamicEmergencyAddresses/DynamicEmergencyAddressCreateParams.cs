using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

/// <summary>
/// Creates a dynamic emergency address, the validated physical location used when
/// provisioning dynamic emergency endpoints.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DynamicEmergencyAddressCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AdministrativeArea {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "administrative_area"
            );
        }
        init { this._rawBodyData.Set("administrative_area", value); }
    }

    public required ApiEnum<string, CountryCode> CountryCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, CountryCode>>(
                "country_code"
            );
        }
        init { this._rawBodyData.Set("country_code", value); }
    }

    public required string HouseNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "house_number"
            );
        }
        init { this._rawBodyData.Set("house_number", value); }
    }

    public required string Locality {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "locality"
            );
        }
        init { this._rawBodyData.Set("locality", value); }
    }

    public required string PostalCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "postal_code"
            );
        }
        init { this._rawBodyData.Set("postal_code", value); }
    }

    public required string StreetName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "street_name"
            );
        }
        init { this._rawBodyData.Set("street_name", value); }
    }

    public string? ExtendedAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("extended_address", value);
        }
    }

    public string? HouseSuffix {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "house_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("house_suffix", value);
        }
    }

    public string? StreetPostDirectional {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "street_post_directional"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("street_post_directional", value);
        }
    }

    public string? StreetPreDirectional {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "street_pre_directional"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("street_pre_directional", value);
        }
    }

    public string? StreetSuffix {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "street_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("street_suffix", value);
        }
    }

    public DynamicEmergencyAddressCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddressCreateParams (
        DynamicEmergencyAddressCreateParams dynamicEmergencyAddressCreateParams
    ) : base(dynamicEmergencyAddressCreateParams)
    {
        this._rawBodyData = new(dynamicEmergencyAddressCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DynamicEmergencyAddressCreateParams (
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
    DynamicEmergencyAddressCreateParams (
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
    public static DynamicEmergencyAddressCreateParams FromRawUnchecked(
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

    public virtual bool Equals(DynamicEmergencyAddressCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/dynamic_emergency_addresses"
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

[JsonConverter(typeof(CountryCodeConverter))]
public enum CountryCode
{
    Us, Ca, Pr
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
            "US"=>CountryCode.Us,
            "CA"=>CountryCode.Ca,
            "PR"=>CountryCode.Pr,
            _ =>(CountryCode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CountryCode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CountryCode.Us=>"US",
            CountryCode.Ca=>"CA",
            CountryCode.Pr=>"PR",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}