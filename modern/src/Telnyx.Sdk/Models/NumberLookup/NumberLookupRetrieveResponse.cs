using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NumberLookup;

[JsonConverter(typeof(JsonModelConverter<NumberLookupRetrieveResponse, NumberLookupRetrieveResponseFromRaw>))]
public sealed record class NumberLookupRetrieveResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public NumberLookupRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupRetrieveResponse (
        NumberLookupRetrieveResponse numberLookupRetrieveResponse
    ) : base(numberLookupRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberLookupRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberLookupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberLookupRetrieveResponseFromRaw : IFromRawJson<NumberLookupRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberLookupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberLookupRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public CallerName? CallerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallerName>(
                "caller_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caller_name", value);
        }
    }

    public Carrier? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Carrier>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// Region code that matches the specific country calling code
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
    /// Unused
    /// </summary>
    public string? Fraud {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fraud"
            );
        }
        init { this._rawData.Set("fraud", value); }
    }

    /// <summary>
    /// Hyphen-separated national number, preceded by the national destination code
    /// (NDC), with a 0 prefix, if an NDC is found
    /// </summary>
    public string? NationalFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "national_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("national_format", value);
        }
    }

    /// <summary>
    /// E164-formatted phone number
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

    public Portability? Portability {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Portability>(
                "portability"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portability", value);
        }
    }

    /// <summary>
    /// Identifies the type of record
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CallerName?.Validate();
        this.Carrier?.Validate();
        _ = this.CountryCode;
        _ = this.Fraud;
        _ = this.NationalFormat;
        _ = this.PhoneNumber;
        this.Portability?.Validate();
        _ = this.RecordType;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CallerName, CallerNameFromRaw>))]
public sealed record class CallerName : JsonModel
{
    /// <summary>
    /// The name of the requested phone number's owner as per the CNAM database
    /// </summary>
    public string? CallerNameValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "caller_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caller_name", value);
        }
    }

    /// <summary>
    /// A caller-name lookup specific error code, expressed as a stringified 5-digit integer
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallerNameValue;
        _ = this.ErrorCode;
    }

    public CallerName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallerName (CallerName callerName) : base(callerName)
    {  }
    #pragma warning restore CS8618

    public CallerName (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallerName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallerNameFromRaw.FromRawUnchecked"/>
    public static CallerName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallerNameFromRaw : IFromRawJson<CallerName>
{
    /// <inheritdoc/>
    public CallerName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallerName.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Carrier, CarrierFromRaw>))]
public sealed record class Carrier : JsonModel
{
    /// <summary>
    /// Unused
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// Region code that matches the specific country calling code if the requested
    /// phone number type is mobile
    /// </summary>
    public string? MobileCountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_country_code", value);
        }
    }

    /// <summary>
    /// National destination code (NDC), with a 0 prefix, if an NDC is found and
    /// the requested phone number type is mobile
    /// </summary>
    public string? MobileNetworkCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_network_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_network_code", value);
        }
    }

    /// <summary>
    /// SPID (Service Provider ID) name, if the requested phone number has been ported;
    /// otherwise, the name of carrier who owns the phone number block
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
    /// If known to Telnyx and applicable, the primary network carrier.
    /// </summary>
    public string? NormalizedCarrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "normalized_carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("normalized_carrier", value);
        }
    }

    /// <summary>
    /// A phone number type that identifies the type of service associated with the
    /// requested phone number
    /// </summary>
    public ApiEnum<string, CarrierType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CarrierType>>(
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
    {
        _ = this.ErrorCode;
        _ = this.MobileCountryCode;
        _ = this.MobileNetworkCode;
        _ = this.Name;
        _ = this.NormalizedCarrier;
        this.Type?.Validate();
    }

    public Carrier ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Carrier (Carrier carrier) : base(carrier)
    {  }
    #pragma warning restore CS8618

    public Carrier (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Carrier (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CarrierFromRaw.FromRawUnchecked"/>
    public static Carrier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CarrierFromRaw : IFromRawJson<Carrier>
{
    /// <inheritdoc/>
    public Carrier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Carrier.FromRawUnchecked(rawData);
}/// <summary>
/// A phone number type that identifies the type of service associated with the requested
/// phone number
/// </summary>
[JsonConverter(typeof(CarrierTypeConverter))]
public enum CarrierType
{
    FixedLine,
    Mobile,
    Voip,
    FixedLineOrMobile,
    TollFree,
    PremiumRate,
    SharedCost,
    PersonalNumber,
    Pager,
    Uan,
    Voicemail,
    Unknown
}sealed class CarrierTypeConverter : JsonConverter<CarrierType>
{
    public override CarrierType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fixed line"=>CarrierType.FixedLine,
            "mobile"=>CarrierType.Mobile,
            "voip"=>CarrierType.Voip,
            "fixed line or mobile"=>CarrierType.FixedLineOrMobile,
            "toll free"=>CarrierType.TollFree,
            "premium rate"=>CarrierType.PremiumRate,
            "shared cost"=>CarrierType.SharedCost,
            "personal number"=>CarrierType.PersonalNumber,
            "pager"=>CarrierType.Pager,
            "uan"=>CarrierType.Uan,
            "voicemail"=>CarrierType.Voicemail,
            "unknown"=>CarrierType.Unknown,
            _ =>(CarrierType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CarrierType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CarrierType.FixedLine=>"fixed line",
            CarrierType.Mobile=>"mobile",
            CarrierType.Voip=>"voip",
            CarrierType.FixedLineOrMobile=>"fixed line or mobile",
            CarrierType.TollFree=>"toll free",
            CarrierType.PremiumRate=>"premium rate",
            CarrierType.SharedCost=>"shared cost",
            CarrierType.PersonalNumber=>"personal number",
            CarrierType.Pager=>"pager",
            CarrierType.Uan=>"uan",
            CarrierType.Voicemail=>"voicemail",
            CarrierType.Unknown=>"unknown",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Portability, PortabilityFromRaw>))]
public sealed record class Portability : JsonModel
{
    /// <summary>
    /// Alternative SPID (Service Provider ID). Often used when a carrier is using
    /// a number from another carrier
    /// </summary>
    public string? Altspid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "altspid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("altspid", value);
        }
    }

    /// <summary>
    /// Alternative service provider name
    /// </summary>
    public string? AltspidCarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "altspid_carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("altspid_carrier_name", value);
        }
    }

    /// <summary>
    /// Alternative service provider type
    /// </summary>
    public string? AltspidCarrierType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "altspid_carrier_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("altspid_carrier_type", value);
        }
    }

    /// <summary>
    /// City name extracted from the locality in the Local Exchange Routing Guide
    /// (LERG) database
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
    /// Type of number
    /// </summary>
    public string? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <summary>
    /// Local Routing Number, if assigned to the requested phone number
    /// </summary>
    public string? Lrn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lrn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lrn", value);
        }
    }

    /// <summary>
    /// Operating Company Name (OCN) as per the Local Exchange Routing Guide (LERG) database
    /// </summary>
    public string? Ocn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ocn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ocn", value);
        }
    }

    /// <summary>
    /// ISO-formatted date when the requested phone number has been ported
    /// </summary>
    public string? PortedDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ported_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ported_date", value);
        }
    }

    /// <summary>
    /// Indicates whether or not the requested phone number has been ported
    /// </summary>
    public ApiEnum<string, PortedStatus>? PortedStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortedStatus>>(
                "ported_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ported_status", value);
        }
    }

    /// <summary>
    /// SPID (Service Provider ID)
    /// </summary>
    public string? Spid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid", value);
        }
    }

    /// <summary>
    /// Service provider name
    /// </summary>
    public string? SpidCarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid_carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid_carrier_name", value);
        }
    }

    /// <summary>
    /// Service provider type
    /// </summary>
    public string? SpidCarrierType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid_carrier_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid_carrier_type", value);
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Altspid;
        _ = this.AltspidCarrierName;
        _ = this.AltspidCarrierType;
        _ = this.City;
        _ = this.LineType;
        _ = this.Lrn;
        _ = this.Ocn;
        _ = this.PortedDate;
        this.PortedStatus?.Validate();
        _ = this.Spid;
        _ = this.SpidCarrierName;
        _ = this.SpidCarrierType;
        _ = this.State;
    }

    public Portability ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Portability (Portability portability) : base(portability)
    {  }
    #pragma warning restore CS8618

    public Portability (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Portability (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortabilityFromRaw.FromRawUnchecked"/>
    public static Portability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortabilityFromRaw : IFromRawJson<Portability>
{
    /// <inheritdoc/>
    public Portability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Portability.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates whether or not the requested phone number has been ported
/// </summary>
[JsonConverter(typeof(PortedStatusConverter))]
public enum PortedStatus
{
    Y, N, Undefined
}sealed class PortedStatusConverter : JsonConverter<PortedStatus>
{
    public override PortedStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Y"=>PortedStatus.Y,
            "N"=>PortedStatus.N,
            ""=>PortedStatus.Undefined,
            _ =>(PortedStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, PortedStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortedStatus.Y=>"Y",
            PortedStatus.N=>"N",
            PortedStatus.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}