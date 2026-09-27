using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

[JsonConverter(typeof(JsonModelConverter<SpeechToTextListResponse, SpeechToTextListResponseFromRaw>))]
public sealed record class SpeechToTextListResponse : JsonModel
{
    public IReadOnlyList<SttDetailReportResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SttDetailReportResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SttDetailReportResponse>?>(
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

    public SpeechToTextListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextListResponse (
        SpeechToTextListResponse speechToTextListResponse
    ) : base(speechToTextListResponse)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechToTextListResponseFromRaw.FromRawUnchecked"/>
    public static SpeechToTextListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeechToTextListResponseFromRaw : IFromRawJson<SpeechToTextListResponse>
{
    /// <inheritdoc/>
    public SpeechToTextListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechToTextListResponse.FromRawUnchecked(rawData);
}