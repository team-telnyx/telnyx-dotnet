using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailBlocks;

namespace Telnyx.Sdk.Models.EmailUnsubscribeGroups.Suppressions;

[JsonConverter(typeof(JsonModelConverter<SuppressionListPageResponse, SuppressionListPageResponseFromRaw>))]
public sealed record class SuppressionListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailBlock> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailBlock>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailBlock>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Group list `meta` (consistent with `GET /v2/email_blocks`).
    /// </summary>
    public required GroupListMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GroupListMeta>(
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

    public SuppressionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuppressionListPageResponse (
        SuppressionListPageResponse suppressionListPageResponse
    ) : base(suppressionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public SuppressionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SuppressionListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuppressionListPageResponseFromRaw.FromRawUnchecked"/>
    public static SuppressionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SuppressionListPageResponseFromRaw : IFromRawJson<SuppressionListPageResponse>
{
    /// <inheritdoc/>
    public SuppressionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SuppressionListPageResponse.FromRawUnchecked(rawData);
}