using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

/// <summary>
/// Update a campaign's properties by `campaignId`. **Please note:** only sample
/// messages are editable.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CampaignUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CampaignID { get; init; }

    /// <summary>
    /// Help message of the campaign.
    /// </summary>
    public bool? AutoRenewal {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "autoRenewal"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("autoRenewal", value);
        }
    }

    /// <summary>
    /// Help message of the campaign.
    /// </summary>
    public string? HelpMessage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "helpMessage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("helpMessage", value);
        }
    }

    /// <summary>
    /// Message flow description.
    /// </summary>
    public string? MessageFlow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "messageFlow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("messageFlow", value);
        }
    }

    /// <summary>
    /// Alphanumeric identifier of the reseller that you want to associate with this campaign.
    /// </summary>
    public string? ResellerID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "resellerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("resellerId", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 1 or more message samples.
    /// </summary>
    public string? Sample1 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sample1"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sample1", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 2 or more message samples.
    /// </summary>
    public string? Sample2 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sample2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sample2", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 3 or more message samples.
    /// </summary>
    public string? Sample3 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sample3"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sample3", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 4 or more message samples.
    /// </summary>
    public string? Sample4 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sample4"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sample4", value);
        }
    }

    /// <summary>
    /// Message sample. Some campaign tiers require 5 or more message samples.
    /// </summary>
    public string? Sample5 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sample5"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sample5", value);
        }
    }

    /// <summary>
    /// Webhook failover to which campaign status updates are sent.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhookFailoverURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhookFailoverURL", value);
        }
    }

    /// <summary>
    /// Webhook to which campaign status updates are sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhookURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhookURL", value);
        }
    }

    public CampaignUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateParams (
        CampaignUpdateParams campaignUpdateParams
    ) : base(campaignUpdateParams)
    {
        this.CampaignID = campaignUpdateParams.CampaignID;

        this._rawBodyData = new(campaignUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CampaignUpdateParams (
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
    CampaignUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string campaignID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CampaignID = campaignID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CampaignUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string campaignID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            campaignID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CampaignID"] = JsonSerializer.SerializeToElement(this.CampaignID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CampaignUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CampaignID?.Equals(other.CampaignID) ?? other.CampaignID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/campaign/{0}",
            EncodePathSegment(this.CampaignID))
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