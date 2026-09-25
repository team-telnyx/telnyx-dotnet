using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

/// <summary>
/// List of reputation-monitored phone numbers, each carrying its current reputation data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReputationPhoneNumberListWithReputation, ReputationPhoneNumberListWithReputationFromRaw>))]
public sealed record class ReputationPhoneNumberListWithReputation : JsonModel
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

    public ReputationPhoneNumberListWithReputation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationPhoneNumberListWithReputation (
        ReputationPhoneNumberListWithReputation reputationPhoneNumberListWithReputation
    ) : base(reputationPhoneNumberListWithReputation)
    {  }
    #pragma warning restore CS8618

    public ReputationPhoneNumberListWithReputation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationPhoneNumberListWithReputation (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReputationPhoneNumberListWithReputationFromRaw.FromRawUnchecked"/>
    public static ReputationPhoneNumberListWithReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReputationPhoneNumberListWithReputationFromRaw : IFromRawJson<ReputationPhoneNumberListWithReputation>
{
    /// <inheritdoc/>
    public ReputationPhoneNumberListWithReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReputationPhoneNumberListWithReputation.FromRawUnchecked(rawData);
}