using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<GcsConfigurationData, GcsConfigurationDataFromRaw>))]
public sealed record class GcsConfigurationData : JsonModel
{
    /// <summary>
    /// Storage backend type
    /// </summary>
    public required ApiEnum<string, GcsConfigurationDataBackend> Backend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GcsConfigurationDataBackend>>(
                "backend"
            );
        }
        init { this._rawData.Set("backend", value); }
    }

    /// <summary>
    /// Name of the bucket to be used to store recording files.
    /// </summary>
    public string? Bucket {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bucket"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bucket", value);
        }
    }

    /// <summary>
    /// Opaque credential token used to authenticate and authorize with storage provider.
    /// </summary>
    public string? Credentials {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "credentials"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("credentials", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Backend.Validate();
        _ = this.Bucket;
        _ = this.Credentials;
    }

    public GcsConfigurationData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GcsConfigurationData (
        GcsConfigurationData gcsConfigurationData
    ) : base(gcsConfigurationData)
    {  }
    #pragma warning restore CS8618

    public GcsConfigurationData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GcsConfigurationData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GcsConfigurationDataFromRaw.FromRawUnchecked"/>
    public static GcsConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public GcsConfigurationData (
        ApiEnum<string, GcsConfigurationDataBackend> backend
    ) : this()
    { this.Backend = backend; }
}

class GcsConfigurationDataFromRaw : IFromRawJson<GcsConfigurationData>
{
    /// <inheritdoc/>
    public GcsConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GcsConfigurationData.FromRawUnchecked(rawData);
}

/// <summary>
/// Storage backend type
/// </summary>
[JsonConverter(typeof(GcsConfigurationDataBackendConverter))]
public enum GcsConfigurationDataBackend
{
    Gcs
}sealed class GcsConfigurationDataBackendConverter : JsonConverter<GcsConfigurationDataBackend>
{
    public override GcsConfigurationDataBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gcs"=>GcsConfigurationDataBackend.Gcs,
            _ =>(GcsConfigurationDataBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GcsConfigurationDataBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            GcsConfigurationDataBackend.Gcs=>"gcs",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}