using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<AzureVoiceSettings, AzureVoiceSettingsFromRaw>))]
public sealed record class AzureVoiceSettings : JsonModel
{
    /// <summary>
    /// Voice settings provider type
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The `identifier` for an integration secret that refers to your Azure Speech
    /// API key.
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
    /// The deployment ID for a custom Azure neural voice.
    /// </summary>
    public string? DeploymentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "deployment_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deployment_id", value);
        }
    }

    /// <summary>
    /// Audio effect to apply.
    /// </summary>
    public ApiEnum<string, Effect>? Effect {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Effect>>(
                "effect"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("effect", value);
        }
    }

    /// <summary>
    /// Voice gender filter.
    /// </summary>
    public ApiEnum<string, Gender>? Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Gender>>(
                "gender"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gender", value);
        }
    }

    /// <summary>
    /// The Azure region for the Speech service (e.g., `eastus`, `westeurope`). Required
    /// when using a custom API key.
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ApiKeyRef;
        _ = this.DeploymentID;
        this.Effect?.Validate();
        this.Gender?.Validate();
        _ = this.Region;
    }

    public AzureVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureVoiceSettings (AzureVoiceSettings azureVoiceSettings) : base(
        azureVoiceSettings
    )
    {  }
    #pragma warning restore CS8618

    public AzureVoiceSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureVoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AzureVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static AzureVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AzureVoiceSettings (
        ApiEnum<string, global::Telnyx.Sdk.Models.Type> type
    ) : this()
    { this.Type = type; }
}

class AzureVoiceSettingsFromRaw : IFromRawJson<AzureVoiceSettings>
{
    /// <inheritdoc/>
    public AzureVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AzureVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice settings provider type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Azure
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Type>
{
    public override global::Telnyx.Sdk.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "azure"=>global::Telnyx.Sdk.Models.Type.Azure,
            _ =>(global::Telnyx.Sdk.Models.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Type.Azure=>"azure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Audio effect to apply.
/// </summary>
[JsonConverter(typeof(EffectConverter))]
public enum Effect
{
    EqCar, EqTelecomhp8k
}sealed class EffectConverter : JsonConverter<Effect>
{
    public override Effect Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "eq_car"=>Effect.EqCar,
            "eq_telecomhp8k"=>Effect.EqTelecomhp8k,
            _ =>(Effect)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Effect value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Effect.EqCar=>"eq_car",
            Effect.EqTelecomhp8k=>"eq_telecomhp8k",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Voice gender filter.
/// </summary>
[JsonConverter(typeof(GenderConverter))]
public enum Gender
{
    Male, Female
}sealed class GenderConverter : JsonConverter<Gender>
{
    public override Gender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "Male"=>Gender.Male, "Female"=>Gender.Female, _ =>(Gender)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Gender value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Gender.Male=>"Male",
            Gender.Female=>"Female",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}