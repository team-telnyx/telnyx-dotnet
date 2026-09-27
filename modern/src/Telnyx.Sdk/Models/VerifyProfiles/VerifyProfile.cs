using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VerifyProfiles;

[JsonConverter(typeof(JsonModelConverter<VerifyProfile, VerifyProfileFromRaw>))]
public sealed record class VerifyProfile : JsonModel
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

    public VerifyProfileCall? Call {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfileCall>(
                "call"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call", value);
        }
    }

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
    /// The maximum daily spend allowed on this verify profile, in USD.
    /// </summary>
    public double? DailySpendLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Whether the daily spend limit is enforced for this verify profile.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit_enabled", value);
        }
    }

    public VerifyProfileFlashcall? Flashcall {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfileFlashcall>(
                "flashcall"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("flashcall", value);
        }
    }

    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The possible verification profile record types.
    /// </summary>
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

    public VerifyProfileSms? Sms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfileSms>(
                "sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sms", value);
        }
    }

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

    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_failover_url", value);
        }
    }

    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    public VerifyProfileWhatsapp? Whatsapp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfileWhatsapp>(
                "whatsapp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Call?.Validate();
        _ = this.CreatedAt;
        _ = this.DailySpendLimit;
        _ = this.DailySpendLimitEnabled;
        this.Flashcall?.Validate();
        _ = this.Language;
        _ = this.Name;
        this.RecordType?.Validate();
        this.Sms?.Validate();
        _ = this.UpdatedAt;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
        this.Whatsapp?.Validate();
    }

    public VerifyProfile ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfile (VerifyProfile verifyProfile) : base(verifyProfile)
    {  }
    #pragma warning restore CS8618

    public VerifyProfile (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfile (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileFromRaw.FromRawUnchecked"/>
    public static VerifyProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifyProfileFromRaw : IFromRawJson<VerifyProfile>
{
    /// <inheritdoc/>
    public VerifyProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfile.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VerifyProfileCall, VerifyProfileCallFromRaw>))]
public sealed record class VerifyProfileCall : JsonModel
{
    /// <summary>
    /// The name that identifies the application requesting 2fa in the verification message.
    /// </summary>
    public string? AppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "app_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("app_name", value);
        }
    }

    /// <summary>
    /// The length of the verify code to generate.
    /// </summary>
    public long? CodeLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "code_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code_length", value);
        }
    }

    /// <summary>
    /// For every request that is initiated via this Verify profile, this sets the
    /// number of seconds before a verification request code expires. Once the verification
    /// request expires, the user cannot use the code to verify their identity.
    /// </summary>
    public long? DefaultVerificationTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "default_verification_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_verification_timeout_secs", value);
        }
    }

    /// <summary>
    /// The message template identifier selected from /verify_profiles/templates
    /// </summary>
    public string? MessagingTemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_template_id", value);
        }
    }

    /// <summary>
    /// Enabled country destinations to send verification codes. The elements in
    /// the list must be valid ISO 3166-1 alpha-2 country codes. If set to `["*"]`,
    /// all destinations will be allowed. **Conditionally required:** this field must
    /// be provided when your organization is configured to require explicit whitelisted
    /// destinations; otherwise it is optional.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppName;
        _ = this.CodeLength;
        _ = this.DefaultVerificationTimeoutSecs;
        _ = this.MessagingTemplateID;
        _ = this.WhitelistedDestinations;
    }

    public VerifyProfileCall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileCall (VerifyProfileCall verifyProfileCall) : base(
        verifyProfileCall
    )
    {  }
    #pragma warning restore CS8618

    public VerifyProfileCall (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileCall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileCallFromRaw.FromRawUnchecked"/>
    public static VerifyProfileCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VerifyProfileCallFromRaw : IFromRawJson<VerifyProfileCall>
{
    /// <inheritdoc/>
    public VerifyProfileCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileCall.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<VerifyProfileFlashcall, VerifyProfileFlashcallFromRaw>))]
public sealed record class VerifyProfileFlashcall : JsonModel
{
    /// <summary>
    /// The name that identifies the application requesting 2fa in the verification message.
    /// </summary>
    public string? AppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "app_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("app_name", value);
        }
    }

    /// <summary>
    /// For every request that is initiated via this Verify profile, this sets the
    /// number of seconds before a verification request code expires. Once the verification
    /// request expires, the user cannot use the code to verify their identity.
    /// </summary>
    public long? DefaultVerificationTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "default_verification_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_verification_timeout_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppName;
        _ = this.DefaultVerificationTimeoutSecs;
    }

    public VerifyProfileFlashcall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileFlashcall (
        VerifyProfileFlashcall verifyProfileFlashcall
    ) : base(verifyProfileFlashcall)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileFlashcall (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileFlashcall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileFlashcallFromRaw.FromRawUnchecked"/>
    public static VerifyProfileFlashcall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VerifyProfileFlashcallFromRaw : IFromRawJson<VerifyProfileFlashcall>
{
    /// <inheritdoc/>
    public VerifyProfileFlashcall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileFlashcall.FromRawUnchecked(rawData);
}/// <summary>
/// The possible verification profile record types.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    VerificationProfile
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
            "verification_profile"=>RecordType.VerificationProfile,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.VerificationProfile=>"verification_profile",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<VerifyProfileSms, VerifyProfileSmsFromRaw>))]
public sealed record class VerifyProfileSms : JsonModel
{
    /// <summary>
    /// The alphanumeric sender ID to use when sending to destinations that require
    /// an alphanumeric sender ID.
    /// </summary>
    public string? AlphaSender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "alpha_sender"
            );
        }
        init { this._rawData.Set("alpha_sender", value); }
    }

    /// <summary>
    /// The name that identifies the application requesting 2fa in the verification message.
    /// </summary>
    public string? AppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "app_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("app_name", value);
        }
    }

    /// <summary>
    /// The length of the verify code to generate.
    /// </summary>
    public long? CodeLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "code_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code_length", value);
        }
    }

    /// <summary>
    /// For every request that is initiated via this Verify profile, this sets the
    /// number of seconds before a verification request code expires. Once the verification
    /// request expires, the user cannot use the code to verify their identity.
    /// </summary>
    public long? DefaultVerificationTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "default_verification_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_verification_timeout_secs", value);
        }
    }

    /// <summary>
    /// The message template identifier selected from /verify_profiles/templates
    /// </summary>
    public string? MessagingTemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_template_id", value);
        }
    }

    /// <summary>
    /// Enabled country destinations to send verification codes. The elements in
    /// the list must be valid ISO 3166-1 alpha-2 country codes. If set to `["*"]`,
    /// all destinations will be allowed. **Conditionally required:** this field must
    /// be provided when your organization is configured to require explicit whitelisted
    /// destinations; otherwise it is optional.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AlphaSender;
        _ = this.AppName;
        _ = this.CodeLength;
        _ = this.DefaultVerificationTimeoutSecs;
        _ = this.MessagingTemplateID;
        _ = this.WhitelistedDestinations;
    }

    public VerifyProfileSms ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileSms (VerifyProfileSms verifyProfileSms) : base(
        verifyProfileSms
    )
    {  }
    #pragma warning restore CS8618

    public VerifyProfileSms (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileSms (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileSmsFromRaw.FromRawUnchecked"/>
    public static VerifyProfileSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VerifyProfileSmsFromRaw : IFromRawJson<VerifyProfileSms>
{
    /// <inheritdoc/>
    public VerifyProfileSms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileSms.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<VerifyProfileWhatsapp, VerifyProfileWhatsappFromRaw>))]
public sealed record class VerifyProfileWhatsapp : JsonModel
{
    /// <summary>
    /// The name that identifies the application requesting 2fa in the verification message.
    /// </summary>
    public string? AppName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "app_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("app_name", value);
        }
    }

    /// <summary>
    /// The length of the verify code to generate.
    /// </summary>
    public long? CodeLength {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "code_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code_length", value);
        }
    }

    /// <summary>
    /// For every request that is initiated via this Verify profile, this sets the
    /// number of seconds before a verification request code expires. Once the verification
    /// request expires, the user cannot use the code to verify their identity.
    /// </summary>
    public long? DefaultVerificationTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "default_verification_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_verification_timeout_secs", value);
        }
    }

    /// <summary>
    /// The message template identifier selected from /verify_profiles/templates
    /// </summary>
    public string? MessagingTemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_template_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_template_id", value);
        }
    }

    /// <summary>
    /// Phone number registered on the customer WABA to send OTPs from
    /// </summary>
    public string? SenderPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sender_phone_number"
            );
        }
        init { this._rawData.Set("sender_phone_number", value); }
    }

    /// <summary>
    /// Customer pre-approved authentication template ID registered on Meta
    /// </summary>
    public string? TemplateID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "template_id"
            );
        }
        init { this._rawData.Set("template_id", value); }
    }

    /// <summary>
    /// Customer Meta WABA ID for Bring-Your-Own-WABA sending
    /// </summary>
    public string? WabaID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "waba_id"
            );
        }
        init { this._rawData.Set("waba_id", value); }
    }

    /// <summary>
    /// Enabled country destinations to send verification codes. The elements in
    /// the list must be valid ISO 3166-1 alpha-2 country codes. If set to `["*"]`,
    /// all destinations will be allowed. **Conditionally required:** this field must
    /// be provided when your organization is configured to require explicit whitelisted
    /// destinations; otherwise it is optional.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppName;
        _ = this.CodeLength;
        _ = this.DefaultVerificationTimeoutSecs;
        _ = this.MessagingTemplateID;
        _ = this.SenderPhoneNumber;
        _ = this.TemplateID;
        _ = this.WabaID;
        _ = this.WhitelistedDestinations;
    }

    public VerifyProfileWhatsapp ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileWhatsapp (
        VerifyProfileWhatsapp verifyProfileWhatsapp
    ) : base(verifyProfileWhatsapp)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileWhatsapp (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileWhatsapp (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileWhatsappFromRaw.FromRawUnchecked"/>
    public static VerifyProfileWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VerifyProfileWhatsappFromRaw : IFromRawJson<VerifyProfileWhatsapp>
{
    /// <inheritdoc/>
    public VerifyProfileWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileWhatsapp.FromRawUnchecked(rawData);
}