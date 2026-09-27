using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<PublicInternetGatewayDeleteResponse, PublicInternetGatewayDeleteResponseFromRaw>))]
public sealed record class PublicInternetGatewayDeleteResponse : JsonModel
{
    public PublicInternetGatewayRead? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PublicInternetGatewayRead>(
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

    public PublicInternetGatewayDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGatewayDeleteResponse (
        PublicInternetGatewayDeleteResponse publicInternetGatewayDeleteResponse
    ) : base(publicInternetGatewayDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGatewayDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGatewayDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PublicInternetGatewayDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PublicInternetGatewayDeleteResponseFromRaw : IFromRawJson<PublicInternetGatewayDeleteResponse>
{
    /// <inheritdoc/>
    public PublicInternetGatewayDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGatewayDeleteResponse.FromRawUnchecked(rawData);
}