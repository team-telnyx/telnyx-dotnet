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

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

/// <summary>
/// Create voicemail settings for a phone number. You can also configure a custom
/// greeting by setting the `greeting` object: use `mode` `custom_greeting` together
/// with a `media_name` that points to an audio file uploaded through the Media Storage
/// API, or `mode` `default` to use the standard system greeting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoicemailCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PhoneNumberID { get; init; }

    /// <summary>
    /// Whether voicemail is enabled.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Controls the greeting a caller hears before leaving a voicemail. Set `mode`
    /// to `default` to play the standard system greeting, or to `custom_greeting`
    /// to play your own audio. When `mode` is `custom_greeting`, `media_name` is
    /// required and must reference an audio file already uploaded to your account
    /// through the Media Storage API.
    /// </summary>
    public Greeting? Greeting {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Greeting>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("greeting", value);
        }
    }

    /// <summary>
    /// The pin used for voicemail
    /// </summary>
    public string? Pin {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("pin", value);
        }
    }

    public VoicemailCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailCreateParams (
        VoicemailCreateParams voicemailCreateParams
    ) : base(voicemailCreateParams)
    {
        this.PhoneNumberID = voicemailCreateParams.PhoneNumberID;

        this._rawBodyData = new(voicemailCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public VoicemailCreateParams (
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
    VoicemailCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string phoneNumberID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PhoneNumberID = phoneNumberID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoicemailCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string phoneNumberID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            phoneNumberID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["PhoneNumberID"] = JsonSerializer.SerializeToElement(this.PhoneNumberID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VoicemailCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PhoneNumberID?.Equals(other.PhoneNumberID) ?? other.PhoneNumberID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/phone_numbers/{0}/voicemail",
            this.PhoneNumberID)
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
/// Controls the greeting a caller hears before leaving a voicemail. Set `mode` to
/// `default` to play the standard system greeting, or to `custom_greeting` to play
/// your own audio. When `mode` is `custom_greeting`, `media_name` is required and
/// must reference an audio file already uploaded to your account through the Media
/// Storage API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Greeting, GreetingFromRaw>))]
public sealed record class Greeting : JsonModel
{
    /// <summary>
    /// The name of the media file to play as the greeting. Required when `mode`
    /// is `custom_greeting`; ignored when `mode` is `default`. The value must match
    /// the `media_name` of a file you previously uploaded with the Media Storage
    /// API (`POST /v2/media`).
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init { this._rawData.Set("media_name", value); }
    }

    /// <summary>
    /// The greeting mode. `default` plays the standard system greeting. `custom_greeting`
    /// plays the audio referenced by `media_name`.
    /// </summary>
    public ApiEnum<string, Mode>? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>(
                "mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaName;
        this.Mode?.Validate();
    }

    public Greeting ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Greeting (Greeting greeting) : base(greeting)
    {  }
    #pragma warning restore CS8618

    public Greeting (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Greeting (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GreetingFromRaw.FromRawUnchecked"/>
    public static Greeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GreetingFromRaw : IFromRawJson<Greeting>
{
    /// <inheritdoc/>
    public Greeting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Greeting.FromRawUnchecked(rawData);
}

/// <summary>
/// The greeting mode. `default` plays the standard system greeting. `custom_greeting`
/// plays the audio referenced by `media_name`.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Default, CustomGreeting
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default"=>Mode.Default,
            "custom_greeting"=>Mode.CustomGreeting,
            _ =>(Mode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Mode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Mode.Default=>"default",
            Mode.CustomGreeting=>"custom_greeting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}