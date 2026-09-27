using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineAzureConfig, TranscriptionEngineAzureConfigFromRaw>))]
public sealed record class TranscriptionEngineAzureConfig : JsonModel
{
    /// <summary>
    /// Azure region to use for speech recognition
    /// </summary>
    public required ApiEnum<string, Region> Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Region>>(
                "region"
            );
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Engine identifier for Azure transcription service
    /// </summary>
    public required ApiEnum<string, TranscriptionEngineAzureConfigTranscriptionEngine> TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TranscriptionEngineAzureConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init { this._rawData.Set("transcription_engine", value); }
    }

    /// <summary>
    /// Reference to the API key for authentication. See [integration secrets documentation](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// for details. The parameter is optional as defaults are available for some regions.
    /// </summary>
    public string? ApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key_ref", value);
        }
    }

    /// <summary>
    /// Language to use for speech recognition
    /// </summary>
    public ApiEnum<string, TranscriptionEngineAzureConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineAzureConfigLanguage>>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Region.Validate();
        this.TranscriptionEngine.Validate();
        _ = this.ApiKeyRef;
        this.Language?.Validate();
    }

    public TranscriptionEngineAzureConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineAzureConfig (
        TranscriptionEngineAzureConfig transcriptionEngineAzureConfig
    ) : base(transcriptionEngineAzureConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineAzureConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineAzureConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineAzureConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineAzureConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineAzureConfigFromRaw : IFromRawJson<TranscriptionEngineAzureConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineAzureConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineAzureConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Azure region to use for speech recognition
/// </summary>
[JsonConverter(typeof(RegionConverter))]
public enum Region
{
    Australiaeast, Centralindia, Eastus, Northcentralus, Westeurope, Westus2
}sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "australiaeast"=>Region.Australiaeast,
            "centralindia"=>Region.Centralindia,
            "eastus"=>Region.Eastus,
            "northcentralus"=>Region.Northcentralus,
            "westeurope"=>Region.Westeurope,
            "westus2"=>Region.Westus2,
            _ =>(Region)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Region value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Region.Australiaeast=>"australiaeast",
            Region.Centralindia=>"centralindia",
            Region.Eastus=>"eastus",
            Region.Northcentralus=>"northcentralus",
            Region.Westeurope=>"westeurope",
            Region.Westus2=>"westus2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for Azure transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAzureConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineAzureConfigTranscriptionEngine
{
    Azure
}sealed class TranscriptionEngineAzureConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineAzureConfigTranscriptionEngine>
{
    public override TranscriptionEngineAzureConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Azure"=>TranscriptionEngineAzureConfigTranscriptionEngine.Azure,
            _ =>(TranscriptionEngineAzureConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAzureConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAzureConfigTranscriptionEngine.Azure=>"Azure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Language to use for speech recognition
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAzureConfigLanguageConverter))]
public enum TranscriptionEngineAzureConfigLanguage
{
    Af,
    Am,
    Ar,
    Bg,
    Bn,
    Bs,
    Ca,
    Cs,
    Cy,
    Da,
    De,
    El,
    En,
    Es,
    Et,
    Eu,
    Fa,
    Fi,
    Fr,
    Ga,
    Gl,
    Gu,
    He,
    Hi,
    Hr,
    Hu,
    Hy,
    ID,
    Is,
    It,
    Ja,
    Ka,
    Kk,
    Km,
    Kn,
    Ko,
    Lo,
    Lt,
    Lv,
    Mk,
    Ml,
    Mn,
    Mr,
    Ms,
    Mt,
    My,
    Nb,
    Ne,
    Nl,
    Pl,
    Ps,
    Pt,
    Ro,
    Ru,
    Si,
    Sk,
    Sl,
    So,
    Sq,
    Sr,
    Sv,
    Sw,
    Ta,
    Te,
    Th,
    Tr,
    Uk,
    Ur,
    Uz,
    Vi,
    Wuu,
    Yue,
    Zh,
    Zu,
    Auto
}sealed class TranscriptionEngineAzureConfigLanguageConverter : JsonConverter<TranscriptionEngineAzureConfigLanguage>
{
    public override TranscriptionEngineAzureConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "af"=>TranscriptionEngineAzureConfigLanguage.Af,
            "am"=>TranscriptionEngineAzureConfigLanguage.Am,
            "ar"=>TranscriptionEngineAzureConfigLanguage.Ar,
            "bg"=>TranscriptionEngineAzureConfigLanguage.Bg,
            "bn"=>TranscriptionEngineAzureConfigLanguage.Bn,
            "bs"=>TranscriptionEngineAzureConfigLanguage.Bs,
            "ca"=>TranscriptionEngineAzureConfigLanguage.Ca,
            "cs"=>TranscriptionEngineAzureConfigLanguage.Cs,
            "cy"=>TranscriptionEngineAzureConfigLanguage.Cy,
            "da"=>TranscriptionEngineAzureConfigLanguage.Da,
            "de"=>TranscriptionEngineAzureConfigLanguage.De,
            "el"=>TranscriptionEngineAzureConfigLanguage.El,
            "en"=>TranscriptionEngineAzureConfigLanguage.En,
            "es"=>TranscriptionEngineAzureConfigLanguage.Es,
            "et"=>TranscriptionEngineAzureConfigLanguage.Et,
            "eu"=>TranscriptionEngineAzureConfigLanguage.Eu,
            "fa"=>TranscriptionEngineAzureConfigLanguage.Fa,
            "fi"=>TranscriptionEngineAzureConfigLanguage.Fi,
            "fr"=>TranscriptionEngineAzureConfigLanguage.Fr,
            "ga"=>TranscriptionEngineAzureConfigLanguage.Ga,
            "gl"=>TranscriptionEngineAzureConfigLanguage.Gl,
            "gu"=>TranscriptionEngineAzureConfigLanguage.Gu,
            "he"=>TranscriptionEngineAzureConfigLanguage.He,
            "hi"=>TranscriptionEngineAzureConfigLanguage.Hi,
            "hr"=>TranscriptionEngineAzureConfigLanguage.Hr,
            "hu"=>TranscriptionEngineAzureConfigLanguage.Hu,
            "hy"=>TranscriptionEngineAzureConfigLanguage.Hy,
            "id"=>TranscriptionEngineAzureConfigLanguage.ID,
            "is"=>TranscriptionEngineAzureConfigLanguage.Is,
            "it"=>TranscriptionEngineAzureConfigLanguage.It,
            "ja"=>TranscriptionEngineAzureConfigLanguage.Ja,
            "ka"=>TranscriptionEngineAzureConfigLanguage.Ka,
            "kk"=>TranscriptionEngineAzureConfigLanguage.Kk,
            "km"=>TranscriptionEngineAzureConfigLanguage.Km,
            "kn"=>TranscriptionEngineAzureConfigLanguage.Kn,
            "ko"=>TranscriptionEngineAzureConfigLanguage.Ko,
            "lo"=>TranscriptionEngineAzureConfigLanguage.Lo,
            "lt"=>TranscriptionEngineAzureConfigLanguage.Lt,
            "lv"=>TranscriptionEngineAzureConfigLanguage.Lv,
            "mk"=>TranscriptionEngineAzureConfigLanguage.Mk,
            "ml"=>TranscriptionEngineAzureConfigLanguage.Ml,
            "mn"=>TranscriptionEngineAzureConfigLanguage.Mn,
            "mr"=>TranscriptionEngineAzureConfigLanguage.Mr,
            "ms"=>TranscriptionEngineAzureConfigLanguage.Ms,
            "mt"=>TranscriptionEngineAzureConfigLanguage.Mt,
            "my"=>TranscriptionEngineAzureConfigLanguage.My,
            "nb"=>TranscriptionEngineAzureConfigLanguage.Nb,
            "ne"=>TranscriptionEngineAzureConfigLanguage.Ne,
            "nl"=>TranscriptionEngineAzureConfigLanguage.Nl,
            "pl"=>TranscriptionEngineAzureConfigLanguage.Pl,
            "ps"=>TranscriptionEngineAzureConfigLanguage.Ps,
            "pt"=>TranscriptionEngineAzureConfigLanguage.Pt,
            "ro"=>TranscriptionEngineAzureConfigLanguage.Ro,
            "ru"=>TranscriptionEngineAzureConfigLanguage.Ru,
            "si"=>TranscriptionEngineAzureConfigLanguage.Si,
            "sk"=>TranscriptionEngineAzureConfigLanguage.Sk,
            "sl"=>TranscriptionEngineAzureConfigLanguage.Sl,
            "so"=>TranscriptionEngineAzureConfigLanguage.So,
            "sq"=>TranscriptionEngineAzureConfigLanguage.Sq,
            "sr"=>TranscriptionEngineAzureConfigLanguage.Sr,
            "sv"=>TranscriptionEngineAzureConfigLanguage.Sv,
            "sw"=>TranscriptionEngineAzureConfigLanguage.Sw,
            "ta"=>TranscriptionEngineAzureConfigLanguage.Ta,
            "te"=>TranscriptionEngineAzureConfigLanguage.Te,
            "th"=>TranscriptionEngineAzureConfigLanguage.Th,
            "tr"=>TranscriptionEngineAzureConfigLanguage.Tr,
            "uk"=>TranscriptionEngineAzureConfigLanguage.Uk,
            "ur"=>TranscriptionEngineAzureConfigLanguage.Ur,
            "uz"=>TranscriptionEngineAzureConfigLanguage.Uz,
            "vi"=>TranscriptionEngineAzureConfigLanguage.Vi,
            "wuu"=>TranscriptionEngineAzureConfigLanguage.Wuu,
            "yue"=>TranscriptionEngineAzureConfigLanguage.Yue,
            "zh"=>TranscriptionEngineAzureConfigLanguage.Zh,
            "zu"=>TranscriptionEngineAzureConfigLanguage.Zu,
            "auto"=>TranscriptionEngineAzureConfigLanguage.Auto,
            _ =>(TranscriptionEngineAzureConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAzureConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAzureConfigLanguage.Af=>"af",
            TranscriptionEngineAzureConfigLanguage.Am=>"am",
            TranscriptionEngineAzureConfigLanguage.Ar=>"ar",
            TranscriptionEngineAzureConfigLanguage.Bg=>"bg",
            TranscriptionEngineAzureConfigLanguage.Bn=>"bn",
            TranscriptionEngineAzureConfigLanguage.Bs=>"bs",
            TranscriptionEngineAzureConfigLanguage.Ca=>"ca",
            TranscriptionEngineAzureConfigLanguage.Cs=>"cs",
            TranscriptionEngineAzureConfigLanguage.Cy=>"cy",
            TranscriptionEngineAzureConfigLanguage.Da=>"da",
            TranscriptionEngineAzureConfigLanguage.De=>"de",
            TranscriptionEngineAzureConfigLanguage.El=>"el",
            TranscriptionEngineAzureConfigLanguage.En=>"en",
            TranscriptionEngineAzureConfigLanguage.Es=>"es",
            TranscriptionEngineAzureConfigLanguage.Et=>"et",
            TranscriptionEngineAzureConfigLanguage.Eu=>"eu",
            TranscriptionEngineAzureConfigLanguage.Fa=>"fa",
            TranscriptionEngineAzureConfigLanguage.Fi=>"fi",
            TranscriptionEngineAzureConfigLanguage.Fr=>"fr",
            TranscriptionEngineAzureConfigLanguage.Ga=>"ga",
            TranscriptionEngineAzureConfigLanguage.Gl=>"gl",
            TranscriptionEngineAzureConfigLanguage.Gu=>"gu",
            TranscriptionEngineAzureConfigLanguage.He=>"he",
            TranscriptionEngineAzureConfigLanguage.Hi=>"hi",
            TranscriptionEngineAzureConfigLanguage.Hr=>"hr",
            TranscriptionEngineAzureConfigLanguage.Hu=>"hu",
            TranscriptionEngineAzureConfigLanguage.Hy=>"hy",
            TranscriptionEngineAzureConfigLanguage.ID=>"id",
            TranscriptionEngineAzureConfigLanguage.Is=>"is",
            TranscriptionEngineAzureConfigLanguage.It=>"it",
            TranscriptionEngineAzureConfigLanguage.Ja=>"ja",
            TranscriptionEngineAzureConfigLanguage.Ka=>"ka",
            TranscriptionEngineAzureConfigLanguage.Kk=>"kk",
            TranscriptionEngineAzureConfigLanguage.Km=>"km",
            TranscriptionEngineAzureConfigLanguage.Kn=>"kn",
            TranscriptionEngineAzureConfigLanguage.Ko=>"ko",
            TranscriptionEngineAzureConfigLanguage.Lo=>"lo",
            TranscriptionEngineAzureConfigLanguage.Lt=>"lt",
            TranscriptionEngineAzureConfigLanguage.Lv=>"lv",
            TranscriptionEngineAzureConfigLanguage.Mk=>"mk",
            TranscriptionEngineAzureConfigLanguage.Ml=>"ml",
            TranscriptionEngineAzureConfigLanguage.Mn=>"mn",
            TranscriptionEngineAzureConfigLanguage.Mr=>"mr",
            TranscriptionEngineAzureConfigLanguage.Ms=>"ms",
            TranscriptionEngineAzureConfigLanguage.Mt=>"mt",
            TranscriptionEngineAzureConfigLanguage.My=>"my",
            TranscriptionEngineAzureConfigLanguage.Nb=>"nb",
            TranscriptionEngineAzureConfigLanguage.Ne=>"ne",
            TranscriptionEngineAzureConfigLanguage.Nl=>"nl",
            TranscriptionEngineAzureConfigLanguage.Pl=>"pl",
            TranscriptionEngineAzureConfigLanguage.Ps=>"ps",
            TranscriptionEngineAzureConfigLanguage.Pt=>"pt",
            TranscriptionEngineAzureConfigLanguage.Ro=>"ro",
            TranscriptionEngineAzureConfigLanguage.Ru=>"ru",
            TranscriptionEngineAzureConfigLanguage.Si=>"si",
            TranscriptionEngineAzureConfigLanguage.Sk=>"sk",
            TranscriptionEngineAzureConfigLanguage.Sl=>"sl",
            TranscriptionEngineAzureConfigLanguage.So=>"so",
            TranscriptionEngineAzureConfigLanguage.Sq=>"sq",
            TranscriptionEngineAzureConfigLanguage.Sr=>"sr",
            TranscriptionEngineAzureConfigLanguage.Sv=>"sv",
            TranscriptionEngineAzureConfigLanguage.Sw=>"sw",
            TranscriptionEngineAzureConfigLanguage.Ta=>"ta",
            TranscriptionEngineAzureConfigLanguage.Te=>"te",
            TranscriptionEngineAzureConfigLanguage.Th=>"th",
            TranscriptionEngineAzureConfigLanguage.Tr=>"tr",
            TranscriptionEngineAzureConfigLanguage.Uk=>"uk",
            TranscriptionEngineAzureConfigLanguage.Ur=>"ur",
            TranscriptionEngineAzureConfigLanguage.Uz=>"uz",
            TranscriptionEngineAzureConfigLanguage.Vi=>"vi",
            TranscriptionEngineAzureConfigLanguage.Wuu=>"wuu",
            TranscriptionEngineAzureConfigLanguage.Yue=>"yue",
            TranscriptionEngineAzureConfigLanguage.Zh=>"zh",
            TranscriptionEngineAzureConfigLanguage.Zu=>"zu",
            TranscriptionEngineAzureConfigLanguage.Auto=>"auto",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}