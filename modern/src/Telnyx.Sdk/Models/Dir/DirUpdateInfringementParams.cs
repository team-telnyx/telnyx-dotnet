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

namespace Telnyx.Sdk.Models.Dir;

/// <summary>
/// Push a fix for a DIR that is `suspended` with an open infringement claim back
/// into vetting. `POST /dir/{dir_id}/submit` is blocked while a claim is open, so
/// this is the customer-callable path to update the DIR's content and re-certify
/// before Telnyx adjudicates the claim. All four certification booleans must be
/// `true`. Optional content fields (`display_name`, `logo_url`, `call_reasons`, `documents`)
/// update the DIR; documents are append-only.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirUpdateInfringementParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DirID { get; init; }

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
    /// Must be `true`.
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
    /// Must be `true`.
    /// </summary>
    public required ApiEnum<bool, CertifyNoInfringement> CertifyNoInfringement {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<bool, CertifyNoInfringement>>(
                "certify_no_infringement"
            );
        }
        init { this._rawBodyData.Set("certify_no_infringement", value); }
    }

    /// <summary>
    /// Must be `true`.
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
    /// Explanation of how the infringement concern was addressed.
    /// </summary>
    public required string InfringementResolutionNotes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "infringement_resolution_notes"
            );
        }
        init { this._rawBodyData.Set("infringement_resolution_notes", value); }
    }

    public IReadOnlyList<string>? CallReasons {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "call_reasons"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "call_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "display_name"
            );
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// Append-only supporting documents to attach while resolving the claim (e.g.
    /// authorization or licensing proof).
    /// </summary>
    public IReadOnlyList<Document>? Documents {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Document>>(
                "documents"
            );
        }
        init {
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
        init { this._rawBodyData.Set("logo_url", value); }
    }

    public DirUpdateInfringementParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirUpdateInfringementParams (
        DirUpdateInfringementParams dirUpdateInfringementParams
    ) : base(dirUpdateInfringementParams)
    {
        this.DirID = dirUpdateInfringementParams.DirID;

        this._rawBodyData = new(dirUpdateInfringementParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DirUpdateInfringementParams (
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
    DirUpdateInfringementParams (
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
    public static DirUpdateInfringementParams FromRawUnchecked(
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

    public virtual bool Equals(DirUpdateInfringementParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DirID?.Equals(other.DirID) ?? other.DirID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dir/{0}/infringement_update",
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
/// Must be `true`.
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
/// Must be `true`.
/// </summary>
[JsonConverter(typeof(CertifyNoInfringementConverter))]
public enum CertifyNoInfringement
{
    True
}

sealed class CertifyNoInfringementConverter : JsonConverter<CertifyNoInfringement>
{
    public override CertifyNoInfringement Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>CertifyNoInfringement.True, _ =>(CertifyNoInfringement)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CertifyNoInfringement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CertifyNoInfringement.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Must be `true`.
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