using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionBulkDisableVoiceResponse, ActionBulkDisableVoiceResponseFromRaw>))]
public sealed record class ActionBulkDisableVoiceResponse : JsonModel
{
    /// <summary>
    /// This object represents a bulk SIM card action. It groups SIM card actions
    /// created through a bulk endpoint under a single resource for further lookup.
    /// </summary>
    public BulkSimCardAction? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BulkSimCardAction>(
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

    public ActionBulkDisableVoiceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionBulkDisableVoiceResponse (
        ActionBulkDisableVoiceResponse actionBulkDisableVoiceResponse
    ) : base(actionBulkDisableVoiceResponse)
    {  }
    #pragma warning restore CS8618

    public ActionBulkDisableVoiceResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionBulkDisableVoiceResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionBulkDisableVoiceResponseFromRaw.FromRawUnchecked"/>
    public static ActionBulkDisableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionBulkDisableVoiceResponseFromRaw : IFromRawJson<ActionBulkDisableVoiceResponse>
{
    /// <inheritdoc/>
    public ActionBulkDisableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionBulkDisableVoiceResponse.FromRawUnchecked(rawData);
}