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

[JsonConverter(typeof(JsonModelConverter<CustomerServiceRecordVerifyPhoneNumberCoverageResponse, CustomerServiceRecordVerifyPhoneNumberCoverageResponseFromRaw>))]
public sealed record class CustomerServiceRecordVerifyPhoneNumberCoverageResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public CustomerServiceRecordVerifyPhoneNumberCoverageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerServiceRecordVerifyPhoneNumberCoverageResponse (
        CustomerServiceRecordVerifyPhoneNumberCoverageResponse customerServiceRecordVerifyPhoneNumberCoverageResponse
    ) : base(customerServiceRecordVerifyPhoneNumberCoverageResponse)
    {  }
    #pragma warning restore CS8618

    public CustomerServiceRecordVerifyPhoneNumberCoverageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerServiceRecordVerifyPhoneNumberCoverageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerServiceRecordVerifyPhoneNumberCoverageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerServiceRecordVerifyPhoneNumberCoverageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerServiceRecordVerifyPhoneNumberCoverageResponseFromRaw : IFromRawJson<CustomerServiceRecordVerifyPhoneNumberCoverageResponse>
{
    /// <inheritdoc/>
    public CustomerServiceRecordVerifyPhoneNumberCoverageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerServiceRecordVerifyPhoneNumberCoverageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Additional data required to perform CSR for the phone number. Only returned
    /// if `has_csr_coverage` is true.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AdditionalDataRequired>>? AdditionalDataRequired {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdditionalDataRequired>>>(
                "additional_data_required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AdditionalDataRequired>>?>(
                "additional_data_required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates whether the phone number is covered or not.
    /// </summary>
    public bool? HasCsrCoverage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "has_csr_coverage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("has_csr_coverage", value);
        }
    }

    /// <summary>
    /// The phone number that is being verified.
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
    /// The reason why the phone number is not covered. Only returned if `has_csr_coverage`
    /// is false.
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AdditionalDataRequired ?? [])
        {
            item.Validate();
        }
        _ = this.HasCsrCoverage;
        _ = this.PhoneNumber;
        _ = this.Reason;
        _ = this.RecordType;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(AdditionalDataRequiredConverter))]
public enum AdditionalDataRequired
{
    Name,
    AuthorizedPersonName,
    AccountNumber,
    CustomerCode,
    Pin,
    AddressLine1,
    City,
    State,
    ZipCode,
    BillingPhoneNumber
}sealed class AdditionalDataRequiredConverter : JsonConverter<AdditionalDataRequired>
{
    public override AdditionalDataRequired Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "name"=>AdditionalDataRequired.Name,
            "authorized_person_name"=>AdditionalDataRequired.AuthorizedPersonName,
            "account_number"=>AdditionalDataRequired.AccountNumber,
            "customer_code"=>AdditionalDataRequired.CustomerCode,
            "pin"=>AdditionalDataRequired.Pin,
            "address_line_1"=>AdditionalDataRequired.AddressLine1,
            "city"=>AdditionalDataRequired.City,
            "state"=>AdditionalDataRequired.State,
            "zip_code"=>AdditionalDataRequired.ZipCode,
            "billing_phone_number"=>AdditionalDataRequired.BillingPhoneNumber,
            _ =>(AdditionalDataRequired)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdditionalDataRequired value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdditionalDataRequired.Name=>"name",
            AdditionalDataRequired.AuthorizedPersonName=>"authorized_person_name",
            AdditionalDataRequired.AccountNumber=>"account_number",
            AdditionalDataRequired.CustomerCode=>"customer_code",
            AdditionalDataRequired.Pin=>"pin",
            AdditionalDataRequired.AddressLine1=>"address_line_1",
            AdditionalDataRequired.City=>"city",
            AdditionalDataRequired.State=>"state",
            AdditionalDataRequired.ZipCode=>"zip_code",
            AdditionalDataRequired.BillingPhoneNumber=>"billing_phone_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}