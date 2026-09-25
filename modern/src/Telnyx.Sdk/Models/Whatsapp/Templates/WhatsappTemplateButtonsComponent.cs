using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

/// <summary>
/// Optional interactive buttons. Maximum 3 buttons per template.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappTemplateButtonsComponent, WhatsappTemplateButtonsComponentFromRaw>))]
public sealed record class WhatsappTemplateButtonsComponent : JsonModel
{
    /// <summary>
    /// Array of button objects. Meta supports various combinations of button types.
    /// </summary>
    public required IReadOnlyList<Button> Buttons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Button>>(
                "buttons"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Button>>(
                "buttons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, WhatsappTemplateButtonsComponentType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappTemplateButtonsComponentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Buttons)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public WhatsappTemplateButtonsComponent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappTemplateButtonsComponent (
        WhatsappTemplateButtonsComponent whatsappTemplateButtonsComponent
    ) : base(whatsappTemplateButtonsComponent)
    {  }
    #pragma warning restore CS8618

    public WhatsappTemplateButtonsComponent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappTemplateButtonsComponent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappTemplateButtonsComponentFromRaw.FromRawUnchecked"/>
    public static WhatsappTemplateButtonsComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappTemplateButtonsComponentFromRaw : IFromRawJson<WhatsappTemplateButtonsComponent>
{
    /// <inheritdoc/>
    public WhatsappTemplateButtonsComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappTemplateButtonsComponent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
{
    public required ApiEnum<string, ButtonType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ButtonType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Custom autofill button text for ONE_TAP OTP buttons.
    /// </summary>
    public string? AutofillText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "autofill_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("autofill_text", value);
        }
    }

    /// <summary>
    /// Sample values for URL variable.
    /// </summary>
    public IReadOnlyList<string>? Example {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "example"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "example",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Flow action type for FLOW-type buttons.
    /// </summary>
    public ApiEnum<string, FlowAction>? FlowAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlowAction>>(
                "flow_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("flow_action", value);
        }
    }

    /// <summary>
    /// Flow ID for FLOW-type buttons.
    /// </summary>
    public string? FlowID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "flow_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("flow_id", value);
        }
    }

    /// <summary>
    /// Target screen name for FLOW buttons with navigate action.
    /// </summary>
    public string? NavigateScreen {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "navigate_screen"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("navigate_screen", value);
        }
    }

    public ApiEnum<string, OtpType>? OtpType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OtpType>>(
                "otp_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("otp_type", value);
        }
    }

    /// <summary>
    /// Android package name. Required for ONE_TAP OTP buttons.
    /// </summary>
    public string? PackageName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "package_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("package_name", value);
        }
    }

    /// <summary>
    /// Phone number in E.164 format.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Android app signing key hash. Required for ONE_TAP OTP buttons.
    /// </summary>
    public string? SignatureHash {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "signature_hash"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("signature_hash", value);
        }
    }

    /// <summary>
    /// Button label text. Maximum 25 characters. Required for URL, PHONE_NUMBER,
    /// and QUICK_REPLY buttons. Not required for OTP buttons (Meta supplies the label).
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// URL for URL-type buttons. Supports one variable ({{1}}).
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <summary>
    /// Whether zero-tap terms have been accepted.
    /// </summary>
    public bool? ZeroTapTermsAccepted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "zero_tap_terms_accepted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zero_tap_terms_accepted", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.AutofillText;
        _ = this.Example;
        this.FlowAction?.Validate();
        _ = this.FlowID;
        _ = this.NavigateScreen;
        this.OtpType?.Validate();
        _ = this.PackageName;
        _ = this.PhoneNumber;
        _ = this.SignatureHash;
        _ = this.Text;
        _ = this.Url;
        _ = this.ZeroTapTermsAccepted;
    }

    public Button ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Button (Button button) : base(button)
    {  }
    #pragma warning restore CS8618

    public Button (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Button (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ButtonFromRaw.FromRawUnchecked"/>
    public static Button FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Button (ApiEnum<string, ButtonType> type) : this()
    { this.Type = type; }
}class ButtonFromRaw : IFromRawJson<Button>
{
    /// <inheritdoc/>
    public Button FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Button.FromRawUnchecked(rawData);
}[JsonConverter(typeof(ButtonTypeConverter))]
public enum ButtonType
{
    Url, PhoneNumber, QuickReply, Otp, CopyCode, Flow
}sealed class ButtonTypeConverter : JsonConverter<ButtonType>
{
    public override ButtonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "URL"=>ButtonType.Url,
            "PHONE_NUMBER"=>ButtonType.PhoneNumber,
            "QUICK_REPLY"=>ButtonType.QuickReply,
            "OTP"=>ButtonType.Otp,
            "COPY_CODE"=>ButtonType.CopyCode,
            "FLOW"=>ButtonType.Flow,
            _ =>(ButtonType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ButtonType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ButtonType.Url=>"URL",
            ButtonType.PhoneNumber=>"PHONE_NUMBER",
            ButtonType.QuickReply=>"QUICK_REPLY",
            ButtonType.Otp=>"OTP",
            ButtonType.CopyCode=>"COPY_CODE",
            ButtonType.Flow=>"FLOW",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Flow action type for FLOW-type buttons.
/// </summary>
[JsonConverter(typeof(FlowActionConverter))]
public enum FlowAction
{
    Navigate, DataExchange
}sealed class FlowActionConverter : JsonConverter<FlowAction>
{
    public override FlowAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "navigate"=>FlowAction.Navigate,
            "data_exchange"=>FlowAction.DataExchange,
            _ =>(FlowAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FlowAction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FlowAction.Navigate=>"navigate",
            FlowAction.DataExchange=>"data_exchange",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(OtpTypeConverter))]
public enum OtpType
{
    CopyCode, OneTap
}sealed class OtpTypeConverter : JsonConverter<OtpType>
{
    public override OtpType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COPY_CODE"=>OtpType.CopyCode,
            "ONE_TAP"=>OtpType.OneTap,
            _ =>(OtpType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, OtpType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OtpType.CopyCode=>"COPY_CODE",
            OtpType.OneTap=>"ONE_TAP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappTemplateButtonsComponentTypeConverter))]
public enum WhatsappTemplateButtonsComponentType
{
    Buttons
}sealed class WhatsappTemplateButtonsComponentTypeConverter : JsonConverter<WhatsappTemplateButtonsComponentType>
{
    public override WhatsappTemplateButtonsComponentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BUTTONS"=>WhatsappTemplateButtonsComponentType.Buttons,
            _ =>(WhatsappTemplateButtonsComponentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappTemplateButtonsComponentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappTemplateButtonsComponentType.Buttons=>"BUTTONS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}