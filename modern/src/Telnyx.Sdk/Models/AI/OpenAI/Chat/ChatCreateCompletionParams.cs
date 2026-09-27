using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Chat = Telnyx.Sdk.Models.AI.Chat;

namespace Telnyx.Sdk.Models.AI.OpenAI.Chat;

/// <summary>
/// Chat with a language model. This endpoint is consistent with the [OpenAI Chat
/// Completions API](https://platform.openai.com/docs/api-reference/chat) and may
/// be used with the OpenAI JS or Python SDK by setting the base URL to `https://api.telnyx.com/v2/ai/openai`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ChatCreateCompletionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A list of the previous chat messages for context.
    /// </summary>
    public required Generic::IReadOnlyList<Message> Messages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Message>>(
                "messages"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<Message>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If you are using an external inference provider like xAI or OpenAI, this field
    /// allows you to pass along a reference to your API key. After creating an [integration
    /// secret](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// for you API key, pass the secret's `identifier` in this field.
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
    /// This is used with `use_beam_search` to determine how many candidate beams
    /// to explore.
    /// </summary>
    public long? BestOf {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "best_of"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("best_of", value);
        }
    }

    /// <summary>
    /// This is used with `use_beam_search`. If `true`, generation stops as soon as
    /// there are `best_of` complete candidates; if `false`, a heuristic is applied
    /// and the generation stops when is it very unlikely to find better candidates.
    /// </summary>
    public bool? EarlyStopping {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "early_stopping"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("early_stopping", value);
        }
    }

    /// <summary>
    /// Whether to enable the thinking/reasoning phase for models that support it
    /// (e.g., QwQ, Qwen3). When set to false, the model will skip the internal reasoning
    /// step and respond directly, which can reduce latency. Defaults to true.
    /// </summary>
    public bool? EnableThinking {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "enable_thinking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("enable_thinking", value);
        }
    }

    /// <summary>
    /// Higher values will penalize the model from repeating the same output tokens.
    /// </summary>
    public double? FrequencyPenalty {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "frequency_penalty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("frequency_penalty", value);
        }
    }

    /// <summary>
    /// This is used with `use_beam_search` to prefer shorter or longer completions.
    /// </summary>
    public double? LengthPenalty {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "length_penalty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("length_penalty", value);
        }
    }

    /// <summary>
    /// Whether to return log probabilities of the output tokens or not. If true,
    /// returns the log probabilities of each output token returned in the `content`
    /// of `message`.
    /// </summary>
    public bool? Logprobs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "logprobs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("logprobs", value);
        }
    }

    /// <summary>
    /// Maximum number of completion tokens the model should generate.
    /// </summary>
    public long? MaxTokens {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_tokens"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_tokens", value);
        }
    }

    /// <summary>
    /// This is an alternative to `top_p` that [many prefer](https://github.com/huggingface/transformers/issues/27670).
    /// Must be in [0, 1].
    /// </summary>
    public double? MinP {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "min_p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("min_p", value);
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
    /// The language model to chat with.
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

    /// <summary>
    /// This will return multiple choices for you instead of a single chat completion.
    /// </summary>
    public double? N {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "n"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("n", value);
        }
    }

    /// <summary>
    /// Higher values will penalize the model from repeating the same output tokens.
    /// </summary>
    public double? PresencePenalty {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "presence_penalty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("presence_penalty", value);
        }
    }

    /// <summary>
    /// Controls the reasoning effort for models that support it. When set, the model
    /// spends more or less compute on internal reasoning before generating its response.
    /// Supported values: none, minimal, low, medium, high, xhigh, max. Not all models
    /// support all values; unsupported values are rejected with a 400 error. When
    /// omitted, reasoning models use their default effort level.
    /// </summary>
    public ApiEnum<string, ReasoningEffort>? ReasoningEffort {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ReasoningEffort>>(
                "reasoning_effort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("reasoning_effort", value);
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
    /// Controls the format of the model output. `json_object` guarantees valid JSON
    /// output without defining a schema; `json_schema` constrains the output to the
    /// JSON schema you supply via the `json_schema` property and is the supported
    /// way to get guaranteed structured output on Telnyx-hosted models.
    /// </summary>
    public ResponseFormat? ResponseFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ResponseFormat>(
                "response_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("response_format", value);
        }
    }

    /// <summary>
    /// If specified, the system will make a best effort to sample deterministically,
    /// such that repeated requests with the same `seed` and parameters should return
    /// the same result.
    /// </summary>
    public long? Seed {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "seed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("seed", value);
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
    /// Up to 4 sequences where the API will stop generating further tokens. The returned
    /// text will not contain the stop sequence.
    /// </summary>
    public Stop? Stop {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Stop>(
                "stop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stop", value);
        }
    }

    /// <summary>
    /// Whether or not to stream data-only server-sent events as they become available.
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
    /// Adjusts the "creativity" of the model. Lower values make the model more deterministic
    /// and repetitive, while higher values make the model more random and creative.
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

    public ApiEnum<string, ToolChoice>? ToolChoice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ToolChoice>>(
                "tool_choice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tool_choice", value);
        }
    }

    /// <summary>
    /// The `function` tool type follows the same schema as the [OpenAI Chat Completions
    /// API](https://platform.openai.com/docs/api-reference/chat). The `retrieval`
    /// tool type is unique to Telnyx. You may pass a list of [embedded storage buckets](https://developers.telnyx.com/api-reference/embeddings/embed-documents)
    /// for retrieval-augmented generation.
    /// </summary>
    public Generic::IReadOnlyList<Tool>? Tools {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Tool>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This is used with `logprobs`. An integer between 0 and 20 specifying the number
    /// of most likely tokens to return at each token position, each with an associated
    /// log probability.
    /// </summary>
    public long? TopLogprobs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "top_logprobs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("top_logprobs", value);
        }
    }

    /// <summary>
    /// An alternative or complement to `temperature`. This adjusts how many of the
    /// top possibilities to consider.
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

    /// <summary>
    /// Setting this to `true` will allow the model to [explore more completion options](https://huggingface.co/blog/how-to-generate#beam-search).
    /// This is not supported by OpenAI.
    /// </summary>
    public bool? UseBeamSearch {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "use_beam_search"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("use_beam_search", value);
        }
    }

    public ChatCreateCompletionParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCreateCompletionParams (
        ChatCreateCompletionParams chatCreateCompletionParams
    ) : base(chatCreateCompletionParams)
    { this._rawBodyData = new(chatCreateCompletionParams._rawBodyData); }
    #pragma warning restore CS8618

    public ChatCreateCompletionParams (
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
    ChatCreateCompletionParams (
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
    public static ChatCreateCompletionParams FromRawUnchecked(
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

    public virtual bool Equals(ChatCreateCompletionParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/openai/chat/completions"
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

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public required Content Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<string, Role> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        this.Role.Validate();
    }

    public Message ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message (Message message) : base(message)
    {  }
    #pragma warning restore CS8618

    public Message (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Message (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Message.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Content (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content (
        Generic::IReadOnlyList<TextAndImage> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Content (JsonElement element)
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
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>TextAndImage</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTextAndImageArray(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;TextAndImage&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTextAndImageArray(
        [NotNullWhen(true)] out Generic::IReadOnlyList<TextAndImage>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<TextAndImage> ;
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
///     (Generic::IReadOnlyList&lt;TextAndImage&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @contentString,
        System::Action<Generic::IReadOnlyList<TextAndImage>> textAndImageArray
    )
    {
        switch (this.Value)
        {
            case string value:
                @contentString(value);
                break;
            case Generic::IReadOnlyList<TextAndImage> value:
                textAndImageArray(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Content");

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
///     (Generic::IReadOnlyList&lt;TextAndImage&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @contentString,
        System::Func<Generic::IReadOnlyList<TextAndImage>, T> textAndImageArray
    )
    {
        return this.Value switch
        {
            string value=>@contentString(value),
            Generic::IReadOnlyList<TextAndImage> value=>textAndImageArray(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Content")
        } ;
    }

    public static implicit operator Content (string value)=> new(value) ;

    public static implicit operator Content (
        Generic::List<TextAndImage> value
    )=> new((Generic::IReadOnlyList<TextAndImage>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch((_) => {},
        (textAndImageArray) => {foreach (var item in textAndImageArray)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(Content? other)
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
        { string _=>0, Generic::IReadOnlyList<TextAndImage> _=>1, _ =>-1 } ;
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<TextAndImage>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Content value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<TextAndImage, TextAndImageFromRaw>))]
public sealed record class TextAndImage : JsonModel
{
    public required ApiEnum<string, global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ImageUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "image_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("image_url", value);
        }
    }

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
        this.Type.Validate();
        _ = this.ImageUrl;
        _ = this.Text;
    }

    public TextAndImage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextAndImage (TextAndImage textAndImage) : base(textAndImage)
    {  }
    #pragma warning restore CS8618

    public TextAndImage (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextAndImage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TextAndImageFromRaw.FromRawUnchecked"/>
    public static TextAndImage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TextAndImage (
        ApiEnum<string, global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type> type
    ) : this()
    { this.Type = type; }
}

class TextAndImageFromRaw : IFromRawJson<TextAndImage>
{
    /// <inheritdoc/>
    public TextAndImage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TextAndImage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Text, ImageUrl
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type>
{
    public override global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text"=>global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type.Text,
            "image_url"=>global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type.ImageUrl,
            _ =>(global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type.Text=>"text",
            global::Telnyx.Sdk.Models.AI.OpenAI.Chat.Type.ImageUrl=>"image_url",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    System, User, Assistant, Tool
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "system"=>Role.System,
            "user"=>Role.User,
            "assistant"=>Role.Assistant,
            "tool"=>Role.Tool,
            _ =>(Role)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Role value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Role.System=>"system",
            Role.User=>"user",
            Role.Assistant=>"assistant",
            Role.Tool=>"tool",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
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
/// Controls the reasoning effort for models that support it. When set, the model
/// spends more or less compute on internal reasoning before generating its response.
/// Supported values: none, minimal, low, medium, high, xhigh, max. Not all models
/// support all values; unsupported values are rejected with a 400 error. When omitted,
/// reasoning models use their default effort level.
/// </summary>
[JsonConverter(typeof(ReasoningEffortConverter))]
public enum ReasoningEffort
{
    None, Minimal, Low, Medium, High, Xhigh, Max
}

sealed class ReasoningEffortConverter : JsonConverter<ReasoningEffort>
{
    public override ReasoningEffort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>ReasoningEffort.None,
            "minimal"=>ReasoningEffort.Minimal,
            "low"=>ReasoningEffort.Low,
            "medium"=>ReasoningEffort.Medium,
            "high"=>ReasoningEffort.High,
            "xhigh"=>ReasoningEffort.Xhigh,
            "max"=>ReasoningEffort.Max,
            _ =>(ReasoningEffort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReasoningEffort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReasoningEffort.None=>"none",
            ReasoningEffort.Minimal=>"minimal",
            ReasoningEffort.Low=>"low",
            ReasoningEffort.Medium=>"medium",
            ReasoningEffort.High=>"high",
            ReasoningEffort.Xhigh=>"xhigh",
            ReasoningEffort.Max=>"max",
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
/// Controls the format of the model output. `json_object` guarantees valid JSON output
/// without defining a schema; `json_schema` constrains the output to the JSON schema
/// you supply via the `json_schema` property and is the supported way to get guaranteed
/// structured output on Telnyx-hosted models.
/// </summary>
[JsonConverter(typeof(ResponseFormatConverter))]
public record class ResponseFormat : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ResponseFormat (
        ResponseFormatText value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat (
        ResponseFormatJsonObject value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat (
        ResponseFormatJsonSchemaParam value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResponseFormat (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResponseFormatText"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickText(out var value)) {
///     // `value` is of type `ResponseFormatText`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickText([NotNullWhen(true)] out ResponseFormatText? value)
    {
        value =this.Value as ResponseFormatText ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResponseFormatJsonObject"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonObject(out var value)) {
///     // `value` is of type `ResponseFormatJsonObject`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonObject(
        [NotNullWhen(true)] out ResponseFormatJsonObject? value
    )
    {
        value =this.Value as ResponseFormatJsonObject ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResponseFormatJsonSchemaParam"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonSchemaParam(out var value)) {
///     // `value` is of type `ResponseFormatJsonSchemaParam`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonSchemaParam(
        [NotNullWhen(true)] out ResponseFormatJsonSchemaParam? value
    )
    {
        value =this.Value as ResponseFormatJsonSchemaParam ;
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
///     (ResponseFormatText value) =&gt; {...},
///     (ResponseFormatJsonObject value) =&gt; {...},
///     (ResponseFormatJsonSchemaParam value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ResponseFormatText> text,
        System::Action<ResponseFormatJsonObject> jsonObject,
        System::Action<ResponseFormatJsonSchemaParam> jsonSchemaParam
    )
    {
        switch (this.Value)
        {
            case ResponseFormatText value:
                text(value);
                break;
            case ResponseFormatJsonObject value:
                jsonObject(value);
                break;
            case ResponseFormatJsonSchemaParam value:
                jsonSchemaParam(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ResponseFormat");

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
///     (ResponseFormatText value) =&gt; {...},
///     (ResponseFormatJsonObject value) =&gt; {...},
///     (ResponseFormatJsonSchemaParam value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ResponseFormatText, T> text,
        System::Func<ResponseFormatJsonObject, T> jsonObject,
        System::Func<ResponseFormatJsonSchemaParam, T> jsonSchemaParam
    )
    {
        return this.Value switch
        {
            ResponseFormatText value=>text(value),
            ResponseFormatJsonObject value=>jsonObject(value),
            ResponseFormatJsonSchemaParam value=>jsonSchemaParam(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ResponseFormat")
        } ;
    }

    public static implicit operator ResponseFormat (
        ResponseFormatText value
    )=> new(value) ;

    public static implicit operator ResponseFormat (
        ResponseFormatJsonObject value
    )=> new(value) ;

    public static implicit operator ResponseFormat (
        ResponseFormatJsonSchemaParam value
    )=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of ResponseFormat");
        }
        this.Switch((text) => text.Validate(),
        (jsonObject) => jsonObject.Validate(),
        (jsonSchemaParam) => jsonSchemaParam.Validate());
    }

    public virtual bool Equals(ResponseFormat? other)
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
            ResponseFormatText _=>0,
            ResponseFormatJsonObject _=>1,
            ResponseFormatJsonSchemaParam _=>2,
            _ =>-1
        } ;
    }
}

sealed class ResponseFormatConverter : JsonConverter<ResponseFormat>
{
    public override ResponseFormat? Read(
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
            var deserialized = JsonSerializer.Deserialize<ResponseFormatText>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ResponseFormatJsonObject>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ResponseFormatJsonSchemaParam>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
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
        ResponseFormat value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Plain text output.
/// </summary>
[JsonConverter(typeof(ResponseFormatTextConverter))]
public record class ResponseFormatText
{
    public JsonElement Element { get; private init; }

    public ResponseFormatText ()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "text"
            }
            """
        );
    }

    internal ResponseFormatText (JsonElement element)
    { Element = element; }

    /// <summary>
/// Validates that the instance's underlying value is the expected constant.
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public void Validate()
    {
        if (this != new ResponseFormatText())
        {
            throw new TelnyxInvalidDataException("Invalid value given for 'ResponseFormatText'");
        }
    }

    public override int GetHashCode()
    { return 0; }

    public virtual bool Equals(ResponseFormatText? other)
    {
        if(other == null)
        {
            return false;
        }

        return JsonElementEquality.DeepEquals(this.Element, other.Element);
    }
}

class ResponseFormatTextConverter : JsonConverter<ResponseFormatText>
{
    public override ResponseFormatText? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(
            JsonSerializer.Deserialize<JsonElement>(ref reader, options)
        );
    }public override void Write(
        Utf8JsonWriter writer,
        ResponseFormatText value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Element, options); }
}

/// <summary>
/// JSON mode: the model output is valid JSON, without a schema.
/// </summary>
[JsonConverter(typeof(ResponseFormatJsonObjectConverter))]
public record class ResponseFormatJsonObject
{
    public JsonElement Element { get; private init; }

    public ResponseFormatJsonObject ()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "json_object"
            }
            """
        );
    }

    internal ResponseFormatJsonObject (JsonElement element)
    { Element = element; }

    /// <summary>
/// Validates that the instance's underlying value is the expected constant.
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public void Validate()
    {
        if (this != new ResponseFormatJsonObject())
        {
            throw new TelnyxInvalidDataException("Invalid value given for 'ResponseFormatJsonObject'");
        }
    }

    public override int GetHashCode()
    { return 0; }

    public virtual bool Equals(ResponseFormatJsonObject? other)
    {
        if(other == null)
        {
            return false;
        }

        return JsonElementEquality.DeepEquals(this.Element, other.Element);
    }
}

class ResponseFormatJsonObjectConverter : JsonConverter<ResponseFormatJsonObject>
{
    public override ResponseFormatJsonObject? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(
            JsonSerializer.Deserialize<JsonElement>(ref reader, options)
        );
    }public override void Write(
        Utf8JsonWriter writer,
        ResponseFormatJsonObject value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Element, options); }
}

/// <summary>
/// Structured output: the model output is constrained to the JSON schema supplied
/// in `json_schema`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ResponseFormatJsonSchemaParam, ResponseFormatJsonSchemaParamFromRaw>))]
public sealed record class ResponseFormatJsonSchemaParam : JsonModel
{
    /// <summary>
    /// The JSON schema configuration, required when `type` is `json_schema`. Matches
    /// the [OpenAI structured outputs](https://platform.openai.com/docs/guides/structured-outputs)
    /// `json_schema` response format.
    /// </summary>
    public required JsonSchema JsonSchema {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JsonSchema>(
                "json_schema"
            );
        }
        init { this._rawData.Set("json_schema", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.JsonSchema.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("json_schema")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public ResponseFormatJsonSchemaParam ()
    { this.Type = JsonSerializer.SerializeToElement("json_schema"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponseFormatJsonSchemaParam (
        ResponseFormatJsonSchemaParam responseFormatJsonSchemaParam
    ) : base(responseFormatJsonSchemaParam)
    {  }
    #pragma warning restore CS8618

    public ResponseFormatJsonSchemaParam (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("json_schema");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponseFormatJsonSchemaParam (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResponseFormatJsonSchemaParamFromRaw.FromRawUnchecked"/>
    public static ResponseFormatJsonSchemaParam FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ResponseFormatJsonSchemaParam (JsonSchema jsonSchema) : this()
    { this.JsonSchema = jsonSchema; }
}

class ResponseFormatJsonSchemaParamFromRaw : IFromRawJson<ResponseFormatJsonSchemaParam>
{
    /// <inheritdoc/>
    public ResponseFormatJsonSchemaParam FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResponseFormatJsonSchemaParam.FromRawUnchecked(rawData);
}

/// <summary>
/// The JSON schema configuration, required when `type` is `json_schema`. Matches
/// the [OpenAI structured outputs](https://platform.openai.com/docs/guides/structured-outputs)
/// `json_schema` response format.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JsonSchema, JsonSchemaFromRaw>))]
public sealed record class JsonSchema : JsonModel
{
    /// <summary>
    /// The name of the response format. Used for clarity only.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// A description of what the response format is for, typically used to guide
    /// the model.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The JSON schema the model output must conform to. A valid [JSON Schema](https://json-schema.org)
    /// object, e.g. a Pydantic `model_json_schema()` export.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Schema {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "schema"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Enables strict schema adherence when supported by the model. If the generated
    /// output does not match the provided schema, the request fails instead of returning
    /// non-conformant output.
    /// </summary>
    public bool? Strict {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "strict"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Schema;
        _ = this.Strict;
    }

    public JsonSchema ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JsonSchema (JsonSchema jsonSchema) : base(jsonSchema)
    {  }
    #pragma warning restore CS8618

    public JsonSchema (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JsonSchema (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JsonSchemaFromRaw.FromRawUnchecked"/>
    public static JsonSchema FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public JsonSchema (string name) : this()
    { this.Name = name; }
}

class JsonSchemaFromRaw : IFromRawJson<JsonSchema>
{
    /// <inheritdoc/>
    public JsonSchema FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JsonSchema.FromRawUnchecked(rawData);
}

/// <summary>
/// Up to 4 sequences where the API will stop generating further tokens. The returned
/// text will not contain the stop sequence.
/// </summary>
[JsonConverter(typeof(StopConverter))]
public record class Stop : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Stop (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Stop (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Stop (JsonElement element)
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
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Stop");

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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Stop")
        } ;
    }

    public static implicit operator Stop (string value)=> new(value) ;

    public static implicit operator Stop (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Stop");
        }
    }

    public virtual bool Equals(Stop? other)
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
        { string _=>0, Generic::IReadOnlyList<string> _=>1, _ =>-1 } ;
    }
}

sealed class StopConverter : JsonConverter<Stop>
{
    public override Stop? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
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
        Utf8JsonWriter writer, Stop value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(ToolChoiceConverter))]
public enum ToolChoice
{
    None, Auto, Required
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>ToolChoice.None,
            "auto"=>ToolChoice.Auto,
            "required"=>ToolChoice.Required,
            _ =>(ToolChoice)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ToolChoice value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToolChoice.None=>"none",
            ToolChoice.Auto=>"auto",
            ToolChoice.Required=>"required",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(ToolConverter))]
public record class Tool : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement Type {
        get { return Match(function: ( x )=>x.Type, retrieval: ( x )=>x.Type); }
    }

    public Tool (Function value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (Retrieval value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Function"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFunction(out var value)) {
///     // `value` is of type `Function`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFunction([NotNullWhen(true)] out Function? value)
    {
        value =this.Value as Function ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Retrieval"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRetrieval(out var value)) {
///     // `value` is of type `Retrieval`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRetrieval([NotNullWhen(true)] out Retrieval? value)
    {
        value =this.Value as Retrieval ;
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
///     (Function value) =&gt; {...},
///     (Retrieval value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Function> function, System::Action<Retrieval> retrieval
    )
    {
        switch (this.Value)
        {
            case Function value:
                function(value);
                break;
            case Retrieval value:
                retrieval(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Tool");

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
///     (Function value) =&gt; {...},
///     (Retrieval value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<Function, T> function, System::Func<Retrieval, T> retrieval)
    {
        return this.Value switch
        {
            Function value=>function(value),
            Retrieval value=>retrieval(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Tool")
        } ;
    }

    public static implicit operator Tool (Function value)=> new(value) ;

    public static implicit operator Tool (Retrieval value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch((function) => function.Validate(),
        (retrieval) => retrieval.Validate());
    }

    public virtual bool Equals(Tool? other)
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
        { Function _=>0, Retrieval _=>1, _ =>-1 } ;
    }
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "function":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Function>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "retrieval":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Retrieval>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new Tool(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Tool value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<Function, FunctionFromRaw>))]
public sealed record class Function : JsonModel
{
    public required FunctionDefinition FunctionValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionDefinition>(
                "function"
            );
        }
        init { this._rawData.Set("function", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FunctionValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("function")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Function ()
    { this.Type = JsonSerializer.SerializeToElement("function"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Function (Function function) : base(function)
    {  }
    #pragma warning restore CS8618

    public Function (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("function");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Function (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FunctionFromRaw.FromRawUnchecked"/>
    public static Function FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Function (FunctionDefinition functionValue) : this()
    { this.FunctionValue = functionValue; }
}

class FunctionFromRaw : IFromRawJson<Function>
{
    /// <inheritdoc/>
    public Function FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Function.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Retrieval, RetrievalFromRaw>))]
public sealed record class Retrieval : JsonModel
{
    public required Chat::BucketIds RetrievalValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Chat::BucketIds>(
                "retrieval"
            );
        }
        init { this._rawData.Set("retrieval", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.RetrievalValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("retrieval")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Retrieval ()
    { this.Type = JsonSerializer.SerializeToElement("retrieval"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Retrieval (Retrieval retrieval) : base(retrieval)
    {  }
    #pragma warning restore CS8618

    public Retrieval (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("retrieval");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Retrieval (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalFromRaw.FromRawUnchecked"/>
    public static Retrieval FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Retrieval (Chat::BucketIds retrievalValue) : this()
    { this.RetrievalValue = retrievalValue; }
}

class RetrievalFromRaw : IFromRawJson<Retrieval>
{
    /// <inheritdoc/>
    public Retrieval FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Retrieval.FromRawUnchecked(rawData);
}