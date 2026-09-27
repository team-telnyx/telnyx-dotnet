using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallReasons;
using Telnyx.Sdk.Models.InfringementClaims;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<DirListInfringementClaimsPageResponse, DirListInfringementClaimsPageResponseFromRaw>))]
public sealed record class DirListInfringementClaimsPageResponse : JsonModel
{
    public required IReadOnlyList<InfringementClaim> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InfringementClaim>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InfringementClaim>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// JSON:API pagination metadata returned with every paginated list response.
    /// Page numbering is 1-based. `page_size` reports the number of items actually
    /// returned in `data` for this page; the requested size is taken from the `page[size]`
    /// query parameter.
    /// </summary>
    public required BrandedCallingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandedCallingPaginationMeta>(
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

    public DirListInfringementClaimsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirListInfringementClaimsPageResponse (
        DirListInfringementClaimsPageResponse dirListInfringementClaimsPageResponse
    ) : base(dirListInfringementClaimsPageResponse)
    {  }
    #pragma warning restore CS8618

    public DirListInfringementClaimsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirListInfringementClaimsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirListInfringementClaimsPageResponseFromRaw.FromRawUnchecked"/>
    public static DirListInfringementClaimsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirListInfringementClaimsPageResponseFromRaw : IFromRawJson<DirListInfringementClaimsPageResponse>
{
    /// <inheritdoc/>
    public DirListInfringementClaimsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirListInfringementClaimsPageResponse.FromRawUnchecked(rawData);
}