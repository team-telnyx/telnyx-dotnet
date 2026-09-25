using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<AzureConfigurationData, AzureConfigurationDataFromRaw>))]
public sealed record class AzureConfigurationData : JsonModel
{
    /// <summary>
    /// Storage backend type
    /// </summary>
    public required ApiEnum<string, AzureConfigurationDataBackend> Backend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AzureConfigurationDataBackend>>(
                "backend"
            );
        }
        init { this._rawData.Set("backend", value); }
    }

    /// <summary>
    /// Azure Blob Storage account key.
    /// </summary>
    public string? AccountKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_key", value);
        }
    }

    /// <summary>
    /// Azure Blob Storage account name.
    /// </summary>
    public string? AccountName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_name", value);
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Backend.Validate();
        _ = this.AccountKey;
        _ = this.AccountName;
        _ = this.Bucket;
    }

    public AzureConfigurationData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureConfigurationData (
        AzureConfigurationData azureConfigurationData
    ) : base(azureConfigurationData)
    {  }
    #pragma warning restore CS8618

    public AzureConfigurationData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureConfigurationData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AzureConfigurationDataFromRaw.FromRawUnchecked"/>
    public static AzureConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AzureConfigurationData (
        ApiEnum<string, AzureConfigurationDataBackend> backend
    ) : this()
    { this.Backend = backend; }
}

class AzureConfigurationDataFromRaw : IFromRawJson<AzureConfigurationData>
{
    /// <inheritdoc/>
    public AzureConfigurationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AzureConfigurationData.FromRawUnchecked(rawData);
}

/// <summary>
/// Storage backend type
/// </summary>
[JsonConverter(typeof(AzureConfigurationDataBackendConverter))]
public enum AzureConfigurationDataBackend
{
    Azure
}sealed class AzureConfigurationDataBackendConverter : JsonConverter<AzureConfigurationDataBackend>
{
    public override AzureConfigurationDataBackend Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "azure"=>AzureConfigurationDataBackend.Azure,
            _ =>(AzureConfigurationDataBackend)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AzureConfigurationDataBackend value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AzureConfigurationDataBackend.Azure=>"azure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}