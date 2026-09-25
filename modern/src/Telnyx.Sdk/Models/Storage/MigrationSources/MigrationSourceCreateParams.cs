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

namespace Telnyx.Sdk.Models.Storage.MigrationSources;

/// <summary>
/// Create a source from which data can be migrated from.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MigrationSourceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Bucket name to migrate the data from.
    /// </summary>
    public required string BucketName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "bucket_name"
            );
        }
        init { this._rawBodyData.Set("bucket_name", value); }
    }

    /// <summary>
    /// Cloud provider from which to migrate data. Use 'telnyx' if you want to migrate
    /// data from one Telnyx bucket to another.
    /// </summary>
    public required ApiEnum<string, Provider> Provider {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init { this._rawBodyData.Set("provider", value); }
    }

    public required ProviderAuth ProviderAuth {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ProviderAuth>(
                "provider_auth"
            );
        }
        init { this._rawBodyData.Set("provider_auth", value); }
    }

    /// <summary>
    /// For intra-Telnyx buckets migration, specify the source bucket region in this field.
    /// </summary>
    public string? SourceRegion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "source_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("source_region", value);
        }
    }

    public MigrationSourceCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceCreateParams (
        MigrationSourceCreateParams migrationSourceCreateParams
    ) : base(migrationSourceCreateParams)
    { this._rawBodyData = new(migrationSourceCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public MigrationSourceCreateParams (
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
    MigrationSourceCreateParams (
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
    public static MigrationSourceCreateParams FromRawUnchecked(
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

    public virtual bool Equals(MigrationSourceCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/storage/migration_sources"
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
/// Cloud provider from which to migrate data. Use 'telnyx' if you want to migrate
/// data from one Telnyx bucket to another.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Aws, Telnyx
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "aws"=>Provider.Aws, "telnyx"=>Provider.Telnyx, _ =>(Provider)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Aws=>"aws",
            Provider.Telnyx=>"telnyx",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ProviderAuth, ProviderAuthFromRaw>))]
public sealed record class ProviderAuth : JsonModel
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

    public ProviderAuth ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProviderAuth (ProviderAuth providerAuth) : base(providerAuth)
    {  }
    #pragma warning restore CS8618

    public ProviderAuth (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProviderAuth (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProviderAuthFromRaw.FromRawUnchecked"/>
    public static ProviderAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProviderAuthFromRaw : IFromRawJson<ProviderAuth>
{
    /// <inheritdoc/>
    public ProviderAuth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProviderAuth.FromRawUnchecked(rawData);
}