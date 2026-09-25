using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardListWirelessConnectivityLogsPageResponse, SimCardListWirelessConnectivityLogsPageResponseFromRaw>))]
public sealed record class SimCardListWirelessConnectivityLogsPageResponse : JsonModel
{
    public IReadOnlyList<SimCardListWirelessConnectivityLogsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimCardListWirelessConnectivityLogsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimCardListWirelessConnectivityLogsResponse>?>(
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

    public SimCardListWirelessConnectivityLogsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardListWirelessConnectivityLogsPageResponse (
        SimCardListWirelessConnectivityLogsPageResponse simCardListWirelessConnectivityLogsPageResponse
    ) : base(simCardListWirelessConnectivityLogsPageResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardListWirelessConnectivityLogsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardListWirelessConnectivityLogsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardListWirelessConnectivityLogsPageResponseFromRaw.FromRawUnchecked"/>
    public static SimCardListWirelessConnectivityLogsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardListWirelessConnectivityLogsPageResponseFromRaw : IFromRawJson<SimCardListWirelessConnectivityLogsPageResponse>
{
    /// <inheritdoc/>
    public SimCardListWirelessConnectivityLogsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardListWirelessConnectivityLogsPageResponse.FromRawUnchecked(rawData);
}