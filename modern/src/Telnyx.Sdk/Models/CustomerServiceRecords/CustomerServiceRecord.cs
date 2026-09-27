using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomerServiceRecords;

[JsonConverter(typeof(JsonModelConverter<CustomerServiceRecord, CustomerServiceRecordFromRaw>))]
public sealed record class CustomerServiceRecord : JsonModel
{
    /// <summary>
    /// Uniquely identifies this customer service record
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
    /// The error message in case status is `failed`. This field would be null in
    /// case of `pending` or `completed` status.
    /// </summary>
    public string? ErrorMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_message"
            );
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// The phone number of the customer service record.
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
    /// The result of the CSR request. This field would be null in case of `pending`
    /// or `failed` status.
    /// </summary>
    public Result? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Result>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// The status of the customer service record
    /// </summary>
    public ApiEnum<string, CustomerServiceRecordStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CustomerServiceRecordStatus>>(
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

    /// <summary>
    /// Callback URL to receive webhook notifications.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.PhoneNumber;
        _ = this.RecordType;
        this.Result?.Validate();
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.WebhookUrl;
    }

    public CustomerServiceRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecord (
        CustomerServiceRecord customerServiceRecord
    ) : base(customerServiceRecord)
    {  }
    #pragma warning restore CS8618

    public CustomerServiceRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerServiceRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerServiceRecordFromRaw.FromRawUnchecked"/>
    public static CustomerServiceRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerServiceRecordFromRaw : IFromRawJson<CustomerServiceRecord>
{
    /// <inheritdoc/>
    public CustomerServiceRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerServiceRecord.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of the CSR request. This field would be null in case of `pending` or
/// `failed` status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The address of the customer service record
    /// </summary>
    public Address? Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>(
                "address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// The admin of the customer service record.
    /// </summary>
    public Admin? Admin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Admin>(
                "admin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("admin", value);
        }
    }

    /// <summary>
    /// The associated phone numbers of the customer service record.
    /// </summary>
    public IReadOnlyList<string>? AssociatedPhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "associated_phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "associated_phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The name of the carrier that the customer service record is for.
    /// </summary>
    public string? CarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address?.Validate();
        this.Admin?.Validate();
        _ = this.AssociatedPhoneNumbers;
        _ = this.CarrierName;
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
}/// <summary>
/// The address of the customer service record
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The state of the address
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
    /// The full address
    /// </summary>
    public string? FullAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "full_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("full_address", value);
        }
    }

    /// <summary>
    /// The city of the address
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// The zip code of the address
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The street address
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.FullAddress;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.StreetAddress;
    }

    public Address ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address (Address address) : base(address)
    {  }
    #pragma warning restore CS8618

    public Address (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Address (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Address.FromRawUnchecked(rawData);
}/// <summary>
/// The admin of the customer service record.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Admin, AdminFromRaw>))]
public sealed record class Admin : JsonModel
{
    /// <summary>
    /// The account number of the customer service record.
    /// </summary>
    public string? AccountNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_number", value);
        }
    }

    /// <summary>
    /// The authorized person name of the customer service record.
    /// </summary>
    public string? AuthorizedPersonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorized_person_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authorized_person_name", value);
        }
    }

    /// <summary>
    /// The billing phone number of the customer service record.
    /// </summary>
    public string? BillingPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_phone_number", value);
        }
    }

    /// <summary>
    /// The name of the customer service record.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.AuthorizedPersonName;
        _ = this.BillingPhoneNumber;
        _ = this.Name;
    }

    public Admin ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Admin (Admin admin) : base(admin)
    {  }
    #pragma warning restore CS8618

    public Admin (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Admin (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdminFromRaw.FromRawUnchecked"/>
    public static Admin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AdminFromRaw : IFromRawJson<Admin>
{
    /// <inheritdoc/>
    public Admin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Admin.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the customer service record
/// </summary>
[JsonConverter(typeof(CustomerServiceRecordStatusConverter))]
public enum CustomerServiceRecordStatus
{
    Pending, Completed, Failed
}sealed class CustomerServiceRecordStatusConverter : JsonConverter<CustomerServiceRecordStatus>
{
    public override CustomerServiceRecordStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>CustomerServiceRecordStatus.Pending,
            "completed"=>CustomerServiceRecordStatus.Completed,
            "failed"=>CustomerServiceRecordStatus.Failed,
            _ =>(CustomerServiceRecordStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerServiceRecordStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CustomerServiceRecordStatus.Pending=>"pending",
            CustomerServiceRecordStatus.Completed=>"completed",
            CustomerServiceRecordStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}