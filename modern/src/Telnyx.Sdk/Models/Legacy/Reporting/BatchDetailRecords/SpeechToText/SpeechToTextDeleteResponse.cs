using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

[JsonConverter(typeof(JsonModelConverter<SpeechToTextDeleteResponse, SpeechToTextDeleteResponseFromRaw>))]
public sealed record class SpeechToTextDeleteResponse : JsonModel
{
    public SttDetailReportResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SttDetailReportResponse>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public SpeechToTextDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextDeleteResponse (
        SpeechToTextDeleteResponse speechToTextDeleteResponse
    ) : base(speechToTextDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechToTextDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SpeechToTextDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeechToTextDeleteResponseFromRaw : IFromRawJson<SpeechToTextDeleteResponse>
{
    /// <inheritdoc/>
    public SpeechToTextDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechToTextDeleteResponse.FromRawUnchecked(rawData);
}