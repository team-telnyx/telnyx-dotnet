using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Messaging;

[JsonConverter(typeof(JsonModelConverter<MdrDetailReportResponse, MdrDetailReportResponseFromRaw>))]
public sealed record class MdrDetailReportResponse : JsonModel
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

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public IReadOnlyList<ApiEnum<string, Direction>>? Directions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Direction>>>(
                "directions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Direction>>?>(
                "directions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public System::DateTimeOffset? EndDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// List of messaging profile IDs
    /// </summary>
    public IReadOnlyList<string>? Profiles {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "profiles"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "profiles",
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

    public IReadOnlyList<ApiEnum<string, RecordType>>? RecordTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, RecordType>>>(
                "record_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, RecordType>>?>(
                "record_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public System::DateTimeOffset? StartDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
        _ = this.Connections;
        _ = this.CreatedAt;
        foreach (var item in this.Directions ?? [])
        {
            item.Validate();
        }
        _ = this.EndDate;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Profiles;
        _ = this.RecordType;
        foreach (var item in this.RecordTypes ?? [])
        {
            item.Validate();
        }
        _ = this.ReportName;
        _ = this.ReportUrl;
        _ = this.StartDate;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public MdrDetailReportResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrDetailReportResponse (
        MdrDetailReportResponse mdrDetailReportResponse
    ) : base(mdrDetailReportResponse)
    {  }
    #pragma warning restore CS8618

    public MdrDetailReportResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrDetailReportResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrDetailReportResponseFromRaw.FromRawUnchecked"/>
    public static MdrDetailReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrDetailReportResponseFromRaw : IFromRawJson<MdrDetailReportResponse>
{
    /// <inheritdoc/>
    public MdrDetailReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrDetailReportResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INBOUND"=>Direction.Inbound,
            "OUTBOUND"=>Direction.Outbound,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"INBOUND",
            Direction.Outbound=>"OUTBOUND",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Incomplete, Completed, Errors
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INCOMPLETE"=>RecordType.Incomplete,
            "COMPLETED"=>RecordType.Completed,
            "ERRORS"=>RecordType.Errors,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Incomplete=>"INCOMPLETE",
            RecordType.Completed=>"COMPLETED",
            RecordType.Errors=>"ERRORS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Complete, Failed, Expired
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING"=>Status.Pending,
            "COMPLETE"=>Status.Complete,
            "FAILED"=>Status.Failed,
            "EXPIRED"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"PENDING",
            Status.Complete=>"COMPLETE",
            Status.Failed=>"FAILED",
            Status.Expired=>"EXPIRED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}