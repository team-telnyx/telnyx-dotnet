using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartSiprecResponse, ActionStartSiprecResponseFromRaw>))]
public sealed record class ActionStartSiprecResponse : JsonModel
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

    public ActionStartSiprecResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartSiprecResponse (
        ActionStartSiprecResponse actionStartSiprecResponse
    ) : base(actionStartSiprecResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartSiprecResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartSiprecResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartSiprecResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartSiprecResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartSiprecResponseFromRaw : IFromRawJson<ActionStartSiprecResponse>
{
    /// <inheritdoc/>
    public ActionStartSiprecResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartSiprecResponse.FromRawUnchecked(rawData);
}