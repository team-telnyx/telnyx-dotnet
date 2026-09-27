using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingListResponse, MessagingListResponseFromRaw>))]
public sealed record class MessagingListResponse : JsonModel
{
    public IReadOnlyList<MdrDetailReportResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MdrDetailReportResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MdrDetailReportResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public BatchCsvPaginationMeta705dfa7312? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchCsvPaginationMeta705dfa7312>(
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

    public MessagingListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingListResponse (
        MessagingListResponse messagingListResponse
    ) : base(messagingListResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingListResponseFromRaw.FromRawUnchecked"/>
    public static MessagingListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingListResponseFromRaw : IFromRawJson<MessagingListResponse>
{
    /// <inheritdoc/>
    public MessagingListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingListResponse.FromRawUnchecked(rawData);
}