using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Reports.CdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<CdrUsageReportFetchSyncResponse, CdrUsageReportFetchSyncResponseFromRaw>))]
public sealed record class CdrUsageReportFetchSyncResponse : JsonModel
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

    public CdrUsageReportFetchSyncResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CdrUsageReportFetchSyncResponse (
        CdrUsageReportFetchSyncResponse cdrUsageReportFetchSyncResponse
    ) : base(cdrUsageReportFetchSyncResponse)
    {  }
    #pragma warning restore CS8618

    public CdrUsageReportFetchSyncResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CdrUsageReportFetchSyncResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CdrUsageReportFetchSyncResponseFromRaw.FromRawUnchecked"/>
    public static CdrUsageReportFetchSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CdrUsageReportFetchSyncResponseFromRaw : IFromRawJson<CdrUsageReportFetchSyncResponse>
{
    /// <inheritdoc/>
    public CdrUsageReportFetchSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CdrUsageReportFetchSyncResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Identifies the resource
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

    public ApiEnum<string, DataAggregationType>? AggregationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataAggregationType>>(
                "aggregation_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("aggregation_type", value);
        }
    }

    public IReadOnlyList<long>? Connections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>(
                "connections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "connections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public System::DateTimeOffset? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    public ApiEnum<string, DataProductBreakdown>? ProductBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataProductBreakdown>>(
                "product_breakdown"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_breakdown", value);
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

    public string? ReportUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "report_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("report_url", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "result",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public System::DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
        _ = this.ID;
        this.AggregationType?.Validate();
        _ = this.Connections;
        _ = this.CreatedAt;
        _ = this.EndTime;
        this.ProductBreakdown?.Validate();
        _ = this.RecordType;
        _ = this.ReportUrl;
        _ = this.Result;
        _ = this.StartTime;
        this.Status?.Validate();
        _ = this.UpdatedAt;
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
}[JsonConverter(typeof(DataAggregationTypeConverter))]
public enum DataAggregationType
{
    NoAggregation, Connection, Tag, BillingGroup
}sealed class DataAggregationTypeConverter : JsonConverter<DataAggregationType>
{
    public override DataAggregationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_AGGREGATION"=>DataAggregationType.NoAggregation,
            "CONNECTION"=>DataAggregationType.Connection,
            "TAG"=>DataAggregationType.Tag,
            "BILLING_GROUP"=>DataAggregationType.BillingGroup,
            _ =>(DataAggregationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataAggregationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataAggregationType.NoAggregation=>"NO_AGGREGATION",
            DataAggregationType.Connection=>"CONNECTION",
            DataAggregationType.Tag=>"TAG",
            DataAggregationType.BillingGroup=>"BILLING_GROUP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(DataProductBreakdownConverter))]
public enum DataProductBreakdown
{
    NoBreakdown, DidVsTollFree, Country, DidVsTollFreePerCountry
}sealed class DataProductBreakdownConverter : JsonConverter<DataProductBreakdown>
{
    public override DataProductBreakdown Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_BREAKDOWN"=>DataProductBreakdown.NoBreakdown,
            "DID_VS_TOLL_FREE"=>DataProductBreakdown.DidVsTollFree,
            "COUNTRY"=>DataProductBreakdown.Country,
            "DID_VS_TOLL_FREE_PER_COUNTRY"=>DataProductBreakdown.DidVsTollFreePerCountry,
            _ =>(DataProductBreakdown)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataProductBreakdown value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataProductBreakdown.NoBreakdown=>"NO_BREAKDOWN",
            DataProductBreakdown.DidVsTollFree=>"DID_VS_TOLL_FREE",
            DataProductBreakdown.Country=>"COUNTRY",
            DataProductBreakdown.DidVsTollFreePerCountry=>"DID_VS_TOLL_FREE_PER_COUNTRY",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Complete, Failed, Expired
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING"=>Status.Pending,
            "COMPLETE"=>Status.Complete,
            "FAILED"=>Status.Failed,
            "EXPIRED"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"PENDING",
            Status.Complete=>"COMPLETE",
            Status.Failed=>"FAILED",
            Status.Expired=>"EXPIRED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}