using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

/// <summary>
/// Retrieve one registered number with its latest reputation snapshot. The `phone_number`
/// path parameter is in E.164 format and must be URL-encoded (e.g. `%2B19493253498`).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NumberRetrieveParams : ParamsBase
{
    public required string EnterpriseID { get; init; }

    public string? PhoneNumber { get; init; }

    /// <summary>
    /// When true, fetches fresh reputation data (incurs API cost). When false (default),
    /// returns cached data.
    /// </summary>
    public bool? Fresh {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "fresh"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("fresh", value);
        }
    }

    public NumberRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberRetrieveParams (
        NumberRetrieveParams numberRetrieveParams
    ) : base(numberRetrieveParams)
    {
        this.EnterpriseID = numberRetrieveParams.EnterpriseID;
        this.PhoneNumber = numberRetrieveParams.PhoneNumber;
    }
    #pragma warning restore CS8618

    public NumberRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string enterpriseID,
        string phoneNumber
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EnterpriseID = enterpriseID;
        this.PhoneNumber = phoneNumber;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NumberRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string enterpriseID,
        string phoneNumber
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            enterpriseID,
            phoneNumber
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EnterpriseID"] = JsonSerializer.SerializeToElement(this.EnterpriseID),
        ["PhoneNumber"] = JsonSerializer.SerializeToElement(this.PhoneNumber),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(NumberRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.EnterpriseID.Equals(other.EnterpriseID)&&(this.PhoneNumber?.Equals(other.PhoneNumber) ?? other.PhoneNumber == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/reputation/numbers/{1}",
            this.EnterpriseID,
            this.PhoneNumber)
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