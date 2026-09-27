using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberConfigurationCreateResponse, PhoneNumberConfigurationCreateResponseFromRaw>))]
public sealed record class PhoneNumberConfigurationCreateResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public PhoneNumberConfigurationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberConfigurationCreateResponse (
        PhoneNumberConfigurationCreateResponse phoneNumberConfigurationCreateResponse
    ) : base(phoneNumberConfigurationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberConfigurationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberConfigurationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberConfigurationCreateResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberConfigurationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberConfigurationCreateResponseFromRaw : IFromRawJson<PhoneNumberConfigurationCreateResponse>
{
    /// <inheritdoc/>
    public PhoneNumberConfigurationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberConfigurationCreateResponse.FromRawUnchecked(rawData);
}