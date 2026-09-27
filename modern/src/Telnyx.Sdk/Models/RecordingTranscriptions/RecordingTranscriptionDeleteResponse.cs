using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RecordingTranscriptions;

[JsonConverter(typeof(JsonModelConverter<RecordingTranscriptionDeleteResponse, RecordingTranscriptionDeleteResponseFromRaw>))]
public sealed record class RecordingTranscriptionDeleteResponse : JsonModel
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

    public RecordingTranscriptionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingTranscriptionDeleteResponse (
        RecordingTranscriptionDeleteResponse recordingTranscriptionDeleteResponse
    ) : base(recordingTranscriptionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public RecordingTranscriptionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingTranscriptionDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingTranscriptionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static RecordingTranscriptionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingTranscriptionDeleteResponseFromRaw : IFromRawJson<RecordingTranscriptionDeleteResponse>
{
    /// <inheritdoc/>
    public RecordingTranscriptionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingTranscriptionDeleteResponse.FromRawUnchecked(rawData);
}