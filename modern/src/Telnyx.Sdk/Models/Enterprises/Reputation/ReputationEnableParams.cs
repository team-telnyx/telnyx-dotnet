using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation;

/// <summary>
/// Activate Phone Number Reputation for the given enterprise. Requires an uploaded
/// Letter of Authorization document (the `loa_document_id` references the Telnyx
/// Documents API) and a refresh-frequency selection. After activation, individual
/// phone numbers can be registered via `POST .../reputation/numbers`.
///
/// <para>**Prerequisite**: the calling user must have agreed to the Phone Number
/// Reputation Terms of Service (`POST /terms_of_service/number_reputation/agree`).</para>
///
/// <para>Failure modes: - `403` - Phone Number Reputation Terms of Service not accepted.
/// - `404` - enterprise does not exist or does not belong to your account. - `400`
/// - reputation already enabled for this enterprise. - `422` - `loa_document_id`
/// missing or `check_frequency` invalid.</para>
///
/// <para>**Pricing:** This is a billable action. See https://telnyx.com/pricing/numbers
/// for current pricing.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReputationEnableParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnterpriseID { get; init; }

    /// <summary>
    /// Id of the signed Letter of Authorization document, returned by the Telnyx
    /// Documents API after upload (upload via `POST /v2/documents`; see https://developers.telnyx.com/api/documents).
    /// </summary>
    public required string LoaDocumentID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "loa_document_id"
            );
        }
        init { this._rawBodyData.Set("loa_document_id", value); }
    }

    /// <summary>
    /// How often Telnyx refreshes the stored reputation data for this enterprise's
    /// registered numbers.
    /// </summary>
    public ApiEnum<string, ReputationCheckFrequency>? CheckFrequency {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ReputationCheckFrequency>>(
                "check_frequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("check_frequency", value);
        }
    }

    public ReputationEnableParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationEnableParams (
        ReputationEnableParams reputationEnableParams
    ) : base(reputationEnableParams)
    {
        this.EnterpriseID = reputationEnableParams.EnterpriseID;

        this._rawBodyData = new(reputationEnableParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ReputationEnableParams (
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
    ReputationEnableParams (
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
    public static ReputationEnableParams FromRawUnchecked(
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

    public virtual bool Equals(ReputationEnableParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/reputation",
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