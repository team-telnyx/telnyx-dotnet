using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.Reports;

[JsonConverter(typeof(JsonModelConverter<PortingReport, PortingReportFromRaw>))]
public sealed record class PortingReport : JsonModel
{
    /// <summary>
    /// Uniquely identifies the report.
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
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
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

    /// <summary>
    /// Identifies the document that was uploaded when report was generated. This
    /// field is only populated when the report is under completed status.
    /// </summary>
    public string? DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "document_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <summary>
    /// The parameters for generating a porting orders CSV report.
    /// </summary>
    public ExportPortingOrdersCsvReport? Params {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportPortingOrdersCsvReport>(
                "params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("params", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
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
    /// Identifies the type of report
    /// </summary>
    public ApiEnum<string, PortingReportReportType>? ReportType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingReportReportType>>(
                "report_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("report_type", value);
        }
    }

    /// <summary>
    /// The current status of the report generation.
    /// </summary>
    public ApiEnum<string, PortingReportStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingReportStatus>>(
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
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
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
        _ = this.CreatedAt;
        _ = this.DocumentID;
        this.Params?.Validate();
        _ = this.RecordType;
        this.ReportType?.Validate();
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public PortingReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingReport (PortingReport portingReport) : base(portingReport)
    {  }
    #pragma warning restore CS8618

    public PortingReport (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingReportFromRaw.FromRawUnchecked"/>
    public static PortingReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingReportFromRaw : IFromRawJson<PortingReport>
{
    /// <inheritdoc/>
    public PortingReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingReport.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of report
/// </summary>
[JsonConverter(typeof(PortingReportReportTypeConverter))]
public enum PortingReportReportType
{
    ExportPortingOrdersCsv
}sealed class PortingReportReportTypeConverter : JsonConverter<PortingReportReportType>
{
    public override PortingReportReportType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "export_porting_orders_csv"=>PortingReportReportType.ExportPortingOrdersCsv,
            _ =>(PortingReportReportType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingReportReportType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingReportReportType.ExportPortingOrdersCsv=>"export_porting_orders_csv",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The current status of the report generation.
/// </summary>
[JsonConverter(typeof(PortingReportStatusConverter))]
public enum PortingReportStatus
{
    Pending, Completed
}sealed class PortingReportStatusConverter : JsonConverter<PortingReportStatus>
{
    public override PortingReportStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PortingReportStatus.Pending,
            "completed"=>PortingReportStatus.Completed,
            _ =>(PortingReportStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingReportStatus.Pending=>"pending",
            PortingReportStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}