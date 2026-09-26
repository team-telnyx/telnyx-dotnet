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

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences;

/// <summary>
/// Updates the specified conference resource, for example to modify its status, and
/// returns the updated conference.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? ConferenceSid { get; init; }

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
    /// The URL we should call to announce something into the conference. The URL
    /// may return an MP3 file, a WAV file, or a TwiML document that contains `&lt;Play&gt;`,
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
    /// The new status of the resource. Specifying `completed` will end the conference
    /// and hang up all participants.
    /// </summary>
    public string? Status {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Status", value);
        }
    }

    public ConferenceUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceUpdateParams (
        ConferenceUpdateParams conferenceUpdateParams
    ) : base(conferenceUpdateParams)
    {
        this.AccountSid = conferenceUpdateParams.AccountSid;
        this.ConferenceSid = conferenceUpdateParams.ConferenceSid;

        this._rawBodyData = new(conferenceUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ConferenceUpdateParams (
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
    ConferenceUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountSid = accountSid;
        this.ConferenceSid = conferenceSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConferenceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountSid,
            conferenceSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["ConferenceSid"] = JsonSerializer.SerializeToElement(this.ConferenceSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ConferenceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&(this.ConferenceSid?.Equals(other.ConferenceSid) ?? other.ConferenceSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Conferences/{1}",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.ConferenceSid))
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