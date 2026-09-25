using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir;

namespace Telnyx.Sdk.Models.InfringementClaims;

/// <summary>
/// Submit a written response and supporting documents disputing the claim. The first
/// call moves the claim from `pending` to `contested`; subsequent calls append supplementary
/// evidence without changing status. The `documents[]` you attach are aggregated
/// across rounds in the claim's `contest_documents` field.
///
/// <para>Only `pending` and `contested` claims accept new evidence. A `resolved`
/// claim returns `400`.</para>
///
/// <para>Failure modes: - `400` - the claim is `resolved` (terminal); cannot be
/// contested further. - `404` - the claim does not exist or is not against a DIR
/// you own. - `422` - `contest_notes` is too short (&lt; 10 chars), too long (&gt;
/// 2000 chars), `documents` is &gt; 20 entries, or a `document_id` is duplicated
/// within the same submission.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InfringementClaimContestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ClaimID { get; init; }

    /// <summary>
    /// Customer's response to the claim. 10–2000 characters.
    /// </summary>
    public required string ContestNotes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "contest_notes"
            );
        }
        init { this._rawBodyData.Set("contest_notes", value); }
    }

    /// <summary>
    /// Up to 20 supporting documents per submission. `document_id` must be unique
    /// within this submission. Documents are aggregated into the claim's `contest_documents`
    /// across all submissions.
    /// </summary>
    public IReadOnlyList<Document>? Documents {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Document>>(
                "documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Document>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public InfringementClaimContestParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfringementClaimContestParams (
        InfringementClaimContestParams infringementClaimContestParams
    ) : base(infringementClaimContestParams)
    {
        this.ClaimID = infringementClaimContestParams.ClaimID;

        this._rawBodyData = new(infringementClaimContestParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public InfringementClaimContestParams (
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
    InfringementClaimContestParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string claimID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ClaimID = claimID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InfringementClaimContestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string claimID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            claimID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ClaimID"] = JsonSerializer.SerializeToElement(this.ClaimID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(InfringementClaimContestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ClaimID?.Equals(other.ClaimID) ?? other.ClaimID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/infringement_claims/{0}/contest",
            this.ClaimID)
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