using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPLatency;

[JsonConverter(typeof(JsonModelConverter<GlobalIPLatencyRetrieveResponse, GlobalIPLatencyRetrieveResponseFromRaw>))]
public sealed record class GlobalIPLatencyRetrieveResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public GlobalIPLatencyRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPLatencyRetrieveResponse (
        GlobalIPLatencyRetrieveResponse globalIPLatencyRetrieveResponse
    ) : base(globalIPLatencyRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPLatencyRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPLatencyRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPLatencyRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPLatencyRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPLatencyRetrieveResponseFromRaw : IFromRawJson<GlobalIPLatencyRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPLatencyRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPLatencyRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public GlobalIP? GlobalIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIP>(
                "global_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip", value);
        }
    }

    public MeanLatency? MeanLatency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MeanLatency>(
                "mean_latency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mean_latency", value);
        }
    }

    public PercentileLatency? PercentileLatency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PercentileLatency>(
                "percentile_latency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("percentile_latency", value);
        }
    }

    public ProberLocation? ProberLocation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProberLocation>(
                "prober_location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prober_location", value);
        }
    }

    /// <summary>
    /// The timestamp of the metric.
    /// </summary>
    public DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.GlobalIP?.Validate();
        this.MeanLatency?.Validate();
        this.PercentileLatency?.Validate();
        this.ProberLocation?.Validate();
        _ = this.Timestamp;
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
}[JsonConverter(typeof(JsonModelConverter<GlobalIP, GlobalIPFromRaw>))]
public sealed record class GlobalIP : JsonModel
{
    /// <summary>
    /// Global IP ID.
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
    /// The Global IP address.
    /// </summary>
    public string? IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IPAddress;
    }

    public GlobalIP ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIP (GlobalIP globalIP) : base(globalIP)
    {  }
    #pragma warning restore CS8618

    public GlobalIP (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIP (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPFromRaw.FromRawUnchecked"/>
    public static GlobalIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class GlobalIPFromRaw : IFromRawJson<GlobalIP>
{
    /// <inheritdoc/>
    public GlobalIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIP.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MeanLatency, MeanLatencyFromRaw>))]
public sealed record class MeanLatency : JsonModel
{
    /// <summary>
    /// The average latency.
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
    /// The unit of the average latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public MeanLatency ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeanLatency (MeanLatency meanLatency) : base(meanLatency)
    {  }
    #pragma warning restore CS8618

    public MeanLatency (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeanLatency (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeanLatencyFromRaw.FromRawUnchecked"/>
    public static MeanLatency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MeanLatencyFromRaw : IFromRawJson<MeanLatency>
{
    /// <inheritdoc/>
    public MeanLatency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeanLatency.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<PercentileLatency, PercentileLatencyFromRaw>))]
public sealed record class PercentileLatency : JsonModel
{
    public V0? P0 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V0>(
                "0"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("0", value);
        }
    }

    public V100? P100 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V100>(
                "100"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("100", value);
        }
    }

    public V25? P25 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V25>(
                "25"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("25", value);
        }
    }

    public V50? P50 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V50>(
                "50"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("50", value);
        }
    }

    public V75? P75 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V75>(
                "75"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("75", value);
        }
    }

    public V90? P90 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V90>(
                "90"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("90", value);
        }
    }

    public V99? P99 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V99>(
                "99"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("99", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.P0?.Validate();
        this.P100?.Validate();
        this.P25?.Validate();
        this.P50?.Validate();
        this.P75?.Validate();
        this.P90?.Validate();
        this.P99?.Validate();
    }

    public PercentileLatency ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PercentileLatency (PercentileLatency percentileLatency) : base(
        percentileLatency
    )
    {  }
    #pragma warning restore CS8618

    public PercentileLatency (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentileLatency (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PercentileLatencyFromRaw.FromRawUnchecked"/>
    public static PercentileLatency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PercentileLatencyFromRaw : IFromRawJson<PercentileLatency>
{
    /// <inheritdoc/>
    public PercentileLatency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PercentileLatency.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V0, V0FromRaw>))]
public sealed record class V0 : JsonModel
{
    /// <summary>
    /// The minimum latency.
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
    /// The unit of the minimum latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V0 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V0 (V0 v0) : base(v0)
    {  }
    #pragma warning restore CS8618

    public V0 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V0 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V0FromRaw.FromRawUnchecked"/>
    public static V0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V0FromRaw : IFromRawJson<V0>
{
    /// <inheritdoc/>
    public V0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>V0.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V100, V100FromRaw>))]
public sealed record class V100 : JsonModel
{
    /// <summary>
    /// The maximum latency.
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
    /// The unit of the maximum latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V100 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V100 (V100 v100) : base(v100)
    {  }
    #pragma warning restore CS8618

    public V100 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V100 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V100FromRaw.FromRawUnchecked"/>
    public static V100 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V100FromRaw : IFromRawJson<V100>
{
    /// <inheritdoc/>
    public V100 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V100.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V25, V25FromRaw>))]
public sealed record class V25 : JsonModel
{
    /// <summary>
    /// The 25th percentile latency.
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
    /// The unit of the 25th percentile latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V25 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V25 (V25 v25) : base(v25)
    {  }
    #pragma warning restore CS8618

    public V25 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V25 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V25FromRaw.FromRawUnchecked"/>
    public static V25 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V25FromRaw : IFromRawJson<V25>
{
    /// <inheritdoc/>
    public V25 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V25.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V50, V50FromRaw>))]
public sealed record class V50 : JsonModel
{
    /// <summary>
    /// The 50th percentile latency.
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
    /// The unit of the 50th percentile latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V50 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V50 (V50 v50) : base(v50)
    {  }
    #pragma warning restore CS8618

    public V50 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V50 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V50FromRaw.FromRawUnchecked"/>
    public static V50 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V50FromRaw : IFromRawJson<V50>
{
    /// <inheritdoc/>
    public V50 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V50.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V75, V75FromRaw>))]
public sealed record class V75 : JsonModel
{
    /// <summary>
    /// The 75th percentile latency.
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
    /// The unit of the 75th percentile latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V75 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V75 (V75 v75) : base(v75)
    {  }
    #pragma warning restore CS8618

    public V75 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V75 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V75FromRaw.FromRawUnchecked"/>
    public static V75 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V75FromRaw : IFromRawJson<V75>
{
    /// <inheritdoc/>
    public V75 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V75.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V90, V90FromRaw>))]
public sealed record class V90 : JsonModel
{
    /// <summary>
    /// The 90th percentile latency.
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
    /// The unit of the 90th percentile latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V90 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V90 (V90 v90) : base(v90)
    {  }
    #pragma warning restore CS8618

    public V90 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V90 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V90FromRaw.FromRawUnchecked"/>
    public static V90 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V90FromRaw : IFromRawJson<V90>
{
    /// <inheritdoc/>
    public V90 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V90.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<V99, V99FromRaw>))]
public sealed record class V99 : JsonModel
{
    /// <summary>
    /// The 99th percentile latency.
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
    /// The unit of the 99th percentile latency.
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.Unit;
    }

    public V99 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V99 (V99 v99) : base(v99)
    {  }
    #pragma warning restore CS8618

    public V99 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V99 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V99FromRaw.FromRawUnchecked"/>
    public static V99 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class V99FromRaw : IFromRawJson<V99>
{
    /// <inheritdoc/>
    public V99 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V99.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ProberLocation, ProberLocationFromRaw>))]
public sealed record class ProberLocation : JsonModel
{
    /// <summary>
    /// Location ID.
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
    /// Latitude.
    /// </summary>
    public double? Lat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "lat"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lat", value);
        }
    }

    /// <summary>
    /// Longitude.
    /// </summary>
    public double? Lon {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "lon"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lon", value);
        }
    }

    /// <summary>
    /// Location name.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Lat;
        _ = this.Lon;
        _ = this.Name;
    }

    public ProberLocation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProberLocation (ProberLocation proberLocation) : base(proberLocation)
    {  }
    #pragma warning restore CS8618

    public ProberLocation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProberLocation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProberLocationFromRaw.FromRawUnchecked"/>
    public static ProberLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProberLocationFromRaw : IFromRawJson<ProberLocation>
{
    /// <inheritdoc/>
    public ProberLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProberLocation.FromRawUnchecked(rawData);
}