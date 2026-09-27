using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationListPageResponse, SimCardDataUsageNotificationListPageResponseFromRaw>))]
public sealed record class SimCardDataUsageNotificationListPageResponse : JsonModel
{
    public IReadOnlyList<SimCardDataUsageNotification>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimCardDataUsageNotification>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimCardDataUsageNotification>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public SimCardDataUsageNotificationListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationListPageResponse (
        SimCardDataUsageNotificationListPageResponse simCardDataUsageNotificationListPageResponse
    ) : base(simCardDataUsageNotificationListPageResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationListPageResponseFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationListPageResponseFromRaw : IFromRawJson<SimCardDataUsageNotificationListPageResponse>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationListPageResponse.FromRawUnchecked(rawData);
}