using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceListResponse, VoiceListResponseFromRaw>))]
public sealed record class VoiceListResponse : JsonModel
{
    public IReadOnlyList<CdrDetailedReqResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CdrDetailedReqResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CdrDetailedReqResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public BatchCsvPaginationMeta705dfa7312? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchCsvPaginationMeta705dfa7312>(
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

    public VoiceListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceListResponse (VoiceListResponse voiceListResponse) : base(
        voiceListResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceListResponseFromRaw.FromRawUnchecked"/>
    public static VoiceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceListResponseFromRaw : IFromRawJson<VoiceListResponse>
{
    /// <inheritdoc/>
    public VoiceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceListResponse.FromRawUnchecked(rawData);
}