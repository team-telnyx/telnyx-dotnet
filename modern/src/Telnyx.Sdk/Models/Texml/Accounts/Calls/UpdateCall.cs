using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

[JsonConverter(typeof(JsonModelConverter<UpdateCall, UpdateCallFromRaw>))]
public sealed record class UpdateCall : JsonModel
{
    /// <summary>
    /// HTTP request type used for `FallbackUrl`.
    /// </summary>
    public ApiEnum<string, UpdateCallFallbackMethod>? FallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateCallFallbackMethod>>(
                "FallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("FallbackMethod", value);
        }
    }

    /// <summary>
    /// A failover URL for which Telnyx will retrieve the TeXML call instructions
    /// if the Url is not responding.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "FallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("FallbackUrl", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `Url`.
    /// </summary>
    public ApiEnum<string, UpdateCallMethod>? Method {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateCallMethod>>(
                "Method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Method", value);
        }
    }

    /// <summary>
    /// The value to set the call status to. Setting the status to completed ends
    /// the call.
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Status", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, UpdateCallStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UpdateCallStatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// TeXML to replace the current one with.
    /// </summary>
    public string? Texml {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Texml"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Texml", value);
        }
    }

    /// <summary>
    /// The URL where TeXML will make a request to retrieve a new set of TeXML instructions
    /// to continue the call flow.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FallbackMethod?.Validate();
        _ = this.FallbackUrl;
        this.Method?.Validate();
        _ = this.Status;
        _ = this.StatusCallback;
        this.StatusCallbackMethod?.Validate();
        _ = this.Texml;
        _ = this.Url;
    }

    public UpdateCall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateCall (UpdateCall updateCall) : base(updateCall)
    {  }
    #pragma warning restore CS8618

    public UpdateCall (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateCall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateCallFromRaw.FromRawUnchecked"/>
    public static UpdateCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateCallFromRaw : IFromRawJson<UpdateCall>
{
    /// <inheritdoc/>
    public UpdateCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateCall.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `FallbackUrl`.
/// </summary>
[JsonConverter(typeof(UpdateCallFallbackMethodConverter))]
public enum UpdateCallFallbackMethod
{
    Get, Post
}sealed class UpdateCallFallbackMethodConverter : JsonConverter<UpdateCallFallbackMethod>
{
    public override UpdateCallFallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>UpdateCallFallbackMethod.Get,
            "POST"=>UpdateCallFallbackMethod.Post,
            _ =>(UpdateCallFallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateCallFallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateCallFallbackMethod.Get=>"GET",
            UpdateCallFallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// HTTP request type used for `Url`.
/// </summary>
[JsonConverter(typeof(UpdateCallMethodConverter))]
public enum UpdateCallMethod
{
    Get, Post
}sealed class UpdateCallMethodConverter : JsonConverter<UpdateCallMethod>
{
    public override UpdateCallMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>UpdateCallMethod.Get,
            "POST"=>UpdateCallMethod.Post,
            _ =>(UpdateCallMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateCallMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateCallMethod.Get=>"GET",
            UpdateCallMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(UpdateCallStatusCallbackMethodConverter))]
public enum UpdateCallStatusCallbackMethod
{
    Get, Post
}sealed class UpdateCallStatusCallbackMethodConverter : JsonConverter<UpdateCallStatusCallbackMethod>
{
    public override UpdateCallStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>UpdateCallStatusCallbackMethod.Get,
            "POST"=>UpdateCallStatusCallbackMethod.Post,
            _ =>(UpdateCallStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateCallStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UpdateCallStatusCallbackMethod.Get=>"GET",
            UpdateCallStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}