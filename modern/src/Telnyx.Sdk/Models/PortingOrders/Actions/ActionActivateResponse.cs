using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionActivateResponse, ActionActivateResponseFromRaw>))]
public sealed record class ActionActivateResponse : JsonModel
{
    public PortingOrdersActivationJob? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrdersActivationJob>(
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

    public ActionActivateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionActivateResponse (
        ActionActivateResponse actionActivateResponse
    ) : base(actionActivateResponse)
    {  }
    #pragma warning restore CS8618

    public ActionActivateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionActivateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionActivateResponseFromRaw.FromRawUnchecked"/>
    public static ActionActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionActivateResponseFromRaw : IFromRawJson<ActionActivateResponse>
{
    /// <inheritdoc/>
    public ActionActivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionActivateResponse.FromRawUnchecked(rawData);
}