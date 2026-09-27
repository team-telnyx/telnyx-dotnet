using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

[JsonConverter(typeof(JsonModelConverter<FilterReplaceResponse, FilterReplaceResponseFromRaw>))]
public sealed record class FilterReplaceResponse : JsonModel
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

    public FilterReplaceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterReplaceResponse (
        FilterReplaceResponse filterReplaceResponse
    ) : base(filterReplaceResponse)
    {  }
    #pragma warning restore CS8618

    public FilterReplaceResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterReplaceResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterReplaceResponseFromRaw.FromRawUnchecked"/>
    public static FilterReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FilterReplaceResponse (InboxFilters data) : this()
    { this.Data = data; }
}

class FilterReplaceResponseFromRaw : IFromRawJson<FilterReplaceResponse>
{
    /// <inheritdoc/>
    public FilterReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterReplaceResponse.FromRawUnchecked(rawData);
}