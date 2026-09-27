using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentConfiguration, AgentConfigurationFromRaw>))]
public sealed record class AgentConfiguration : JsonModel
{
    /// <summary>
    /// Basic agent identity and contact information. At least one complete phone,
    /// website, or email contact is required.
    /// </summary>
    public required Basics Basics {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Basics>(
                "basics"
            );
        }
        init { this._rawData.Set("basics", value); }
    }

    public AgentCampaignConfiguration? Campaign {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentCampaignConfiguration>(
                "campaign"
            );
        }
        init { this._rawData.Set("campaign", value); }
    }

    public AgentTestingConfiguration? Testing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentTestingConfiguration>(
                "testing"
            );
        }
        init { this._rawData.Set("testing", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Basics.Validate();
        this.Campaign?.Validate();
        this.Testing?.Validate();
    }

    public AgentConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentConfiguration (AgentConfiguration agentConfiguration) : base(
        agentConfiguration
    )
    {  }
    #pragma warning restore CS8618

    public AgentConfiguration (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentConfigurationFromRaw.FromRawUnchecked"/>
    public static AgentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentConfiguration (Basics basics) : this()
    { this.Basics = basics; }
}

class AgentConfigurationFromRaw : IFromRawJson<AgentConfiguration>
{
    /// <inheritdoc/>
    public AgentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Basic agent identity and contact information. At least one complete phone, website,
/// or email contact is required.
/// </summary>
[JsonConverter(typeof(BasicsConverter))]
public record class Basics : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public AgentPhoneContact? PhoneNumber {
        get {
            return Match<AgentPhoneContact?>(agentPhoneContactRequirement: ( x )=>x.PhoneNumber,
            agentWebhookContactRequirement: ( x )=>x.PhoneNumber,
            agentProfileContactRequirement: ( x )=>x.PhoneNumber);
        }
    }

    public string? BrandColor {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.BrandColor,
            agentWebhookContactRequirement: ( x )=>x.BrandColor,
            agentProfileContactRequirement: ( x )=>x.BrandColor);
        }
    }

    public string? Description {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.Description,
            agentWebhookContactRequirement: ( x )=>x.Description,
            agentProfileContactRequirement: ( x )=>x.Description);
        }
    }

    public AgentEmailContact? Email {
        get {
            return Match<AgentEmailContact?>(agentPhoneContactRequirement: ( x )=>x.Email,
            agentWebhookContactRequirement: ( x )=>x.Email,
            agentProfileContactRequirement: ( x )=>x.Email);
        }
    }

    public string? HeroUrl {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.HeroUrl,
            agentWebhookContactRequirement: ( x )=>x.HeroUrl,
            agentProfileContactRequirement: ( x )=>x.HeroUrl);
        }
    }

    public string? LogoUrl {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.LogoUrl,
            agentWebhookContactRequirement: ( x )=>x.LogoUrl,
            agentProfileContactRequirement: ( x )=>x.LogoUrl);
        }
    }

    public string? PrivacyPolicyUrl {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.PrivacyPolicyUrl,
            agentWebhookContactRequirement: ( x )=>x.PrivacyPolicyUrl,
            agentProfileContactRequirement: ( x )=>x.PrivacyPolicyUrl);
        }
    }

    public string? TermsAndConditionsUrl {
        get {
            return Match<string?>(agentPhoneContactRequirement: ( x )=>x.TermsAndConditionsUrl,
            agentWebhookContactRequirement: ( x )=>x.TermsAndConditionsUrl,
            agentProfileContactRequirement: ( x )=>x.TermsAndConditionsUrl);
        }
    }

    public AgentWebsiteContact? Website {
        get {
            return Match<AgentWebsiteContact?>(agentPhoneContactRequirement: ( x )=>x.Website,
            agentWebhookContactRequirement: ( x )=>x.Website,
            agentProfileContactRequirement: ( x )=>x.Website);
        }
    }

    public Basics (
        AgentPhoneContactRequirement value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Basics (
        AgentWebhookContactRequirement value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Basics (
        AgentProfileContactRequirement value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Basics (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AgentPhoneContactRequirement"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAgentPhoneContactRequirement(out var value)) {
///     // `value` is of type `AgentPhoneContactRequirement`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAgentPhoneContactRequirement(
        [NotNullWhen(true)] out AgentPhoneContactRequirement? value
    )
    {
        value =this.Value as AgentPhoneContactRequirement ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AgentWebhookContactRequirement"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAgentWebhookContactRequirement(out var value)) {
///     // `value` is of type `AgentWebhookContactRequirement`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAgentWebhookContactRequirement(
        [NotNullWhen(true)] out AgentWebhookContactRequirement? value
    )
    {
        value =this.Value as AgentWebhookContactRequirement ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AgentProfileContactRequirement"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAgentProfileContactRequirement(out var value)) {
///     // `value` is of type `AgentProfileContactRequirement`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAgentProfileContactRequirement(
        [NotNullWhen(true)] out AgentProfileContactRequirement? value
    )
    {
        value =this.Value as AgentProfileContactRequirement ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (AgentPhoneContactRequirement value) =&gt; {...},
///     (AgentWebhookContactRequirement value) =&gt; {...},
///     (AgentProfileContactRequirement value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<AgentPhoneContactRequirement> agentPhoneContactRequirement,
        System::Action<AgentWebhookContactRequirement> agentWebhookContactRequirement,
        System::Action<AgentProfileContactRequirement> agentProfileContactRequirement
    )
    {
        switch (this.Value)
        {
            case AgentPhoneContactRequirement value:
                agentPhoneContactRequirement(value);
                break;
            case AgentWebhookContactRequirement value:
                agentWebhookContactRequirement(value);
                break;
            case AgentProfileContactRequirement value:
                agentProfileContactRequirement(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Basics");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (AgentPhoneContactRequirement value) =&gt; {...},
///     (AgentWebhookContactRequirement value) =&gt; {...},
///     (AgentProfileContactRequirement value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<AgentPhoneContactRequirement, T> agentPhoneContactRequirement,
        System::Func<AgentWebhookContactRequirement, T> agentWebhookContactRequirement,
        System::Func<AgentProfileContactRequirement, T> agentProfileContactRequirement
    )
    {
        return this.Value switch
        {
            AgentPhoneContactRequirement value=>agentPhoneContactRequirement(value),
            AgentWebhookContactRequirement value=>agentWebhookContactRequirement(value),
            AgentProfileContactRequirement value=>agentProfileContactRequirement(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Basics")
        } ;
    }

    public static implicit operator Basics (
        AgentPhoneContactRequirement value
    )=> new(value) ;

    public static implicit operator Basics (
        AgentWebhookContactRequirement value
    )=> new(value) ;

    public static implicit operator Basics (
        AgentProfileContactRequirement value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Basics");
        }
        this.Switch((agentPhoneContactRequirement) => agentPhoneContactRequirement.Validate(),
        (agentWebhookContactRequirement) => agentWebhookContactRequirement.Validate(),
        (agentProfileContactRequirement) => agentProfileContactRequirement.Validate());
    }

    public virtual bool Equals(Basics? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            AgentPhoneContactRequirement _=>0,
            AgentWebhookContactRequirement _=>1,
            AgentProfileContactRequirement _=>2,
            _ =>-1
        } ;
    }
}sealed class BasicsConverter : JsonConverter<Basics>
{
    public override Basics? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<AgentPhoneContactRequirement>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AgentWebhookContactRequirement>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AgentProfileContactRequirement>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Basics value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<AgentPhoneContactRequirement, AgentPhoneContactRequirementFromRaw>))]
public sealed record class AgentPhoneContactRequirement : JsonModel
{
    public required AgentPhoneContact PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentPhoneContact>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? BrandColor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brand_color"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brand_color", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public AgentEmailContact? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentEmailContact>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public string? HeroUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hero_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hero_url", value);
        }
    }

    public string? LogoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logo_url", value);
        }
    }

    public string? PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacy_policy_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacy_policy_url", value);
        }
    }

    public string? TermsAndConditionsUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "terms_and_conditions_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("terms_and_conditions_url", value);
        }
    }

    public AgentWebsiteContact? Website {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentWebsiteContact>(
                "website"
            );
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PhoneNumber.Validate();
        _ = this.BrandColor;
        _ = this.Description;
        this.Email?.Validate();
        _ = this.HeroUrl;
        _ = this.LogoUrl;
        _ = this.PrivacyPolicyUrl;
        _ = this.TermsAndConditionsUrl;
        this.Website?.Validate();
    }

    public AgentPhoneContactRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentPhoneContactRequirement (
        AgentPhoneContactRequirement agentPhoneContactRequirement
    ) : base(agentPhoneContactRequirement)
    {  }
    #pragma warning restore CS8618

    public AgentPhoneContactRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentPhoneContactRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentPhoneContactRequirementFromRaw.FromRawUnchecked"/>
    public static AgentPhoneContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentPhoneContactRequirement (AgentPhoneContact phoneNumber) : this()
    { this.PhoneNumber = phoneNumber; }
}class AgentPhoneContactRequirementFromRaw : IFromRawJson<AgentPhoneContactRequirement>
{
    /// <inheritdoc/>
    public AgentPhoneContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentPhoneContactRequirement.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<AgentWebhookContactRequirement, AgentWebhookContactRequirementFromRaw>))]
public sealed record class AgentWebhookContactRequirement : JsonModel
{
    public required AgentWebsiteContact Website {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentWebsiteContact>(
                "website"
            );
        }
        init { this._rawData.Set("website", value); }
    }

    public string? BrandColor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brand_color"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brand_color", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public AgentEmailContact? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentEmailContact>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public string? HeroUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hero_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hero_url", value);
        }
    }

    public string? LogoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logo_url", value);
        }
    }

    public AgentPhoneContact? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentPhoneContact>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacy_policy_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacy_policy_url", value);
        }
    }

    public string? TermsAndConditionsUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "terms_and_conditions_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("terms_and_conditions_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Website.Validate();
        _ = this.BrandColor;
        _ = this.Description;
        this.Email?.Validate();
        _ = this.HeroUrl;
        _ = this.LogoUrl;
        this.PhoneNumber?.Validate();
        _ = this.PrivacyPolicyUrl;
        _ = this.TermsAndConditionsUrl;
    }

    public AgentWebhookContactRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentWebhookContactRequirement (
        AgentWebhookContactRequirement agentWebhookContactRequirement
    ) : base(agentWebhookContactRequirement)
    {  }
    #pragma warning restore CS8618

    public AgentWebhookContactRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentWebhookContactRequirement (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentWebhookContactRequirementFromRaw.FromRawUnchecked"/>
    public static AgentWebhookContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentWebhookContactRequirement (AgentWebsiteContact website) : this()
    { this.Website = website; }
}class AgentWebhookContactRequirementFromRaw : IFromRawJson<AgentWebhookContactRequirement>
{
    /// <inheritdoc/>
    public AgentWebhookContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentWebhookContactRequirement.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<AgentProfileContactRequirement, AgentProfileContactRequirementFromRaw>))]
public sealed record class AgentProfileContactRequirement : JsonModel
{
    public required AgentEmailContact Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentEmailContact>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public string? BrandColor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brand_color"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brand_color", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? HeroUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hero_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hero_url", value);
        }
    }

    public string? LogoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logo_url", value);
        }
    }

    public AgentPhoneContact? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentPhoneContact>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "privacy_policy_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("privacy_policy_url", value);
        }
    }

    public string? TermsAndConditionsUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "terms_and_conditions_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("terms_and_conditions_url", value);
        }
    }

    public AgentWebsiteContact? Website {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentWebsiteContact>(
                "website"
            );
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Email.Validate();
        _ = this.BrandColor;
        _ = this.Description;
        _ = this.HeroUrl;
        _ = this.LogoUrl;
        this.PhoneNumber?.Validate();
        _ = this.PrivacyPolicyUrl;
        _ = this.TermsAndConditionsUrl;
        this.Website?.Validate();
    }

    public AgentProfileContactRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentProfileContactRequirement (
        AgentProfileContactRequirement agentProfileContactRequirement
    ) : base(agentProfileContactRequirement)
    {  }
    #pragma warning restore CS8618

    public AgentProfileContactRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentProfileContactRequirement (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentProfileContactRequirementFromRaw.FromRawUnchecked"/>
    public static AgentProfileContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AgentProfileContactRequirement (AgentEmailContact email) : this()
    { this.Email = email; }
}class AgentProfileContactRequirementFromRaw : IFromRawJson<AgentProfileContactRequirement>
{
    /// <inheritdoc/>
    public AgentProfileContactRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentProfileContactRequirement.FromRawUnchecked(rawData);
}