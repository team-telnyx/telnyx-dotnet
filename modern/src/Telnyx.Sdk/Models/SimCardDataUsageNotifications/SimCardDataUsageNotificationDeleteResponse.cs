using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationDeleteResponse, SimCardDataUsageNotificationDeleteResponseFromRaw>))]
public sealed record class SimCardDataUsageNotificationDeleteResponse : JsonModel
{
    /// <summary>
    /// The SIM card individual data usage notification information.
    /// </summary>
    public SimCardDataUsageNotification? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardDataUsageNotification>(
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

    public SimCardDataUsageNotificationDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationDeleteResponse (
        SimCardDataUsageNotificationDeleteResponse simCardDataUsageNotificationDeleteResponse
    ) : base(simCardDataUsageNotificationDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationDeleteResponseFromRaw : IFromRawJson<SimCardDataUsageNotificationDeleteResponse>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationDeleteResponse.FromRawUnchecked(rawData);
}