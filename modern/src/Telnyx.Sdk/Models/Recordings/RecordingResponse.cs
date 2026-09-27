using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Recordings;

[JsonConverter(typeof(JsonModelConverter<RecordingResponse, RecordingResponseFromRaw>))]
public sealed record class RecordingResponse : JsonModel
{
    public RecordingResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecordingResponseData>(
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

    public RecordingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingResponse (RecordingResponse recordingResponse) : base(
        recordingResponse
    )
    {  }
    #pragma warning restore CS8618

    public RecordingResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingResponseFromRaw.FromRawUnchecked"/>
    public static RecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingResponseFromRaw : IFromRawJson<RecordingResponse>
{
    /// <inheritdoc/>
    public RecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingResponse.FromRawUnchecked(rawData);
}