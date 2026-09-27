using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.NotificationEventConditions;

[JsonConverter(typeof(JsonModelConverter<NotificationEventConditionListPageResponse, NotificationEventConditionListPageResponseFromRaw>))]
public sealed record class NotificationEventConditionListPageResponse : JsonModel
{
    public IReadOnlyList<NotificationEventConditionListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NotificationEventConditionListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NotificationEventConditionListResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public NotificationEventConditionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationEventConditionListPageResponse (
        NotificationEventConditionListPageResponse notificationEventConditionListPageResponse
    ) : base(notificationEventConditionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationEventConditionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationEventConditionListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationEventConditionListPageResponseFromRaw.FromRawUnchecked"/>
    public static NotificationEventConditionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationEventConditionListPageResponseFromRaw : IFromRawJson<NotificationEventConditionListPageResponse>
{
    /// <inheritdoc/>
    public NotificationEventConditionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationEventConditionListPageResponse.FromRawUnchecked(rawData);
}