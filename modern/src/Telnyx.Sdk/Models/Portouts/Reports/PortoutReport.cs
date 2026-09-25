using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.Reports;

[JsonConverter(typeof(JsonModelConverter<PortoutReport, PortoutReportFromRaw>))]
public sealed record class PortoutReport : JsonModel
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
    /// The parameters for generating a port-outs CSV report.
    /// </summary>
    public ExportPortoutsCsvReport? Params {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExportPortoutsCsvReport>(
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
    public ApiEnum<string, PortoutReportReportType>? ReportType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortoutReportReportType>>(
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
    public ApiEnum<string, PortoutReportStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortoutReportStatus>>(
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

    public PortoutReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutReport (PortoutReport portoutReport) : base(portoutReport)
    {  }
    #pragma warning restore CS8618

    public PortoutReport (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutReportFromRaw.FromRawUnchecked"/>
    public static PortoutReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutReportFromRaw : IFromRawJson<PortoutReport>
{
    /// <inheritdoc/>
    public PortoutReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutReport.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of report
/// </summary>
[JsonConverter(typeof(PortoutReportReportTypeConverter))]
public enum PortoutReportReportType
{
    ExportPortoutsCsv
}sealed class PortoutReportReportTypeConverter : JsonConverter<PortoutReportReportType>
{
    public override PortoutReportReportType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "export_portouts_csv"=>PortoutReportReportType.ExportPortoutsCsv,
            _ =>(PortoutReportReportType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortoutReportReportType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortoutReportReportType.ExportPortoutsCsv=>"export_portouts_csv",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The current status of the report generation.
/// </summary>
[JsonConverter(typeof(PortoutReportStatusConverter))]
public enum PortoutReportStatus
{
    Pending, Completed
}sealed class PortoutReportStatusConverter : JsonConverter<PortoutReportStatus>
{
    public override PortoutReportStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PortoutReportStatus.Pending,
            "completed"=>PortoutReportStatus.Completed,
            _ =>(PortoutReportStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortoutReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortoutReportStatus.Pending=>"pending",
            PortoutReportStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}