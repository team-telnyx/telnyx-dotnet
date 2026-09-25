using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Updates the specified AI assistant's attributes and returns the updated assistant.
/// The request can also control how the change is promoted across assistant versions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AssistantUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AssistantID { get; init; }

    /// <summary>
    /// A2A agents this assistant can delegate to. Tools are not stored here: at the
    /// start of every conversation each agent's card is fetched and one tool is derived
    /// per skill the card advertises, named `a2a_&lt;name&gt;_&lt;skill_id&gt;`.
    /// The following limits are not enforced when the assistant is saved, and anything
    /// past them is dropped when the conversation starts: 64 agents per assistant,
    /// 64 skills per card, 128 derived tools per assistant, and a 6 second budget
    /// for all card fetches combined. An agent whose card cannot be fetched costs
    /// the assistant that capability for the conversation; it does not fail the call.
    /// Omit this field to leave the assistant's agents unchanged; send an empty
    /// array to remove them all.
    /// </summary>
    public IReadOnlyList<AssistantA2AAgent>? A2aAgents {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AssistantA2AAgent>>(
                "a2a_agents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AssistantA2AAgent>?>(
                "a2a_agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Conversation flow as supplied by API clients (create / update).
    ///
    /// <para>A directed graph of `FlowNodeReq` connected by `FlowEdge`s. Validation
    /// enforces unique node/edge IDs, that `start_node_id` references a real node,
    /// and that every edge's endpoints reference real nodes.</para>
    /// </summary>
    public ConversationFlowReq? ConversationFlow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConversationFlowReq>(
                "conversation_flow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_flow", value);
        }
    }

    public string? Description {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Map of dynamic variables and their default values
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? DynamicVariables {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Timeout in milliseconds for the dynamic variables webhook. Must be between
    /// 1 and 10000 ms. If the webhook does not respond within this timeout, the call
    /// proceeds with default values. See the [dynamic variables guide](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables).
    /// </summary>
    public long? DynamicVariablesWebhookTimeoutMs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "dynamic_variables_webhook_timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dynamic_variables_webhook_timeout_ms", value);
        }
    }

    /// <summary>
    /// If `dynamic_variables_webhook_url` is set, Telnyx sends a POST request to
    /// this URL at the start of the conversation to resolve dynamic variables. **Gotcha:**
    /// the webhook response must wrap variables under a top-level `dynamic_variables`
    /// object, e.g. `{"dynamic_variables": {"customer_name": "Jane"}}`. Returning
    /// a flat object will be ignored and variables will fall back to their defaults.
    /// See the [dynamic variables guide](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
    /// for the full request/response format and timeout behavior.
    /// </summary>
    public string? DynamicVariablesWebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "dynamic_variables_webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dynamic_variables_webhook_url", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, EnabledFeatures>>? EnabledFeatures {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, EnabledFeatures>>>(
                "enabled_features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, EnabledFeatures>>?>(
                "enabled_features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ExternalLlmReq? ExternalLlm {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ExternalLlmReq>(
                "external_llm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("external_llm", value);
        }
    }

    public FallbackConfigReq? FallbackConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FallbackConfigReq>(
                "fallback_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("fallback_config", value);
        }
    }

    /// <summary>
    /// Text that the assistant will use to start the conversation. This may be templated
    /// with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables).
    /// Use an empty string to have the assistant wait for the user to speak first.
    /// Use the special value `&lt;assistant-speaks-first-with-model-generated-message&gt;`
    /// to have the assistant generate the greeting based on the system instructions.
    /// </summary>
    public string? Greeting {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("greeting", value);
        }
    }

    public InsightSettings? InsightSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InsightSettings>(
                "insight_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("insight_settings", value);
        }
    }

    /// <summary>
    /// System instructions for the assistant. These may be templated with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
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
    /// Connected integrations attached to the assistant. The catalog of available
    /// integrations is at `/ai/integrations`; the user's connected integrations
    /// are at `/ai/integrations/connections`. Each item references a catalog integration
    /// by `integration_id`.
    /// </summary>
    public IReadOnlyList<AssistantIntegration>? Integrations {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AssistantIntegration>>(
                "integrations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AssistantIntegration>?>(
                "integrations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Settings for interruptions and how the assistant decides the user has finished
    /// speaking. These timings are most relevant when using non turn-taking transcription
    /// models. For turn-taking models like `deepgram/flux`, end-of-turn behavior
    /// is controlled by the transcription end-of-turn settings under `transcription.settings`
    /// (`eot_threshold`, `eot_timeout_ms`, `eager_eot_threshold`).
    /// </summary>
    public InferenceEmbeddingInterruptionSettings? InterruptionSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InferenceEmbeddingInterruptionSettings>(
                "interruption_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("interruption_settings", value);
        }
    }

    /// <summary>
    /// This is only needed when using third-party inference providers selected by
    /// `model`. The `identifier` for an integration secret [/v2/integration_secrets](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// that refers to your LLM provider's API key. For bring-your-own endpoint authentication,
    /// use `external_llm.llm_api_key_ref` instead. Warning: Free plans are unlikely
    /// to work with this integration.
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// MCP servers attached to the assistant. Create MCP servers with `/ai/mcp_servers`,
    /// then reference them by `id` here.
    /// </summary>
    public IReadOnlyList<AssistantMcpServer>? McpServers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AssistantMcpServer>>(
                "mcp_servers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AssistantMcpServer>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingSettings? MessagingSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MessagingSettings>(
                "messaging_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("messaging_settings", value);
        }
    }

    /// <summary>
    /// ID of the model to use when `external_llm` is not set. You can use the [Get
    /// models API](https://developers.telnyx.com/api-reference/openai-chat/get-available-models-openai-compatible)
    /// to see available models. If `external_llm` is provided, the assistant uses
    /// `external_llm` instead of this field. If neither `model` nor `external_llm`
    /// is provided, Telnyx applies the default model.
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

    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public ObservabilityReq? ObservabilitySettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ObservabilityReq>(
                "observability_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("observability_settings", value);
        }
    }

    /// <summary>
    /// Configuration for post-conversation processing. When enabled, the assistant
    /// receives one additional LLM turn after the conversation ends, allowing it
    /// to execute final tool calls such as sending a summary or updating a record
    /// via webhook or function tools. Integration and MCP server tools are not available
    /// post-conversation; call-control tools (e.g. hangup, transfer) are also unavailable.
    /// Beta feature.
    /// </summary>
    public PostConversationSettingsReq? PostConversationSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PostConversationSettingsReq>(
                "post_conversation_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("post_conversation_settings", value);
        }
    }

    public PrivacySettings? PrivacySettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PrivacySettings>(
                "privacy_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("privacy_settings", value);
        }
    }

    /// <summary>
    /// Indicates whether the assistant should be promoted to the main version. Defaults
    /// to true.
    /// </summary>
    public bool? PromoteToMain {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "promote_to_main"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("promote_to_main", value);
        }
    }

    /// <summary>
    /// Tags associated with the assistant. Tags can also be managed with the assistant
    /// tag endpoints.
    /// </summary>
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

    public TelephonySettings? TelephonySettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TelephonySettings>(
                "telephony_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("telephony_settings", value);
        }
    }

    /// <summary>
    /// IDs of shared tools to attach to the assistant. New integrations should prefer
    /// `tool_ids` over inline `tools`. On update, a sent `tool_ids` array fully
    /// replaces the assistant's attached shared tools; omit the field to leave them
    /// unchanged. Single-instance tool types are counted across inline `tools` and
    /// `tool_ids` combined, so attaching a shared tool of such a type when an instance
    /// already exists returns HTTP 400 with error code 10015.
    /// </summary>
    public IReadOnlyList<string>? ToolIds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tool_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tool_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Deprecated for new integrations. Inline tool definitions available to the
    /// assistant. Prefer `tool_ids` to attach shared tools created with the AI Tools
    /// endpoints. On update, a sent `tools` array fully replaces the assistant's
    /// inline tools; omit the field to leave the inline tools unchanged. Each tool
    /// type except `function`, `webhook`, and `client_side_tool` allows at most one
    /// instance per assistant, counted across inline `tools` and shared `tool_ids`
    /// combined — sending a duplicate of such a type returns HTTP 400 with error
    /// code 10015. Responses merge shared tools into `tools` with `shared: true`;
    /// when updating, omit those tools from the `tools` array and manage them through
    /// `tool_ids` instead.
    /// </summary>
    public IReadOnlyList<AssistantTool>? Tools {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AssistantTool>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AssistantTool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public TranscriptionSettings? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TranscriptionSettings>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription", value);
        }
    }

    /// <summary>
    /// Human-readable name for the assistant version.
    /// </summary>
    public string? VersionName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "version_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("version_name", value);
        }
    }

    public InferenceEmbeddingVoiceSettings? VoiceSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InferenceEmbeddingVoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice_settings", value);
        }
    }

    /// <summary>
    /// Configuration settings for the assistant's web widget.
    /// </summary>
    public WidgetSettings? WidgetSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<WidgetSettings>(
                "widget_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("widget_settings", value);
        }
    }

    public AssistantUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantUpdateParams (
        AssistantUpdateParams assistantUpdateParams
    ) : base(assistantUpdateParams)
    {
        this.AssistantID = assistantUpdateParams.AssistantID;

        this._rawBodyData = new(assistantUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AssistantUpdateParams (
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
    AssistantUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AssistantID = assistantID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AssistantUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            assistantID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AssistantID"] = JsonSerializer.SerializeToElement(this.AssistantID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AssistantUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AssistantID?.Equals(other.AssistantID) ?? other.AssistantID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/assistants/{0}",
            this.AssistantID)
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