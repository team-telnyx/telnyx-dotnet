using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingOptouts;

[JsonConverter(typeof(JsonModelConverter<MessagingOptoutListPageResponse, MessagingOptoutListPageResponseFromRaw>))]
public sealed record class MessagingOptoutListPageResponse : JsonModel
{
    public IReadOnlyList<MessagingOptoutListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingOptoutListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingOptoutListResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingPaginationMeta0b38e7044b? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingPaginationMeta0b38e7044b>(
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

    public MessagingOptoutListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOptoutListPageResponse (
        MessagingOptoutListPageResponse messagingOptoutListPageResponse
    ) : base(messagingOptoutListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingOptoutListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOptoutListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOptoutListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingOptoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingOptoutListPageResponseFromRaw : IFromRawJson<MessagingOptoutListPageResponse>
{
    /// <inheritdoc/>
    public MessagingOptoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOptoutListPageResponse.FromRawUnchecked(rawData);
}