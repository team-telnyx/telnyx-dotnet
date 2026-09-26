using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

/// <summary>
/// Submit a batch of phone numbers belonging to this enterprise for reputation remediation.
/// The request is accepted asynchronously: this endpoint returns `202` with the
/// persisted request id, then the request transitions through processing states
/// until completion. Use the GET endpoints to poll status and per-number results.
///
/// <para>Each phone number must be in E.164 format and belong to this enterprise.
/// A number that already has an in-flight remediation request is rejected.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RemediationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnterpriseID { get; init; }

    /// <summary>
    /// How the numbers are used (free text).
    /// </summary>
    public required string CallPurpose {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "call_purpose"
            );
        }
        init { this._rawBodyData.Set("call_purpose", value); }
    }

    /// <summary>
    /// Phone numbers in E.164 format. Each must belong to this enterprise. Maximum
    /// 2,000 per request.
    /// </summary>
    public required IReadOnlyList<string> PhoneNumbers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "phone_numbers"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "phone_numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional contact email for this remediation request.
    /// </summary>
    public string? ContactEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "contact_email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("contact_email", value);
        }
    }

    /// <summary>
    /// Optional https:// URL for status notifications.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public RemediationCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemediationCreateParams (
        RemediationCreateParams remediationCreateParams
    ) : base(remediationCreateParams)
    {
        this.EnterpriseID = remediationCreateParams.EnterpriseID;

        this._rawBodyData = new(remediationCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public RemediationCreateParams (
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
    RemediationCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string enterpriseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EnterpriseID = enterpriseID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RemediationCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string enterpriseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            enterpriseID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EnterpriseID"] = JsonSerializer.SerializeToElement(this.EnterpriseID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(RemediationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EnterpriseID?.Equals(other.EnterpriseID) ?? other.EnterpriseID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/reputation/remediation",
            EncodePathSegment(this.EnterpriseID))
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