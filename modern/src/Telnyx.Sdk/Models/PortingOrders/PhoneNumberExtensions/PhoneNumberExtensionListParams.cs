using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

/// <summary>
/// Returns a list of all phone number extensions of a porting order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberExtensionListParams : ParamsBase
{
    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[porting_phone_number_id]
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

    public PhoneNumberExtensionListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberExtensionListParams (
        PhoneNumberExtensionListParams phoneNumberExtensionListParams
    ) : base(phoneNumberExtensionListParams)
    { this.PortingOrderID = phoneNumberExtensionListParams.PortingOrderID; }
    #pragma warning restore CS8618

    public PhoneNumberExtensionListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberExtensionListParams (
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
    public static PhoneNumberExtensionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
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
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["PortingOrderID"] = JsonSerializer.SerializeToElement(this.PortingOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PhoneNumberExtensionListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/phone_number_extensions",
            EncodePathSegment(this.PortingOrderID))
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
/// Consolidated filter parameter (deepObject style). Originally: filter[porting_phone_number_id]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter results by porting phone number id
    /// </summary>
    public string? PortingPhoneNumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_phone_number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_phone_number_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.PortingPhoneNumberID; }

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