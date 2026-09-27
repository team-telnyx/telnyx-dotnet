using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartTranscriptionResponse, ActionStartTranscriptionResponseFromRaw>))]
public sealed record class ActionStartTranscriptionResponse : JsonModel
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

    public ActionStartTranscriptionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartTranscriptionResponse (
        ActionStartTranscriptionResponse actionStartTranscriptionResponse
    ) : base(actionStartTranscriptionResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartTranscriptionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartTranscriptionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartTranscriptionResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartTranscriptionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartTranscriptionResponseFromRaw : IFromRawJson<ActionStartTranscriptionResponse>
{
    /// <inheritdoc/>
    public ActionStartTranscriptionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartTranscriptionResponse.FromRawUnchecked(rawData);
}