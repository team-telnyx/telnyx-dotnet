using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderPhoneNumberConfiguration, PortingOrderPhoneNumberConfigurationFromRaw>))]
public sealed record class PortingOrderPhoneNumberConfiguration : JsonModel
{
    /// <summary>
    /// identifies the billing group to set on the numbers when ported
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init { this._rawData.Set("billing_group_id", value); }
    }

    /// <summary>
    /// identifies the connection to set on the numbers when ported
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init { this._rawData.Set("connection_id", value); }
    }

    /// <summary>
    /// identifies the emergency address to set on the numbers when ported
    /// </summary>
    public string? EmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "emergency_address_id"
            );
        }
        init { this._rawData.Set("emergency_address_id", value); }
    }

    /// <summary>
    /// identifies the messaging profile to set on the numbers when ported
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawData.Set("messaging_profile_id", value); }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingGroupID;
        _ = this.ConnectionID;
        _ = this.EmergencyAddressID;
        _ = this.MessagingProfileID;
        _ = this.Tags;
    }

    public PortingOrderPhoneNumberConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderPhoneNumberConfiguration (
        PortingOrderPhoneNumberConfiguration portingOrderPhoneNumberConfiguration
    ) : base(portingOrderPhoneNumberConfiguration)
    {  }
    #pragma warning restore CS8618

    public PortingOrderPhoneNumberConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderPhoneNumberConfiguration (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderPhoneNumberConfigurationFromRaw.FromRawUnchecked"/>
    public static PortingOrderPhoneNumberConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderPhoneNumberConfigurationFromRaw : IFromRawJson<PortingOrderPhoneNumberConfiguration>
{
    /// <inheritdoc/>
    public PortingOrderPhoneNumberConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderPhoneNumberConfiguration.FromRawUnchecked(rawData);
}