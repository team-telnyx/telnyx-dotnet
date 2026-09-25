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

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

/// <summary>
/// Updates a stored custom credentials configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomStorageCredentialUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConnectionID { get; init; }

    public required ApiEnum<string, CustomStorageCredentialUpdateParamsBackend> Backend {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, CustomStorageCredentialUpdateParamsBackend>>(
                "backend"
            );
        }
        init { this._rawBodyData.Set("backend", value); }
    }

    public required CustomStorageCredentialUpdateParamsConfiguration Configuration {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<CustomStorageCredentialUpdateParamsConfiguration>(
                "configuration"
            );
        }
        init { this._rawBodyData.Set("configuration", value); }
    }

    public CustomStorageCredentialUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomStorageCredentialUpdateParams (
        CustomStorageCredentialUpdateParams customStorageCredentialUpdateParams
    ) : base(customStorageCredentialUpdateParams)
    {
        this.ConnectionID = customStorageCredentialUpdateParams.ConnectionID;

        this._rawBodyData = new(customStorageCredentialUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CustomStorageCredentialUpdateParams (
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
    CustomStorageCredentialUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConnectionID = connectionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomStorageCredentialUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            connectionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ConnectionID"] = JsonSerializer.SerializeToElement(this.ConnectionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CustomStorageCredentialUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConnectionID?.Equals(other.ConnectionID) ?? other.ConnectionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/custom_storage_credentials/{0}",
            this.ConnectionID)
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

[JsonConverter(typeof(CustomStorageCredentialUpdateParamsBackendConverter))]
public enum CustomStorageCredentialUpdateParamsBackend
{
    Gcs, S3, S3Generic, Azure
}

sealed class CustomStorageCredentialUpdateParamsBackendConverter : JsonConverter<CustomStorageCredentialUpdateParamsBackend>
{
    public override CustomStorageCredentialUpdateParamsBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gcs"=>CustomStorageCredentialUpdateParamsBackend.Gcs,
            "s3"=>CustomStorageCredentialUpdateParamsBackend.S3,
            "s3-generic"=>CustomStorageCredentialUpdateParamsBackend.S3Generic,
            "azure"=>CustomStorageCredentialUpdateParamsBackend.Azure,
            _ =>(CustomStorageCredentialUpdateParamsBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomStorageCredentialUpdateParamsBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CustomStorageCredentialUpdateParamsBackend.Gcs=>"gcs",
            CustomStorageCredentialUpdateParamsBackend.S3=>"s3",
            CustomStorageCredentialUpdateParamsBackend.S3Generic=>"s3-generic",
            CustomStorageCredentialUpdateParamsBackend.Azure=>"azure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(CustomStorageCredentialUpdateParamsConfigurationConverter))]
public record class CustomStorageCredentialUpdateParamsConfiguration : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? Bucket {
        get {
            return Match<string?>(gcsConfigurationData: ( x )=>x.Bucket,
            s3ConfigurationData: ( x )=>x.Bucket,
            s3GenericConfigurationData: ( x )=>x.Bucket,
            azureConfigurationData: ( x )=>x.Bucket);
        }
    }

    public string? AwsAccessKeyID {
        get {
            return Match<string?>(gcsConfigurationData: ( _ )=>null,
            s3ConfigurationData: ( x )=>x.AwsAccessKeyID,
            s3GenericConfigurationData: ( x )=>x.AwsAccessKeyID,
            azureConfigurationData: ( _ )=>null);
        }
    }

    public string? AwsSecretAccessKey {
        get {
            return Match<string?>(gcsConfigurationData: ( _ )=>null,
            s3ConfigurationData: ( x )=>x.AwsSecretAccessKey,
            s3GenericConfigurationData: ( x )=>x.AwsSecretAccessKey,
            azureConfigurationData: ( _ )=>null);
        }
    }

    public string? Region {
        get {
            return Match<string?>(gcsConfigurationData: ( _ )=>null,
            s3ConfigurationData: ( x )=>x.Region,
            s3GenericConfigurationData: ( x )=>x.Region,
            azureConfigurationData: ( _ )=>null);
        }
    }

    public CustomStorageCredentialUpdateParamsConfiguration (
        GcsConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageCredentialUpdateParamsConfiguration (
        S3ConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageCredentialUpdateParamsConfiguration (
        S3GenericConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageCredentialUpdateParamsConfiguration (
        AzureConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageCredentialUpdateParamsConfiguration (
        JsonElement element
    )
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="GcsConfigurationData"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickGcsConfigurationData(out var value)) {
///     // `value` is of type `GcsConfigurationData`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickGcsConfigurationData(
        [NotNullWhen(true)] out GcsConfigurationData? value
    )
    {
        value =this.Value as GcsConfigurationData ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="S3ConfigurationData"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickS3ConfigurationData(out var value)) {
///     // `value` is of type `S3ConfigurationData`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickS3ConfigurationData(
        [NotNullWhen(true)] out S3ConfigurationData? value
    )
    {
        value =this.Value as S3ConfigurationData ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="S3GenericConfigurationData"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickS3GenericConfigurationData(out var value)) {
///     // `value` is of type `S3GenericConfigurationData`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickS3GenericConfigurationData(
        [NotNullWhen(true)] out S3GenericConfigurationData? value
    )
    {
        value =this.Value as S3GenericConfigurationData ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AzureConfigurationData"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAzureConfigurationData(out var value)) {
///     // `value` is of type `AzureConfigurationData`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAzureConfigurationData(
        [NotNullWhen(true)] out AzureConfigurationData? value
    )
    {
        value =this.Value as AzureConfigurationData ;
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
///     (GcsConfigurationData value) =&gt; {...},
///     (S3ConfigurationData value) =&gt; {...},
///     (S3GenericConfigurationData value) =&gt; {...},
///     (AzureConfigurationData value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<GcsConfigurationData> gcsConfigurationData,
        System::Action<S3ConfigurationData> s3ConfigurationData,
        System::Action<S3GenericConfigurationData> s3GenericConfigurationData,
        System::Action<AzureConfigurationData> azureConfigurationData
    )
    {
        switch (this.Value)
        {
            case GcsConfigurationData value:
                gcsConfigurationData(value);
                break;
            case S3ConfigurationData value:
                s3ConfigurationData(value);
                break;
            case S3GenericConfigurationData value:
                s3GenericConfigurationData(value);
                break;
            case AzureConfigurationData value:
                azureConfigurationData(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageCredentialUpdateParamsConfiguration");

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
///     (GcsConfigurationData value) =&gt; {...},
///     (S3ConfigurationData value) =&gt; {...},
///     (S3GenericConfigurationData value) =&gt; {...},
///     (AzureConfigurationData value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<GcsConfigurationData, T> gcsConfigurationData,
        System::Func<S3ConfigurationData, T> s3ConfigurationData,
        System::Func<S3GenericConfigurationData, T> s3GenericConfigurationData,
        System::Func<AzureConfigurationData, T> azureConfigurationData
    )
    {
        return this.Value switch
        {
            GcsConfigurationData value=>gcsConfigurationData(value),
            S3ConfigurationData value=>s3ConfigurationData(value),
            S3GenericConfigurationData value=>s3GenericConfigurationData(value),
            AzureConfigurationData value=>azureConfigurationData(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageCredentialUpdateParamsConfiguration")
        } ;
    }

    public static implicit operator CustomStorageCredentialUpdateParamsConfiguration (
        GcsConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageCredentialUpdateParamsConfiguration (
        S3ConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageCredentialUpdateParamsConfiguration (
        S3GenericConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageCredentialUpdateParamsConfiguration (
        AzureConfigurationData value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageCredentialUpdateParamsConfiguration");
        }
        this.Switch((gcsConfigurationData) => gcsConfigurationData.Validate(),
        (s3ConfigurationData) => s3ConfigurationData.Validate(),
        (s3GenericConfigurationData) => s3GenericConfigurationData.Validate(),
        (azureConfigurationData) => azureConfigurationData.Validate());
    }

    public virtual bool Equals(
        CustomStorageCredentialUpdateParamsConfiguration? other
    )
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
            GcsConfigurationData _=>0,
            S3ConfigurationData _=>1,
            S3GenericConfigurationData _=>2,
            AzureConfigurationData _=>3,
            _ =>-1
        } ;
    }
}

sealed class CustomStorageCredentialUpdateParamsConfigurationConverter : JsonConverter<CustomStorageCredentialUpdateParamsConfiguration>
{
    public override CustomStorageCredentialUpdateParamsConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? backend;
        try {
            backend = element.GetProperty("backend").GetString();
        } catch {
            backend = null;
        }

        switch (backend)
        {
            case "gcs":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GcsConfigurationData>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "s3":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3ConfigurationData>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "s3-generic":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3GenericConfigurationData>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "azure":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureConfigurationData>(element, options);
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
                {
                    return new CustomStorageCredentialUpdateParamsConfiguration(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomStorageCredentialUpdateParamsConfiguration value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}