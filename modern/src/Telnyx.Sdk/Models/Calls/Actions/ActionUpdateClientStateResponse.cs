using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionUpdateClientStateResponse, ActionUpdateClientStateResponseFromRaw>))]
public sealed record class ActionUpdateClientStateResponse : JsonModel
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

    public ActionUpdateClientStateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionUpdateClientStateResponse (
        ActionUpdateClientStateResponse actionUpdateClientStateResponse
    ) : base(actionUpdateClientStateResponse)
    {  }
    #pragma warning restore CS8618

    public ActionUpdateClientStateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionUpdateClientStateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionUpdateClientStateResponseFromRaw.FromRawUnchecked"/>
    public static ActionUpdateClientStateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionUpdateClientStateResponseFromRaw : IFromRawJson<ActionUpdateClientStateResponse>
{
    /// <inheritdoc/>
    public ActionUpdateClientStateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionUpdateClientStateResponse.FromRawUnchecked(rawData);
}