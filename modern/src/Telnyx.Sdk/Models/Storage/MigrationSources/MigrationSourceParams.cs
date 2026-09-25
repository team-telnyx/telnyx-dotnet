using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.MigrationSources;

[JsonConverter(typeof(JsonModelConverter<MigrationSourceParams, MigrationSourceParamsFromRaw>))]
public sealed record class MigrationSourceParams : JsonModel
{
    /// <summary>
    /// Bucket name to migrate the data from.
    /// </summary>
    public required string BucketName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "bucket_name"
            );
        }
        init { this._rawData.Set("bucket_name", value); }
    }

    /// <summary>
    /// Cloud provider from which to migrate data. Use 'telnyx' if you want to migrate
    /// data from one Telnyx bucket to another.
    /// </summary>
    public required ApiEnum<string, MigrationSourceParamsProvider> Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MigrationSourceParamsProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    public required MigrationSourceParamsProviderAuth ProviderAuth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MigrationSourceParamsProviderAuth>(
                "provider_auth"
            );
        }
        init { this._rawData.Set("provider_auth", value); }
    }

    /// <summary>
    /// Unique identifier for the data migration source.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// For intra-Telnyx buckets migration, specify the source bucket region in this field.
    /// </summary>
    public string? SourceRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source_region", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketName;
        this.Provider.Validate();
        this.ProviderAuth.Validate();
        _ = this.ID;
        _ = this.SourceRegion;
    }

    public MigrationSourceParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceParams (
        MigrationSourceParams migrationSourceParams
    ) : base(migrationSourceParams)
    {  }
    #pragma warning restore CS8618

    public MigrationSourceParams (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationSourceParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationSourceParamsFromRaw.FromRawUnchecked"/>
    public static MigrationSourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationSourceParamsFromRaw : IFromRawJson<MigrationSourceParams>
{
    /// <inheritdoc/>
    public MigrationSourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationSourceParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Cloud provider from which to migrate data. Use 'telnyx' if you want to migrate
/// data from one Telnyx bucket to another.
/// </summary>
[JsonConverter(typeof(MigrationSourceParamsProviderConverter))]
public enum MigrationSourceParamsProvider
{
    Aws, Telnyx
}sealed class MigrationSourceParamsProviderConverter : JsonConverter<MigrationSourceParamsProvider>
{
    public override MigrationSourceParamsProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>MigrationSourceParamsProvider.Aws,
            "telnyx"=>MigrationSourceParamsProvider.Telnyx,
            _ =>(MigrationSourceParamsProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MigrationSourceParamsProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MigrationSourceParamsProvider.Aws=>"aws",
            MigrationSourceParamsProvider.Telnyx=>"telnyx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MigrationSourceParamsProviderAuth, MigrationSourceParamsProviderAuthFromRaw>))]
public sealed record class MigrationSourceParamsProviderAuth : JsonModel
{
    /// <summary>
    /// AWS Access Key. For Telnyx-to-Telnyx migrations, use your Telnyx API key here.
    /// </summary>
    public string? AccessKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "access_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("access_key", value);
        }
    }

    /// <summary>
    /// AWS Secret Access Key. For Telnyx-to-Telnyx migrations, use your Telnyx API
    /// key here as well.
    /// </summary>
    public string? SecretAccessKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secret_access_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secret_access_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessKey;
        _ = this.SecretAccessKey;
    }

    public MigrationSourceParamsProviderAuth ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceParamsProviderAuth (
        MigrationSourceParamsProviderAuth migrationSourceParamsProviderAuth
    ) : base(migrationSourceParamsProviderAuth)
    {  }
    #pragma warning restore CS8618

    public MigrationSourceParamsProviderAuth (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationSourceParamsProviderAuth (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationSourceParamsProviderAuthFromRaw.FromRawUnchecked"/>
    public static MigrationSourceParamsProviderAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MigrationSourceParamsProviderAuthFromRaw : IFromRawJson<MigrationSourceParamsProviderAuth>
{
    /// <inheritdoc/>
    public MigrationSourceParamsProviderAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationSourceParamsProviderAuth.FromRawUnchecked(rawData);
}