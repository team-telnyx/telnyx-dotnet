using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGatherResponse, ActionGatherResponseFromRaw>))]
public sealed record class ActionGatherResponse : JsonModel
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

    public ActionGatherResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherResponse (
        ActionGatherResponse actionGatherResponse
    ) : base(actionGatherResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGatherResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGatherResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGatherResponseFromRaw.FromRawUnchecked"/>
    public static ActionGatherResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGatherResponseFromRaw : IFromRawJson<ActionGatherResponse>
{
    /// <inheritdoc/>
    public ActionGatherResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGatherResponse.FromRawUnchecked(rawData);
}