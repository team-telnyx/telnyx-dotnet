using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPUsage;

[JsonConverter(typeof(JsonModelConverter<GlobalIPUsageRetrieveResponse, GlobalIPUsageRetrieveResponseFromRaw>))]
public sealed record class GlobalIPUsageRetrieveResponse : JsonModel
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

    public GlobalIPUsageRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPUsageRetrieveResponse (
        GlobalIPUsageRetrieveResponse globalIPUsageRetrieveResponse
    ) : base(globalIPUsageRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPUsageRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPUsageRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPUsageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPUsageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPUsageRetrieveResponseFromRaw : IFromRawJson<GlobalIPUsageRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPUsageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPUsageRetrieveResponse.FromRawUnchecked(rawData);
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

    public Received? Received {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Received>(
                "received"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("received", value);
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

    public Transmitted? Transmitted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Transmitted>(
                "transmitted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transmitted", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.GlobalIP?.Validate();
        this.Received?.Validate();
        _ = this.Timestamp;
        this.Transmitted?.Validate();
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
}[JsonConverter(typeof(JsonModelConverter<Received, ReceivedFromRaw>))]
public sealed record class Received : JsonModel
{
    /// <summary>
    /// The amount of data received.
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
    /// The unit of the amount of data received.
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

    public Received ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Received (Received received) : base(received)
    {  }
    #pragma warning restore CS8618

    public Received (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Received (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReceivedFromRaw.FromRawUnchecked"/>
    public static Received FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ReceivedFromRaw : IFromRawJson<Received>
{
    /// <inheritdoc/>
    public Received FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Received.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Transmitted, TransmittedFromRaw>))]
public sealed record class Transmitted : JsonModel
{
    /// <summary>
    /// The amount of data transmitted.
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
    /// The unit of the amount of data transmitted.
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

    public Transmitted ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transmitted (Transmitted transmitted) : base(transmitted)
    {  }
    #pragma warning restore CS8618

    public Transmitted (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Transmitted (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransmittedFromRaw.FromRawUnchecked"/>
    public static Transmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TransmittedFromRaw : IFromRawJson<Transmitted>
{
    /// <inheritdoc/>
    public Transmitted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Transmitted.FromRawUnchecked(rawData);
}