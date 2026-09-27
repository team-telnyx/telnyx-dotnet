using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.UacConnections;

/// <summary>
/// External SIP peer settings used by Telnyx when registering to your PBX and routing
/// outbound calls.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UacExternalSettings, UacExternalSettingsFromRaw>))]
public sealed record class UacExternalSettings : JsonModel
{
    /// <summary>
    /// The authentication username used in SIP digest authentication. If not set,
    /// the Username value will be used.
    /// </summary>
    public string? AuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "auth_username"
            );
        }
        init { this._rawData.Set("auth_username", value); }
    }

    /// <summary>
    /// The registration interval, in seconds, indicating how often the system refreshes
    /// the SIP registration with the external SIP peer.
    /// </summary>
    public long? ExpirationSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "expiration_sec"
            );
        }
        init { this._rawData.Set("expiration_sec", value); }
    }

    /// <summary>
    /// The user portion of the SIP From header used in outbound requests. This controls
    /// the caller identity presented to the external SIP peer.
    /// </summary>
    public string? FromUser {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_user"
            );
        }
        init { this._rawData.Set("from_user", value); }
    }

    /// <summary>
    /// An optional SIP proxy used to route outbound requests before reaching the
    /// external SIP peer.
    /// </summary>
    public string? OutboundProxy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_proxy"
            );
        }
        init { this._rawData.Set("outbound_proxy", value); }
    }

    /// <summary>
    /// The SIP password used for digest authentication with the external SIP peer.
    /// For primary accounts created on or after September 8, 2026, this password
    /// is returned as `********`. The password is returned in full on create, and
    /// on update only when that update changed the password. Accounts created before
    /// September 8, 2026 are unaffected.
    /// </summary>
    public string? Password {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("password", value);
        }
    }

    /// <summary>
    /// The SIP proxy address of the external SIP peer used for registrations and
    /// outbound call routing.
    /// </summary>
    public string? Proxy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "proxy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("proxy", value);
        }
    }

    /// <summary>
    /// The transport protocol used for SIP signaling when communicating with the
    /// external SIP peer. One of UDP, TLS, or TCP.
    /// </summary>
    public ApiEnum<string, Transport>? Transport {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Transport>>(
                "transport"
            );
        }
        init { this._rawData.Set("transport", value); }
    }

    /// <summary>
    /// Custom SIP User-Agent header value that Telnyx uses on outbound REGISTER and
    /// INVITE messages. Set to null to use Telnyx's default User-Agent.
    /// </summary>
    public string? UserAgent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_agent"
            );
        }
        init { this._rawData.Set("user_agent", value); }
    }

    /// <summary>
    /// The SIP username used to authenticate with the external SIP peer for registrations
    /// and outbound calls. Must start with a letter or number and contain only letters,
    /// numbers, hyphens, and underscores.
    /// </summary>
    public string? Username {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthUsername;
        _ = this.ExpirationSec;
        _ = this.FromUser;
        _ = this.OutboundProxy;
        _ = this.Password;
        _ = this.Proxy;
        this.Transport?.Validate();
        _ = this.UserAgent;
        _ = this.Username;
    }

    public UacExternalSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacExternalSettings (UacExternalSettings uacExternalSettings) : base(
        uacExternalSettings
    )
    {  }
    #pragma warning restore CS8618

    public UacExternalSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacExternalSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacExternalSettingsFromRaw.FromRawUnchecked"/>
    public static UacExternalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacExternalSettingsFromRaw : IFromRawJson<UacExternalSettings>
{
    /// <inheritdoc/>
    public UacExternalSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacExternalSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The transport protocol used for SIP signaling when communicating with the external
/// SIP peer. One of UDP, TLS, or TCP.
/// </summary>
[JsonConverter(typeof(TransportConverter))]
public enum Transport
{
    Udp, Tls, Tcp
}sealed class TransportConverter : JsonConverter<Transport>
{
    public override Transport Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UDP"=>Transport.Udp,
            "TLS"=>Transport.Tls,
            "TCP"=>Transport.Tcp,
            _ =>(Transport)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Transport value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Transport.Udp=>"UDP",
            Transport.Tls=>"TLS",
            Transport.Tcp=>"TCP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}