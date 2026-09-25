using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

[JsonConverter(typeof(JsonModelConverter<DraftListPageResponse, DraftListPageResponseFromRaw>))]
public sealed record class DraftListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailDraft> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailDraft>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailDraft>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required EmailPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPaginationMeta>(
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

    public DraftListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftListPageResponse (
        DraftListPageResponse draftListPageResponse
    ) : base(draftListPageResponse)
    {  }
    #pragma warning restore CS8618

    public DraftListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DraftListPageResponseFromRaw.FromRawUnchecked"/>
    public static DraftListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DraftListPageResponseFromRaw : IFromRawJson<DraftListPageResponse>
{
    /// <inheritdoc/>
    public DraftListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DraftListPageResponse.FromRawUnchecked(rawData);
}