using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Play audio to all or some participants on a conference call.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionPlayParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The URL of a file to be played back in the conference. media_name and audio_url
    /// cannot be used together in one request.
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
    /// List of call control ids identifying participants the audio file should be
    /// played to. If not given, the audio file will be played to the entire conference.
    /// </summary>
    public IReadOnlyList<string>? CallControlIds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of times the audio file should be played. If supplied, the value
    /// must be an integer between 1 and 100, or the special string `infinity` for
    /// an endless loop.
    /// </summary>
    public Loopcount? Loop {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Loopcount>(
                "loop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("loop", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played back in the conference. The media_name
    /// must point to a file previously uploaded to api.telnyx.com/v2/media by the
    /// same user/organization. The file must either be a WAV or MP3 file.
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
    /// Region where the conference data is located. Defaults to the region defined
    /// in user's data locality settings (Europe or US).
    /// </summary>
    public ApiEnum<string, ConferenceRegion>? Region {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceRegion>>(
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

    public ActionPlayParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionPlayParams (ActionPlayParams actionPlayParams) : base(
        actionPlayParams
    )
    {
        this.ID = actionPlayParams.ID;

        this._rawBodyData = new(actionPlayParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionPlayParams (
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
    ActionPlayParams (
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
    public static ActionPlayParams FromRawUnchecked(
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

    public virtual bool Equals(ActionPlayParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/actions/play",
            EncodePathSegment(this.ID))
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