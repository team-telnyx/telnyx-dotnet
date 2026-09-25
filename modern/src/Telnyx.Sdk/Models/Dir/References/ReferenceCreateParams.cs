using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.References;

/// <summary>
/// Submit the two business references and one financial reference for a DIR.
///
/// <para>The DIR's authorizer email must be verified first (see the email-verification
/// endpoint). Until it is, this returns `409` and no references are stored.</para>
///
/// <para>The request body carries exactly two business references plus one financial
/// reference. The first submission stores them and returns `201`. Resubmitting returns
/// `200`: identical values are simply confirmed and nothing is written, while changed
/// values replace those references.</para>
///
/// <para>Replacing a reference is allowed only while the DIR itself is still editable,
/// the same window in which a single reference may be updated; once the DIR has
/// been submitted for vetting this returns `400`. A replaced reference's pending
/// verification call is cancelled and its dial-in code stops working, and the replacement
/// contact is emailed fresh scheduling details. References whose details did not
/// change keep their existing call, code, and the notice already sent to them.</para>
///
/// <para>The response always echoes the stored references in the same shape as the GET.</para>
///
/// <para>Who qualifies: the two business references confirm the company's reputation
/// and operations. Each should be a senior contact at an organization the business
/// works with, such as a vendor, partner, or client: a C-suite executive (CEO, CFO,
/// CTO, COO), an owner or founder as reflected in the company's corporate records,
/// or a senior manager, director, or executive. The financial reference confirms
/// the company pays its bills and should be a licensed certified public accountant
/// (CPA) the company uses, a contact at a bank or financial institution that has
/// a relationship with the company, or a reasonable alternative banking or financial reference.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReferenceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DirID { get; init; }

    /// <summary>
    /// Exactly two business references. Array order determines each one's slot:
    /// the first entry becomes slot 1 and the second becomes slot 2. Those slots
    /// are what you pass when updating a single reference later. Each should be a
    /// senior contact who can speak to your company's reputation and operations:
    /// a C-suite executive (CEO, CFO, CTO, COO), an owner or founder as reflected
    /// in your corporate records, or a senior manager, director, or executive at
    /// an organization you work with, such as a vendor, partner, or client.
    /// </summary>
    public required IReadOnlyList<ReferenceInput> BusinessReferences {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ReferenceInput>>(
                "business_references"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<ReferenceInput>>(
                "business_references",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One reference supplied at submit. The reference type is implied by the field
    /// that carries it (business_references vs financial_reference).
    /// </summary>
    public required ReferenceInput FinancialReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ReferenceInput>(
                "financial_reference"
            );
        }
        init { this._rawBodyData.Set("financial_reference", value); }
    }

    public ReferenceCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferenceCreateParams (
        ReferenceCreateParams referenceCreateParams
    ) : base(referenceCreateParams)
    {
        this.DirID = referenceCreateParams.DirID;

        this._rawBodyData = new(referenceCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ReferenceCreateParams (
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
    ReferenceCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string dirID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DirID = dirID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReferenceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string dirID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            dirID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["DirID"] = JsonSerializer.SerializeToElement(this.DirID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ReferenceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DirID?.Equals(other.DirID) ?? other.DirID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dir/{0}/references",
            this.DirID)
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