using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<IPConnectionRetrieveResponse, IPConnectionRetrieveResponseFromRaw>))]
public sealed record class IPConnectionRetrieveResponse : JsonModel
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

    public IPConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionRetrieveResponse (
        IPConnectionRetrieveResponse ipConnectionRetrieveResponse
    ) : base(ipConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public IPConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static IPConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPConnectionRetrieveResponseFromRaw : IFromRawJson<IPConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public IPConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPConnectionRetrieveResponse.FromRawUnchecked(rawData);
}