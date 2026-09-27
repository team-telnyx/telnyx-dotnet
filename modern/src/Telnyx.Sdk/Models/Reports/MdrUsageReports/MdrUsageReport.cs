using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Reports.MdrUsageReports;

[JsonConverter(typeof(JsonModelConverter<MdrUsageReport, MdrUsageReportFromRaw>))]
public sealed record class MdrUsageReport : JsonModel
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

    public ApiEnum<string, MdrUsageReportAggregationType>? AggregationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MdrUsageReportAggregationType>>(
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

    public string? Profiles {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profiles"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profiles", value);
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

    public IReadOnlyList<Result>? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "result",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        this.AggregationType?.Validate();
        _ = this.Connections;
        _ = this.CreatedAt;
        _ = this.EndDate;
        _ = this.Profiles;
        _ = this.RecordType;
        _ = this.ReportUrl;
        foreach (var item in this.Result ?? [])
        {
            item.Validate();
        }
        _ = this.StartDate;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public MdrUsageReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MdrUsageReport (MdrUsageReport mdrUsageReport) : base(mdrUsageReport)
    {  }
    #pragma warning restore CS8618

    public MdrUsageReport (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MdrUsageReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MdrUsageReportFromRaw.FromRawUnchecked"/>
    public static MdrUsageReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MdrUsageReportFromRaw : IFromRawJson<MdrUsageReport>
{
    /// <inheritdoc/>
    public MdrUsageReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MdrUsageReport.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MdrUsageReportAggregationTypeConverter))]
public enum MdrUsageReportAggregationType
{
    NoAggregation, Profile, Tags
}sealed class MdrUsageReportAggregationTypeConverter : JsonConverter<MdrUsageReportAggregationType>
{
    public override MdrUsageReportAggregationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NO_AGGREGATION"=>MdrUsageReportAggregationType.NoAggregation,
            "PROFILE"=>MdrUsageReportAggregationType.Profile,
            "TAGS"=>MdrUsageReportAggregationType.Tags,
            _ =>(MdrUsageReportAggregationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MdrUsageReportAggregationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MdrUsageReportAggregationType.NoAggregation=>"NO_AGGREGATION",
            MdrUsageReportAggregationType.Profile=>"PROFILE",
            MdrUsageReportAggregationType.Tags=>"TAGS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    public string? CarrierPassthroughFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_passthrough_fee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_passthrough_fee", value);
        }
    }

    public string? Connection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection", value);
        }
    }

    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    public string? Delivered {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivered"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivered", value);
        }
    }

    public string? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public string? MessageType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message_type", value);
        }
    }

    public string? Parts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parts", value);
        }
    }

    public string? Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product", value);
        }
    }

    public string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_id", value);
        }
    }

    public string? Received {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "received"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("received", value);
        }
    }

    public string? Sent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sent", value);
        }
    }

    public string? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tags", value);
        }
    }

    public string? TnType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tn_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tn_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CarrierPassthroughFee;
        _ = this.Connection;
        _ = this.Cost;
        _ = this.Currency;
        _ = this.Delivered;
        _ = this.Direction;
        _ = this.MessageType;
        _ = this.Parts;
        _ = this.Product;
        _ = this.ProfileID;
        _ = this.Received;
        _ = this.Sent;
        _ = this.Tags;
        _ = this.TnType;
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
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