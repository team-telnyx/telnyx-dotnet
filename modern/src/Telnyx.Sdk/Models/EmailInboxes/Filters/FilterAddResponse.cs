using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

[JsonConverter(typeof(JsonModelConverter<FilterAddResponse, FilterAddResponseFromRaw>))]
public sealed record class FilterAddResponse : JsonModel
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

    public FilterAddResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterAddResponse (FilterAddResponse filterAddResponse) : base(
        filterAddResponse
    )
    {  }
    #pragma warning restore CS8618

    public FilterAddResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterAddResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterAddResponseFromRaw.FromRawUnchecked"/>
    public static FilterAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FilterAddResponse (InboxFilters data) : this()
    { this.Data = data; }
}

class FilterAddResponseFromRaw : IFromRawJson<FilterAddResponse>
{
    /// <inheritdoc/>
    public FilterAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FilterAddResponse.FromRawUnchecked(rawData);
}