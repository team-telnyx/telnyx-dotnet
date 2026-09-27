using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

/// <summary>
/// Starts generation of a CSV export for phone numbers matching the supplied filters.
/// The `csv_format` parameter selects the output format, and the response contains
/// the resulting download record.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CsvDownloadCreateParams : ParamsBase
{
    /// <summary>
    /// Which format to use when generating the CSV file. The default for backwards
    /// compatibility is 'V1'
    /// </summary>
    public ApiEnum<string, CsvFormat>? CsvFormat {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, CsvFormat>>(
                "csv_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("csv_format", value);
        }
    }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[has_bundle],
    /// filter[tag], filter[connection_id], filter[phone_number], filter[status],
    /// filter[voice.connection_name], filter[voice.usage_payment_method], filter[billing_group_id],
    /// filter[emergency_address_id], filter[customer_reference]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public CsvDownloadCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CsvDownloadCreateParams (
        CsvDownloadCreateParams csvDownloadCreateParams
    ) : base(csvDownloadCreateParams)
    {  }
    #pragma warning restore CS8618

    public CsvDownloadCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CsvDownloadCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CsvDownloadCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CsvDownloadCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/phone_numbers/csv_downloads"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Which format to use when generating the CSV file. The default for backwards compatibility
/// is 'V1'
/// </summary>
[JsonConverter(typeof(CsvFormatConverter))]
public enum CsvFormat
{
    V1, V2
}

sealed class CsvFormatConverter : JsonConverter<CsvFormat>
{
    public override CsvFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "V1"=>CsvFormat.V1, "V2"=>CsvFormat.V2, _ =>(CsvFormat)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, CsvFormat value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CsvFormat.V1=>"V1",
            CsvFormat.V2=>"V2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Consolidated filter parameter (deepObject style). Originally: filter[has_bundle],
/// filter[tag], filter[connection_id], filter[phone_number], filter[status], filter[voice.connection_name],
/// filter[voice.usage_payment_method], filter[billing_group_id], filter[emergency_address_id], filter[customer_reference]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by the billing_group_id associated with phone numbers. To filter to
    /// only phone numbers that have no billing group associated them, set the value
    /// of this filter to the string 'null'.
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
    /// Filter by connection_id.
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
    /// Filter numbers via the customer_reference set.
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
    /// Filter by the emergency_address_id associated with phone numbers. To filter
    /// only phone numbers that have no emergency address associated with them, set
    /// the value of this filter to the string 'null'.
    /// </summary>
    public string? EmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "emergency_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emergency_address_id", value);
        }
    }

    /// <summary>
    /// Filter by phone number that have bundles.
    /// </summary>
    public string? HasBundle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "has_bundle"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("has_bundle", value);
        }
    }

    /// <summary>
    /// Filter by phone number. Requires at least three digits.              Non-numerical
    /// characters will result in no values being returned.
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
    /// Filter by phone number status.
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
    /// Filter by phone number tags.
    /// </summary>
    public string? Tag {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tag"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tag", value);
        }
    }

    /// <summary>
    /// Filter by voice connection name pattern matching.
    /// </summary>
    public VoiceConnectionName? VoiceConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceConnectionName>(
                "voice.connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice.connection_name", value);
        }
    }

    /// <summary>
    /// Filter by usage_payment_method.
    /// </summary>
    public ApiEnum<string, VoiceUsagePaymentMethod>? VoiceUsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceUsagePaymentMethod>>(
                "voice.usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice.usage_payment_method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingGroupID;
        _ = this.ConnectionID;
        _ = this.CustomerReference;
        _ = this.EmergencyAddressID;
        _ = this.HasBundle;
        _ = this.PhoneNumber;
        this.Status?.Validate();
        _ = this.Tag;
        this.VoiceConnectionName?.Validate();
        this.VoiceUsagePaymentMethod?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by phone number status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    PurchasePending,
    PurchaseFailed,
    PortPending,
    Active,
    Deleted,
    PortFailed,
    EmergencyOnly,
    PortedOut,
    PortOutPending
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>Status.PurchasePending,
            "purchase-failed"=>Status.PurchaseFailed,
            "port-pending"=>Status.PortPending,
            "active"=>Status.Active,
            "deleted"=>Status.Deleted,
            "port-failed"=>Status.PortFailed,
            "emergency-only"=>Status.EmergencyOnly,
            "ported-out"=>Status.PortedOut,
            "port-out-pending"=>Status.PortOutPending,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.PurchasePending=>"purchase-pending",
            Status.PurchaseFailed=>"purchase-failed",
            Status.PortPending=>"port-pending",
            Status.Active=>"active",
            Status.Deleted=>"deleted",
            Status.PortFailed=>"port-failed",
            Status.EmergencyOnly=>"emergency-only",
            Status.PortedOut=>"ported-out",
            Status.PortOutPending=>"port-out-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by voice connection name pattern matching.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceConnectionName, VoiceConnectionNameFromRaw>))]
public sealed record class VoiceConnectionName : JsonModel
{
    /// <summary>
    /// Filter contains connection name. Requires at least three characters.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// Filter ends with connection name. Requires at least three characters.
    /// </summary>
    public string? EndsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ends_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ends_with", value);
        }
    }

    /// <summary>
    /// Filter by connection name.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <summary>
    /// Filter starts with connection name. Requires at least three characters.
    /// </summary>
    public string? StartsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "starts_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("starts_with", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.EndsWith;
        _ = this.Eq;
        _ = this.StartsWith;
    }

    public VoiceConnectionName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceConnectionName (VoiceConnectionName voiceConnectionName) : base(
        voiceConnectionName
    )
    {  }
    #pragma warning restore CS8618

    public VoiceConnectionName (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceConnectionName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceConnectionNameFromRaw.FromRawUnchecked"/>
    public static VoiceConnectionName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceConnectionNameFromRaw : IFromRawJson<VoiceConnectionName>
{
    /// <inheritdoc/>
    public VoiceConnectionName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceConnectionName.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by usage_payment_method.
/// </summary>
[JsonConverter(typeof(VoiceUsagePaymentMethodConverter))]
public enum VoiceUsagePaymentMethod
{
    PayPerMinute, Channel
}

sealed class VoiceUsagePaymentMethodConverter : JsonConverter<VoiceUsagePaymentMethod>
{
    public override VoiceUsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>VoiceUsagePaymentMethod.PayPerMinute,
            "channel"=>VoiceUsagePaymentMethod.Channel,
            _ =>(VoiceUsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceUsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceUsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            VoiceUsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}