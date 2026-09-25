using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveMetricAggregatesResponse, FuncRetrieveMetricAggregatesResponseFromRaw>))]
public sealed record class FuncRetrieveMetricAggregatesResponse : JsonModel
{
    public double? CpuUsedCoresAvg {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "cpu_used_cores_avg"
            );
        }
        init { this._rawData.Set("cpu_used_cores_avg", value); }
    }

    public double? CpuUsedCoresMax {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "cpu_used_cores_max"
            );
        }
        init { this._rawData.Set("cpu_used_cores_max", value); }
    }

    public DateTimeOffset? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? FunctionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "function_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("function_id", value);
        }
    }

    public string? FunctionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "function_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("function_name", value);
        }
    }

    public double? MemoryUsedBytesAvg {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "memory_used_bytes_avg"
            );
        }
        init { this._rawData.Set("memory_used_bytes_avg", value); }
    }

    public double? MemoryUsedBytesMax {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "memory_used_bytes_max"
            );
        }
        init { this._rawData.Set("memory_used_bytes_max", value); }
    }

    public string? Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product", value);
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

    public double? RequestClientErrorRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_client_error_rate"
            );
        }
        init { this._rawData.Set("request_client_error_rate", value); }
    }

    public double? RequestCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_count"
            );
        }
        init { this._rawData.Set("request_count", value); }
    }

    public double? RequestErrorRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_error_rate"
            );
        }
        init { this._rawData.Set("request_error_rate", value); }
    }

    public double? RequestLatencyAvgMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_latency_avg_ms"
            );
        }
        init { this._rawData.Set("request_latency_avg_ms", value); }
    }

    public double? RequestLatencyP50Ms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_latency_p50_ms"
            );
        }
        init { this._rawData.Set("request_latency_p50_ms", value); }
    }

    public double? RequestLatencyP95Ms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_latency_p95_ms"
            );
        }
        init { this._rawData.Set("request_latency_p95_ms", value); }
    }

    public double? RequestLatencyP99Ms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_latency_p99_ms"
            );
        }
        init { this._rawData.Set("request_latency_p99_ms", value); }
    }

    public double? RequestSuccessRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "request_success_rate"
            );
        }
        init { this._rawData.Set("request_success_rate", value); }
    }

    public DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CpuUsedCoresAvg;
        _ = this.CpuUsedCoresMax;
        _ = this.EndTime;
        _ = this.FunctionID;
        _ = this.FunctionName;
        _ = this.MemoryUsedBytesAvg;
        _ = this.MemoryUsedBytesMax;
        _ = this.Product;
        _ = this.RecordType;
        _ = this.RequestClientErrorRate;
        _ = this.RequestCount;
        _ = this.RequestErrorRate;
        _ = this.RequestLatencyAvgMs;
        _ = this.RequestLatencyP50Ms;
        _ = this.RequestLatencyP95Ms;
        _ = this.RequestLatencyP99Ms;
        _ = this.RequestSuccessRate;
        _ = this.StartTime;
    }

    public FuncRetrieveMetricAggregatesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveMetricAggregatesResponse (
        FuncRetrieveMetricAggregatesResponse funcRetrieveMetricAggregatesResponse
    ) : base(funcRetrieveMetricAggregatesResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveMetricAggregatesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveMetricAggregatesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveMetricAggregatesResponseFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveMetricAggregatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncRetrieveMetricAggregatesResponseFromRaw : IFromRawJson<FuncRetrieveMetricAggregatesResponse>
{
    /// <inheritdoc/>
    public FuncRetrieveMetricAggregatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveMetricAggregatesResponse.FromRawUnchecked(rawData);
}