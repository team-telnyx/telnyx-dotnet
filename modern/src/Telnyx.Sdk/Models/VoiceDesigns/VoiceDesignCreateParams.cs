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

namespace Telnyx.Sdk.Models.VoiceDesigns;

/// <summary>
/// Creates a new voice design (version 1) when `voice_design_id` is omitted. When
/// `voice_design_id` is provided, adds a new version to the existing design instead.
/// A design can have at most 50 versions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceDesignCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Natural language description of the voice style, e.g. 'Speak in a warm, friendly
    /// tone with a slight British accent'.
    /// </summary>
    public required string Prompt {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "prompt"
            );
        }
        init { this._rawBodyData.Set("prompt", value); }
    }

    /// <summary>
    /// Sample text to synthesize for this voice design.
    /// </summary>
    public required string Text {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// Language for synthesis. Supported values: Auto, Chinese, English, Japanese,
    /// Korean, German, French, Russian, Portuguese, Spanish, Italian. Defaults to Auto.
    /// </summary>
    public string? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    /// <summary>
    /// Maximum number of tokens to generate. Default: 2048.
    /// </summary>
    public long? MaxNewTokens {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_new_tokens"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_new_tokens", value);
        }
    }

    /// <summary>
    /// Name for the voice design. Required when creating a new design (`voice_design_id`
    /// is not provided); ignored when adding a version. Cannot be a UUID.
    /// </summary>
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

    /// <summary>
    /// Voice synthesis provider. `telnyx` uses the Qwen3TTS model; `minimax` uses
    /// the Minimax speech models. Case-insensitive. Defaults to `telnyx`.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("provider", value);
        }
    }

    /// <summary>
    /// Repetition penalty to reduce repeated patterns in generated audio. Default: 1.05.
    /// </summary>
    public float? RepetitionPenalty {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>(
                "repetition_penalty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("repetition_penalty", value);
        }
    }

    /// <summary>
    /// Sampling temperature controlling randomness. Higher values produce more varied
    /// output. Default: 0.9.
    /// </summary>
    public float? Temperature {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>(
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
    /// Top-k sampling parameter — limits the token vocabulary considered at each
    /// step. Default: 50.
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
    /// Top-p (nucleus) sampling parameter — cumulative probability cutoff for token
    /// selection. Default: 1.0.
    /// </summary>
    public float? TopP {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<float>(
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
    /// ID of an existing voice design to add a new version to. When provided, a new
    /// version is created instead of a new design.
    /// </summary>
    public string? VoiceDesignID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "voice_design_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice_design_id", value);
        }
    }

    public VoiceDesignCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignCreateParams (
        VoiceDesignCreateParams voiceDesignCreateParams
    ) : base(voiceDesignCreateParams)
    { this._rawBodyData = new(voiceDesignCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public VoiceDesignCreateParams (
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
    VoiceDesignCreateParams (
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
    public static VoiceDesignCreateParams FromRawUnchecked(
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

    public virtual bool Equals(VoiceDesignCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/voice_designs"
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
/// Voice synthesis provider. `telnyx` uses the Qwen3TTS model; `minimax` uses the
/// Minimax speech models. Case-insensitive. Defaults to `telnyx`.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Telnyx, Minimax
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>Provider.Telnyx,
            "minimax"=>Provider.Minimax,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Telnyx=>"telnyx",
            Provider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}