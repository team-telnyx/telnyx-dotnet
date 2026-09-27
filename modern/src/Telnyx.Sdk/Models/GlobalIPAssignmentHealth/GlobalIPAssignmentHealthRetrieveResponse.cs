using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignmentHealth;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentHealthRetrieveResponse, GlobalIPAssignmentHealthRetrieveResponseFromRaw>))]
public sealed record class GlobalIPAssignmentHealthRetrieveResponse : JsonModel
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

    public GlobalIPAssignmentHealthRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentHealthRetrieveResponse (
        GlobalIPAssignmentHealthRetrieveResponse globalIPAssignmentHealthRetrieveResponse
    ) : base(globalIPAssignmentHealthRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentHealthRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentHealthRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentHealthRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentHealthRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentHealthRetrieveResponseFromRaw : IFromRawJson<GlobalIPAssignmentHealthRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentHealthRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentHealthRetrieveResponse.FromRawUnchecked(rawData);
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

    public GlobalIPAssignment? GlobalIPAssignment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIPAssignment>(
                "global_ip_assignment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_assignment", value);
        }
    }

    public Health? Health {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Health>(
                "health"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("health", value);
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
        this.GlobalIPAssignment?.Validate();
        this.Health?.Validate();
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
}[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignment, GlobalIPAssignmentFromRaw>))]
public sealed record class GlobalIPAssignment : JsonModel
{
    /// <summary>
    /// Global IP assignment ID.
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

    public WireguardPeer? WireguardPeer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireguardPeer>(
                "wireguard_peer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer", value);
        }
    }

    /// <summary>
    /// Wireguard peer ID.
    /// </summary>
    public string? WireguardPeerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_peer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.WireguardPeer?.Validate();
        _ = this.WireguardPeerID;
    }

    public GlobalIPAssignment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignment (GlobalIPAssignment globalIPAssignment) : base(
        globalIPAssignment
    )
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class GlobalIPAssignmentFromRaw : IFromRawJson<GlobalIPAssignment>
{
    /// <inheritdoc/>
    public GlobalIPAssignment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignment.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WireguardPeer, WireguardPeerFromRaw>))]
public sealed record class WireguardPeer : JsonModel
{
    /// <summary>
    /// The IP address of the interface.
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

    /// <summary>
    /// A user specified name for the interface.
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
        _ = this.IPAddress;
        _ = this.Name;
    }

    public WireguardPeer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeer (WireguardPeer wireguardPeer) : base(wireguardPeer)
    {  }
    #pragma warning restore CS8618

    public WireguardPeer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerFromRaw.FromRawUnchecked"/>
    public static WireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WireguardPeerFromRaw : IFromRawJson<WireguardPeer>
{
    /// <inheritdoc/>
    public WireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeer.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Health, HealthFromRaw>))]
public sealed record class Health : JsonModel
{
    /// <summary>
    /// The number of failed health checks.
    /// </summary>
    public double? Fail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "fail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fail", value);
        }
    }

    /// <summary>
    /// The number of successful health checks.
    /// </summary>
    public double? Pass {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "pass"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pass", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Fail;
        _ = this.Pass;
    }

    public Health ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Health (Health health) : base(health)
    {  }
    #pragma warning restore CS8618

    public Health (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Health (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HealthFromRaw.FromRawUnchecked"/>
    public static Health FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class HealthFromRaw : IFromRawJson<Health>
{
    /// <inheritdoc/>
    public Health FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Health.FromRawUnchecked(rawData);
}