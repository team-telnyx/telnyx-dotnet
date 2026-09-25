using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Voice;

/// <summary>
/// Response object for CDR detailed report
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CdrDetailedReqResponse, CdrDetailedReqResponseFromRaw>))]
public sealed record class CdrDetailedReqResponse : JsonModel
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
    /// List of call types (Inbound = 1, Outbound = 2)
    /// </summary>
    public IReadOnlyList<int>? CallTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<int>>(
                "call_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<int>?>(
                "call_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of connections
    /// </summary>
    public IReadOnlyList<long>? Connections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>(
                "connections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "connections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Creation date of the report
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// End time in ISO format
    /// </summary>
    public string? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// List of filters
    /// </summary>
    public IReadOnlyList<Filter>? Filters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Filter>>(
                "filters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Filter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of managed accounts
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
    /// List of record types (Complete = 1, Incomplete = 2, Errors = 3)
    /// </summary>
    public IReadOnlyList<int>? RecordTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<int>>(
                "record_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<int>?>(
                "record_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Name of the report
    /// </summary>
    public string? ReportName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "report_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("report_name", value);
        }
    }

    /// <summary>
    /// URL to download the report
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
    /// Number of retries
    /// </summary>
    public int? Retry {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "retry"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retry", value);
        }
    }

    /// <summary>
    /// Source of the report. Valid values: calls (default), call-control, fax-api, webrtc
    /// </summary>
    public string? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Start time in ISO format
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Status of the report (Pending = 1, Complete = 2, Failed = 3, Expired = 4)
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

    /// <summary>
    /// Timezone for the report
    /// </summary>
    public string? Timezone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "timezone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timezone", value);
        }
    }

    /// <summary>
    /// Last update date of the report
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.CallTypes;
        _ = this.Connections;
        _ = this.CreatedAt;
        _ = this.EndTime;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.ManagedAccounts;
        _ = this.RecordType;
        _ = this.RecordTypes;
        _ = this.ReportName;
        _ = this.ReportUrl;
        _ = this.Retry;
        _ = this.Source;
        _ = this.StartTime;
        _ = this.Status;
        _ = this.Timezone;
        _ = this.UpdatedAt;
    }

    public CdrDetailedReqResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CdrDetailedReqResponse (
        CdrDetailedReqResponse cdrDetailedReqResponse
    ) : base(cdrDetailedReqResponse)
    {  }
    #pragma warning restore CS8618

    public CdrDetailedReqResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CdrDetailedReqResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CdrDetailedReqResponseFromRaw.FromRawUnchecked"/>
    public static CdrDetailedReqResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CdrDetailedReqResponseFromRaw : IFromRawJson<CdrDetailedReqResponse>
{
    /// <inheritdoc/>
    public CdrDetailedReqResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CdrDetailedReqResponse.FromRawUnchecked(rawData);
}