using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

[JsonConverter(typeof(JsonModelConverter<CsvDownloadListPageResponse, CsvDownloadListPageResponseFromRaw>))]
public sealed record class CsvDownloadListPageResponse : JsonModel
{
    public IReadOnlyList<CsvDownload>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CsvDownload>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CsvDownload>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public CsvDownloadListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CsvDownloadListPageResponse (
        CsvDownloadListPageResponse csvDownloadListPageResponse
    ) : base(csvDownloadListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CsvDownloadListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CsvDownloadListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CsvDownloadListPageResponseFromRaw.FromRawUnchecked"/>
    public static CsvDownloadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CsvDownloadListPageResponseFromRaw : IFromRawJson<CsvDownloadListPageResponse>
{
    /// <inheritdoc/>
    public CsvDownloadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CsvDownloadListPageResponse.FromRawUnchecked(rawData);
}