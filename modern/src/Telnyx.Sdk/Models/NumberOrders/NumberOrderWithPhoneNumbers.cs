using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NumberOrders;

[JsonConverter(typeof(JsonModelConverter<NumberOrderWithPhoneNumbers, NumberOrderWithPhoneNumbersFromRaw>))]
public sealed record class NumberOrderWithPhoneNumbers : JsonModel
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

    public IReadOnlyList<NumberOrderPhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NumberOrderPhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NumberOrderPhoneNumber>?>(
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

    public NumberOrderWithPhoneNumbers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderWithPhoneNumbers (
        NumberOrderWithPhoneNumbers numberOrderWithPhoneNumbers
    ) : base(numberOrderWithPhoneNumbers)
    {  }
    #pragma warning restore CS8618

    public NumberOrderWithPhoneNumbers (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderWithPhoneNumbers (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderWithPhoneNumbersFromRaw.FromRawUnchecked"/>
    public static NumberOrderWithPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderWithPhoneNumbersFromRaw : IFromRawJson<NumberOrderWithPhoneNumbers>
{
    /// <inheritdoc/>
    public NumberOrderWithPhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderWithPhoneNumbers.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the order.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Success, Failure
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
            "success"=>Status.Success,
            "failure"=>Status.Failure,
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
            Status.Success=>"success",
            Status.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}