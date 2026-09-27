using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

[JsonConverter(typeof(JsonModelConverter<DynamicEmergencyEndpoint, DynamicEmergencyEndpointFromRaw>))]
public sealed record class DynamicEmergencyEndpoint : JsonModel
{
    public required string CallbackNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "callback_number"
            );
        }
        init { this._rawData.Set("callback_number", value); }
    }

    public required string CallerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "caller_name"
            );
        }
        init { this._rawData.Set("caller_name", value); }
    }

    /// <summary>
    /// An id of a currently active dynamic emergency location.
    /// </summary>
    public required string DynamicEmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "dynamic_emergency_address_id"
            );
        }
        init { this._rawData.Set("dynamic_emergency_address_id", value); }
    }

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
    /// ISO 8601 formatted date of when the resource was created
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    public string? SipFromID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_from_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_from_id", value);
        }
    }

    /// <summary>
    /// Status of dynamic emergency address
    /// </summary>
    public ApiEnum<string, DynamicEmergencyEndpointStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DynamicEmergencyEndpointStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the resource was last updated
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.CallbackNumber;
        _ = this.CallerName;
        _ = this.DynamicEmergencyAddressID;
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.SipFromID;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public DynamicEmergencyEndpoint ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicEmergencyEndpoint (
        DynamicEmergencyEndpoint dynamicEmergencyEndpoint
    ) : base(dynamicEmergencyEndpoint)
    {  }
    #pragma warning restore CS8618

    public DynamicEmergencyEndpoint (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicEmergencyEndpoint (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DynamicEmergencyEndpointFromRaw.FromRawUnchecked"/>
    public static DynamicEmergencyEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DynamicEmergencyEndpointFromRaw : IFromRawJson<DynamicEmergencyEndpoint>
{
    /// <inheritdoc/>
    public DynamicEmergencyEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DynamicEmergencyEndpoint.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of dynamic emergency address
/// </summary>
[JsonConverter(typeof(DynamicEmergencyEndpointStatusConverter))]
public enum DynamicEmergencyEndpointStatus
{
    Pending, Activated, Rejected
}sealed class DynamicEmergencyEndpointStatusConverter : JsonConverter<DynamicEmergencyEndpointStatus>
{
    public override DynamicEmergencyEndpointStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>DynamicEmergencyEndpointStatus.Pending,
            "activated"=>DynamicEmergencyEndpointStatus.Activated,
            "rejected"=>DynamicEmergencyEndpointStatus.Rejected,
            _ =>(DynamicEmergencyEndpointStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DynamicEmergencyEndpointStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DynamicEmergencyEndpointStatus.Pending=>"pending",
            DynamicEmergencyEndpointStatus.Activated=>"activated",
            DynamicEmergencyEndpointStatus.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}