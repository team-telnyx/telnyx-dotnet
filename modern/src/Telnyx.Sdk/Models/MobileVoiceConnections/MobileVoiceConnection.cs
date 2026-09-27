using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnection, MobileVoiceConnectionFromRaw>))]
public sealed record class MobileVoiceConnection : JsonModel
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
    /// Indicates if the connection is active.
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
    /// The name of the connection.
    /// </summary>
    public string? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_name", value);
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public MobileVoiceConnectionInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobileVoiceConnectionInbound>(
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

    public MobileVoiceConnectionOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobileVoiceConnectionOutbound>(
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
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// A list of tags associated with the connection.
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

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// The API version for webhooks.
    /// </summary>
    public ApiEnum<string, MobileVoiceConnectionWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MobileVoiceConnectionWebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init { this._rawData.Set("webhook_api_version", value); }
    }

    /// <summary>
    /// The failover URL where webhooks are sent.
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
    /// The URL where webhooks are sent.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init { this._rawData.Set("webhook_event_url", value); }
    }

    /// <summary>
    /// The timeout for webhooks in seconds.
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
        _ = this.ConnectionName;
        _ = this.CreatedAt;
        this.Inbound?.Validate();
        this.Outbound?.Validate();
        this.RecordType?.Validate();
        _ = this.Tags;
        _ = this.UpdatedAt;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public MobileVoiceConnection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnection (
        MobileVoiceConnection mobileVoiceConnection
    ) : base(mobileVoiceConnection)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnection (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionFromRaw : IFromRawJson<MobileVoiceConnection>
{
    /// <inheritdoc/>
    public MobileVoiceConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnection.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionInbound, MobileVoiceConnectionInboundFromRaw>))]
public sealed record class MobileVoiceConnectionInbound : JsonModel
{
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init { this._rawData.Set("channel_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ChannelLimit; }

    public MobileVoiceConnectionInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionInbound (
        MobileVoiceConnectionInbound mobileVoiceConnectionInbound
    ) : base(mobileVoiceConnectionInbound)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionInboundFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobileVoiceConnectionInboundFromRaw : IFromRawJson<MobileVoiceConnectionInbound>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionInbound.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionOutbound, MobileVoiceConnectionOutboundFromRaw>))]
public sealed record class MobileVoiceConnectionOutbound : JsonModel
{
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init { this._rawData.Set("channel_limit", value); }
    }

    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init { this._rawData.Set("outbound_voice_profile_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.OutboundVoiceProfileID;
    }

    public MobileVoiceConnectionOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionOutbound (
        MobileVoiceConnectionOutbound mobileVoiceConnectionOutbound
    ) : base(mobileVoiceConnectionOutbound)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionOutbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionOutboundFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobileVoiceConnectionOutboundFromRaw : IFromRawJson<MobileVoiceConnectionOutbound>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionOutbound.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    MobileVoiceConnection
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mobile_voice_connection"=>RecordType.MobileVoiceConnection,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.MobileVoiceConnection=>"mobile_voice_connection",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The API version for webhooks.
/// </summary>
[JsonConverter(typeof(MobileVoiceConnectionWebhookApiVersionConverter))]
public enum MobileVoiceConnectionWebhookApiVersion
{
    V1, V2
}sealed class MobileVoiceConnectionWebhookApiVersionConverter : JsonConverter<MobileVoiceConnectionWebhookApiVersion>
{
    public override MobileVoiceConnectionWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>MobileVoiceConnectionWebhookApiVersion.V1,
            "2"=>MobileVoiceConnectionWebhookApiVersion.V2,
            _ =>(MobileVoiceConnectionWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobileVoiceConnectionWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobileVoiceConnectionWebhookApiVersion.V1=>"1",
            MobileVoiceConnectionWebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}