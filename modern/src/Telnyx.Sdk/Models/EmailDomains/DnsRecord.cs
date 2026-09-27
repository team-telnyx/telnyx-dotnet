using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<DnsRecord, DnsRecordFromRaw>))]
public sealed record class DnsRecord : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Host {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "host"
            );
        }
        init { this._rawData.Set("host", value); }
    }

    public required ApiEnum<string, Purpose> Purpose {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Purpose>>(
                "purpose"
            );
        }
        init { this._rawData.Set("purpose", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required bool Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "required"
            );
        }
        init { this._rawData.Set("required", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    public string? ActualValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "actual_value"
            );
        }
        init { this._rawData.Set("actual_value", value); }
    }

    public long? Priority {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "priority"
            );
        }
        init { this._rawData.Set("priority", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Host;
        this.Purpose.Validate();
        this.RecordType.Validate();
        _ = this.Required;
        this.Status.Validate();
        _ = this.Value;
        _ = this.ActualValue;
        _ = this.Priority;
    }

    public DnsRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DnsRecord (DnsRecord dnsRecord) : base(dnsRecord)
    {  }
    #pragma warning restore CS8618

    public DnsRecord (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DnsRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DnsRecordFromRaw.FromRawUnchecked"/>
    public static DnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DnsRecordFromRaw : IFromRawJson<DnsRecord>
{
    /// <inheritdoc/>
    public DnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DnsRecord.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PurposeConverter))]
public enum Purpose
{
    Ownership, Spf, Dkim, Dmarc, Mx
}sealed class PurposeConverter : JsonConverter<Purpose>
{
    public override Purpose Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ownership"=>Purpose.Ownership,
            "spf"=>Purpose.Spf,
            "dkim"=>Purpose.Dkim,
            "dmarc"=>Purpose.Dmarc,
            "mx"=>Purpose.Mx,
            _ =>(Purpose)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Purpose value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Purpose.Ownership=>"ownership",
            Purpose.Spf=>"spf",
            Purpose.Dkim=>"dkim",
            Purpose.Dmarc=>"dmarc",
            Purpose.Mx=>"mx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Txt, Mx
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "TXT"=>RecordType.Txt, "MX"=>RecordType.Mx, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Txt=>"TXT",
            RecordType.Mx=>"MX",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Verified, Failed, NotRequired
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
            "failed"=>Status.Failed,
            "not_required"=>Status.NotRequired,
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
            Status.Failed=>"failed",
            Status.NotRequired=>"not_required",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}