using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionLeaveResponse, ActionLeaveResponseFromRaw>))]
public sealed record class ActionLeaveResponse : JsonModel
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

    public ActionLeaveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionLeaveResponse (ActionLeaveResponse actionLeaveResponse) : base(
        actionLeaveResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionLeaveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionLeaveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionLeaveResponseFromRaw.FromRawUnchecked"/>
    public static ActionLeaveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionLeaveResponseFromRaw : IFromRawJson<ActionLeaveResponse>
{
    /// <inheritdoc/>
    public ActionLeaveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionLeaveResponse.FromRawUnchecked(rawData);
}