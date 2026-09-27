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
using Templates = Telnyx.Sdk.Models.Whatsapp.Templates;

namespace Telnyx.Sdk.Models.WhatsappMessageTemplates;

/// <summary>
/// Updates the editable fields of the specified WhatsApp message template.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WhatsappMessageTemplateUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public ApiEnum<string, Category>? Category {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Category>>(
                "category"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// Updated template components. Same structure as the create request.
    /// </summary>
    public IReadOnlyList<Component>? Components {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Component>>(
                "components"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Component>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WhatsappMessageTemplateUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageTemplateUpdateParams (
        WhatsappMessageTemplateUpdateParams whatsappMessageTemplateUpdateParams
    ) : base(whatsappMessageTemplateUpdateParams)
    {
        this.ID = whatsappMessageTemplateUpdateParams.ID;

        this._rawBodyData = new(whatsappMessageTemplateUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public WhatsappMessageTemplateUpdateParams (
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
    WhatsappMessageTemplateUpdateParams (
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
    public static WhatsappMessageTemplateUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(WhatsappMessageTemplateUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v2/whatsapp_message_templates/{0}",
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
        Templates::WhatsappTemplateHeaderComponent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        Templates::WhatsappTemplateBodyComponent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        Templates::WhatsappTemplateFooterComponent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        Templates::WhatsappTemplateButtonsComponent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (
        Templates::WhatsappTemplateCarouselComponent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Component (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Templates::WhatsappTemplateHeaderComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateHeader(out var value)) {
///     // `value` is of type `Templates::WhatsappTemplateHeaderComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateHeader(
        [NotNullWhen(true)] out Templates::WhatsappTemplateHeaderComponent? value
    )
    {
        value =this.Value as Templates::WhatsappTemplateHeaderComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Templates::WhatsappTemplateBodyComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateBody(out var value)) {
///     // `value` is of type `Templates::WhatsappTemplateBodyComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateBody(
        [NotNullWhen(true)] out Templates::WhatsappTemplateBodyComponent? value
    )
    {
        value =this.Value as Templates::WhatsappTemplateBodyComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Templates::WhatsappTemplateFooterComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateFooter(out var value)) {
///     // `value` is of type `Templates::WhatsappTemplateFooterComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateFooter(
        [NotNullWhen(true)] out Templates::WhatsappTemplateFooterComponent? value
    )
    {
        value =this.Value as Templates::WhatsappTemplateFooterComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Templates::WhatsappTemplateButtonsComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateButtons(out var value)) {
///     // `value` is of type `Templates::WhatsappTemplateButtonsComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateButtons(
        [NotNullWhen(true)] out Templates::WhatsappTemplateButtonsComponent? value
    )
    {
        value =this.Value as Templates::WhatsappTemplateButtonsComponent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Templates::WhatsappTemplateCarouselComponent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWhatsappTemplateCarousel(out var value)) {
///     // `value` is of type `Templates::WhatsappTemplateCarouselComponent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWhatsappTemplateCarousel(
        [NotNullWhen(true)] out Templates::WhatsappTemplateCarouselComponent? value
    )
    {
        value =this.Value as Templates::WhatsappTemplateCarouselComponent ;
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
///     (Templates::WhatsappTemplateHeaderComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateBodyComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateFooterComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateButtonsComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateCarouselComponent value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Templates::WhatsappTemplateHeaderComponent> whatsappTemplateHeader,
        System::Action<Templates::WhatsappTemplateBodyComponent> whatsappTemplateBody,
        System::Action<Templates::WhatsappTemplateFooterComponent> whatsappTemplateFooter,
        System::Action<Templates::WhatsappTemplateButtonsComponent> whatsappTemplateButtons,
        System::Action<Templates::WhatsappTemplateCarouselComponent> whatsappTemplateCarousel
    )
    {
        switch (this.Value)
        {
            case Templates::WhatsappTemplateHeaderComponent value:
                whatsappTemplateHeader(value);
                break;
            case Templates::WhatsappTemplateBodyComponent value:
                whatsappTemplateBody(value);
                break;
            case Templates::WhatsappTemplateFooterComponent value:
                whatsappTemplateFooter(value);
                break;
            case Templates::WhatsappTemplateButtonsComponent value:
                whatsappTemplateButtons(value);
                break;
            case Templates::WhatsappTemplateCarouselComponent value:
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
///     (Templates::WhatsappTemplateHeaderComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateBodyComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateFooterComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateButtonsComponent value) =&gt; {...},
///     (Templates::WhatsappTemplateCarouselComponent value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Templates::WhatsappTemplateHeaderComponent, T> whatsappTemplateHeader,
        System::Func<Templates::WhatsappTemplateBodyComponent, T> whatsappTemplateBody,
        System::Func<Templates::WhatsappTemplateFooterComponent, T> whatsappTemplateFooter,
        System::Func<Templates::WhatsappTemplateButtonsComponent, T> whatsappTemplateButtons,
        System::Func<Templates::WhatsappTemplateCarouselComponent, T> whatsappTemplateCarousel
    )
    {
        return this.Value switch
        {
            Templates::WhatsappTemplateHeaderComponent value=>whatsappTemplateHeader(value),
            Templates::WhatsappTemplateBodyComponent value=>whatsappTemplateBody(value),
            Templates::WhatsappTemplateFooterComponent value=>whatsappTemplateFooter(value),
            Templates::WhatsappTemplateButtonsComponent value=>whatsappTemplateButtons(value),
            Templates::WhatsappTemplateCarouselComponent value=>whatsappTemplateCarousel(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Component")
        } ;
    }

    public static implicit operator Component (
        Templates::WhatsappTemplateHeaderComponent value
    )=> new(value) ;

    public static implicit operator Component (
        Templates::WhatsappTemplateBodyComponent value
    )=> new(value) ;

    public static implicit operator Component (
        Templates::WhatsappTemplateFooterComponent value
    )=> new(value) ;

    public static implicit operator Component (
        Templates::WhatsappTemplateButtonsComponent value
    )=> new(value) ;

    public static implicit operator Component (
        Templates::WhatsappTemplateCarouselComponent value
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
            Templates::WhatsappTemplateHeaderComponent _=>0,
            Templates::WhatsappTemplateBodyComponent _=>1,
            Templates::WhatsappTemplateFooterComponent _=>2,
            Templates::WhatsappTemplateButtonsComponent _=>3,
            Templates::WhatsappTemplateCarouselComponent _=>4,
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
                    var deserialized = JsonSerializer.Deserialize<Templates::WhatsappTemplateHeaderComponent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Templates::WhatsappTemplateBodyComponent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Templates::WhatsappTemplateFooterComponent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Templates::WhatsappTemplateButtonsComponent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Templates::WhatsappTemplateCarouselComponent>(element, options);
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