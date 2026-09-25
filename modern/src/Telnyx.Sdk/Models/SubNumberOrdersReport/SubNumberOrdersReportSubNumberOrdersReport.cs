using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SubNumberOrdersReport;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrdersReportSubNumberOrdersReport, SubNumberOrdersReportSubNumberOrdersReportFromRaw>))]
public sealed record class SubNumberOrdersReportSubNumberOrdersReport : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// The filters that were applied to generate this report
    /// </summary>
    public Filters? Filters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Filters>(
                "filters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filters", value);
        }
    }

    /// <summary>
    /// The type of order report.
    /// </summary>
    public string? OrderType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_type", value);
        }
    }

    /// <summary>
    /// Indicates the completion level of the sub number orders report. The report
    /// must have a status of 'success' before it can be downloaded.
    /// </summary>
    public ApiEnum<string, SubNumberOrdersReportSubNumberOrdersReportStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubNumberOrdersReportSubNumberOrdersReportStatus>>(
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

    /// <summary>
    /// The ID of the user who created the report.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Filters?.Validate();
        _ = this.OrderType;
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.UserID;
    }

    public SubNumberOrdersReportSubNumberOrdersReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrdersReportSubNumberOrdersReport (
        SubNumberOrdersReportSubNumberOrdersReport subNumberOrdersReportSubNumberOrdersReport
    ) : base(subNumberOrdersReportSubNumberOrdersReport)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrdersReportSubNumberOrdersReport (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrdersReportSubNumberOrdersReport (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrdersReportSubNumberOrdersReportFromRaw.FromRawUnchecked"/>
    public static SubNumberOrdersReportSubNumberOrdersReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrdersReportSubNumberOrdersReportFromRaw : IFromRawJson<SubNumberOrdersReportSubNumberOrdersReport>
{
    /// <inheritdoc/>
    public SubNumberOrdersReportSubNumberOrdersReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrdersReportSubNumberOrdersReport.FromRawUnchecked(rawData);
}

/// <summary>
/// The filters that were applied to generate this report
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public System::DateTimeOffset? CreatedAtGt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at_gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at_gt", value);
        }
    }

    public System::DateTimeOffset? CreatedAtLt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at_lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at_lt", value);
        }
    }

    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    public string? OrderRequestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_request_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_request_id", value);
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.CreatedAtGt;
        _ = this.CreatedAtLt;
        _ = this.CustomerReference;
        _ = this.OrderRequestID;
        _ = this.Status;
    }

    public Filters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filters (Filters filters) : base(filters)
    {  }
    #pragma warning restore CS8618

    public Filters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FiltersFromRaw.FromRawUnchecked"/>
    public static Filters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FiltersFromRaw : IFromRawJson<Filters>
{
    /// <inheritdoc/>
    public Filters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filters.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates the completion level of the sub number orders report. The report must
/// have a status of 'success' before it can be downloaded.
/// </summary>
[JsonConverter(typeof(SubNumberOrdersReportSubNumberOrdersReportStatusConverter))]
public enum SubNumberOrdersReportSubNumberOrdersReportStatus
{
    Pending, Success, Failed, Expired
}sealed class SubNumberOrdersReportSubNumberOrdersReportStatusConverter : JsonConverter<SubNumberOrdersReportSubNumberOrdersReportStatus>
{
    public override SubNumberOrdersReportSubNumberOrdersReportStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>SubNumberOrdersReportSubNumberOrdersReportStatus.Pending,
            "success"=>SubNumberOrdersReportSubNumberOrdersReportStatus.Success,
            "failed"=>SubNumberOrdersReportSubNumberOrdersReportStatus.Failed,
            "expired"=>SubNumberOrdersReportSubNumberOrdersReportStatus.Expired,
            _ =>(SubNumberOrdersReportSubNumberOrdersReportStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubNumberOrdersReportSubNumberOrdersReportStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SubNumberOrdersReportSubNumberOrdersReportStatus.Pending=>"pending",
            SubNumberOrdersReportSubNumberOrdersReportStatus.Success=>"success",
            SubNumberOrdersReportSubNumberOrdersReportStatus.Failed=>"failed",
            SubNumberOrdersReportSubNumberOrdersReportStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}