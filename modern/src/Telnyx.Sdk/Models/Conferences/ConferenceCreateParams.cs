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

namespace Telnyx.Sdk.Models.Conferences;

/// <summary>
/// Create a conference from an existing call leg using a `call_control_id` and a
/// conference name. Upon creating the conference, the call will be automatically
/// bridged to the conference. Conferences will expire after all participants have
/// left the conference or after 4 hours regardless of the number of active participants.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `conference.created` - `conference.participant.joined` - `conference.participant.left`
/// - `conference.ended` - `conference.recording.saved` - `conference.floor.changed`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Unique identifier and token for controlling the call
    /// </summary>
    public required string CallControlID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawBodyData.Set("call_control_id", value); }
    }

    /// <summary>
    /// Name of the conference
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Whether a beep sound should be played when participants join and/or leave
    /// the conference.
    /// </summary>
    public ApiEnum<string, BeepEnabled>? BeepEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BeepEnabled>>(
                "beep_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("beep_enabled", value);
        }
    }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string. The client_state will be updated for the creator
    /// call leg and will be used for all webhooks related to the created conference.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Toggle background comfort noise.
    /// </summary>
    public bool? ComfortNoise {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "comfort_noise"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("comfort_noise", value);
        }
    }

    /// <summary>
    /// Use this field to avoid execution of duplicate commands. Telnyx will ignore
    /// subsequent commands with the same `command_id` as one that has already been executed.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Time length (minutes) after which the conference will end.
    /// </summary>
    public long? DurationMinutes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "duration_minutes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("duration_minutes", value);
        }
    }

    /// <summary>
    /// The URL of a file to be played to participants joining the conference. The
    /// URL can point to either a WAV or MP3 file. hold_media_name and hold_audio_url
    /// cannot be used together in one request. Takes effect only when "start_conference_on_create"
    /// is set to "false".
    /// </summary>
    public string? HoldAudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "hold_audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold_audio_url", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played to participants joining the conference.
    /// The media_name must point to a file previously uploaded to api.telnyx.com/v2/media
    /// by the same user/organization. The file must either be a WAV or MP3 file.
    /// Takes effect only when "start_conference_on_create" is set to "false".
    /// </summary>
    public string? HoldMediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "hold_media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("hold_media_name", value);
        }
    }

    /// <summary>
    /// The maximum number of active conference participants to allow. Must be between
    /// 2 and 800. Defaults to 250
    /// </summary>
    public long? MaxParticipants {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_participants", value);
        }
    }

    /// <summary>
    /// Sets the region where the conference data will be hosted. Defaults to the
    /// region defined in user's data locality settings (Europe or US).
    /// </summary>
    public ApiEnum<string, Region>? Region {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Region>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("region", value);
        }
    }

    /// <summary>
    /// Whether the conference should be started on creation. If the conference isn't
    /// started all participants that join are automatically put on hold. Defaults
    /// to "true".
    /// </summary>
    public bool? StartConferenceOnCreate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "start_conference_on_create"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("start_conference_on_create", value);
        }
    }

    public ConferenceCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceCreateParams (
        ConferenceCreateParams conferenceCreateParams
    ) : base(conferenceCreateParams)
    { this._rawBodyData = new(conferenceCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public ConferenceCreateParams (
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
    ConferenceCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConferenceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ConferenceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/conferences"
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
/// Whether a beep sound should be played when participants join and/or leave the conference.
/// </summary>
[JsonConverter(typeof(BeepEnabledConverter))]
public enum BeepEnabled
{
    Always, Never, OnEnter, OnExit
}

sealed class BeepEnabledConverter : JsonConverter<BeepEnabled>
{
    public override BeepEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>BeepEnabled.Always,
            "never"=>BeepEnabled.Never,
            "on_enter"=>BeepEnabled.OnEnter,
            "on_exit"=>BeepEnabled.OnExit,
            _ =>(BeepEnabled)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, BeepEnabled value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BeepEnabled.Always=>"always",
            BeepEnabled.Never=>"never",
            BeepEnabled.OnEnter=>"on_enter",
            BeepEnabled.OnExit=>"on_exit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sets the region where the conference data will be hosted. Defaults to the region
/// defined in user's data locality settings (Europe or US).
/// </summary>
[JsonConverter(typeof(RegionConverter))]
public enum Region
{
    Australia, Europe, MiddleEast, Us
}

sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Australia"=>Region.Australia,
            "Europe"=>Region.Europe,
            "Middle East"=>Region.MiddleEast,
            "US"=>Region.Us,
            _ =>(Region)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Region value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Region.Australia=>"Australia",
            Region.Europe=>"Europe",
            Region.MiddleEast=>"Middle East",
            Region.Us=>"US",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}