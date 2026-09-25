using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Reports.MdrUsageReports;

namespace Telnyx.Sdk.Models.Reports;

[JsonConverter(typeof(JsonModelConverter<ReportListMdrsResponse, ReportListMdrsResponseFromRaw>))]
public sealed record class ReportListMdrsResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ReportingPaginationMeta77109e5d17? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReportingPaginationMeta77109e5d17>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public ReportListMdrsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListMdrsResponse (
        ReportListMdrsResponse reportListMdrsResponse
    ) : base(reportListMdrsResponse)
    {  }
    #pragma warning restore CS8618

    public ReportListMdrsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListMdrsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReportListMdrsResponseFromRaw.FromRawUnchecked"/>
    public static ReportListMdrsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReportListMdrsResponseFromRaw : IFromRawJson<ReportListMdrsResponse>
{
    /// <inheritdoc/>
    public ReportListMdrsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReportListMdrsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Id of message detail record
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

    /// <summary>
    /// The destination number for a call, or the callee
    /// </summary>
    public string? Cld {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cld"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cld", value);
        }
    }

    /// <summary>
    /// The number associated with the person initiating the call, or the caller
    /// </summary>
    public string? Cli {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cli"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cli", value);
        }
    }

    /// <summary>
    /// Final cost. Cost is calculated as rate * parts
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Message sent time
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

    /// <summary>
    /// Currency of the rate and cost
    /// </summary>
    public ApiEnum<string, Currency>? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>(
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

    /// <summary>
    /// Direction of message - inbound or outbound.
    /// </summary>
    public string? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// Type of message
    /// </summary>
    public ApiEnum<string, DataMessageType>? MessageType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataMessageType>>(
                "message_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message_type", value);
        }
    }

    /// <summary>
    /// Number of parts this message has. Max number of character is 160. If message
    /// contains more characters then that it will be broken down in multiple parts
    /// </summary>
    public double? Parts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "parts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parts", value);
        }
    }

    /// <summary>
    /// Configured profile name. New profiles can be created and configured on Telnyx portal
    /// </summary>
    public string? ProfileName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_name", value);
        }
    }

    /// <summary>
    /// Rate applied to the message
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Message status
    /// </summary>
    public ApiEnum<string, DataStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Cld;
        _ = this.Cli;
        _ = this.Cost;
        _ = this.CreatedAt;
        this.Currency?.Validate();
        _ = this.Direction;
        this.MessageType?.Validate();
        _ = this.Parts;
        _ = this.ProfileName;
        _ = this.Rate;
        _ = this.RecordType;
        this.Status?.Validate();
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
}/// <summary>
/// Currency of the rate and cost
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    Aud, Cad, Eur, Gbp, Usd
}sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUD"=>Currency.Aud,
            "CAD"=>Currency.Cad,
            "EUR"=>Currency.Eur,
            "GBP"=>Currency.Gbp,
            "USD"=>Currency.Usd,
            _ =>(Currency)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Currency value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Currency.Aud=>"AUD",
            Currency.Cad=>"CAD",
            Currency.Eur=>"EUR",
            Currency.Gbp=>"GBP",
            Currency.Usd=>"USD",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Type of message
/// </summary>
[JsonConverter(typeof(DataMessageTypeConverter))]
public enum DataMessageType
{
    Sms, Mms
}sealed class DataMessageTypeConverter : JsonConverter<DataMessageType>
{
    public override DataMessageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>DataMessageType.Sms,
            "MMS"=>DataMessageType.Mms,
            _ =>(DataMessageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataMessageType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataMessageType.Sms=>"SMS",
            DataMessageType.Mms=>"MMS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Message status
/// </summary>
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    GwTimeout, Delivered, DlrUnconfirmed, DlrTimeout, Received, GwReject, Failed
}sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GW_TIMEOUT"=>DataStatus.GwTimeout,
            "DELIVERED"=>DataStatus.Delivered,
            "DLR_UNCONFIRMED"=>DataStatus.DlrUnconfirmed,
            "DLR_TIMEOUT"=>DataStatus.DlrTimeout,
            "RECEIVED"=>DataStatus.Received,
            "GW_REJECT"=>DataStatus.GwReject,
            "FAILED"=>DataStatus.Failed,
            _ =>(DataStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DataStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataStatus.GwTimeout=>"GW_TIMEOUT",
            DataStatus.Delivered=>"DELIVERED",
            DataStatus.DlrUnconfirmed=>"DLR_UNCONFIRMED",
            DataStatus.DlrTimeout=>"DLR_TIMEOUT",
            DataStatus.Received=>"RECEIVED",
            DataStatus.GwReject=>"GW_REJECT",
            DataStatus.Failed=>"FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}