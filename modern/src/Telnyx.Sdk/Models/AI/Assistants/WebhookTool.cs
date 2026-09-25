using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<WebhookTool, WebhookToolFromRaw>))]
public sealed record class WebhookTool : JsonModel
{
    public required ApiEnum<string, WebhookToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebhookToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required WebhookToolWebhook Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebhookToolWebhook>(
                "webhook"
            );
        }
        init { this._rawData.Set("webhook", value); }
    }

    /// <summary>
    /// The maximum number of milliseconds to wait for the webhook to respond before
    /// the tool call is aborted. Set this at the tool level, as a sibling of `type`
    /// — a `timeout_ms` nested inside the `webhook` object is not applied, and the
    /// tool runs at this default instead.
    /// </summary>
    public long? TimeoutMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Webhook.Validate();
        _ = this.TimeoutMs;
    }

    public WebhookTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookTool (WebhookTool webhookTool) : base(webhookTool)
    {  }
    #pragma warning restore CS8618

    public WebhookTool (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolFromRaw.FromRawUnchecked"/>
    public static WebhookTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookToolFromRaw : IFromRawJson<WebhookTool>
{
    /// <inheritdoc/>
    public WebhookTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookToolTypeConverter))]
public enum WebhookToolType
{
    Webhook
}sealed class WebhookToolTypeConverter : JsonConverter<WebhookToolType>
{
    public override WebhookToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "webhook"=>WebhookToolType.Webhook, _ =>(WebhookToolType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookToolType.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WebhookToolWebhook, WebhookToolWebhookFromRaw>))]
public sealed record class WebhookToolWebhook : JsonModel
{
    /// <summary>
    /// The description of the tool.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the tool.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The URL of the external tool to be called. This URL is going to be used by
    /// the assistant. The URL can be templated like: `https://example.com/api/v1/{id}`,
    /// where `{id}` is a placeholder for a value that will be provided by the assistant
    /// if `path_parameters` are provided with the `id` attribute.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// The body parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the body of the
    /// request. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public WebhookToolWebhookBodyParameters? BodyParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookToolWebhookBodyParameters>(
                "body_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body_parameters", value);
        }
    }

    /// <summary>
    /// The headers to be sent to the external tool.
    /// </summary>
    public IReadOnlyList<WebhookToolWebhookHeader>? Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookToolWebhookHeader>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookToolWebhookHeader>?>(
                "headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The HTTP method to be used when calling the external tool.
    /// </summary>
    public ApiEnum<string, WebhookToolWebhookMethod>? Method {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookToolWebhookMethod>>(
                "method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <summary>
    /// The path parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the path of the
    /// request if the URL contains a placeholder for a value. See the [JSON Schema
    /// reference](https://json-schema.org/understanding-json-schema) for documentation
    /// about the format
    /// </summary>
    public WebhookToolWebhookPathParameters? PathParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookToolWebhookPathParameters>(
                "path_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("path_parameters", value);
        }
    }

    /// <summary>
    /// The query parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the query of the
    /// request. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public WebhookToolWebhookQueryParameters? QueryParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookToolWebhookQueryParameters>(
                "query_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("query_parameters", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.Url;
        this.BodyParameters?.Validate();
        foreach (var item in this.Headers ?? [])
        {
            item.Validate();
        }
        this.Method?.Validate();
        this.PathParameters?.Validate();
        this.QueryParameters?.Validate();
    }

    public WebhookToolWebhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolWebhook (WebhookToolWebhook webhookToolWebhook) : base(
        webhookToolWebhook
    )
    {  }
    #pragma warning restore CS8618

    public WebhookToolWebhook (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolWebhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolWebhookFromRaw.FromRawUnchecked"/>
    public static WebhookToolWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolWebhookFromRaw : IFromRawJson<WebhookToolWebhook>
{
    /// <inheritdoc/>
    public WebhookToolWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolWebhook.FromRawUnchecked(rawData);
}/// <summary>
/// The body parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the body of the request. See
/// the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookToolWebhookBodyParameters, WebhookToolWebhookBodyParametersFromRaw>))]
public sealed record class WebhookToolWebhookBodyParameters : JsonModel
{
    /// <summary>
    /// The properties of the body parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the body parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, WebhookToolWebhookBodyParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookToolWebhookBodyParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public WebhookToolWebhookBodyParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolWebhookBodyParameters (
        WebhookToolWebhookBodyParameters webhookToolWebhookBodyParameters
    ) : base(webhookToolWebhookBodyParameters)
    {  }
    #pragma warning restore CS8618

    public WebhookToolWebhookBodyParameters (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolWebhookBodyParameters (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolWebhookBodyParametersFromRaw.FromRawUnchecked"/>
    public static WebhookToolWebhookBodyParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolWebhookBodyParametersFromRaw : IFromRawJson<WebhookToolWebhookBodyParameters>
{
    /// <inheritdoc/>
    public WebhookToolWebhookBodyParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolWebhookBodyParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WebhookToolWebhookBodyParametersTypeConverter))]
public enum WebhookToolWebhookBodyParametersType
{
    Object
}sealed class WebhookToolWebhookBodyParametersTypeConverter : JsonConverter<WebhookToolWebhookBodyParametersType>
{
    public override WebhookToolWebhookBodyParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object"=>WebhookToolWebhookBodyParametersType.Object,
            _ =>(WebhookToolWebhookBodyParametersType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookToolWebhookBodyParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookToolWebhookBodyParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WebhookToolWebhookHeader, WebhookToolWebhookHeaderFromRaw>))]
public sealed record class WebhookToolWebhookHeader : JsonModel
{
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `Bearer {{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret as the bearer token.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public WebhookToolWebhookHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolWebhookHeader (
        WebhookToolWebhookHeader webhookToolWebhookHeader
    ) : base(webhookToolWebhookHeader)
    {  }
    #pragma warning restore CS8618

    public WebhookToolWebhookHeader (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolWebhookHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolWebhookHeaderFromRaw.FromRawUnchecked"/>
    public static WebhookToolWebhookHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolWebhookHeaderFromRaw : IFromRawJson<WebhookToolWebhookHeader>
{
    /// <inheritdoc/>
    public WebhookToolWebhookHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolWebhookHeader.FromRawUnchecked(rawData);
}/// <summary>
/// The HTTP method to be used when calling the external tool.
/// </summary>
[JsonConverter(typeof(WebhookToolWebhookMethodConverter))]
public enum WebhookToolWebhookMethod
{
    Get, Post, Put, Delete, Patch
}sealed class WebhookToolWebhookMethodConverter : JsonConverter<WebhookToolWebhookMethod>
{
    public override WebhookToolWebhookMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WebhookToolWebhookMethod.Get,
            "POST"=>WebhookToolWebhookMethod.Post,
            "PUT"=>WebhookToolWebhookMethod.Put,
            "DELETE"=>WebhookToolWebhookMethod.Delete,
            "PATCH"=>WebhookToolWebhookMethod.Patch,
            _ =>(WebhookToolWebhookMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookToolWebhookMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookToolWebhookMethod.Get=>"GET",
            WebhookToolWebhookMethod.Post=>"POST",
            WebhookToolWebhookMethod.Put=>"PUT",
            WebhookToolWebhookMethod.Delete=>"DELETE",
            WebhookToolWebhookMethod.Patch=>"PATCH",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The path parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the path of the request if
/// the URL contains a placeholder for a value. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookToolWebhookPathParameters, WebhookToolWebhookPathParametersFromRaw>))]
public sealed record class WebhookToolWebhookPathParameters : JsonModel
{
    /// <summary>
    /// The properties of the path parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the path parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, WebhookToolWebhookPathParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookToolWebhookPathParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public WebhookToolWebhookPathParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolWebhookPathParameters (
        WebhookToolWebhookPathParameters webhookToolWebhookPathParameters
    ) : base(webhookToolWebhookPathParameters)
    {  }
    #pragma warning restore CS8618

    public WebhookToolWebhookPathParameters (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolWebhookPathParameters (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolWebhookPathParametersFromRaw.FromRawUnchecked"/>
    public static WebhookToolWebhookPathParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolWebhookPathParametersFromRaw : IFromRawJson<WebhookToolWebhookPathParameters>
{
    /// <inheritdoc/>
    public WebhookToolWebhookPathParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolWebhookPathParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WebhookToolWebhookPathParametersTypeConverter))]
public enum WebhookToolWebhookPathParametersType
{
    Object
}sealed class WebhookToolWebhookPathParametersTypeConverter : JsonConverter<WebhookToolWebhookPathParametersType>
{
    public override WebhookToolWebhookPathParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object"=>WebhookToolWebhookPathParametersType.Object,
            _ =>(WebhookToolWebhookPathParametersType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookToolWebhookPathParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookToolWebhookPathParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The query parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the query of the request. See
/// the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookToolWebhookQueryParameters, WebhookToolWebhookQueryParametersFromRaw>))]
public sealed record class WebhookToolWebhookQueryParameters : JsonModel
{
    /// <summary>
    /// The properties of the query parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the query parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, WebhookToolWebhookQueryParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookToolWebhookQueryParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public WebhookToolWebhookQueryParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolWebhookQueryParameters (
        WebhookToolWebhookQueryParameters webhookToolWebhookQueryParameters
    ) : base(webhookToolWebhookQueryParameters)
    {  }
    #pragma warning restore CS8618

    public WebhookToolWebhookQueryParameters (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolWebhookQueryParameters (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolWebhookQueryParametersFromRaw.FromRawUnchecked"/>
    public static WebhookToolWebhookQueryParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolWebhookQueryParametersFromRaw : IFromRawJson<WebhookToolWebhookQueryParameters>
{
    /// <inheritdoc/>
    public WebhookToolWebhookQueryParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolWebhookQueryParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WebhookToolWebhookQueryParametersTypeConverter))]
public enum WebhookToolWebhookQueryParametersType
{
    Object
}sealed class WebhookToolWebhookQueryParametersTypeConverter : JsonConverter<WebhookToolWebhookQueryParametersType>
{
    public override WebhookToolWebhookQueryParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object"=>WebhookToolWebhookQueryParametersType.Object,
            _ =>(WebhookToolWebhookQueryParametersType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookToolWebhookQueryParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookToolWebhookQueryParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}