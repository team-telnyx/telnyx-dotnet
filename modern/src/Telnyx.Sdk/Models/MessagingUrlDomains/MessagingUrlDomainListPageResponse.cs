using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingUrlDomains;

[JsonConverter(typeof(JsonModelConverter<MessagingUrlDomainListPageResponse, MessagingUrlDomainListPageResponseFromRaw>))]
public sealed record class MessagingUrlDomainListPageResponse : JsonModel
{
    public IReadOnlyList<MessagingUrlDomainListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingUrlDomainListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingUrlDomainListResponse>?>(
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

    public MessagingUrlDomainListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingUrlDomainListPageResponse (
        MessagingUrlDomainListPageResponse messagingUrlDomainListPageResponse
    ) : base(messagingUrlDomainListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingUrlDomainListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingUrlDomainListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingUrlDomainListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessagingUrlDomainListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingUrlDomainListPageResponseFromRaw : IFromRawJson<MessagingUrlDomainListPageResponse>
{
    /// <inheritdoc/>
    public MessagingUrlDomainListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingUrlDomainListPageResponse.FromRawUnchecked(rawData);
}