using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkCreateResponse, NetworkCreateResponseFromRaw>))]
public sealed record class NetworkCreateResponse : JsonModel
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

    public NetworkCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkCreateResponse (
        NetworkCreateResponse networkCreateResponse
    ) : base(networkCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkCreateResponseFromRaw.FromRawUnchecked"/>
    public static NetworkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkCreateResponseFromRaw : IFromRawJson<NetworkCreateResponse>
{
    /// <inheritdoc/>
    public NetworkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkCreateResponse.FromRawUnchecked(rawData);
}