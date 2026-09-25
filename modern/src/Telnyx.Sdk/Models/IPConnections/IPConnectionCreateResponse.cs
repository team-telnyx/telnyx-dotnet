using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<IPConnectionCreateResponse, IPConnectionCreateResponseFromRaw>))]
public sealed record class IPConnectionCreateResponse : JsonModel
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

    public IPConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionCreateResponse (
        IPConnectionCreateResponse ipConnectionCreateResponse
    ) : base(ipConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public IPConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static IPConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPConnectionCreateResponseFromRaw : IFromRawJson<IPConnectionCreateResponse>
{
    /// <inheritdoc/>
    public IPConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPConnectionCreateResponse.FromRawUnchecked(rawData);
}