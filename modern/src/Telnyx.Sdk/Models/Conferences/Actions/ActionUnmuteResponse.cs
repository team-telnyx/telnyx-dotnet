using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionUnmuteResponse, ActionUnmuteResponseFromRaw>))]
public sealed record class ActionUnmuteResponse : JsonModel
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

    public ActionUnmuteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionUnmuteResponse (
        ActionUnmuteResponse actionUnmuteResponse
    ) : base(actionUnmuteResponse)
    {  }
    #pragma warning restore CS8618

    public ActionUnmuteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionUnmuteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionUnmuteResponseFromRaw.FromRawUnchecked"/>
    public static ActionUnmuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionUnmuteResponseFromRaw : IFromRawJson<ActionUnmuteResponse>
{
    /// <inheritdoc/>
    public ActionUnmuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionUnmuteResponse.FromRawUnchecked(rawData);
}