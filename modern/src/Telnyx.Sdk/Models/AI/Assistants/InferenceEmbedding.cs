using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<InferenceEmbedding, InferenceEmbeddingFromRaw>))]
public sealed record class InferenceEmbedding : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// System instructions for the assistant. These may be templated with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
    /// </summary>
    public required string Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// ID of the model to use when `external_llm` is not set. You can use the [Get
    /// models API](https://developers.telnyx.com/api-reference/openai-chat/get-available-models-openai-compatible)
    /// to see available models. If `external_llm` is provided, the assistant uses
    /// `external_llm` instead of this field. If neither `model` nor `external_llm`
    /// is provided, Telnyx applies the default model.
    /// </summary>
    public required string Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

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
    /// A2A agents this assistant can delegate to. Tools are not stored here: at the
    /// start of every conversation each agent's card is fetched and one tool is derived
    /// per skill the card advertises, named `a2a_&lt;name&gt;_&lt;skill_id&gt;`.
    /// The following limits are not enforced when the assistant is saved, and anything
    /// past them is dropped when the conversation starts: 64 agents per assistant,
    /// 64 skills per card, 128 derived tools per assistant, and a 6 second budget
    /// for all card fetches combined. An agent whose card cannot be fetched costs
    /// the assistant that capability for the conversation; it does not fail the call.
    /// </summary>
    public IReadOnlyList<AssistantA2AAgent>? A2aAgents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AssistantA2AAgent>>(
                "a2a_agents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AssistantA2AAgent>?>(
                "a2a_agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Conversation flow as returned by the API.
    /// </summary>
    public ConversationFlow? ConversationFlow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationFlow>(
                "conversation_flow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_flow", value);
        }
    }

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
    /// Map of dynamic variables and their values
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? DynamicVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "dynamic_variables_webhook_timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dynamic_variables_webhook_timeout_ms", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dynamic_variables_webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dynamic_variables_webhook_url", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, EnabledFeatures>>? EnabledFeatures {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, EnabledFeatures>>>(
                "enabled_features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, EnabledFeatures>>?>(
                "enabled_features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Text that the assistant will use to start the conversation. This may be templated
    /// with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables).
    /// Use an empty string to have the assistant wait for the user to speak first.
    /// Use the special value `&lt;assistant-speaks-first-with-model-generated-message&gt;`
    /// to have the assistant generate the greeting based on the system instructions.
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

    public ImportMetadata? ImportMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImportMetadata>(
                "import_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("import_metadata", value);
        }
    }

    public InsightSettings? InsightSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InsightSettings>(
                "insight_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("insight_settings", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AssistantIntegration>>(
                "integrations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AssistantIntegration>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InferenceEmbeddingInterruptionSettings>(
                "interruption_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruption_settings", value);
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
    /// MCP servers attached to the assistant. Create MCP servers with `/ai/mcp_servers`,
    /// then reference them by `id` here.
    /// </summary>
    public IReadOnlyList<AssistantMcpServer>? McpServers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AssistantMcpServer>>(
                "mcp_servers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AssistantMcpServer>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingSettings? MessagingSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingSettings>(
                "messaging_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_settings", value);
        }
    }

    public Observability? ObservabilitySettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Observability>(
                "observability_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("observability_settings", value);
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
    public PostConversationSettings? PostConversationSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PostConversationSettings>(
                "post_conversation_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("post_conversation_settings", value);
        }
    }

    public PrivacySettings? PrivacySettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrivacySettings>(
                "privacy_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacy_settings", value);
        }
    }

    /// <summary>
    /// IDs of missions related to this assistant.
    /// </summary>
    public IReadOnlyList<string>? RelatedMissionIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "related_mission_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "related_mission_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tags associated with the assistant. Tags can also be managed with the assistant
    /// tag endpoints.
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

    public TelephonySettings? TelephonySettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephonySettings>(
                "telephony_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telephony_settings", value);
        }
    }

    /// <summary>
    /// The assistant's tools. Responses merge the assistant's shared Tools Library
    /// tools into this array alongside inline tools, each flagged `shared: true`;
    /// inline tools carry `shared: false`. On update, a sent `tools` array fully
    /// replaces the inline tools only — shared tools stay attached unless `tool_ids`
    /// changes. Each tool type except `function`, `webhook`, and `client_side_tool`
    /// allows at most one instance per assistant across both sources.
    /// </summary>
    public IReadOnlyList<AssistantTool>? Tools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AssistantTool>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AssistantTool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public TranscriptionSettings? Transcription {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionSettings>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription", value);
        }
    }

    /// <summary>
    /// Timestamp when this assistant version was created.
    /// </summary>
    public DateTimeOffset? VersionCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "version_created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version_created_at", value);
        }
    }

    /// <summary>
    /// Identifier for the assistant version returned by version-aware assistant endpoints.
    /// </summary>
    public string? VersionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version_id", value);
        }
    }

    /// <summary>
    /// Human-readable name for the assistant version.
    /// </summary>
    public string? VersionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version_name", value);
        }
    }

    public InferenceEmbeddingVoiceSettings? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InferenceEmbeddingVoiceSettings>(
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

    /// <summary>
    /// Configuration settings for the assistant's web widget.
    /// </summary>
    public WidgetSettings? WidgetSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WidgetSettings>(
                "widget_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("widget_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Instructions;
        _ = this.Model;
        _ = this.Name;
        foreach (var item in this.A2aAgents ?? [])
        {
            item.Validate();
        }
        this.ConversationFlow?.Validate();
        _ = this.Description;
        _ = this.DynamicVariables;
        _ = this.DynamicVariablesWebhookTimeoutMs;
        _ = this.DynamicVariablesWebhookUrl;
        foreach (var item in this.EnabledFeatures ?? [])
        {
            item.Validate();
        }
        this.ExternalLlm?.Validate();
        this.FallbackConfig?.Validate();
        _ = this.Greeting;
        this.ImportMetadata?.Validate();
        this.InsightSettings?.Validate();
        foreach (var item in this.Integrations ?? [])
        {
            item.Validate();
        }
        this.InterruptionSettings?.Validate();
        _ = this.LlmApiKeyRef;
        foreach (var item in this.McpServers ?? [])
        {
            item.Validate();
        }
        this.MessagingSettings?.Validate();
        this.ObservabilitySettings?.Validate();
        this.PostConversationSettings?.Validate();
        this.PrivacySettings?.Validate();
        _ = this.RelatedMissionIds;
        _ = this.Tags;
        this.TelephonySettings?.Validate();
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
        this.Transcription?.Validate();
        _ = this.VersionCreatedAt;
        _ = this.VersionID;
        _ = this.VersionName;
        this.VoiceSettings?.Validate();
        this.WidgetSettings?.Validate();
    }

    public InferenceEmbedding ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferenceEmbedding (InferenceEmbedding inferenceEmbedding) : base(
        inferenceEmbedding
    )
    {  }
    #pragma warning restore CS8618

    public InferenceEmbedding (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InferenceEmbedding (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InferenceEmbeddingFromRaw.FromRawUnchecked"/>
    public static InferenceEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InferenceEmbeddingFromRaw : IFromRawJson<InferenceEmbedding>
{
    /// <inheritdoc/>
    public InferenceEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InferenceEmbedding.FromRawUnchecked(rawData);
}