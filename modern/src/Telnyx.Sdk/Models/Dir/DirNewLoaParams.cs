using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises.Reputation.Loa;

namespace Telnyx.Sdk.Models.Dir;

/// <summary>
/// Generate a pre-filled Letter of Authorization (LOA) PDF for a DIR. Enterprise
/// identity (legal name, DBA, address, contact, website, tax id) and the DIR display
/// name are read server-side; the caller supplies the telephone numbers to authorize,
/// an optional Authorized Agent block, and an optional drawn signature.
///
/// <para>When `signature` is omitted the PDF is returned unsigned so the customer
/// can sign it externally and upload it via the Documents API. When `signature` is
/// present the PDF embeds the supplied image, printed name, and signed-at date.</para>
///
/// <para>Returns `application/pdf`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirNewLoaParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DirID { get; init; }

    /// <summary>
    /// Telephone numbers to authorize on the DIR, in `+E164` format (`+` followed
    /// by 10-15 digits). Max 15 per request.
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
    /// Third-party reseller / partner managing the enterprise's phone numbers. Omit
    /// when the enterprise works directly with Telnyx.
    /// </summary>
    public AgentInput? Agent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AgentInput>(
                "agent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("agent", value);
        }
    }

    /// <summary>
    /// Optional. When provided the rendered PDF embeds the signature image, printed
    /// name, and signed-at date. When absent the PDF is returned unsigned so the
    /// customer can sign externally and upload it via the Documents API.
    /// </summary>
    public global::Telnyx.Sdk.Models.Dir.Signature? Signature {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<global::Telnyx.Sdk.Models.Dir.Signature>(
                "signature"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("signature", value);
        }
    }

    public DirNewLoaParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirNewLoaParams (DirNewLoaParams dirNewLoaParams) : base(
        dirNewLoaParams
    )
    {
        this.DirID = dirNewLoaParams.DirID;

        this._rawBodyData = new(dirNewLoaParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DirNewLoaParams (
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
    DirNewLoaParams (
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
    public static DirNewLoaParams FromRawUnchecked(
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

    public virtual bool Equals(DirNewLoaParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dir/{0}/loa",
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
        request.Headers.Add("Accept", "application/pdf");
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

/// <summary>
/// Optional. When provided the rendered PDF embeds the signature image, printed name,
/// and signed-at date. When absent the PDF is returned unsigned so the customer can
/// sign externally and upload it via the Documents API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<global::Telnyx.Sdk.Models.Dir.Signature, global::Telnyx.Sdk.Models.Dir.SignatureFromRaw>))]
public sealed record class Signature : JsonModel
{
    /// <summary>
    /// PNG image, base64-encoded.
    /// </summary>
    public required string ImageBase64 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "image_base64"
            );
        }
        init { this._rawData.Set("image_base64", value); }
    }

    /// <summary>
    /// Optional. When absent the rendered PDF falls back to the enterprise contact's
    /// legal name.
    /// </summary>
    public string? SignerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "signer_name"
            );
        }
        init { this._rawData.Set("signer_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageBase64;
        _ = this.SignerName;
    }

    public Signature ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Signature (global::Telnyx.Sdk.Models.Dir.Signature signature) : base(
        signature
    )
    {  }
    #pragma warning restore CS8618

    public Signature (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Signature (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="global::Telnyx.Sdk.Models.Dir.SignatureFromRaw.FromRawUnchecked"/>
    public static global::Telnyx.Sdk.Models.Dir.Signature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Signature (string imageBase64) : this()
    { this.ImageBase64 = imageBase64; }
}

class SignatureFromRaw : IFromRawJson<global::Telnyx.Sdk.Models.Dir.Signature>
{
    /// <inheritdoc/>
    public global::Telnyx.Sdk.Models.Dir.Signature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>global::Telnyx.Sdk.Models.Dir.Signature.FromRawUnchecked(rawData);
}