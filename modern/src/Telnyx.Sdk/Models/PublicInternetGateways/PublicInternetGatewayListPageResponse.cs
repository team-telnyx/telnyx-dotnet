using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<PublicInternetGatewayListPageResponse, PublicInternetGatewayListPageResponseFromRaw>))]
public sealed record class PublicInternetGatewayListPageResponse : JsonModel
{
    public IReadOnlyList<PublicInternetGatewayRead>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PublicInternetGatewayRead>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PublicInternetGatewayRead>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public PublicInternetGatewayListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGatewayListPageResponse (
        PublicInternetGatewayListPageResponse publicInternetGatewayListPageResponse
    ) : base(publicInternetGatewayListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGatewayListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGatewayListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayListPageResponseFromRaw.FromRawUnchecked"/>
    public static PublicInternetGatewayListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PublicInternetGatewayListPageResponseFromRaw : IFromRawJson<PublicInternetGatewayListPageResponse>
{
    /// <inheritdoc/>
    public PublicInternetGatewayListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGatewayListPageResponse.FromRawUnchecked(rawData);
}