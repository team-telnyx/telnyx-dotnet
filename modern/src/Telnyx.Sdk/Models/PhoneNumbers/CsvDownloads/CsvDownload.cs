using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

[JsonConverter(typeof(JsonModelConverter<CsvDownload, CsvDownloadFromRaw>))]
public sealed record class CsvDownload : JsonModel
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
    /// Indicates the completion level of the CSV report. Only complete CSV download
    /// requests will be able to be retrieved.
    /// </summary>
    public ApiEnum<string, CsvDownloadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CsvDownloadStatus>>(
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
    /// The URL at which the CSV file can be retrieved.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.Url;
    }

    public CsvDownload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CsvDownload (CsvDownload csvDownload) : base(csvDownload)
    {  }
    #pragma warning restore CS8618

    public CsvDownload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CsvDownload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CsvDownloadFromRaw.FromRawUnchecked"/>
    public static CsvDownload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CsvDownloadFromRaw : IFromRawJson<CsvDownload>
{
    /// <inheritdoc/>
    public CsvDownload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CsvDownload.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the completion level of the CSV report. Only complete CSV download
/// requests will be able to be retrieved.
/// </summary>
[JsonConverter(typeof(CsvDownloadStatusConverter))]
public enum CsvDownloadStatus
{
    Pending, Complete, Failed, Expired
}sealed class CsvDownloadStatusConverter : JsonConverter<CsvDownloadStatus>
{
    public override CsvDownloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>CsvDownloadStatus.Pending,
            "complete"=>CsvDownloadStatus.Complete,
            "failed"=>CsvDownloadStatus.Failed,
            "expired"=>CsvDownloadStatus.Expired,
            _ =>(CsvDownloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CsvDownloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CsvDownloadStatus.Pending=>"pending",
            CsvDownloadStatus.Complete=>"complete",
            CsvDownloadStatus.Failed=>"failed",
            CsvDownloadStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}