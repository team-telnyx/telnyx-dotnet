using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionBridgeResponse, ActionBridgeResponseFromRaw>))]
public sealed record class ActionBridgeResponse : JsonModel
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

    public ActionBridgeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionBridgeResponse (
        ActionBridgeResponse actionBridgeResponse
    ) : base(actionBridgeResponse)
    {  }
    #pragma warning restore CS8618

    public ActionBridgeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionBridgeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionBridgeResponseFromRaw.FromRawUnchecked"/>
    public static ActionBridgeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionBridgeResponseFromRaw : IFromRawJson<ActionBridgeResponse>
{
    /// <inheritdoc/>
    public ActionBridgeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionBridgeResponse.FromRawUnchecked(rawData);
}