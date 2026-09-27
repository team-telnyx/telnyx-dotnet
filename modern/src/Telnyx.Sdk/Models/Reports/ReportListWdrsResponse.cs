using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportListWdrsResponse, ReportListWdrsResponseFromRaw>))]
public sealed record class ReportListWdrsResponse : JsonModel
{
    /// <summary>
    /// WDR id
    /// </summary>
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

    public Cost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cost>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Record created time
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public DownlinkData? DownlinkData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DownlinkData>(
                "downlink_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("downlink_data", value);
        }
    }

    /// <summary>
    /// Session duration in seconds.
    /// </summary>
    public double? DurationSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "duration_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_seconds", value);
        }
    }

    /// <summary>
    /// International mobile subscriber identity.
    /// </summary>
    public string? Imsi {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "imsi"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("imsi", value);
        }
    }

    /// <summary>
    /// Mobile country code.
    /// </summary>
    public string? Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Mobile network code.
    /// </summary>
    public string? Mnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <summary>
    /// Phone number
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

    public Rate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rate>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

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
    /// Sim card unique identifier
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// Sim group unique identifier
    /// </summary>
    public string? SimGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_group_id", value);
        }
    }

    /// <summary>
    /// Defined sim group name
    /// </summary>
    public string? SimGroupName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_group_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_group_name", value);
        }
    }

    public UplinkData? UplinkData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UplinkData>(
                "uplink_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uplink_data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Cost?.Validate();
        _ = this.CreatedAt;
        this.DownlinkData?.Validate();
        _ = this.DurationSeconds;
        _ = this.Imsi;
        _ = this.Mcc;
        _ = this.Mnc;
        _ = this.PhoneNumber;
        this.Rate?.Validate();
        _ = this.RecordType;
        _ = this.SimCardID;
        _ = this.SimGroupID;
        _ = this.SimGroupName;
        this.UplinkData?.Validate();
    }

    public ReportListWdrsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListWdrsResponse (
        ReportListWdrsResponse reportListWdrsResponse
    ) : base(reportListWdrsResponse)
    {  }
    #pragma warning restore CS8618

    public ReportListWdrsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListWdrsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportListWdrsResponseFromRaw.FromRawUnchecked"/>
    public static ReportListWdrsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportListWdrsResponseFromRaw : IFromRawJson<ReportListWdrsResponse>
{
    /// <inheritdoc/>
    public ReportListWdrsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportListWdrsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
{
    /// <summary>
    /// Final cost. Cost is calculated as rate * unit
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Currency of the rate and cost
    /// </summary>
    public ApiEnum<string, CostCurrency>? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CostCurrency>>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public Cost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost (Cost cost) : base(cost)
    {  }
    #pragma warning restore CS8618

    public Cost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cost.FromRawUnchecked(rawData);
}/// <summary>
/// Currency of the rate and cost
/// </summary>
[JsonConverter(typeof(CostCurrencyConverter))]
public enum CostCurrency
{
    Aud, Cad, Eur, Gbp, Usd
}sealed class CostCurrencyConverter : JsonConverter<CostCurrency>
{
    public override CostCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUD"=>CostCurrency.Aud,
            "CAD"=>CostCurrency.Cad,
            "EUR"=>CostCurrency.Eur,
            "GBP"=>CostCurrency.Gbp,
            "USD"=>CostCurrency.Usd,
            _ =>(CostCurrency)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CostCurrency value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CostCurrency.Aud=>"AUD",
            CostCurrency.Cad=>"CAD",
            CostCurrency.Eur=>"EUR",
            CostCurrency.Gbp=>"GBP",
            CostCurrency.Usd=>"USD",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<DownlinkData, DownlinkDataFromRaw>))]
public sealed record class DownlinkData : JsonModel
{
    /// <summary>
    /// Downlink data
    /// </summary>
    public double? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Transmission unit
    /// </summary>
    public ApiEnum<string, Unit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Unit>>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Unit?.Validate();
    }

    public DownlinkData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DownlinkData (DownlinkData downlinkData) : base(downlinkData)
    {  }
    #pragma warning restore CS8618

    public DownlinkData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DownlinkData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DownlinkDataFromRaw.FromRawUnchecked"/>
    public static DownlinkData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DownlinkDataFromRaw : IFromRawJson<DownlinkData>
{
    /// <inheritdoc/>
    public DownlinkData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DownlinkData.FromRawUnchecked(rawData);
}/// <summary>
/// Transmission unit
/// </summary>
[JsonConverter(typeof(UnitConverter))]
public enum Unit
{
    B, KB, MB
}sealed class UnitConverter : JsonConverter<Unit>
{
    public override Unit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "B"=>Unit.B, "KB"=>Unit.KB, "MB"=>Unit.MB, _ =>(Unit)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Unit value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Unit.B=>"B",
            Unit.KB=>"KB",
            Unit.MB=>"MB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Rate, RateFromRaw>))]
public sealed record class Rate : JsonModel
{
    /// <summary>
    /// Rate from which cost is calculated
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Currency of the rate and cost
    /// </summary>
    public ApiEnum<string, RateCurrency>? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RateCurrency>>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public Rate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rate (Rate rate) : base(rate)
    {  }
    #pragma warning restore CS8618

    public Rate (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Rate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RateFromRaw.FromRawUnchecked"/>
    public static Rate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RateFromRaw : IFromRawJson<Rate>
{
    /// <inheritdoc/>
    public Rate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Rate.FromRawUnchecked(rawData);
}/// <summary>
/// Currency of the rate and cost
/// </summary>
[JsonConverter(typeof(RateCurrencyConverter))]
public enum RateCurrency
{
    Aud, Cad, Eur, Gbp, Usd
}sealed class RateCurrencyConverter : JsonConverter<RateCurrency>
{
    public override RateCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUD"=>RateCurrency.Aud,
            "CAD"=>RateCurrency.Cad,
            "EUR"=>RateCurrency.Eur,
            "GBP"=>RateCurrency.Gbp,
            "USD"=>RateCurrency.Usd,
            _ =>(RateCurrency)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RateCurrency value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RateCurrency.Aud=>"AUD",
            RateCurrency.Cad=>"CAD",
            RateCurrency.Eur=>"EUR",
            RateCurrency.Gbp=>"GBP",
            RateCurrency.Usd=>"USD",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<UplinkData, UplinkDataFromRaw>))]
public sealed record class UplinkData : JsonModel
{
    /// <summary>
    /// Uplink data
    /// </summary>
    public double? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Transmission unit
    /// </summary>
    public ApiEnum<string, UplinkDataUnit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UplinkDataUnit>>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Unit?.Validate();
    }

    public UplinkData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UplinkData (UplinkData uplinkData) : base(uplinkData)
    {  }
    #pragma warning restore CS8618

    public UplinkData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UplinkData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UplinkDataFromRaw.FromRawUnchecked"/>
    public static UplinkData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UplinkDataFromRaw : IFromRawJson<UplinkData>
{
    /// <inheritdoc/>
    public UplinkData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UplinkData.FromRawUnchecked(rawData);
}/// <summary>
/// Transmission unit
/// </summary>
[JsonConverter(typeof(UplinkDataUnitConverter))]
public enum UplinkDataUnit
{
    B, KB, MB
}sealed class UplinkDataUnitConverter : JsonConverter<UplinkDataUnit>
{
    public override UplinkDataUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "B"=>UplinkDataUnit.B,
            "KB"=>UplinkDataUnit.KB,
            "MB"=>UplinkDataUnit.MB,
            _ =>(UplinkDataUnit)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UplinkDataUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UplinkDataUnit.B=>"B",
            UplinkDataUnit.KB=>"KB",
            UplinkDataUnit.MB=>"MB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}