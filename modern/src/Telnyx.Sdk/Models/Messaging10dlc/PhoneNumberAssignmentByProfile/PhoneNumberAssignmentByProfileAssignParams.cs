using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

/// <summary>
/// This endpoint allows you to link all phone numbers associated with a Messaging
/// Profile to a campaign. **Please note:** if you want to assign phone numbers to
/// a campaign that you did not create with Telnyx 10DLC services, this endpoint
/// allows that provided that you've shared the campaign with Telnyx. In this case,
/// only provide the parameter, `tcrCampaignId`, and not `campaignId`. In all other
/// cases (where the campaign you're assigning was created with Telnyx 10DLC services),
/// only provide `campaignId`, not `tcrCampaignId`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberAssignmentByProfileAssignParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The ID of the messaging profile that you want to link to the specified campaign.
    /// </summary>
    public required string MessagingProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "messagingProfileId"
            );
        }
        init { this._rawBodyData.Set("messagingProfileId", value); }
    }

    /// <summary>
    /// The ID of the campaign you want to link to the specified messaging profile.
    /// If you supply this ID in the request, do not also include a tcrCampaignId.
    /// </summary>
    public string? CampaignID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "campaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("campaignId", value);
        }
    }

    /// <summary>
    /// The TCR ID of the shared campaign you want to link to the specified messaging
    /// profile (for campaigns not created using Telnyx 10DLC services only). If
    /// you supply this ID in the request, do not also include a campaignId.
    /// </summary>
    public string? TcrCampaignID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "tcrCampaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tcrCampaignId", value);
        }
    }

    public PhoneNumberAssignmentByProfileAssignParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileAssignParams (
        PhoneNumberAssignmentByProfileAssignParams phoneNumberAssignmentByProfileAssignParams
    ) : base(phoneNumberAssignmentByProfileAssignParams)
    {
        this._rawBodyData = new(phoneNumberAssignmentByProfileAssignParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileAssignParams (
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
    PhoneNumberAssignmentByProfileAssignParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileAssignParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(
        PhoneNumberAssignmentByProfileAssignParams? other
    )
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/10dlc/phoneNumberAssignmentByProfile"
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