using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI;

/// <summary>
/// Metadata for a model available on Telnyx Inference. Returned by `GET /v2/ai/openai/models`
/// (and the deprecated `GET /v2/ai/models`). Open-source models live under their
/// Hugging Face organization (e.g. `moonshotai/Kimi-K2.6`, `zai-org/GLM-5.1-FP8`,
/// `MiniMaxAI/MiniMax-M2.7`); fine-tuned models are owned by the Telnyx organization
/// that trained them.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ModelMetadata, ModelMetadataFromRaw>))]
public sealed record class ModelMetadata : JsonModel
{
    /// <summary>
    /// Model identifier. For open-source models, follows the `{organization}/{model_name}`
    /// convention from Hugging Face (e.g. `moonshotai/Kimi-K2.6`).
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
    /// Maximum total tokens (prompt + completion) supported by the model in a single request.
    /// </summary>
    public required long ContextLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "context_length"
            );
        }
        init { this._rawData.Set("context_length", value); }
    }

    /// <summary>
    /// Timestamp at which the model was registered on Telnyx Inference (ISO 8601).
    /// </summary>
    public required System::DateTimeOffset Created {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created"
            );
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// ISO language codes the model supports (e.g. `en`, `es`).
    /// </summary>
    public required IReadOnlyList<string> Languages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "languages"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "languages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// License the model is distributed under, e.g. `Apache 2.0`, `MIT`, `Llama 3
    /// Community License`.
    /// </summary>
    public required string License {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "license"
            );
        }
        init { this._rawData.Set("license", value); }
    }

    /// <summary>
    /// Organization that originally published the model, matching the prefix of
    /// `id` for open-source models.
    /// </summary>
    public required string Organization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "organization"
            );
        }
        init { this._rawData.Set("organization", value); }
    }

    /// <summary>
    /// Owner of the model. `Telnyx` for Telnyx-hosted open-source models, the upstream
    /// provider name for proxied models, or the Telnyx organization id for fine-tuned models.
    /// </summary>
    public required string OwnedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "owned_by"
            );
        }
        init { this._rawData.Set("owned_by", value); }
    }

    /// <summary>
    /// Total parameter count of the model.
    /// </summary>
    public required long Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "parameters"
            );
        }
        init { this._rawData.Set("parameters", value); }
    }

    /// <summary>
    /// Billing tier the model belongs to. Used together with `pricing` to determine
    /// cost per 1M tokens.
    /// </summary>
    public required ApiEnum<string, Tier> Tier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Tier>>(
                "tier"
            );
        }
        init { this._rawData.Set("tier", value); }
    }

    /// <summary>
    /// Base model the fine-tuned model was trained from. Only set for fine-tuned models.
    /// </summary>
    public string? BaseModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "base_model"
            );
        }
        init { this._rawData.Set("base_model", value); }
    }

    /// <summary>
    /// Short, human-readable summary of what the model is best suited for.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether the model can be used as a base for a fine-tuning job via `POST /v2/ai/fine_tuning/jobs`.
    /// </summary>
    public bool? IsFineTunable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_fine_tunable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_fine_tunable", value);
        }
    }

    /// <summary>
    /// Whether the model accepts image inputs in chat completions (multimodal vision support).
    /// </summary>
    public bool? IsVisionSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_vision_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_vision_supported", value);
        }
    }

    /// <summary>
    /// Maximum number of completion (output) tokens the model will generate per request.
    /// `null` if unconstrained beyond `context_length`.
    /// </summary>
    public long? MaxCompletionTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_completion_tokens"
            );
        }
        init { this._rawData.Set("max_completion_tokens", value); }
    }

    /// <summary>
    /// Object type. Always `model`.
    /// </summary>
    public string? Object {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "object"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    /// <summary>
    /// Human-readable parameter count, e.g. `1.0T`, `753.9B`, `8B`.
    /// </summary>
    public string? ParametersStr {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parameters_str"
            );
        }
        init { this._rawData.Set("parameters_str", value); }
    }

    /// <summary>
    /// Mapping of token kind to price, as strings to preserve precision. Typical
    /// keys are `prompt`, `cached_prompt`, and `completion`. When pricing is available
    /// the block also includes `currency` (ISO 4217 code matching the account's configured
    /// billing currency) and `unit` (the denomination the prices are quoted in, currently
    /// always `1M_tokens` for token-priced models).
    /// </summary>
    public IReadOnlyDictionary<string, string>? Pricing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "pricing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "pricing",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether Telnyx currently recommends this model as the LLM powering a Telnyx
    /// AI Assistant.
    /// </summary>
    public bool? RecommendedForAssistants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "recommended_for_assistants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recommended_for_assistants", value);
        }
    }

    /// <summary>
    /// Public region names where the model is currently deployed (e.g. `us-central-1`, `eu-central-1`).
    /// </summary>
    public IReadOnlyList<string>? Regions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "regions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "regions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Service tiers supported by this Telnyx-hosted model. Use one of these values
    /// as `service_tier` in Chat Completions or Responses requests. This field is
    /// omitted for externally hosted models.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ServiceTier>>? ServiceTiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, ServiceTier>>>(
                "service_tiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, ServiceTier>>?>(
                "service_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Primary task the model is intended for, e.g. `text-generation`, `audio-text-to-text`,
    /// `feature-extraction` (embeddings).
    /// </summary>
    public string? Task {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "task"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("task", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ContextLength;
        _ = this.Created;
        _ = this.Languages;
        _ = this.License;
        _ = this.Organization;
        _ = this.OwnedBy;
        _ = this.Parameters;
        this.Tier.Validate();
        _ = this.BaseModel;
        _ = this.Description;
        _ = this.IsFineTunable;
        _ = this.IsVisionSupported;
        _ = this.MaxCompletionTokens;
        _ = this.Object;
        _ = this.ParametersStr;
        _ = this.Pricing;
        _ = this.RecommendedForAssistants;
        _ = this.Regions;
        foreach (var item in this.ServiceTiers ?? [])
        {
            item.Validate();
        }
        _ = this.Task;
    }

    public ModelMetadata ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelMetadata (ModelMetadata modelMetadata) : base(modelMetadata)
    {  }
    #pragma warning restore CS8618

    public ModelMetadata (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelMetadata (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ModelMetadataFromRaw.FromRawUnchecked"/>
    public static ModelMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ModelMetadataFromRaw : IFromRawJson<ModelMetadata>
{
    /// <inheritdoc/>
    public ModelMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ModelMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing tier the model belongs to. Used together with `pricing` to determine
/// cost per 1M tokens.
/// </summary>
[JsonConverter(typeof(TierConverter))]
public enum Tier
{
    Small, Medium, Large, Unlisted
}sealed class TierConverter : JsonConverter<Tier>
{
    public override Tier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "small"=>Tier.Small,
            "medium"=>Tier.Medium,
            "large"=>Tier.Large,
            "unlisted"=>Tier.Unlisted,
            _ =>(Tier)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Tier value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Tier.Small=>"small",
            Tier.Medium=>"medium",
            Tier.Large=>"large",
            Tier.Unlisted=>"unlisted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Default, Priority, Flex
}sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default"=>ServiceTier.Default,
            "priority"=>ServiceTier.Priority,
            "flex"=>ServiceTier.Flex,
            _ =>(ServiceTier)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ServiceTier value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ServiceTier.Default=>"default",
            ServiceTier.Priority=>"priority",
            ServiceTier.Flex=>"flex",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}