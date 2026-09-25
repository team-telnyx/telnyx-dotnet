using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<Observability, ObservabilityFromRaw>))]
public sealed record class Observability : JsonModel
{
    public string? Host {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "host"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("host", value);
        }
    }

    public string? PromptLabel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "prompt_label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt_label", value);
        }
    }

    public string? PromptName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "prompt_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt_name", value);
        }
    }

    /// <summary>
    /// Whether to auto-publish the assistant's instructions as a Langfuse prompt.
    ///
    /// <para>When ENABLED + prompt_name set, every assistant create/update pushes
    /// `instructions` to Langfuse via create_prompt and stores the returned version
    /// in prompt_version.</para>
    /// </summary>
    public ApiEnum<string, PromptSyncStatus>? PromptSync {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PromptSyncStatus>>(
                "prompt_sync"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt_sync", value);
        }
    }

    public long? PromptVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "prompt_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt_version", value);
        }
    }

    public string? PublicKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "public_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_key_ref", value);
        }
    }

    public string? SecretKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secret_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secret_key_ref", value);
        }
    }

    public ApiEnum<string, ObservabilityStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ObservabilityStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Host;
        _ = this.PromptLabel;
        _ = this.PromptName;
        this.PromptSync?.Validate();
        _ = this.PromptVersion;
        _ = this.PublicKeyRef;
        _ = this.SecretKeyRef;
        this.Status?.Validate();
    }

    public Observability ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Observability (Observability observability) : base(observability)
    {  }
    #pragma warning restore CS8618

    public Observability (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Observability (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ObservabilityFromRaw.FromRawUnchecked"/>
    public static Observability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ObservabilityFromRaw : IFromRawJson<Observability>
{
    /// <inheritdoc/>
    public Observability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Observability.FromRawUnchecked(rawData);
}