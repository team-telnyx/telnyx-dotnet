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

namespace Telnyx.Sdk.Models.Texml.Calls;

/// <summary>
/// Initiate an outbound TeXML call using a TeXML application connection ID, not
/// an account SID. Request parameter names are case-sensitive. From and To are required;
/// Texml supplies inline instructions and Url overrides the application XML request
/// URL. When neither is supplied, the application configuration supplies the instructions.
/// The response is a flat call object without a data wrapper.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConnectionID { get; init; }

    /// <summary>
    /// The E.164-formatted phone number or SIP URI to present as the caller.
    /// </summary>
    public required string From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "From"
            );
        }
        init { this._rawBodyData.Set("From", value); }
    }

    /// <summary>
    /// The E.164-formatted phone number or SIP URI to call.
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "To"
            );
        }
        init { this._rawBodyData.Set("To", value); }
    }

    /// <summary>
    /// HTTP method used to retrieve TeXML instructions from Url.
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
    /// Inline TeXML instructions to execute when the call is answered.
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
    /// The URL from which to retrieve TeXML instructions. Overrides the TeXML application
    /// XML request URL.
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

    public CallCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCreateParams (CallCreateParams callCreateParams) : base(
        callCreateParams
    )
    {
        this.ConnectionID = callCreateParams.ConnectionID;

        this._rawBodyData = new(callCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CallCreateParams (
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
    CallCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConnectionID = connectionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            connectionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ConnectionID"] = JsonSerializer.SerializeToElement(this.ConnectionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConnectionID?.Equals(other.ConnectionID) ?? other.ConnectionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/calls/{0}",
            this.ConnectionID)
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
/// HTTP method used to retrieve TeXML instructions from Url.
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