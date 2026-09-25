using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<IPConnectionUpdateResponse, IPConnectionUpdateResponseFromRaw>))]
public sealed record class IPConnectionUpdateResponse : JsonModel
{
    public IPConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IPConnection>(
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

    public IPConnectionUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionUpdateResponse (
        IPConnectionUpdateResponse ipConnectionUpdateResponse
    ) : base(ipConnectionUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public IPConnectionUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPConnectionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static IPConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPConnectionUpdateResponseFromRaw : IFromRawJson<IPConnectionUpdateResponse>
{
    /// <inheritdoc/>
    public IPConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPConnectionUpdateResponse.FromRawUnchecked(rawData);
}