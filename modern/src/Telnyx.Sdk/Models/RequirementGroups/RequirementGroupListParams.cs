using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.RequirementGroups;

/// <summary>
/// Returns regulatory requirement groups for the account. Results can be filtered
/// by country, number type, action, approval status, and customer reference.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RequirementGroupListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[country_code],
    /// filter[phone_number_type], filter[action], filter[status], filter[customer_reference]
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

    public RequirementGroupListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementGroupListParams (
        RequirementGroupListParams requirementGroupListParams
    ) : base(requirementGroupListParams)
    {  }
    #pragma warning restore CS8618

    public RequirementGroupListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementGroupListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RequirementGroupListParams FromRawUnchecked(
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

    public virtual bool Equals(RequirementGroupListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/requirement_groups"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[country_code],
/// filter[phone_number_type], filter[action], filter[status], filter[customer_reference]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter requirement groups by action type
    /// </summary>
    public ApiEnum<string, FilterAction>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FilterAction>>(
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
    /// Filter requirement groups by country code (iso alpha 2)
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
    /// Filter requirement groups by customer reference
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
    /// Filter requirement groups by phone number type.
    /// </summary>
    public ApiEnum<string, FilterPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FilterPhoneNumberType>>(
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

    /// <summary>
    /// Filter requirement groups by status
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        _ = this.CountryCode;
        _ = this.CustomerReference;
        this.PhoneNumberType?.Validate();
        this.Status?.Validate();
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
/// Filter requirement groups by action type
/// </summary>
[JsonConverter(typeof(FilterActionConverter))]
public enum FilterAction
{
    Ordering, Porting, Action
}

sealed class FilterActionConverter : JsonConverter<FilterAction>
{
    public override FilterAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ordering"=>FilterAction.Ordering,
            "porting"=>FilterAction.Porting,
            "action"=>FilterAction.Action,
            _ =>(FilterAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterAction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterAction.Ordering=>"ordering",
            FilterAction.Porting=>"porting",
            FilterAction.Action=>"action",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter requirement groups by phone number type.
/// </summary>
[JsonConverter(typeof(FilterPhoneNumberTypeConverter))]
public enum FilterPhoneNumberType
{
    Local, TollFree, Mobile, National, SharedCost
}

sealed class FilterPhoneNumberTypeConverter : JsonConverter<FilterPhoneNumberType>
{
    public override FilterPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>FilterPhoneNumberType.Local,
            "toll_free"=>FilterPhoneNumberType.TollFree,
            "mobile"=>FilterPhoneNumberType.Mobile,
            "national"=>FilterPhoneNumberType.National,
            "shared_cost"=>FilterPhoneNumberType.SharedCost,
            _ =>(FilterPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterPhoneNumberType.Local=>"local",
            FilterPhoneNumberType.TollFree=>"toll_free",
            FilterPhoneNumberType.Mobile=>"mobile",
            FilterPhoneNumberType.National=>"national",
            FilterPhoneNumberType.SharedCost=>"shared_cost",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter requirement groups by status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Approved, Unapproved, PendingApproval, Declined, Expired
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
            "approved"=>Status.Approved,
            "unapproved"=>Status.Unapproved,
            "pending-approval"=>Status.PendingApproval,
            "declined"=>Status.Declined,
            "expired"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Approved=>"approved",
            Status.Unapproved=>"unapproved",
            Status.PendingApproval=>"pending-approval",
            Status.Declined=>"declined",
            Status.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}