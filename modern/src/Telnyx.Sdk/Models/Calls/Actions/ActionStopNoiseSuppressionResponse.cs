using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStopNoiseSuppressionResponse, ActionStopNoiseSuppressionResponseFromRaw>))]
public sealed record class ActionStopNoiseSuppressionResponse : JsonModel
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

    public ActionStopNoiseSuppressionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStopNoiseSuppressionResponse (
        ActionStopNoiseSuppressionResponse actionStopNoiseSuppressionResponse
    ) : base(actionStopNoiseSuppressionResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStopNoiseSuppressionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStopNoiseSuppressionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStopNoiseSuppressionResponseFromRaw.FromRawUnchecked"/>
    public static ActionStopNoiseSuppressionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStopNoiseSuppressionResponseFromRaw : IFromRawJson<ActionStopNoiseSuppressionResponse>
{
    /// <inheritdoc/>
    public ActionStopNoiseSuppressionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStopNoiseSuppressionResponse.FromRawUnchecked(rawData);
}