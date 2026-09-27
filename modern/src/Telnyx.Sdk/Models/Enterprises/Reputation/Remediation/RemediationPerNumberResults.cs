using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

/// <summary>
/// Per-category buckets of phone numbers, populated once results are available.
/// Empty lists are kept (not omitted) so consumers can iterate without null-checking
/// each key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RemediationPerNumberResults, RemediationPerNumberResultsFromRaw>))]
public sealed record class RemediationPerNumberResults : JsonModel
{
    public IReadOnlyList<string>? Ineligible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "ineligible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ineligible",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? NotFlagged {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "not_flagged"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "not_flagged",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? Refused {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "refused"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "refused",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? Remediated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "remediated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "remediated",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? RequiresReview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "requires_review"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "requires_review",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ineligible;
        _ = this.NotFlagged;
        _ = this.Refused;
        _ = this.Remediated;
        _ = this.RequiresReview;
    }

    public RemediationPerNumberResults ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemediationPerNumberResults (
        RemediationPerNumberResults remediationPerNumberResults
    ) : base(remediationPerNumberResults)
    {  }
    #pragma warning restore CS8618

    public RemediationPerNumberResults (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RemediationPerNumberResults (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RemediationPerNumberResultsFromRaw.FromRawUnchecked"/>
    public static RemediationPerNumberResults FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RemediationPerNumberResultsFromRaw : IFromRawJson<RemediationPerNumberResults>
{
    /// <inheritdoc/>
    public RemediationPerNumberResults FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RemediationPerNumberResults.FromRawUnchecked(rawData);
}