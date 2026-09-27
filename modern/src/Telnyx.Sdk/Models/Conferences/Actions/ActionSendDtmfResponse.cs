using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSendDtmfResponse, ActionSendDtmfResponseFromRaw>))]
public sealed record class ActionSendDtmfResponse : JsonModel
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

    public ActionSendDtmfResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSendDtmfResponse (
        ActionSendDtmfResponse actionSendDtmfResponse
    ) : base(actionSendDtmfResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSendDtmfResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSendDtmfResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSendDtmfResponseFromRaw.FromRawUnchecked"/>
    public static ActionSendDtmfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSendDtmfResponseFromRaw : IFromRawJson<ActionSendDtmfResponse>
{
    /// <inheritdoc/>
    public ActionSendDtmfResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSendDtmfResponse.FromRawUnchecked(rawData);
}