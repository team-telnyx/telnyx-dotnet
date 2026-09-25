using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Settings;

[JsonConverter(typeof(JsonModelConverter<RetrievalSettingsWrapper, RetrievalSettingsWrapperFromRaw>))]
public sealed record class RetrievalSettingsWrapper : JsonModel
{
    /// <summary>
    /// Identifies the record type. Always `ai_collection_settings`.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// How documents are retrieved when searching the collection.
    /// </summary>
    public RetrievalSettings? Retrieval {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetrievalSettings>(
                "retrieval"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retrieval", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        this.Retrieval?.Validate();
    }

    public RetrievalSettingsWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalSettingsWrapper (
        RetrievalSettingsWrapper retrievalSettingsWrapper
    ) : base(retrievalSettingsWrapper)
    {  }
    #pragma warning restore CS8618

    public RetrievalSettingsWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalSettingsWrapper (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalSettingsWrapperFromRaw.FromRawUnchecked"/>
    public static RetrievalSettingsWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RetrievalSettingsWrapperFromRaw : IFromRawJson<RetrievalSettingsWrapper>
{
    /// <inheritdoc/>
    public RetrievalSettingsWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RetrievalSettingsWrapper.FromRawUnchecked(rawData);
}