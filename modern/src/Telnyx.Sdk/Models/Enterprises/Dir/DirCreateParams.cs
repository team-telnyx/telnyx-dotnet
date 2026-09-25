using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Dir = Telnyx.Sdk.Models.Dir;

namespace Telnyx.Sdk.Models.Enterprises.Dir;

/// <summary>
/// Create a new DIR under the given enterprise. The DIR starts in `draft` status;
/// it must be submitted (`POST .../submit`) and approved by Telnyx before any phone
/// number can be attached.
///
/// <para>**Field rules** - `display_name`: 1–35 characters, no emoji or whitespace-only
/// strings; this is the name shown to recipients. - `call_reasons`: 1–10 strings,
/// each ≤64 characters; describe why your business calls customers (e.g. 'Appointment
/// reminders', 'Billing inquiries'). Validate the wording against `POST /call_reasons/validate`.
/// - `logo_url`: HTTPS URL (max 128 chars) to a 256×256 BMP (max 1 MB). The image
/// is downloaded and hashed at submission time. - `documents`: up to 20 entries;
/// each `document_id` must be obtained by uploading the file via the Telnyx Documents
/// API first. Within one DIR a `document_id` may only appear once. - `certify_brand_is_accurate`,
/// `certify_no_shaft_content`, `certify_ip_ownership` MUST all be `true`.</para>
///
/// <para>**Failure modes** - `422` - validation error; `errors[].source.pointer`
/// names the offending field. - `403` - Branded Calling not activated on this enterprise
/// (see `POST /enterprises/{id}/branded_calling`). - `404` - enterprise does not
/// exist or does not belong to your account.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnterpriseID { get; init; }

    /// <summary>
    /// Contact email of the authorizer. Telnyx may send verification or infringement-notice
    /// email here; use a monitored mailbox.
    /// </summary>
    public required string AuthorizerEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "authorizer_email"
            );
        }
        init { this._rawBodyData.Set("authorizer_email", value); }
    }

    /// <summary>
    /// Name of the person at your enterprise who is authorizing this DIR registration.
    /// Must be a real individual (used for audit and trademark-claim contests).
    /// </summary>
    public required string AuthorizerName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "authorizer_name"
            );
        }
        init { this._rawBodyData.Set("authorizer_name", value); }
    }

    /// <summary>
    /// 1–10 reasons your business calls customers. Validate phrasing against `POST /call_reasons/validate`.
    /// </summary>
    public required IReadOnlyList<string> CallReasons {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "call_reasons"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "call_reasons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Must be `true`.
    /// </summary>
    public required ApiEnum<bool, CertifyBrandIsAccurate> CertifyBrandIsAccurate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<bool, CertifyBrandIsAccurate>>(
                "certify_brand_is_accurate"
            );
        }
        init { this._rawBodyData.Set("certify_brand_is_accurate", value); }
    }

    /// <summary>
    /// Must be `true`. Confirms ownership of any logos/trademarks shown.
    /// </summary>
    public required ApiEnum<bool, CertifyIPOwnership> CertifyIPOwnership {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<bool, CertifyIPOwnership>>(
                "certify_ip_ownership"
            );
        }
        init { this._rawBodyData.Set("certify_ip_ownership", value); }
    }

    /// <summary>
    /// Must be `true`. Confirms this DIR is not used for SHAFT content (Sex, Hate,
    /// Alcohol, Firearms, Tobacco) where prohibited.
    /// </summary>
    public required ApiEnum<bool, CertifyNoShaftContent> CertifyNoShaftContent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<bool, CertifyNoShaftContent>>(
                "certify_no_shaft_content"
            );
        }
        init { this._rawBodyData.Set("certify_no_shaft_content", value); }
    }

    /// <summary>
    /// Name shown to call recipients. No emoji; not whitespace-only.
    /// </summary>
    public required string DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "display_name"
            );
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// Supporting documents. Each `document_id` may appear at most once on a DIR.
    /// </summary>
    public IReadOnlyList<Dir::Document>? Documents {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Dir::Document>>(
                "documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Dir::Document>?>(
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
    /// Set to true if your organization places calls on behalf of other enterprises (BPO/reseller).
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

    public DirCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirCreateParams (DirCreateParams dirCreateParams) : base(
        dirCreateParams
    )
    {
        this.EnterpriseID = dirCreateParams.EnterpriseID;

        this._rawBodyData = new(dirCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DirCreateParams (
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
    DirCreateParams (
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
    public static DirCreateParams FromRawUnchecked(
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

    public virtual bool Equals(DirCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EnterpriseID?.Equals(other.EnterpriseID) ?? other.EnterpriseID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/dir",
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
/// Must be `true`.
/// </summary>
[JsonConverter(typeof(CertifyBrandIsAccurateConverter))]
public enum CertifyBrandIsAccurate
{
    True
}

sealed class CertifyBrandIsAccurateConverter : JsonConverter<CertifyBrandIsAccurate>
{
    public override CertifyBrandIsAccurate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>CertifyBrandIsAccurate.True, _ =>(CertifyBrandIsAccurate)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CertifyBrandIsAccurate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CertifyBrandIsAccurate.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Must be `true`. Confirms ownership of any logos/trademarks shown.
/// </summary>
[JsonConverter(typeof(CertifyIPOwnershipConverter))]
public enum CertifyIPOwnership
{
    True
}

sealed class CertifyIPOwnershipConverter : JsonConverter<CertifyIPOwnership>
{
    public override CertifyIPOwnership Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>CertifyIPOwnership.True, _ =>(CertifyIPOwnership)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CertifyIPOwnership value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CertifyIPOwnership.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Must be `true`. Confirms this DIR is not used for SHAFT content (Sex, Hate, Alcohol,
/// Firearms, Tobacco) where prohibited.
/// </summary>
[JsonConverter(typeof(CertifyNoShaftContentConverter))]
public enum CertifyNoShaftContent
{
    True
}

sealed class CertifyNoShaftContentConverter : JsonConverter<CertifyNoShaftContent>
{
    public override CertifyNoShaftContent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>CertifyNoShaftContent.True, _ =>(CertifyNoShaftContent)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CertifyNoShaftContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CertifyNoShaftContent.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}