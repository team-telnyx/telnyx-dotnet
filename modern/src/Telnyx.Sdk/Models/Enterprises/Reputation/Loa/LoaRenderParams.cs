using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Loa;

/// <summary>
/// Render the LOA for this enterprise as a PDF. The enterprise identity, address,
/// and authorized-representative contact are taken from the enterprise record; the
/// optional `agent` block is supplied only when a third-party partner manages the
/// numbers. The response is the PDF itself (unsigned unless a `signature` is provided).
/// Sign it and upload it to the Telnyx Documents API (`POST /v2/documents`, see https://developers.telnyx.com/api/documents)
/// to obtain the `loa_document_id` required by `POST .../reputation`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LoaRenderParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnterpriseID { get; init; }

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
    /// Optional signature embedded in the rendered PDF. When omitted the PDF is
    /// returned unsigned for the customer to sign and upload.
    /// </summary>
    public Signature? Signature {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Signature>(
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

    public LoaRenderParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaRenderParams (LoaRenderParams loaRenderParams) : base(
        loaRenderParams
    )
    {
        this.EnterpriseID = loaRenderParams.EnterpriseID;

        this._rawBodyData = new(loaRenderParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public LoaRenderParams (
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
    LoaRenderParams (
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
    public static LoaRenderParams FromRawUnchecked(
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

    public virtual bool Equals(LoaRenderParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/reputation/loa",
            this.EnterpriseID)
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
/// Optional signature embedded in the rendered PDF. When omitted the PDF is returned
/// unsigned for the customer to sign and upload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Signature, SignatureFromRaw>))]
public sealed record class Signature : JsonModel
{
    /// <summary>
    /// Base64-encoded signature image.
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
    public Signature (Signature signature) : base(signature)
    {  }
    #pragma warning restore CS8618

    public Signature (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Signature (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SignatureFromRaw.FromRawUnchecked"/>
    public static Signature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Signature (string imageBase64) : this()
    { this.ImageBase64 = imageBase64; }
}

class SignatureFromRaw : IFromRawJson<Signature>
{
    /// <inheritdoc/>
    public Signature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Signature.FromRawUnchecked(rawData);
}