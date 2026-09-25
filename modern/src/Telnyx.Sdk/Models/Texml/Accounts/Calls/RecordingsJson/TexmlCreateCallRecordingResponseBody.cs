using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

[JsonConverter(typeof(JsonModelConverter<TexmlCreateCallRecordingResponseBody, TexmlCreateCallRecordingResponseBodyFromRaw>))]
public sealed record class TexmlCreateCallRecordingResponseBody : JsonModel
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

    public ApiEnum<long, TwimlRecordingChannels>? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, TwimlRecordingChannels>>(
                "channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    public string? ConferenceSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_sid"
            );
        }
        init { this._rawData.Set("conference_sid", value); }
    }

    public System::DateTimeOffset? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// The duration of this recording, given in seconds.
    /// </summary>
    public string? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "duration"
            );
        }
        init { this._rawData.Set("duration", value); }
    }

    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// The price of this recording, the currency is specified in the price_unit
    /// field.
    /// </summary>
    public string? Price {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "price"
            );
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// The unit in which the price is given.
    /// </summary>
    public string? PriceUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "price_unit"
            );
        }
        init { this._rawData.Set("price_unit", value); }
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
    /// Defines how the recording was created.
    /// </summary>
    public ApiEnum<string, RecordingSource>? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingSource>>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public System::DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// The audio track to record for the call. The default is `both`.
    /// </summary>
    public ApiEnum<string, Track>? Track {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Track>>(
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
    /// The relative URI for this recording resource.
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
        this.Channels?.Validate();
        _ = this.ConferenceSid;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.Duration;
        _ = this.ErrorCode;
        _ = this.Price;
        _ = this.PriceUnit;
        _ = this.Sid;
        this.Source?.Validate();
        _ = this.StartTime;
        this.Track?.Validate();
        _ = this.Uri;
    }

    public TexmlCreateCallRecordingResponseBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlCreateCallRecordingResponseBody (
        TexmlCreateCallRecordingResponseBody texmlCreateCallRecordingResponseBody
    ) : base(texmlCreateCallRecordingResponseBody)
    {  }
    #pragma warning restore CS8618

    public TexmlCreateCallRecordingResponseBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlCreateCallRecordingResponseBody (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlCreateCallRecordingResponseBodyFromRaw.FromRawUnchecked"/>
    public static TexmlCreateCallRecordingResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlCreateCallRecordingResponseBodyFromRaw : IFromRawJson<TexmlCreateCallRecordingResponseBody>
{
    /// <inheritdoc/>
    public TexmlCreateCallRecordingResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlCreateCallRecordingResponseBody.FromRawUnchecked(rawData);
}

/// <summary>
/// The audio track to record for the call. The default is `both`.
/// </summary>
[JsonConverter(typeof(TrackConverter))]
public enum Track
{
    Inbound, Outbound, Both
}sealed class TrackConverter : JsonConverter<Track>
{
    public override Track Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>Track.Inbound,
            "outbound"=>Track.Outbound,
            "both"=>Track.Both,
            _ =>(Track)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Track value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Track.Inbound=>"inbound",
            Track.Outbound=>"outbound",
            Track.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}