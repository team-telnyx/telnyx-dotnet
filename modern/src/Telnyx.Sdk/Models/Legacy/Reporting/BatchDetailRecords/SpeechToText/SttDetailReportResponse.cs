using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

[JsonConverter(typeof(JsonModelConverter<SttDetailReportResponse, SttDetailReportResponseFromRaw>))]
public sealed record class SttDetailReportResponse : JsonModel
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
    /// URL to download the report
    /// </summary>
    public string? DownloadLink {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "download_link"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("download_link", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DownloadLink;
        _ = this.EndDate;
        _ = this.RecordType;
        _ = this.StartDate;
        this.Status?.Validate();
    }

    public SttDetailReportResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SttDetailReportResponse (
        SttDetailReportResponse sttDetailReportResponse
    ) : base(sttDetailReportResponse)
    {  }
    #pragma warning restore CS8618

    public SttDetailReportResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SttDetailReportResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SttDetailReportResponseFromRaw.FromRawUnchecked"/>
    public static SttDetailReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SttDetailReportResponseFromRaw : IFromRawJson<SttDetailReportResponse>
{
    /// <inheritdoc/>
    public SttDetailReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SttDetailReportResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
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