using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Query the status of an SMS OTP (One-Time Password) for Sole Proprietor brand verification
/// using the Brand ID.
///
/// <para>This endpoint allows you to check the delivery and verification status of
/// an OTP sent during the Sole Proprietor brand verification process by looking
/// it up with the brand ID.</para>
///
/// <para>The response includes delivery status, verification dates, and detailed
/// delivery information.</para>
///
/// <para>**Note:** This is an alternative to the `/10dlc/brand/smsOtp/{referenceId}`
/// endpoint when you have the Brand ID but not the reference ID.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandRetrieveSmsOtpStatusParams : ParamsBase
{
    public string? BrandID { get; init; }

    public BrandRetrieveSmsOtpStatusParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandRetrieveSmsOtpStatusParams (
        BrandRetrieveSmsOtpStatusParams brandRetrieveSmsOtpStatusParams
    ) : base(brandRetrieveSmsOtpStatusParams)
    { this.BrandID = brandRetrieveSmsOtpStatusParams.BrandID; }
    #pragma warning restore CS8618

    public BrandRetrieveSmsOtpStatusParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandRetrieveSmsOtpStatusParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string brandID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BrandID = brandID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandRetrieveSmsOtpStatusParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string brandID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            brandID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["BrandID"] = JsonSerializer.SerializeToElement(this.BrandID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BrandRetrieveSmsOtpStatusParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BrandID?.Equals(other.BrandID) ?? other.BrandID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/brand/{0}/smsOtp",
            this.BrandID)
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