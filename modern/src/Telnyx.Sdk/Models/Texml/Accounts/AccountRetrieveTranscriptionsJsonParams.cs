using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts;

/// <summary>
/// Returns multiple recording transcription resources for an account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountRetrieveTranscriptionsJsonParams : ParamsBase
{
    public string? AccountSid { get; init; }

    /// <summary>
    /// The number of records to be displayed on a page
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "PageSize"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageSize", value);
        }
    }

    /// <summary>
    /// Used to request the next page of results.
    /// </summary>
    public string? PageToken {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "PageToken"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageToken", value);
        }
    }

    public AccountRetrieveTranscriptionsJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRetrieveTranscriptionsJsonParams (
        AccountRetrieveTranscriptionsJsonParams accountRetrieveTranscriptionsJsonParams
    ) : base(accountRetrieveTranscriptionsJsonParams)
    { this.AccountSid = accountRetrieveTranscriptionsJsonParams.AccountSid; }
    #pragma warning restore CS8618

    public AccountRetrieveTranscriptionsJsonParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRetrieveTranscriptionsJsonParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AccountSid = accountSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccountRetrieveTranscriptionsJsonParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            accountSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AccountRetrieveTranscriptionsJsonParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountSid?.Equals(other.AccountSid) ?? other.AccountSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Transcriptions.json",
            EncodePathSegment(this.AccountSid))
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