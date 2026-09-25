using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir;

/// <summary>
/// Edit a DIR. DIRs in `draft`, `rejected`, `unsuccessful`, or `suspended` can be
/// edited freely: PATCH is a pure edit, `status` is never changed, and you re-vet
/// by calling `POST /v2/dir/{dir_id}/submit` explicitly. A `verified` DIR can also
/// be edited in place: a PATCH that changes any value returns the DIR to `draft`
/// and branded delivery stops until you re-submit and the DIR is approved again,
/// while a PATCH that changes nothing (an empty body or values identical to the
/// current ones) leaves the DIR `verified`, so idempotent retries are safe. DIRs
/// in any other status (`submitted`, `in_review`, `expired`, `infringement_claimed`,
/// `permanently_rejected`) cannot be edited.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DirID { get; init; }

    /// <summary>
    /// Contact email of the authorizer. Telnyx may send verification or infringement
    /// notices here.
    /// </summary>
    public string? AuthorizerEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "authorizer_email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("authorizer_email", value);
        }
    }

    /// <summary>
    /// Name of the person at your enterprise authorizing this DIR. Must be a real individual.
    /// </summary>
    public string? AuthorizerName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "authorizer_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("authorizer_name", value);
        }
    }

    /// <summary>
    /// 1–10 reasons your business calls customers. Validate phrasing against `POST /call_reasons/validate`.
    /// </summary>
    public IReadOnlyList<string>? CallReasons {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "call_reasons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "call_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Certification that the DIR information is accurate. Must be `true` for the
    /// DIR to be submitted for vetting.
    /// </summary>
    public bool? CertifyBrandIsAccurate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "certify_brand_is_accurate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("certify_brand_is_accurate", value);
        }
    }

    /// <summary>
    /// Certification of ownership of any logos/trademarks shown. Must be `true`
    /// for the DIR to be submitted for vetting.
    /// </summary>
    public bool? CertifyIPOwnership {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "certify_ip_ownership"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("certify_ip_ownership", value);
        }
    }

    /// <summary>
    /// Certification that this DIR is not used for SHAFT content (Sex, Hate, Alcohol,
    /// Firearms, Tobacco) where prohibited. Must be `true` for the DIR to be submitted
    /// for vetting.
    /// </summary>
    public bool? CertifyNoShaftContent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "certify_no_shaft_content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("certify_no_shaft_content", value);
        }
    }

    /// <summary>
    /// Name shown to call recipients. 1–35 characters, no emoji, not whitespace-only.
    /// </summary>
    public string? DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("display_name", value);
        }
    }

    /// <summary>
    /// Additional supporting documents to attach. Append-only: existing documents
    /// are never removed or replaced, and an empty or omitted list is a no-op. Each
    /// `document_id` may appear at most once on a DIR.
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

    /// <summary>
    /// Publicly accessible HTTPS URL (max 128 chars) to a 256x256 BMP logo (max 1 MB).
    /// </summary>
    public string? LogoUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "logo_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("logo_url", value);
        }
    }

    /// <summary>
    /// Set to true if your organization places calls on behalf of other enterprises
    /// (BPO/reseller). Updating this triggers re-vetting on next submit.
    /// </summary>
    public bool? Reselling {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "reselling"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("reselling", value);
        }
    }

    public DirUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirUpdateParams (DirUpdateParams dirUpdateParams) : base(
        dirUpdateParams
    )
    {
        this.DirID = dirUpdateParams.DirID;

        this._rawBodyData = new(dirUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DirUpdateParams (
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
    DirUpdateParams (
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
    public static DirUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(DirUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dir/{0}",
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