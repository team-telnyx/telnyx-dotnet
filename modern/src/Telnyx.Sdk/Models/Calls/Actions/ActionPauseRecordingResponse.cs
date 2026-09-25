using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionPauseRecordingResponse, ActionPauseRecordingResponseFromRaw>))]
public sealed record class ActionPauseRecordingResponse : JsonModel
{
    public CallControlCommandResult? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlCommandResult>(
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

    public ActionPauseRecordingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionPauseRecordingResponse (
        ActionPauseRecordingResponse actionPauseRecordingResponse
    ) : base(actionPauseRecordingResponse)
    {  }
    #pragma warning restore CS8618

    public ActionPauseRecordingResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionPauseRecordingResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionPauseRecordingResponseFromRaw.FromRawUnchecked"/>
    public static ActionPauseRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionPauseRecordingResponseFromRaw : IFromRawJson<ActionPauseRecordingResponse>
{
    /// <inheritdoc/>
    public ActionPauseRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionPauseRecordingResponse.FromRawUnchecked(rawData);
}