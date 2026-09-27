using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuthClients;

/// <summary>
/// Retrieve a paginated list of OAuth clients for the authenticated user
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthClientListParams : ParamsBase
{
    /// <summary>
    /// Filter by allowed grant type
    /// </summary>
    public ApiEnum<string, FilterAllowedGrantTypesContains>? FilterAllowedGrantTypesContains {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterAllowedGrantTypesContains>>(
                "filter[allowed_grant_types][contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[allowed_grant_types][contains]", value);
        }
    }

    /// <summary>
    /// Filter by client ID
    /// </summary>
    public string? FilterClientID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[client_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[client_id]", value);
        }
    }

    /// <summary>
    /// Filter by client type
    /// </summary>
    public ApiEnum<string, FilterClientType>? FilterClientType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterClientType>>(
                "filter[client_type]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[client_type]", value);
        }
    }

    /// <summary>
    /// Filter by exact client name
    /// </summary>
    public string? FilterName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[name]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[name]", value);
        }
    }

    /// <summary>
    /// Filter by client name containing text
    /// </summary>
    public string? FilterNameContains {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[name][contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[name][contains]", value);
        }
    }

    /// <summary>
    /// Filter by verification status
    /// </summary>
    public bool? FilterVerified {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "filter[verified]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[verified]", value);
        }
    }

    /// <summary>
    /// Page number
    /// </summary>
    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    /// <summary>
    /// Number of results per page
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public OAuthClientListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientListParams (
        OAuthClientListParams oauthClientListParams
    ) : base(oauthClientListParams)
    {  }
    #pragma warning restore CS8618

    public OAuthClientListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClientListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OAuthClientListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(OAuthClientListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/oauth_clients"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Filter by allowed grant type
/// </summary>
[JsonConverter(typeof(FilterAllowedGrantTypesContainsConverter))]
public enum FilterAllowedGrantTypesContains
{
    ClientCredentials, AuthorizationCode, RefreshToken
}

sealed class FilterAllowedGrantTypesContainsConverter : JsonConverter<FilterAllowedGrantTypesContains>
{
    public override FilterAllowedGrantTypesContains Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_credentials"=>FilterAllowedGrantTypesContains.ClientCredentials,
            "authorization_code"=>FilterAllowedGrantTypesContains.AuthorizationCode,
            "refresh_token"=>FilterAllowedGrantTypesContains.RefreshToken,
            _ =>(FilterAllowedGrantTypesContains)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterAllowedGrantTypesContains value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterAllowedGrantTypesContains.ClientCredentials=>"client_credentials",
            FilterAllowedGrantTypesContains.AuthorizationCode=>"authorization_code",
            FilterAllowedGrantTypesContains.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by client type
/// </summary>
[JsonConverter(typeof(FilterClientTypeConverter))]
public enum FilterClientType
{
    Confidential, Public
}

sealed class FilterClientTypeConverter : JsonConverter<FilterClientType>
{
    public override FilterClientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "confidential"=>FilterClientType.Confidential,
            "public"=>FilterClientType.Public,
            _ =>(FilterClientType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterClientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterClientType.Confidential=>"confidential",
            FilterClientType.Public=>"public",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}