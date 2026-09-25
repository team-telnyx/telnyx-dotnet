using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionPlayResponse, ActionPlayResponseFromRaw>))]
public sealed record class ActionPlayResponse : JsonModel
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

    public ActionPlayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionPlayResponse (ActionPlayResponse actionPlayResponse) : base(
        actionPlayResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionPlayResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionPlayResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionPlayResponseFromRaw.FromRawUnchecked"/>
    public static ActionPlayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionPlayResponseFromRaw : IFromRawJson<ActionPlayResponse>
{
    /// <inheritdoc/>
    public ActionPlayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionPlayResponse.FromRawUnchecked(rawData);
}