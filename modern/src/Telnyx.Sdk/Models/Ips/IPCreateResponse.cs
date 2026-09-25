using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Ips;

[JsonConverter(typeof(JsonModelConverter<IPCreateResponse, IPCreateResponseFromRaw>))]
public sealed record class IPCreateResponse : JsonModel
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

    public IPCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPCreateResponse (IPCreateResponse ipCreateResponse) : base(
        ipCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public IPCreateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPCreateResponseFromRaw.FromRawUnchecked"/>
    public static IPCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPCreateResponseFromRaw : IFromRawJson<IPCreateResponse>
{
    /// <inheritdoc/>
    public IPCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPCreateResponse.FromRawUnchecked(rawData);
}