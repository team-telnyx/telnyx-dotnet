using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<ExternalLlm, ExternalLlmFromRaw>))]
public sealed record class ExternalLlm : JsonModel
{
    /// <summary>
    /// Base URL for the external LLM endpoint.
    /// </summary>
    public required string BaseUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "base_url"
            );
        }
        init { this._rawData.Set("base_url", value); }
    }

    /// <summary>
    /// Model identifier to use with the external LLM endpoint.
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
    /// When `true`, Telnyx forwards the assistant's dynamic variables to the external
    /// LLM endpoint as a top-level `extra_metadata` object on the chat completion
    /// request body. Defaults to `false`. Example payload sent to the external endpoint:
    /// `{"extra_metadata": {"customer_name": "Jane", "account_id": "acct_789", "telnyx_agent_target":
    /// "+13125550100", "telnyx_end_user_target": "+13125550123"}}`. Distinct from
    /// OpenAI's native `metadata` field, which has its own size and type limits.
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
        _ = this.BaseUrl;
        _ = this.Model;
        this.AuthenticationMethod?.Validate();
        _ = this.CertificateRef;
        _ = this.ForwardMetadata;
        _ = this.LlmApiKeyRef;
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
}

class ExternalLlmFromRaw : IFromRawJson<ExternalLlm>
{
    /// <inheritdoc/>
    public ExternalLlm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalLlm.FromRawUnchecked(rawData);
}