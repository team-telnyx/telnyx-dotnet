using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<S3GenericConfigurationData, S3GenericConfigurationDataFromRaw>))]
public sealed record class S3GenericConfigurationData : JsonModel
{
    /// <summary>
    /// AWS credentials access key id.
    /// </summary>
    public required string AwsAccessKeyID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "aws_access_key_id"
            );
        }
        init { this._rawData.Set("aws_access_key_id", value); }
    }

    /// <summary>
    /// AWS secret access key.
    /// </summary>
    public required string AwsSecretAccessKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "aws_secret_access_key"
            );
        }
        init { this._rawData.Set("aws_secret_access_key", value); }
    }

    /// <summary>
    /// Storage backend type
    /// </summary>
    public required ApiEnum<string, S3GenericConfigurationDataBackend> Backend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, S3GenericConfigurationDataBackend>>(
                "backend"
            );
        }
        init { this._rawData.Set("backend", value); }
    }

    /// <summary>
    /// Name of the bucket to be used to store recording files.
    /// </summary>
    public required string Bucket {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "bucket"
            );
        }
        init { this._rawData.Set("bucket", value); }
    }

    /// <summary>
    /// URL of an S3-compatible storage endpoint, used to direct uploads and presigned
    /// download URLs to a non-AWS store (for example MinIO, Cloudflare R2, Wasabi,
    /// Backblaze B2, or Supabase). A bare host (https://s3.example.com) or a path-prefixed
    /// URL (https://xyz.supabase.co/storage/v1/s3) is accepted, and must use the
    /// http or https scheme.
    /// </summary>
    public required string Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "endpoint"
            );
        }
        init { this._rawData.Set("endpoint", value); }
    }

    /// <summary>
    /// Region where the bucket is located.
    /// </summary>
    public required string Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "region"
            );
        }
        init { this._rawData.Set("region", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AwsAccessKeyID;
        _ = this.AwsSecretAccessKey;
        this.Backend.Validate();
        _ = this.Bucket;
        _ = this.Endpoint;
        _ = this.Region;
    }

    public S3GenericConfigurationData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public S3GenericConfigurationData (
        S3GenericConfigurationData s3GenericConfigurationData
    ) : base(s3GenericConfigurationData)
    {  }
    #pragma warning restore CS8618

    public S3GenericConfigurationData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    S3GenericConfigurationData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="S3GenericConfigurationDataFromRaw.FromRawUnchecked"/>
    public static S3GenericConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class S3GenericConfigurationDataFromRaw : IFromRawJson<S3GenericConfigurationData>
{
    /// <inheritdoc/>
    public S3GenericConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>S3GenericConfigurationData.FromRawUnchecked(rawData);
}

/// <summary>
/// Storage backend type
/// </summary>
[JsonConverter(typeof(S3GenericConfigurationDataBackendConverter))]
public enum S3GenericConfigurationDataBackend
{
    S3Generic
}sealed class S3GenericConfigurationDataBackendConverter : JsonConverter<S3GenericConfigurationDataBackend>
{
    public override S3GenericConfigurationDataBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "s3-generic"=>S3GenericConfigurationDataBackend.S3Generic,
            _ =>(S3GenericConfigurationDataBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        S3GenericConfigurationDataBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            S3GenericConfigurationDataBackend.S3Generic=>"s3-generic",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}