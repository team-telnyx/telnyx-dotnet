using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberReservations.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionExtendResponse, ActionExtendResponseFromRaw>))]
public sealed record class ActionExtendResponse : JsonModel
{
    public NumberReservation? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberReservation>(
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

    public ActionExtendResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionExtendResponse (
        ActionExtendResponse actionExtendResponse
    ) : base(actionExtendResponse)
    {  }
    #pragma warning restore CS8618

    public ActionExtendResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionExtendResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionExtendResponseFromRaw.FromRawUnchecked"/>
    public static ActionExtendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionExtendResponseFromRaw : IFromRawJson<ActionExtendResponse>
{
    /// <inheritdoc/>
    public ActionExtendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionExtendResponse.FromRawUnchecked(rawData);
}