using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderCreateResponse, PortingOrderCreateResponseFromRaw>))]
public sealed record class PortingOrderCreateResponse : JsonModel
{
    public IReadOnlyList<PortingOrder>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrder>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrder>?>(
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

    public PortingOrderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderCreateResponse (
        PortingOrderCreateResponse portingOrderCreateResponse
    ) : base(portingOrderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderCreateResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderCreateResponseFromRaw : IFromRawJson<PortingOrderCreateResponse>
{
    /// <inheritdoc/>
    public PortingOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderCreateResponse.FromRawUnchecked(rawData);
}