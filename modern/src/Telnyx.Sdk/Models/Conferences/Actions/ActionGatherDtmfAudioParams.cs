using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Play an audio file to a specific conference participant and gather DTMF input.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionGatherDtmfAudioParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Unique identifier and token for controlling the call leg that will receive
    /// the gather prompt.
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
    /// The URL of the audio file to play as the gather prompt. Must be WAV or MP3 format.
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
    /// Use this field to add state to every subsequent webhook. Must be a valid
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
    /// Identifier for this gather command. Will be included in the gather ended
    /// webhook. Maximum 100 characters.
    /// </summary>
    public string? GatherID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "gather_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("gather_id", value);
        }
    }

    /// <summary>
    /// Duration in milliseconds to wait for the first digit before timing out.
    /// </summary>
    public long? InitialTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "initial_timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("initial_timeout_millis", value);
        }
    }

    /// <summary>
    /// Duration in milliseconds to wait between digits.
    /// </summary>
    public long? InterDigitTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
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
    /// URL of audio file to play when invalid input is received.
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
    /// Name of media file to play when invalid input is received.
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
    /// Maximum number of digits to gather.
    /// </summary>
    public long? MaximumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
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
    /// Maximum number of times to play the prompt if no input is received.
    /// </summary>
    public long? MaximumTries {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
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
    /// The name of the media file uploaded to the Media Storage API to play as the
    /// gather prompt.
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
    /// Minimum number of digits to gather.
    /// </summary>
    public long? MinimumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
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
    /// Whether to stop the audio playback when a DTMF digit is received.
    /// </summary>
    public bool? StopPlaybackOnDtmf {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "stop_playback_on_dtmf"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stop_playback_on_dtmf", value);
        }
    }

    /// <summary>
    /// Digit that terminates gathering. Set to an empty string to disable the terminating
    /// digit entirely, so that a digit such as `#` can be collected as input per `valid_digits`.
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
    /// Duration in milliseconds to wait for input before timing out.
    /// </summary>
    public long? TimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
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
    /// Digits that are valid for gathering. All other digits will be ignored.
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

    public ActionGatherDtmfAudioParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherDtmfAudioParams (
        ActionGatherDtmfAudioParams actionGatherDtmfAudioParams
    ) : base(actionGatherDtmfAudioParams)
    {
        this.ID = actionGatherDtmfAudioParams.ID;

        this._rawBodyData = new(actionGatherDtmfAudioParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionGatherDtmfAudioParams (
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
    ActionGatherDtmfAudioParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionGatherDtmfAudioParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionGatherDtmfAudioParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/actions/gather_using_audio",
            this.ID)
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