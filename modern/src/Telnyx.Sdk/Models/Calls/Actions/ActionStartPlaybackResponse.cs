using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartPlaybackResponse, ActionStartPlaybackResponseFromRaw>))]
public sealed record class ActionStartPlaybackResponse : JsonModel
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

    public ActionStartPlaybackResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartPlaybackResponse (
        ActionStartPlaybackResponse actionStartPlaybackResponse
    ) : base(actionStartPlaybackResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartPlaybackResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartPlaybackResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartPlaybackResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartPlaybackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartPlaybackResponseFromRaw : IFromRawJson<ActionStartPlaybackResponse>
{
    /// <inheritdoc/>
    public ActionStartPlaybackResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartPlaybackResponse.FromRawUnchecked(rawData);
}