using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifyProfiles;

/// <summary>
/// Creates a new Verify profile to associate verifications with.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VerifyProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public Call? Call {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Call>(
                "call"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call", value);
        }
    }

    /// <summary>
    /// The maximum daily spend allowed on this verify profile, in USD.
    /// </summary>
    public double? DailySpendLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Whether the daily spend limit is enforced for this verify profile.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit_enabled", value);
        }
    }

    public Flashcall? Flashcall {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Flashcall>(
                "flashcall"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("flashcall", value);
        }
    }

    public string? Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    public Sms? Sms {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Sms>(
                "sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sms", value);
        }
    }

    public string? WebhookFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_failover_url", value);
        }
    }

    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public VerifyProfileCreateParamsWhatsapp? Whatsapp {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VerifyProfileCreateParamsWhatsapp>(
                "whatsapp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("whatsapp", value);
        }
    }

    public VerifyProfileCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileCreateParams (
        VerifyProfileCreateParams verifyProfileCreateParams
    ) : base(verifyProfileCreateParams)
    { this._rawBodyData = new(verifyProfileCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public VerifyProfileCreateParams (
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
    VerifyProfileCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VerifyProfileCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VerifyProfileCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/verify_profiles"
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

[JsonConverter(typeof(JsonModelConverter<Call, CallFromRaw>))]
public sealed record class Call : JsonModel
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

    public Call ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Call (Call call) : base(call)
    {  }
    #pragma warning restore CS8618

    public Call (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Call (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallFromRaw.FromRawUnchecked"/>
    public static Call FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallFromRaw : IFromRawJson<Call>
{
    /// <inheritdoc/>
    public Call FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Call.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Flashcall, FlashcallFromRaw>))]
public sealed record class Flashcall : JsonModel
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
        _ = this.DefaultVerificationTimeoutSecs;
        _ = this.WhitelistedDestinations;
    }

    public Flashcall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Flashcall (Flashcall flashcall) : base(flashcall)
    {  }
    #pragma warning restore CS8618

    public Flashcall (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Flashcall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FlashcallFromRaw.FromRawUnchecked"/>
    public static Flashcall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FlashcallFromRaw : IFromRawJson<Flashcall>
{
    /// <inheritdoc/>
    public Flashcall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Flashcall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Sms, SmsFromRaw>))]
public sealed record class Sms : JsonModel
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

    public Sms ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sms (Sms sms) : base(sms)
    {  }
    #pragma warning restore CS8618

    public Sms (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Sms (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SmsFromRaw.FromRawUnchecked"/>
    public static Sms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SmsFromRaw : IFromRawJson<Sms>
{
    /// <inheritdoc/>
    public Sms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Sms.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VerifyProfileCreateParamsWhatsapp, VerifyProfileCreateParamsWhatsappFromRaw>))]
public sealed record class VerifyProfileCreateParamsWhatsapp : JsonModel
{
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
        _ = this.DefaultVerificationTimeoutSecs;
        _ = this.SenderPhoneNumber;
        _ = this.TemplateID;
        _ = this.WabaID;
        _ = this.WhitelistedDestinations;
    }

    public VerifyProfileCreateParamsWhatsapp ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileCreateParamsWhatsapp (
        VerifyProfileCreateParamsWhatsapp verifyProfileCreateParamsWhatsapp
    ) : base(verifyProfileCreateParamsWhatsapp)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileCreateParamsWhatsapp (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileCreateParamsWhatsapp (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileCreateParamsWhatsappFromRaw.FromRawUnchecked"/>
    public static VerifyProfileCreateParamsWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifyProfileCreateParamsWhatsappFromRaw : IFromRawJson<VerifyProfileCreateParamsWhatsapp>
{
    /// <inheritdoc/>
    public VerifyProfileCreateParamsWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileCreateParamsWhatsapp.FromRawUnchecked(rawData);
}