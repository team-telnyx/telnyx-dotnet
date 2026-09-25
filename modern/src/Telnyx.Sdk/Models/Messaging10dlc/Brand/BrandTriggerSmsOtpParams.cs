using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Trigger or re-trigger an SMS OTP (One-Time Password) for Sole Proprietor brand verification.
///
/// <para>**Important Notes:**</para>
///
/// <para>* Only allowed for Sole Proprietor (`SOLE_PROPRIETOR`) brands * Triggers
/// generation of a one-time password sent to the `mobilePhone` number in the brand's
/// profile * Campaigns cannot be created until OTP verification is complete * US/CA
/// numbers only for real OTPs; mock brands can use non-US/CA numbers for testing
/// * Returns a `referenceId` that can be used to check OTP status via the GET `/10dlc/brand/smsOtp/{referenceId}` endpoint</para>
///
/// <para>**Use Cases:**</para>
///
/// <para>* Initial OTP trigger after Sole Proprietor brand creation * Re-triggering
/// OTP if the user didn't receive or needs a new code</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandTriggerSmsOtpParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? BrandID { get; init; }

    /// <summary>
    /// SMS message template to send the OTP. Must include `@OTP_PIN@` placeholder
    /// which will be replaced with the actual PIN
    /// </summary>
    public required string PinSms {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "pinSms"
            );
        }
        init { this._rawBodyData.Set("pinSms", value); }
    }

    /// <summary>
    /// SMS message to send upon successful OTP verification
    /// </summary>
    public required string SuccessSms {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "successSms"
            );
        }
        init { this._rawBodyData.Set("successSms", value); }
    }

    public BrandTriggerSmsOtpParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandTriggerSmsOtpParams (
        BrandTriggerSmsOtpParams brandTriggerSmsOtpParams
    ) : base(brandTriggerSmsOtpParams)
    {
        this.BrandID = brandTriggerSmsOtpParams.BrandID;

        this._rawBodyData = new(brandTriggerSmsOtpParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public BrandTriggerSmsOtpParams (
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
    BrandTriggerSmsOtpParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string brandID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.BrandID = brandID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandTriggerSmsOtpParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string brandID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BrandTriggerSmsOtpParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BrandID?.Equals(other.BrandID) ?? other.BrandID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
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