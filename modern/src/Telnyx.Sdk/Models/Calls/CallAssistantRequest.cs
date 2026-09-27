using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Assistants = Telnyx.Sdk.Models.AI.Assistants;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// AI Assistant configuration. All fields except `id` are optional — the assistant's
/// stored configuration will be used as fallback for any omitted fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallAssistantRequest, CallAssistantRequestFromRaw>))]
public sealed record class CallAssistantRequest : JsonModel
{
    /// <summary>
    /// The identifier of the AI assistant to use.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Map of dynamic variables and their default values. Dynamic variables can be
    /// referenced in instructions, greeting, and tool definitions using the `{{variable_name}}`
    /// syntax. Call-control-agent automatically merges in `telnyx_call_*` variables
    /// (telnyx_call_to, telnyx_call_from, telnyx_conversation_channel, telnyx_agent_target,
    /// telnyx_end_user_target, telnyx_call_caller_id_name) and custom header variables.
    /// </summary>
    public IReadOnlyDictionary<string, DynamicVariable>? DynamicVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, DynamicVariable>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, DynamicVariable>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// External LLM configuration for bringing your own LLM endpoint.
    /// </summary>
    public ExternalLlm? ExternalLlm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalLlm>(
                "external_llm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_llm", value);
        }
    }

    /// <summary>
    /// Fallback LLM configuration used when the primary LLM provider is unavailable.
    /// </summary>
    public FallbackConfig? FallbackConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FallbackConfig>(
                "fallback_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fallback_config", value);
        }
    }

    /// <summary>
    /// Initial greeting text spoken when the assistant starts. Can be plain text
    /// for any voice or SSML for `AWS.Polly.&lt;voice_id&gt;` voices. There is a
    /// 3,000 character limit.
    /// </summary>
    public string? Greeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting", value);
        }
    }

    /// <summary>
    /// System instructions for the voice assistant. Can be templated with [dynamic
    /// variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables).
    /// This will overwrite the instructions set in the assistant configuration.
    /// </summary>
    public string? Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "instructions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("instructions", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the LLM provider API key. Use this field
    /// to reference an [integration secret](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// containing your LLM provider API key. Supports any LLM provider (OpenAI,
    /// Anthropic, etc.).
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// MCP (Model Context Protocol) server configurations for extending the assistant's
    /// capabilities with external tools and data sources.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? McpServers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "mcp_servers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// LLM model override for this call. If omitted, the assistant's configured model
    /// is used.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Assistant name override for this call.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Observability configuration for the assistant session, including Langfuse
    /// integration for tracing and monitoring.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ObservabilitySettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "observability_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "observability_settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Deprecated — use `llm_api_key_ref` instead. Integration secret identifier
    /// for the OpenAI API key. This field is maintained for backward compatibility;
    /// `llm_api_key_ref` is the canonical field name and supports all LLM providers.
    /// </summary>
    [System::Obsolete("This field is deprecated and will be removed soon")]
    public string? OpenAIApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "openai_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("openai_api_key_ref", value);
        }
    }

    /// <summary>
    /// Inline tool definitions available to the assistant (webhook, retrieval, transfer,
    /// hangup, etc.). Overrides the assistant's stored tools if provided.
    /// </summary>
    public IReadOnlyList<Tool>? Tools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tool>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Assistants::VoiceSettings? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Assistants::VoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (this.DynamicVariables != null)
        {
            foreach (var item in this.DynamicVariables.Values)
            {
                item.Validate();
            }
        }
        this.ExternalLlm?.Validate();
        this.FallbackConfig?.Validate();
        _ = this.Greeting;
        _ = this.Instructions;
        _ = this.LlmApiKeyRef;
        _ = this.McpServers;
        _ = this.Model;
        _ = this.Name;
        _ = this.ObservabilitySettings;
        _ = this.OpenAIApiKeyRef;
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
        this.VoiceSettings?.Validate();
    }

    public CallAssistantRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAssistantRequest (
        CallAssistantRequest callAssistantRequest
    ) : base(callAssistantRequest)
    {  }
    #pragma warning restore CS8618

    public CallAssistantRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAssistantRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAssistantRequestFromRaw.FromRawUnchecked"/>
    public static CallAssistantRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CallAssistantRequest (string id) : this()
    { this.ID = id; }
}

class CallAssistantRequestFromRaw : IFromRawJson<CallAssistantRequest>
{
    /// <inheritdoc/>
    public CallAssistantRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAssistantRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DynamicVariableConverter))]
public record class DynamicVariable : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public DynamicVariable (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DynamicVariable (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DynamicVariable (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DynamicVariable (JsonElement element)
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
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="bool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBool(out var value)) {
///     // `value` is of type `bool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value =this.Value as bool? ;
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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of DynamicVariable");

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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            double value=>@double(value),
            bool value=>@bool(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of DynamicVariable")
        } ;
    }

    public static implicit operator DynamicVariable (
        string value
    )=> new(value) ;

    public static implicit operator DynamicVariable (
        double value
    )=> new(value) ;

    public static implicit operator DynamicVariable (bool value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of DynamicVariable");
        }
    }

    public virtual bool Equals(DynamicVariable? other)
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
        { string _=>0, double _=>1, bool _=>2, _ =>-1 } ;
    }
}sealed class DynamicVariableConverter : JsonConverter<DynamicVariable>
{
    public override DynamicVariable? Read(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DynamicVariable value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// External LLM configuration for bringing your own LLM endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExternalLlm, ExternalLlmFromRaw>))]
public sealed record class ExternalLlm : JsonModel
{
    /// <summary>
    /// Authentication method used when connecting to the external LLM endpoint.
    /// </summary>
    public ApiEnum<string, AuthenticationMethod>? AuthenticationMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AuthenticationMethod>>(
                "authentication_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authentication_method", value);
        }
    }

    /// <summary>
    /// Base URL for the external LLM endpoint.
    /// </summary>
    public string? BaseUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "base_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("base_url", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the client certificate used with certificate authentication.
    /// </summary>
    public string? CertificateRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "certificate_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certificate_ref", value);
        }
    }

    /// <summary>
    /// When enabled, Telnyx forwards the assistant's dynamic variables to the external
    /// LLM endpoint. Defaults to false. The chat completion request includes a top-level
    /// `extra_metadata` object when dynamic variables are available. For example: `{"extra_metadata":{"customer_name":"Jane","account_id":"acct_789","telnyx_agent_target":"+13125550100","telnyx_end_user_target":"+13125550123"}}`.
    /// </summary>
    public bool? ForwardMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "forward_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("forward_metadata", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the external LLM API key.
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// Model identifier to use with the external LLM endpoint.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// URL used to retrieve an access token when certificate authentication is enabled.
    /// </summary>
    public string? TokenRetrievalUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token_retrieval_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_retrieval_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AuthenticationMethod?.Validate();
        _ = this.BaseUrl;
        _ = this.CertificateRef;
        _ = this.ForwardMetadata;
        _ = this.LlmApiKeyRef;
        _ = this.Model;
        _ = this.TokenRetrievalUrl;
    }

    public ExternalLlm ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalLlm (ExternalLlm externalLlm) : base(externalLlm)
    {  }
    #pragma warning restore CS8618

    public ExternalLlm (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalLlm (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalLlmFromRaw.FromRawUnchecked"/>
    public static ExternalLlm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ExternalLlmFromRaw : IFromRawJson<ExternalLlm>
{
    /// <inheritdoc/>
    public ExternalLlm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalLlm.FromRawUnchecked(rawData);
}/// <summary>
/// Authentication method used when connecting to the external LLM endpoint.
/// </summary>
[JsonConverter(typeof(AuthenticationMethodConverter))]
public enum AuthenticationMethod
{
    Token, Certificate
}sealed class AuthenticationMethodConverter : JsonConverter<AuthenticationMethod>
{
    public override AuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token"=>AuthenticationMethod.Token,
            "certificate"=>AuthenticationMethod.Certificate,
            _ =>(AuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AuthenticationMethod.Token=>"token",
            AuthenticationMethod.Certificate=>"certificate",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Fallback LLM configuration used when the primary LLM provider is unavailable.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FallbackConfig, FallbackConfigFromRaw>))]
public sealed record class FallbackConfig : JsonModel
{
    /// <summary>
    /// External LLM fallback configuration.
    /// </summary>
    public FallbackConfigExternalLlm? ExternalLlm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FallbackConfigExternalLlm>(
                "external_llm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_llm", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the fallback model API key.
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// Fallback Telnyx-hosted model to use when the primary LLM provider is unavailable.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExternalLlm?.Validate();
        _ = this.LlmApiKeyRef;
        _ = this.Model;
    }

    public FallbackConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FallbackConfig (FallbackConfig fallbackConfig) : base(fallbackConfig)
    {  }
    #pragma warning restore CS8618

    public FallbackConfig (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FallbackConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FallbackConfigFromRaw.FromRawUnchecked"/>
    public static FallbackConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FallbackConfigFromRaw : IFromRawJson<FallbackConfig>
{
    /// <inheritdoc/>
    public FallbackConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FallbackConfig.FromRawUnchecked(rawData);
}/// <summary>
/// External LLM fallback configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FallbackConfigExternalLlm, FallbackConfigExternalLlmFromRaw>))]
public sealed record class FallbackConfigExternalLlm : JsonModel
{
    /// <summary>
    /// Authentication method used when connecting to the external LLM endpoint.
    /// </summary>
    public ApiEnum<string, FallbackConfigExternalLlmAuthenticationMethod>? AuthenticationMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FallbackConfigExternalLlmAuthenticationMethod>>(
                "authentication_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authentication_method", value);
        }
    }

    /// <summary>
    /// Base URL for the external LLM endpoint.
    /// </summary>
    public string? BaseUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "base_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("base_url", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the client certificate used with certificate authentication.
    /// </summary>
    public string? CertificateRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "certificate_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certificate_ref", value);
        }
    }

    /// <summary>
    /// When enabled, Telnyx forwards the assistant's dynamic variables to the external
    /// LLM endpoint. Defaults to false. The chat completion request includes a top-level
    /// `extra_metadata` object when dynamic variables are available. For example: `{"extra_metadata":{"customer_name":"Jane","account_id":"acct_789","telnyx_agent_target":"+13125550100","telnyx_end_user_target":"+13125550123"}}`.
    /// </summary>
    public bool? ForwardMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "forward_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("forward_metadata", value);
        }
    }

    /// <summary>
    /// Integration secret identifier for the external LLM API key.
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// Model identifier to use with the external LLM endpoint.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// URL used to retrieve an access token when certificate authentication is enabled.
    /// </summary>
    public string? TokenRetrievalUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token_retrieval_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_retrieval_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AuthenticationMethod?.Validate();
        _ = this.BaseUrl;
        _ = this.CertificateRef;
        _ = this.ForwardMetadata;
        _ = this.LlmApiKeyRef;
        _ = this.Model;
        _ = this.TokenRetrievalUrl;
    }

    public FallbackConfigExternalLlm ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FallbackConfigExternalLlm (
        FallbackConfigExternalLlm fallbackConfigExternalLlm
    ) : base(fallbackConfigExternalLlm)
    {  }
    #pragma warning restore CS8618

    public FallbackConfigExternalLlm (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FallbackConfigExternalLlm (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FallbackConfigExternalLlmFromRaw.FromRawUnchecked"/>
    public static FallbackConfigExternalLlm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FallbackConfigExternalLlmFromRaw : IFromRawJson<FallbackConfigExternalLlm>
{
    /// <inheritdoc/>
    public FallbackConfigExternalLlm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FallbackConfigExternalLlm.FromRawUnchecked(rawData);
}/// <summary>
/// Authentication method used when connecting to the external LLM endpoint.
/// </summary>
[JsonConverter(typeof(FallbackConfigExternalLlmAuthenticationMethodConverter))]
public enum FallbackConfigExternalLlmAuthenticationMethod
{
    Token, Certificate
}sealed class FallbackConfigExternalLlmAuthenticationMethodConverter : JsonConverter<FallbackConfigExternalLlmAuthenticationMethod>
{
    public override FallbackConfigExternalLlmAuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token"=>FallbackConfigExternalLlmAuthenticationMethod.Token,
            "certificate"=>FallbackConfigExternalLlmAuthenticationMethod.Certificate,
            _ =>(FallbackConfigExternalLlmAuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FallbackConfigExternalLlmAuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FallbackConfigExternalLlmAuthenticationMethod.Token=>"token",
            FallbackConfigExternalLlmAuthenticationMethod.Certificate=>"certificate",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(ToolConverter))]
public record class Tool : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Tool (BookAppointmentTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (CheckAvailabilityTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (Assistants::WebhookTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (Assistants::HangupTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (Assistants::TransferTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (CallControlRetrievalTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="BookAppointmentTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBookAppointment(out var value)) {
///     // `value` is of type `BookAppointmentTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBookAppointment(
        [NotNullWhen(true)] out BookAppointmentTool? value
    )
    {
        value =this.Value as BookAppointmentTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CheckAvailabilityTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCheckAvailability(out var value)) {
///     // `value` is of type `CheckAvailabilityTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCheckAvailability(
        [NotNullWhen(true)] out CheckAvailabilityTool? value
    )
    {
        value =this.Value as CheckAvailabilityTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Assistants::WebhookTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhook(out var value)) {
///     // `value` is of type `Assistants::WebhookTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhook(
        [NotNullWhen(true)] out Assistants::WebhookTool? value
    )
    {
        value =this.Value as Assistants::WebhookTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Assistants::HangupTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHangup(out var value)) {
///     // `value` is of type `Assistants::HangupTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHangup(
        [NotNullWhen(true)] out Assistants::HangupTool? value
    )
    {
        value =this.Value as Assistants::HangupTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Assistants::TransferTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTransfer(out var value)) {
///     // `value` is of type `Assistants::TransferTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTransfer(
        [NotNullWhen(true)] out Assistants::TransferTool? value
    )
    {
        value =this.Value as Assistants::TransferTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallControlRetrievalTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallControlRetrieval(out var value)) {
///     // `value` is of type `CallControlRetrievalTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallControlRetrieval(
        [NotNullWhen(true)] out CallControlRetrievalTool? value
    )
    {
        value =this.Value as CallControlRetrievalTool ;
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
///     (BookAppointmentTool value) =&gt; {...},
///     (CheckAvailabilityTool value) =&gt; {...},
///     (Assistants::WebhookTool value) =&gt; {...},
///     (Assistants::HangupTool value) =&gt; {...},
///     (Assistants::TransferTool value) =&gt; {...},
///     (CallControlRetrievalTool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<BookAppointmentTool> bookAppointment,
        System::Action<CheckAvailabilityTool> checkAvailability,
        System::Action<Assistants::WebhookTool> webhook,
        System::Action<Assistants::HangupTool> hangup,
        System::Action<Assistants::TransferTool> transfer,
        System::Action<CallControlRetrievalTool> callControlRetrieval
    )
    {
        switch (this.Value)
        {
            case BookAppointmentTool value:
                bookAppointment(value);
                break;
            case CheckAvailabilityTool value:
                checkAvailability(value);
                break;
            case Assistants::WebhookTool value:
                webhook(value);
                break;
            case Assistants::HangupTool value:
                hangup(value);
                break;
            case Assistants::TransferTool value:
                transfer(value);
                break;
            case CallControlRetrievalTool value:
                callControlRetrieval(value);
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
///     (BookAppointmentTool value) =&gt; {...},
///     (CheckAvailabilityTool value) =&gt; {...},
///     (Assistants::WebhookTool value) =&gt; {...},
///     (Assistants::HangupTool value) =&gt; {...},
///     (Assistants::TransferTool value) =&gt; {...},
///     (CallControlRetrievalTool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<BookAppointmentTool, T> bookAppointment,
        System::Func<CheckAvailabilityTool, T> checkAvailability,
        System::Func<Assistants::WebhookTool, T> webhook,
        System::Func<Assistants::HangupTool, T> hangup,
        System::Func<Assistants::TransferTool, T> transfer,
        System::Func<CallControlRetrievalTool, T> callControlRetrieval
    )
    {
        return this.Value switch
        {
            BookAppointmentTool value=>bookAppointment(value),
            CheckAvailabilityTool value=>checkAvailability(value),
            Assistants::WebhookTool value=>webhook(value),
            Assistants::HangupTool value=>hangup(value),
            Assistants::TransferTool value=>transfer(value),
            CallControlRetrievalTool value=>callControlRetrieval(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Tool")
        } ;
    }

    public static implicit operator Tool (
        BookAppointmentTool value
    )=> new(value) ;

    public static implicit operator Tool (
        CheckAvailabilityTool value
    )=> new(value) ;

    public static implicit operator Tool (
        Assistants::WebhookTool value
    )=> new(value) ;

    public static implicit operator Tool (
        Assistants::HangupTool value
    )=> new(value) ;

    public static implicit operator Tool (
        Assistants::TransferTool value
    )=> new(value) ;

    public static implicit operator Tool (
        CallControlRetrievalTool value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch((bookAppointment) => bookAppointment.Validate(),
        (checkAvailability) => checkAvailability.Validate(),
        (webhook) => webhook.Validate(),
        (hangup) => hangup.Validate(),
        (transfer) => transfer.Validate(),
        (callControlRetrieval) => callControlRetrieval.Validate());
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
        {
            BookAppointmentTool _=>0,
            CheckAvailabilityTool _=>1,
            Assistants::WebhookTool _=>2,
            Assistants::HangupTool _=>3,
            Assistants::TransferTool _=>4,
            CallControlRetrievalTool _=>5,
            _ =>-1
        } ;
    }
}sealed class ToolConverter : JsonConverter<Tool>
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
            case "book_appointment":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BookAppointmentTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "check_availability":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CheckAvailabilityTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "webhook":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Assistants::WebhookTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "hangup":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Assistants::HangupTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "transfer":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Assistants::TransferTool>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<CallControlRetrievalTool>(element, options);
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