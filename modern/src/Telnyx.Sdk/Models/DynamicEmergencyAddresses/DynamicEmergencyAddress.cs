using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.DynamicEmergencyAddresses;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyAddress, DynamicEmergencyAddressFromRaw>))]
public sealed record class DynamicEmergencyAddress : JsonModel
{
    public required string AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "administrative_area"
            );
        }
        init { this._rawData.Set("administrative_area", value); }
    }

    public required ApiEnum<string, DynamicEmergencyAddressCountryCode> CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DynamicEmergencyAddressCountryCode>>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    public required string HouseNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "house_number"
            );
        }
        init { this._rawData.Set("house_number", value); }
    }

    public required string Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "locality"
            );
        }
        init { this._rawData.Set("locality", value); }
    }

    public required string PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "postal_code"
            );
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public required string StreetName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "street_name"
            );
        }
        init { this._rawData.Set("street_name", value); }
    }

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
    /// ISO 8601 formatted date of when the resource was created
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extended_address", value);
        }
    }

    public string? HouseSuffix {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "house_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("house_suffix", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Unique location reference string to be used in SIP INVITE from / p-asserted headers.
    /// </summary>
    public string? SipGeolocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_geolocation_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_geolocation_id", value);
        }
    }

    /// <summary>
    /// Status of dynamic emergency address
    /// </summary>
    public ApiEnum<string, DynamicEmergencyAddressStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DynamicEmergencyAddressStatus>>(
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

    public string? StreetPostDirectional {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_post_directional"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_post_directional", value);
        }
    }

    public string? StreetPreDirectional {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_pre_directional"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_pre_directional", value);
        }
    }

    public string? StreetSuffix {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_suffix", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the resource was last updated
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        this.CountryCode.Validate();
        _ = this.HouseNumber;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.StreetName;
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ExtendedAddress;
        _ = this.HouseSuffix;
        _ = this.RecordType;
        _ = this.SipGeolocationID;
        this.Status?.Validate();
        _ = this.StreetPostDirectional;
        _ = this.StreetPreDirectional;
        _ = this.StreetSuffix;
        _ = this.UpdatedAt;
    }

    public DynamicEmergencyAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyAddress (
        DynamicEmergencyAddress dynamicEmergencyAddress
    ) : base(dynamicEmergencyAddress)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyAddress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyAddressFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyAddressFromRaw : IFromRawJson<DynamicEmergencyAddress>
{
    /// <inheritdoc/>
    public DynamicEmergencyAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyAddress.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DynamicEmergencyAddressCountryCodeConverter))]
public enum DynamicEmergencyAddressCountryCode
{
    Us, Ca, Pr
}sealed class DynamicEmergencyAddressCountryCodeConverter : JsonConverter<DynamicEmergencyAddressCountryCode>
{
    public override DynamicEmergencyAddressCountryCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>DynamicEmergencyAddressCountryCode.Us,
            "CA"=>DynamicEmergencyAddressCountryCode.Ca,
            "PR"=>DynamicEmergencyAddressCountryCode.Pr,
            _ =>(DynamicEmergencyAddressCountryCode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DynamicEmergencyAddressCountryCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DynamicEmergencyAddressCountryCode.Us=>"US",
            DynamicEmergencyAddressCountryCode.Ca=>"CA",
            DynamicEmergencyAddressCountryCode.Pr=>"PR",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of dynamic emergency address
/// </summary>
[JsonConverter(typeof(DynamicEmergencyAddressStatusConverter))]
public enum DynamicEmergencyAddressStatus
{
    Pending, Activated, Rejected
}sealed class DynamicEmergencyAddressStatusConverter : JsonConverter<DynamicEmergencyAddressStatus>
{
    public override DynamicEmergencyAddressStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>DynamicEmergencyAddressStatus.Pending,
            "activated"=>DynamicEmergencyAddressStatus.Activated,
            "rejected"=>DynamicEmergencyAddressStatus.Rejected,
            _ =>(DynamicEmergencyAddressStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DynamicEmergencyAddressStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DynamicEmergencyAddressStatus.Pending=>"pending",
            DynamicEmergencyAddressStatus.Activated=>"activated",
            DynamicEmergencyAddressStatus.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}