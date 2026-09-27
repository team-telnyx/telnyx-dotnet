using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionPhoneNumber, ExternalConnectionPhoneNumberFromRaw>))]
public sealed record class ExternalConnectionPhoneNumber : JsonModel
{
    public IReadOnlyList<ApiEnum<string, AcquiredCapability>>? AcquiredCapabilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AcquiredCapability>>>(
                "acquired_capabilities"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AcquiredCapability>>?>(
                "acquired_capabilities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the civic address assigned to the phone number.
    /// </summary>
    public string? CivicAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "civic_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("civic_address_id", value);
        }
    }

    /// <summary>
    /// The iso country code that will be displayed to the user when they receive
    /// a call from this phone number.
    /// </summary>
    public string? DisplayedCountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "displayed_country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("displayed_country_code", value);
        }
    }

    /// <summary>
    /// Identifies the location assigned to the phone number.
    /// </summary>
    public string? LocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location_id", value);
        }
    }

    /// <summary>
    /// Phone number ID from the Telnyx API.
    /// </summary>
    public string? NumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_id", value);
        }
    }

    /// <summary>
    /// Phone number in E164 format.
    /// </summary>
    public string? TelephoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telephone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telephone_number", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the resource.
    /// </summary>
    public string? TicketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ticket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ticket_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AcquiredCapabilities ?? [])
        {
            item.Validate();
        }
        _ = this.CivicAddressID;
        _ = this.DisplayedCountryCode;
        _ = this.LocationID;
        _ = this.NumberID;
        _ = this.TelephoneNumber;
        _ = this.TicketID;
    }

    public ExternalConnectionPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionPhoneNumber (
        ExternalConnectionPhoneNumber externalConnectionPhoneNumber
    ) : base(externalConnectionPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionPhoneNumber (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionPhoneNumberFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionPhoneNumberFromRaw : IFromRawJson<ExternalConnectionPhoneNumber>
{
    /// <inheritdoc/>
    public ExternalConnectionPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionPhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// The capabilities that are available for this phone number on Microsoft Teams.
/// </summary>
[JsonConverter(typeof(AcquiredCapabilityConverter))]
public enum AcquiredCapability
{
    FirstPartyAppAssignment,
    InboundCalling,
    Office365,
    OutboundCalling,
    UserAssignment
}sealed class AcquiredCapabilityConverter : JsonConverter<AcquiredCapability>
{
    public override AcquiredCapability Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FirstPartyAppAssignment"=>AcquiredCapability.FirstPartyAppAssignment,
            "InboundCalling"=>AcquiredCapability.InboundCalling,
            "Office365"=>AcquiredCapability.Office365,
            "OutboundCalling"=>AcquiredCapability.OutboundCalling,
            "UserAssignment"=>AcquiredCapability.UserAssignment,
            _ =>(AcquiredCapability)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AcquiredCapability value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AcquiredCapability.FirstPartyAppAssignment=>"FirstPartyAppAssignment",
            AcquiredCapability.InboundCalling=>"InboundCalling",
            AcquiredCapability.Office365=>"Office365",
            AcquiredCapability.OutboundCalling=>"OutboundCalling",
            AcquiredCapability.UserAssignment=>"UserAssignment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}