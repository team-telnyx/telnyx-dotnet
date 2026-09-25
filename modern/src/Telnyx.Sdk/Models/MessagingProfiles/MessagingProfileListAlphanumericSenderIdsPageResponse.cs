using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileListAlphanumericSenderIdsPageResponse, MessagingProfileListAlphanumericSenderIdsPageResponseFromRaw>))]
public sealed record class MessagingProfileListAlphanumericSenderIdsPageResponse : JsonModel
{
    public IReadOnlyList<AlphanumericSenderID>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AlphanumericSenderID>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AlphanumericSenderID>?>(
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

    public MessagingProfileListAlphanumericSenderIdsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileListAlphanumericSenderIdsPageResponse (
        MessagingProfileListAlphanumericSenderIdsPageResponse messagingProfileListAlphanumericSenderIdsPageResponse
    ) : base(messagingProfileListAlphanumericSenderIdsPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileListAlphanumericSenderIdsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileListAlphanumericSenderIdsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileListAlphanumericSenderIdsPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileListAlphanumericSenderIdsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileListAlphanumericSenderIdsPageResponseFromRaw : IFromRawJson<MessagingProfileListAlphanumericSenderIdsPageResponse>
{
    /// <inheritdoc/>
    public MessagingProfileListAlphanumericSenderIdsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileListAlphanumericSenderIdsPageResponse.FromRawUnchecked(rawData);
}