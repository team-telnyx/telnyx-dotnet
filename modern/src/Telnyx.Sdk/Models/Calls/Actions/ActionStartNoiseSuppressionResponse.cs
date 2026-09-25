using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartNoiseSuppressionResponse, ActionStartNoiseSuppressionResponseFromRaw>))]
public sealed record class ActionStartNoiseSuppressionResponse : JsonModel
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

    public ActionStartNoiseSuppressionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartNoiseSuppressionResponse (
        ActionStartNoiseSuppressionResponse actionStartNoiseSuppressionResponse
    ) : base(actionStartNoiseSuppressionResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartNoiseSuppressionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartNoiseSuppressionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartNoiseSuppressionResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartNoiseSuppressionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartNoiseSuppressionResponseFromRaw : IFromRawJson<ActionStartNoiseSuppressionResponse>
{
    /// <inheritdoc/>
    public ActionStartNoiseSuppressionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartNoiseSuppressionResponse.FromRawUnchecked(rawData);
}