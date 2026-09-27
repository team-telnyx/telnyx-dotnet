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

namespace Telnyx.Sdk.Models.AI.OpenAI;

/// <summary>
/// Create a response using Telnyx's OpenAI-compatible Responses API. This endpoint
/// is compatible with the [OpenAI Responses API](https://developers.openai.com/api/reference/responses/overview)
/// and may be used with the OpenAI JS or Python SDK by setting the base URL to `https://api.telnyx.com/v2/ai/openai`.
///
/// <para>The `conversation` parameter refers to a Telnyx Conversation rather than
/// an OpenAI-hosted conversation object. To persist a thread across turns, first
/// [create a conversation](https://developers.telnyx.com/api-reference/conversations/create-a-conversation)
/// with `POST /ai/conversations`, then pass that conversation's `id` in the Responses
/// request as `conversation`. The endpoint appends the new input, assistant output,
/// reasoning, and tool-call messages to that conversation. Reuse the same `conversation`
/// id on subsequent Responses requests, including tool-result followups, so the model
/// receives the prior context.</para>
///
/// <para>If `conversation` is omitted, the request is processed without persisting
/// messages to a Telnyx conversation. Use the Conversations API to manage history:
/// [list conversations](https://developers.telnyx.com/api-reference/conversations/list-conversations)
/// (optionally filtered by metadata), [fetch messages](https://developers.telnyx.com/api-reference/conversations/get-conversation-messages)
/// for a conversation, and optionally [add messages](https://developers.telnyx.com/api-reference/conversations/create-message)
/// outside the Responses flow.</para>
///
/// <para>You can attach arbitrary metadata when creating a conversation (for example
/// to tag the conversation's source, channel, or user) and later filter by it when
/// listing conversations.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OpenAICreateResponseParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Optional Telnyx Conversation ID from `POST /ai/conversations`. When provided,
    /// Telnyx stores this turn on that conversation and uses the conversation's
    /// prior messages as context. Reuse the same ID for subsequent turns and tool-result
    /// followups. Omit it for a non-persisted, stateless response.
    /// </summary>
    public string? Conversation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "conversation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation", value);
        }
    }

    /// <summary>
    /// The input items for this turn, using the OpenAI Responses API input format.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Input {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "input"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "input",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional system/developer instructions for the model. When used with a persisted
    /// `conversation`, send these on the first request that creates the thread;
    /// subsequent turns can rely on the stored history.
    /// </summary>
    public string? Instructions {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "instructions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("instructions", value);
        }
    }

    /// <summary>
    /// How strictly `region` is applied. `preferred` (the default when `region`
    /// is set) tries that region first and falls back to another when the model
    /// cannot be served there, so a request that would have succeeded still succeeds.
    /// `strict` pins the request: it is served from that region or it fails with
    /// a 422, never redirected to another region. Requires `region`.
    /// </summary>
    public ApiEnum<string, Mode>? Mode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Mode>>(
                "mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mode", value);
        }
    }

    /// <summary>
    /// Model identifier to use for the response, for example `zai-org/GLM-5.1-FP8`
    /// or another model available from the Telnyx OpenAI-compatible models endpoint.
    /// </summary>
    public string? Model {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    public Reasoning? Reasoning {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Reasoning>(
                "reasoning"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("reasoning", value);
        }
    }

    /// <summary>
    /// Optional data-residency region the request should be served from, using the
    /// same vocabulary as your account's Data Locality setting. Behavior depends
    /// on `mode`. Supported for Telnyx-hosted models only: a request routed to an
    /// external provider never passes through Telnyx model routing, so a region
    /// cannot be enforced for it. Omit for today's latency-based routing.
    /// </summary>
    public ApiEnum<string, Region>? Region {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Region>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("region", value);
        }
    }

    /// <summary>
    /// The service tier to use for this request. Supported values vary by model;
    /// use `GET /v2/ai/openai/models` and inspect the model's `service_tiers` field.
    /// If omitted, Telnyx-hosted models use `default`.
    /// </summary>
    public string? ServiceTier {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "service_tier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("service_tier", value);
        }
    }

    /// <summary>
    /// Set to `true` to stream Server-Sent Events, matching OpenAI's Responses streaming format.
    /// </summary>
    public bool? Stream {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "stream"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream", value);
        }
    }

    public OpenAICreateResponseParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OpenAICreateResponseParams (
        OpenAICreateResponseParams openaiCreateResponseParams
    ) : base(openaiCreateResponseParams)
    { this._rawBodyData = new(openaiCreateResponseParams._rawBodyData); }
    #pragma warning restore CS8618

    public OpenAICreateResponseParams (
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
    OpenAICreateResponseParams (
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
    public static OpenAICreateResponseParams FromRawUnchecked(
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

    public virtual bool Equals(OpenAICreateResponseParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/openai/responses"
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
/// How strictly `region` is applied. `preferred` (the default when `region` is set)
/// tries that region first and falls back to another when the model cannot be served
/// there, so a request that would have succeeded still succeeds. `strict` pins the
/// request: it is served from that region or it fails with a 422, never redirected
/// to another region. Requires `region`.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Preferred, Strict
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "preferred"=>Mode.Preferred, "strict"=>Mode.Strict, _ =>(Mode)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Mode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Mode.Preferred=>"preferred",
            Mode.Strict=>"strict",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Reasoning, ReasoningFromRaw>))]
public sealed record class Reasoning : JsonModel
{
    /// <summary>
    /// Controls the reasoning effort for models that support it. Same values and
    /// semantics as reasoning_effort on Chat Completions.
    /// </summary>
    public ApiEnum<string, Effort>? Effort {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Effort>>(
                "effort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("effort", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Effort?.Validate(); }

    public Reasoning ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reasoning (Reasoning reasoning) : base(reasoning)
    {  }
    #pragma warning restore CS8618

    public Reasoning (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Reasoning (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReasoningFromRaw.FromRawUnchecked"/>
    public static Reasoning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReasoningFromRaw : IFromRawJson<Reasoning>
{
    /// <inheritdoc/>
    public Reasoning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Reasoning.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls the reasoning effort for models that support it. Same values and semantics
/// as reasoning_effort on Chat Completions.
/// </summary>
[JsonConverter(typeof(EffortConverter))]
public enum Effort
{
    None, Minimal, Low, Medium, High, Xhigh, Max
}

sealed class EffortConverter : JsonConverter<Effort>
{
    public override Effort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>Effort.None,
            "minimal"=>Effort.Minimal,
            "low"=>Effort.Low,
            "medium"=>Effort.Medium,
            "high"=>Effort.High,
            "xhigh"=>Effort.Xhigh,
            "max"=>Effort.Max,
            _ =>(Effort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Effort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Effort.None=>"none",
            Effort.Minimal=>"minimal",
            Effort.Low=>"low",
            Effort.Medium=>"medium",
            Effort.High=>"high",
            Effort.Xhigh=>"xhigh",
            Effort.Max=>"max",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Optional data-residency region the request should be served from, using the same
/// vocabulary as your account's Data Locality setting. Behavior depends on `mode`.
/// Supported for Telnyx-hosted models only: a request routed to an external provider
/// never passes through Telnyx model routing, so a region cannot be enforced for
/// it. Omit for today's latency-based routing.
/// </summary>
[JsonConverter(typeof(RegionConverter))]
public enum Region
{
    Usa, Eu, Aus, Uae
}

sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USA"=>Region.Usa,
            "EU"=>Region.Eu,
            "AUS"=>Region.Aus,
            "UAE"=>Region.Uae,
            _ =>(Region)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Region value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Region.Usa=>"USA",
            Region.Eu=>"EU",
            Region.Aus=>"AUS",
            Region.Uae=>"UAE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}