using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalVoiceIntegrationsPaginationMeta, ExternalVoiceIntegrationsPaginationMetaFromRaw>))]
public sealed record class ExternalVoiceIntegrationsPaginationMeta : JsonModel
{
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    public long? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.TotalPages;
        _ = this.PageSize;
        _ = this.TotalResults;
    }

    public ExternalVoiceIntegrationsPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalVoiceIntegrationsPaginationMeta (
        ExternalVoiceIntegrationsPaginationMeta externalVoiceIntegrationsPaginationMeta
    ) : base(externalVoiceIntegrationsPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public ExternalVoiceIntegrationsPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalVoiceIntegrationsPaginationMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalVoiceIntegrationsPaginationMetaFromRaw.FromRawUnchecked"/>
    public static ExternalVoiceIntegrationsPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalVoiceIntegrationsPaginationMetaFromRaw : IFromRawJson<ExternalVoiceIntegrationsPaginationMeta>
{
    /// <inheritdoc/>
    public ExternalVoiceIntegrationsPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalVoiceIntegrationsPaginationMeta.FromRawUnchecked(rawData);
}