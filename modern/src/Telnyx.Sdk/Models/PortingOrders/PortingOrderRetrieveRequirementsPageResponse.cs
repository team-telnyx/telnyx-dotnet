using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderRetrieveRequirementsPageResponse, PortingOrderRetrieveRequirementsPageResponseFromRaw>))]
public sealed record class PortingOrderRetrieveRequirementsPageResponse : JsonModel
{
    public IReadOnlyList<PortingOrderRetrieveRequirementsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrderRetrieveRequirementsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrderRetrieveRequirementsResponse>?>(
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

    public PortingOrderRetrieveRequirementsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRetrieveRequirementsPageResponse (
        PortingOrderRetrieveRequirementsPageResponse portingOrderRetrieveRequirementsPageResponse
    ) : base(portingOrderRetrieveRequirementsPageResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRetrieveRequirementsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRetrieveRequirementsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRetrieveRequirementsPageResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderRetrieveRequirementsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderRetrieveRequirementsPageResponseFromRaw : IFromRawJson<PortingOrderRetrieveRequirementsPageResponse>
{
    /// <inheritdoc/>
    public PortingOrderRetrieveRequirementsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRetrieveRequirementsPageResponse.FromRawUnchecked(rawData);
}