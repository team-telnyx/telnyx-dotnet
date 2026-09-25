using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Networks.DefaultGateway;

[JsonConverter(typeof(JsonModelConverter<DefaultGatewayDeleteResponse, DefaultGatewayDeleteResponseFromRaw>))]
public sealed record class DefaultGatewayDeleteResponse : JsonModel
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

    public DefaultGatewayDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultGatewayDeleteResponse (
        DefaultGatewayDeleteResponse defaultGatewayDeleteResponse
    ) : base(defaultGatewayDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public DefaultGatewayDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultGatewayDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DefaultGatewayDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DefaultGatewayDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DefaultGatewayDeleteResponseFromRaw : IFromRawJson<DefaultGatewayDeleteResponse>
{
    /// <inheritdoc/>
    public DefaultGatewayDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DefaultGatewayDeleteResponse.FromRawUnchecked(rawData);
}