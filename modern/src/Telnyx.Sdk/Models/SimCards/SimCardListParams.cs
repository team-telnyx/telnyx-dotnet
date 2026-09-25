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

namespace Telnyx.Sdk.Models.SimCards;

/// <summary>
/// Get all SIM cards belonging to the user that match the given filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SimCardListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter for SIM cards (deepObject style). Originally:
    /// filter[iccid], filter[msisdn], filter[status], filter[tags]
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

    /// <summary>
    /// A valid SIM card group ID.
    /// </summary>
    public string? FilterSimCardGroupID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[sim_card_group_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[sim_card_group_id]", value);
        }
    }

    /// <summary>
    /// It includes the associated SIM card group object in the response when present.
    /// </summary>
    public bool? IncludeSimCardGroup {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_sim_card_group"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_sim_card_group", value);
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
    /// Sorts SIM cards by the given field. Defaults to ascending order unless field
    /// is prefixed with a minus sign.
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

    public SimCardListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardListParams (SimCardListParams simCardListParams) : base(
        simCardListParams
    )
    {  }
    #pragma warning restore CS8618

    public SimCardListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SimCardListParams FromRawUnchecked(
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

    public virtual bool Equals(SimCardListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/sim_cards"
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
/// Consolidated filter parameter for SIM cards (deepObject style). Originally: filter[iccid],
/// filter[msisdn], filter[status], filter[tags]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// A search string to partially match for the SIM card's ICCID.
    /// </summary>
    public string? Iccid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "iccid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("iccid", value);
        }
    }

    /// <summary>
    /// A search string to match for the SIM card's MSISDN.
    /// </summary>
    public string? Msisdn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "msisdn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("msisdn", value);
        }
    }

    /// <summary>
    /// Filter by a SIM card's status.
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

    /// <summary>
    /// A list of SIM card tags to filter on.&lt;br/&gt;&lt;br/&gt;  If the SIM card
    /// contains &lt;b&gt;&lt;i&gt;all&lt;/i&gt;&lt;/b&gt; of the given &lt;code&gt;tags&lt;/code&gt;
    /// they will be found.&lt;br/&gt;&lt;br/&gt; For example, if the SIM cards have
    /// the following tags: &lt;ul&gt;   &lt;li&gt;&lt;code&gt;['customers', 'staff',
    /// 'test']&lt;/code&gt;   &lt;li&gt;&lt;code&gt;['test']&lt;/code&gt;&lt;/li&gt;
    ///   &lt;li&gt;&lt;code&gt;['customers']&lt;/code&gt;&lt;/li&gt; &lt;/ul&gt;
    /// Searching for &lt;code&gt;['customers', 'test']&lt;/code&gt; returns only
    /// the first because it's the only one with both tags.&lt;br/&gt; Searching for
    /// &lt;code&gt;test&lt;/code&gt; returns the first two SIMs, because both of
    /// them have such tag.&lt;br/&gt; Searching for &lt;code&gt;customers&lt;/code&gt;
    /// returns the first and last SIMs.&lt;br/&gt;
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Iccid;
        _ = this.Msisdn;
        foreach (var item in this.Status ?? [])
        {
            item.Validate();
        }
        _ = this.Tags;
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

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Enabled, Disabled, Standby, DataLimitExceeded, UnauthorizedImei
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
            "enabled"=>Status.Enabled,
            "disabled"=>Status.Disabled,
            "standby"=>Status.Standby,
            "data_limit_exceeded"=>Status.DataLimitExceeded,
            "unauthorized_imei"=>Status.UnauthorizedImei,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Enabled=>"enabled",
            Status.Disabled=>"disabled",
            Status.Standby=>"standby",
            Status.DataLimitExceeded=>"data_limit_exceeded",
            Status.UnauthorizedImei=>"unauthorized_imei",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sorts SIM cards by the given field. Defaults to ascending order unless field is
/// prefixed with a minus sign.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CurrentBillingPeriodConsumedDataAmount,
    DescCurrentBillingPeriodConsumedDataAmount
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
            "current_billing_period_consumed_data.amount"=>Sort.CurrentBillingPeriodConsumedDataAmount,
            "-current_billing_period_consumed_data.amount"=>Sort.DescCurrentBillingPeriodConsumedDataAmount,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CurrentBillingPeriodConsumedDataAmount=>"current_billing_period_consumed_data.amount",
            Sort.DescCurrentBillingPeriodConsumedDataAmount=>"-current_billing_period_consumed_data.amount",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}