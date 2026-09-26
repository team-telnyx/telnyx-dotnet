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

namespace Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

/// <summary>
/// Updates the FQDN authentication strategy for a specific FQDN connection.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FqdnAuthenticationPatchAllParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FqdnConnectionID { get; init; }

    /// <summary>
    /// The failover webhook URL.
    /// </summary>
    public string? FailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("failover_url", value);
        }
    }

    /// <summary>
    /// The outbound authentication type.
    /// </summary>
    public ApiEnum<string, FqdnOutboundAuthentication>? FqdnOutboundAuthentication {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, FqdnOutboundAuthentication>>(
                "fqdn_outbound_authentication"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("fqdn_outbound_authentication", value);
        }
    }

    /// <summary>
    /// The IP authentication method.
    /// </summary>
    public ApiEnum<string, IPAuthenticationMethod>? IPAuthenticationMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, IPAuthenticationMethod>>(
                "ip_authentication_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ip_authentication_method", value);
        }
    }

    /// <summary>
    /// The password for authentication.
    /// </summary>
    public string? Password {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("password", value);
        }
    }

    /// <summary>
    /// The TXT record name for Microsoft Teams SBC DNS verification.
    /// </summary>
    public string? TxtName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "txt_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("txt_name", value);
        }
    }

    /// <summary>
    /// The TTL for the TXT record.
    /// </summary>
    public long? TxtTtl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "txt_ttl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("txt_ttl", value);
        }
    }

    /// <summary>
    /// The TXT record value for Microsoft Teams SBC DNS verification.
    /// </summary>
    public string? TxtValue {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "txt_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("txt_value", value);
        }
    }

    /// <summary>
    /// The username for authentication.
    /// </summary>
    public string? UserName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("user_name", value);
        }
    }

    /// <summary>
    /// The webhook URL for authentication events.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public FqdnAuthenticationPatchAllParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnAuthenticationPatchAllParams (
        FqdnAuthenticationPatchAllParams fqdnAuthenticationPatchAllParams
    ) : base(fqdnAuthenticationPatchAllParams)
    {
        this.FqdnConnectionID = fqdnAuthenticationPatchAllParams.FqdnConnectionID;

        this._rawBodyData = new(fqdnAuthenticationPatchAllParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public FqdnAuthenticationPatchAllParams (
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
    FqdnAuthenticationPatchAllParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string fqdnConnectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FqdnConnectionID = fqdnConnectionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FqdnAuthenticationPatchAllParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string fqdnConnectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            fqdnConnectionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["FqdnConnectionID"] = JsonSerializer.SerializeToElement(this.FqdnConnectionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(FqdnAuthenticationPatchAllParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FqdnConnectionID?.Equals(other.FqdnConnectionID) ?? other.FqdnConnectionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/fqdn_connections/{0}/fqdn_authentication",
            EncodePathSegment(this.FqdnConnectionID))
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
/// The outbound authentication type.
/// </summary>
[JsonConverter(typeof(FqdnOutboundAuthenticationConverter))]
public enum FqdnOutboundAuthentication
{
    IPAuthentication, CredentialAuthentication
}

sealed class FqdnOutboundAuthenticationConverter : JsonConverter<FqdnOutboundAuthentication>
{
    public override FqdnOutboundAuthentication Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ip-authentication"=>FqdnOutboundAuthentication.IPAuthentication,
            "credential-authentication"=>FqdnOutboundAuthentication.CredentialAuthentication,
            _ =>(FqdnOutboundAuthentication)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FqdnOutboundAuthentication value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FqdnOutboundAuthentication.IPAuthentication=>"ip-authentication",
            FqdnOutboundAuthentication.CredentialAuthentication=>"credential-authentication",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The IP authentication method.
/// </summary>
[JsonConverter(typeof(IPAuthenticationMethodConverter))]
public enum IPAuthenticationMethod
{
    Token, PChargeInfo
}

sealed class IPAuthenticationMethodConverter : JsonConverter<IPAuthenticationMethod>
{
    public override IPAuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token"=>IPAuthenticationMethod.Token,
            "p-charge-info"=>IPAuthenticationMethod.PChargeInfo,
            _ =>(IPAuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IPAuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IPAuthenticationMethod.Token=>"token",
            IPAuthenticationMethod.PChargeInfo=>"p-charge-info",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}