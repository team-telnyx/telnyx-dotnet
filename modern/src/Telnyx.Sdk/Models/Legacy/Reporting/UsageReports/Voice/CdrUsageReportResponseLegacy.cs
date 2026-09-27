using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Voice;

/// <summary>
/// Legacy V2 CDR usage report response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CdrUsageReportResponseLegacy, CdrUsageReportResponseLegacyFromRaw>))]
public sealed record class CdrUsageReportResponseLegacy : JsonModel
{
    /// <summary>
    /// Identifies the resource
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
    /// Aggregation type: All = 0, By Connections = 1, By Tags = 2, By Billing Group
    /// = 3
    /// </summary>
    public int? AggregationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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

    public IReadOnlyList<string>? Connections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "connections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "connections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public DateTimeOffset? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    /// <summary>
    /// Product breakdown type: No breakdown = 0, DID vs Toll-free = 1, Country =
    /// 2, DID vs Toll-free per Country = 3
    /// </summary>
    public int? ProductBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "product_breakdown"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product_breakdown", value);
        }
    }

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

    public IReadOnlyDictionary<string, JsonElement>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "result",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// Status of the report: Pending = 1, Complete = 2, Failed = 3, Expired = 4
    /// </summary>
    public int? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
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
        _ = this.Connections;
        _ = this.CreatedAt;
        _ = this.EndTime;
        _ = this.ProductBreakdown;
        _ = this.RecordType;
        _ = this.ReportUrl;
        _ = this.Result;
        _ = this.StartTime;
        _ = this.Status;
        _ = this.UpdatedAt;
    }

    public CdrUsageReportResponseLegacy ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CdrUsageReportResponseLegacy (
        CdrUsageReportResponseLegacy cdrUsageReportResponseLegacy
    ) : base(cdrUsageReportResponseLegacy)
    {  }
    #pragma warning restore CS8618

    public CdrUsageReportResponseLegacy (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CdrUsageReportResponseLegacy (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CdrUsageReportResponseLegacyFromRaw.FromRawUnchecked"/>
    public static CdrUsageReportResponseLegacy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CdrUsageReportResponseLegacyFromRaw : IFromRawJson<CdrUsageReportResponseLegacy>
{
    /// <inheritdoc/>
    public CdrUsageReportResponseLegacy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CdrUsageReportResponseLegacy.FromRawUnchecked(rawData);
}