using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingProfileMetrics;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileMetricListResponse, MessagingProfileMetricListResponseFromRaw>))]
public sealed record class MessagingProfileMetricListResponse : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
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
        _ = this.Data;
        this.Meta?.Validate();
    }

    public MessagingProfileMetricListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileMetricListResponse (
        MessagingProfileMetricListResponse messagingProfileMetricListResponse
    ) : base(messagingProfileMetricListResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileMetricListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileMetricListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileMetricListResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileMetricListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileMetricListResponseFromRaw : IFromRawJson<MessagingProfileMetricListResponse>
{
    /// <inheritdoc/>
    public MessagingProfileMetricListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileMetricListResponse.FromRawUnchecked(rawData);
}