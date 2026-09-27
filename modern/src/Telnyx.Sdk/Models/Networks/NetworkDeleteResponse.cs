using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkDeleteResponse, NetworkDeleteResponseFromRaw>))]
public sealed record class NetworkDeleteResponse : JsonModel
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

    public NetworkDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkDeleteResponse (
        NetworkDeleteResponse networkDeleteResponse
    ) : base(networkDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkDeleteResponseFromRaw.FromRawUnchecked"/>
    public static NetworkDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkDeleteResponseFromRaw : IFromRawJson<NetworkDeleteResponse>
{
    /// <inheritdoc/>
    public NetworkDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkDeleteResponse.FromRawUnchecked(rawData);
}