using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<PublicInternetGatewayCreateResponse, PublicInternetGatewayCreateResponseFromRaw>))]
public sealed record class PublicInternetGatewayCreateResponse : JsonModel
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

    public PublicInternetGatewayCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGatewayCreateResponse (
        PublicInternetGatewayCreateResponse publicInternetGatewayCreateResponse
    ) : base(publicInternetGatewayCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGatewayCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGatewayCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayCreateResponseFromRaw.FromRawUnchecked"/>
    public static PublicInternetGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PublicInternetGatewayCreateResponseFromRaw : IFromRawJson<PublicInternetGatewayCreateResponse>
{
    /// <inheritdoc/>
    public PublicInternetGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGatewayCreateResponse.FromRawUnchecked(rawData);
}