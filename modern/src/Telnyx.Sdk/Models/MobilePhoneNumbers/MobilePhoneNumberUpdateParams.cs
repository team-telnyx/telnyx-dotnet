using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers;

/// <summary>
/// Update the settings of a specific mobile phone number.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MobilePhoneNumberUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

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

    public string? ConnectionID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init { this._rawBodyData.Set("connection_id", value); }
    }

    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init { this._rawBodyData.Set("customer_reference", value); }
    }

    public Inbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Inbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inbound", value);
        }
    }

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

    public bool? NoiseSuppression {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "noise_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("noise_suppression", value);
        }
    }

    public Outbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Outbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("outbound", value);
        }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MobilePhoneNumberUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberUpdateParams (
        MobilePhoneNumberUpdateParams mobilePhoneNumberUpdateParams
    ) : base(mobilePhoneNumberUpdateParams)
    {
        this.ID = mobilePhoneNumberUpdateParams.ID;

        this._rawBodyData = new(mobilePhoneNumberUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public MobilePhoneNumberUpdateParams (
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
    MobilePhoneNumberUpdateParams (
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
    public static MobilePhoneNumberUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(MobilePhoneNumberUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v2/mobile_phone_numbers/{0}",
            this.ID)
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

[JsonConverter(typeof(JsonModelConverter<CallForwarding, CallForwardingFromRaw>))]
public sealed record class CallForwarding : JsonModel
{
    public bool? CallForwardingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_forwarding_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_forwarding_enabled", value);
        }
    }

    public ApiEnum<string, ForwardingType>? ForwardingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ForwardingType>>(
                "forwarding_type"
            );
        }
        init { this._rawData.Set("forwarding_type", value); }
    }

    public string? ForwardsTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "forwards_to"
            );
        }
        init { this._rawData.Set("forwards_to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallForwardingEnabled;
        this.ForwardingType?.Validate();
        _ = this.ForwardsTo;
    }

    public CallForwarding ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForwarding (CallForwarding callForwarding) : base(callForwarding)
    {  }
    #pragma warning restore CS8618

    public CallForwarding (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForwarding (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForwardingFromRaw.FromRawUnchecked"/>
    public static CallForwarding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallForwardingFromRaw : IFromRawJson<CallForwarding>
{
    /// <inheritdoc/>
    public CallForwarding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForwarding.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ForwardingTypeConverter))]
public enum ForwardingType
{
    Always, OnFailure
}

sealed class ForwardingTypeConverter : JsonConverter<ForwardingType>
{
    public override ForwardingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>ForwardingType.Always,
            "on-failure"=>ForwardingType.OnFailure,
            _ =>(ForwardingType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ForwardingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ForwardingType.Always=>"always",
            ForwardingType.OnFailure=>"on-failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CallRecording, CallRecordingFromRaw>))]
public sealed record class CallRecording : JsonModel
{
    public ApiEnum<string, InboundCallRecordingChannels>? InboundCallRecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundCallRecordingChannels>>(
                "inbound_call_recording_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_channels", value);
        }
    }

    public bool? InboundCallRecordingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "inbound_call_recording_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_enabled", value);
        }
    }

    public ApiEnum<string, InboundCallRecordingFormat>? InboundCallRecordingFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundCallRecordingFormat>>(
                "inbound_call_recording_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound_call_recording_format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InboundCallRecordingChannels?.Validate();
        _ = this.InboundCallRecordingEnabled;
        this.InboundCallRecordingFormat?.Validate();
    }

    public CallRecording ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecording (CallRecording callRecording) : base(callRecording)
    {  }
    #pragma warning restore CS8618

    public CallRecording (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecording (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingFromRaw.FromRawUnchecked"/>
    public static CallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingFromRaw : IFromRawJson<CallRecording>
{
    /// <inheritdoc/>
    public CallRecording FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecording.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InboundCallRecordingChannelsConverter))]
public enum InboundCallRecordingChannels
{
    Single, Dual
}

sealed class InboundCallRecordingChannelsConverter : JsonConverter<InboundCallRecordingChannels>
{
    public override InboundCallRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>InboundCallRecordingChannels.Single,
            "dual"=>InboundCallRecordingChannels.Dual,
            _ =>(InboundCallRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallRecordingChannels.Single=>"single",
            InboundCallRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(InboundCallRecordingFormatConverter))]
public enum InboundCallRecordingFormat
{
    Wav, Mp3
}

sealed class InboundCallRecordingFormatConverter : JsonConverter<InboundCallRecordingFormat>
{
    public override InboundCallRecordingFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>InboundCallRecordingFormat.Wav,
            "mp3"=>InboundCallRecordingFormat.Mp3,
            _ =>(InboundCallRecordingFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundCallRecordingFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundCallRecordingFormat.Wav=>"wav",
            InboundCallRecordingFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CnamListing, CnamListingFromRaw>))]
public sealed record class CnamListing : JsonModel
{
    public string? CnamListingDetails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cnam_listing_details"
            );
        }
        init { this._rawData.Set("cnam_listing_details", value); }
    }

    public bool? CnamListingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "cnam_listing_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cnam_listing_enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CnamListingDetails;
        _ = this.CnamListingEnabled;
    }

    public CnamListing ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CnamListing (CnamListing cnamListing) : base(cnamListing)
    {  }
    #pragma warning restore CS8618

    public CnamListing (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CnamListing (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CnamListingFromRaw.FromRawUnchecked"/>
    public static CnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CnamListingFromRaw : IFromRawJson<CnamListing>
{
    /// <inheritdoc/>
    public CnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CnamListing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
{
    /// <summary>
    /// The ID of the CallControl or TeXML Application that will intercept inbound calls.
    /// </summary>
    public string? InterceptionAppID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_id"
            );
        }
        init { this._rawData.Set("interception_app_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.InterceptionAppID; }

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
}

class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Inbound.FromRawUnchecked(rawData);
}

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

[JsonConverter(typeof(JsonModelConverter<Outbound, OutboundFromRaw>))]
public sealed record class Outbound : JsonModel
{
    /// <summary>
    /// The ID of the CallControl or TeXML Application that will intercept outbound calls.
    /// </summary>
    public string? InterceptionAppID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "interception_app_id"
            );
        }
        init { this._rawData.Set("interception_app_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.InterceptionAppID; }

    public Outbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Outbound (Outbound outbound) : base(outbound)
    {  }
    #pragma warning restore CS8618

    public Outbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Outbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundFromRaw.FromRawUnchecked"/>
    public static Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundFromRaw : IFromRawJson<Outbound>
{
    /// <inheritdoc/>
    public Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Outbound.FromRawUnchecked(rawData);
}