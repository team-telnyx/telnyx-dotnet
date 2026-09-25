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

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

/// <summary>
/// Generate and fetch messaging usage report synchronously. This endpoint will both
/// generate and fetch the messaging report over a specified time period. No polling
/// is necessary but the response may take up to a couple of minutes.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MdrUsageReportFetchSyncParams : ParamsBase
{
    /// <summary>
    /// Type of aggregation to apply to the results.
    /// </summary>
    public required ApiEnum<string, MdrUsageReportFetchSyncParamsAggregationType> AggregationType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, MdrUsageReportFetchSyncParamsAggregationType>>(
                "aggregation_type"
            );
        }
        init { this._rawQueryData.Set("aggregation_type", value); }
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
    /// Filter results by profile.
    /// </summary>
    public IReadOnlyList<string>? Profiles {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "profiles"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "profiles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public MdrUsageReportFetchSyncParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReportFetchSyncParams (
        MdrUsageReportFetchSyncParams mdrUsageReportFetchSyncParams
    ) : base(mdrUsageReportFetchSyncParams)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReportFetchSyncParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReportFetchSyncParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MdrUsageReportFetchSyncParams FromRawUnchecked(
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

    public virtual bool Equals(MdrUsageReportFetchSyncParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/reports/mdr_usage_reports/sync"
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
[JsonConverter(typeof(MdrUsageReportFetchSyncParamsAggregationTypeConverter))]
public enum MdrUsageReportFetchSyncParamsAggregationType
{
    NoAggregation, Profile, Tags
}

sealed class MdrUsageReportFetchSyncParamsAggregationTypeConverter : JsonConverter<MdrUsageReportFetchSyncParamsAggregationType>
{
    public override MdrUsageReportFetchSyncParamsAggregationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_AGGREGATION"=>MdrUsageReportFetchSyncParamsAggregationType.NoAggregation,
            "PROFILE"=>MdrUsageReportFetchSyncParamsAggregationType.Profile,
            "TAGS"=>MdrUsageReportFetchSyncParamsAggregationType.Tags,
            _ =>(MdrUsageReportFetchSyncParamsAggregationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MdrUsageReportFetchSyncParamsAggregationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MdrUsageReportFetchSyncParamsAggregationType.NoAggregation=>"NO_AGGREGATION",
            MdrUsageReportFetchSyncParamsAggregationType.Profile=>"PROFILE",
            MdrUsageReportFetchSyncParamsAggregationType.Tags=>"TAGS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}