using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WirelessBlocklists;

[JsonConverter(typeof(JsonModelConverter<WirelessBlocklistUpdateResponse, WirelessBlocklistUpdateResponseFromRaw>))]
public sealed record class WirelessBlocklistUpdateResponse : JsonModel
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

    public WirelessBlocklistUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistUpdateResponse (
        WirelessBlocklistUpdateResponse wirelessBlocklistUpdateResponse
    ) : base(wirelessBlocklistUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessBlocklistUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WirelessBlocklistUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessBlocklistUpdateResponseFromRaw : IFromRawJson<WirelessBlocklistUpdateResponse>
{
    /// <inheritdoc/>
    public WirelessBlocklistUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessBlocklistUpdateResponse.FromRawUnchecked(rawData);
}