using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging;

[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberWithMessagingSettings, MobilePhoneNumberWithMessagingSettingsFromRaw>))]
public sealed record class MobilePhoneNumberWithMessagingSettings : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public Features? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Features>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("features", value);
        }
    }

    /// <summary>
    /// The messaging product that the number is registered to use
    /// </summary>
    public string? MessagingProduct {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_product", value);
        }
    }

    /// <summary>
    /// Unique identifier for a messaging profile.
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

    /// <summary>
    /// The organization that owns this phone number.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    /// <summary>
    /// +E.164 formatted phone number.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Tags associated with this phone number.
    /// </summary>
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

    /// <summary>
    /// The messaging traffic or use case for which the number is currently configured.
    /// </summary>
    public string? TrafficType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "traffic_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("traffic_type", value);
        }
    }

    /// <summary>
    /// The type of the phone number
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        this.Features?.Validate();
        _ = this.MessagingProduct;
        _ = this.MessagingProfileID;
        _ = this.OrganizationID;
        _ = this.PhoneNumber;
        this.RecordType?.Validate();
        _ = this.Tags;
        _ = this.TrafficType;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public MobilePhoneNumberWithMessagingSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberWithMessagingSettings (
        MobilePhoneNumberWithMessagingSettings mobilePhoneNumberWithMessagingSettings
    ) : base(mobilePhoneNumberWithMessagingSettings)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberWithMessagingSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberWithMessagingSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberWithMessagingSettingsFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberWithMessagingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobilePhoneNumberWithMessagingSettingsFromRaw : IFromRawJson<MobilePhoneNumberWithMessagingSettings>
{
    /// <inheritdoc/>
    public MobilePhoneNumberWithMessagingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberWithMessagingSettings.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Features, FeaturesFromRaw>))]
public sealed record class Features : JsonModel
{
    /// <summary>
    /// The set of features available for a specific messaging use case (SMS or MMS).
    /// Features can vary depending on the characteristics the phone number, as well
    /// as its current product configuration.
    /// </summary>
    public MessagingFeatureSet? Sms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingFeatureSet>(
                "sms"
            );
        }
        init { this._rawData.Set("sms", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Sms?.Validate(); }

    public Features ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Features (Features features) : base(features)
    {  }
    #pragma warning restore CS8618

    public Features (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Features (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FeaturesFromRaw.FromRawUnchecked"/>
    public static Features FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FeaturesFromRaw : IFromRawJson<Features>
{
    /// <inheritdoc/>
    public Features FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Features.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    MessagingPhoneNumber, MessagingSettings
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "messaging_phone_number"=>RecordType.MessagingPhoneNumber,
            "messaging_settings"=>RecordType.MessagingSettings,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.MessagingPhoneNumber=>"messaging_phone_number",
            RecordType.MessagingSettings=>"messaging_settings",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of the phone number
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Longcode
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type>
{
    public override global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "longcode"=>global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type.Longcode,
            _ =>(global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging.Type.Longcode=>"longcode",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}