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

[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateWebhookEvent, NumberOrderStatusUpdateWebhookEventFromRaw>))]
public sealed record class NumberOrderStatusUpdateWebhookEvent : JsonModel
{
    public required NumberOrderStatusUpdateWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderStatusUpdateWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required NumberOrderStatusUpdateWebhookEventMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderStatusUpdateWebhookEventMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Meta.Validate();
    }

    public NumberOrderStatusUpdateWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateWebhookEvent (
        NumberOrderStatusUpdateWebhookEvent numberOrderStatusUpdateWebhookEvent
    ) : base(numberOrderStatusUpdateWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateWebhookEventFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderStatusUpdateWebhookEventFromRaw : IFromRawJson<NumberOrderStatusUpdateWebhookEvent>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateWebhookEventData, NumberOrderStatusUpdateWebhookEventDataFromRaw>))]
public sealed record class NumberOrderStatusUpdateWebhookEventData : JsonModel
{
    /// <summary>
    /// Unique identifier for the event
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The type of event being sent
    /// </summary>
    public required ApiEnum<string, NumberOrderStatusUpdateWebhookEventDataEventType> EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NumberOrderStatusUpdateWebhookEventDataEventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the event occurred
    /// </summary>
    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// Number order data delivered in a webhook. Server-generated fields are valid
    /// in this outbound webhook request.
    /// </summary>
    public required NumberOrderStatusUpdateWebhookEventDataPayload Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NumberOrderStatusUpdateWebhookEventDataPayload>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    /// <summary>
    /// Type of record
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType.Validate();
        _ = this.OccurredAt;
        this.Payload.Validate();
        _ = this.RecordType;
    }

    public NumberOrderStatusUpdateWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateWebhookEventData (
        NumberOrderStatusUpdateWebhookEventData numberOrderStatusUpdateWebhookEventData
    ) : base(numberOrderStatusUpdateWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberOrderStatusUpdateWebhookEventDataFromRaw : IFromRawJson<NumberOrderStatusUpdateWebhookEventData>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// The type of event being sent
/// </summary>
[JsonConverter(typeof(NumberOrderStatusUpdateWebhookEventDataEventTypeConverter))]
public enum NumberOrderStatusUpdateWebhookEventDataEventType
{
    NumberOrderComplete
}sealed class NumberOrderStatusUpdateWebhookEventDataEventTypeConverter : JsonConverter<NumberOrderStatusUpdateWebhookEventDataEventType>
{
    public override NumberOrderStatusUpdateWebhookEventDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "number_order.complete"=>NumberOrderStatusUpdateWebhookEventDataEventType.NumberOrderComplete,
            _ =>(NumberOrderStatusUpdateWebhookEventDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumberOrderStatusUpdateWebhookEventDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberOrderStatusUpdateWebhookEventDataEventType.NumberOrderComplete=>"number_order.complete",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Number order data delivered in a webhook. Server-generated fields are valid in
/// this outbound webhook request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateWebhookEventDataPayload, NumberOrderStatusUpdateWebhookEventDataPayloadFromRaw>))]
public sealed record class NumberOrderStatusUpdateWebhookEventDataPayload : JsonModel
{
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
    /// Identifies the messaging profile associated with the phone number.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Identifies the connection associated with this phone number.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string denoting when the number order was created.
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

    /// <summary>
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Identifies the messaging profile associated with the phone number.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
    }

    public IReadOnlyList<PhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The count of phone numbers in the number order.
    /// </summary>
    public long? PhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "phone_numbers_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_numbers_count", value);
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

    /// <summary>
    /// True if all requirements are met for every phone number, false otherwise.
    /// </summary>
    public bool? RequirementsMet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "requirements_met"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_met", value);
        }
    }

    /// <summary>
    /// The status of the order.
    /// </summary>
    public ApiEnum<string, NumberOrderStatusUpdateWebhookEventDataPayloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NumberOrderStatusUpdateWebhookEventDataPayloadStatus>>(
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

    public IReadOnlyList<string>? SubNumberOrdersIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "sub_number_orders_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "sub_number_orders_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string for when the number order was updated.
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
        _ = this.BillingGroupID;
        _ = this.ConnectionID;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.MessagingProfileID;
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
        _ = this.PhoneNumbersCount;
        _ = this.RecordType;
        _ = this.RequirementsMet;
        this.Status?.Validate();
        _ = this.SubNumberOrdersIds;
        _ = this.UpdatedAt;
    }

    public NumberOrderStatusUpdateWebhookEventDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateWebhookEventDataPayload (
        NumberOrderStatusUpdateWebhookEventDataPayload numberOrderStatusUpdateWebhookEventDataPayload
    ) : base(numberOrderStatusUpdateWebhookEventDataPayload)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateWebhookEventDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateWebhookEventDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateWebhookEventDataPayloadFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberOrderStatusUpdateWebhookEventDataPayloadFromRaw : IFromRawJson<NumberOrderStatusUpdateWebhookEventDataPayload>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateWebhookEventDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateWebhookEventDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The unique phone numbers given as arguments in the job creation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
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

    public string? BundleID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bundle_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bundle_id", value);
        }
    }

    /// <summary>
    /// Country code of the phone number
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
    /// The ISO 3166-1 alpha-2 country code of the phone number.
    /// </summary>
    public string? CountryIsoAlpha2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_iso_alpha2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_iso_alpha2", value);
        }
    }

    public string? PhoneNumberValue {
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
    /// Phone number type
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
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

    public IReadOnlyList<RegulatoryRequirement>? RegulatoryRequirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RegulatoryRequirement>>(
                "regulatory_requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RegulatoryRequirement>?>(
                "regulatory_requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True if all requirements are met for a phone number, false otherwise.
    /// </summary>
    public bool? RequirementsMet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "requirements_met"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_met", value);
        }
    }

    /// <summary>
    /// Status of document requirements (if applicable)
    /// </summary>
    public ApiEnum<string, RequirementsStatus>? RequirementsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RequirementsStatus>>(
                "requirements_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirements_status", value);
        }
    }

    /// <summary>
    /// The status of the phone number in the order.
    /// </summary>
    public ApiEnum<string, PhoneNumberStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberStatus>>(
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
        _ = this.BundleID;
        _ = this.CountryCode;
        _ = this.CountryIsoAlpha2;
        _ = this.PhoneNumberValue;
        this.PhoneNumberType?.Validate();
        _ = this.RecordType;
        foreach (var item in this.RegulatoryRequirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        this.RequirementsStatus?.Validate();
        this.Status?.Validate();
    }

    public PhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber (PhoneNumber phoneNumber) : base(phoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}/// <summary>
/// Phone number type
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local, Mobile, National, SharedCost, TollFree
}sealed class PhoneNumberTypeConverter : JsonConverter<PhoneNumberType>
{
    public override PhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberType.Local,
            "mobile"=>PhoneNumberType.Mobile,
            "national"=>PhoneNumberType.National,
            "shared_cost"=>PhoneNumberType.SharedCost,
            "toll_free"=>PhoneNumberType.TollFree,
            _ =>(PhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberType.Local=>"local",
            PhoneNumberType.Mobile=>"mobile",
            PhoneNumberType.National=>"national",
            PhoneNumberType.SharedCost=>"shared_cost",
            PhoneNumberType.TollFree=>"toll_free",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Regulatory requirement data delivered in a number order webhook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RegulatoryRequirement, RegulatoryRequirementFromRaw>))]
public sealed record class RegulatoryRequirement : JsonModel
{
    public ApiEnum<string, FieldType>? FieldType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FieldType>>(
                "field_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_type", value);
        }
    }

    /// <summary>
    /// The value of the requirement, this could be an id to a resource or a string value.
    /// </summary>
    public string? FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_value", value);
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

    /// <summary>
    /// Unique id for a requirement.
    /// </summary>
    public string? RequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FieldType?.Validate();
        _ = this.FieldValue;
        _ = this.RecordType;
        _ = this.RequirementID;
    }

    public RegulatoryRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryRequirement (
        RegulatoryRequirement regulatoryRequirement
    ) : base(regulatoryRequirement)
    {  }
    #pragma warning restore CS8618

    public RegulatoryRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegulatoryRequirementFromRaw : IFromRawJson<RegulatoryRequirement>
{
    /// <inheritdoc/>
    public RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegulatoryRequirement.FromRawUnchecked(rawData);
}[JsonConverter(typeof(FieldTypeConverter))]
public enum FieldType
{
    Textual, Datetime, Address, Document
}sealed class FieldTypeConverter : JsonConverter<FieldType>
{
    public override FieldType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "textual"=>FieldType.Textual,
            "datetime"=>FieldType.Datetime,
            "address"=>FieldType.Address,
            "document"=>FieldType.Document,
            _ =>(FieldType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FieldType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FieldType.Textual=>"textual",
            FieldType.Datetime=>"datetime",
            FieldType.Address=>"address",
            FieldType.Document=>"document",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of document requirements (if applicable)
/// </summary>
[JsonConverter(typeof(RequirementsStatusConverter))]
public enum RequirementsStatus
{
    Pending,
    Approved,
    Cancelled,
    Deleted,
    RequirementInfoException,
    RequirementInfoPending,
    RequirementInfoUnderReview
}sealed class RequirementsStatusConverter : JsonConverter<RequirementsStatus>
{
    public override RequirementsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>RequirementsStatus.Pending,
            "approved"=>RequirementsStatus.Approved,
            "cancelled"=>RequirementsStatus.Cancelled,
            "deleted"=>RequirementsStatus.Deleted,
            "requirement-info-exception"=>RequirementsStatus.RequirementInfoException,
            "requirement-info-pending"=>RequirementsStatus.RequirementInfoPending,
            "requirement-info-under-review"=>RequirementsStatus.RequirementInfoUnderReview,
            _ =>(RequirementsStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequirementsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RequirementsStatus.Pending=>"pending",
            RequirementsStatus.Approved=>"approved",
            RequirementsStatus.Cancelled=>"cancelled",
            RequirementsStatus.Deleted=>"deleted",
            RequirementsStatus.RequirementInfoException=>"requirement-info-exception",
            RequirementsStatus.RequirementInfoPending=>"requirement-info-pending",
            RequirementsStatus.RequirementInfoUnderReview=>"requirement-info-under-review",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the phone number in the order.
/// </summary>
[JsonConverter(typeof(PhoneNumberStatusConverter))]
public enum PhoneNumberStatus
{
    Pending, Success, Failure
}sealed class PhoneNumberStatusConverter : JsonConverter<PhoneNumberStatus>
{
    public override PhoneNumberStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PhoneNumberStatus.Pending,
            "success"=>PhoneNumberStatus.Success,
            "failure"=>PhoneNumberStatus.Failure,
            _ =>(PhoneNumberStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberStatus.Pending=>"pending",
            PhoneNumberStatus.Success=>"success",
            PhoneNumberStatus.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the order.
/// </summary>
[JsonConverter(typeof(NumberOrderStatusUpdateWebhookEventDataPayloadStatusConverter))]
public enum NumberOrderStatusUpdateWebhookEventDataPayloadStatus
{
    Pending, Success, Failure
}sealed class NumberOrderStatusUpdateWebhookEventDataPayloadStatusConverter : JsonConverter<NumberOrderStatusUpdateWebhookEventDataPayloadStatus>
{
    public override NumberOrderStatusUpdateWebhookEventDataPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Pending,
            "success"=>NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Success,
            "failure"=>NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Failure,
            _ =>(NumberOrderStatusUpdateWebhookEventDataPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumberOrderStatusUpdateWebhookEventDataPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Pending=>"pending",
            NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Success=>"success",
            NumberOrderStatusUpdateWebhookEventDataPayloadStatus.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<NumberOrderStatusUpdateWebhookEventMeta, NumberOrderStatusUpdateWebhookEventMetaFromRaw>))]
public sealed record class NumberOrderStatusUpdateWebhookEventMeta : JsonModel
{
    /// <summary>
    /// Webhook delivery attempt number
    /// </summary>
    public required long Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "attempt"
            );
        }
        init { this._rawData.Set("attempt", value); }
    }

    /// <summary>
    /// URL where the webhook was delivered
    /// </summary>
    public required string DeliveredTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "delivered_to"
            );
        }
        init { this._rawData.Set("delivered_to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempt;
        _ = this.DeliveredTo;
    }

    public NumberOrderStatusUpdateWebhookEventMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderStatusUpdateWebhookEventMeta (
        NumberOrderStatusUpdateWebhookEventMeta numberOrderStatusUpdateWebhookEventMeta
    ) : base(numberOrderStatusUpdateWebhookEventMeta)
    {  }
    #pragma warning restore CS8618

    public NumberOrderStatusUpdateWebhookEventMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderStatusUpdateWebhookEventMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderStatusUpdateWebhookEventMetaFromRaw.FromRawUnchecked"/>
    public static NumberOrderStatusUpdateWebhookEventMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberOrderStatusUpdateWebhookEventMetaFromRaw : IFromRawJson<NumberOrderStatusUpdateWebhookEventMeta>
{
    /// <inheritdoc/>
    public NumberOrderStatusUpdateWebhookEventMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderStatusUpdateWebhookEventMeta.FromRawUnchecked(rawData);
}