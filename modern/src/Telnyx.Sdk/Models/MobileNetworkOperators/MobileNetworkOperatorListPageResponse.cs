using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.MobileNetworkOperators;

[JsonConverter(typeof(JsonModelConverter<MobileNetworkOperatorListPageResponse, MobileNetworkOperatorListPageResponseFromRaw>))]
public sealed record class MobileNetworkOperatorListPageResponse : JsonModel
{
    public IReadOnlyList<MobileNetworkOperatorListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MobileNetworkOperatorListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MobileNetworkOperatorListResponse>?>(
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

    public MobileNetworkOperatorListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileNetworkOperatorListPageResponse (
        MobileNetworkOperatorListPageResponse mobileNetworkOperatorListPageResponse
    ) : base(mobileNetworkOperatorListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MobileNetworkOperatorListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileNetworkOperatorListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileNetworkOperatorListPageResponseFromRaw.FromRawUnchecked"/>
    public static MobileNetworkOperatorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileNetworkOperatorListPageResponseFromRaw : IFromRawJson<MobileNetworkOperatorListPageResponse>
{
    /// <inheritdoc/>
    public MobileNetworkOperatorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileNetworkOperatorListPageResponse.FromRawUnchecked(rawData);
}