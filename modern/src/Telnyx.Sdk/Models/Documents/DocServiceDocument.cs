using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Documents;

[JsonConverter(typeof(JsonModelConverter<DocServiceDocument, DocServiceDocumentFromRaw>))]
public sealed record class DocServiceDocument : JsonModel
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
    /// ISO 8601 formatted date-time indicating when the resource was created.
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
    /// ISO 8601 formatted date-time indicating when the resource was updated.
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

    /// <summary>
    /// The antivirus scan status of the document.
    /// </summary>
    public ApiEnum<string, AvScanStatus>? AvScanStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AvScanStatus>>(
                "av_scan_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("av_scan_status", value);
        }
    }

    /// <summary>
    /// The document's content_type.
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// Optional reference string for customer tracking.
    /// </summary>
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

    /// <summary>
    /// The filename of the document.
    /// </summary>
    public string? Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "filename"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// The document's SHA256 hash provided for optional verification purposes.
    /// </summary>
    public string? Sha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sha256"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sha256", value);
        }
    }

    /// <summary>
    /// Indicates the document's filesize
    /// </summary>
    public Size? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Size>(
                "size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// Indicates the current document reviewing status
    /// </summary>
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

    public static implicit operator DocServiceRecord (
        DocServiceDocument docServiceDocument
    )=> new() {
        ID = docServiceDocument.ID,
        CreatedAt = docServiceDocument.CreatedAt,
        RecordType = docServiceDocument.RecordType,
        UpdatedAt = docServiceDocument.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        this.AvScanStatus?.Validate();
        _ = this.ContentType;
        _ = this.CustomerReference;
        _ = this.Filename;
        _ = this.Sha256;
        this.Size?.Validate();
        this.Status?.Validate();
    }

    public DocServiceDocument ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocServiceDocument (DocServiceDocument docServiceDocument) : base(
        docServiceDocument
    )
    {  }
    #pragma warning restore CS8618

    public DocServiceDocument (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DocServiceDocument (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DocServiceDocumentFromRaw.FromRawUnchecked"/>
    public static DocServiceDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DocServiceDocumentFromRaw : IFromRawJson<DocServiceDocument>
{
    /// <inheritdoc/>
    public DocServiceDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DocServiceDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The antivirus scan status of the document.
    /// </summary>
    public ApiEnum<string, AvScanStatus>? AvScanStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AvScanStatus>>(
                "av_scan_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("av_scan_status", value);
        }
    }

    /// <summary>
    /// The document's content_type.
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// Optional reference string for customer tracking.
    /// </summary>
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

    /// <summary>
    /// The filename of the document.
    /// </summary>
    public string? Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "filename"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// The document's SHA256 hash provided for optional verification purposes.
    /// </summary>
    public string? Sha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sha256"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sha256", value);
        }
    }

    /// <summary>
    /// Indicates the document's filesize
    /// </summary>
    public Size? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Size>(
                "size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// Indicates the current document reviewing status
    /// </summary>
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
        this.AvScanStatus?.Validate();
        _ = this.ContentType;
        _ = this.CustomerReference;
        _ = this.Filename;
        _ = this.Sha256;
        this.Size?.Validate();
        this.Status?.Validate();
    }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}/// <summary>
/// The antivirus scan status of the document.
/// </summary>
[JsonConverter(typeof(AvScanStatusConverter))]
public enum AvScanStatus
{
    Scanned, Infected, PendingScan, NotScanned
}sealed class AvScanStatusConverter : JsonConverter<AvScanStatus>
{
    public override AvScanStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scanned"=>AvScanStatus.Scanned,
            "infected"=>AvScanStatus.Infected,
            "pending_scan"=>AvScanStatus.PendingScan,
            "not_scanned"=>AvScanStatus.NotScanned,
            _ =>(AvScanStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AvScanStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AvScanStatus.Scanned=>"scanned",
            AvScanStatus.Infected=>"infected",
            AvScanStatus.PendingScan=>"pending_scan",
            AvScanStatus.NotScanned=>"not_scanned",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates the document's filesize
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Size, SizeFromRaw>))]
public sealed record class Size : JsonModel
{
    /// <summary>
    /// The number of bytes
    /// </summary>
    public long? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Identifies the unit
    /// </summary>
    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Unit;
    }

    public Size ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Size (Size size) : base(size)
    {  }
    #pragma warning restore CS8618

    public Size (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Size (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SizeFromRaw.FromRawUnchecked"/>
    public static Size FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SizeFromRaw : IFromRawJson<Size>
{
    /// <inheritdoc/>
    public Size FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Size.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates the current document reviewing status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Verified, Denied
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
            "pending"=>Status.Pending,
            "verified"=>Status.Verified,
            "denied"=>Status.Denied,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Verified=>"verified",
            Status.Denied=>"denied",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}