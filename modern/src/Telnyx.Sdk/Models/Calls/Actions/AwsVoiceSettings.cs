using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<AwsVoiceSettings, AwsVoiceSettingsFromRaw>))]
public sealed record class AwsVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, AwsVoiceSettingsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AwsVoiceSettingsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Type.Validate(); }

    public AwsVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AwsVoiceSettings (AwsVoiceSettings awsVoiceSettings) : base(
        awsVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public AwsVoiceSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AwsVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AwsVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static AwsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AwsVoiceSettings (ApiEnum<string, AwsVoiceSettingsType> type) : this(

    )
    { this.Type = type; }
}

class AwsVoiceSettingsFromRaw : IFromRawJson<AwsVoiceSettings>
{
    /// <inheritdoc/>
    public AwsVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AwsVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(AwsVoiceSettingsTypeConverter))]
public enum AwsVoiceSettingsType
{
    Aws
}sealed class AwsVoiceSettingsTypeConverter : JsonConverter<AwsVoiceSettingsType>
{
    public override AwsVoiceSettingsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "aws"=>AwsVoiceSettingsType.Aws, _ =>(AwsVoiceSettingsType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AwsVoiceSettingsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AwsVoiceSettingsType.Aws=>"aws",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}