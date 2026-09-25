using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<CustomStorageConfiguration, CustomStorageConfigurationFromRaw>))]
public sealed record class CustomStorageConfiguration : JsonModel
{
    public required ApiEnum<string, CustomStorageConfigurationBackend> Backend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CustomStorageConfigurationBackend>>(
                "backend"
            );
        }
        init { this._rawData.Set("backend", value); }
    }

    public required CustomStorageConfigurationConfiguration Configuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomStorageConfigurationConfiguration>(
                "configuration"
            );
        }
        init { this._rawData.Set("configuration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Backend.Validate();
        this.Configuration.Validate();
    }

    public CustomStorageConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomStorageConfiguration (
        CustomStorageConfiguration customStorageConfiguration
    ) : base(customStorageConfiguration)
    {  }
    #pragma warning restore CS8618

    public CustomStorageConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomStorageConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomStorageConfigurationFromRaw.FromRawUnchecked"/>
    public static CustomStorageConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomStorageConfigurationFromRaw : IFromRawJson<CustomStorageConfiguration>
{
    /// <inheritdoc/>
    public CustomStorageConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomStorageConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CustomStorageConfigurationBackendConverter))]
public enum CustomStorageConfigurationBackend
{
    Gcs, S3, S3Generic, Azure
}sealed class CustomStorageConfigurationBackendConverter : JsonConverter<CustomStorageConfigurationBackend>
{
    public override CustomStorageConfigurationBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gcs"=>CustomStorageConfigurationBackend.Gcs,
            "s3"=>CustomStorageConfigurationBackend.S3,
            "s3-generic"=>CustomStorageConfigurationBackend.S3Generic,
            "azure"=>CustomStorageConfigurationBackend.Azure,
            _ =>(CustomStorageConfigurationBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomStorageConfigurationBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CustomStorageConfigurationBackend.Gcs=>"gcs",
            CustomStorageConfigurationBackend.S3=>"s3",
            CustomStorageConfigurationBackend.S3Generic=>"s3-generic",
            CustomStorageConfigurationBackend.Azure=>"azure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(CustomStorageConfigurationConfigurationConverter))]
public record class CustomStorageConfigurationConfiguration : ModelBase
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

    public CustomStorageConfigurationConfiguration (
        GcsConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageConfigurationConfiguration (
        S3ConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageConfigurationConfiguration (
        S3GenericConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageConfigurationConfiguration (
        AzureConfigurationData value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomStorageConfigurationConfiguration (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageConfigurationConfiguration");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageConfigurationConfiguration")
        } ;
    }

    public static implicit operator CustomStorageConfigurationConfiguration (
        GcsConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageConfigurationConfiguration (
        S3ConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageConfigurationConfiguration (
        S3GenericConfigurationData value
    )=> new(value) ;

    public static implicit operator CustomStorageConfigurationConfiguration (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CustomStorageConfigurationConfiguration");
        }
        this.Switch((gcsConfigurationData) => gcsConfigurationData.Validate(),
        (s3ConfigurationData) => s3ConfigurationData.Validate(),
        (s3GenericConfigurationData) => s3GenericConfigurationData.Validate(),
        (azureConfigurationData) => azureConfigurationData.Validate());
    }

    public virtual bool Equals(CustomStorageConfigurationConfiguration? other)
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
}sealed class CustomStorageConfigurationConfigurationConverter : JsonConverter<CustomStorageConfigurationConfiguration>
{
    public override CustomStorageConfigurationConfiguration? Read(
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
                { return new CustomStorageConfigurationConfiguration(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomStorageConfigurationConfiguration value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}