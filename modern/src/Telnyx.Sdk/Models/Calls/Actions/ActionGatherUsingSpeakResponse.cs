using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGatherUsingSpeakResponse, ActionGatherUsingSpeakResponseFromRaw>))]
public sealed record class ActionGatherUsingSpeakResponse : JsonModel
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

    public ActionGatherUsingSpeakResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherUsingSpeakResponse (
        ActionGatherUsingSpeakResponse actionGatherUsingSpeakResponse
    ) : base(actionGatherUsingSpeakResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGatherUsingSpeakResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGatherUsingSpeakResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGatherUsingSpeakResponseFromRaw.FromRawUnchecked"/>
    public static ActionGatherUsingSpeakResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGatherUsingSpeakResponseFromRaw : IFromRawJson<ActionGatherUsingSpeakResponse>
{
    /// <inheritdoc/>
    public ActionGatherUsingSpeakResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGatherUsingSpeakResponse.FromRawUnchecked(rawData);
}