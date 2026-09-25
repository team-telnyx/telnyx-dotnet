using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using PortingPhoneNumbers = Telnyx.Sdk.Models.PortingPhoneNumbers;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

/// <summary>
/// Returns a list of all phone number blocks of a porting order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberBlockListParams : ParamsBase
{
    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[porting_order_id],
    /// filter[support_key], filter[status], filter[phone_number], filter[activation_status], filter[portability_status]
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

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// Consolidated sort parameter (deepObject style). Originally: sort[value]
    /// </summary>
    public Sort? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Sort>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public PhoneNumberBlockListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBlockListParams (
        PhoneNumberBlockListParams phoneNumberBlockListParams
    ) : base(phoneNumberBlockListParams)
    { this.PortingOrderID = phoneNumberBlockListParams.PortingOrderID; }
    #pragma warning restore CS8618

    public PhoneNumberBlockListParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBlockListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string portingOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PortingOrderID = portingOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberBlockListParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string portingOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            portingOrderID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["PortingOrderID"] = JsonSerializer.SerializeToElement(this.PortingOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PhoneNumberBlockListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PortingOrderID?.Equals(other.PortingOrderID) ?? other.PortingOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/phone_number_blocks",
            this.PortingOrderID)
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
/// Consolidated filter parameter (deepObject style). Originally: filter[porting_order_id],
/// filter[support_key], filter[status], filter[phone_number], filter[activation_status], filter[portability_status]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter results by activation status
    /// </summary>
    public ApiEnum<string, PortingPhoneNumbers::PortingOrderActivationStatus>? ActivationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingPhoneNumbers::PortingOrderActivationStatus>>(
                "activation_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activation_status", value);
        }
    }

    /// <summary>
    /// Filter results by a list of phone numbers
    /// </summary>
    public Generic::IReadOnlyList<string>? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phone_number",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter results by portability status
    /// </summary>
    public ApiEnum<string, PortabilityStatus>? PortabilityStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortabilityStatus>>(
                "portability_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portability_status", value);
        }
    }

    /// <summary>
    /// Filter results by a list of porting order ids
    /// </summary>
    public Generic::IReadOnlyList<string>? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "porting_order_id",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter porting orders by status(es). Originally: filter[status], filter[status][in][]
    /// </summary>
    public Status? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Status>(
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
    /// Filter results by support key(s). Originally: filter[support_key][eq], filter[support_key][in][]
    /// </summary>
    public SupportKey? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SupportKey>(
                "support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("support_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ActivationStatus?.Validate();
        _ = this.PhoneNumber;
        this.PortabilityStatus?.Validate();
        _ = this.PortingOrderID;
        this.Status?.Validate();
        this.SupportKey?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter results by portability status
/// </summary>
[JsonConverter(typeof(PortabilityStatusConverter))]
public enum PortabilityStatus
{
    Pending, Confirmed, Provisional
}

sealed class PortabilityStatusConverter : JsonConverter<PortabilityStatus>
{
    public override PortabilityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PortabilityStatus.Pending,
            "confirmed"=>PortabilityStatus.Confirmed,
            "provisional"=>PortabilityStatus.Provisional,
            _ =>(PortabilityStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortabilityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortabilityStatus.Pending=>"pending",
            PortabilityStatus.Confirmed=>"confirmed",
            PortabilityStatus.Provisional=>"provisional",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter porting orders by status(es). Originally: filter[status], filter[status][in][]
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public record class Status : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Status (
        ApiEnum<string, PortingOrderMultipleStatus> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Status (
        Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Status (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of PortingOrderMultipleStatus>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPortingOrderMultiple(out var value)) {
///     // `value` is of type `ApiEnum&lt;string, PortingOrderMultipleStatus&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPortingOrderMultiple(
        [NotNullWhen(true)] out ApiEnum<string, PortingOrderMultipleStatus>? value
    )
    {
        value =this.Value as ApiEnum<string, PortingOrderMultipleStatus> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>ApiEnum&lt;string, PortingOrderStatusItem&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPortingOrderStatusList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;ApiEnum&lt;string, PortingOrderStatusItem&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPortingOrderStatusList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (ApiEnum&lt;string, PortingOrderMultipleStatus&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;ApiEnum&lt;string, PortingOrderStatusItem&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ApiEnum<string, PortingOrderMultipleStatus>> portingOrderMultiple,
        System::Action<Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>>> portingOrderStatusList
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, PortingOrderMultipleStatus> value:
                portingOrderMultiple(value);
                break;
            case Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>> value:
                portingOrderStatusList(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Status");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (ApiEnum&lt;string, PortingOrderMultipleStatus&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;ApiEnum&lt;string, PortingOrderStatusItem&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ApiEnum<string, PortingOrderMultipleStatus>, T> portingOrderMultiple,
        System::Func<Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>>, T> portingOrderStatusList
    )
    {
        return this.Value switch
        {
            ApiEnum<string, PortingOrderMultipleStatus> value=>portingOrderMultiple(value),
            Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>> value=>portingOrderStatusList(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Status")
        } ;
    }

    public static implicit operator Status (
        ApiEnum<string, PortingOrderMultipleStatus> value
    )=> new(value) ;

    public static implicit operator Status (
        PortingOrderMultipleStatus value
    )=> new(value) ;

    public static implicit operator Status (
        Generic::List<ApiEnum<string, PortingOrderStatusItem>> value
    )=> new((Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>>)value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Status");
        }
        this.Switch((portingOrderMultiple) => portingOrderMultiple.Validate(),
        (portingOrderStatusList) => {foreach (var item in portingOrderStatusList)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(Status? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            ApiEnum<string, PortingOrderMultipleStatus> _=>0,
            Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>> _=>1,
            _ =>-1
        } ;
    }
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PortingOrderMultipleStatus>>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<ApiEnum<string, PortingOrderStatusItem>>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Filter by single status
/// </summary>
[JsonConverter(typeof(PortingOrderMultipleStatusConverter))]
public enum PortingOrderMultipleStatus
{
    Draft,
    InProcess,
    Submitted,
    Exception,
    FocDateConfirmed,
    CancelPending,
    Ported,
    Cancelled
}

sealed class PortingOrderMultipleStatusConverter : JsonConverter<PortingOrderMultipleStatus>
{
    public override PortingOrderMultipleStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>PortingOrderMultipleStatus.Draft,
            "in-process"=>PortingOrderMultipleStatus.InProcess,
            "submitted"=>PortingOrderMultipleStatus.Submitted,
            "exception"=>PortingOrderMultipleStatus.Exception,
            "foc-date-confirmed"=>PortingOrderMultipleStatus.FocDateConfirmed,
            "cancel-pending"=>PortingOrderMultipleStatus.CancelPending,
            "ported"=>PortingOrderMultipleStatus.Ported,
            "cancelled"=>PortingOrderMultipleStatus.Cancelled,
            _ =>(PortingOrderMultipleStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingOrderMultipleStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingOrderMultipleStatus.Draft=>"draft",
            PortingOrderMultipleStatus.InProcess=>"in-process",
            PortingOrderMultipleStatus.Submitted=>"submitted",
            PortingOrderMultipleStatus.Exception=>"exception",
            PortingOrderMultipleStatus.FocDateConfirmed=>"foc-date-confirmed",
            PortingOrderMultipleStatus.CancelPending=>"cancel-pending",
            PortingOrderMultipleStatus.Ported=>"ported",
            PortingOrderMultipleStatus.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(PortingOrderStatusItemConverter))]
public enum PortingOrderStatusItem
{
    Draft,
    InProcess,
    Submitted,
    Exception,
    FocDateConfirmed,
    CancelPending,
    Ported,
    Cancelled
}

sealed class PortingOrderStatusItemConverter : JsonConverter<PortingOrderStatusItem>
{
    public override PortingOrderStatusItem Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>PortingOrderStatusItem.Draft,
            "in-process"=>PortingOrderStatusItem.InProcess,
            "submitted"=>PortingOrderStatusItem.Submitted,
            "exception"=>PortingOrderStatusItem.Exception,
            "foc-date-confirmed"=>PortingOrderStatusItem.FocDateConfirmed,
            "cancel-pending"=>PortingOrderStatusItem.CancelPending,
            "ported"=>PortingOrderStatusItem.Ported,
            "cancelled"=>PortingOrderStatusItem.Cancelled,
            _ =>(PortingOrderStatusItem)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingOrderStatusItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingOrderStatusItem.Draft=>"draft",
            PortingOrderStatusItem.InProcess=>"in-process",
            PortingOrderStatusItem.Submitted=>"submitted",
            PortingOrderStatusItem.Exception=>"exception",
            PortingOrderStatusItem.FocDateConfirmed=>"foc-date-confirmed",
            PortingOrderStatusItem.CancelPending=>"cancel-pending",
            PortingOrderStatusItem.Ported=>"ported",
            PortingOrderStatusItem.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter results by support key(s). Originally: filter[support_key][eq], filter[support_key][in][]
/// </summary>
[JsonConverter(typeof(SupportKeyConverter))]
public record class SupportKey : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public SupportKey (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SupportKey (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public SupportKey (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of SupportKey");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of SupportKey")
        } ;
    }

    public static implicit operator SupportKey (string value)=> new(value) ;

    public static implicit operator SupportKey (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of SupportKey");
        }
    }

    public virtual bool Equals(SupportKey? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { string _=>0, Generic::IReadOnlyList<string> _=>1, _ =>-1 } ;
    }
}

sealed class SupportKeyConverter : JsonConverter<SupportKey>
{
    public override SupportKey? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, SupportKey value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Consolidated sort parameter (deepObject style). Originally: sort[value]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sort, SortFromRaw>))]
public sealed record class Sort : JsonModel
{
    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// created_at in descending order
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
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
    { this.Value?.Validate(); }

    public Sort ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sort (Sort sort) : base(sort)
    {  }
    #pragma warning restore CS8618

    public Sort (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Sort (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SortFromRaw.FromRawUnchecked"/>
    public static Sort FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SortFromRaw : IFromRawJson<Sort>
{
    /// <inheritdoc/>
    public Sort FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Sort.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by created_at
/// in descending order
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    CreatedAtDesc, CreatedAt
}

sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "-created_at"=>Value.CreatedAtDesc,
            "created_at"=>Value.CreatedAt,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.CreatedAtDesc=>"-created_at",
            Value.CreatedAt=>"created_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}