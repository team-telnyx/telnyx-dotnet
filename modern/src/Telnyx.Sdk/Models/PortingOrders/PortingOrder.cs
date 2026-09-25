using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using PortingPhoneNumbers = Telnyx.Sdk.Models.PortingPhoneNumbers;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrder, PortingOrderFromRaw>))]
public sealed record class PortingOrder : JsonModel
{
    /// <summary>
    /// Uniquely identifies this porting order
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

    public PortingOrderActivationSettings? ActivationSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderActivationSettings>(
                "activation_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activation_settings", value);
        }
    }

    /// <summary>
    /// For specific porting orders, we may require additional steps to be taken
    /// before submitting the porting order.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AdditionalStep>>? AdditionalSteps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdditionalStep>>>(
                "additional_steps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AdditionalStep>>?>(
                "additional_steps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// A customer-specified group reference for customer bookkeeping purposes
    /// </summary>
    public string? CustomerGroupReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_group_reference"
            );
        }
        init { this._rawData.Set("customer_group_reference", value); }
    }

    /// <summary>
    /// A customer-specified reference number for customer bookkeeping purposes
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init { this._rawData.Set("customer_reference", value); }
    }

    /// <summary>
    /// A description of the porting order
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Can be specified directly or via the `requirement_group_id` parameter.
    /// </summary>
    public PortingOrderDocuments? Documents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderDocuments>(
                "documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("documents", value);
        }
    }

    public PortingOrderEndUser? EndUser {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderEndUser>(
                "end_user"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_user", value);
        }
    }

    /// <summary>
    /// Information about messaging porting process.
    /// </summary>
    public PortingOrderMessaging? Messaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderMessaging>(
                "messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging", value);
        }
    }

    public PortingOrderMisc? Misc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderMisc>(
                "misc"
            );
        }
        init { this._rawData.Set("misc", value); }
    }

    /// <summary>
    /// Identifies the old service provider
    /// </summary>
    public string? OldServiceProviderOcn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "old_service_provider_ocn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("old_service_provider_ocn", value);
        }
    }

    /// <summary>
    /// A key to reference for the porting order group when contacting Telnyx customer
    /// support. This information is not available for porting orders in `draft` state
    /// </summary>
    public string? ParentSupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parent_support_key"
            );
        }
        init { this._rawData.Set("parent_support_key", value); }
    }

    public PortingOrderPhoneNumberConfiguration? PhoneNumberConfiguration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderPhoneNumberConfiguration>(
                "phone_number_configuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_configuration", value);
        }
    }

    /// <summary>
    /// The type of the phone number
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

    /// <summary>
    /// List of phone numbers associated with this porting order
    /// </summary>
    public IReadOnlyList<PortingPhoneNumbers::PortingPhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumbers::PortingPhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumbers::PortingPhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Count of phone numbers associated with this porting order
    /// </summary>
    public long? PortingPhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "porting_phone_numbers_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_phone_numbers_count", value);
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
    /// List of documentation requirements for porting numbers. Can be set directly
    /// or via the `requirement_group_id` parameter.
    /// </summary>
    public IReadOnlyList<PortingOrderRequirement>? Requirements {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrderRequirement>>(
                "requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrderRequirement>?>(
                "requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Is true when the required documentation is met
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
    /// Porting order status
    /// </summary>
    public PortingOrderStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderStatus>(
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
    /// A key to reference this porting order when contacting Telnyx customer support.
    /// This information is not available in draft porting orders.
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "support_key"
            );
        }
        init { this._rawData.Set("support_key", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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

    public PortingOrderUserFeedback? UserFeedback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderUserFeedback>(
                "user_feedback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_feedback", value);
        }
    }

    /// <summary>
    /// Identifies the user (or organization) who requested the porting order
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

    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ActivationSettings?.Validate();
        foreach (var item in this.AdditionalSteps ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.CustomerGroupReference;
        _ = this.CustomerReference;
        _ = this.Description;
        this.Documents?.Validate();
        this.EndUser?.Validate();
        this.Messaging?.Validate();
        this.Misc?.Validate();
        _ = this.OldServiceProviderOcn;
        _ = this.ParentSupportKey;
        this.PhoneNumberConfiguration?.Validate();
        this.PhoneNumberType?.Validate();
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
        _ = this.PortingPhoneNumbersCount;
        _ = this.RecordType;
        foreach (var item in this.Requirements ?? [])
        {
            item.Validate();
        }
        _ = this.RequirementsMet;
        this.Status?.Validate();
        _ = this.SupportKey;
        _ = this.UpdatedAt;
        this.UserFeedback?.Validate();
        _ = this.UserID;
        _ = this.WebhookUrl;
    }

    public PortingOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrder (PortingOrder portingOrder) : base(portingOrder)
    {  }
    #pragma warning restore CS8618

    public PortingOrder (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderFromRaw.FromRawUnchecked"/>
    public static PortingOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderFromRaw : IFromRawJson<PortingOrder>
{
    /// <inheritdoc/>
    public PortingOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdditionalStepConverter))]
public enum AdditionalStep
{
    AssociatedPhoneNumbers, PhoneNumberVerificationCodes
}sealed class AdditionalStepConverter : JsonConverter<AdditionalStep>
{
    public override AdditionalStep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "associated_phone_numbers"=>AdditionalStep.AssociatedPhoneNumbers,
            "phone_number_verification_codes"=>AdditionalStep.PhoneNumberVerificationCodes,
            _ =>(AdditionalStep)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdditionalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdditionalStep.AssociatedPhoneNumbers=>"associated_phone_numbers",
            AdditionalStep.PhoneNumberVerificationCodes=>"phone_number_verification_codes",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of the phone number
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Landline, Local, Mobile, National, SharedCost, TollFree
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
            "landline"=>PhoneNumberType.Landline,
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
            PhoneNumberType.Landline=>"landline",
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
}