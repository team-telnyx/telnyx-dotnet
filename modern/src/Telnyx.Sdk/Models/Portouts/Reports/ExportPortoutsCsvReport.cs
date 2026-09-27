using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.Reports;

/// <summary>
/// The parameters for generating a port-outs CSV report.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExportPortoutsCsvReport, ExportPortoutsCsvReportFromRaw>))]
public sealed record class ExportPortoutsCsvReport : JsonModel
{
    /// <summary>
    /// The filters to apply to the export port-out CSV report.
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

    public ExportPortoutsCsvReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportPortoutsCsvReport (
        ExportPortoutsCsvReport exportPortoutsCsvReport
    ) : base(exportPortoutsCsvReport)
    {  }
    #pragma warning restore CS8618

    public ExportPortoutsCsvReport (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportPortoutsCsvReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExportPortoutsCsvReportFromRaw.FromRawUnchecked"/>
    public static ExportPortoutsCsvReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ExportPortoutsCsvReport (Filters filters) : this()
    { this.Filters = filters; }
}

class ExportPortoutsCsvReportFromRaw : IFromRawJson<ExportPortoutsCsvReport>
{
    /// <inheritdoc/>
    public ExportPortoutsCsvReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExportPortoutsCsvReport.FromRawUnchecked(rawData);
}

/// <summary>
/// The filters to apply to the export port-out CSV report.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    /// <summary>
    /// The date and time the port-out was created after.
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
    /// The date and time the port-out was created before.
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
    /// The customer reference of the port-outs to include in the report.
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
    /// The end user name of the port-outs to include in the report.
    /// </summary>
    public string? EndUserName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_user_name", value);
        }
    }

    /// <summary>
    /// A list of phone numbers that the port-outs phone numbers must overlap with.
    /// </summary>
    public IReadOnlyList<string>? PhoneNumbersOverlaps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phone_numbers__overlaps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phone_numbers__overlaps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the port-outs to include in the report.
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
        _ = this.EndUserName;
        _ = this.PhoneNumbersOverlaps;
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
    Pending, Authorized, Ported, Rejected, RejectedPending, Canceled
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
            "pending"=>StatusIn.Pending,
            "authorized"=>StatusIn.Authorized,
            "ported"=>StatusIn.Ported,
            "rejected"=>StatusIn.Rejected,
            "rejected-pending"=>StatusIn.RejectedPending,
            "canceled"=>StatusIn.Canceled,
            _ =>(StatusIn)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StatusIn value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusIn.Pending=>"pending",
            StatusIn.Authorized=>"authorized",
            StatusIn.Ported=>"ported",
            StatusIn.Rejected=>"rejected",
            StatusIn.RejectedPending=>"rejected-pending",
            StatusIn.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}