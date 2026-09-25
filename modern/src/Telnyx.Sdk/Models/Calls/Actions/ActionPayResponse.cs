using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionPayResponse, ActionPayResponseFromRaw>))]
public sealed record class ActionPayResponse : JsonModel
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

    public ActionPayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionPayResponse (ActionPayResponse actionPayResponse) : base(
        actionPayResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionPayResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionPayResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionPayResponseFromRaw.FromRawUnchecked"/>
    public static ActionPayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionPayResponseFromRaw : IFromRawJson<ActionPayResponse>
{
    /// <inheritdoc/>
    public ActionPayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionPayResponse.FromRawUnchecked(rawData);
}