using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartRecordingResponse, ActionStartRecordingResponseFromRaw>))]
public sealed record class ActionStartRecordingResponse : JsonModel
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

    public ActionStartRecordingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartRecordingResponse (
        ActionStartRecordingResponse actionStartRecordingResponse
    ) : base(actionStartRecordingResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartRecordingResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartRecordingResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartRecordingResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartRecordingResponseFromRaw : IFromRawJson<ActionStartRecordingResponse>
{
    /// <inheritdoc/>
    public ActionStartRecordingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartRecordingResponse.FromRawUnchecked(rawData);
}