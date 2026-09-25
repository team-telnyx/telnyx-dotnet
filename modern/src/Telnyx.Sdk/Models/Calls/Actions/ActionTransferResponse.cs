using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionTransferResponse, ActionTransferResponseFromRaw>))]
public sealed record class ActionTransferResponse : JsonModel
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

    public ActionTransferResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionTransferResponse (
        ActionTransferResponse actionTransferResponse
    ) : base(actionTransferResponse)
    {  }
    #pragma warning restore CS8618

    public ActionTransferResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionTransferResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionTransferResponseFromRaw.FromRawUnchecked"/>
    public static ActionTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionTransferResponseFromRaw : IFromRawJson<ActionTransferResponse>
{
    /// <inheritdoc/>
    public ActionTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionTransferResponse.FromRawUnchecked(rawData);
}