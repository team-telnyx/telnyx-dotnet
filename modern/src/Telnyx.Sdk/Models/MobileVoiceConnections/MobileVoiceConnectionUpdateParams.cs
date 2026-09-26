using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

/// <summary>
/// Update the settings of a specific mobile voice connection.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MobileVoiceConnectionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public bool? Active {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("active", value);
        }
    }

    public string? ConnectionName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connection_name", value);
        }
    }

    public MobileVoiceConnectionUpdateParamsInbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MobileVoiceConnectionUpdateParamsInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inbound", value);
        }
    }

    public MobileVoiceConnectionUpdateParamsOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MobileVoiceConnectionUpdateParamsOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("outbound", value);
        }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, MobileVoiceConnectionUpdateParamsWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MobileVoiceConnectionUpdateParamsWebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_api_version", value);
        }
    }

    public string? WebhookEventFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawBodyData.Set("webhook_event_failover_url", value); }
    }

    public string? WebhookEventUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init { this._rawBodyData.Set("webhook_event_url", value); }
    }

    public long? WebhookTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_timeout_secs", value);
        }
    }

    public MobileVoiceConnectionUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionUpdateParams (
        MobileVoiceConnectionUpdateParams mobileVoiceConnectionUpdateParams
    ) : base(mobileVoiceConnectionUpdateParams)
    {
        this.ID = mobileVoiceConnectionUpdateParams.ID;

        this._rawBodyData = new(mobileVoiceConnectionUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public MobileVoiceConnectionUpdateParams (
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
    MobileVoiceConnectionUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MobileVoiceConnectionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MobileVoiceConnectionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v2/mobile_voice_connections/{0}",
            EncodePathSegment(this.ID))
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

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionUpdateParamsInbound, MobileVoiceConnectionUpdateParamsInboundFromRaw>))]
public sealed record class MobileVoiceConnectionUpdateParamsInbound : JsonModel
{
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

    public MobileVoiceConnectionUpdateParamsInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionUpdateParamsInbound (
        MobileVoiceConnectionUpdateParamsInbound mobileVoiceConnectionUpdateParamsInbound
    ) : base(mobileVoiceConnectionUpdateParamsInbound)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionUpdateParamsInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionUpdateParamsInbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionUpdateParamsInboundFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionUpdateParamsInboundFromRaw : IFromRawJson<MobileVoiceConnectionUpdateParamsInbound>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionUpdateParamsInbound.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionUpdateParamsOutbound, MobileVoiceConnectionUpdateParamsOutboundFromRaw>))]
public sealed record class MobileVoiceConnectionUpdateParamsOutbound : JsonModel
{
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

    public MobileVoiceConnectionUpdateParamsOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionUpdateParamsOutbound (
        MobileVoiceConnectionUpdateParamsOutbound mobileVoiceConnectionUpdateParamsOutbound
    ) : base(mobileVoiceConnectionUpdateParamsOutbound)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionUpdateParamsOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionUpdateParamsOutbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionUpdateParamsOutboundFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionUpdateParamsOutboundFromRaw : IFromRawJson<MobileVoiceConnectionUpdateParamsOutbound>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionUpdateParamsOutbound.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MobileVoiceConnectionUpdateParamsWebhookApiVersionConverter))]
public enum MobileVoiceConnectionUpdateParamsWebhookApiVersion
{
    V1, V2
}

sealed class MobileVoiceConnectionUpdateParamsWebhookApiVersionConverter : JsonConverter<MobileVoiceConnectionUpdateParamsWebhookApiVersion>
{
    public override MobileVoiceConnectionUpdateParamsWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>MobileVoiceConnectionUpdateParamsWebhookApiVersion.V1,
            "2"=>MobileVoiceConnectionUpdateParamsWebhookApiVersion.V2,
            _ =>(MobileVoiceConnectionUpdateParamsWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MobileVoiceConnectionUpdateParamsWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MobileVoiceConnectionUpdateParamsWebhookApiVersion.V1=>"1",
            MobileVoiceConnectionUpdateParamsWebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}