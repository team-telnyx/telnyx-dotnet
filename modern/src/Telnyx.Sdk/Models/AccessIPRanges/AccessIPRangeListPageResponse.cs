using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AccessIPAddress;

namespace Telnyx.Sdk.Models.AccessIPRanges;

[JsonConverter(typeof(JsonModelConverter<AccessIPRangeListPageResponse, AccessIPRangeListPageResponseFromRaw>))]
public sealed record class AccessIPRangeListPageResponse : JsonModel
{
    public required IReadOnlyList<AccessIPRange> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccessIPRange>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AccessIPRange>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetaCloudflareIPListSync Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetaCloudflareIPListSync>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public AccessIPRangeListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPRangeListPageResponse (
        AccessIPRangeListPageResponse accessIPRangeListPageResponse
    ) : base(accessIPRangeListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AccessIPRangeListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPRangeListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AccessIPRangeListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccessIPRangeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AccessIPRangeListPageResponseFromRaw : IFromRawJson<AccessIPRangeListPageResponse>
{
    /// <inheritdoc/>
    public AccessIPRangeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AccessIPRangeListPageResponse.FromRawUnchecked(rawData);
}