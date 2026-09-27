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

[JsonConverter(typeof(JsonModelConverter<EmailDomain, EmailDomainFromRaw>))]
public sealed record class EmailDomain : JsonModel
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

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required Dkim Dkim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Dkim>(
                "dkim"
            );
        }
        init { this._rawData.Set("dkim", value); }
    }

    /// <summary>
    /// DMARC policy for a sending domain. Drives the recommended _dmarc.&lt;domain&gt;
    /// TXT record. DMARC is advisory and never blocks sending. When omitted or null,
    /// the domain uses the advisory default (v=DMARC1; p=none; rua=mailto:dmarc@telnyx.com).
    /// </summary>
    public required EmailDmarcPolicy? DmarcPolicy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailDmarcPolicy>(
                "dmarc_policy"
            );
        }
        init { this._rawData.Set("dmarc_policy", value); }
    }

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

    public required Inbound Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Inbound>(
                "inbound"
            );
        }
        init { this._rawData.Set("inbound", value); }
    }

    public required ApiEnum<string, EmailDomainRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required ApiEnum<string, EmailDomainStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required DomainsTrackingSettings Tracking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DomainsTrackingSettings>(
                "tracking"
            );
        }
        init { this._rawData.Set("tracking", value); }
    }

    /// <summary>
    /// Domain type. `custom` domains are account-owned (BYOD). `shared` domains are
    /// Telnyx-managed, visible to and usable by ALL accounts for sending, but read-only:
    /// only the owning (system) account may modify, verify, or delete them; other
    /// accounts receive 403 (code 10008).
    /// </summary>
    public required ApiEnum<string, EmailDomainType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public required bool UsableForInbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "usable_for_inbound"
            );
        }
        init { this._rawData.Set("usable_for_inbound", value); }
    }

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

    /// <summary>
    /// Sender reputation for this domain (present on all domain responses).
    /// </summary>
    public EmailDomainReputation? Reputation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmailDomainReputation>(
                "reputation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reputation", value);
        }
    }

    public System::DateTimeOffset? VerifiedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "verified_at"
            );
        }
        init { this._rawData.Set("verified_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Dkim.Validate();
        this.DmarcPolicy?.Validate();
        foreach (var item in this.DnsRecords)
        {
            item.Validate();
        }
        _ = this.Domain;
        this.Inbound.Validate();
        this.RecordType.Validate();
        this.Status.Validate();
        this.Tracking.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.UsableForInbound;
        _ = this.UsableForSending;
        this.Verification.Validate();
        this.Reputation?.Validate();
        _ = this.VerifiedAt;
    }

    public EmailDomain ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomain (EmailDomain emailDomain) : base(emailDomain)
    {  }
    #pragma warning restore CS8618

    public EmailDomain (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomain (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainFromRaw.FromRawUnchecked"/>
    public static EmailDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDomainFromRaw : IFromRawJson<EmailDomain>
{
    /// <inheritdoc/>
    public EmailDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomain.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Dkim, DkimFromRaw>))]
public sealed record class Dkim : JsonModel
{
    public required bool Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "active"
            );
        }
        init { this._rawData.Set("active", value); }
    }

    public required ApiEnum<string, Algorithm>? Algorithm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Algorithm>>(
                "algorithm"
            );
        }
        init { this._rawData.Set("algorithm", value); }
    }

    public required ApiEnum<long, KeyLength>? KeyLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, KeyLength>>(
                "key_length"
            );
        }
        init { this._rawData.Set("key_length", value); }
    }

    public required System::DateTimeOffset? RotatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "rotated_at"
            );
        }
        init { this._rawData.Set("rotated_at", value); }
    }

    public required string? Selector {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "selector"
            );
        }
        init { this._rawData.Set("selector", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        this.Algorithm?.Validate();
        this.KeyLength?.Validate();
        _ = this.RotatedAt;
        _ = this.Selector;
    }

    public Dkim ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dkim (Dkim dkim) : base(dkim)
    {  }
    #pragma warning restore CS8618

    public Dkim (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Dkim (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DkimFromRaw.FromRawUnchecked"/>
    public static Dkim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DkimFromRaw : IFromRawJson<Dkim>
{
    /// <inheritdoc/>
    public Dkim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Dkim.FromRawUnchecked(rawData);
}[JsonConverter(typeof(AlgorithmConverter))]
public enum Algorithm
{
    RsaSha256
}sealed class AlgorithmConverter : JsonConverter<Algorithm>
{
    public override Algorithm Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "rsa-sha256"=>Algorithm.RsaSha256, _ =>(Algorithm)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Algorithm value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Algorithm.RsaSha256=>"rsa-sha256",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(KeyLengthConverter))]
public enum KeyLength
{
    KeyLength2048
}sealed class KeyLengthConverter : JsonConverter<KeyLength>
{
    public override KeyLength Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        { 2048L=>KeyLength.KeyLength2048, _ =>(KeyLength)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, KeyLength value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            KeyLength.KeyLength2048=>2048L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
{
    public required bool CatchAll {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "catch_all"
            );
        }
        init { this._rawData.Set("catch_all", value); }
    }

    public required bool Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "enabled"
            );
        }
        init { this._rawData.Set("enabled", value); }
    }

    public required bool MxRequired {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "mx_required"
            );
        }
        init { this._rawData.Set("mx_required", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CatchAll;
        _ = this.Enabled;
        _ = this.MxRequired;
    }

    public Inbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Inbound (Inbound inbound) : base(inbound)
    {  }
    #pragma warning restore CS8618

    public Inbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Inbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundFromRaw.FromRawUnchecked"/>
    public static Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Inbound.FromRawUnchecked(rawData);
}[JsonConverter(typeof(EmailDomainRecordTypeConverter))]
public enum EmailDomainRecordType
{
    EmailDomain
}sealed class EmailDomainRecordTypeConverter : JsonConverter<EmailDomainRecordType>
{
    public override EmailDomainRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_domain"=>EmailDomainRecordType.EmailDomain,
            _ =>(EmailDomainRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainRecordType.EmailDomain=>"email_domain",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Sender reputation for this domain (present on all domain responses).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDomainReputation, EmailDomainReputationFromRaw>))]
public sealed record class EmailDomainReputation : JsonModel
{
    /// <summary>
    /// Reputation band, e.g. good/warn/poor.
    /// </summary>
    public string? Band {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "band"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("band", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Breakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "breakdown"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "breakdown",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public System::DateTimeOffset? ComputedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "computed_at"
            );
        }
        init { this._rawData.Set("computed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Band;
        _ = this.Breakdown;
        _ = this.ComputedAt;
    }

    public EmailDomainReputation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainReputation (
        EmailDomainReputation emailDomainReputation
    ) : base(emailDomainReputation)
    {  }
    #pragma warning restore CS8618

    public EmailDomainReputation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainReputation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainReputationFromRaw.FromRawUnchecked"/>
    public static EmailDomainReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailDomainReputationFromRaw : IFromRawJson<EmailDomainReputation>
{
    /// <inheritdoc/>
    public EmailDomainReputation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainReputation.FromRawUnchecked(rawData);
}