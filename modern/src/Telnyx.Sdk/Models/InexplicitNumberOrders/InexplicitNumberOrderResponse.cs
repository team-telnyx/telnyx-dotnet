using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.InexplicitNumberOrders;

[JsonConverter(typeof(JsonModelConverter<InexplicitNumberOrderResponse, InexplicitNumberOrderResponseFromRaw>))]
public sealed record class InexplicitNumberOrderResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the inexplicit number order
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
    /// Billing group id to apply to phone numbers that are purchased
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
    /// Connection id to apply to phone numbers that are purchased
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
    /// ISO 8601 formatted date indicating when the resource was created
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
    /// Reference label for the customer
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
    /// Messaging profile id to apply to phone numbers that are purchased
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

    public IReadOnlyList<InexplicitNumberOrderResponseOrderingGroup>? OrderingGroups {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InexplicitNumberOrderResponseOrderingGroup>>(
                "ordering_groups"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InexplicitNumberOrderResponseOrderingGroup>?>(
                "ordering_groups",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated
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
        foreach (var item in this.OrderingGroups ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public InexplicitNumberOrderResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderResponse (
        InexplicitNumberOrderResponse inexplicitNumberOrderResponse
    ) : base(inexplicitNumberOrderResponse)
    {  }
    #pragma warning restore CS8618

    public InexplicitNumberOrderResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InexplicitNumberOrderResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InexplicitNumberOrderResponseFromRaw.FromRawUnchecked"/>
    public static InexplicitNumberOrderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InexplicitNumberOrderResponseFromRaw : IFromRawJson<InexplicitNumberOrderResponse>
{
    /// <inheritdoc/>
    public InexplicitNumberOrderResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InexplicitNumberOrderResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<InexplicitNumberOrderResponseOrderingGroup, InexplicitNumberOrderResponseOrderingGroupFromRaw>))]
public sealed record class InexplicitNumberOrderResponseOrderingGroup : JsonModel
{
    /// <summary>
    /// Filter for phone numbers in a given state / province
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// Quantity of phone numbers allocated
    /// </summary>
    public long? CountAllocated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count_allocated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count_allocated", value);
        }
    }

    /// <summary>
    /// Quantity of phone numbers requested
    /// </summary>
    public long? CountRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count_requested"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count_requested", value);
        }
    }

    /// <summary>
    /// Country where you would like to purchase phone numbers
    /// </summary>
    public string? CountryIso {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_iso"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_iso", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the ordering group was created
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
    /// Error reason if applicable
    /// </summary>
    public string? ErrorReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_reason", value);
        }
    }

    /// <summary>
    /// Filter to exclude phone numbers that are currently on hold/reserved for your account.
    /// </summary>
    public bool? ExcludeHeldNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "exclude_held_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("exclude_held_numbers", value);
        }
    }

    /// <summary>
    /// Filter by area code
    /// </summary>
    public string? NationalDestinationCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "national_destination_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("national_destination_code", value);
        }
    }

    /// <summary>
    /// Array of orders created to fulfill the inexplicit order
    /// </summary>
    public IReadOnlyList<Order>? Orders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Order>>(
                "orders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Order>?>(
                "orders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number type
    /// </summary>
    public string? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Filter for phone numbers that contain the digits specified
    /// </summary>
    public string? PhoneNumberContains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number[contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number[contains]", value);
        }
    }

    /// <summary>
    /// Filter by the ending digits of the phone number
    /// </summary>
    public string? PhoneNumberEndsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number[ends_with]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number[ends_with]", value);
        }
    }

    /// <summary>
    /// Filter by the starting digits of the phone number
    /// </summary>
    public string? PhoneNumberStartsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number[starts_with]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number[starts_with]", value);
        }
    }

    /// <summary>
    /// Filter to exclude phone numbers that need additional time after to purchase
    /// to activate. Only applicable for +1 toll_free numbers.
    /// </summary>
    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
        }
    }

    /// <summary>
    /// Status of the ordering group
    /// </summary>
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

    /// <summary>
    /// Ordering strategy used
    /// </summary>
    public ApiEnum<string, InexplicitNumberOrderResponseOrderingGroupStrategy>? Strategy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InexplicitNumberOrderResponseOrderingGroupStrategy>>(
                "strategy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("strategy", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the ordering group was updated
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
        _ = this.AdministrativeArea;
        _ = this.CountAllocated;
        _ = this.CountRequested;
        _ = this.CountryIso;
        _ = this.CreatedAt;
        _ = this.ErrorReason;
        _ = this.ExcludeHeldNumbers;
        _ = this.NationalDestinationCode;
        foreach (var item in this.Orders ?? [])
        {
            item.Validate();
        }
        _ = this.PhoneNumberType;
        _ = this.PhoneNumberContains;
        _ = this.PhoneNumberEndsWith;
        _ = this.PhoneNumberStartsWith;
        _ = this.Quickship;
        this.Status?.Validate();
        this.Strategy?.Validate();
        _ = this.UpdatedAt;
    }

    public InexplicitNumberOrderResponseOrderingGroup ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderResponseOrderingGroup (
        InexplicitNumberOrderResponseOrderingGroup inexplicitNumberOrderResponseOrderingGroup
    ) : base(inexplicitNumberOrderResponseOrderingGroup)
    {  }
    #pragma warning restore CS8618

    public InexplicitNumberOrderResponseOrderingGroup (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InexplicitNumberOrderResponseOrderingGroup (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InexplicitNumberOrderResponseOrderingGroupFromRaw.FromRawUnchecked"/>
    public static InexplicitNumberOrderResponseOrderingGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InexplicitNumberOrderResponseOrderingGroupFromRaw : IFromRawJson<InexplicitNumberOrderResponseOrderingGroup>
{
    /// <inheritdoc/>
    public InexplicitNumberOrderResponseOrderingGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InexplicitNumberOrderResponseOrderingGroup.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Order, OrderFromRaw>))]
public sealed record class Order : JsonModel
{
    /// <summary>
    /// ID of the main number order
    /// </summary>
    public required string NumberOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "number_order_id"
            );
        }
        init { this._rawData.Set("number_order_id", value); }
    }

    /// <summary>
    /// Array of sub number order IDs
    /// </summary>
    public required IReadOnlyList<string> SubNumberOrderIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "sub_number_order_ids"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "sub_number_order_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumberOrderID;
        _ = this.SubNumberOrderIds;
    }

    public Order ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Order (Order order) : base(order)
    {  }
    #pragma warning restore CS8618

    public Order (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Order (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrderFromRaw.FromRawUnchecked"/>
    public static Order FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OrderFromRaw : IFromRawJson<Order>
{
    /// <inheritdoc/>
    public Order FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Order.FromRawUnchecked(rawData);
}/// <summary>
/// Status of the ordering group
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Processing, Failed, Success, PartialSuccess
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
            "pending"=>Status.Pending,
            "processing"=>Status.Processing,
            "failed"=>Status.Failed,
            "success"=>Status.Success,
            "partial_success"=>Status.PartialSuccess,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Processing=>"processing",
            Status.Failed=>"failed",
            Status.Success=>"success",
            Status.PartialSuccess=>"partial_success",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Ordering strategy used
/// </summary>
[JsonConverter(typeof(InexplicitNumberOrderResponseOrderingGroupStrategyConverter))]
public enum InexplicitNumberOrderResponseOrderingGroupStrategy
{
    Always, Never
}sealed class InexplicitNumberOrderResponseOrderingGroupStrategyConverter : JsonConverter<InexplicitNumberOrderResponseOrderingGroupStrategy>
{
    public override InexplicitNumberOrderResponseOrderingGroupStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>InexplicitNumberOrderResponseOrderingGroupStrategy.Always,
            "never"=>InexplicitNumberOrderResponseOrderingGroupStrategy.Never,
            _ =>(InexplicitNumberOrderResponseOrderingGroupStrategy)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InexplicitNumberOrderResponseOrderingGroupStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InexplicitNumberOrderResponseOrderingGroupStrategy.Always=>"always",
            InexplicitNumberOrderResponseOrderingGroupStrategy.Never=>"never",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}