using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Anthropic.V1;

/// <summary>
/// Send a message to a language model using the Anthropic Messages API format. This
/// endpoint is compatible with the [Anthropic Messages API](https://docs.anthropic.com/en/api/messages)
/// and may be used with the Anthropic JS or Python SDK by setting the base URL to `https://api.telnyx.com/v2/ai/anthropic`.
///
/// <para>The endpoint translates Anthropic-format requests into Telnyx's inference
/// internals, then translates the response back to the Anthropic message shape. Streaming
/// responses use Anthropic SSE event types (`message_start`, `content_block_start`,
/// `content_block_delta`, `content_block_stop`, `message_delta`, `message_stop`).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1MessagesParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The maximum number of tokens to generate in the response.
    /// </summary>
    public required long MaxTokens {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "max_tokens"
            );
        }
        init { this._rawBodyData.Set("max_tokens", value); }
    }

    /// <summary>
    /// The messages to send to the model, following the [Anthropic Messages API](https://docs.anthropic.com/en/api/messages) format.
    /// </summary>
    public required Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> Messages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "messages"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "messages",
                ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// The model to use for generating the response, for example `zai-org/GLM-5.3-Flash`
    /// or another model available from the Telnyx models endpoint.
    /// </summary>
    public required string Model {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// If you are using an external inference provider, this field allows you to
    /// pass along a reference to your API key. After creating an [integration secret](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// for your API key, pass the secret's `identifier` in this field.
    /// </summary>
    public string? ApiKeyRef {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("api_key_ref", value);
        }
    }

    /// <summary>
    /// The billing group ID to associate with this request.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Configuration for model fallback behavior when the primary model is unavailable.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? FallbackConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "fallback_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "fallback_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Maximum number of retries for the request.
    /// </summary>
    public long? MaxRetries {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_retries"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_retries", value);
        }
    }

    /// <summary>
    /// List of MCP (Model Context Protocol) servers to make available to the model.
    /// </summary>
    public Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? McpServers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "mcp_servers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// An object describing metadata about the request.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
    /// use the Telnyx models endpoint and inspect the model's `service_tiers` field.
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
    /// Custom sequences that will cause the model to stop generating.
    /// </summary>
    public Generic::IReadOnlyList<string>? StopSequences {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "stop_sequences"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "stop_sequences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to stream the response as Anthropic-format Server-Sent Events.
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

    /// <summary>
    /// System prompt. Can be a string or an array of content blocks following the
    /// Anthropic API format.
    /// </summary>
    public V1MessagesParamsSystem? System {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<V1MessagesParamsSystem>(
                "system"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("system", value);
        }
    }

    /// <summary>
    /// Amount of randomness injected into the response. Ranges from 0 to 1.
    /// </summary>
    public double? Temperature {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "temperature"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("temperature", value);
        }
    }

    /// <summary>
    /// Extended thinking configuration for models that support it. Set `type` to
    /// `enabled` to turn on extended thinking.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Thinking {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "thinking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "thinking",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Request timeout in seconds.
    /// </summary>
    public double? Timeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout", value);
        }
    }

    /// <summary>
    /// Controls how the model uses tools, following the Anthropic API format.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? ToolChoice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "tool_choice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "tool_choice",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Definitions of tools that the model may use, following the Anthropic API format.
    /// </summary>
    public Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? Tools {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// Top-k sampling parameter. Only sample from the top K options for each subsequent token.
    /// </summary>
    public long? TopK {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "top_k"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("top_k", value);
        }
    }

    /// <summary>
    /// Nucleus sampling parameter. Use temperature or top_p, but not both.
    /// </summary>
    public double? TopP {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "top_p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("top_p", value);
        }
    }

    public V1MessagesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1MessagesParams (V1MessagesParams v1MessagesParams) : base(
        v1MessagesParams
    )
    { this._rawBodyData = new(v1MessagesParams._rawBodyData); }
    #pragma warning restore CS8618

    public V1MessagesParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V1MessagesParams (
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
    public static V1MessagesParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(V1MessagesParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/anthropic/v1/messages"
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

/// <summary>
/// System prompt. Can be a string or an array of content blocks following the Anthropic
/// API format.
/// </summary>
[JsonConverter(typeof(V1MessagesParamsSystemConverter))]
public record class V1MessagesParamsSystem : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public V1MessagesParamsSystem (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public V1MessagesParamsSystem (
        Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)));
        this._element = element;
    }

    public V1MessagesParamsSystem (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>Generic::Dictionary&lt;string, JsonElement&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>> jsonElements
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of V1MessagesParamsSystem");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>, T> jsonElements
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value=>jsonElements(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of V1MessagesParamsSystem")
        } ;
    }

    public static implicit operator V1MessagesParamsSystem (
        string value
    )=> new(value) ;

    public static implicit operator V1MessagesParamsSystem (
        Generic::List<Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of V1MessagesParamsSystem");
        }
    }

    public virtual bool Equals(V1MessagesParamsSystem? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            string _=>0,
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> _=>1,
            _ =>-1
        } ;
    }
}

sealed class V1MessagesParamsSystemConverter : JsonConverter<V1MessagesParamsSystem>
{
    public override V1MessagesParamsSystem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1MessagesParamsSystem value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}