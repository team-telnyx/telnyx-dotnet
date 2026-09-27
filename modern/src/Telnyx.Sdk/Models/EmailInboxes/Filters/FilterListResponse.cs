using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

[JsonConverter(typeof(JsonModelConverter<FilterListResponse, FilterListResponseFromRaw>))]
public sealed record class FilterListResponse : JsonModel
{
    public required InboxFilters Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboxFilters>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public FilterListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterListResponse (FilterListResponse filterListResponse) : base(
        filterListResponse
    )
    {  }
    #pragma warning restore CS8618

    public FilterListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterListResponseFromRaw.FromRawUnchecked"/>
    public static FilterListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FilterListResponse (InboxFilters data) : this()
    { this.Data = data; }
}

class FilterListResponseFromRaw : IFromRawJson<FilterListResponse>
{
    /// <inheritdoc/>
    public FilterListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterListResponse.FromRawUnchecked(rawData);
}