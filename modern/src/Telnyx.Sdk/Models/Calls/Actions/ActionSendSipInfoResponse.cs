using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSendSipInfoResponse, ActionSendSipInfoResponseFromRaw>))]
public sealed record class ActionSendSipInfoResponse : JsonModel
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

    public ActionSendSipInfoResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSendSipInfoResponse (
        ActionSendSipInfoResponse actionSendSipInfoResponse
    ) : base(actionSendSipInfoResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSendSipInfoResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSendSipInfoResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSendSipInfoResponseFromRaw.FromRawUnchecked"/>
    public static ActionSendSipInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSendSipInfoResponseFromRaw : IFromRawJson<ActionSendSipInfoResponse>
{
    /// <inheritdoc/>
    public ActionSendSipInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSendSipInfoResponse.FromRawUnchecked(rawData);
}