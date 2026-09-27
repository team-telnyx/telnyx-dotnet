using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumberConfiguration, PortingPhoneNumberConfigurationFromRaw>))]
public sealed record class PortingPhoneNumberConfiguration : JsonModel
{
    /// <summary>
    /// Uniquely identifies this phone number configuration
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
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <summary>
    /// Identifies the associated porting phone number
    /// </summary>
    public string? PortingPhoneNumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_phone_number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_phone_number_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <summary>
    /// Identifies the associated user bundle
    /// </summary>
    public string? UserBundleID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_bundle_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_bundle_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.PortingPhoneNumberID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.UserBundleID;
    }

    public PortingPhoneNumberConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumberConfiguration (
        PortingPhoneNumberConfiguration portingPhoneNumberConfiguration
    ) : base(portingPhoneNumberConfiguration)
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumberConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumberConfiguration (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberConfigurationFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumberConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingPhoneNumberConfigurationFromRaw : IFromRawJson<PortingPhoneNumberConfiguration>
{
    /// <inheritdoc/>
    public PortingPhoneNumberConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumberConfiguration.FromRawUnchecked(rawData);
}