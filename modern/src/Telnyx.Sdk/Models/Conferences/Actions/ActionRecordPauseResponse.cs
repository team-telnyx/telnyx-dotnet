using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRecordPauseResponse, ActionRecordPauseResponseFromRaw>))]
public sealed record class ActionRecordPauseResponse : JsonModel
{
    public ConferenceCommandResult? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceCommandResult>(
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

    public ActionRecordPauseResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRecordPauseResponse (
        ActionRecordPauseResponse actionRecordPauseResponse
    ) : base(actionRecordPauseResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRecordPauseResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRecordPauseResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRecordPauseResponseFromRaw.FromRawUnchecked"/>
    public static ActionRecordPauseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRecordPauseResponseFromRaw : IFromRawJson<ActionRecordPauseResponse>
{
    /// <inheritdoc/>
    public ActionRecordPauseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRecordPauseResponse.FromRawUnchecked(rawData);
}