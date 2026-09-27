using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionReferResponse, ActionReferResponseFromRaw>))]
public sealed record class ActionReferResponse : JsonModel
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

    public ActionReferResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionReferResponse (ActionReferResponse actionReferResponse) : base(
        actionReferResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionReferResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionReferResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionReferResponseFromRaw.FromRawUnchecked"/>
    public static ActionReferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionReferResponseFromRaw : IFromRawJson<ActionReferResponse>
{
    /// <inheritdoc/>
    public ActionReferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionReferResponse.FromRawUnchecked(rawData);
}