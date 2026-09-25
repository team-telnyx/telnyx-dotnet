using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

[JsonConverter(typeof(JsonModelConverter<SpeechToTextCreateResponse, SpeechToTextCreateResponseFromRaw>))]
public sealed record class SpeechToTextCreateResponse : JsonModel
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

    public SpeechToTextCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextCreateResponse (
        SpeechToTextCreateResponse speechToTextCreateResponse
    ) : base(speechToTextCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechToTextCreateResponseFromRaw.FromRawUnchecked"/>
    public static SpeechToTextCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeechToTextCreateResponseFromRaw : IFromRawJson<SpeechToTextCreateResponse>
{
    /// <inheritdoc/>
    public SpeechToTextCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechToTextCreateResponse.FromRawUnchecked(rawData);
}