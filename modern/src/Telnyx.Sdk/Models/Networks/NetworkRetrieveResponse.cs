using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkRetrieveResponse, NetworkRetrieveResponseFromRaw>))]
public sealed record class NetworkRetrieveResponse : JsonModel
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

    public NetworkRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkRetrieveResponse (
        NetworkRetrieveResponse networkRetrieveResponse
    ) : base(networkRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NetworkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkRetrieveResponseFromRaw : IFromRawJson<NetworkRetrieveResponse>
{
    /// <inheritdoc/>
    public NetworkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkRetrieveResponse.FromRawUnchecked(rawData);
}