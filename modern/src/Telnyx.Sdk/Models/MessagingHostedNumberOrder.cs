using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrder, MessagingHostedNumberOrderFromRaw>))]
public sealed record class MessagingHostedNumberOrder : JsonModel
{
    /// <summary>
    /// Resource unique identifier.
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
    /// Automatically associate the number with this messaging profile ID when the
    /// order is complete.
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

    public IReadOnlyList<HostedNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<HostedNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<HostedNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public ApiEnum<string, MessagingHostedNumberOrderStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingHostedNumberOrderStatus>>(
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
        _ = this.MessagingProfileID;
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
        _ = this.RecordType;
        this.Status?.Validate();
    }

    public MessagingHostedNumberOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrder (
        MessagingHostedNumberOrder messagingHostedNumberOrder
    ) : base(messagingHostedNumberOrder)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrder (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderFromRaw : IFromRawJson<MessagingHostedNumberOrder>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MessagingHostedNumberOrderStatusConverter))]
public enum MessagingHostedNumberOrderStatus
{
    CarrierRejected,
    ComplianceReviewFailed,
    Deleted,
    Failed,
    IncompleteDocumentation,
    IncorrectBillingInformation,
    IneligibleCarrier,
    LoaFileInvalid,
    LoaFileSuccessful,
    Pending,
    Provisioning,
    Successful
}sealed class MessagingHostedNumberOrderStatusConverter : JsonConverter<MessagingHostedNumberOrderStatus>
{
    public override MessagingHostedNumberOrderStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "carrier_rejected"=>MessagingHostedNumberOrderStatus.CarrierRejected,
            "compliance_review_failed"=>MessagingHostedNumberOrderStatus.ComplianceReviewFailed,
            "deleted"=>MessagingHostedNumberOrderStatus.Deleted,
            "failed"=>MessagingHostedNumberOrderStatus.Failed,
            "incomplete_documentation"=>MessagingHostedNumberOrderStatus.IncompleteDocumentation,
            "incorrect_billing_information"=>MessagingHostedNumberOrderStatus.IncorrectBillingInformation,
            "ineligible_carrier"=>MessagingHostedNumberOrderStatus.IneligibleCarrier,
            "loa_file_invalid"=>MessagingHostedNumberOrderStatus.LoaFileInvalid,
            "loa_file_successful"=>MessagingHostedNumberOrderStatus.LoaFileSuccessful,
            "pending"=>MessagingHostedNumberOrderStatus.Pending,
            "provisioning"=>MessagingHostedNumberOrderStatus.Provisioning,
            "successful"=>MessagingHostedNumberOrderStatus.Successful,
            _ =>(MessagingHostedNumberOrderStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingHostedNumberOrderStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingHostedNumberOrderStatus.CarrierRejected=>"carrier_rejected",
            MessagingHostedNumberOrderStatus.ComplianceReviewFailed=>"compliance_review_failed",
            MessagingHostedNumberOrderStatus.Deleted=>"deleted",
            MessagingHostedNumberOrderStatus.Failed=>"failed",
            MessagingHostedNumberOrderStatus.IncompleteDocumentation=>"incomplete_documentation",
            MessagingHostedNumberOrderStatus.IncorrectBillingInformation=>"incorrect_billing_information",
            MessagingHostedNumberOrderStatus.IneligibleCarrier=>"ineligible_carrier",
            MessagingHostedNumberOrderStatus.LoaFileInvalid=>"loa_file_invalid",
            MessagingHostedNumberOrderStatus.LoaFileSuccessful=>"loa_file_successful",
            MessagingHostedNumberOrderStatus.Pending=>"pending",
            MessagingHostedNumberOrderStatus.Provisioning=>"provisioning",
            MessagingHostedNumberOrderStatus.Successful=>"successful",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}