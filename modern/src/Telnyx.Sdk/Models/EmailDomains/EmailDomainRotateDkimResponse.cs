using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainRotateDkimResponse, EmailDomainRotateDkimResponseFromRaw>))]
public sealed record class EmailDomainRotateDkimResponse : JsonModel
{
    /// <summary>
    /// Result of rotating a domain's DKIM key. The new key is active and signing
    /// switches to it immediately; the previous key is retired to a `retiring` state
    /// (retained, not revoked) so it can be revoked after the DNS propagation grace
    /// period. Selectors are fixed, so the DKIM DNS record's TXT value is replaced
    /// in place at the shared `&lt;selector&gt;._domainkey.&lt;domain&gt;` host
    /// — `old_selector_retained` is false and the returned dns_records carry the
    /// new value the customer must publish promptly.
    /// </summary>
    public required EmailDomainRotateDkimResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomainRotateDkimResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailDomainRotateDkimResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRotateDkimResponse (
        EmailDomainRotateDkimResponse emailDomainRotateDkimResponse
    ) : base(emailDomainRotateDkimResponse)
    {  }
    #pragma warning restore CS8618

    public EmailDomainRotateDkimResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRotateDkimResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRotateDkimResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainRotateDkimResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailDomainRotateDkimResponse (
        EmailDomainRotateDkimResponseData data
    ) : this()
    { this.Data = data; }
}

class EmailDomainRotateDkimResponseFromRaw : IFromRawJson<EmailDomainRotateDkimResponse>
{
    /// <inheritdoc/>
    public EmailDomainRotateDkimResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainRotateDkimResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of rotating a domain's DKIM key. The new key is active and signing switches
/// to it immediately; the previous key is retired to a `retiring` state (retained,
/// not revoked) so it can be revoked after the DNS propagation grace period. Selectors
/// are fixed, so the DKIM DNS record's TXT value is replaced in place at the shared
/// `&lt;selector&gt;._domainkey.&lt;domain&gt;` host — `old_selector_retained` is
/// false and the returned dns_records carry the new value the customer must publish
/// promptly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDomainRotateDkimResponseData, EmailDomainRotateDkimResponseDataFromRaw>))]
public sealed record class EmailDomainRotateDkimResponseData : JsonModel
{
    /// <summary>
    /// The new active DKIM key.
    /// </summary>
    public required EmailDomainRotateDkimResponseDataDkim Dkim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomainRotateDkimResponseDataDkim>(
                "dkim"
            );
        }
        init { this._rawData.Set("dkim", value); }
    }

    /// <summary>
    /// The DKIM DNS records the customer must publish, carrying the new key's TXT
    /// value with verification reset to pending.
    /// </summary>
    public required IReadOnlyList<DnsRecord> DnsRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DnsRecord>>(
                "dns_records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<DnsRecord>>(
                "dns_records",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Domain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "domain"
            );
        }
        init { this._rawData.Set("domain", value); }
    }

    public required string DomainID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "domain_id"
            );
        }
        init { this._rawData.Set("domain_id", value); }
    }

    /// <summary>
    /// False for this service: one selector is fixed per domain, so rotation replaces
    /// the TXT value at the existing _domainkey host. There is no dual-selector overlap;
    /// publish the replacement TXT promptly because signing switches immediately.
    /// </summary>
    public required bool OldSelectorRetained {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "old_selector_retained"
            );
        }
        init { this._rawData.Set("old_selector_retained", value); }
    }

    /// <summary>
    /// The retired previous key, or null when the domain had no active key before
    /// rotation. Retained in a `retiring` state so it can be revoked after the DNS
    /// propagation grace period.
    /// </summary>
    public required PreviousDkimKey? PreviousDkimKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PreviousDkimKey>(
                "previous_dkim_key"
            );
        }
        init { this._rawData.Set("previous_dkim_key", value); }
    }

    public required ApiEnum<string, EmailDomainRotateDkimResponseDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainRotateDkimResponseDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Dkim.Validate();
        foreach (var item in this.DnsRecords)
        {
            item.Validate();
        }
        _ = this.Domain;
        _ = this.DomainID;
        _ = this.OldSelectorRetained;
        this.PreviousDkimKey?.Validate();
        this.RecordType.Validate();
    }

    public EmailDomainRotateDkimResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRotateDkimResponseData (
        EmailDomainRotateDkimResponseData emailDomainRotateDkimResponseData
    ) : base(emailDomainRotateDkimResponseData)
    {  }
    #pragma warning restore CS8618

    public EmailDomainRotateDkimResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRotateDkimResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRotateDkimResponseDataFromRaw.FromRawUnchecked"/>
    public static EmailDomainRotateDkimResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailDomainRotateDkimResponseDataFromRaw : IFromRawJson<EmailDomainRotateDkimResponseData>
{
    /// <inheritdoc/>
    public EmailDomainRotateDkimResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainRotateDkimResponseData.FromRawUnchecked(rawData);
}/// <summary>
/// The new active DKIM key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDomainRotateDkimResponseDataDkim, EmailDomainRotateDkimResponseDataDkimFromRaw>))]
public sealed record class EmailDomainRotateDkimResponseDataDkim : JsonModel
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

    public required ApiEnum<string, EmailDomainRotateDkimResponseDataDkimAlgorithm> Algorithm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainRotateDkimResponseDataDkimAlgorithm>>(
                "algorithm"
            );
        }
        init { this._rawData.Set("algorithm", value); }
    }

    public required ApiEnum<long, EmailDomainRotateDkimResponseDataDkimKeyLength> KeyLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<long, EmailDomainRotateDkimResponseDataDkimKeyLength>>(
                "key_length"
            );
        }
        init { this._rawData.Set("key_length", value); }
    }

    public required string Selector {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "selector"
            );
        }
        init { this._rawData.Set("selector", value); }
    }

    public required ApiEnum<string, EmailDomainRotateDkimResponseDataDkimStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainRotateDkimResponseDataDkimStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Monotonically increasing per-domain key version.
    /// </summary>
    public required long Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "version"
            );
        }
        init { this._rawData.Set("version", value); }
    }

    public System::DateTimeOffset? ActivatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "activated_at"
            );
        }
        init { this._rawData.Set("activated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Algorithm.Validate();
        this.KeyLength.Validate();
        _ = this.Selector;
        this.Status.Validate();
        _ = this.Version;
        _ = this.ActivatedAt;
    }

    public EmailDomainRotateDkimResponseDataDkim ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRotateDkimResponseDataDkim (
        EmailDomainRotateDkimResponseDataDkim emailDomainRotateDkimResponseDataDkim
    ) : base(emailDomainRotateDkimResponseDataDkim)
    {  }
    #pragma warning restore CS8618

    public EmailDomainRotateDkimResponseDataDkim (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRotateDkimResponseDataDkim (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRotateDkimResponseDataDkimFromRaw.FromRawUnchecked"/>
    public static EmailDomainRotateDkimResponseDataDkim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailDomainRotateDkimResponseDataDkimFromRaw : IFromRawJson<EmailDomainRotateDkimResponseDataDkim>
{
    /// <inheritdoc/>
    public EmailDomainRotateDkimResponseDataDkim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainRotateDkimResponseDataDkim.FromRawUnchecked(rawData);
}[JsonConverter(typeof(EmailDomainRotateDkimResponseDataDkimAlgorithmConverter))]
public enum EmailDomainRotateDkimResponseDataDkimAlgorithm
{
    RsaSha256
}sealed class EmailDomainRotateDkimResponseDataDkimAlgorithmConverter : JsonConverter<EmailDomainRotateDkimResponseDataDkimAlgorithm>
{
    public override EmailDomainRotateDkimResponseDataDkimAlgorithm Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rsa-sha256"=>EmailDomainRotateDkimResponseDataDkimAlgorithm.RsaSha256,
            _ =>(EmailDomainRotateDkimResponseDataDkimAlgorithm)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRotateDkimResponseDataDkimAlgorithm value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainRotateDkimResponseDataDkimAlgorithm.RsaSha256=>"rsa-sha256",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(EmailDomainRotateDkimResponseDataDkimKeyLengthConverter))]
public enum EmailDomainRotateDkimResponseDataDkimKeyLength
{
    V2048
}sealed class EmailDomainRotateDkimResponseDataDkimKeyLengthConverter : JsonConverter<EmailDomainRotateDkimResponseDataDkimKeyLength>
{
    public override EmailDomainRotateDkimResponseDataDkimKeyLength Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            2048L=>EmailDomainRotateDkimResponseDataDkimKeyLength.V2048,
            _ =>(EmailDomainRotateDkimResponseDataDkimKeyLength)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRotateDkimResponseDataDkimKeyLength value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainRotateDkimResponseDataDkimKeyLength.V2048=>2048L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(EmailDomainRotateDkimResponseDataDkimStatusConverter))]
public enum EmailDomainRotateDkimResponseDataDkimStatus
{
    Active
}sealed class EmailDomainRotateDkimResponseDataDkimStatusConverter : JsonConverter<EmailDomainRotateDkimResponseDataDkimStatus>
{
    public override EmailDomainRotateDkimResponseDataDkimStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active"=>EmailDomainRotateDkimResponseDataDkimStatus.Active,
            _ =>(EmailDomainRotateDkimResponseDataDkimStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRotateDkimResponseDataDkimStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainRotateDkimResponseDataDkimStatus.Active=>"active",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The retired previous key, or null when the domain had no active key before rotation.
/// Retained in a `retiring` state so it can be revoked after the DNS propagation
/// grace period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviousDkimKey, PreviousDkimKeyFromRaw>))]
public sealed record class PreviousDkimKey : JsonModel
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

    public required string Selector {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "selector"
            );
        }
        init { this._rawData.Set("selector", value); }
    }

    public required ApiEnum<string, PreviousDkimKeyStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreviousDkimKeyStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required long Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "version"
            );
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Selector;
        this.Status.Validate();
        _ = this.Version;
    }

    public PreviousDkimKey ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviousDkimKey (PreviousDkimKey previousDkimKey) : base(
        previousDkimKey
    )
    {  }
    #pragma warning restore CS8618

    public PreviousDkimKey (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviousDkimKey (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PreviousDkimKeyFromRaw.FromRawUnchecked"/>
    public static PreviousDkimKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PreviousDkimKeyFromRaw : IFromRawJson<PreviousDkimKey>
{
    /// <inheritdoc/>
    public PreviousDkimKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PreviousDkimKey.FromRawUnchecked(rawData);
}[JsonConverter(typeof(PreviousDkimKeyStatusConverter))]
public enum PreviousDkimKeyStatus
{
    Retiring, Revoked
}sealed class PreviousDkimKeyStatusConverter : JsonConverter<PreviousDkimKeyStatus>
{
    public override PreviousDkimKeyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retiring"=>PreviousDkimKeyStatus.Retiring,
            "revoked"=>PreviousDkimKeyStatus.Revoked,
            _ =>(PreviousDkimKeyStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviousDkimKeyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PreviousDkimKeyStatus.Retiring=>"retiring",
            PreviousDkimKeyStatus.Revoked=>"revoked",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(EmailDomainRotateDkimResponseDataRecordTypeConverter))]
public enum EmailDomainRotateDkimResponseDataRecordType
{
    EmailDomainDkimRotation
}sealed class EmailDomainRotateDkimResponseDataRecordTypeConverter : JsonConverter<EmailDomainRotateDkimResponseDataRecordType>
{
    public override EmailDomainRotateDkimResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_domain_dkim_rotation"=>EmailDomainRotateDkimResponseDataRecordType.EmailDomainDkimRotation,
            _ =>(EmailDomainRotateDkimResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRotateDkimResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainRotateDkimResponseDataRecordType.EmailDomainDkimRotation=>"email_domain_dkim_rotation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}