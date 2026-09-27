using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStopTranscriptionResponse, ActionStopTranscriptionResponseFromRaw>))]
public sealed record class ActionStopTranscriptionResponse : JsonModel
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

    public ActionStopTranscriptionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStopTranscriptionResponse (
        ActionStopTranscriptionResponse actionStopTranscriptionResponse
    ) : base(actionStopTranscriptionResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStopTranscriptionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStopTranscriptionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStopTranscriptionResponseFromRaw.FromRawUnchecked"/>
    public static ActionStopTranscriptionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStopTranscriptionResponseFromRaw : IFromRawJson<ActionStopTranscriptionResponse>
{
    /// <inheritdoc/>
    public ActionStopTranscriptionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStopTranscriptionResponse.FromRawUnchecked(rawData);
}