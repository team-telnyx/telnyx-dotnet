using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

/// <summary>
/// The call forwarding settings for a phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallForwarding, CallForwardingFromRaw>))]
public sealed record class CallForwarding : JsonModel
{
    /// <summary>
    /// Indicates if call forwarding will be enabled for this number if forwards_to
    /// and forwarding_type are filled in. Defaults to true for backwards compatibility
    /// with APIV1 use of numbers endpoints.
    /// </summary>
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

    /// <summary>
    /// Call forwarding type. 'forwards_to' must be set for this to have an effect.
    /// </summary>
    public ApiEnum<string, ForwardingType>? ForwardingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ForwardingType>>(
                "forwarding_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("forwarding_type", value);
        }
    }

    /// <summary>
    /// The phone number to which inbound calls to this number are forwarded. Inbound
    /// calls will not be forwarded if this field is left blank. If set, must be
    /// a +E.164-formatted phone number.
    /// </summary>
    public string? ForwardsTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "forwards_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("forwards_to", value);
        }
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

/// <summary>
/// Call forwarding type. 'forwards_to' must be set for this to have an effect.
/// </summary>
[JsonConverter(typeof(ForwardingTypeConverter))]
public enum ForwardingType
{
    Always, OnFailure
}sealed class ForwardingTypeConverter : JsonConverter<ForwardingType>
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