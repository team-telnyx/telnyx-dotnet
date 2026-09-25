using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionEnqueueResponse, ActionEnqueueResponseFromRaw>))]
public sealed record class ActionEnqueueResponse : JsonModel
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

    public ActionEnqueueResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionEnqueueResponse (
        ActionEnqueueResponse actionEnqueueResponse
    ) : base(actionEnqueueResponse)
    {  }
    #pragma warning restore CS8618

    public ActionEnqueueResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionEnqueueResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionEnqueueResponseFromRaw.FromRawUnchecked"/>
    public static ActionEnqueueResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionEnqueueResponseFromRaw : IFromRawJson<ActionEnqueueResponse>
{
    /// <inheritdoc/>
    public ActionEnqueueResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionEnqueueResponse.FromRawUnchecked(rawData);
}