using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WirelessBlocklists;

[JsonConverter(typeof(JsonModelConverter<WirelessBlocklistCreateResponse, WirelessBlocklistCreateResponseFromRaw>))]
public sealed record class WirelessBlocklistCreateResponse : JsonModel
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

    public WirelessBlocklistCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistCreateResponse (
        WirelessBlocklistCreateResponse wirelessBlocklistCreateResponse
    ) : base(wirelessBlocklistCreateResponse)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessBlocklistCreateResponseFromRaw.FromRawUnchecked"/>
    public static WirelessBlocklistCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessBlocklistCreateResponseFromRaw : IFromRawJson<WirelessBlocklistCreateResponse>
{
    /// <inheritdoc/>
    public WirelessBlocklistCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessBlocklistCreateResponse.FromRawUnchecked(rawData);
}