using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionResumeRecordingResponse, ActionResumeRecordingResponseFromRaw>))]
public sealed record class ActionResumeRecordingResponse : JsonModel
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

    public ActionResumeRecordingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionResumeRecordingResponse (
        ActionResumeRecordingResponse actionResumeRecordingResponse
    ) : base(actionResumeRecordingResponse)
    {  }
    #pragma warning restore CS8618

    public ActionResumeRecordingResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionResumeRecordingResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionResumeRecordingResponseFromRaw.FromRawUnchecked"/>
    public static ActionResumeRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionResumeRecordingResponseFromRaw : IFromRawJson<ActionResumeRecordingResponse>
{
    /// <inheritdoc/>
    public ActionResumeRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionResumeRecordingResponse.FromRawUnchecked(rawData);
}