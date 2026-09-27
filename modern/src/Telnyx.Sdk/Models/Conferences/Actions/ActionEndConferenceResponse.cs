using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionEndConferenceResponse, ActionEndConferenceResponseFromRaw>))]
public sealed record class ActionEndConferenceResponse : JsonModel
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

    public ActionEndConferenceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionEndConferenceResponse (
        ActionEndConferenceResponse actionEndConferenceResponse
    ) : base(actionEndConferenceResponse)
    {  }
    #pragma warning restore CS8618

    public ActionEndConferenceResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionEndConferenceResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionEndConferenceResponseFromRaw.FromRawUnchecked"/>
    public static ActionEndConferenceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionEndConferenceResponseFromRaw : IFromRawJson<ActionEndConferenceResponse>
{
    /// <inheritdoc/>
    public ActionEndConferenceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionEndConferenceResponse.FromRawUnchecked(rawData);
}