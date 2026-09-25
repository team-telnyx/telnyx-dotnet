using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartStreamingResponse, ActionStartStreamingResponseFromRaw>))]
public sealed record class ActionStartStreamingResponse : JsonModel
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

    public ActionStartStreamingResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartStreamingResponse (
        ActionStartStreamingResponse actionStartStreamingResponse
    ) : base(actionStartStreamingResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartStreamingResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartStreamingResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartStreamingResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartStreamingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartStreamingResponseFromRaw : IFromRawJson<ActionStartStreamingResponse>
{
    /// <inheritdoc/>
    public ActionStartStreamingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartStreamingResponse.FromRawUnchecked(rawData);
}