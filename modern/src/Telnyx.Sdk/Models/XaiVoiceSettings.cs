using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<XaiVoiceSettings, XaiVoiceSettingsFromRaw>))]
public sealed record class XaiVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, XaiVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XaiVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Language code, or `auto` to detect automatically.
    /// </summary>
    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        this.Type.Validate();
        _ = this.Language;
    }

    public XaiVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public XaiVoiceSettings (XaiVoiceSettings xaiVoiceSettings) : base(
        xaiVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public XaiVoiceSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    XaiVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="XaiVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static XaiVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public XaiVoiceSettings (ApiEnum<string, XaiVoiceSettingsType> type) : this(

    )
    { this.Type = type; }
}

class XaiVoiceSettingsFromRaw : IFromRawJson<XaiVoiceSettings>
{
    /// <inheritdoc/>
    public XaiVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>XaiVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(XaiVoiceSettingsTypeConverter))]
public enum XaiVoiceSettingsType
{
    Xai
}sealed class XaiVoiceSettingsTypeConverter : JsonConverter<XaiVoiceSettingsType>
{
    public override XaiVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "xai"=>XaiVoiceSettingsType.Xai, _ =>(XaiVoiceSettingsType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XaiVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            XaiVoiceSettingsType.Xai=>"xai",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}