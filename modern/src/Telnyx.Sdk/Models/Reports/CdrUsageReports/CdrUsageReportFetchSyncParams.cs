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

namespace Telnyx.Sdk.Models.Reports.CdrUsageReports;

/// <summary>
/// Generate and fetch voice usage report synchronously. This endpoint will both generate
/// and fetch the voice report over a specified time period. No polling is necessary
/// but the response may take up to a couple of minutes.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CdrUsageReportFetchSyncParams : ParamsBase
{
    /// <summary>
    /// Type of aggregation to apply to the results.
    /// </summary>
    public required ApiEnum<string, AggregationType> AggregationType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, AggregationType>>(
                "aggregation_type"
            );
        }
        init { this._rawQueryData.Set("aggregation_type", value); }
    }

    /// <summary>
    /// Filter results by product breakdown.
    /// </summary>
    public required ApiEnum<string, ProductBreakdown> ProductBreakdown {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, ProductBreakdown>>(
                "product_breakdown"
            );
        }
        init { this._rawQueryData.Set("product_breakdown", value); }
    }

    /// <summary>
    /// Filter results by connection.
    /// </summary>
    public IReadOnlyList<double>? Connections {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<double>>(
                "connections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<double>?>(
                "connections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// End of the date range filter (inclusive, ISO 8601).
    /// </summary>
    public System::DateTimeOffset? EndDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "end_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("end_date", value);
        }
    }

    /// <summary>
    /// Start of the date range filter (inclusive, ISO 8601).
    /// </summary>
    public System::DateTimeOffset? StartDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "start_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("start_date", value);
        }
    }

    public CdrUsageReportFetchSyncParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CdrUsageReportFetchSyncParams (
        CdrUsageReportFetchSyncParams cdrUsageReportFetchSyncParams
    ) : base(cdrUsageReportFetchSyncParams)
    {  }
    #pragma warning restore CS8618

    public CdrUsageReportFetchSyncParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CdrUsageReportFetchSyncParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CdrUsageReportFetchSyncParams FromRawUnchecked(
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

    public virtual bool Equals(CdrUsageReportFetchSyncParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/reports/cdr_usage_reports/sync"
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
/// Type of aggregation to apply to the results.
/// </summary>
[JsonConverter(typeof(AggregationTypeConverter))]
public enum AggregationType
{
    NoAggregation, Connection, Tag, BillingGroup
}

sealed class AggregationTypeConverter : JsonConverter<AggregationType>
{
    public override AggregationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_AGGREGATION"=>AggregationType.NoAggregation,
            "CONNECTION"=>AggregationType.Connection,
            "TAG"=>AggregationType.Tag,
            "BILLING_GROUP"=>AggregationType.BillingGroup,
            _ =>(AggregationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AggregationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AggregationType.NoAggregation=>"NO_AGGREGATION",
            AggregationType.Connection=>"CONNECTION",
            AggregationType.Tag=>"TAG",
            AggregationType.BillingGroup=>"BILLING_GROUP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter results by product breakdown.
/// </summary>
[JsonConverter(typeof(ProductBreakdownConverter))]
public enum ProductBreakdown
{
    NoBreakdown, DidVsTollFree, Country, DidVsTollFreePerCountry
}

sealed class ProductBreakdownConverter : JsonConverter<ProductBreakdown>
{
    public override ProductBreakdown Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_BREAKDOWN"=>ProductBreakdown.NoBreakdown,
            "DID_VS_TOLL_FREE"=>ProductBreakdown.DidVsTollFree,
            "COUNTRY"=>ProductBreakdown.Country,
            "DID_VS_TOLL_FREE_PER_COUNTRY"=>ProductBreakdown.DidVsTollFreePerCountry,
            _ =>(ProductBreakdown)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductBreakdown value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ProductBreakdown.NoBreakdown=>"NO_BREAKDOWN",
            ProductBreakdown.DidVsTollFree=>"DID_VS_TOLL_FREE",
            ProductBreakdown.Country=>"COUNTRY",
            ProductBreakdown.DidVsTollFreePerCountry=>"DID_VS_TOLL_FREE_PER_COUNTRY",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}