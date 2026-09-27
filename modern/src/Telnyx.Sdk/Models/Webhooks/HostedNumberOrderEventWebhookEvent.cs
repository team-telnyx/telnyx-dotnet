using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<HostedNumberOrderEventWebhookEvent, HostedNumberOrderEventWebhookEventFromRaw>))]
public sealed record class HostedNumberOrderEventWebhookEvent : JsonModel
{
    public HostedNumberOrderEventWebhookEventData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HostedNumberOrderEventWebhookEventData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public HostedNumberOrderEventWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HostedNumberOrderEventWebhookEvent (
        HostedNumberOrderEventWebhookEvent hostedNumberOrderEventWebhookEvent
    ) : base(hostedNumberOrderEventWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public HostedNumberOrderEventWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HostedNumberOrderEventWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HostedNumberOrderEventWebhookEventFromRaw.FromRawUnchecked"/>
    public static HostedNumberOrderEventWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HostedNumberOrderEventWebhookEventFromRaw : IFromRawJson<HostedNumberOrderEventWebhookEvent>
{
    /// <inheritdoc/>
    public HostedNumberOrderEventWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HostedNumberOrderEventWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<HostedNumberOrderEventWebhookEventData, HostedNumberOrderEventWebhookEventDataFromRaw>))]
public sealed record class HostedNumberOrderEventWebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
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
    /// The type of event being delivered. Internal transfer events are only emitted
    /// for orders where the numbers are already active on another Telnyx account.
    /// </summary>
    public ApiEnum<string, HostedNumberOrderEventWebhookEventDataEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HostedNumberOrderEventWebhookEventDataEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the event was generated.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    /// <summary>
    /// Payload delivered with every messaging_hosted_numbers_orders.* event. `approval_deadline`
    /// and `decision` are meaningful only for `internal_transfer_*` events.
    /// </summary>
    public HostedNumberOrderEventWebhookEventDataPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HostedNumberOrderEventWebhookEventDataPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, HostedNumberOrderEventWebhookEventDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, HostedNumberOrderEventWebhookEventDataRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public HostedNumberOrderEventWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HostedNumberOrderEventWebhookEventData (
        HostedNumberOrderEventWebhookEventData hostedNumberOrderEventWebhookEventData
    ) : base(hostedNumberOrderEventWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public HostedNumberOrderEventWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HostedNumberOrderEventWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HostedNumberOrderEventWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static HostedNumberOrderEventWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class HostedNumberOrderEventWebhookEventDataFromRaw : IFromRawJson<HostedNumberOrderEventWebhookEventData>
{
    /// <inheritdoc/>
    public HostedNumberOrderEventWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HostedNumberOrderEventWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being delivered. Internal transfer events are only emitted
/// for orders where the numbers are already active on another Telnyx account.
/// </summary>
[JsonConverter(typeof(HostedNumberOrderEventWebhookEventDataEventTypeConverter))]
public enum HostedNumberOrderEventWebhookEventDataEventType
{
    MessagingHostedNumbersOrdersCreated,
    MessagingHostedNumbersOrdersUpdated,
    MessagingHostedNumbersOrdersDeleted,
    MessagingHostedNumbersOrdersInternalTransferDetected,
    MessagingHostedNumbersOrdersInternalTransferApprovalRequested,
    MessagingHostedNumbersOrdersInternalTransferApproved,
    MessagingHostedNumbersOrdersInternalTransferRejected,
    MessagingHostedNumbersOrdersInternalTransferAutoApproved
}sealed class HostedNumberOrderEventWebhookEventDataEventTypeConverter : JsonConverter<HostedNumberOrderEventWebhookEventDataEventType>
{
    public override HostedNumberOrderEventWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "messaging_hosted_numbers_orders.created"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersCreated,
            "messaging_hosted_numbers_orders.updated"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersUpdated,
            "messaging_hosted_numbers_orders.deleted"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersDeleted,
            "messaging_hosted_numbers_orders.internal_transfer_detected"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferDetected,
            "messaging_hosted_numbers_orders.internal_transfer_approval_requested"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferApprovalRequested,
            "messaging_hosted_numbers_orders.internal_transfer_approved"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferApproved,
            "messaging_hosted_numbers_orders.internal_transfer_rejected"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferRejected,
            "messaging_hosted_numbers_orders.internal_transfer_auto_approved"=>HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferAutoApproved,
            _ =>(HostedNumberOrderEventWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HostedNumberOrderEventWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersCreated=>"messaging_hosted_numbers_orders.created",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersUpdated=>"messaging_hosted_numbers_orders.updated",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersDeleted=>"messaging_hosted_numbers_orders.deleted",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferDetected=>"messaging_hosted_numbers_orders.internal_transfer_detected",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferApprovalRequested=>"messaging_hosted_numbers_orders.internal_transfer_approval_requested",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferApproved=>"messaging_hosted_numbers_orders.internal_transfer_approved",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferRejected=>"messaging_hosted_numbers_orders.internal_transfer_rejected",
            HostedNumberOrderEventWebhookEventDataEventType.MessagingHostedNumbersOrdersInternalTransferAutoApproved=>"messaging_hosted_numbers_orders.internal_transfer_auto_approved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Payload delivered with every messaging_hosted_numbers_orders.* event. `approval_deadline`
/// and `decision` are meaningful only for `internal_transfer_*` events.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<HostedNumberOrderEventWebhookEventDataPayload, HostedNumberOrderEventWebhookEventDataPayloadFromRaw>))]
public sealed record class HostedNumberOrderEventWebhookEventDataPayload : JsonModel
{
    /// <summary>
    /// Unix timestamp (seconds) by which the losing organization must respond before
    /// auto-approval. Populated on internal-transfer events once an approval window
    /// has been issued.
    /// </summary>
    public long? ApprovalDeadline {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "approval_deadline"
            );
        }
        init { this._rawData.Set("approval_deadline", value); }
    }

    /// <summary>
    /// Approval decision for the internal transfer. Defaults to `pending` for non-internal-transfer events.
    /// </summary>
    public ApiEnum<string, Decision>? Decision {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Decision>>(
                "decision"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("decision", value);
        }
    }

    public IReadOnlyList<Number>? Numbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Number>>(
                "numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Number>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the hosted number order.
    /// </summary>
    public string? OrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_id", value);
        }
    }

    /// <summary>
    /// Current status of the order.
    /// </summary>
    public ApiEnum<string, OrderStatus>? OrderStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OrderStatus>>(
                "order_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_status", value);
        }
    }

    /// <summary>
    /// The messaging profile associated with the order.
    /// </summary>
    public string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_id", value);
        }
    }

    /// <summary>
    /// The organization that owns the order.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApprovalDeadline;
        this.Decision?.Validate();
        foreach (var item in this.Numbers ?? [])
        {
            item.Validate();
        }
        _ = this.OrderID;
        this.OrderStatus?.Validate();
        _ = this.ProfileID;
        _ = this.UserID;
    }

    public HostedNumberOrderEventWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HostedNumberOrderEventWebhookEventDataPayload (
        HostedNumberOrderEventWebhookEventDataPayload hostedNumberOrderEventWebhookEventDataPayload
    ) : base(hostedNumberOrderEventWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public HostedNumberOrderEventWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HostedNumberOrderEventWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HostedNumberOrderEventWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static HostedNumberOrderEventWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class HostedNumberOrderEventWebhookEventDataPayloadFromRaw : IFromRawJson<HostedNumberOrderEventWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public HostedNumberOrderEventWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HostedNumberOrderEventWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Approval decision for the internal transfer. Defaults to `pending` for non-internal-transfer events.
/// </summary>
[JsonConverter(typeof(DecisionConverter))]
public enum Decision
{
    Pending, Approved, Rejected
}sealed class DecisionConverter : JsonConverter<Decision>
{
    public override Decision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Decision.Pending,
            "approved"=>Decision.Approved,
            "rejected"=>Decision.Rejected,
            _ =>(Decision)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Decision value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Decision.Pending=>"pending",
            Decision.Approved=>"approved",
            Decision.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Number, NumberFromRaw>))]
public sealed record class Number : JsonModel
{
    /// <summary>
    /// Current status of this phone number within the order.
    /// </summary>
    public ApiEnum<string, NumberStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NumberStatus>>(
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
    /// Phone number in +E.164 format.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status?.Validate();
        _ = this.Value;
    }

    public Number ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Number (Number number) : base(number)
    {  }
    #pragma warning restore CS8618

    public Number (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Number (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberFromRaw.FromRawUnchecked"/>
    public static Number FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberFromRaw : IFromRawJson<Number>
{
    /// <inheritdoc/>
    public Number FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Number.FromRawUnchecked(rawData);
}/// <summary>
/// Current status of this phone number within the order.
/// </summary>
[JsonConverter(typeof(NumberStatusConverter))]
public enum NumberStatus
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
    OwnershipSuccessful,
    Pending,
    Provisioning,
    Successful
}sealed class NumberStatusConverter : JsonConverter<NumberStatus>
{
    public override NumberStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deleted"=>NumberStatus.Deleted,
            "failed"=>NumberStatus.Failed,
            "failed_activation"=>NumberStatus.FailedActivation,
            "failed_carrier_rejected"=>NumberStatus.FailedCarrierRejected,
            "failed_ineligible_carrier"=>NumberStatus.FailedIneligibleCarrier,
            "failed_number_already_hosted"=>NumberStatus.FailedNumberAlreadyHosted,
            "failed_number_not_found"=>NumberStatus.FailedNumberNotFound,
            "failed_ownership_verification"=>NumberStatus.FailedOwnershipVerification,
            "failed_timeout"=>NumberStatus.FailedTimeout,
            "ownership_successful"=>NumberStatus.OwnershipSuccessful,
            "pending"=>NumberStatus.Pending,
            "provisioning"=>NumberStatus.Provisioning,
            "successful"=>NumberStatus.Successful,
            _ =>(NumberStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, NumberStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberStatus.Deleted=>"deleted",
            NumberStatus.Failed=>"failed",
            NumberStatus.FailedActivation=>"failed_activation",
            NumberStatus.FailedCarrierRejected=>"failed_carrier_rejected",
            NumberStatus.FailedIneligibleCarrier=>"failed_ineligible_carrier",
            NumberStatus.FailedNumberAlreadyHosted=>"failed_number_already_hosted",
            NumberStatus.FailedNumberNotFound=>"failed_number_not_found",
            NumberStatus.FailedOwnershipVerification=>"failed_ownership_verification",
            NumberStatus.FailedTimeout=>"failed_timeout",
            NumberStatus.OwnershipSuccessful=>"ownership_successful",
            NumberStatus.Pending=>"pending",
            NumberStatus.Provisioning=>"provisioning",
            NumberStatus.Successful=>"successful",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current status of the order.
/// </summary>
[JsonConverter(typeof(OrderStatusConverter))]
public enum OrderStatus
{
    Pending,
    Provisioning,
    Successful,
    Failed,
    Deleted,
    CarrierRejected,
    ComplianceReviewFailed,
    IncompleteDocumentation,
    IncorrectBillingInformation,
    IneligibleCarrier,
    LoaFileInvalid,
    LoaFileSuccessful
}sealed class OrderStatusConverter : JsonConverter<OrderStatus>
{
    public override OrderStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>OrderStatus.Pending,
            "provisioning"=>OrderStatus.Provisioning,
            "successful"=>OrderStatus.Successful,
            "failed"=>OrderStatus.Failed,
            "deleted"=>OrderStatus.Deleted,
            "carrier_rejected"=>OrderStatus.CarrierRejected,
            "compliance_review_failed"=>OrderStatus.ComplianceReviewFailed,
            "incomplete_documentation"=>OrderStatus.IncompleteDocumentation,
            "incorrect_billing_information"=>OrderStatus.IncorrectBillingInformation,
            "ineligible_carrier"=>OrderStatus.IneligibleCarrier,
            "loa_file_invalid"=>OrderStatus.LoaFileInvalid,
            "loa_file_successful"=>OrderStatus.LoaFileSuccessful,
            _ =>(OrderStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, OrderStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OrderStatus.Pending=>"pending",
            OrderStatus.Provisioning=>"provisioning",
            OrderStatus.Successful=>"successful",
            OrderStatus.Failed=>"failed",
            OrderStatus.Deleted=>"deleted",
            OrderStatus.CarrierRejected=>"carrier_rejected",
            OrderStatus.ComplianceReviewFailed=>"compliance_review_failed",
            OrderStatus.IncompleteDocumentation=>"incomplete_documentation",
            OrderStatus.IncorrectBillingInformation=>"incorrect_billing_information",
            OrderStatus.IneligibleCarrier=>"ineligible_carrier",
            OrderStatus.LoaFileInvalid=>"loa_file_invalid",
            OrderStatus.LoaFileSuccessful=>"loa_file_successful",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(HostedNumberOrderEventWebhookEventDataRecordTypeConverter))]
public enum HostedNumberOrderEventWebhookEventDataRecordType
{
    Event
}sealed class HostedNumberOrderEventWebhookEventDataRecordTypeConverter : JsonConverter<HostedNumberOrderEventWebhookEventDataRecordType>
{
    public override HostedNumberOrderEventWebhookEventDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>HostedNumberOrderEventWebhookEventDataRecordType.Event,
            _ =>(HostedNumberOrderEventWebhookEventDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HostedNumberOrderEventWebhookEventDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HostedNumberOrderEventWebhookEventDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}