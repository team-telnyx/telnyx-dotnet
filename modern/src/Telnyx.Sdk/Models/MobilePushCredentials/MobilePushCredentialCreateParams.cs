using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MobilePushCredentials;

/// <summary>
/// Creates a new mobile push credential for delivering push notifications to iOS
/// or Android apps, and returns the created credential.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MobilePushCredentialCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required CreateMobilePushCredentialRequest CreateMobilePushCredentialRequest {
        get {
            return WrappedJsonSerializer.GetNotNullClass<CreateMobilePushCredentialRequest>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public MobilePushCredentialCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePushCredentialCreateParams (
        MobilePushCredentialCreateParams mobilePushCredentialCreateParams
    ) : base(mobilePushCredentialCreateParams)
    { this.RawBodyData = mobilePushCredentialCreateParams.RawBodyData; }
    #pragma warning restore CS8618

    public MobilePushCredentialCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePushCredentialCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MobilePushCredentialCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MobilePushCredentialCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/mobile_push_credentials"
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

[JsonConverter(typeof(CreateMobilePushCredentialRequestConverter))]
public record class CreateMobilePushCredentialRequest : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string Alias {
        get { return Match(ios: ( x )=>x.Alias, android: ( x )=>x.Alias); }
    }

    public JsonElement Type {
        get { return Match(ios: ( x )=>x.Type, android: ( x )=>x.Type); }
    }

    public CreateMobilePushCredentialRequest (
        Ios value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateMobilePushCredentialRequest (
        Android value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateMobilePushCredentialRequest (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Ios"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickIos(out var value)) {
///     // `value` is of type `Ios`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickIos([NotNullWhen(true)] out Ios? value)
    {
        value =this.Value as Ios ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Android"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAndroid(out var value)) {
///     // `value` is of type `Android`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAndroid([NotNullWhen(true)] out Android? value)
    {
        value =this.Value as Android ;
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
///     (Ios value) =&gt; {...},
///     (Android value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(System::Action<Ios> ios, System::Action<Android> android)
    {
        switch (this.Value)
        {
            case Ios value:
                ios(value);
                break;
            case Android value:
                android(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CreateMobilePushCredentialRequest");

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
///     (Ios value) =&gt; {...},
///     (Android value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<Ios, T> ios, System::Func<Android, T> android)
    {
        return this.Value switch
        {
            Ios value=>ios(value),
            Android value=>android(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CreateMobilePushCredentialRequest")
        } ;
    }

    public static implicit operator CreateMobilePushCredentialRequest (
        Ios value
    )=> new(value) ;

    public static implicit operator CreateMobilePushCredentialRequest (
        Android value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CreateMobilePushCredentialRequest");
        }
        this.Switch((ios) => ios.Validate(), (android) => android.Validate());
    }

    public virtual bool Equals(CreateMobilePushCredentialRequest? other)
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
        { Ios _=>0, Android _=>1, _ =>-1 } ;
    }
}

sealed class CreateMobilePushCredentialRequestConverter : JsonConverter<CreateMobilePushCredentialRequest>
{
    public override CreateMobilePushCredentialRequest? Read(
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
            case "ios":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Ios>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "android":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Android>(element, options);
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
                { return new CreateMobilePushCredentialRequest(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateMobilePushCredentialRequest value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<Ios, IosFromRaw>))]
public sealed record class Ios : JsonModel
{
    /// <summary>
    /// Alias to uniquely identify the credential
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <summary>
    /// Certificate as received from APNs
    /// </summary>
    public required string Certificate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "certificate"
            );
        }
        init { this._rawData.Set("certificate", value); }
    }

    /// <summary>
    /// Corresponding private key to the certificate as received from APNs
    /// </summary>
    public required string PrivateKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "private_key"
            );
        }
        init { this._rawData.Set("private_key", value); }
    }

    /// <summary>
    /// Type of mobile push credential. Should be &lt;code&gt;ios&lt;/code&gt; here
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        _ = this.Certificate;
        _ = this.PrivateKey;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("ios")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Ios ()
    { this.Type = JsonSerializer.SerializeToElement("ios"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ios (Ios ios) : base(ios)
    {  }
    #pragma warning restore CS8618

    public Ios (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ios");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Ios (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IosFromRaw.FromRawUnchecked"/>
    public static Ios FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IosFromRaw : IFromRawJson<Ios>
{
    /// <inheritdoc/>
    public Ios FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Ios.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Android, AndroidFromRaw>))]
public sealed record class Android : JsonModel
{
    /// <summary>
    /// Alias to uniquely identify the credential
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <summary>
    /// Private key file in JSON format
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> ProjectAccountJsonFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "project_account_json_file"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "project_account_json_file",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Type of mobile push credential. Should be &lt;code&gt;android&lt;/code&gt; here
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        _ = this.ProjectAccountJsonFile;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("android")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Android ()
    { this.Type = JsonSerializer.SerializeToElement("android"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Android (Android android) : base(android)
    {  }
    #pragma warning restore CS8618

    public Android (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("android");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Android (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AndroidFromRaw.FromRawUnchecked"/>
    public static Android FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AndroidFromRaw : IFromRawJson<Android>
{
    /// <inheritdoc/>
    public Android FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Android.FromRawUnchecked(rawData);
}