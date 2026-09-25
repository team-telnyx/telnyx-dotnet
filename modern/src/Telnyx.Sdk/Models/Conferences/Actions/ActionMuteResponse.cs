using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionMuteResponse, ActionMuteResponseFromRaw>))]
public sealed record class ActionMuteResponse : JsonModel
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

    public ActionMuteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionMuteResponse (ActionMuteResponse actionMuteResponse) : base(
        actionMuteResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionMuteResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionMuteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionMuteResponseFromRaw.FromRawUnchecked"/>
    public static ActionMuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionMuteResponseFromRaw : IFromRawJson<ActionMuteResponse>
{
    /// <inheritdoc/>
    public ActionMuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionMuteResponse.FromRawUnchecked(rawData);
}