using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGatherDtmfAudioResponse, ActionGatherDtmfAudioResponseFromRaw>))]
public sealed record class ActionGatherDtmfAudioResponse : JsonModel
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

    public ActionGatherDtmfAudioResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherDtmfAudioResponse (
        ActionGatherDtmfAudioResponse actionGatherDtmfAudioResponse
    ) : base(actionGatherDtmfAudioResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGatherDtmfAudioResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGatherDtmfAudioResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGatherDtmfAudioResponseFromRaw.FromRawUnchecked"/>
    public static ActionGatherDtmfAudioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGatherDtmfAudioResponseFromRaw : IFromRawJson<ActionGatherDtmfAudioResponse>
{
    /// <inheritdoc/>
    public ActionGatherDtmfAudioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGatherDtmfAudioResponse.FromRawUnchecked(rawData);
}