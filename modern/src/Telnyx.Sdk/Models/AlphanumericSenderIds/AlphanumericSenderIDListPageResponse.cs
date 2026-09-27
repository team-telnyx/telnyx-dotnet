using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<AlphanumericSenderIDListPageResponse, AlphanumericSenderIDListPageResponseFromRaw>))]
public sealed record class AlphanumericSenderIDListPageResponse : JsonModel
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

    public AlphanumericSenderIDListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlphanumericSenderIDListPageResponse (
        AlphanumericSenderIDListPageResponse alphanumericSenderIDListPageResponse
    ) : base(alphanumericSenderIDListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AlphanumericSenderIDListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AlphanumericSenderIDListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AlphanumericSenderIDListPageResponseFromRaw.FromRawUnchecked"/>
    public static AlphanumericSenderIDListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AlphanumericSenderIDListPageResponseFromRaw : IFromRawJson<AlphanumericSenderIDListPageResponse>
{
    /// <inheritdoc/>
    public AlphanumericSenderIDListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AlphanumericSenderIDListPageResponse.FromRawUnchecked(rawData);
}