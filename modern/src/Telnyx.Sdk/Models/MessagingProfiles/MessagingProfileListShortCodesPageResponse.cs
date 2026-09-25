using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileListShortCodesPageResponse, MessagingProfileListShortCodesPageResponseFromRaw>))]
public sealed record class MessagingProfileListShortCodesPageResponse : JsonModel
{
    public IReadOnlyList<ShortCode>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ShortCode>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ShortCode>?>(
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

    public MessagingProfileListShortCodesPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileListShortCodesPageResponse (
        MessagingProfileListShortCodesPageResponse messagingProfileListShortCodesPageResponse
    ) : base(messagingProfileListShortCodesPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileListShortCodesPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileListShortCodesPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileListShortCodesPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileListShortCodesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileListShortCodesPageResponseFromRaw : IFromRawJson<MessagingProfileListShortCodesPageResponse>
{
    /// <inheritdoc/>
    public MessagingProfileListShortCodesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileListShortCodesPageResponse.FromRawUnchecked(rawData);
}