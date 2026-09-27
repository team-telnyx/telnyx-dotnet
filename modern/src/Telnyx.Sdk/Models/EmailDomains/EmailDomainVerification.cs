using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainVerification, EmailDomainVerificationFromRaw>))]
public sealed record class EmailDomainVerification : JsonModel
{
    public required ApiEnum<string, EmailDomainVerificationDkim> Dkim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailDomainVerificationDkim>>(
                "dkim"
            );
        }
        init { this._rawData.Set("dkim", value); }
    }

    public required ApiEnum<string, Dmarc> Dmarc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Dmarc>>(
                "dmarc"
            );
        }
        init { this._rawData.Set("dmarc", value); }
    }

    public required ApiEnum<string, Mx> Mx {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Mx>>(
                "mx"
            );
        }
        init { this._rawData.Set("mx", value); }
    }

    public required ApiEnum<string, Ownership> Ownership {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Ownership>>(
                "ownership"
            );
        }
        init { this._rawData.Set("ownership", value); }
    }

    public required ApiEnum<string, Spf> Spf {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Spf>>(
                "spf"
            );
        }
        init { this._rawData.Set("spf", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Dkim.Validate();
        this.Dmarc.Validate();
        this.Mx.Validate();
        this.Ownership.Validate();
        this.Spf.Validate();
    }

    public EmailDomainVerification ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainVerification (
        EmailDomainVerification emailDomainVerification
    ) : base(emailDomainVerification)
    {  }
    #pragma warning restore CS8618

    public EmailDomainVerification (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainVerification (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainVerificationFromRaw.FromRawUnchecked"/>
    public static EmailDomainVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDomainVerificationFromRaw : IFromRawJson<EmailDomainVerification>
{
    /// <inheritdoc/>
    public EmailDomainVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainVerification.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EmailDomainVerificationDkimConverter))]
public enum EmailDomainVerificationDkim
{
    Pending, Verified, Failed
}sealed class EmailDomainVerificationDkimConverter : JsonConverter<EmailDomainVerificationDkim>
{
    public override EmailDomainVerificationDkim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>EmailDomainVerificationDkim.Pending,
            "verified"=>EmailDomainVerificationDkim.Verified,
            "failed"=>EmailDomainVerificationDkim.Failed,
            _ =>(EmailDomainVerificationDkim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainVerificationDkim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainVerificationDkim.Pending=>"pending",
            EmailDomainVerificationDkim.Verified=>"verified",
            EmailDomainVerificationDkim.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(DmarcConverter))]
public enum Dmarc
{
    MissingOptional, Verified, Failed
}sealed class DmarcConverter : JsonConverter<Dmarc>
{
    public override Dmarc Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "missing_optional"=>Dmarc.MissingOptional,
            "verified"=>Dmarc.Verified,
            "failed"=>Dmarc.Failed,
            _ =>(Dmarc)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Dmarc value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Dmarc.MissingOptional=>"missing_optional",
            Dmarc.Verified=>"verified",
            Dmarc.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MxConverter))]
public enum Mx
{
    NotRequired, Pending, Verified, Failed
}sealed class MxConverter : JsonConverter<Mx>
{
    public override Mx Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_required"=>Mx.NotRequired,
            "pending"=>Mx.Pending,
            "verified"=>Mx.Verified,
            "failed"=>Mx.Failed,
            _ =>(Mx)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Mx value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Mx.NotRequired=>"not_required",
            Mx.Pending=>"pending",
            Mx.Verified=>"verified",
            Mx.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(OwnershipConverter))]
public enum Ownership
{
    Pending, Verified, NotRequired
}sealed class OwnershipConverter : JsonConverter<Ownership>
{
    public override Ownership Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Ownership.Pending,
            "verified"=>Ownership.Verified,
            "not_required"=>Ownership.NotRequired,
            _ =>(Ownership)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Ownership value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Ownership.Pending=>"pending",
            Ownership.Verified=>"verified",
            Ownership.NotRequired=>"not_required",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(SpfConverter))]
public enum Spf
{
    MissingOptional, Verified, Failed, NotRequired
}sealed class SpfConverter : JsonConverter<Spf>
{
    public override Spf Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "missing_optional"=>Spf.MissingOptional,
            "verified"=>Spf.Verified,
            "failed"=>Spf.Failed,
            "not_required"=>Spf.NotRequired,
            _ =>(Spf)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Spf value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Spf.MissingOptional=>"missing_optional",
            Spf.Verified=>"verified",
            Spf.Failed=>"failed",
            Spf.NotRequired=>"not_required",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}