using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<IPConnectionDeleteResponse, IPConnectionDeleteResponseFromRaw>))]
public sealed record class IPConnectionDeleteResponse : JsonModel
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

    public IPConnectionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionDeleteResponse (
        IPConnectionDeleteResponse ipConnectionDeleteResponse
    ) : base(ipConnectionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public IPConnectionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPConnectionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static IPConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPConnectionDeleteResponseFromRaw : IFromRawJson<IPConnectionDeleteResponse>
{
    /// <inheritdoc/>
    public IPConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPConnectionDeleteResponse.FromRawUnchecked(rawData);
}