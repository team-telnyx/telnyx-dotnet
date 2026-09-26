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

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

/// <summary>
/// Updates the specified conference participant, for example muting or holding them,
/// and returns the updated participant.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParticipantUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public required string ConferenceSid { get; init; }

    public string? CallSidOrParticipantLabel { get; init; }

    /// <summary>
    /// The HTTP method used to call the `AnnounceUrl`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, AnnounceMethod>? AnnounceMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AnnounceMethod>>(
                "AnnounceMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AnnounceMethod", value);
        }
    }

    /// <summary>
    /// The URL to call to announce something to the participant. The URL may return
    /// an MP3 fileo a WAV file, or a TwiML document that contains `&lt;Play&gt;`,
    /// `&lt;Say&gt;`, `&lt;Pause&gt;`, or `&lt;Redirect&gt;` verbs.
    /// </summary>
    public string? AnnounceUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "AnnounceUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AnnounceUrl", value);
        }
    }

    /// <summary>
    /// Whether to play a notification beep to the conference when the participant exits.
    /// </summary>
    public bool? BeepOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "BeepOnExit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("BeepOnExit", value);
        }
    }

    /// <summary>
    /// The SID of the participant who is being coached. The participant being coached
    /// is the only participant who can hear the participant who is coaching.
    /// </summary>
    public string? CallSidToCoach {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "CallSidToCoach"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("CallSidToCoach", value);
        }
    }

    /// <summary>
    /// Whether the participant is coaching another call. When `true`, `CallSidToCoach`
    /// has to be given.
    /// </summary>
    public bool? Coaching {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Coaching"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Coaching", value);
        }
    }

    /// <summary>
    /// Whether to end the conference when the participant leaves.
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "EndConferenceOnExit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("EndConferenceOnExit", value);
        }
    }

    /// <summary>
    /// Whether the participant should be on hold.
    /// </summary>
    public bool? Hold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Hold", value);
        }
    }

    /// <summary>
    /// The HTTP method to use when calling the `HoldUrl`.
    /// </summary>
    public ApiEnum<string, HoldMethod>? HoldMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, HoldMethod>>(
                "HoldMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("HoldMethod", value);
        }
    }

    /// <summary>
    /// The URL to be called using the `HoldMethod` for music that plays when the
    /// participant is on hold. The URL may return an MP3 file, a WAV file, or a
    /// TwiML document that contains `&lt;Play&gt;`, `&lt;Say&gt;`, `&lt;Pause&gt;`,
    /// or `&lt;Redirect&gt;` verbs.
    /// </summary>
    public string? HoldUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "HoldUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("HoldUrl", value);
        }
    }

    /// <summary>
    /// Whether the participant should be muted.
    /// </summary>
    public bool? Muted {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Muted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Muted", value);
        }
    }

    /// <summary>
    /// The URL to call for an audio file to play while the participant is waiting
    /// for the conference to start.
    /// </summary>
    public string? WaitUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "WaitUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("WaitUrl", value);
        }
    }

    public ParticipantUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParticipantUpdateParams (
        ParticipantUpdateParams participantUpdateParams
    ) : base(participantUpdateParams)
    {
        this.AccountSid = participantUpdateParams.AccountSid;
        this.ConferenceSid = participantUpdateParams.ConferenceSid;
        this.CallSidOrParticipantLabel = participantUpdateParams.CallSidOrParticipantLabel;

        this._rawBodyData = new(participantUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ParticipantUpdateParams (
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
    ParticipantUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid,
        string callSidOrParticipantLabel
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountSid = accountSid;
        this.ConferenceSid = conferenceSid;
        this.CallSidOrParticipantLabel = callSidOrParticipantLabel;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ParticipantUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid,
        string callSidOrParticipantLabel
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountSid,
            conferenceSid,
            callSidOrParticipantLabel
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["ConferenceSid"] = JsonSerializer.SerializeToElement(this.ConferenceSid),
        ["CallSidOrParticipantLabel"] = JsonSerializer.SerializeToElement(this.CallSidOrParticipantLabel),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ParticipantUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&this.ConferenceSid.Equals(other.ConferenceSid)&&(this.CallSidOrParticipantLabel?.Equals(other.CallSidOrParticipantLabel) ?? other.CallSidOrParticipantLabel == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Conferences/{1}/Participants/{2}",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.ConferenceSid),
            EncodePathSegment(this.CallSidOrParticipantLabel))
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
/// The HTTP method used to call the `AnnounceUrl`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(AnnounceMethodConverter))]
public enum AnnounceMethod
{
    Get, Post
}

sealed class AnnounceMethodConverter : JsonConverter<AnnounceMethod>
{
    public override AnnounceMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>AnnounceMethod.Get,
            "POST"=>AnnounceMethod.Post,
            _ =>(AnnounceMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnnounceMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AnnounceMethod.Get=>"GET",
            AnnounceMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The HTTP method to use when calling the `HoldUrl`.
/// </summary>
[JsonConverter(typeof(HoldMethodConverter))]
public enum HoldMethod
{
    Get, Post
}

sealed class HoldMethodConverter : JsonConverter<HoldMethod>
{
    public override HoldMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>HoldMethod.Get, "POST"=>HoldMethod.Post, _ =>(HoldMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, HoldMethod value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            HoldMethod.Get=>"GET",
            HoldMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}