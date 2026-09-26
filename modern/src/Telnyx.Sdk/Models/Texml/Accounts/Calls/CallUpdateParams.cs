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

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

/// <summary>
/// Update TeXML call. Please note that the keys present in the payload MUST BE formatted
/// in CamelCase as specified in the example.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? CallSid { get; init; }

    /// <summary>
    /// HTTP request type used for `FallbackUrl`.
    /// </summary>
    public ApiEnum<string, FallbackMethod>? FallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, FallbackMethod>>(
                "FallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("FallbackMethod", value);
        }
    }

    /// <summary>
    /// A failover URL for which Telnyx will retrieve the TeXML call instructions
    /// if the Url is not responding.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "FallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("FallbackUrl", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `Url`.
    /// </summary>
    public ApiEnum<string, Method>? Method {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Method>>(
                "Method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Method", value);
        }
    }

    /// <summary>
    /// The value to set the call status to. Setting the status to completed ends
    /// the call.
    /// </summary>
    public string? Status {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Status", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, StatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// TeXML to replace the current one with.
    /// </summary>
    public string? Texml {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Texml"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Texml", value);
        }
    }

    /// <summary>
    /// The URL where TeXML will make a request to retrieve a new set of TeXML instructions
    /// to continue the call flow.
    /// </summary>
    public string? UrlValue {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Url", value);
        }
    }

    public CallUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallUpdateParams (CallUpdateParams callUpdateParams) : base(
        callUpdateParams
    )
    {
        this.AccountSid = callUpdateParams.AccountSid;
        this.CallSid = callUpdateParams.CallSid;

        this._rawBodyData = new(callUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CallUpdateParams (
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
    CallUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string callSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountSid = accountSid;
        this.CallSid = callSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string callSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountSid,
            callSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["CallSid"] = JsonSerializer.SerializeToElement(this.CallSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&(this.CallSid?.Equals(other.CallSid) ?? other.CallSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls/{1}",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.CallSid))
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
/// HTTP request type used for `FallbackUrl`.
/// </summary>
[JsonConverter(typeof(FallbackMethodConverter))]
public enum FallbackMethod
{
    Get, Post
}

sealed class FallbackMethodConverter : JsonConverter<FallbackMethod>
{
    public override FallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>FallbackMethod.Get,
            "POST"=>FallbackMethod.Post,
            _ =>(FallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FallbackMethod.Get=>"GET",
            FallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `Url`.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Get, Post
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "GET"=>Method.Get, "POST"=>Method.Post, _ =>(Method)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Method value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Method.Get=>"GET",
            Method.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(StatusCallbackMethodConverter))]
public enum StatusCallbackMethod
{
    Get, Post
}

sealed class StatusCallbackMethodConverter : JsonConverter<StatusCallbackMethod>
{
    public override StatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>StatusCallbackMethod.Get,
            "POST"=>StatusCallbackMethod.Post,
            _ =>(StatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusCallbackMethod.Get=>"GET",
            StatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}