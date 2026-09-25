using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PronunciationDicts;

/// <summary>
/// A pronunciation dictionary record.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PronunciationDictData, PronunciationDictDataFromRaw>))]
public sealed record class PronunciationDictData : JsonModel
{
    /// <summary>
    /// Unique identifier for the pronunciation dictionary.
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
    /// ISO 8601 timestamp with millisecond precision.
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
    /// List of pronunciation items (alias or phoneme type).
    /// </summary>
    public IReadOnlyList<PronunciationDictItem>? Items {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PronunciationDictItem>>(
                "items"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PronunciationDictItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name for the dictionary. Must be unique within the organization.
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
    /// ISO 8601 timestamp with millisecond precision.
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
    /// Auto-incrementing version number. Increases by 1 on each update. Used for
    /// optimistic concurrency control and cache invalidation.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        this.RecordType?.Validate();
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public PronunciationDictData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PronunciationDictData (
        PronunciationDictData pronunciationDictData
    ) : base(pronunciationDictData)
    {  }
    #pragma warning restore CS8618

    public PronunciationDictData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PronunciationDictData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PronunciationDictDataFromRaw.FromRawUnchecked"/>
    public static PronunciationDictData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PronunciationDictDataFromRaw : IFromRawJson<PronunciationDictData>
{
    /// <inheritdoc/>
    public PronunciationDictData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PronunciationDictData.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the resource type.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    PronunciationDict
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pronunciation_dict"=>RecordType.PronunciationDict,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.PronunciationDict=>"pronunciation_dict",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}