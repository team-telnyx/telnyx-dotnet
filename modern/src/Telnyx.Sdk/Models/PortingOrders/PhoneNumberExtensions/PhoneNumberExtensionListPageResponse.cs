using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberExtensionListPageResponse, PhoneNumberExtensionListPageResponseFromRaw>))]
public sealed record class PhoneNumberExtensionListPageResponse : JsonModel
{
    public IReadOnlyList<PortingPhoneNumberExtension>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumberExtension>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumberExtension>?>(
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

    public PhoneNumberExtensionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberExtensionListPageResponse (
        PhoneNumberExtensionListPageResponse phoneNumberExtensionListPageResponse
    ) : base(phoneNumberExtensionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberExtensionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberExtensionListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberExtensionListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberExtensionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberExtensionListPageResponseFromRaw : IFromRawJson<PhoneNumberExtensionListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberExtensionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberExtensionListPageResponse.FromRawUnchecked(rawData);
}