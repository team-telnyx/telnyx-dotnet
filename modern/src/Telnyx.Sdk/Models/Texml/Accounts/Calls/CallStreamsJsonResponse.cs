using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

[JsonConverter(typeof(JsonModelConverter<CallStreamsJsonResponse, CallStreamsJsonResponseFromRaw>))]
public sealed record class CallStreamsJsonResponse : JsonModel
{
    public string? AccountSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_sid", value);
        }
    }

    public string? CallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid", value);
        }
    }

    public System::DateTimeOffset? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "date_updated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated", value);
        }
    }

    /// <summary>
    /// The user specified name of Stream.
    /// </summary>
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
    /// Identifier of a resource.
    /// </summary>
    public string? Sid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sid", value);
        }
    }

    /// <summary>
    /// The status of the streaming.
    /// </summary>
    public ApiEnum<string, CallStreamsJsonResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallStreamsJsonResponseStatus>>(
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

    /// <summary>
    /// The relative URI for this streaming resource.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountSid;
        _ = this.CallSid;
        _ = this.DateUpdated;
        _ = this.Name;
        _ = this.Sid;
        this.Status?.Validate();
        _ = this.Uri;
    }

    public CallStreamsJsonResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamsJsonResponse (
        CallStreamsJsonResponse callStreamsJsonResponse
    ) : base(callStreamsJsonResponse)
    {  }
    #pragma warning restore CS8618

    public CallStreamsJsonResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamsJsonResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamsJsonResponseFromRaw.FromRawUnchecked"/>
    public static CallStreamsJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallStreamsJsonResponseFromRaw : IFromRawJson<CallStreamsJsonResponse>
{
    /// <inheritdoc/>
    public CallStreamsJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamsJsonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the streaming.
/// </summary>
[JsonConverter(typeof(CallStreamsJsonResponseStatusConverter))]
public enum CallStreamsJsonResponseStatus
{
    InProgress
}sealed class CallStreamsJsonResponseStatusConverter : JsonConverter<CallStreamsJsonResponseStatus>
{
    public override CallStreamsJsonResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>CallStreamsJsonResponseStatus.InProgress,
            _ =>(CallStreamsJsonResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamsJsonResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamsJsonResponseStatus.InProgress=>"in-progress",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}