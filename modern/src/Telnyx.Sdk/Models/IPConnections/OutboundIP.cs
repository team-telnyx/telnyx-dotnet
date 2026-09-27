using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<OutboundIP, OutboundIPFromRaw>))]
public sealed record class OutboundIP : JsonModel
{
    /// <summary>
    /// Set a phone number as the ani_override value to override caller id number
    /// on outbound calls.
    /// </summary>
    public string? AniOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ani_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ani_override", value);
        }
    }

    /// <summary>
    /// Specifies when we apply your ani_override setting. Only applies when ani_override
    /// is not blank.
    /// </summary>
    public ApiEnum<string, AniOverrideType>? AniOverrideType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AniOverrideType>>(
                "ani_override_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ani_override_type", value);
        }
    }

    /// <summary>
    /// Forces all SIP calls originated on this connection to be "parked" instead
    /// of "bridged" to the destination specified on the URI. Parked calls will return
    /// ringback to the caller and will await for a Call Control command to define
    /// which action will be taken next.
    /// </summary>
    public bool? CallParkingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_parking_enabled"
            );
        }
        init { this._rawData.Set("call_parking_enabled", value); }
    }

    /// <summary>
    /// When set, this will limit the total number of outbound calls to phone numbers
    /// associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Generate ringback tone through 183 session progress message with early media.
    /// </summary>
    public bool? GenerateRingbackTone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "generate_ringback_tone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("generate_ringback_tone", value);
        }
    }

    /// <summary>
    /// When set, ringback will not wait for indication before sending ringback tone
    /// to calling party.
    /// </summary>
    public bool? InstantRingbackEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "instant_ringback_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("instant_ringback_enabled", value);
        }
    }

    public ApiEnum<string, IPAuthenticationMethod>? IPAuthenticationMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IPAuthenticationMethod>>(
                "ip_authentication_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_authentication_method", value);
        }
    }

    public string? IPAuthenticationToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_authentication_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_authentication_token", value);
        }
    }

    /// <summary>
    /// A 2-character country code specifying the country whose national dialing
    /// rules should be used. For example, if set to `US` then any US number can be
    /// dialed without preprending +1 to the number. When left blank, Telnyx will
    /// try US and GB dialing rules, in that order, by default.
    /// </summary>
    public string? Localization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "localization"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("localization", value);
        }
    }

    /// <summary>
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound_voice_profile_id", value);
        }
    }

    /// <summary>
    /// This setting only affects connections with Fax-type Outbound Voice Profiles.
    /// The setting dictates whether or not Telnyx sends a t.38 reinvite.&lt;br/&gt;&lt;br/&gt;
    /// By default, Telnyx will send the re-invite. If set to `customer`, the caller
    /// is expected to send the t.38 reinvite.
    /// </summary>
    public ApiEnum<string, T38ReinviteSource>? T38ReinviteSource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, T38ReinviteSource>>(
                "t38_reinvite_source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("t38_reinvite_source", value);
        }
    }

    /// <summary>
    /// Numerical chars only, exactly 4 characters.
    /// </summary>
    public string? TechPrefix {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tech_prefix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tech_prefix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AniOverride;
        this.AniOverrideType?.Validate();
        _ = this.CallParkingEnabled;
        _ = this.ChannelLimit;
        _ = this.GenerateRingbackTone;
        _ = this.InstantRingbackEnabled;
        this.IPAuthenticationMethod?.Validate();
        _ = this.IPAuthenticationToken;
        _ = this.Localization;
        _ = this.OutboundVoiceProfileID;
        this.T38ReinviteSource?.Validate();
        _ = this.TechPrefix;
    }

    public OutboundIP ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundIP (OutboundIP outboundIP) : base(outboundIP)
    {  }
    #pragma warning restore CS8618

    public OutboundIP (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundIP (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundIPFromRaw.FromRawUnchecked"/>
    public static OutboundIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundIPFromRaw : IFromRawJson<OutboundIP>
{
    /// <inheritdoc/>
    public OutboundIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundIP.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies when we apply your ani_override setting. Only applies when ani_override
/// is not blank.
/// </summary>
[JsonConverter(typeof(AniOverrideTypeConverter))]
public enum AniOverrideType
{
    Always, Normal, Emergency
}sealed class AniOverrideTypeConverter : JsonConverter<AniOverrideType>
{
    public override AniOverrideType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>AniOverrideType.Always,
            "normal"=>AniOverrideType.Normal,
            "emergency"=>AniOverrideType.Emergency,
            _ =>(AniOverrideType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AniOverrideType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AniOverrideType.Always=>"always",
            AniOverrideType.Normal=>"normal",
            AniOverrideType.Emergency=>"emergency",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(IPAuthenticationMethodConverter))]
public enum IPAuthenticationMethod
{
    TechPrefixpChargeInfo, Token
}sealed class IPAuthenticationMethodConverter : JsonConverter<IPAuthenticationMethod>
{
    public override IPAuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tech-prefixp-charge-info"=>IPAuthenticationMethod.TechPrefixpChargeInfo,
            "token"=>IPAuthenticationMethod.Token,
            _ =>(IPAuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IPAuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IPAuthenticationMethod.TechPrefixpChargeInfo=>"tech-prefixp-charge-info",
            IPAuthenticationMethod.Token=>"token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// This setting only affects connections with Fax-type Outbound Voice Profiles.
/// The setting dictates whether or not Telnyx sends a t.38 reinvite.&lt;br/&gt;&lt;br/&gt;
/// By default, Telnyx will send the re-invite. If set to `customer`, the caller
/// is expected to send the t.38 reinvite.
/// </summary>
[JsonConverter(typeof(T38ReinviteSourceConverter))]
public enum T38ReinviteSource
{
    Telnyx, Customer, Disabled, Passthru, CallerPassthru, CalleePassthru
}sealed class T38ReinviteSourceConverter : JsonConverter<T38ReinviteSource>
{
    public override T38ReinviteSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>T38ReinviteSource.Telnyx,
            "customer"=>T38ReinviteSource.Customer,
            "disabled"=>T38ReinviteSource.Disabled,
            "passthru"=>T38ReinviteSource.Passthru,
            "caller-passthru"=>T38ReinviteSource.CallerPassthru,
            "callee-passthru"=>T38ReinviteSource.CalleePassthru,
            _ =>(T38ReinviteSource)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        T38ReinviteSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            T38ReinviteSource.Telnyx=>"telnyx",
            T38ReinviteSource.Customer=>"customer",
            T38ReinviteSource.Disabled=>"disabled",
            T38ReinviteSource.Passthru=>"passthru",
            T38ReinviteSource.CallerPassthru=>"caller-passthru",
            T38ReinviteSource.CalleePassthru=>"callee-passthru",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}