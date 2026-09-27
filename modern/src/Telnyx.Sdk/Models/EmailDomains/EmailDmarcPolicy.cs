using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

/// <summary>
/// DMARC policy for a sending domain. Drives the recommended _dmarc.&lt;domain&gt;
/// TXT record. DMARC is advisory and never blocks sending. When omitted or null,
/// the domain uses the advisory default (v=DMARC1; p=none; rua=mailto:dmarc@telnyx.com).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDmarcPolicy, EmailDmarcPolicyFromRaw>))]
public sealed record class EmailDmarcPolicy : JsonModel
{
    /// <summary>
    /// Policy applied to messages that fail alignment.
    /// </summary>
    public ApiEnum<string, P>? P {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, P>>(
                "p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("p", value);
        }
    }

    /// <summary>
    /// Percentage of messages the policy applies to. Omitted from the record when 100.
    /// </summary>
    public long? Pct {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "pct"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pct", value);
        }
    }

    /// <summary>
    /// URI for aggregate reports. Defaults to the Telnyx address when absent; null
    /// omits it.
    /// </summary>
    public string? Rua {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rua"
            );
        }
        init { this._rawData.Set("rua", value); }
    }

    /// <summary>
    /// Policy for subdomains. Omitted from the record when null.
    /// </summary>
    public ApiEnum<string, Sp>? Sp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Sp>>(
                "sp"
            );
        }
        init { this._rawData.Set("sp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.P?.Validate();
        _ = this.Pct;
        _ = this.Rua;
        this.Sp?.Validate();
    }

    public EmailDmarcPolicy ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDmarcPolicy (EmailDmarcPolicy emailDmarcPolicy) : base(
        emailDmarcPolicy
    )
    {  }
    #pragma warning restore CS8618

    public EmailDmarcPolicy (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDmarcPolicy (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDmarcPolicyFromRaw.FromRawUnchecked"/>
    public static EmailDmarcPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDmarcPolicyFromRaw : IFromRawJson<EmailDmarcPolicy>
{
    /// <inheritdoc/>
    public EmailDmarcPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDmarcPolicy.FromRawUnchecked(rawData);
}

/// <summary>
/// Policy applied to messages that fail alignment.
/// </summary>
[JsonConverter(typeof(PConverter))]
public enum P
{
    None, Quarantine, Reject
}sealed class PConverter : JsonConverter<P>
{
    public override P Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>P.None,
            "quarantine"=>P.Quarantine,
            "reject"=>P.Reject,
            _ =>(P)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, P value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            P.None=>"none",
            P.Quarantine=>"quarantine",
            P.Reject=>"reject",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Policy for subdomains. Omitted from the record when null.
/// </summary>
[JsonConverter(typeof(SpConverter))]
public enum Sp
{
    None, Quarantine, Reject
}sealed class SpConverter : JsonConverter<Sp>
{
    public override Sp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>Sp.None,
            "quarantine"=>Sp.Quarantine,
            "reject"=>Sp.Reject,
            _ =>(Sp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sp value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sp.None=>"none",
            Sp.Quarantine=>"quarantine",
            Sp.Reject=>"reject",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}