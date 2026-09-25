using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationRetrieveResponse, SimCardDataUsageNotificationRetrieveResponseFromRaw>))]
public sealed record class SimCardDataUsageNotificationRetrieveResponse : JsonModel
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

    public SimCardDataUsageNotificationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationRetrieveResponse (
        SimCardDataUsageNotificationRetrieveResponse simCardDataUsageNotificationRetrieveResponse
    ) : base(simCardDataUsageNotificationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationRetrieveResponseFromRaw : IFromRawJson<SimCardDataUsageNotificationRetrieveResponse>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationRetrieveResponse.FromRawUnchecked(rawData);
}