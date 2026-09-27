using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Ips;

[JsonConverter(typeof(JsonModelConverter<IPRetrieveResponse, IPRetrieveResponseFromRaw>))]
public sealed record class IPRetrieveResponse : JsonModel
{
    public IP? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IP>(
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

    public IPRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPRetrieveResponse (IPRetrieveResponse ipRetrieveResponse) : base(
        ipRetrieveResponse
    )
    {  }
    #pragma warning restore CS8618

    public IPRetrieveResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static IPRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPRetrieveResponseFromRaw : IFromRawJson<IPRetrieveResponse>
{
    /// <inheritdoc/>
    public IPRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPRetrieveResponse.FromRawUnchecked(rawData);
}