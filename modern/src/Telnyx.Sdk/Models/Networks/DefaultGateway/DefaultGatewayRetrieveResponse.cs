using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Networks.DefaultGateway;

[JsonConverter(typeof(JsonModelConverter<DefaultGatewayRetrieveResponse, DefaultGatewayRetrieveResponseFromRaw>))]
public sealed record class DefaultGatewayRetrieveResponse : JsonModel
{
    public IReadOnlyList<DefaultGatewayDefaultGateway>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DefaultGatewayDefaultGateway>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DefaultGatewayDefaultGateway>?>(
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

    public DefaultGatewayRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultGatewayRetrieveResponse (
        DefaultGatewayRetrieveResponse defaultGatewayRetrieveResponse
    ) : base(defaultGatewayRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public DefaultGatewayRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultGatewayRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DefaultGatewayRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DefaultGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DefaultGatewayRetrieveResponseFromRaw : IFromRawJson<DefaultGatewayRetrieveResponse>
{
    /// <inheritdoc/>
    public DefaultGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DefaultGatewayRetrieveResponse.FromRawUnchecked(rawData);
}