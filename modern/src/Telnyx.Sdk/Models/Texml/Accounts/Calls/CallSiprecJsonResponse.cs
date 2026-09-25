using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

[JsonConverter(typeof(JsonModelConverter<CallSiprecJsonResponse, CallSiprecJsonResponseFromRaw>))]
public sealed record class CallSiprecJsonResponse : JsonModel
{
    /// <summary>
    /// The id of the account the resource belongs to.
    /// </summary>
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

    /// <summary>
    /// The id of the call the resource belongs to.
    /// </summary>
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

    /// <summary>
    /// The date and time the siprec session was created.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created", value);
        }
    }

    /// <summary>
    /// The date and time the siprec session was last updated.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The error code of the siprec session.
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_code", value);
        }
    }

    /// <summary>
    /// The SID of the siprec session.
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
    /// The date and time the siprec session was started.
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// The status of the siprec session.
    /// </summary>
    public ApiEnum<string, CallSiprecJsonResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSiprecJsonResponseStatus>>(
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
    /// The track used for the siprec session.
    /// </summary>
    public ApiEnum<string, CallSiprecJsonResponseTrack>? Track {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallSiprecJsonResponseTrack>>(
                "track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("track", value);
        }
    }

    /// <summary>
    /// The URI of the siprec session.
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
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.ErrorCode;
        _ = this.Sid;
        _ = this.StartTime;
        this.Status?.Validate();
        this.Track?.Validate();
        _ = this.Uri;
    }

    public CallSiprecJsonResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecJsonResponse (
        CallSiprecJsonResponse callSiprecJsonResponse
    ) : base(callSiprecJsonResponse)
    {  }
    #pragma warning restore CS8618

    public CallSiprecJsonResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecJsonResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecJsonResponseFromRaw.FromRawUnchecked"/>
    public static CallSiprecJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSiprecJsonResponseFromRaw : IFromRawJson<CallSiprecJsonResponse>
{
    /// <inheritdoc/>
    public CallSiprecJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecJsonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the siprec session.
/// </summary>
[JsonConverter(typeof(CallSiprecJsonResponseStatusConverter))]
public enum CallSiprecJsonResponseStatus
{
    InProgress, Stopped
}sealed class CallSiprecJsonResponseStatusConverter : JsonConverter<CallSiprecJsonResponseStatus>
{
    public override CallSiprecJsonResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>CallSiprecJsonResponseStatus.InProgress,
            "stopped"=>CallSiprecJsonResponseStatus.Stopped,
            _ =>(CallSiprecJsonResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSiprecJsonResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSiprecJsonResponseStatus.InProgress=>"in-progress",
            CallSiprecJsonResponseStatus.Stopped=>"stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The track used for the siprec session.
/// </summary>
[JsonConverter(typeof(CallSiprecJsonResponseTrackConverter))]
public enum CallSiprecJsonResponseTrack
{
    BothTracks, InboundTrack, OutboundTrack
}sealed class CallSiprecJsonResponseTrackConverter : JsonConverter<CallSiprecJsonResponseTrack>
{
    public override CallSiprecJsonResponseTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both_tracks"=>CallSiprecJsonResponseTrack.BothTracks,
            "inbound_track"=>CallSiprecJsonResponseTrack.InboundTrack,
            "outbound_track"=>CallSiprecJsonResponseTrack.OutboundTrack,
            _ =>(CallSiprecJsonResponseTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSiprecJsonResponseTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSiprecJsonResponseTrack.BothTracks=>"both_tracks",
            CallSiprecJsonResponseTrack.InboundTrack=>"inbound_track",
            CallSiprecJsonResponseTrack.OutboundTrack=>"outbound_track",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}