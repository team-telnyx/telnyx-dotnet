using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WirelessBlocklists;

[JsonConverter(typeof(JsonModelConverter<WirelessBlocklistRetrieveResponse, WirelessBlocklistRetrieveResponseFromRaw>))]
public sealed record class WirelessBlocklistRetrieveResponse : JsonModel
{
    public WirelessWirelessBlocklist? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WirelessWirelessBlocklist>(
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

    public WirelessBlocklistRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistRetrieveResponse (
        WirelessBlocklistRetrieveResponse wirelessBlocklistRetrieveResponse
    ) : base(wirelessBlocklistRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessBlocklistRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WirelessBlocklistRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessBlocklistRetrieveResponseFromRaw : IFromRawJson<WirelessBlocklistRetrieveResponse>
{
    /// <inheritdoc/>
    public WirelessBlocklistRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessBlocklistRetrieveResponse.FromRawUnchecked(rawData);
}