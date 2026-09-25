using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

/// <summary>
/// Asynchronously create a Private Wireless Gateway for SIM cards for a previously
/// created network. This operation may take several minutes so you can check the
/// Private Wireless Gateway status at the section Get a Private Wireless Gateway.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PrivateWirelessGatewayCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The private wireless gateway name.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The identification of the related network resource.
    /// </summary>
    public required string NetworkID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "network_id"
            );
        }
        init { this._rawBodyData.Set("network_id", value); }
    }

    /// <summary>
    /// Determines how IP addresses are assigned to SIM cards using this gateway.
    /// With static, each SIM card gets a fixed IP address from the gateway's IP
    /// range that is preserved across sessions. With dynamic, an IP address is assigned
    /// by the network at attach time and may change between sessions. If omitted,
    /// the gateway is created with the default address mode, dynamic.
    /// </summary>
    public ApiEnum<string, AddressMode>? AddressMode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AddressMode>>(
                "address_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("address_mode", value);
        }
    }

    /// <summary>
    /// The code of the region where the private wireless gateway will be assigned.
    /// A list of available regions can be found at the regions endpoint
    /// </summary>
    public string? RegionCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("region_code", value);
        }
    }

    public PrivateWirelessGatewayCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGatewayCreateParams (
        PrivateWirelessGatewayCreateParams privateWirelessGatewayCreateParams
    ) : base(privateWirelessGatewayCreateParams)
    {
        this._rawBodyData = new(privateWirelessGatewayCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PrivateWirelessGatewayCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGatewayCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PrivateWirelessGatewayCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PrivateWirelessGatewayCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/private_wireless_gateways"
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

/// <summary>
/// Determines how IP addresses are assigned to SIM cards using this gateway. With
/// static, each SIM card gets a fixed IP address from the gateway's IP range that
/// is preserved across sessions. With dynamic, an IP address is assigned by the network
/// at attach time and may change between sessions. If omitted, the gateway is created
/// with the default address mode, dynamic.
/// </summary>
[JsonConverter(typeof(AddressModeConverter))]
public enum AddressMode
{
    Static, Dynamic
}

sealed class AddressModeConverter : JsonConverter<AddressMode>
{
    public override AddressMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "static"=>AddressMode.Static,
            "dynamic"=>AddressMode.Dynamic,
            _ =>(AddressMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AddressMode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AddressMode.Static=>"static",
            AddressMode.Dynamic=>"dynamic",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}