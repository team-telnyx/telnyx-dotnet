using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkUpdateResponse, NetworkUpdateResponseFromRaw>))]
public sealed record class NetworkUpdateResponse : JsonModel
{
    public Network? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Network>(
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

    public NetworkUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkUpdateResponse (
        NetworkUpdateResponse networkUpdateResponse
    ) : base(networkUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkUpdateResponseFromRaw.FromRawUnchecked"/>
    public static NetworkUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkUpdateResponseFromRaw : IFromRawJson<NetworkUpdateResponse>
{
    /// <inheritdoc/>
    public NetworkUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkUpdateResponse.FromRawUnchecked(rawData);
}