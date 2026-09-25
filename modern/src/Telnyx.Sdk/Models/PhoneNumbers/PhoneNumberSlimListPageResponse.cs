using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberSlimListPageResponse, PhoneNumberSlimListPageResponseFromRaw>))]
public sealed record class PhoneNumberSlimListPageResponse : JsonModel
{
    public IReadOnlyList<PhoneNumberSlimListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumberSlimListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumberSlimListResponse>?>(
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

    public PhoneNumberSlimListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSlimListPageResponse (
        PhoneNumberSlimListPageResponse phoneNumberSlimListPageResponse
    ) : base(phoneNumberSlimListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberSlimListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSlimListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSlimListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSlimListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberSlimListPageResponseFromRaw : IFromRawJson<PhoneNumberSlimListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberSlimListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberSlimListPageResponse.FromRawUnchecked(rawData);
}