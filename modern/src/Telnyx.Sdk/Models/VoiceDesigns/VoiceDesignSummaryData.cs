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
/// A summarized voice design object (without version-specific fields).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignSummaryData, VoiceDesignSummaryDataFromRaw>))]
public sealed record class VoiceDesignSummaryData : JsonModel
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
    /// Voice synthesis provider used for this design.
    /// </summary>
    public ApiEnum<string, VoiceDesignSummaryDataProvider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceDesignSummaryDataProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// List of TTS model identifiers supported by this design's provider.
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
    /// Identifies the resource type.
    /// </summary>
    public ApiEnum<string, VoiceDesignSummaryDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceDesignSummaryDataRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        this.Provider?.Validate();
        _ = this.ProviderSupportedModels;
        this.RecordType?.Validate();
        _ = this.UpdatedAt;
    }

    public VoiceDesignSummaryData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignSummaryData (
        VoiceDesignSummaryData voiceDesignSummaryData
    ) : base(voiceDesignSummaryData)
    {  }
    #pragma warning restore CS8618

    public VoiceDesignSummaryData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignSummaryData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignSummaryDataFromRaw.FromRawUnchecked"/>
    public static VoiceDesignSummaryData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignSummaryDataFromRaw : IFromRawJson<VoiceDesignSummaryData>
{
    /// <inheritdoc/>
    public VoiceDesignSummaryData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignSummaryData.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice synthesis provider used for this design.
/// </summary>
[JsonConverter(typeof(VoiceDesignSummaryDataProviderConverter))]
public enum VoiceDesignSummaryDataProvider
{
    Telnyx, Minimax
}sealed class VoiceDesignSummaryDataProviderConverter : JsonConverter<VoiceDesignSummaryDataProvider>
{
    public override VoiceDesignSummaryDataProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>VoiceDesignSummaryDataProvider.Telnyx,
            "minimax"=>VoiceDesignSummaryDataProvider.Minimax,
            _ =>(VoiceDesignSummaryDataProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceDesignSummaryDataProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceDesignSummaryDataProvider.Telnyx=>"telnyx",
            VoiceDesignSummaryDataProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the resource type.
/// </summary>
[JsonConverter(typeof(VoiceDesignSummaryDataRecordTypeConverter))]
public enum VoiceDesignSummaryDataRecordType
{
    VoiceDesign
}sealed class VoiceDesignSummaryDataRecordTypeConverter : JsonConverter<VoiceDesignSummaryDataRecordType>
{
    public override VoiceDesignSummaryDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "voice_design"=>VoiceDesignSummaryDataRecordType.VoiceDesign,
            _ =>(VoiceDesignSummaryDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceDesignSummaryDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceDesignSummaryDataRecordType.VoiceDesign=>"voice_design",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}