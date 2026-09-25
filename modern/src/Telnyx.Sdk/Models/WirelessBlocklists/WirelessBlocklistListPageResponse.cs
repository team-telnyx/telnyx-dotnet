using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.WirelessBlocklists;

[JsonConverter(typeof(JsonModelConverter<WirelessBlocklistListPageResponse, WirelessBlocklistListPageResponseFromRaw>))]
public sealed record class WirelessBlocklistListPageResponse : JsonModel
{
    public IReadOnlyList<WirelessWirelessBlocklist>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WirelessWirelessBlocklist>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WirelessWirelessBlocklist>?>(
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

    public WirelessBlocklistListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistListPageResponse (
        WirelessBlocklistListPageResponse wirelessBlocklistListPageResponse
    ) : base(wirelessBlocklistListPageResponse)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessBlocklistListPageResponseFromRaw.FromRawUnchecked"/>
    public static WirelessBlocklistListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessBlocklistListPageResponseFromRaw : IFromRawJson<WirelessBlocklistListPageResponse>
{
    /// <inheritdoc/>
    public WirelessBlocklistListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessBlocklistListPageResponse.FromRawUnchecked(rawData);
}