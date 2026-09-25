using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Ips;

[JsonConverter(typeof(JsonModelConverter<IPUpdateResponse, IPUpdateResponseFromRaw>))]
public sealed record class IPUpdateResponse : JsonModel
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

    public IPUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPUpdateResponse (IPUpdateResponse ipUpdateResponse) : base(
        ipUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public IPUpdateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPUpdateResponseFromRaw.FromRawUnchecked"/>
    public static IPUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPUpdateResponseFromRaw : IFromRawJson<IPUpdateResponse>
{
    /// <inheritdoc/>
    public IPUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPUpdateResponse.FromRawUnchecked(rawData);
}