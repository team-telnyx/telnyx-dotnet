using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Query the status of an SMS OTP (One-Time Password) for Sole Proprietor brand verification.
///
/// <para>This endpoint allows you to check the delivery and verification status of
/// an OTP sent during the Sole Proprietor brand verification process. You can query
/// by either:</para>
///
/// <para>* `referenceId` - The reference ID returned when the OTP was initially
/// triggered * `brandId` - Query parameter for portal users to look up OTP status
/// by Brand ID</para>
///
/// <para>The response includes delivery status, verification dates, and detailed
/// delivery information.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandGetSmsOtpByReferenceParams : ParamsBase
{
    public string? ReferenceID { get; init; }

    /// <summary>
    /// Filter by Brand ID for easier lookup in portal applications
    /// </summary>
    public string? BrandID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "brandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("brandId", value);
        }
    }

    public BrandGetSmsOtpByReferenceParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandGetSmsOtpByReferenceParams (
        BrandGetSmsOtpByReferenceParams brandGetSmsOtpByReferenceParams
    ) : base(brandGetSmsOtpByReferenceParams)
    { this.ReferenceID = brandGetSmsOtpByReferenceParams.ReferenceID; }
    #pragma warning restore CS8618

    public BrandGetSmsOtpByReferenceParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandGetSmsOtpByReferenceParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string referenceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ReferenceID = referenceID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandGetSmsOtpByReferenceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string referenceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            referenceID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ReferenceID"] = JsonSerializer.SerializeToElement(this.ReferenceID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BrandGetSmsOtpByReferenceParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ReferenceID?.Equals(other.ReferenceID) ?? other.ReferenceID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/brand/smsOtp/{0}",
            EncodePathSegment(this.ReferenceID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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