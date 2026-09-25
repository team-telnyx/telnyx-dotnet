using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

/// <summary>
/// HTTP request and response information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Http, HttpFromRaw>))]
public sealed record class Http : JsonModel
{
    /// <summary>
    /// Request details.
    /// </summary>
    public Request? Request {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Request>(
                "request"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("request", value);
        }
    }

    /// <summary>
    /// Response details, optional.
    /// </summary>
    public Response? Response {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Response>(
                "response"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("response", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Request?.Validate();
        this.Response?.Validate();
    }

    public Http ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Http (Http http) : base(http)
    {  }
    #pragma warning restore CS8618

    public Http (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Http (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HttpFromRaw.FromRawUnchecked"/>
    public static Http FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HttpFromRaw : IFromRawJson<Http>
{
    /// <inheritdoc/>
    public Http FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Http.FromRawUnchecked(rawData);
}

/// <summary>
/// Request details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
{
    /// <summary>
    /// List of headers, limited to 10kB.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<string>>? Headers {
        get {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<string>>>(
                "headers"
            );
            if (value == null) {
                return null;
            }

            return ImmutableArray.ToImmutableArray(Enumerable.Select(value.Value, ( item )=>(IReadOnlyList<string>)item));
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<string>>?>(
                "headers",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>ImmutableArray.ToImmutableArray(item)))
            );
        }
    }

    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Headers;
        _ = this.Url;
    }

    public Request ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Request (Request request) : base(request)
    {  }
    #pragma warning restore CS8618

    public Request (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Request (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequestFromRaw.FromRawUnchecked"/>
    public static Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RequestFromRaw : IFromRawJson<Request>
{
    /// <inheritdoc/>
    public Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Request.FromRawUnchecked(rawData);
}/// <summary>
/// Response details, optional.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Response, ResponseFromRaw>))]
public sealed record class Response : JsonModel
{
    /// <summary>
    /// Raw response body, limited to 10kB.
    /// </summary>
    public string? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    /// <summary>
    /// List of headers, limited to 10kB.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<string>>? Headers {
        get {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<string>>>(
                "headers"
            );
            if (value == null) {
                return null;
            }

            return ImmutableArray.ToImmutableArray(Enumerable.Select(value.Value, ( item )=>(IReadOnlyList<string>)item));
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<string>>?>(
                "headers",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>ImmutableArray.ToImmutableArray(item)))
            );
        }
    }

    public long? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Headers;
        _ = this.Status;
    }

    public Response ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Response (Response response) : base(response)
    {  }
    #pragma warning restore CS8618

    public Response (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Response (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResponseFromRaw.FromRawUnchecked"/>
    public static Response FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResponseFromRaw : IFromRawJson<Response>
{
    /// <inheritdoc/>
    public Response FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Response.FromRawUnchecked(rawData);
}