using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Networks;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

/// <summary>
/// Create a new WireGuard Interface. Current limitation of 10 interfaces per user
/// can be created.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireguardInterfaceCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required Body Body {
        get {
            return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public WireguardInterfaceCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceCreateParams (
        WireguardInterfaceCreateParams wireguardInterfaceCreateParams
    ) : base(wireguardInterfaceCreateParams)
    { this.RawBodyData = wireguardInterfaceCreateParams.RawBodyData; }
    #pragma warning restore CS8618

    public WireguardInterfaceCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WireguardInterfaceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(WireguardInterfaceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/wireguard_interfaces"
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

[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// ISO 8601 formatted date-time indicating when the resource was created.
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
    /// ISO 8601 formatted date-time indicating when the resource was updated.
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

    /// <summary>
    /// The id of the network associated with the interface.
    /// </summary>
    public string? NetworkID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "network_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network_id", value);
        }
    }

    /// <summary>
    /// The current status of the interface deployment.
    /// </summary>
    public ApiEnum<string, InterfaceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InterfaceStatus>>(
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

    /// <summary>
    /// Enable SIP traffic forwarding over VPN interface.
    /// </summary>
    public bool? EnableSipTrunking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_sip_trunking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_sip_trunking", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.endpoint` value.
    /// </summary>
    public string? Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("endpoint", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.PublicKey`.
    /// </summary>
    public string? PublicKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "public_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_key", value);
        }
    }

    /// <summary>
    /// The region the interface should be deployed to.
    /// </summary>
    public required string RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "region_code"
            );
        }
        init { this._rawData.Set("region_code", value); }
    }

    public static implicit operator WireguardInterface (Body body)=> new() {
        ID = body.ID,
        CreatedAt = body.CreatedAt,
        RecordType = body.RecordType,
        UpdatedAt = body.UpdatedAt,
        Name = body.Name,
        NetworkID = body.NetworkID,
        Status = body.Status,
        EnableSipTrunking = body.EnableSipTrunking,
        Endpoint = body.Endpoint,
        PublicKey = body.PublicKey
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.NetworkID;
        this.Status?.Validate();
        _ = this.EnableSipTrunking;
        _ = this.Endpoint;
        _ = this.PublicKey;
        _ = this.RegionCode;
    }

    public Body ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body (Body body) : base(body)
    {  }
    #pragma warning restore CS8618

    public Body (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Body (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Body (string regionCode) : this()
    { this.RegionCode = regionCode; }
}

class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Body.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceCreate, WireguardInterfaceCreateFromRaw>))]
public sealed record class WireguardInterfaceCreate : JsonModel
{
    /// <summary>
    /// The region the interface should be deployed to.
    /// </summary>
    public required string RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "region_code"
            );
        }
        init { this._rawData.Set("region_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RegionCode; }

    public WireguardInterfaceCreate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceCreate (
        WireguardInterfaceCreate wireguardInterfaceCreate
    ) : base(wireguardInterfaceCreate)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceCreate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceCreate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceCreateFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WireguardInterfaceCreate (string regionCode) : this()
    { this.RegionCode = regionCode; }
}

class WireguardInterfaceCreateFromRaw : IFromRawJson<WireguardInterfaceCreate>
{
    /// <inheritdoc/>
    public WireguardInterfaceCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceCreate.FromRawUnchecked(rawData);
}