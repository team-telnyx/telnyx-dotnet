using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

[JsonConverter(typeof(JsonModelConverter<CsvDownloadRetrieveResponse, CsvDownloadRetrieveResponseFromRaw>))]
public sealed record class CsvDownloadRetrieveResponse : JsonModel
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

    public CsvDownloadRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CsvDownloadRetrieveResponse (
        CsvDownloadRetrieveResponse csvDownloadRetrieveResponse
    ) : base(csvDownloadRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CsvDownloadRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CsvDownloadRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CsvDownloadRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CsvDownloadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CsvDownloadRetrieveResponseFromRaw : IFromRawJson<CsvDownloadRetrieveResponse>
{
    /// <inheritdoc/>
    public CsvDownloadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CsvDownloadRetrieveResponse.FromRawUnchecked(rawData);
}