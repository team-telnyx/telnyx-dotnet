using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Transcriptions.Json;

/// <summary>
/// Permanently deletes a recording transcription.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class JsonDeleteRecordingTranscriptionSidJsonParams : ParamsBase
{
    public required string AccountSid { get; init; }

    public string? RecordingTranscriptionSid { get; init; }

    public JsonDeleteRecordingTranscriptionSidJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JsonDeleteRecordingTranscriptionSidJsonParams (
        JsonDeleteRecordingTranscriptionSidJsonParams jsonDeleteRecordingTranscriptionSidJsonParams
    ) : base(jsonDeleteRecordingTranscriptionSidJsonParams)
    {
        this.AccountSid = jsonDeleteRecordingTranscriptionSidJsonParams.AccountSid;
        this.RecordingTranscriptionSid = jsonDeleteRecordingTranscriptionSidJsonParams.RecordingTranscriptionSid;
    }
    #pragma warning restore CS8618

    public JsonDeleteRecordingTranscriptionSidJsonParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JsonDeleteRecordingTranscriptionSidJsonParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string accountSid,
        string recordingTranscriptionSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AccountSid = accountSid;
        this.RecordingTranscriptionSid = recordingTranscriptionSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static JsonDeleteRecordingTranscriptionSidJsonParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string accountSid,
        string recordingTranscriptionSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            accountSid,
            recordingTranscriptionSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["RecordingTranscriptionSid"] = JsonSerializer.SerializeToElement(this.RecordingTranscriptionSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(
        JsonDeleteRecordingTranscriptionSidJsonParams? other
    )
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&(this.RecordingTranscriptionSid?.Equals(other.RecordingTranscriptionSid) ?? other.RecordingTranscriptionSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Transcriptions/{1}.json",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.RecordingTranscriptionSid))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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