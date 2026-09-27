using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

[JsonConverter(typeof(JsonModelConverter<CivicAddressListResponse, CivicAddressListResponseFromRaw>))]
public sealed record class CivicAddressListResponse : JsonModel
{
    public IReadOnlyList<CivicAddress>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CivicAddress>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CivicAddress>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public CivicAddressListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CivicAddressListResponse (
        CivicAddressListResponse civicAddressListResponse
    ) : base(civicAddressListResponse)
    {  }
    #pragma warning restore CS8618

    public CivicAddressListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CivicAddressListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CivicAddressListResponseFromRaw.FromRawUnchecked"/>
    public static CivicAddressListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CivicAddressListResponseFromRaw : IFromRawJson<CivicAddressListResponse>
{
    /// <inheritdoc/>
    public CivicAddressListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CivicAddressListResponse.FromRawUnchecked(rawData);
}