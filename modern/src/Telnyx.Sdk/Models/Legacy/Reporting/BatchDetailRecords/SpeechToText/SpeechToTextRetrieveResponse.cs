using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

[JsonConverter(typeof(JsonModelConverter<SpeechToTextRetrieveResponse, SpeechToTextRetrieveResponseFromRaw>))]
public sealed record class SpeechToTextRetrieveResponse : JsonModel
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

    public SpeechToTextRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechToTextRetrieveResponse (
        SpeechToTextRetrieveResponse speechToTextRetrieveResponse
    ) : base(speechToTextRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SpeechToTextRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechToTextRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechToTextRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SpeechToTextRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SpeechToTextRetrieveResponseFromRaw : IFromRawJson<SpeechToTextRetrieveResponse>
{
    /// <inheritdoc/>
    public SpeechToTextRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechToTextRetrieveResponse.FromRawUnchecked(rawData);
}