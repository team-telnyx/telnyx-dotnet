using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderListPageResponse, MessagingHostedNumberOrderListPageResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderListPageResponse : JsonModel
{
    public IReadOnlyList<MessagingHostedNumberOrder>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingHostedNumberOrder>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingHostedNumberOrder>?>(
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

    public MessagingHostedNumberOrderListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderListPageResponse (
        MessagingHostedNumberOrderListPageResponse messagingHostedNumberOrderListPageResponse
    ) : base(messagingHostedNumberOrderListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderListPageResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderListPageResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderListPageResponse.FromRawUnchecked(rawData);
}