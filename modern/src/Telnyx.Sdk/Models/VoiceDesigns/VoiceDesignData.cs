using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VoiceDesigns;

/// <summary>
/// A voice design object with full version detail.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignData, VoiceDesignDataFromRaw>))]
public sealed record class VoiceDesignData : JsonModel
{
    /// <summary>
    /// Unique identifier for the voice design.
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
    /// Timestamp when the voice design was first created.
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
    /// Name of the voice design.
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
    /// Natural language prompt used to define the voice style for this version.
    /// </summary>
    public string? Prompt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "prompt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt", value);
        }
    }

    /// <summary>
    /// Voice synthesis provider used for this design.
    /// </summary>
    public ApiEnum<string, VoiceDesignDataProvider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceDesignDataProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// List of TTS model identifiers supported by this design's provider (e.g. `Qwen3TTS`, `speech-02-turbo`).
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
    /// Provider-specific voice identifier. For Telnyx designs this is the design
    /// version ID; for Minimax it is the Minimax-assigned voice ID.
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
    /// Sample text used to synthesize this version.
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Timestamp when the voice design was last updated.
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

    /// <summary>
    /// Version number of this voice design.
    /// </summary>
    public long? Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <summary>
    /// Timestamp when this specific version was created.
    /// </summary>
    public System::DateTimeOffset? VersionCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "version_created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version_created_at", value);
        }
    }

    /// <summary>
    /// Size of the voice sample audio in bytes.
    /// </summary>
    public long? VoiceSampleSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "voice_sample_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_sample_size", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.Prompt;
        this.Provider?.Validate();
        _ = this.ProviderSupportedModels;
        _ = this.ProviderVoiceID;
        this.RecordType?.Validate();
        _ = this.Text;
        _ = this.UpdatedAt;
        _ = this.Version;
        _ = this.VersionCreatedAt;
        _ = this.VoiceSampleSize;
    }

    public VoiceDesignData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignData (VoiceDesignData voiceDesignData) : base(
        voiceDesignData
    )
    {  }
    #pragma warning restore CS8618

    public VoiceDesignData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignDataFromRaw.FromRawUnchecked"/>
    public static VoiceDesignData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignDataFromRaw : IFromRawJson<VoiceDesignData>
{
    /// <inheritdoc/>
    public VoiceDesignData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignData.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice synthesis provider used for this design.
/// </summary>
[JsonConverter(typeof(VoiceDesignDataProviderConverter))]
public enum VoiceDesignDataProvider
{
    Telnyx, Minimax
}sealed class VoiceDesignDataProviderConverter : JsonConverter<VoiceDesignDataProvider>
{
    public override VoiceDesignDataProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>VoiceDesignDataProvider.Telnyx,
            "minimax"=>VoiceDesignDataProvider.Minimax,
            _ =>(VoiceDesignDataProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceDesignDataProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceDesignDataProvider.Telnyx=>"telnyx",
            VoiceDesignDataProvider.Minimax=>"minimax",
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
    VoiceDesign
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "voice_design"=>RecordType.VoiceDesign, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.VoiceDesign=>"voice_design",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}