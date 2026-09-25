using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Play an audio file on the call until the required DTMF signals are gathered to
/// build interactive menus.
///
/// <para>You can pass a list of valid digits along with an 'invalid_audio_url',
/// which will be played back at the beginning of each prompt. Playback will be interrupted
/// when a DTMF signal is received. The `Answer command must be issued before the
/// `gather_using_audio` command.</para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.playback.started` - `call.playback.ended` - `call.dtmf.received`
/// (you may receive many of these webhooks) - `call.gather.ended`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionGatherUsingAudioParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// The URL of a file to be played back at the beginning of each prompt. The
    /// URL can point to either a WAV or MP3 file. media_name and audio_url cannot
    /// be used together in one request.
    /// </summary>
    public string? AudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("audio_url", value);
        }
    }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
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
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
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
    /// The number of milliseconds to wait for input between digits.
    /// </summary>
    public int? InterDigitTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "inter_digit_timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inter_digit_timeout_millis", value);
        }
    }

    /// <summary>
    /// The URL of a file to play when digits don't match the `valid_digits` parameter
    /// or the number of digits is not between `min` and `max`. The URL can point
    /// to either a WAV or MP3 file. invalid_media_name and invalid_audio_url cannot
    /// be used together in one request.
    /// </summary>
    public string? InvalidAudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "invalid_audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("invalid_audio_url", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played back when digits don't match the `valid_digits`
    /// parameter or the number of digits is not between `min` and `max`. The media_name
    /// must point to a file previously uploaded to api.telnyx.com/v2/media by the
    /// same user/organization. The file must either be a WAV or MP3 file.
    /// </summary>
    public string? InvalidMediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "invalid_media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("invalid_media_name", value);
        }
    }

    /// <summary>
    /// The maximum number of digits to fetch. This parameter has a maximum value
    /// of 128.
    /// </summary>
    public int? MaximumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "maximum_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("maximum_digits", value);
        }
    }

    /// <summary>
    /// The maximum number of times the file should be played if there is no input
    /// from the user on the call.
    /// </summary>
    public int? MaximumTries {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "maximum_tries"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("maximum_tries", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played back at the beginning of each prompt.
    /// The media_name must point to a file previously uploaded to api.telnyx.com/v2/media
    /// by the same user/organization. The file must either be a WAV or MP3 file.
    /// </summary>
    public string? MediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_name", value);
        }
    }

    /// <summary>
    /// The minimum number of digits to fetch. This parameter has a minimum value
    /// of 1.
    /// </summary>
    public int? MinimumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "minimum_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("minimum_digits", value);
        }
    }

    /// <summary>
    /// The digit used to terminate input if fewer than `maximum_digits` digits have
    /// been gathered. Set to an empty string to disable the terminating digit entirely,
    /// so that a digit such as `#` can be collected as input per `valid_digits`.
    /// </summary>
    public string? TerminatingDigit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "terminating_digit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("terminating_digit", value);
        }
    }

    /// <summary>
    /// The number of milliseconds to wait for a DTMF response after file playback
    /// ends before a replaying the sound file.
    /// </summary>
    public int? TimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout_millis", value);
        }
    }

    /// <summary>
    /// A list of all digits accepted as valid.
    /// </summary>
    public string? ValidDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "valid_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("valid_digits", value);
        }
    }

    public ActionGatherUsingAudioParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherUsingAudioParams (
        ActionGatherUsingAudioParams actionGatherUsingAudioParams
    ) : base(actionGatherUsingAudioParams)
    {
        this.CallControlID = actionGatherUsingAudioParams.CallControlID;

        this._rawBodyData = new(actionGatherUsingAudioParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionGatherUsingAudioParams (
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
    ActionGatherUsingAudioParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionGatherUsingAudioParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionGatherUsingAudioParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/gather_using_audio",
            this.CallControlID)
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