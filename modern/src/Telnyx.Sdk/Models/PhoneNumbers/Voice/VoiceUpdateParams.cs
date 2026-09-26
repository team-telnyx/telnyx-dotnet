using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

/// <summary>
/// Updates the voice configuration for the specified phone number. The response contains
/// the phone number with its updated voice settings.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The call forwarding settings for a phone number.
    /// </summary>
    public CallForwarding? CallForwarding {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallForwarding>(
                "call_forwarding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_forwarding", value);
        }
    }

    /// <summary>
    /// The call recording settings for a phone number.
    /// </summary>
    public CallRecording? CallRecording {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallRecording>(
                "call_recording"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_recording", value);
        }
    }

    /// <summary>
    /// Controls whether the caller ID name is enabled for this phone number.
    /// </summary>
    public bool? CallerIDNameEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "caller_id_name_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("caller_id_name_enabled", value);
        }
    }

    /// <summary>
    /// The CNAM listing settings for a phone number.
    /// </summary>
    public CnamListing? CnamListing {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CnamListing>(
                "cnam_listing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("cnam_listing", value);
        }
    }

    /// <summary>
    /// The inbound_call_screening setting is a phone number configuration option
    /// variable that allows users to configure their settings to block or flag fraudulent
    /// calls. It can be set to disabled, reject_calls, or flag_calls. This feature
    /// has an additional per-number monthly cost associated with it.
    /// </summary>
    public ApiEnum<string, InboundCallScreening>? InboundCallScreening {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InboundCallScreening>>(
                "inbound_call_screening"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inbound_call_screening", value);
        }
    }

    /// <summary>
    /// The media features settings for a phone number.
    /// </summary>
    public MediaFeatures? MediaFeatures {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MediaFeatures>(
                "media_features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_features", value);
        }
    }

    /// <summary>
    /// Controls whether a tech prefix is enabled for this phone number.
    /// </summary>
    public bool? TechPrefixEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "tech_prefix_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tech_prefix_enabled", value);
        }
    }

    /// <summary>
    /// This field allows you to rewrite the destination number of an inbound call
    /// before the call is routed to you. The value of this field may be any alphanumeric
    /// value, and the value will replace the number originally dialed.
    /// </summary>
    public string? TranslatedNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "translated_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("translated_number", value);
        }
    }

    /// <summary>
    /// Controls whether a number is billed per minute or uses your concurrent channels.
    /// </summary>
    public ApiEnum<string, UsagePaymentMethod>? UsagePaymentMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UsagePaymentMethod>>(
                "usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("usage_payment_method", value);
        }
    }

    public VoiceUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceUpdateParams (VoiceUpdateParams voiceUpdateParams) : base(
        voiceUpdateParams
    )
    {
        this.ID = voiceUpdateParams.ID;

        this._rawBodyData = new(voiceUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public VoiceUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoiceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VoiceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/phone_numbers/{0}/voice",
            EncodePathSegment(this.ID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// The inbound_call_screening setting is a phone number configuration option variable
/// that allows users to configure their settings to block or flag fraudulent calls.
/// It can be set to disabled, reject_calls, or flag_calls. This feature has an additional
/// per-number monthly cost associated with it.
/// </summary>
[JsonConverter(typeof(InboundCallScreeningConverter))]
public enum InboundCallScreening
{
    Disabled, RejectCalls, FlagCalls
}

sealed class InboundCallScreeningConverter : JsonConverter<InboundCallScreening>
{
    public override InboundCallScreening Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>InboundCallScreening.Disabled,
            "reject_calls"=>InboundCallScreening.RejectCalls,
            "flag_calls"=>InboundCallScreening.FlagCalls,
            _ =>(InboundCallScreening)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallScreening value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallScreening.Disabled=>"disabled",
            InboundCallScreening.RejectCalls=>"reject_calls",
            InboundCallScreening.FlagCalls=>"flag_calls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Controls whether a number is billed per minute or uses your concurrent channels.
/// </summary>
[JsonConverter(typeof(UsagePaymentMethodConverter))]
public enum UsagePaymentMethod
{
    PayPerMinute, Channel
}

sealed class UsagePaymentMethodConverter : JsonConverter<UsagePaymentMethod>
{
    public override UsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pay-per-minute"=>UsagePaymentMethod.PayPerMinute,
            "channel"=>UsagePaymentMethod.Channel,
            _ =>(UsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UsagePaymentMethod.PayPerMinute=>"pay-per-minute",
            UsagePaymentMethod.Channel=>"channel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}