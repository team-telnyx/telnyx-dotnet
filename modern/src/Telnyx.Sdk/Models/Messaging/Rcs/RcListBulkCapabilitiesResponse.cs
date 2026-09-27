using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging.Rcs;

[JsonConverter(typeof(JsonModelConverter<RcListBulkCapabilitiesResponse, RcListBulkCapabilitiesResponseFromRaw>))]
public sealed record class RcListBulkCapabilitiesResponse : JsonModel
{
    public IReadOnlyList<RcsCapabilities>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsCapabilities>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RcsCapabilities>?>(
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

    public RcListBulkCapabilitiesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcListBulkCapabilitiesResponse (
        RcListBulkCapabilitiesResponse rcListBulkCapabilitiesResponse
    ) : base(rcListBulkCapabilitiesResponse)
    {  }
    #pragma warning restore CS8618

    public RcListBulkCapabilitiesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcListBulkCapabilitiesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcListBulkCapabilitiesResponseFromRaw.FromRawUnchecked"/>
    public static RcListBulkCapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcListBulkCapabilitiesResponseFromRaw : IFromRawJson<RcListBulkCapabilitiesResponse>
{
    /// <inheritdoc/>
    public RcListBulkCapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcListBulkCapabilitiesResponse.FromRawUnchecked(rawData);
}