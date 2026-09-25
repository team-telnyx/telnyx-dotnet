using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGatherUsingAudioResponse, ActionGatherUsingAudioResponseFromRaw>))]
public sealed record class ActionGatherUsingAudioResponse : JsonModel
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

    public ActionGatherUsingAudioResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherUsingAudioResponse (
        ActionGatherUsingAudioResponse actionGatherUsingAudioResponse
    ) : base(actionGatherUsingAudioResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGatherUsingAudioResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGatherUsingAudioResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGatherUsingAudioResponseFromRaw.FromRawUnchecked"/>
    public static ActionGatherUsingAudioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGatherUsingAudioResponseFromRaw : IFromRawJson<ActionGatherUsingAudioResponse>
{
    /// <inheritdoc/>
    public ActionGatherUsingAudioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGatherUsingAudioResponse.FromRawUnchecked(rawData);
}