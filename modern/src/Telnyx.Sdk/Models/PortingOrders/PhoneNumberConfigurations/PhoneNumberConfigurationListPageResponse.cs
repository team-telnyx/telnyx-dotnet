using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberConfigurationListPageResponse, PhoneNumberConfigurationListPageResponseFromRaw>))]
public sealed record class PhoneNumberConfigurationListPageResponse : JsonModel
{
    public IReadOnlyList<PortingPhoneNumberConfiguration>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumberConfiguration>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumberConfiguration>?>(
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

    public PhoneNumberConfigurationListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberConfigurationListPageResponse (
        PhoneNumberConfigurationListPageResponse phoneNumberConfigurationListPageResponse
    ) : base(phoneNumberConfigurationListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberConfigurationListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberConfigurationListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberConfigurationListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberConfigurationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberConfigurationListPageResponseFromRaw : IFromRawJson<PhoneNumberConfigurationListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberConfigurationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberConfigurationListPageResponse.FromRawUnchecked(rawData);
}