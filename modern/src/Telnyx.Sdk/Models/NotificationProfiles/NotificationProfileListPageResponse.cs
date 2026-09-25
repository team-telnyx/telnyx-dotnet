using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.NotificationProfiles;

[JsonConverter(typeof(JsonModelConverter<NotificationProfileListPageResponse, NotificationProfileListPageResponseFromRaw>))]
public sealed record class NotificationProfileListPageResponse : JsonModel
{
    public IReadOnlyList<NotificationProfile>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NotificationProfile>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NotificationProfile>?>(
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

    public NotificationProfileListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileListPageResponse (
        NotificationProfileListPageResponse notificationProfileListPageResponse
    ) : base(notificationProfileListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static NotificationProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileListPageResponseFromRaw : IFromRawJson<NotificationProfileListPageResponse>
{
    /// <inheritdoc/>
    public NotificationProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileListPageResponse.FromRawUnchecked(rawData);
}