using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

[JsonConverter(typeof(JsonModelConverter<CivicAddressRetrieveResponse, CivicAddressRetrieveResponseFromRaw>))]
public sealed record class CivicAddressRetrieveResponse : JsonModel
{
    public CivicAddress? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CivicAddress>(
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

    public CivicAddressRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CivicAddressRetrieveResponse (
        CivicAddressRetrieveResponse civicAddressRetrieveResponse
    ) : base(civicAddressRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CivicAddressRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CivicAddressRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CivicAddressRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CivicAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CivicAddressRetrieveResponseFromRaw : IFromRawJson<CivicAddressRetrieveResponse>
{
    /// <inheritdoc/>
    public CivicAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CivicAddressRetrieveResponse.FromRawUnchecked(rawData);
}