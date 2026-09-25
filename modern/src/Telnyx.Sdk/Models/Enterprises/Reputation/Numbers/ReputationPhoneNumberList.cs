using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

[JsonConverter(typeof(JsonModelConverter<ReputationPhoneNumberList, ReputationPhoneNumberListFromRaw>))]
public sealed record class ReputationPhoneNumberList : JsonModel
{
    public required IReadOnlyList<ReputationPhoneNumber> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ReputationPhoneNumber>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ReputationPhoneNumber>>(
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
    public required NumberReputationPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberReputationPaginationMeta>(
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

    public ReputationPhoneNumberList ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationPhoneNumberList (
        ReputationPhoneNumberList reputationPhoneNumberList
    ) : base(reputationPhoneNumberList)
    {  }
    #pragma warning restore CS8618

    public ReputationPhoneNumberList (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationPhoneNumberList (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReputationPhoneNumberListFromRaw.FromRawUnchecked"/>
    public static ReputationPhoneNumberList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReputationPhoneNumberListFromRaw : IFromRawJson<ReputationPhoneNumberList>
{
    /// <inheritdoc/>
    public ReputationPhoneNumberList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReputationPhoneNumberList.FromRawUnchecked(rawData);
}