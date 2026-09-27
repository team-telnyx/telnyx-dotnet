using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

[JsonConverter(typeof(JsonModelConverter<FilterDeleteAllResponse, FilterDeleteAllResponseFromRaw>))]
public sealed record class FilterDeleteAllResponse : JsonModel
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

    public FilterDeleteAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterDeleteAllResponse (
        FilterDeleteAllResponse filterDeleteAllResponse
    ) : base(filterDeleteAllResponse)
    {  }
    #pragma warning restore CS8618

    public FilterDeleteAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterDeleteAllResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static FilterDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FilterDeleteAllResponse (InboxFilters data) : this()
    { this.Data = data; }
}

class FilterDeleteAllResponseFromRaw : IFromRawJson<FilterDeleteAllResponse>
{
    /// <inheritdoc/>
    public FilterDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterDeleteAllResponse.FromRawUnchecked(rawData);
}