using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<MessagingPaginationMeta0b38e7044b, MessagingPaginationMeta0b38e7044bFromRaw>))]
public sealed record class MessagingPaginationMeta0b38e7044b : JsonModel
{
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    public required long TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_results"
            );
        }
        init { this._rawData.Set("total_results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public MessagingPaginationMeta0b38e7044b ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingPaginationMeta0b38e7044b (
        MessagingPaginationMeta0b38e7044b messagingPaginationMeta0b38e7044b
    ) : base(messagingPaginationMeta0b38e7044b)
    {  }
    #pragma warning restore CS8618

    public MessagingPaginationMeta0b38e7044b (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingPaginationMeta0b38e7044b (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingPaginationMeta0b38e7044bFromRaw.FromRawUnchecked"/>
    public static MessagingPaginationMeta0b38e7044b FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingPaginationMeta0b38e7044bFromRaw : IFromRawJson<MessagingPaginationMeta0b38e7044b>
{
    /// <inheritdoc/>
    public MessagingPaginationMeta0b38e7044b FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingPaginationMeta0b38e7044b.FromRawUnchecked(rawData);
}