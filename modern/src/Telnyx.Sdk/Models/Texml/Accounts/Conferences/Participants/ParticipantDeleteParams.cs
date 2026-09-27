using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

/// <summary>
/// Removes the specified participant from the conference, ending their leg of the call.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParticipantDeleteParams : ParamsBase
{
    public required string AccountSid { get; init; }

    public required string ConferenceSid { get; init; }

    public string? CallSidOrParticipantLabel { get; init; }

    public ParticipantDeleteParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParticipantDeleteParams (
        ParticipantDeleteParams participantDeleteParams
    ) : base(participantDeleteParams)
    {
        this.AccountSid = participantDeleteParams.AccountSid;
        this.ConferenceSid = participantDeleteParams.ConferenceSid;
        this.CallSidOrParticipantLabel = participantDeleteParams.CallSidOrParticipantLabel;
    }
    #pragma warning restore CS8618

    public ParticipantDeleteParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ParticipantDeleteParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string accountSid,
        string conferenceSid,
        string callSidOrParticipantLabel
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AccountSid = accountSid;
        this.ConferenceSid = conferenceSid;
        this.CallSidOrParticipantLabel = callSidOrParticipantLabel;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ParticipantDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string accountSid,
        string conferenceSid,
        string callSidOrParticipantLabel
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
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
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ParticipantDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&this.ConferenceSid.Equals(other.ConferenceSid)&&(this.CallSidOrParticipantLabel?.Equals(other.CallSidOrParticipantLabel) ?? other.CallSidOrParticipantLabel == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Conferences/{1}/Participants/{2}",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.ConferenceSid),
            EncodePathSegment(this.CallSidOrParticipantLabel))
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