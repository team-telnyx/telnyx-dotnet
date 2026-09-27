using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Text = System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages.Rcs;

/// <summary>
/// Queues an outbound RCS message through the selected RCS agent. Check recipient
/// capabilities before sending features that require RCS support.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RcSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// RCS Agent ID
    /// </summary>
    public required string AgentID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "agent_id"
            );
        }
        init { this._rawBodyData.Set("agent_id", value); }
    }

    public required RcsAgentMessage AgentMessage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<RcsAgentMessage>(
                "agent_message"
            );
        }
        init { this._rawBodyData.Set("agent_message", value); }
    }

    /// <summary>
    /// A valid messaging profile ID
    /// </summary>
    public required string MessagingProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawBodyData.Set("messaging_profile_id", value); }
    }

    /// <summary>
    /// Phone number in +E.164 format
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    public MmsFallback? MmsFallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MmsFallback>(
                "mms_fallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mms_fallback", value);
        }
    }

    public SmsFallback? SmsFallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SmsFallback>(
                "sms_fallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sms_fallback", value);
        }
    }

    /// <summary>
    /// Message type - must be set to "RCS"
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Messages.Rcs.Type>? Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Messages.Rcs.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    /// <summary>
    /// The URL where webhooks related to this message will be sent.
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

    public RcSendParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcSendParams (RcSendParams rcSendParams) : base(rcSendParams)
    { this._rawBodyData = new(rcSendParams._rawBodyData); }
    #pragma warning restore CS8618

    public RcSendParams (
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
    RcSendParams (
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
    public static RcSendParams FromRawUnchecked(
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

    public virtual bool Equals(RcSendParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/messages/rcs"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Text::Encoding.UTF8,
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

[JsonConverter(typeof(JsonModelConverter<MmsFallback, MmsFallbackFromRaw>))]
public sealed record class MmsFallback : JsonModel
{
    /// <summary>
    /// Phone number in +E.164 format
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// List of media URLs
    /// </summary>
    public IReadOnlyList<string>? MediaUrls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "media_urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "media_urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Subject of the message
    /// </summary>
    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subject", value);
        }
    }

    /// <summary>
    /// Text
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        _ = this.MediaUrls;
        _ = this.Subject;
        _ = this.Text;
    }

    public MmsFallback ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MmsFallback (MmsFallback mmsFallback) : base(mmsFallback)
    {  }
    #pragma warning restore CS8618

    public MmsFallback (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MmsFallback (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MmsFallbackFromRaw.FromRawUnchecked"/>
    public static MmsFallback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MmsFallbackFromRaw : IFromRawJson<MmsFallback>
{
    /// <inheritdoc/>
    public MmsFallback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MmsFallback.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SmsFallback, SmsFallbackFromRaw>))]
public sealed record class SmsFallback : JsonModel
{
    /// <summary>
    /// Phone number in +E.164 format
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// Text (maximum 3072 characters)
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        _ = this.Text;
    }

    public SmsFallback ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SmsFallback (SmsFallback smsFallback) : base(smsFallback)
    {  }
    #pragma warning restore CS8618

    public SmsFallback (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SmsFallback (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SmsFallbackFromRaw.FromRawUnchecked"/>
    public static SmsFallback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SmsFallbackFromRaw : IFromRawJson<SmsFallback>
{
    /// <inheritdoc/>
    public SmsFallback FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SmsFallback.FromRawUnchecked(rawData);
}

/// <summary>
/// Message type - must be set to "RCS"
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Rcs
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Messages.Rcs.Type>
{
    public override global::Telnyx.Sdk.Models.Messages.Rcs.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RCS"=>global::Telnyx.Sdk.Models.Messages.Rcs.Type.Rcs,
            _ =>(global::Telnyx.Sdk.Models.Messages.Rcs.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Messages.Rcs.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Messages.Rcs.Type.Rcs=>"RCS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}