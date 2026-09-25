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

namespace Telnyx.Sdk.Models.Requirements;

/// <summary>
/// List all requirements with filtering, sorting, and pagination
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RequirementListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter for requirements (deepObject style). Originally:
    /// filter[country_code], filter[phone_number_type], filter[action]
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
    /// Consolidated sort parameter for requirements (deepObject style). Originally: sort[]
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Sort>>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Sort>>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Sort>>?>(
                "sort",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by requirement version number. When omitted, returns the currently-active version.
    /// </summary>
    public long? Version {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("version", value);
        }
    }

    public RequirementListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementListParams (
        RequirementListParams requirementListParams
    ) : base(requirementListParams)
    {  }
    #pragma warning restore CS8618

    public RequirementListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RequirementListParams FromRawUnchecked(
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

    public virtual bool Equals(RequirementListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/requirements"
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
/// Consolidated filter parameter for requirements (deepObject style). Originally:
/// filter[country_code], filter[phone_number_type], filter[action]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filters requirements to those applying to a specific action.
    /// </summary>
    public ApiEnum<string, Action>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Action>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <summary>
    /// Filters results to those applying to a 2-character (ISO 3166-1 alpha-2) country code
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
    /// Filters results to those applying to a specific phone_number_type
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        _ = this.CountryCode;
        this.PhoneNumberType?.Validate();
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
/// Filters requirements to those applying to a specific action.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    BrandedCalling, Ordering, Porting
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "branded_calling"=>Action.BrandedCalling,
            "ordering"=>Action.Ordering,
            "porting"=>Action.Porting,
            _ =>(Action)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Action value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Action.BrandedCalling=>"branded_calling",
            Action.Ordering=>"ordering",
            Action.Porting=>"porting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filters results to those applying to a specific phone_number_type
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local, National, TollFree
}

sealed class PhoneNumberTypeConverter : JsonConverter<PhoneNumberType>
{
    public override PhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>PhoneNumberType.Local,
            "national"=>PhoneNumberType.National,
            "toll_free"=>PhoneNumberType.TollFree,
            _ =>(PhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberType.Local=>"local",
            PhoneNumberType.National=>"national",
            PhoneNumberType.TollFree=>"toll_free",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt,
    UpdatedAt,
    CountryCode,
    PhoneNumberType,
    CreatedAtDesc,
    UpdatedAtDesc,
    CountryCodeDesc,
    PhoneNumberTypeDesc
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>Sort.CreatedAt,
            "updated_at"=>Sort.UpdatedAt,
            "country_code"=>Sort.CountryCode,
            "phone_number_type"=>Sort.PhoneNumberType,
            "-created_at"=>Sort.CreatedAtDesc,
            "-updated_at"=>Sort.UpdatedAtDesc,
            "-country_code"=>Sort.CountryCodeDesc,
            "-phone_number_type"=>Sort.PhoneNumberTypeDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.UpdatedAt=>"updated_at",
            Sort.CountryCode=>"country_code",
            Sort.PhoneNumberType=>"phone_number_type",
            Sort.CreatedAtDesc=>"-created_at",
            Sort.UpdatedAtDesc=>"-updated_at",
            Sort.CountryCodeDesc=>"-country_code",
            Sort.PhoneNumberTypeDesc=>"-phone_number_type",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}