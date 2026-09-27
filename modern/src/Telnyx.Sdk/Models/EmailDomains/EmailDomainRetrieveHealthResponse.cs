using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainRetrieveHealthResponse, EmailDomainRetrieveHealthResponseFromRaw>))]
public sealed record class EmailDomainRetrieveHealthResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailDomainRetrieveHealthResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRetrieveHealthResponse (
        EmailDomainRetrieveHealthResponse emailDomainRetrieveHealthResponse
    ) : base(emailDomainRetrieveHealthResponse)
    {  }
    #pragma warning restore CS8618

    public EmailDomainRetrieveHealthResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRetrieveHealthResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRetrieveHealthResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainRetrieveHealthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailDomainRetrieveHealthResponse (Data data) : this()
    { this.Data = data; }
}

class EmailDomainRetrieveHealthResponseFromRaw : IFromRawJson<EmailDomainRetrieveHealthResponse>
{
    /// <inheritdoc/>
    public EmailDomainRetrieveHealthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainRetrieveHealthResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique identifier for the email domain
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp of the last health check
    /// </summary>
    public required System::DateTimeOffset CheckedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "checked_at"
            );
        }
        init { this._rawData.Set("checked_at", value); }
    }

    /// <summary>
    /// Record type discriminator
    /// </summary>
    public required ApiEnum<string, DataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Current domain status
    /// </summary>
    public required ApiEnum<string, DataStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Whether the domain is usable for receiving inbound email
    /// </summary>
    public required bool UsableForInbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "usable_for_inbound"
            );
        }
        init { this._rawData.Set("usable_for_inbound", value); }
    }

    /// <summary>
    /// Whether the domain is usable for sending email
    /// </summary>
    public required bool UsableForSending {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "usable_for_sending"
            );
        }
        init { this._rawData.Set("usable_for_sending", value); }
    }

    public required EmailDomainVerification Verification {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomainVerification>(
                "verification"
            );
        }
        init { this._rawData.Set("verification", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CheckedAt;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.UsableForInbound;
        _ = this.UsableForSending;
        this.Verification.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Record type discriminator
/// </summary>
[JsonConverter(typeof(DataRecordTypeConverter))]
public enum DataRecordType
{
    EmailDomainHealth
}sealed class DataRecordTypeConverter : JsonConverter<DataRecordType>
{
    public override DataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_domain_health"=>DataRecordType.EmailDomainHealth,
            _ =>(DataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataRecordType.EmailDomainHealth=>"email_domain_health",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current domain status
/// </summary>
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    Pending, Verifying, Verified, Failed, Degraded, Suspended
}sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>DataStatus.Pending,
            "verifying"=>DataStatus.Verifying,
            "verified"=>DataStatus.Verified,
            "failed"=>DataStatus.Failed,
            "degraded"=>DataStatus.Degraded,
            "suspended"=>DataStatus.Suspended,
            _ =>(DataStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DataStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataStatus.Pending=>"pending",
            DataStatus.Verifying=>"verifying",
            DataStatus.Verified=>"verified",
            DataStatus.Failed=>"failed",
            DataStatus.Degraded=>"degraded",
            DataStatus.Suspended=>"suspended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}