using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallReasons;

[JsonConverter(typeof(JsonModelConverter<CallReasonListPageResponse, CallReasonListPageResponseFromRaw>))]
public sealed record class CallReasonListPageResponse : JsonModel
{
    public required IReadOnlyList<CallReasonListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CallReasonListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<CallReasonListResponse>>(
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

    public CallReasonListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReasonListPageResponse (
        CallReasonListPageResponse callReasonListPageResponse
    ) : base(callReasonListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CallReasonListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReasonListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReasonListPageResponseFromRaw.FromRawUnchecked"/>
    public static CallReasonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallReasonListPageResponseFromRaw : IFromRawJson<CallReasonListPageResponse>
{
    /// <inheritdoc/>
    public CallReasonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReasonListPageResponse.FromRawUnchecked(rawData);
}