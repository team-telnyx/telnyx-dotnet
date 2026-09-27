using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplication, CallControlApplicationFromRaw>))]
public sealed record class CallControlApplication : JsonModel
{
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
    /// Specifies whether the connection can be used.
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// &lt;code&gt;Latency&lt;/code&gt; directs Telnyx to route media through the
    /// site with the lowest round-trip time to the user's connection. Telnyx calculates
    /// this time using ICMP ping messages. This can be disabled by specifying a site
    /// to handle all media.
    /// </summary>
    public ApiEnum<string, CallControlApplicationAnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallControlApplicationAnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// A user-assigned name to help manage the application.
    /// </summary>
    public string? ApplicationName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "application_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("application_name", value);
        }
    }

    /// <summary>
    /// Specifies if call cost webhooks should be sent for this Call Control Application.
    /// </summary>
    public bool? CallCostInWebhooks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_cost_in_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_cost_in_webhooks", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the resource was created
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
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that
    /// DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    public ApiEnum<string, CallControlApplicationDtmfType>? DtmfType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallControlApplicationDtmfType>>(
                "dtmf_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dtmf_type", value);
        }
    }

    /// <summary>
    /// Specifies whether calls to phone numbers associated with this connection
    /// should hangup after timing out.
    /// </summary>
    public bool? FirstCommandTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "first_command_timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_command_timeout", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a dial command.
    /// </summary>
    public long? FirstCommandTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "first_command_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_command_timeout_secs", value);
        }
    }

    public CallControlApplicationInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlApplicationInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound", value);
        }
    }

    public CallControlApplicationOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlApplicationOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// When enabled, DTMF digits entered by users will be redacted in debug logs
    /// to protect PII data entered through IVR interactions.
    /// </summary>
    public bool? RedactDtmfDebugLogging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "redact_dtmf_debug_logging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("redact_dtmf_debug_logging", value);
        }
    }

    /// <summary>
    /// Tags assigned to the Call Control Application.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the resource was last updated
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
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, CallControlApplicationWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallControlApplicationWebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails. Must include a scheme, such as `https`.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent. Must include
    /// a scheme, such as `https`.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_url", value);
        }
    }

    public long? WebhookTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init { this._rawData.Set("webhook_timeout_secs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.AnchorsiteOverride?.Validate();
        _ = this.ApplicationName;
        _ = this.CallCostInWebhooks;
        _ = this.CreatedAt;
        this.DtmfType?.Validate();
        _ = this.FirstCommandTimeout;
        _ = this.FirstCommandTimeoutSecs;
        this.Inbound?.Validate();
        this.Outbound?.Validate();
        this.RecordType?.Validate();
        _ = this.RedactDtmfDebugLogging;
        _ = this.Tags;
        _ = this.UpdatedAt;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public CallControlApplication ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplication (
        CallControlApplication callControlApplication
    ) : base(callControlApplication)
    {  }
    #pragma warning restore CS8618

    public CallControlApplication (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplication (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationFromRaw.FromRawUnchecked"/>
    public static CallControlApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationFromRaw : IFromRawJson<CallControlApplication>
{
    /// <inheritdoc/>
    public CallControlApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplication.FromRawUnchecked(rawData);
}

/// <summary>
/// &lt;code&gt;Latency&lt;/code&gt; directs Telnyx to route media through the site
/// with the lowest round-trip time to the user's connection. Telnyx calculates this
/// time using ICMP ping messages. This can be disabled by specifying a site to handle
/// all media.
/// </summary>
[JsonConverter(typeof(CallControlApplicationAnchorsiteOverrideConverter))]
public enum CallControlApplicationAnchorsiteOverride
{
    Latency,
    ChicagoIl,
    AshburnVa,
    SanJoseCa,
    LondonUk,
    ChennaiIn,
    AmsterdamNetherlands,
    TorontoCanada,
    SydneyAustralia
}sealed class CallControlApplicationAnchorsiteOverrideConverter : JsonConverter<CallControlApplicationAnchorsiteOverride>
{
    public override CallControlApplicationAnchorsiteOverride Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latency"=>CallControlApplicationAnchorsiteOverride.Latency,
            "Chicago, IL"=>CallControlApplicationAnchorsiteOverride.ChicagoIl,
            "Ashburn, VA"=>CallControlApplicationAnchorsiteOverride.AshburnVa,
            "San Jose, CA"=>CallControlApplicationAnchorsiteOverride.SanJoseCa,
            "London, UK"=>CallControlApplicationAnchorsiteOverride.LondonUk,
            "Chennai, IN"=>CallControlApplicationAnchorsiteOverride.ChennaiIn,
            "Amsterdam, Netherlands"=>CallControlApplicationAnchorsiteOverride.AmsterdamNetherlands,
            "Toronto, Canada"=>CallControlApplicationAnchorsiteOverride.TorontoCanada,
            "Sydney, Australia"=>CallControlApplicationAnchorsiteOverride.SydneyAustralia,
            _ =>(CallControlApplicationAnchorsiteOverride)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallControlApplicationAnchorsiteOverride value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallControlApplicationAnchorsiteOverride.Latency=>"Latency",
            CallControlApplicationAnchorsiteOverride.ChicagoIl=>"Chicago, IL",
            CallControlApplicationAnchorsiteOverride.AshburnVa=>"Ashburn, VA",
            CallControlApplicationAnchorsiteOverride.SanJoseCa=>"San Jose, CA",
            CallControlApplicationAnchorsiteOverride.LondonUk=>"London, UK",
            CallControlApplicationAnchorsiteOverride.ChennaiIn=>"Chennai, IN",
            CallControlApplicationAnchorsiteOverride.AmsterdamNetherlands=>"Amsterdam, Netherlands",
            CallControlApplicationAnchorsiteOverride.TorontoCanada=>"Toronto, Canada",
            CallControlApplicationAnchorsiteOverride.SydneyAustralia=>"Sydney, Australia",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF
/// digits sent to Telnyx will be accepted in all formats.
/// </summary>
[JsonConverter(typeof(CallControlApplicationDtmfTypeConverter))]
public enum CallControlApplicationDtmfType
{
    Rfc2833, Inband, SipInfo
}sealed class CallControlApplicationDtmfTypeConverter : JsonConverter<CallControlApplicationDtmfType>
{
    public override CallControlApplicationDtmfType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RFC 2833"=>CallControlApplicationDtmfType.Rfc2833,
            "Inband"=>CallControlApplicationDtmfType.Inband,
            "SIP INFO"=>CallControlApplicationDtmfType.SipInfo,
            _ =>(CallControlApplicationDtmfType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallControlApplicationDtmfType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallControlApplicationDtmfType.Rfc2833=>"RFC 2833",
            CallControlApplicationDtmfType.Inband=>"Inband",
            CallControlApplicationDtmfType.SipInfo=>"SIP INFO",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    CallControlApplication
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call_control_application"=>RecordType.CallControlApplication,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.CallControlApplication=>"call_control_application",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(CallControlApplicationWebhookApiVersionConverter))]
public enum CallControlApplicationWebhookApiVersion
{
    V1, V2
}sealed class CallControlApplicationWebhookApiVersionConverter : JsonConverter<CallControlApplicationWebhookApiVersion>
{
    public override CallControlApplicationWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>CallControlApplicationWebhookApiVersion.V1,
            "2"=>CallControlApplicationWebhookApiVersion.V2,
            _ =>(CallControlApplicationWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallControlApplicationWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallControlApplicationWebhookApiVersion.V1=>"1",
            CallControlApplicationWebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}