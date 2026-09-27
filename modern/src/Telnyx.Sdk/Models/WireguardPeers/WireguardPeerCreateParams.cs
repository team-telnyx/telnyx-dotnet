using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

/// <summary>
/// Create a new WireGuard Peer. Current limitation of 5 peers per interface can be created.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WireguardPeerCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required Body Body {
        get {
            return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public WireguardPeerCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerCreateParams (
        WireguardPeerCreateParams wireguardPeerCreateParams
    ) : base(wireguardPeerCreateParams)
    { this.RawBodyData = wireguardPeerCreateParams.RawBodyData; }
    #pragma warning restore CS8618

    public WireguardPeerCreateParams (
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
    WireguardPeerCreateParams (
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
    public static WireguardPeerCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WireguardPeerCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/wireguard_peers"
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
    /// ISO 8601 formatted date-time indicating when peer sent traffic last time.
    /// </summary>
    public string? LastSeen {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_seen"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_seen", value);
        }
    }

    /// <summary>
    /// Your WireGuard `Interface.PrivateKey`.&lt;br /&gt;&lt;br /&gt;This attribute
    /// is only ever utlised if, on POST, you do NOT provide your own `public_key`.
    /// In which case, a new Public and Private key pair will be generated for you.
    /// When your `private_key` is returned, you must save this immediately as we
    /// do not save it within Telnyx. If you lose your Private Key, it can not be recovered.
    /// </summary>
    public string? PrivateKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "private_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("private_key", value);
        }
    }

    /// <summary>
    /// The id of the wireguard interface associated with the peer.
    /// </summary>
    public string? WireguardInterfaceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_interface_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_interface_id", value);
        }
    }

    public static implicit operator WireguardPeer (Body body)=> new() {
        ID = body.ID,
        CreatedAt = body.CreatedAt,
        RecordType = body.RecordType,
        UpdatedAt = body.UpdatedAt,
        LastSeen = body.LastSeen,
        PrivateKey = body.PrivateKey,
        WireguardInterfaceID = body.WireguardInterfaceID
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.LastSeen;
        _ = this.PrivateKey;
        _ = this.WireguardInterfaceID;
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
}

class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Body.FromRawUnchecked(rawData);
}