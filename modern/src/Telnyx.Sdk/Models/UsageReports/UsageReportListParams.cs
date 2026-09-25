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

namespace Telnyx.Sdk.Models.UsageReports;

/// <summary>
/// Get Telnyx usage data by product, broken out by the specified dimensions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageReportListParams : ParamsBase
{
    /// <summary>
    /// Breakout by specified product dimensions
    /// </summary>
    public required IReadOnlyList<string> Dimensions {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<ImmutableArray<string>>(
                "dimensions"
            );
        }
        init {
            this._rawQueryData.Set<ImmutableArray<string>>(
                "dimensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Specified product usage values
    /// </summary>
    public required IReadOnlyList<string> Metrics {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<ImmutableArray<string>>(
                "metrics"
            );
        }
        init {
            this._rawQueryData.Set<ImmutableArray<string>>(
                "metrics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Telnyx product
    /// </summary>
    public required string Product {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "product"
            );
        }
        init { this._rawQueryData.Set("product", value); }
    }

    /// <summary>
    /// A more user-friendly way to specify the timespan you want to filter by. More
    /// options can be found in the Telnyx API Reference docs.
    /// </summary>
    public string? DateRange {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "date_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("date_range", value);
        }
    }

    /// <summary>
    /// The end date for the time range you are interested in. The maximum time range
    /// is 31 days. Format: YYYY-MM-DDTHH:mm:ssZ
    /// </summary>
    public string? EndDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
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
    /// Filter records on dimensions
    /// </summary>
    public string? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
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
    /// Specify the response format (csv or json). JSON is returned by default, even
    /// if not specified.
    /// </summary>
    public ApiEnum<string, Format>? Format {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("format", value);
        }
    }

    /// <summary>
    /// Return the aggregations for all Managed Accounts under the user making the request.
    /// </summary>
    public bool? ManagedAccounts {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "managed_accounts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("managed_accounts", value);
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
    /// Specifies the sort order for results
    /// </summary>
    public IReadOnlyList<string>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "sort",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The start date for the time range you are interested in. The maximum time
    /// range is 31 days. Format: YYYY-MM-DDTHH:mm:ssZ
    /// </summary>
    public string? StartDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
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

    /// <summary>
    /// Authenticates the request with your Telnyx API V2 KEY
    /// </summary>
    public string? AuthorizationBearer {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "authorization_bearer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("authorization_bearer", value);
        }
    }

    public UsageReportListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportListParams (
        UsageReportListParams usageReportListParams
    ) : base(usageReportListParams)
    {  }
    #pragma warning restore CS8618

    public UsageReportListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UsageReportListParams FromRawUnchecked(
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

    public virtual bool Equals(UsageReportListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/usage_reports"
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
/// Specify the response format (csv or json). JSON is returned by default, even if
/// not specified.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Csv, Json
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "csv"=>Format.Csv, "json"=>Format.Json, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Csv=>"csv",
            Format.Json=>"json",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}