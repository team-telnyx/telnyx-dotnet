using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionLeaveQueueResponse, ActionLeaveQueueResponseFromRaw>))]
public sealed record class ActionLeaveQueueResponse : JsonModel
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

    public ActionLeaveQueueResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionLeaveQueueResponse (
        ActionLeaveQueueResponse actionLeaveQueueResponse
    ) : base(actionLeaveQueueResponse)
    {  }
    #pragma warning restore CS8618

    public ActionLeaveQueueResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionLeaveQueueResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionLeaveQueueResponseFromRaw.FromRawUnchecked"/>
    public static ActionLeaveQueueResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionLeaveQueueResponseFromRaw : IFromRawJson<ActionLeaveQueueResponse>
{
    /// <inheritdoc/>
    public ActionLeaveQueueResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionLeaveQueueResponse.FromRawUnchecked(rawData);
}