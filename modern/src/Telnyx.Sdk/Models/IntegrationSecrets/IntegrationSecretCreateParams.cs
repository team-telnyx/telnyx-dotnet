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

namespace Telnyx.Sdk.Models.IntegrationSecrets;

/// <summary>
/// Create a new secret with an associated identifier that can be used to securely
/// integrate with other services.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IntegrationSecretCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The unique identifier of the secret.
    /// </summary>
    public required string Identifier {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "identifier"
            );
        }
        init { this._rawBodyData.Set("identifier", value); }
    }

    /// <summary>
    /// The type of secret.
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.IntegrationSecrets.Type> Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.IntegrationSecrets.Type>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// The token for the secret. Required for bearer type secrets, ignored otherwise.
    /// </summary>
    public string? Token {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("token", value);
        }
    }

    /// <summary>
    /// The password for the secret. Required for basic type secrets, ignored otherwise.
    /// </summary>
    public string? Password {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("password", value);
        }
    }

    /// <summary>
    /// The username for the secret. Required for basic type secrets, ignored otherwise.
    /// </summary>
    public string? Username {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("username", value);
        }
    }

    public IntegrationSecretCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationSecretCreateParams (
        IntegrationSecretCreateParams integrationSecretCreateParams
    ) : base(integrationSecretCreateParams)
    { this._rawBodyData = new(integrationSecretCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public IntegrationSecretCreateParams (
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
    IntegrationSecretCreateParams (
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
    public static IntegrationSecretCreateParams FromRawUnchecked(
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

    public virtual bool Equals(IntegrationSecretCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/integration_secrets"
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
/// The type of secret.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Bearer, Basic
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.IntegrationSecrets.Type>
{
    public override global::Telnyx.Sdk.Models.IntegrationSecrets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bearer"=>global::Telnyx.Sdk.Models.IntegrationSecrets.Type.Bearer,
            "basic"=>global::Telnyx.Sdk.Models.IntegrationSecrets.Type.Basic,
            _ =>(global::Telnyx.Sdk.Models.IntegrationSecrets.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.IntegrationSecrets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.IntegrationSecrets.Type.Bearer=>"bearer",
            global::Telnyx.Sdk.Models.IntegrationSecrets.Type.Basic=>"basic",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}