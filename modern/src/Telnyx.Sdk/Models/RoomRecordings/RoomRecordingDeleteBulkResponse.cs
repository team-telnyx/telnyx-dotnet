using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomRecordings;

[JsonConverter(typeof(JsonModelConverter<RoomRecordingDeleteBulkResponse, RoomRecordingDeleteBulkResponseFromRaw>))]
public sealed record class RoomRecordingDeleteBulkResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public RoomRecordingDeleteBulkResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomRecordingDeleteBulkResponse (
        RoomRecordingDeleteBulkResponse roomRecordingDeleteBulkResponse
    ) : base(roomRecordingDeleteBulkResponse)
    {  }
    #pragma warning restore CS8618

    public RoomRecordingDeleteBulkResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomRecordingDeleteBulkResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomRecordingDeleteBulkResponseFromRaw.FromRawUnchecked"/>
    public static RoomRecordingDeleteBulkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomRecordingDeleteBulkResponseFromRaw : IFromRawJson<RoomRecordingDeleteBulkResponse>
{
    /// <inheritdoc/>
    public RoomRecordingDeleteBulkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomRecordingDeleteBulkResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Amount of room recordings affected
    /// </summary>
    public long? RoomRecordings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "room_recordings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("room_recordings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RoomRecordings; }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}