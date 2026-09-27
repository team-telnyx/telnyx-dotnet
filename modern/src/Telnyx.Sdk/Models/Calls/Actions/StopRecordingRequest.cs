using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<StopRecordingRequest, StopRecordingRequestFromRaw>))]
public sealed record class StopRecordingRequest : JsonModel
{
    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the resource.
    /// </summary>
    public string? RecordingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientState;
        _ = this.CommandID;
        _ = this.RecordingID;
    }

    public StopRecordingRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StopRecordingRequest (
        StopRecordingRequest stopRecordingRequest
    ) : base(stopRecordingRequest)
    {  }
    #pragma warning restore CS8618

    public StopRecordingRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StopRecordingRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StopRecordingRequestFromRaw.FromRawUnchecked"/>
    public static StopRecordingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StopRecordingRequestFromRaw : IFromRawJson<StopRecordingRequest>
{
    /// <inheritdoc/>
    public StopRecordingRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StopRecordingRequest.FromRawUnchecked(rawData);
}