using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SpeechToText;

/// <summary>
/// Retrieve the canonical list of supported speech-to-text providers, models, accepted
/// language codes, and the service types each model supports.
///
/// <para>Service types:   * `streaming` — standalone WebSocket transcription via
/// `/speech-to-text/transcription`.   * `file_based` — file-based transcription via
/// `/ai/audio/transcriptions`.   * `in_call` — live call transcription via Call Control
/// `transcription_start`.   * `ai_assistant` — STT configured on a Call Control
/// AI Assistant via voice-assistant `TranscriptionConfig` (covers both live-streaming
/// and non-streaming/batch models).</para>
///
/// <para>Use this endpoint to discover which (provider, model) combinations are
/// available for the surface you need, and which language codes each accepts. `auto`
/// in a `languages` array indicates the provider performs language detection.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpeechToTextListProvidersParams : ParamsBase
{
    /// <summary>
    /// Filter to entries for a specific STT provider. The enum mirrors the providers
    /// advertised across the speech-to-text spec (including `google` and `telnyx`,
    /// which are accepted as WebSocket transcription engines). A provider that has
    /// no models currently registered for any service type will return an empty `data`
    /// array rather than an error.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("provider", value);
        }
    }

    /// <summary>
    /// Filter to entries that support the given service type. For backward compatibility
    /// with the values that briefly shipped before the product-aligned rename, the
    /// legacy aliases `file_transcription`, `in_call_transcription`, and `ai_assistant_transcription`
    /// are silently accepted and normalized to `file_based`, `in_call`, and `ai_assistant`
    /// respectively. The response always emits the canonical (post-rename) values.
    /// </summary>
    public ApiEnum<string, SttServiceType>? ServiceType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SttServiceType>>(
                "service_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("service_type", value);
        }
    }

    public SpeechToTextListProvidersParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextListProvidersParams (
        SpeechToTextListProvidersParams speechToTextListProvidersParams
    ) : base(speechToTextListProvidersParams)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextListProvidersParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextListProvidersParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpeechToTextListProvidersParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SpeechToTextListProvidersParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/speech-to-text/providers"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Filter to entries for a specific STT provider. The enum mirrors the providers
/// advertised across the speech-to-text spec (including `google` and `telnyx`, which
/// are accepted as WebSocket transcription engines). A provider that has no models
/// currently registered for any service type will return an empty `data` array rather
/// than an error.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Deepgram,
    Speechmatics,
    Assemblyai,
    Xai,
    Soniox,
    Parakeet,
    Humain,
    Reson8,
    Cohere,
    Azure,
    OpenAI,
    Google,
    Telnyx
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
            "deepgram"=>Provider.Deepgram,
            "speechmatics"=>Provider.Speechmatics,
            "assemblyai"=>Provider.Assemblyai,
            "xai"=>Provider.Xai,
            "soniox"=>Provider.Soniox,
            "parakeet"=>Provider.Parakeet,
            "humain"=>Provider.Humain,
            "reson8"=>Provider.Reson8,
            "cohere"=>Provider.Cohere,
            "azure"=>Provider.Azure,
            "openai"=>Provider.OpenAI,
            "google"=>Provider.Google,
            "telnyx"=>Provider.Telnyx,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Deepgram=>"deepgram",
            Provider.Speechmatics=>"speechmatics",
            Provider.Assemblyai=>"assemblyai",
            Provider.Xai=>"xai",
            Provider.Soniox=>"soniox",
            Provider.Parakeet=>"parakeet",
            Provider.Humain=>"humain",
            Provider.Reson8=>"reson8",
            Provider.Cohere=>"cohere",
            Provider.Azure=>"azure",
            Provider.OpenAI=>"openai",
            Provider.Google=>"google",
            Provider.Telnyx=>"telnyx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}