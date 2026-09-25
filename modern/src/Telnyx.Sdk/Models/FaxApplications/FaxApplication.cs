using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.FaxApplications;

[JsonConverter(typeof(JsonModelConverter<FaxApplication, FaxApplicationFromRaw>))]
public sealed record class FaxApplication : JsonModel
{
    /// <summary>
    /// Uniquely identifies the resource.
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
    /// Specifies whether the connection can be used.
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// A user-assigned name to help manage the application.
    /// </summary>
    public string? ApplicationName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "application_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("application_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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

    public FaxApplicationInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxApplicationInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound", value);
        }
    }

    public FaxApplicationOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxApplicationOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound", value);
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
    /// Tags associated with the Fax Application.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
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
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent. Must include
    /// a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_url", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init { this._rawData.Set("webhook_timeout_secs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.AnchorsiteOverride?.Validate();
        _ = this.ApplicationName;
        _ = this.CreatedAt;
        this.Inbound?.Validate();
        this.Outbound?.Validate();
        _ = this.RecordType;
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public FaxApplication ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplication (FaxApplication faxApplication) : base(faxApplication)
    {  }
    #pragma warning restore CS8618

    public FaxApplication (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplication (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationFromRaw.FromRawUnchecked"/>
    public static FaxApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationFromRaw : IFromRawJson<FaxApplication>
{
    /// <inheritdoc/>
    public FaxApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplication.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FaxApplicationInbound, FaxApplicationInboundFromRaw>))]
public sealed record class FaxApplicationInbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the number of concurrent inbound calls to phone
    /// numbers associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Specifies a subdomain that can be used to receive Inbound calls to a Connection,
    /// in the same way a phone number is used, from a SIP endpoint. Example: the
    /// subdomain "example.sip.telnyx.com" can be called from any SIP endpoint by
    /// using the SIP URI "sip:@example.sip.telnyx.com" where the user part can be
    /// any alphanumeric value. Please note TLS encrypted calls are not allowed for
    /// subdomain calls.
    /// </summary>
    public string? SipSubdomain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_subdomain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain", value);
        }
    }

    /// <summary>
    /// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint
    /// in the public Internet) or "Only my connections" (any connection assigned
    /// to the same Telnyx user).
    /// </summary>
    public ApiEnum<string, FaxApplicationInboundSipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxApplicationInboundSipSubdomainReceiveSettings>>(
                "sip_subdomain_receive_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain_receive_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
    }

    public FaxApplicationInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationInbound (
        FaxApplicationInbound faxApplicationInbound
    ) : base(faxApplicationInbound)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationInboundFromRaw.FromRawUnchecked"/>
    public static FaxApplicationInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxApplicationInboundFromRaw : IFromRawJson<FaxApplicationInbound>
{
    /// <inheritdoc/>
    public FaxApplicationInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationInbound.FromRawUnchecked(rawData);
}/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(FaxApplicationInboundSipSubdomainReceiveSettingsConverter))]
public enum FaxApplicationInboundSipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}sealed class FaxApplicationInboundSipSubdomainReceiveSettingsConverter : JsonConverter<FaxApplicationInboundSipSubdomainReceiveSettings>
{
    public override FaxApplicationInboundSipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>FaxApplicationInboundSipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>FaxApplicationInboundSipSubdomainReceiveSettings.FromAnyone,
            _ =>(FaxApplicationInboundSipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxApplicationInboundSipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxApplicationInboundSipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            FaxApplicationInboundSipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FaxApplicationOutbound, FaxApplicationOutboundFromRaw>))]
public sealed record class FaxApplicationOutbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the number of concurrent outbound calls to phone
    /// numbers associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound_voice_profile_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.OutboundVoiceProfileID;
    }

    public FaxApplicationOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationOutbound (
        FaxApplicationOutbound faxApplicationOutbound
    ) : base(faxApplicationOutbound)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationOutbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationOutboundFromRaw.FromRawUnchecked"/>
    public static FaxApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FaxApplicationOutboundFromRaw : IFromRawJson<FaxApplicationOutbound>
{
    /// <inheritdoc/>
    public FaxApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationOutbound.FromRawUnchecked(rawData);
}