using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderRetrieveExceptionTypesResponse, PortingOrderRetrieveExceptionTypesResponseFromRaw>))]
public sealed record class PortingOrderRetrieveExceptionTypesResponse : JsonModel
{
    public IReadOnlyList<PortingOrdersExceptionType>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrdersExceptionType>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrdersExceptionType>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public PortingOrderRetrieveExceptionTypesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRetrieveExceptionTypesResponse (
        PortingOrderRetrieveExceptionTypesResponse portingOrderRetrieveExceptionTypesResponse
    ) : base(portingOrderRetrieveExceptionTypesResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRetrieveExceptionTypesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRetrieveExceptionTypesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRetrieveExceptionTypesResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderRetrieveExceptionTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderRetrieveExceptionTypesResponseFromRaw : IFromRawJson<PortingOrderRetrieveExceptionTypesResponse>
{
    /// <inheritdoc/>
    public PortingOrderRetrieveExceptionTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRetrieveExceptionTypesResponse.FromRawUnchecked(rawData);
}