using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

[JsonConverter(typeof(JsonModelConverter<CsvDownloadCreateResponse, CsvDownloadCreateResponseFromRaw>))]
public sealed record class CsvDownloadCreateResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public CsvDownloadCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CsvDownloadCreateResponse (
        CsvDownloadCreateResponse csvDownloadCreateResponse
    ) : base(csvDownloadCreateResponse)
    {  }
    #pragma warning restore CS8618

    public CsvDownloadCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CsvDownloadCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CsvDownloadCreateResponseFromRaw.FromRawUnchecked"/>
    public static CsvDownloadCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CsvDownloadCreateResponseFromRaw : IFromRawJson<CsvDownloadCreateResponse>
{
    /// <inheritdoc/>
    public CsvDownloadCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CsvDownloadCreateResponse.FromRawUnchecked(rawData);
}