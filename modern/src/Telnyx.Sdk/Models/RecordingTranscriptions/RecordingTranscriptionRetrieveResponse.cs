using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RecordingTranscriptions;

[JsonConverter(typeof(JsonModelConverter<RecordingTranscriptionRetrieveResponse, RecordingTranscriptionRetrieveResponseFromRaw>))]
public sealed record class RecordingTranscriptionRetrieveResponse : JsonModel
{
    public RecordingTranscription? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecordingTranscription>(
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

    public RecordingTranscriptionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingTranscriptionRetrieveResponse (
        RecordingTranscriptionRetrieveResponse recordingTranscriptionRetrieveResponse
    ) : base(recordingTranscriptionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RecordingTranscriptionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingTranscriptionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingTranscriptionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RecordingTranscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingTranscriptionRetrieveResponseFromRaw : IFromRawJson<RecordingTranscriptionRetrieveResponse>
{
    /// <inheritdoc/>
    public RecordingTranscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingTranscriptionRetrieveResponse.FromRawUnchecked(rawData);
}