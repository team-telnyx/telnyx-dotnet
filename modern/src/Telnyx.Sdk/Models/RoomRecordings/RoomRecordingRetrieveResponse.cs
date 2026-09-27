using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomRecordings;

[JsonConverter(typeof(JsonModelConverter<RoomRecordingRetrieveResponse, RoomRecordingRetrieveResponseFromRaw>))]
public sealed record class RoomRecordingRetrieveResponse : JsonModel
{
    public RoomRecording? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomRecording>(
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

    public RoomRecordingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingRetrieveResponse (
        RoomRecordingRetrieveResponse roomRecordingRetrieveResponse
    ) : base(roomRecordingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RoomRecordingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingRetrieveResponseFromRaw : IFromRawJson<RoomRecordingRetrieveResponse>
{
    /// <inheritdoc/>
    public RoomRecordingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecordingRetrieveResponse.FromRawUnchecked(rawData);
}