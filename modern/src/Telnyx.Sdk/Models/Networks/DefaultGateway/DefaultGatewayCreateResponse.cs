using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Networks.DefaultGateway;

[JsonConverter(typeof(JsonModelConverter<DefaultGatewayCreateResponse, DefaultGatewayCreateResponseFromRaw>))]
public sealed record class DefaultGatewayCreateResponse : JsonModel
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

    public DefaultGatewayCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultGatewayCreateResponse (
        DefaultGatewayCreateResponse defaultGatewayCreateResponse
    ) : base(defaultGatewayCreateResponse)
    {  }
    #pragma warning restore CS8618

    public DefaultGatewayCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultGatewayCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DefaultGatewayCreateResponseFromRaw.FromRawUnchecked"/>
    public static DefaultGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DefaultGatewayCreateResponseFromRaw : IFromRawJson<DefaultGatewayCreateResponse>
{
    /// <inheritdoc/>
    public DefaultGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DefaultGatewayCreateResponse.FromRawUnchecked(rawData);
}