using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

/// <summary>
/// Get all outbound voice profiles belonging to the user that match the given filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OutboundVoiceProfileListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[name][contains]
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
    /// Specifies the sort order for results. By default sorting direction is ascending.
    /// To have the results sorted in descending order add the &lt;code&gt;-&lt;/code&gt;
    /// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;name&lt;/code&gt;:
    /// sorts the result by the     &lt;code&gt;name&lt;/code&gt; field in ascending
    /// order.   &lt;/li&gt;
    ///
    /// <para>  &lt;li&gt;     &lt;code&gt;-name&lt;/code&gt;: sorts the result by
    /// the     &lt;code&gt;name&lt;/code&gt; field in descending order.   &lt;/li&gt;
    /// &lt;/ul&gt; &lt;br/&gt;</para>
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
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

    public OutboundVoiceProfileListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileListParams (
        OutboundVoiceProfileListParams outboundVoiceProfileListParams
    ) : base(outboundVoiceProfileListParams)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OutboundVoiceProfileListParams FromRawUnchecked(
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

    public virtual bool Equals(OutboundVoiceProfileListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/outbound_voice_profiles"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[name][contains]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Name filtering operations
    /// </summary>
    public Name? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Name>(
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
    { this.Name?.Validate(); }

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
/// Name filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Name, NameFromRaw>))]
public sealed record class Name : JsonModel
{
    /// <summary>
    /// Optional filter on outbound voice profile name.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public Name ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Name (Name name) : base(name)
    {  }
    #pragma warning restore CS8618

    public Name (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Name (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NameFromRaw.FromRawUnchecked"/>
    public static Name FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NameFromRaw : IFromRawJson<Name>
{
    /// <inheritdoc/>
    public Name FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Name.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. By default sorting direction is ascending.
/// To have the results sorted in descending order add the &lt;code&gt;-&lt;/code&gt;
/// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;name&lt;/code&gt;:
/// sorts the result by the     &lt;code&gt;name&lt;/code&gt; field in ascending
/// order.   &lt;/li&gt;
///
/// <para>  &lt;li&gt;     &lt;code&gt;-name&lt;/code&gt;: sorts the result by the
///     &lt;code&gt;name&lt;/code&gt; field in descending order.   &lt;/li&gt; &lt;/ul&gt; &lt;br/&gt;</para>
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    Enabled,
    EnabledDesc,
    CreatedAt,
    CreatedAtDesc,
    Name,
    NameDesc,
    ServicePlan,
    ServicePlanDesc,
    TrafficType,
    TrafficTypeDesc,
    UsagePaymentMethod,
    UsagePaymentMethodDesc
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
            "enabled"=>Sort.Enabled,
            "-enabled"=>Sort.EnabledDesc,
            "created_at"=>Sort.CreatedAt,
            "-created_at"=>Sort.CreatedAtDesc,
            "name"=>Sort.Name,
            "-name"=>Sort.NameDesc,
            "service_plan"=>Sort.ServicePlan,
            "-service_plan"=>Sort.ServicePlanDesc,
            "traffic_type"=>Sort.TrafficType,
            "-traffic_type"=>Sort.TrafficTypeDesc,
            "usage_payment_method"=>Sort.UsagePaymentMethod,
            "-usage_payment_method"=>Sort.UsagePaymentMethodDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.Enabled=>"enabled",
            Sort.EnabledDesc=>"-enabled",
            Sort.CreatedAt=>"created_at",
            Sort.CreatedAtDesc=>"-created_at",
            Sort.Name=>"name",
            Sort.NameDesc=>"-name",
            Sort.ServicePlan=>"service_plan",
            Sort.ServicePlanDesc=>"-service_plan",
            Sort.TrafficType=>"traffic_type",
            Sort.TrafficTypeDesc=>"-traffic_type",
            Sort.UsagePaymentMethod=>"usage_payment_method",
            Sort.UsagePaymentMethodDesc=>"-usage_payment_method",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}