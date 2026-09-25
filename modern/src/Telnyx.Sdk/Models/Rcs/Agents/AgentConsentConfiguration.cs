using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentConsentConfiguration, AgentConsentConfigurationFromRaw>))]
public sealed record class AgentConsentConfiguration : JsonModel
{
    public required string CallToAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_to_action"
            );
        }
        init { this._rawData.Set("call_to_action", value); }
    }

    public required bool DoubleOptIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "double_opt_in"
            );
        }
        init { this._rawData.Set("double_opt_in", value); }
    }

    public required string HelpResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "help_response"
            );
        }
        init { this._rawData.Set("help_response", value); }
    }

    public required string OptInMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "opt_in_message"
            );
        }
        init { this._rawData.Set("opt_in_message", value); }
    }

    public required IReadOnlyList<OptInMethod> OptInMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OptInMethod>>(
                "opt_in_methods"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<OptInMethod>>(
                "opt_in_methods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string OptOutResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "opt_out_response"
            );
        }
        init { this._rawData.Set("opt_out_response", value); }
    }

    /// <summary>
    /// Required when an opt-in method is `WEBSITE` or `MOBILE_APP`.
    /// </summary>
    public string? CallToActionMediaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_to_action_media_url"
            );
        }
        init { this._rawData.Set("call_to_action_media_url", value); }
    }

    /// <summary>
    /// Required when an opt-in method is `WEBSITE`.
    /// </summary>
    public string? CallToActionUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_to_action_url"
            );
        }
        init { this._rawData.Set("call_to_action_url", value); }
    }

    /// <summary>
    /// Required when double_opt_in is true.
    /// </summary>
    public string? DoubleOptInMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "double_opt_in_message"
            );
        }
        init { this._rawData.Set("double_opt_in_message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallToAction;
        _ = this.DoubleOptIn;
        _ = this.HelpResponse;
        _ = this.OptInMessage;
        foreach (var item in this.OptInMethods)
        {
            item.Validate();
        }
        _ = this.OptOutResponse;
        _ = this.CallToActionMediaUrl;
        _ = this.CallToActionUrl;
        _ = this.DoubleOptInMessage;
    }

    public AgentConsentConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConsentConfiguration (
        AgentConsentConfiguration agentConsentConfiguration
    ) : base(agentConsentConfiguration)
    {  }
    #pragma warning restore CS8618

    public AgentConsentConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConsentConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentConsentConfigurationFromRaw.FromRawUnchecked"/>
    public static AgentConsentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentConsentConfigurationFromRaw : IFromRawJson<AgentConsentConfiguration>
{
    /// <inheritdoc/>
    public AgentConsentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentConsentConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OptInMethod, OptInMethodFromRaw>))]
public sealed record class OptInMethod : JsonModel
{
    public required ApiEnum<string, MethodType> MethodType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MethodType>>(
                "method_type"
            );
        }
        init { this._rawData.Set("method_type", value); }
    }

    /// <summary>
    /// Required when method_type is `OTHER`.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MethodType.Validate();
        _ = this.Description;
    }

    public OptInMethod ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OptInMethod (OptInMethod optInMethod) : base(optInMethod)
    {  }
    #pragma warning restore CS8618

    public OptInMethod (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OptInMethod (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OptInMethodFromRaw.FromRawUnchecked"/>
    public static OptInMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public OptInMethod (ApiEnum<string, MethodType> methodType) : this()
    { this.MethodType = methodType; }
}class OptInMethodFromRaw : IFromRawJson<OptInMethod>
{
    /// <inheritdoc/>
    public OptInMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OptInMethod.FromRawUnchecked(rawData);
}[JsonConverter(typeof(MethodTypeConverter))]
public enum MethodType
{
    Sms, Website, MobileApp, QrCode, SalePoint, Other
}sealed class MethodTypeConverter : JsonConverter<MethodType>
{
    public override MethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MethodType.Sms,
            "WEBSITE"=>MethodType.Website,
            "MOBILE_APP"=>MethodType.MobileApp,
            "QR_CODE"=>MethodType.QrCode,
            "SALE_POINT"=>MethodType.SalePoint,
            "OTHER"=>MethodType.Other,
            _ =>(MethodType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, MethodType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MethodType.Sms=>"SMS",
            MethodType.Website=>"WEBSITE",
            MethodType.MobileApp=>"MOBILE_APP",
            MethodType.QrCode=>"QR_CODE",
            MethodType.SalePoint=>"SALE_POINT",
            MethodType.Other=>"OTHER",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}