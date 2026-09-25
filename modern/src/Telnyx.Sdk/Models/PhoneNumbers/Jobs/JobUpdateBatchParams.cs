using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers.Voice;

namespace Telnyx.Sdk.Models.PhoneNumbers.Jobs;

/// <summary>
/// Creates a new background job to update a batch of numbers. At most one thousand
/// numbers can be updated per API call. At least one of the updateable fields must
/// be submitted. IMPORTANT: You must either specify filters (using the filter parameters)
/// or specific phone numbers (using the phone_numbers parameter in the request body).
/// If you specify filters, ALL phone numbers that match the given filters (up to
/// 1000 at a time) will be updated. If you want to update only specific numbers,
/// you must use the phone_numbers parameter in the request body. When using the
/// phone_numbers parameter, ensure you follow the correct format as shown in the
/// example (either phone number IDs or phone numbers in E164 format).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class JobUpdateBatchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of phone number ids and/or phone numbers in E164 format to update. This
    /// parameter is required if no filter parameters are provided. If you want to
    /// update specific numbers rather than all numbers matching a filter, you must
    /// use this parameter. Each item must be either a valid phone number ID or a
    /// phone number in E164 format (e.g., '+13127367254').
    /// </summary>
    public required IReadOnlyList<string> PhoneNumbers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "phone_numbers"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "phone_numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[has_bundle],
    /// filter[tag], filter[connection_id], filter[phone_number], filter[status],
    /// filter[voice.connection_name], filter[voice.usage_payment_method], filter[billing_group_id],
    /// filter[emergency_address_id], filter[customer_reference]
    /// </summary>
    public JobUpdateBatchParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<JobUpdateBatchParamsFilter>(
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

    /// <summary>
    /// Identifies the billing group associated with the phone number.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Identifies the connection associated with the phone number.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Indicates whether to enable or disable the deletion lock on each phone number.
    /// When enabled, this prevents the phone number from being deleted via the API
    /// or Telnyx portal.
    /// </summary>
    public bool? DeletionLockEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "deletion_lock_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("deletion_lock_enabled", value);
        }
    }

    /// <summary>
    /// If someone attempts to port your phone number away from Telnyx and your phone
    /// number has an external PIN set, we will attempt to verify that you provided
    /// the correct external PIN to the winning carrier. Note that not all carriers
    /// cooperate with this security mechanism.
    /// </summary>
    public string? ExternalPin {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "external_pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("external_pin", value);
        }
    }

    /// <summary>
    /// Indicates whether to enable or disable HD Voice on each phone number. HD Voice
    /// is a paid feature and may not be available for all phone numbers, more details
    /// about it can be found in the Telnyx support documentation.
    /// </summary>
    public bool? HDVoiceEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "hd_voice_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hd_voice_enabled", value);
        }
    }

    /// <summary>
    /// A list of user-assigned tags to help organize phone numbers.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public UpdateVoiceSettings? Voice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UpdateVoiceSettings>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice", value);
        }
    }

    public JobUpdateBatchParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobUpdateBatchParams (
        JobUpdateBatchParams jobUpdateBatchParams
    ) : base(jobUpdateBatchParams)
    { this._rawBodyData = new(jobUpdateBatchParams._rawBodyData); }
    #pragma warning restore CS8618

    public JobUpdateBatchParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobUpdateBatchParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static JobUpdateBatchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(JobUpdateBatchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/phone_numbers/jobs/update_phone_numbers"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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
/// Consolidated filter parameter (deepObject style). Originally: filter[has_bundle],
/// filter[tag], filter[connection_id], filter[phone_number], filter[status], filter[voice.connection_name],
/// filter[voice.usage_payment_method], filter[billing_group_id], filter[emergency_address_id], filter[customer_reference]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobUpdateBatchParamsFilter, JobUpdateBatchParamsFilterFromRaw>))]
public sealed record class JobUpdateBatchParamsFilter : JsonModel
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
    public ApiEnum<string, JobUpdateBatchParamsFilterStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JobUpdateBatchParamsFilterStatus>>(
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
    public ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod>? VoiceUsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod>>(
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

    public JobUpdateBatchParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobUpdateBatchParamsFilter (
        JobUpdateBatchParamsFilter jobUpdateBatchParamsFilter
    ) : base(jobUpdateBatchParamsFilter)
    {  }
    #pragma warning restore CS8618

    public JobUpdateBatchParamsFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobUpdateBatchParamsFilter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobUpdateBatchParamsFilterFromRaw.FromRawUnchecked"/>
    public static JobUpdateBatchParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobUpdateBatchParamsFilterFromRaw : IFromRawJson<JobUpdateBatchParamsFilter>
{
    /// <inheritdoc/>
    public JobUpdateBatchParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobUpdateBatchParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by phone number status.
/// </summary>
[JsonConverter(typeof(JobUpdateBatchParamsFilterStatusConverter))]
public enum JobUpdateBatchParamsFilterStatus
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

sealed class JobUpdateBatchParamsFilterStatusConverter : JsonConverter<JobUpdateBatchParamsFilterStatus>
{
    public override JobUpdateBatchParamsFilterStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "purchase-pending"=>JobUpdateBatchParamsFilterStatus.PurchasePending,
            "purchase-failed"=>JobUpdateBatchParamsFilterStatus.PurchaseFailed,
            "port-pending"=>JobUpdateBatchParamsFilterStatus.PortPending,
            "active"=>JobUpdateBatchParamsFilterStatus.Active,
            "deleted"=>JobUpdateBatchParamsFilterStatus.Deleted,
            "port-failed"=>JobUpdateBatchParamsFilterStatus.PortFailed,
            "emergency-only"=>JobUpdateBatchParamsFilterStatus.EmergencyOnly,
            "ported-out"=>JobUpdateBatchParamsFilterStatus.PortedOut,
            "port-out-pending"=>JobUpdateBatchParamsFilterStatus.PortOutPending,
            _ =>(JobUpdateBatchParamsFilterStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JobUpdateBatchParamsFilterStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            JobUpdateBatchParamsFilterStatus.PurchasePending=>"purchase-pending",
            JobUpdateBatchParamsFilterStatus.PurchaseFailed=>"purchase-failed",
            JobUpdateBatchParamsFilterStatus.PortPending=>"port-pending",
            JobUpdateBatchParamsFilterStatus.Active=>"active",
            JobUpdateBatchParamsFilterStatus.Deleted=>"deleted",
            JobUpdateBatchParamsFilterStatus.PortFailed=>"port-failed",
            JobUpdateBatchParamsFilterStatus.EmergencyOnly=>"emergency-only",
            JobUpdateBatchParamsFilterStatus.PortedOut=>"ported-out",
            JobUpdateBatchParamsFilterStatus.PortOutPending=>"port-out-pending",
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
[JsonConverter(typeof(global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethodConverter))]
public enum VoiceUsagePaymentMethod
{
    PayPerMinute, Channel
}

sealed class VoiceUsagePaymentMethodConverter : JsonConverter<global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod>
{
    public override global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod.PayPerMinute,
            "channel"=>global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod.Channel,
            _ =>(global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            global::Telnyx.Sdk.Models.PhoneNumbers.Jobs.VoiceUsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}