using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<HostedNumber, HostedNumberFromRaw>))]
public sealed record class HostedNumber : JsonModel
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
    /// The messaging hosted phone number (+E.164 format)
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

    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PhoneNumber;
        _ = this.RecordType;
        this.Status?.Validate();
    }

    public HostedNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HostedNumber (HostedNumber hostedNumber) : base(hostedNumber)
    {  }
    #pragma warning restore CS8618

    public HostedNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HostedNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HostedNumberFromRaw.FromRawUnchecked"/>
    public static HostedNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HostedNumberFromRaw : IFromRawJson<HostedNumber>
{
    /// <inheritdoc/>
    public HostedNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HostedNumber.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Deleted,
    Failed,
    FailedActivation,
    FailedCarrierRejected,
    FailedIneligibleCarrier,
    FailedNumberAlreadyHosted,
    FailedNumberNotFound,
    FailedOwnershipVerification,
    FailedTimeout,
    Pending,
    Provisioning,
    Successful
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deleted"=>Status.Deleted,
            "failed"=>Status.Failed,
            "failed_activation"=>Status.FailedActivation,
            "failed_carrier_rejected"=>Status.FailedCarrierRejected,
            "failed_ineligible_carrier"=>Status.FailedIneligibleCarrier,
            "failed_number_already_hosted"=>Status.FailedNumberAlreadyHosted,
            "failed_number_not_found"=>Status.FailedNumberNotFound,
            "failed_ownership_verification"=>Status.FailedOwnershipVerification,
            "failed_timeout"=>Status.FailedTimeout,
            "pending"=>Status.Pending,
            "provisioning"=>Status.Provisioning,
            "successful"=>Status.Successful,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Deleted=>"deleted",
            Status.Failed=>"failed",
            Status.FailedActivation=>"failed_activation",
            Status.FailedCarrierRejected=>"failed_carrier_rejected",
            Status.FailedIneligibleCarrier=>"failed_ineligible_carrier",
            Status.FailedNumberAlreadyHosted=>"failed_number_already_hosted",
            Status.FailedNumberNotFound=>"failed_number_not_found",
            Status.FailedOwnershipVerification=>"failed_ownership_verification",
            Status.FailedTimeout=>"failed_timeout",
            Status.Pending=>"pending",
            Status.Provisioning=>"provisioning",
            Status.Successful=>"successful",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}