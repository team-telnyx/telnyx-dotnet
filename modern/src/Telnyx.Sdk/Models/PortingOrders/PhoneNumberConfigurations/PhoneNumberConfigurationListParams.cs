using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

/// <summary>
/// Returns a list of phone number configurations paginated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberConfigurationListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[porting_order.status][in][],
    /// filter[porting_phone_number][in][], filter[user_bundle_id][in][]
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

    public PhoneNumberConfigurationListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberConfigurationListParams (
        PhoneNumberConfigurationListParams phoneNumberConfigurationListParams
    ) : base(phoneNumberConfigurationListParams)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberConfigurationListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberConfigurationListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberConfigurationListParams FromRawUnchecked(
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

    public virtual bool Equals(PhoneNumberConfigurationListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/porting_orders/phone_number_configurations"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[porting_order.status][in][],
/// filter[porting_phone_number][in][], filter[user_bundle_id][in][]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public PortingOrder? PortingOrder {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrder>(
                "porting_order"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order", value);
        }
    }

    /// <summary>
    /// Filter results by a list of porting phone number IDs
    /// </summary>
    public IReadOnlyList<string>? PortingPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "porting_phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "porting_phone_number",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter results by a list of user bundle IDs
    /// </summary>
    public IReadOnlyList<string>? UserBundleID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "user_bundle_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "user_bundle_id",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PortingOrder?.Validate();
        _ = this.PortingPhoneNumber;
        _ = this.UserBundleID;
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

[JsonConverter(typeof(JsonModelConverter<PortingOrder, PortingOrderFromRaw>))]
public sealed record class PortingOrder : JsonModel
{
    /// <summary>
    /// Filter results by specific porting order statuses
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Status>>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Status>>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Status>>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Status ?? [])
        {
            item.Validate();
        }
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

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    ActivationInProgress,
    CancelPending,
    Cancelled,
    Draft,
    Exception,
    FocDateConfirmed,
    InProcess,
    Ported,
    Submitted
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
            "activation-in-progress"=>Status.ActivationInProgress,
            "cancel-pending"=>Status.CancelPending,
            "cancelled"=>Status.Cancelled,
            "draft"=>Status.Draft,
            "exception"=>Status.Exception,
            "foc-date-confirmed"=>Status.FocDateConfirmed,
            "in-process"=>Status.InProcess,
            "ported"=>Status.Ported,
            "submitted"=>Status.Submitted,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.ActivationInProgress=>"activation-in-progress",
            Status.CancelPending=>"cancel-pending",
            Status.Cancelled=>"cancelled",
            Status.Draft=>"draft",
            Status.Exception=>"exception",
            Status.FocDateConfirmed=>"foc-date-confirmed",
            Status.InProcess=>"in-process",
            Status.Ported=>"ported",
            Status.Submitted=>"submitted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Consolidated sort parameter (deepObject style). Originally: sort[value]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sort, SortFromRaw>))]
public sealed record class Sort : JsonModel
{
    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// created_at in descending order.
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

    public Sort (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Sort (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SortFromRaw.FromRawUnchecked"/>
    public static Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SortFromRaw : IFromRawJson<Sort>
{
    /// <inheritdoc/>
    public Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Sort.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by created_at
/// in descending order.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    CreatedAt, CreatedAtDesc
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
            "created_at"=>Value.CreatedAt,
            "-created_at"=>Value.CreatedAtDesc,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.CreatedAt=>"created_at",
            Value.CreatedAtDesc=>"-created_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}