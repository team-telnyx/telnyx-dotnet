using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Ips;

[JsonConverter(typeof(JsonModelConverter<IPDeleteResponse, IPDeleteResponseFromRaw>))]
public sealed record class IPDeleteResponse : JsonModel
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

    public IPDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPDeleteResponse (IPDeleteResponse ipDeleteResponse) : base(
        ipDeleteResponse
    )
    {  }
    #pragma warning restore CS8618

    public IPDeleteResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPDeleteResponseFromRaw.FromRawUnchecked"/>
    public static IPDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPDeleteResponseFromRaw : IFromRawJson<IPDeleteResponse>
{
    /// <inheritdoc/>
    public IPDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPDeleteResponse.FromRawUnchecked(rawData);
}