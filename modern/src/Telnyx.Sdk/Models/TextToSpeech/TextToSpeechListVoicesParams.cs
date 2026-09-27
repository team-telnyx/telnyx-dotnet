using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TextToSpeech;

/// <summary>
/// Retrieve a list of available voices from one or all TTS providers. When `provider`
/// is specified, returns voices for that provider only. Otherwise, returns voices
/// from all providers.
///
/// <para>Some providers (ElevenLabs, Resemble) require an API key to list voices.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TextToSpeechListVoicesParams : ParamsBase
{
    /// <summary>
    /// API key for providers that require one to list voices (e.g. ElevenLabs).
    /// </summary>
    public string? ApiKey {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "api_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("api_key", value);
        }
    }

    /// <summary>
    /// Filter voices by provider. If omitted, voices from all providers are returned.
    /// </summary>
    public ApiEnum<string, TextToSpeechListVoicesParamsProvider>? Provider {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TextToSpeechListVoicesParamsProvider>>(
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

    public TextToSpeechListVoicesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextToSpeechListVoicesParams (
        TextToSpeechListVoicesParams textToSpeechListVoicesParams
    ) : base(textToSpeechListVoicesParams)
    {  }
    #pragma warning restore CS8618

    public TextToSpeechListVoicesParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextToSpeechListVoicesParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TextToSpeechListVoicesParams FromRawUnchecked(
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

    public virtual bool Equals(TextToSpeechListVoicesParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/text-to-speech/voices"
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
/// Filter voices by provider. If omitted, voices from all providers are returned.
/// </summary>
[JsonConverter(typeof(TextToSpeechListVoicesParamsProviderConverter))]
public enum TextToSpeechListVoicesParamsProvider
{
    Aws, Telnyx, Azure, Elevenlabs, Minimax, Resemble, Xai, Humain, Soniox
}

sealed class TextToSpeechListVoicesParamsProviderConverter : JsonConverter<TextToSpeechListVoicesParamsProvider>
{
    public override TextToSpeechListVoicesParamsProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>TextToSpeechListVoicesParamsProvider.Aws,
            "telnyx"=>TextToSpeechListVoicesParamsProvider.Telnyx,
            "azure"=>TextToSpeechListVoicesParamsProvider.Azure,
            "elevenlabs"=>TextToSpeechListVoicesParamsProvider.Elevenlabs,
            "minimax"=>TextToSpeechListVoicesParamsProvider.Minimax,
            "resemble"=>TextToSpeechListVoicesParamsProvider.Resemble,
            "xai"=>TextToSpeechListVoicesParamsProvider.Xai,
            "humain"=>TextToSpeechListVoicesParamsProvider.Humain,
            "soniox"=>TextToSpeechListVoicesParamsProvider.Soniox,
            _ =>(TextToSpeechListVoicesParamsProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextToSpeechListVoicesParamsProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TextToSpeechListVoicesParamsProvider.Aws=>"aws",
            TextToSpeechListVoicesParamsProvider.Telnyx=>"telnyx",
            TextToSpeechListVoicesParamsProvider.Azure=>"azure",
            TextToSpeechListVoicesParamsProvider.Elevenlabs=>"elevenlabs",
            TextToSpeechListVoicesParamsProvider.Minimax=>"minimax",
            TextToSpeechListVoicesParamsProvider.Resemble=>"resemble",
            TextToSpeechListVoicesParamsProvider.Xai=>"xai",
            TextToSpeechListVoicesParamsProvider.Humain=>"humain",
            TextToSpeechListVoicesParamsProvider.Soniox=>"soniox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}