using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRecordStartResponse, ActionRecordStartResponseFromRaw>))]
public sealed record class ActionRecordStartResponse : JsonModel
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

    public ActionRecordStartResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRecordStartResponse (
        ActionRecordStartResponse actionRecordStartResponse
    ) : base(actionRecordStartResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRecordStartResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRecordStartResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRecordStartResponseFromRaw.FromRawUnchecked"/>
    public static ActionRecordStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRecordStartResponseFromRaw : IFromRawJson<ActionRecordStartResponse>
{
    /// <inheritdoc/>
    public ActionRecordStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRecordStartResponse.FromRawUnchecked(rawData);
}