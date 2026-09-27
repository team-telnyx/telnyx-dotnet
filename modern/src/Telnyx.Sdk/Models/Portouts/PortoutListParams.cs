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

namespace Telnyx.Sdk.Models.Portouts;

/// <summary>
/// Returns the portout requests according to filters
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PortoutListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[carrier_name],
    /// filter[country_code], filter[country_code_in], filter[foc_date], filter[inserted_at],
    /// filter[phone_number], filter[pon], filter[ported_out_at], filter[spid], filter[status],
    /// filter[status_in], filter[support_key]
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

    public PortoutListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutListParams (PortoutListParams portoutListParams) : base(
        portoutListParams
    )
    {  }
    #pragma warning restore CS8618

    public PortoutListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PortoutListParams FromRawUnchecked(
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

    public virtual bool Equals(PortoutListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/portouts"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[carrier_name],
/// filter[country_code], filter[country_code_in], filter[foc_date], filter[inserted_at],
/// filter[phone_number], filter[pon], filter[ported_out_at], filter[spid], filter[status],
/// filter[status_in], filter[support_key]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by new carrier name.
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

    /// <summary>
    /// Filter by 2-letter country code
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Filter by a list of 2-letter country codes
    /// </summary>
    public IReadOnlyList<string>? CountryCodeIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "country_code_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "country_code_in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by foc_date. Matches all portouts with the same date
    /// </summary>
    public System::DateTimeOffset? FocDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "foc_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foc_date", value);
        }
    }

    /// <summary>
    /// Filter by inserted_at date range using nested operations
    /// </summary>
    public InsertedAt? InsertedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InsertedAt>(
                "inserted_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inserted_at", value);
        }
    }

    /// <summary>
    /// Filter by a phone number on the portout. Matches all portouts with the phone number
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
    /// Filter by Port Order Number (PON).
    /// </summary>
    public string? Pon {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pon"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pon", value);
        }
    }

    /// <summary>
    /// Filter by ported_out_at date range using nested operations
    /// </summary>
    public PortedOutAt? PortedOutAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortedOutAt>(
                "ported_out_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ported_out_at", value);
        }
    }

    /// <summary>
    /// Filter by new carrier spid.
    /// </summary>
    public string? Spid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid", value);
        }
    }

    /// <summary>
    /// Filter by portout status.
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
    /// Filter by a list of portout statuses
    /// </summary>
    public IReadOnlyList<ApiEnum<string, StatusIn>>? StatusIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, StatusIn>>>(
                "status_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, StatusIn>>?>(
                "status_in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by the portout's support_key
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.CarrierName;
        _ = this.CountryCode;
        _ = this.CountryCodeIn;
        _ = this.FocDate;
        this.InsertedAt?.Validate();
        _ = this.PhoneNumber;
        _ = this.Pon;
        this.PortedOutAt?.Validate();
        _ = this.Spid;
        this.Status?.Validate();
        foreach (var item in this.StatusIn ?? [])
        {
            item.Validate();
        }
        _ = this.SupportKey;
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
/// Filter by inserted_at date range using nested operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InsertedAt, InsertedAtFromRaw>))]
public sealed record class InsertedAt : JsonModel
{
    /// <summary>
    /// Filter by inserted_at date greater than or equal.
    /// </summary>
    public System::DateTimeOffset? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Filter by inserted_at date less than or equal.
    /// </summary>
    public System::DateTimeOffset? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public InsertedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsertedAt (InsertedAt insertedAt) : base(insertedAt)
    {  }
    #pragma warning restore CS8618

    public InsertedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsertedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsertedAtFromRaw.FromRawUnchecked"/>
    public static InsertedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsertedAtFromRaw : IFromRawJson<InsertedAt>
{
    /// <inheritdoc/>
    public InsertedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsertedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by ported_out_at date range using nested operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortedOutAt, PortedOutAtFromRaw>))]
public sealed record class PortedOutAt : JsonModel
{
    /// <summary>
    /// Filter by ported_out_at date greater than or equal.
    /// </summary>
    public System::DateTimeOffset? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Filter by ported_out_at date less than or equal.
    /// </summary>
    public System::DateTimeOffset? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public PortedOutAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortedOutAt (PortedOutAt portedOutAt) : base(portedOutAt)
    {  }
    #pragma warning restore CS8618

    public PortedOutAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortedOutAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortedOutAtFromRaw.FromRawUnchecked"/>
    public static PortedOutAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortedOutAtFromRaw : IFromRawJson<PortedOutAt>
{
    /// <inheritdoc/>
    public PortedOutAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortedOutAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by portout status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Authorized, Ported, Rejected, RejectedPending, Canceled
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
            "pending"=>Status.Pending,
            "authorized"=>Status.Authorized,
            "ported"=>Status.Ported,
            "rejected"=>Status.Rejected,
            "rejected-pending"=>Status.RejectedPending,
            "canceled"=>Status.Canceled,
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
            Status.Authorized=>"authorized",
            Status.Ported=>"ported",
            Status.Rejected=>"rejected",
            Status.RejectedPending=>"rejected-pending",
            Status.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(StatusInConverter))]
public enum StatusIn
{
    Pending, Authorized, Ported, Rejected, RejectedPending, Canceled
}

sealed class StatusInConverter : JsonConverter<StatusIn>
{
    public override StatusIn Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>StatusIn.Pending,
            "authorized"=>StatusIn.Authorized,
            "ported"=>StatusIn.Ported,
            "rejected"=>StatusIn.Rejected,
            "rejected-pending"=>StatusIn.RejectedPending,
            "canceled"=>StatusIn.Canceled,
            _ =>(StatusIn)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StatusIn value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusIn.Pending=>"pending",
            StatusIn.Authorized=>"authorized",
            StatusIn.Ported=>"ported",
            StatusIn.Rejected=>"rejected",
            StatusIn.RejectedPending=>"rejected-pending",
            StatusIn.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}