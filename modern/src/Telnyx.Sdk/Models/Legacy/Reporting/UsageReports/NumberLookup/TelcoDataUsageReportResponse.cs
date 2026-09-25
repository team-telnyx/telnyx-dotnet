using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

/// <summary>
/// Telco data usage report response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelcoDataUsageReportResponse, TelcoDataUsageReportResponseFromRaw>))]
public sealed record class TelcoDataUsageReportResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the report
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Type of aggregation used in the report
    /// </summary>
    public string? AggregationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "aggregation_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("aggregation_type", value);
        }
    }

    /// <summary>
    /// Timestamp when the report was created
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// End date of the report period
    /// </summary>
    public string? EndDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_date", value);
        }
    }

    /// <summary>
    /// List of managed account IDs included in the report
    /// </summary>
    public IReadOnlyList<string>? ManagedAccounts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "managed_accounts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "managed_accounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Record type identifier
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// URL to download the complete report
    /// </summary>
    public string? ReportUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "report_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("report_url", value);
        }
    }

    /// <summary>
    /// Array of usage records
    /// </summary>
    public IReadOnlyList<TelcoDataUsageRecord>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TelcoDataUsageRecord>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TelcoDataUsageRecord>?>(
                "result",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start date of the report period
    /// </summary>
    public string? StartDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_date", value);
        }
    }

    /// <summary>
    /// Current status of the report
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Timestamp when the report was last updated
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AggregationType;
        _ = this.CreatedAt;
        _ = this.EndDate;
        _ = this.ManagedAccounts;
        _ = this.RecordType;
        _ = this.ReportUrl;
        foreach (var item in this.Result ?? [])
        {
            item.Validate();
        }
        _ = this.StartDate;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public TelcoDataUsageReportResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelcoDataUsageReportResponse (
        TelcoDataUsageReportResponse telcoDataUsageReportResponse
    ) : base(telcoDataUsageReportResponse)
    {  }
    #pragma warning restore CS8618

    public TelcoDataUsageReportResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelcoDataUsageReportResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelcoDataUsageReportResponseFromRaw.FromRawUnchecked"/>
    public static TelcoDataUsageReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelcoDataUsageReportResponseFromRaw : IFromRawJson<TelcoDataUsageReportResponse>
{
    /// <inheritdoc/>
    public TelcoDataUsageReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelcoDataUsageReportResponse.FromRawUnchecked(rawData);
}