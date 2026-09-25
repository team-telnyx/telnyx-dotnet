using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberListPageResponse, PhoneNumberListPageResponseFromRaw>))]
public sealed record class PhoneNumberListPageResponse : JsonModel
{
    public IReadOnlyList<PhoneNumberListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumberListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumberListResponse>?>(
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

    public PhoneNumberListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListPageResponse (
        PhoneNumberListPageResponse phoneNumberListPageResponse
    ) : base(phoneNumberListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberListPageResponseFromRaw : IFromRawJson<PhoneNumberListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberListPageResponse.FromRawUnchecked(rawData);
}