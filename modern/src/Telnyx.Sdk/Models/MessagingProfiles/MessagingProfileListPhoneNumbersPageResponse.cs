using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileListPhoneNumbersPageResponse, MessagingProfileListPhoneNumbersPageResponseFromRaw>))]
public sealed record class MessagingProfileListPhoneNumbersPageResponse : JsonModel
{
    public IReadOnlyList<PhoneNumberWithMessagingSettings>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumberWithMessagingSettings>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumberWithMessagingSettings>?>(
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

    public MessagingProfileListPhoneNumbersPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileListPhoneNumbersPageResponse (
        MessagingProfileListPhoneNumbersPageResponse messagingProfileListPhoneNumbersPageResponse
    ) : base(messagingProfileListPhoneNumbersPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileListPhoneNumbersPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileListPhoneNumbersPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileListPhoneNumbersPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileListPhoneNumbersPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileListPhoneNumbersPageResponseFromRaw : IFromRawJson<MessagingProfileListPhoneNumbersPageResponse>
{
    /// <inheritdoc/>
    public MessagingProfileListPhoneNumbersPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileListPhoneNumbersPageResponse.FromRawUnchecked(rawData);
}