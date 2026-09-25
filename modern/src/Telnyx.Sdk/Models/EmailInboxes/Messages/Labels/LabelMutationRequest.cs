using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Labels;

/// <summary>
/// Labels to add or remove. Both operations are idempotent set operations, so a retried
/// request converges instead of failing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LabelMutationRequest, LabelMutationRequestFromRaw>))]
public sealed record class LabelMutationRequest : JsonModel
{
    /// <summary>
    /// One or more labels. Each label is a freeform, case-sensitive string of at
    /// most 255 characters; a message or thread may carry at most 50 labels. The
    /// `telnyx:` prefix is a reserved system namespace and is rejected on customer writes.
    /// </summary>
    public required IReadOnlyList<string> Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "labels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Labels; }

    public LabelMutationRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelMutationRequest (
        LabelMutationRequest labelMutationRequest
    ) : base(labelMutationRequest)
    {  }
    #pragma warning restore CS8618

    public LabelMutationRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelMutationRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LabelMutationRequestFromRaw.FromRawUnchecked"/>
    public static LabelMutationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public LabelMutationRequest (IReadOnlyList<string> labels) : this()
    { this.Labels = labels; }
}

class LabelMutationRequestFromRaw : IFromRawJson<LabelMutationRequest>
{
    /// <inheritdoc/>
    public LabelMutationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LabelMutationRequest.FromRawUnchecked(rawData);
}