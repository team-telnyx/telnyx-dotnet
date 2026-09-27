using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationUpdateResponse, SimCardDataUsageNotificationUpdateResponseFromRaw>))]
public sealed record class SimCardDataUsageNotificationUpdateResponse : JsonModel
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

    public SimCardDataUsageNotificationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationUpdateResponse (
        SimCardDataUsageNotificationUpdateResponse simCardDataUsageNotificationUpdateResponse
    ) : base(simCardDataUsageNotificationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationUpdateResponseFromRaw : IFromRawJson<SimCardDataUsageNotificationUpdateResponse>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationUpdateResponse.FromRawUnchecked(rawData);
}