using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingListPageResponse, MessagingListPageResponseFromRaw>))]
public sealed record class MessagingListPageResponse : JsonModel
{
    public IReadOnlyList<MdrUsageReportResponseLegacy>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MdrUsageReportResponseLegacy>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MdrUsageReportResponseLegacy>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public StandardPaginationMetaFfba4faa88? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StandardPaginationMetaFfba4faa88>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public MessagingListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingListPageResponse (
        MessagingListPageResponse messagingListPageResponse
    ) : base(messagingListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingListPageResponseFromRaw : IFromRawJson<MessagingListPageResponse>
{
    /// <inheritdoc/>
    public MessagingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingListPageResponse.FromRawUnchecked(rawData);
}