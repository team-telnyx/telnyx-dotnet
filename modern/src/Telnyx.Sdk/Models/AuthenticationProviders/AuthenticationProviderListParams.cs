using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

/// <summary>
/// Returns a list of your SSO authentication providers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AuthenticationProviderListParams : ParamsBase
{
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

    /// <summary>
    /// Specifies the sort order for results. By default sorting direction is ascending.
    /// To have the results sorted in descending order add the &lt;code&gt;-&lt;/code&gt;
    /// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;name&lt;/code&gt;:
    /// sorts the result by the     &lt;code&gt;name&lt;/code&gt; field in ascending
    /// order.   &lt;/li&gt;   &lt;li&gt;     &lt;code&gt;-name&lt;/code&gt;: sorts
    /// the result by the     &lt;code&gt;name&lt;/code&gt; field in descending order.
    ///   &lt;/li&gt; &lt;/ul&gt;&lt;br/&gt;If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
    /// in descending order.
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public AuthenticationProviderListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderListParams (
        AuthenticationProviderListParams authenticationProviderListParams
    ) : base(authenticationProviderListParams)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AuthenticationProviderListParams FromRawUnchecked(
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

    public virtual bool Equals(AuthenticationProviderListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/authentication_providers"
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
/// Specifies the sort order for results. By default sorting direction is ascending.
/// To have the results sorted in descending order add the &lt;code&gt;-&lt;/code&gt;
/// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;name&lt;/code&gt;:
/// sorts the result by the     &lt;code&gt;name&lt;/code&gt; field in ascending
/// order.   &lt;/li&gt;   &lt;li&gt;     &lt;code&gt;-name&lt;/code&gt;: sorts the
/// result by the     &lt;code&gt;name&lt;/code&gt; field in descending order.
/// &lt;/li&gt; &lt;/ul&gt;&lt;br/&gt;If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
/// in descending order.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    Name,
    NameDesc,
    ShortName,
    ShortNameDesc,
    Active,
    ActiveDesc,
    CreatedAt,
    CreatedAtDesc,
    UpdatedAt,
    UpdatedAtDesc
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "name"=>Sort.Name,
            "-name"=>Sort.NameDesc,
            "short_name"=>Sort.ShortName,
            "-short_name"=>Sort.ShortNameDesc,
            "active"=>Sort.Active,
            "-active"=>Sort.ActiveDesc,
            "created_at"=>Sort.CreatedAt,
            "-created_at"=>Sort.CreatedAtDesc,
            "updated_at"=>Sort.UpdatedAt,
            "-updated_at"=>Sort.UpdatedAtDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.Name=>"name",
            Sort.NameDesc=>"-name",
            Sort.ShortName=>"short_name",
            Sort.ShortNameDesc=>"-short_name",
            Sort.Active=>"active",
            Sort.ActiveDesc=>"-active",
            Sort.CreatedAt=>"created_at",
            Sort.CreatedAtDesc=>"-created_at",
            Sort.UpdatedAt=>"updated_at",
            Sort.UpdatedAtDesc=>"-updated_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}