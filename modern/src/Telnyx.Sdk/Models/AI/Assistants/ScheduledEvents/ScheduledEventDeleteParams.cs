using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

/// <summary>
/// If the event is pending, this will cancel the event. Otherwise, this will simply
/// remove the record of the event.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ScheduledEventDeleteParams : ParamsBase
{
    public required string AssistantID { get; init; }

    public string? EventID { get; init; }

    public ScheduledEventDeleteParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledEventDeleteParams (
        ScheduledEventDeleteParams scheduledEventDeleteParams
    ) : base(scheduledEventDeleteParams)
    {
        this.AssistantID = scheduledEventDeleteParams.AssistantID;
        this.EventID = scheduledEventDeleteParams.EventID;
    }
    #pragma warning restore CS8618

    public ScheduledEventDeleteParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledEventDeleteParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string assistantID,
        string eventID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AssistantID = assistantID;
        this.EventID = eventID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ScheduledEventDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string assistantID,
        string eventID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            assistantID,
            eventID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AssistantID"] = JsonSerializer.SerializeToElement(this.AssistantID),
        ["EventID"] = JsonSerializer.SerializeToElement(this.EventID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ScheduledEventDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AssistantID.Equals(other.AssistantID)&&(this.EventID?.Equals(other.EventID) ?? other.EventID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/assistants/{0}/scheduled_events/{1}",
            EncodePathSegment(this.AssistantID),
            EncodePathSegment(this.EventID))
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