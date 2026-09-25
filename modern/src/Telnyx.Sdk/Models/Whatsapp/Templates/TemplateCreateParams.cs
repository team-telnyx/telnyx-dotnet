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

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

/// <summary>
/// Creates a WhatsApp message template for review and subsequent use in template messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Template category: AUTHENTICATION, UTILITY, or MARKETING.
    /// </summary>
    public required ApiEnum<string, Category> Category {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Category>>(
                "category"
            );
        }
        init { this._rawBodyData.Set("category", value); }
    }

    /// <summary>
    /// Template components defining message structure. Passed through to Meta Graph
    /// API. Templates with variables must include example values. Supports HEADER,
    /// BODY, FOOTER, BUTTONS, CAROUSEL and any future Meta component types.
    /// </summary>
    public required IReadOnlyList<Component> Components {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Component>>(
                "components"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<Component>>(
                "components",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Template language code (e.g. en_US, es, pt_BR).
    /// </summary>
    public required string Language {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "language"
            );
        }
        init { this._rawBodyData.Set("language", value); }
    }

    /// <summary>
    /// Template name. Lowercase letters, numbers, and underscores only.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The WhatsApp Business Account ID.
    /// </summary>
    public required string WabaID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "waba_id"
            );
        }
        init { this._rawBodyData.Set("waba_id", value); }
    }

    public TemplateCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateCreateParams (
        TemplateCreateParams templateCreateParams
    ) : base(templateCreateParams)
    { this._rawBodyData = new(templateCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public TemplateCreateParams (
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
    TemplateCreateParams (
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
    public static TemplateCreateParams FromRawUnchecked(
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

    public virtual bool Equals(TemplateCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/whatsapp/message_templates"
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
/// Template category: AUTHENTICATION, UTILITY, or MARKETING.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Marketing, Utility, Authentication
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MARKETING"=>Category.Marketing,
            "UTILITY"=>Category.Utility,
            "AUTHENTICATION"=>Category.Authentication,
            _ =>(Category)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Category value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Category.Marketing=>"MARKETING",
            Category.Utility=>"UTILITY",
            Category.Authentication=>"AUTHENTICATION",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// A template component. Additional Meta component types not listed here are also accepted.
/// </summary>
[JsonConverter(typeof(ComponentConverter))]
public record class Component : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? Text {
        get {
            return Match<string?>(whatsappTemplateHeader: ( x )=>x.Text,
            whatsappTemplateBody: ( x )=>x.Text,
            whatsappTemplateFooter: ( x )=>x.Text,
            whatsappTemplateButtons: ( _ )=>null,
            whatsappTemplateCarousel: ( _ )=>null);
        }
    }

    public Component (
        WhatsappTemplateHeaderComponent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        WhatsappTemplateBodyComponent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        WhatsappTemplateFooterComponent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        WhatsappTemplateButtonsComponent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        WhatsappTemplateCarouselComponent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappTemplateHeaderComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateHeader(out var value)) {
///     // `value` is of type `WhatsappTemplateHeaderComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateHeader(
        [NotNullWhen(true)] out WhatsappTemplateHeaderComponent? value
    )
    {
        value =this.Value as WhatsappTemplateHeaderComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappTemplateBodyComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateBody(out var value)) {
///     // `value` is of type `WhatsappTemplateBodyComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateBody(
        [NotNullWhen(true)] out WhatsappTemplateBodyComponent? value
    )
    {
        value =this.Value as WhatsappTemplateBodyComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappTemplateFooterComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateFooter(out var value)) {
///     // `value` is of type `WhatsappTemplateFooterComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateFooter(
        [NotNullWhen(true)] out WhatsappTemplateFooterComponent? value
    )
    {
        value =this.Value as WhatsappTemplateFooterComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappTemplateButtonsComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateButtons(out var value)) {
///     // `value` is of type `WhatsappTemplateButtonsComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateButtons(
        [NotNullWhen(true)] out WhatsappTemplateButtonsComponent? value
    )
    {
        value =this.Value as WhatsappTemplateButtonsComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WhatsappTemplateCarouselComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateCarousel(out var value)) {
///     // `value` is of type `WhatsappTemplateCarouselComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateCarousel(
        [NotNullWhen(true)] out WhatsappTemplateCarouselComponent? value
    )
    {
        value =this.Value as WhatsappTemplateCarouselComponent ;
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
///     (WhatsappTemplateHeaderComponent value) =&gt; {...},
///     (WhatsappTemplateBodyComponent value) =&gt; {...},
///     (WhatsappTemplateFooterComponent value) =&gt; {...},
///     (WhatsappTemplateButtonsComponent value) =&gt; {...},
///     (WhatsappTemplateCarouselComponent value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<WhatsappTemplateHeaderComponent> whatsappTemplateHeader,
        System::Action<WhatsappTemplateBodyComponent> whatsappTemplateBody,
        System::Action<WhatsappTemplateFooterComponent> whatsappTemplateFooter,
        System::Action<WhatsappTemplateButtonsComponent> whatsappTemplateButtons,
        System::Action<WhatsappTemplateCarouselComponent> whatsappTemplateCarousel
    )
    {
        switch (this.Value)
        {
            case WhatsappTemplateHeaderComponent value:
                whatsappTemplateHeader(value);
                break;
            case WhatsappTemplateBodyComponent value:
                whatsappTemplateBody(value);
                break;
            case WhatsappTemplateFooterComponent value:
                whatsappTemplateFooter(value);
                break;
            case WhatsappTemplateButtonsComponent value:
                whatsappTemplateButtons(value);
                break;
            case WhatsappTemplateCarouselComponent value:
                whatsappTemplateCarousel(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Component");

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
///     (WhatsappTemplateHeaderComponent value) =&gt; {...},
///     (WhatsappTemplateBodyComponent value) =&gt; {...},
///     (WhatsappTemplateFooterComponent value) =&gt; {...},
///     (WhatsappTemplateButtonsComponent value) =&gt; {...},
///     (WhatsappTemplateCarouselComponent value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<WhatsappTemplateHeaderComponent, T> whatsappTemplateHeader,
        System::Func<WhatsappTemplateBodyComponent, T> whatsappTemplateBody,
        System::Func<WhatsappTemplateFooterComponent, T> whatsappTemplateFooter,
        System::Func<WhatsappTemplateButtonsComponent, T> whatsappTemplateButtons,
        System::Func<WhatsappTemplateCarouselComponent, T> whatsappTemplateCarousel
    )
    {
        return this.Value switch
        {
            WhatsappTemplateHeaderComponent value=>whatsappTemplateHeader(value),
            WhatsappTemplateBodyComponent value=>whatsappTemplateBody(value),
            WhatsappTemplateFooterComponent value=>whatsappTemplateFooter(value),
            WhatsappTemplateButtonsComponent value=>whatsappTemplateButtons(value),
            WhatsappTemplateCarouselComponent value=>whatsappTemplateCarousel(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Component")
        } ;
    }

    public static implicit operator Component (
        WhatsappTemplateHeaderComponent value
    )=> new(value) ;

    public static implicit operator Component (
        WhatsappTemplateBodyComponent value
    )=> new(value) ;

    public static implicit operator Component (
        WhatsappTemplateFooterComponent value
    )=> new(value) ;

    public static implicit operator Component (
        WhatsappTemplateButtonsComponent value
    )=> new(value) ;

    public static implicit operator Component (
        WhatsappTemplateCarouselComponent value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Component");
        }
        this.Switch((whatsappTemplateHeader) => whatsappTemplateHeader.Validate(),
        (whatsappTemplateBody) => whatsappTemplateBody.Validate(),
        (whatsappTemplateFooter) => whatsappTemplateFooter.Validate(),
        (whatsappTemplateButtons) => whatsappTemplateButtons.Validate(),
        (whatsappTemplateCarousel) => whatsappTemplateCarousel.Validate());
    }

    public virtual bool Equals(Component? other)
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
            WhatsappTemplateHeaderComponent _=>0,
            WhatsappTemplateBodyComponent _=>1,
            WhatsappTemplateFooterComponent _=>2,
            WhatsappTemplateButtonsComponent _=>3,
            WhatsappTemplateCarouselComponent _=>4,
            _ =>-1
        } ;
    }
}

sealed class ComponentConverter : JsonConverter<Component>
{
    public override Component? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "HEADER":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WhatsappTemplateHeaderComponent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "BODY":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WhatsappTemplateBodyComponent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "FOOTER":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WhatsappTemplateFooterComponent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "BUTTONS":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WhatsappTemplateButtonsComponent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "CAROUSEL":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WhatsappTemplateCarouselComponent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new Component(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Component value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}