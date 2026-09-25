using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.Streams;

[JsonConverter(typeof(JsonModelConverter<StreamStreamingSidJsonResponse, StreamStreamingSidJsonResponseFromRaw>))]
public sealed record class StreamStreamingSidJsonResponse : JsonModel
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
    public ApiEnum<string, StreamStreamingSidJsonResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StreamStreamingSidJsonResponseStatus>>(
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
        _ = this.Sid;
        this.Status?.Validate();
        _ = this.Uri;
    }

    public StreamStreamingSidJsonResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreamStreamingSidJsonResponse (
        StreamStreamingSidJsonResponse streamStreamingSidJsonResponse
    ) : base(streamStreamingSidJsonResponse)
    {  }
    #pragma warning restore CS8618

    public StreamStreamingSidJsonResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StreamStreamingSidJsonResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StreamStreamingSidJsonResponseFromRaw.FromRawUnchecked"/>
    public static StreamStreamingSidJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StreamStreamingSidJsonResponseFromRaw : IFromRawJson<StreamStreamingSidJsonResponse>
{
    /// <inheritdoc/>
    public StreamStreamingSidJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StreamStreamingSidJsonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the streaming.
/// </summary>
[JsonConverter(typeof(StreamStreamingSidJsonResponseStatusConverter))]
public enum StreamStreamingSidJsonResponseStatus
{
    Stopped
}sealed class StreamStreamingSidJsonResponseStatusConverter : JsonConverter<StreamStreamingSidJsonResponseStatus>
{
    public override StreamStreamingSidJsonResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stopped"=>StreamStreamingSidJsonResponseStatus.Stopped,
            _ =>(StreamStreamingSidJsonResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamStreamingSidJsonResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamStreamingSidJsonResponseStatus.Stopped=>"stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}