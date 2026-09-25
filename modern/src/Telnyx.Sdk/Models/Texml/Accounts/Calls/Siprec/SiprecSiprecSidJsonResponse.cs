using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.Siprec;

[JsonConverter(typeof(JsonModelConverter<SiprecSiprecSidJsonResponse, SiprecSiprecSidJsonResponseFromRaw>))]
public sealed record class SiprecSiprecSidJsonResponse : JsonModel
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
    /// The status of the siprec session.
    /// </summary>
    public ApiEnum<string, SiprecSiprecSidJsonResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SiprecSiprecSidJsonResponseStatus>>(
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
        _ = this.DateUpdated;
        _ = this.ErrorCode;
        _ = this.Sid;
        this.Status?.Validate();
        _ = this.Uri;
    }

    public SiprecSiprecSidJsonResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SiprecSiprecSidJsonResponse (
        SiprecSiprecSidJsonResponse siprecSiprecSidJsonResponse
    ) : base(siprecSiprecSidJsonResponse)
    {  }
    #pragma warning restore CS8618

    public SiprecSiprecSidJsonResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SiprecSiprecSidJsonResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SiprecSiprecSidJsonResponseFromRaw.FromRawUnchecked"/>
    public static SiprecSiprecSidJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SiprecSiprecSidJsonResponseFromRaw : IFromRawJson<SiprecSiprecSidJsonResponse>
{
    /// <inheritdoc/>
    public SiprecSiprecSidJsonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SiprecSiprecSidJsonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the siprec session.
/// </summary>
[JsonConverter(typeof(SiprecSiprecSidJsonResponseStatusConverter))]
public enum SiprecSiprecSidJsonResponseStatus
{
    InProgress, Stopped
}sealed class SiprecSiprecSidJsonResponseStatusConverter : JsonConverter<SiprecSiprecSidJsonResponseStatus>
{
    public override SiprecSiprecSidJsonResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>SiprecSiprecSidJsonResponseStatus.InProgress,
            "stopped"=>SiprecSiprecSidJsonResponseStatus.Stopped,
            _ =>(SiprecSiprecSidJsonResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SiprecSiprecSidJsonResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SiprecSiprecSidJsonResponseStatus.InProgress=>"in-progress",
            SiprecSiprecSidJsonResponseStatus.Stopped=>"stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}