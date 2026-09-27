using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// A voice clone object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceCloneData, VoiceCloneDataFromRaw>))]
public sealed record class VoiceCloneData : JsonModel
{
    /// <summary>
    /// Unique identifier for the voice clone.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Timestamp when the voice clone was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public ApiEnum<string, VoiceCloneDataGender>? Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceCloneDataGender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// Voice style description. If not explicitly set on upload, falls back to the
    /// source design's prompt text.
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// ISO 639-1 language code of the voice clone.
    /// </summary>
    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language"
            );
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// TTS model identifier for the voice clone.
    /// </summary>
    public ApiEnum<string, VoiceCloneDataModelID>? ModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceCloneDataModelID>>(
                "model_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model_id", value);
        }
    }

    /// <summary>
    /// Name of the voice clone.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Voice synthesis provider used for this clone.
    /// </summary>
    public ApiEnum<string, VoiceCloneDataProvider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceCloneDataProvider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <summary>
    /// List of TTS model identifiers supported by this clone's provider.
    /// </summary>
    public IReadOnlyList<string>? ProviderSupportedModels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "provider_supported_models"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "provider_supported_models",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Provider-specific voice identifier used for TTS synthesis. May differ from
    /// the clone UUID depending on the provider and model.
    /// </summary>
    public string? ProviderVoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "provider_voice_id"
            );
        }
        init { this._rawData.Set("provider_voice_id", value); }
    }

    /// <summary>
    /// Identifies the resource type.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// UUID of the source voice design. `null` for upload-based clones.
    /// </summary>
    public string? SourceVoiceDesignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source_voice_design_id"
            );
        }
        init { this._rawData.Set("source_voice_design_id", value); }
    }

    /// <summary>
    /// Version of the source voice design used. `null` for upload-based clones.
    /// </summary>
    public long? SourceVoiceDesignVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "source_voice_design_version"
            );
        }
        init { this._rawData.Set("source_voice_design_version", value); }
    }

    /// <summary>
    /// Clone status. pending for Ultra clones while on-prem import is in progress,
    /// active once ready, failed if verification timed out, expired if not kept alive.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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

    /// <summary>
    /// Timestamp when the voice clone was last updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Gender?.Validate();
        _ = this.Label;
        _ = this.Language;
        this.ModelID?.Validate();
        _ = this.Name;
        this.Provider?.Validate();
        _ = this.ProviderSupportedModels;
        _ = this.ProviderVoiceID;
        this.RecordType?.Validate();
        _ = this.SourceVoiceDesignID;
        _ = this.SourceVoiceDesignVersion;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public VoiceCloneData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCloneData (VoiceCloneData voiceCloneData) : base(voiceCloneData)
    {  }
    #pragma warning restore CS8618

    public VoiceCloneData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCloneData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCloneDataFromRaw.FromRawUnchecked"/>
    public static VoiceCloneData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceCloneDataFromRaw : IFromRawJson<VoiceCloneData>
{
    /// <inheritdoc/>
    public VoiceCloneData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceCloneData.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(VoiceCloneDataGenderConverter))]
public enum VoiceCloneDataGender
{
    Male, Female, Neutral
}sealed class VoiceCloneDataGenderConverter : JsonConverter<VoiceCloneDataGender>
{
    public override VoiceCloneDataGender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>VoiceCloneDataGender.Male,
            "female"=>VoiceCloneDataGender.Female,
            "neutral"=>VoiceCloneDataGender.Neutral,
            _ =>(VoiceCloneDataGender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceCloneDataGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceCloneDataGender.Male=>"male",
            VoiceCloneDataGender.Female=>"female",
            VoiceCloneDataGender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// TTS model identifier for the voice clone.
/// </summary>
[JsonConverter(typeof(VoiceCloneDataModelIDConverter))]
public enum VoiceCloneDataModelID
{
    Qwen3Tts, Ultra, Speech2_8Turbo
}sealed class VoiceCloneDataModelIDConverter : JsonConverter<VoiceCloneDataModelID>
{
    public override VoiceCloneDataModelID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Qwen3TTS"=>VoiceCloneDataModelID.Qwen3Tts,
            "Ultra"=>VoiceCloneDataModelID.Ultra,
            "speech-2.8-turbo"=>VoiceCloneDataModelID.Speech2_8Turbo,
            _ =>(VoiceCloneDataModelID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceCloneDataModelID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceCloneDataModelID.Qwen3Tts=>"Qwen3TTS",
            VoiceCloneDataModelID.Ultra=>"Ultra",
            VoiceCloneDataModelID.Speech2_8Turbo=>"speech-2.8-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Voice synthesis provider used for this clone.
/// </summary>
[JsonConverter(typeof(VoiceCloneDataProviderConverter))]
public enum VoiceCloneDataProvider
{
    Telnyx, Minimax
}sealed class VoiceCloneDataProviderConverter : JsonConverter<VoiceCloneDataProvider>
{
    public override VoiceCloneDataProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>VoiceCloneDataProvider.Telnyx,
            "minimax"=>VoiceCloneDataProvider.Minimax,
            _ =>(VoiceCloneDataProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceCloneDataProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceCloneDataProvider.Telnyx=>"telnyx",
            VoiceCloneDataProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the resource type.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    VoiceClone
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "voice_clone"=>RecordType.VoiceClone, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.VoiceClone=>"voice_clone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Clone status. pending for Ultra clones while on-prem import is in progress, active
/// once ready, failed if verification timed out, expired if not kept alive.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active, Pending, Failed, Expired
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active"=>Status.Active,
            "pending"=>Status.Pending,
            "failed"=>Status.Failed,
            "expired"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Active=>"active",
            Status.Pending=>"pending",
            Status.Failed=>"failed",
            Status.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}