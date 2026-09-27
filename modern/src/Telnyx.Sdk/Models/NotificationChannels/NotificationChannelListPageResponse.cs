using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.NotificationChannels;

[JsonConverter(typeof(JsonModelConverter<NotificationChannelListPageResponse, NotificationChannelListPageResponseFromRaw>))]
public sealed record class NotificationChannelListPageResponse : JsonModel
{
    public IReadOnlyList<NotificationChannelNotificationChannel>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NotificationChannelNotificationChannel>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NotificationChannelNotificationChannel>?>(
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

    public NotificationChannelListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelListPageResponse (
        NotificationChannelListPageResponse notificationChannelListPageResponse
    ) : base(notificationChannelListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelListPageResponseFromRaw.FromRawUnchecked"/>
    public static NotificationChannelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelListPageResponseFromRaw : IFromRawJson<NotificationChannelListPageResponse>
{
    /// <inheritdoc/>
    public NotificationChannelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelListPageResponse.FromRawUnchecked(rawData);
}