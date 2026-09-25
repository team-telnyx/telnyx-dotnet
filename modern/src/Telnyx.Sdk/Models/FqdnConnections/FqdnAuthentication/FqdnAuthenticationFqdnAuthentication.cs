using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

[JsonConverter(typeof(JsonModelConverter<FqdnAuthenticationFqdnAuthentication, FqdnAuthenticationFqdnAuthenticationFromRaw>))]
public sealed record class FqdnAuthenticationFqdnAuthentication : JsonModel
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
    /// The ID of the FQDN connection this authentication strategy belongs to.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// The failover webhook URL.
    /// </summary>
    public string? FailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failover_url", value);
        }
    }

    /// <summary>
    /// The outbound authentication type.
    /// </summary>
    public ApiEnum<string, FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication>? FqdnOutboundAuthentication {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication>>(
                "fqdn_outbound_authentication"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fqdn_outbound_authentication", value);
        }
    }

    /// <summary>
    /// The IP authentication method.
    /// </summary>
    public ApiEnum<string, FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod>? IPAuthenticationMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod>>(
                "ip_authentication_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_authentication_method", value);
        }
    }

    /// <summary>
    /// Whether the connection is a Microsoft Teams SBC.
    /// </summary>
    public bool? MicrosoftTeamsSbc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "microsoft_teams_sbc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("microsoft_teams_sbc", value);
        }
    }

    /// <summary>
    /// The password for authentication. For primary accounts created on or after
    /// September 8, 2026, this password is returned as `********`. The password
    /// is returned in full on create, and on update only when that update changed
    /// the password. Accounts created before September 8, 2026 are unaffected.
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
    /// The TXT record name for Microsoft Teams SBC DNS verification.
    /// </summary>
    public string? TxtName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "txt_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_name", value);
        }
    }

    /// <summary>
    /// The TTL for the TXT record.
    /// </summary>
    public long? TxtTtl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "txt_ttl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_ttl", value);
        }
    }

    /// <summary>
    /// The TXT record value for Microsoft Teams SBC DNS verification.
    /// </summary>
    public string? TxtValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "txt_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("txt_value", value);
        }
    }

    /// <summary>
    /// The username for authentication.
    /// </summary>
    public string? UserName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_name", value);
        }
    }

    /// <summary>
    /// The webhook URL for authentication events.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ConnectionID;
        _ = this.FailoverUrl;
        this.FqdnOutboundAuthentication?.Validate();
        this.IPAuthenticationMethod?.Validate();
        _ = this.MicrosoftTeamsSbc;
        _ = this.Password;
        _ = this.RecordType;
        _ = this.TxtName;
        _ = this.TxtTtl;
        _ = this.TxtValue;
        _ = this.UserName;
        _ = this.WebhookUrl;
    }

    public FqdnAuthenticationFqdnAuthentication ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnAuthenticationFqdnAuthentication (
        FqdnAuthenticationFqdnAuthentication fqdnAuthenticationFqdnAuthentication
    ) : base(fqdnAuthenticationFqdnAuthentication)
    {  }
    #pragma warning restore CS8618

    public FqdnAuthenticationFqdnAuthentication (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnAuthenticationFqdnAuthentication (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnAuthenticationFqdnAuthenticationFromRaw.FromRawUnchecked"/>
    public static FqdnAuthenticationFqdnAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnAuthenticationFqdnAuthenticationFromRaw : IFromRawJson<FqdnAuthenticationFqdnAuthentication>
{
    /// <inheritdoc/>
    public FqdnAuthenticationFqdnAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnAuthenticationFqdnAuthentication.FromRawUnchecked(rawData);
}

/// <summary>
/// The outbound authentication type.
/// </summary>
[JsonConverter(typeof(FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthenticationConverter))]
public enum FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication
{
    IPAuthentication, CredentialAuthentication
}sealed class FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthenticationConverter : JsonConverter<FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication>
{
    public override FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ip-authentication"=>FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication.IPAuthentication,
            "credential-authentication"=>FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication.CredentialAuthentication,
            _ =>(FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication.IPAuthentication=>"ip-authentication",
            FqdnAuthenticationFqdnAuthenticationFqdnOutboundAuthentication.CredentialAuthentication=>"credential-authentication",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The IP authentication method.
/// </summary>
[JsonConverter(typeof(FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethodConverter))]
public enum FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod
{
    Token, PChargeInfo
}sealed class FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethodConverter : JsonConverter<FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod>
{
    public override FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token"=>FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod.Token,
            "p-charge-info"=>FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod.PChargeInfo,
            _ =>(FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod.Token=>"token",
            FqdnAuthenticationFqdnAuthenticationIPAuthenticationMethod.PChargeInfo=>"p-charge-info",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}