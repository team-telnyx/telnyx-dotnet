using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnection, ExternalConnectionFromRaw>))]
public sealed record class ExternalConnection : JsonModel
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

    /// <summary>
    /// If the credential associated with this service is active.
    /// </summary>
    public bool? CredentialActive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "credential_active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("credential_active", value);
        }
    }

    /// <summary>
    /// The service that will be consuming this connection.
    /// </summary>
    public ApiEnum<string, ExternalConnectionExternalSipConnection>? ExternalSipConnection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExternalConnectionExternalSipConnection>>(
                "external_sip_connection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_sip_connection", value);
        }
    }

    public ExternalConnectionInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalConnectionInbound>(
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

    public ExternalConnectionOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalConnectionOutbound>(
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
    /// Tags associated with the connection.
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
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_api_version", value);
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
        _ = this.CreatedAt;
        _ = this.CredentialActive;
        this.ExternalSipConnection?.Validate();
        this.Inbound?.Validate();
        this.Outbound?.Validate();
        _ = this.RecordType;
        _ = this.Tags;
        _ = this.UpdatedAt;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public ExternalConnection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnection (ExternalConnection externalConnection) : base(
        externalConnection
    )
    {  }
    #pragma warning restore CS8618

    public ExternalConnection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionFromRaw.FromRawUnchecked"/>
    public static ExternalConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionFromRaw : IFromRawJson<ExternalConnection>
{
    /// <inheritdoc/>
    public ExternalConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnection.FromRawUnchecked(rawData);
}

/// <summary>
/// The service that will be consuming this connection.
/// </summary>
[JsonConverter(typeof(ExternalConnectionExternalSipConnectionConverter))]
public enum ExternalConnectionExternalSipConnection
{
    Zoom, OperatorConnect
}sealed class ExternalConnectionExternalSipConnectionConverter : JsonConverter<ExternalConnectionExternalSipConnection>
{
    public override ExternalConnectionExternalSipConnection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "zoom"=>ExternalConnectionExternalSipConnection.Zoom,
            "operator_connect"=>ExternalConnectionExternalSipConnection.OperatorConnect,
            _ =>(ExternalConnectionExternalSipConnection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionExternalSipConnection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ExternalConnectionExternalSipConnection.Zoom=>"zoom",
            ExternalConnectionExternalSipConnection.OperatorConnect=>"operator_connect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ExternalConnectionInbound, ExternalConnectionInboundFromRaw>))]
public sealed record class ExternalConnectionInbound : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ChannelLimit; }

    public ExternalConnectionInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionInbound (
        ExternalConnectionInbound externalConnectionInbound
    ) : base(externalConnectionInbound)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionInboundFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ExternalConnectionInboundFromRaw : IFromRawJson<ExternalConnectionInbound>
{
    /// <inheritdoc/>
    public ExternalConnectionInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionInbound.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ExternalConnectionOutbound, ExternalConnectionOutboundFromRaw>))]
public sealed record class ExternalConnectionOutbound : JsonModel
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

    public ExternalConnectionOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionOutbound (
        ExternalConnectionOutbound externalConnectionOutbound
    ) : base(externalConnectionOutbound)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionOutbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionOutboundFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ExternalConnectionOutboundFromRaw : IFromRawJson<ExternalConnectionOutbound>
{
    /// <inheritdoc/>
    public ExternalConnectionOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionOutbound.FromRawUnchecked(rawData);
}/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2
}sealed class WebhookApiVersionConverter : JsonConverter<WebhookApiVersion>
{
    public override WebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>WebhookApiVersion.V1,
            "2"=>WebhookApiVersion.V2,
            _ =>(WebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookApiVersion.V1=>"1",
            WebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}