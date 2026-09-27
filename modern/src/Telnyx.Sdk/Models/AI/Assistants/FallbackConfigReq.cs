using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<FallbackConfigReq, FallbackConfigReqFromRaw>))]
public sealed record class FallbackConfigReq : JsonModel
{
    public ExternalLlmReq? ExternalLlm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalLlmReq>(
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

    public FallbackConfigReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FallbackConfigReq (FallbackConfigReq fallbackConfigReq) : base(
        fallbackConfigReq
    )
    {  }
    #pragma warning restore CS8618

    public FallbackConfigReq (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FallbackConfigReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FallbackConfigReqFromRaw.FromRawUnchecked"/>
    public static FallbackConfigReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FallbackConfigReqFromRaw : IFromRawJson<FallbackConfigReq>
{
    /// <inheritdoc/>
    public FallbackConfigReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FallbackConfigReq.FromRawUnchecked(rawData);
}