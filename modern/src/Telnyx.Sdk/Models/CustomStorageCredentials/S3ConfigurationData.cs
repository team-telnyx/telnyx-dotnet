using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<S3ConfigurationData, S3ConfigurationDataFromRaw>))]
public sealed record class S3ConfigurationData : JsonModel
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
    public required ApiEnum<string, S3ConfigurationDataBackend> Backend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, S3ConfigurationDataBackend>>(
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
        _ = this.Region;
    }

    public S3ConfigurationData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public S3ConfigurationData (S3ConfigurationData s3ConfigurationData) : base(
        s3ConfigurationData
    )
    {  }
    #pragma warning restore CS8618

    public S3ConfigurationData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    S3ConfigurationData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="S3ConfigurationDataFromRaw.FromRawUnchecked"/>
    public static S3ConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class S3ConfigurationDataFromRaw : IFromRawJson<S3ConfigurationData>
{
    /// <inheritdoc/>
    public S3ConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>S3ConfigurationData.FromRawUnchecked(rawData);
}

/// <summary>
/// Storage backend type
/// </summary>
[JsonConverter(typeof(S3ConfigurationDataBackendConverter))]
public enum S3ConfigurationDataBackend
{
    S3
}sealed class S3ConfigurationDataBackendConverter : JsonConverter<S3ConfigurationDataBackend>
{
    public override S3ConfigurationDataBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "s3"=>S3ConfigurationDataBackend.S3,
            _ =>(S3ConfigurationDataBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        S3ConfigurationDataBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            S3ConfigurationDataBackend.S3=>"s3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}