using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<PublicInternetGatewayRetrieveResponse, PublicInternetGatewayRetrieveResponseFromRaw>))]
public sealed record class PublicInternetGatewayRetrieveResponse : JsonModel
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

    public PublicInternetGatewayRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGatewayRetrieveResponse (
        PublicInternetGatewayRetrieveResponse publicInternetGatewayRetrieveResponse
    ) : base(publicInternetGatewayRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGatewayRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGatewayRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PublicInternetGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PublicInternetGatewayRetrieveResponseFromRaw : IFromRawJson<PublicInternetGatewayRetrieveResponse>
{
    /// <inheritdoc/>
    public PublicInternetGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGatewayRetrieveResponse.FromRawUnchecked(rawData);
}