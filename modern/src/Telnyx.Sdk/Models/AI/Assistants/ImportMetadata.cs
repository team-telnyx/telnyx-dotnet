using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<ImportMetadata, ImportMetadataFromRaw>))]
public sealed record class ImportMetadata : JsonModel
{
    /// <summary>
    /// ID of the assistant in the provider's system.
    /// </summary>
    public string? ImportID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "import_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("import_id", value);
        }
    }

    /// <summary>
    /// Provider the assistant was imported from.
    /// </summary>
    public ApiEnum<string, ImportProvider>? ImportProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImportProvider>>(
                "import_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("import_provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImportID;
        this.ImportProvider?.Validate();
    }

    public ImportMetadata ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImportMetadata (ImportMetadata importMetadata) : base(importMetadata)
    {  }
    #pragma warning restore CS8618

    public ImportMetadata (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ImportMetadata (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ImportMetadataFromRaw.FromRawUnchecked"/>
    public static ImportMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ImportMetadataFromRaw : IFromRawJson<ImportMetadata>
{
    /// <inheritdoc/>
    public ImportMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ImportMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Provider the assistant was imported from.
/// </summary>
[JsonConverter(typeof(ImportProviderConverter))]
public enum ImportProvider
{
    Elevenlabs, Vapi, Retell
}sealed class ImportProviderConverter : JsonConverter<ImportProvider>
{
    public override ImportProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "elevenlabs"=>ImportProvider.Elevenlabs,
            "vapi"=>ImportProvider.Vapi,
            "retell"=>ImportProvider.Retell,
            _ =>(ImportProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImportProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ImportProvider.Elevenlabs=>"elevenlabs",
            ImportProvider.Vapi=>"vapi",
            ImportProvider.Retell=>"retell",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}