using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.Reports;

/// <summary>
/// The parameters for generating a porting orders CSV report.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportPortingOrdersCsvReport, ExportPortingOrdersCsvReportFromRaw>))]
public sealed record class ExportPortingOrdersCsvReport : JsonModel
{
    /// <summary>
    /// The filters to apply to the export porting order CSV report.
    /// </summary>
    public required Filters Filters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Filters>(
                "filters"
            );
        }
        init { this._rawData.Set("filters", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Filters.Validate(); }

    public ExportPortingOrdersCsvReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportPortingOrdersCsvReport (
        ExportPortingOrdersCsvReport exportPortingOrdersCsvReport
    ) : base(exportPortingOrdersCsvReport)
    {  }
    #pragma warning restore CS8618

    public ExportPortingOrdersCsvReport (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportPortingOrdersCsvReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExportPortingOrdersCsvReportFromRaw.FromRawUnchecked"/>
    public static ExportPortingOrdersCsvReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ExportPortingOrdersCsvReport (Filters filters) : this()
    { this.Filters = filters; }
}

class ExportPortingOrdersCsvReportFromRaw : IFromRawJson<ExportPortingOrdersCsvReport>
{
    /// <inheritdoc/>
    public ExportPortingOrdersCsvReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExportPortingOrdersCsvReport.FromRawUnchecked(rawData);
}

/// <summary>
/// The filters to apply to the export porting order CSV report.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    /// <summary>
    /// The date and time the porting order was created after.
    /// </summary>
    public System::DateTimeOffset? CreatedAtGt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at__gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at__gt", value);
        }
    }

    /// <summary>
    /// The date and time the porting order was created before.
    /// </summary>
    public System::DateTimeOffset? CreatedAtLt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at__lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at__lt", value);
        }
    }

    /// <summary>
    /// The customer reference of the porting orders to include in the report.
    /// </summary>
    public IReadOnlyList<string>? CustomerReferenceIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "customer_reference__in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "customer_reference__in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the porting orders to include in the report.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, StatusIn>>? StatusIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, StatusIn>>>(
                "status__in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, StatusIn>>?>(
                "status__in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAtGt;
        _ = this.CreatedAtLt;
        _ = this.CustomerReferenceIn;
        foreach (var item in this.StatusIn ?? [])
        {
            item.Validate();
        }
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
}[JsonConverter(typeof(StatusInConverter))]
public enum StatusIn
{
    Draft,
    InProcess,
    Submitted,
    Exception,
    FocDateConfirmed,
    CancelPending,
    Ported,
    Cancelled
}sealed class StatusInConverter : JsonConverter<StatusIn>
{
    public override StatusIn Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>StatusIn.Draft,
            "in-process"=>StatusIn.InProcess,
            "submitted"=>StatusIn.Submitted,
            "exception"=>StatusIn.Exception,
            "foc-date-confirmed"=>StatusIn.FocDateConfirmed,
            "cancel-pending"=>StatusIn.CancelPending,
            "ported"=>StatusIn.Ported,
            "cancelled"=>StatusIn.Cancelled,
            _ =>(StatusIn)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StatusIn value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusIn.Draft=>"draft",
            StatusIn.InProcess=>"in-process",
            StatusIn.Submitted=>"submitted",
            StatusIn.Exception=>"exception",
            StatusIn.FocDateConfirmed=>"foc-date-confirmed",
            StatusIn.CancelPending=>"cancel-pending",
            StatusIn.Ported=>"ported",
            StatusIn.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}