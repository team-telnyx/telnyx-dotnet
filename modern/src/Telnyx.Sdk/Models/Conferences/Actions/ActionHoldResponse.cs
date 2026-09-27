using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionHoldResponse, ActionHoldResponseFromRaw>))]
public sealed record class ActionHoldResponse : JsonModel
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

    public ActionHoldResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionHoldResponse (ActionHoldResponse actionHoldResponse) : base(
        actionHoldResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionHoldResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionHoldResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionHoldResponseFromRaw.FromRawUnchecked"/>
    public static ActionHoldResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionHoldResponseFromRaw : IFromRawJson<ActionHoldResponse>
{
    /// <inheritdoc/>
    public ActionHoldResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionHoldResponse.FromRawUnchecked(rawData);
}