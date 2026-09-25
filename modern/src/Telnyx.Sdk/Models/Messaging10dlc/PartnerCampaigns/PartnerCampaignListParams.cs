using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

/// <summary>
/// Retrieve all partner campaigns you have shared to Telnyx in a paginated fashion.
///
/// <para>This endpoint is currently limited to only returning shared campaigns that
/// Telnyx has accepted. In other words, shared but pending campaigns are currently
/// omitted from the response from this endpoint.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PartnerCampaignListParams : ParamsBase
{
    /// <summary>
    /// The 1-indexed page number to get. The default value is `1`.
    /// </summary>
    public long? Page {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// The amount of records per page, limited to between 1 and 500 inclusive. The
    /// default value is `10`.
    /// </summary>
    public long? RecordsPerPage {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "recordsPerPage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("recordsPerPage", value);
        }
    }

    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// createdAt in descending order.
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public PartnerCampaignListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PartnerCampaignListParams (
        PartnerCampaignListParams partnerCampaignListParams
    ) : base(partnerCampaignListParams)
    {  }
    #pragma warning restore CS8618

    public PartnerCampaignListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PartnerCampaignListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PartnerCampaignListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PartnerCampaignListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/10dlc/partner_campaigns"
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

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by createdAt
/// in descending order.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    AssignedPhoneNumbersCount,
    AssignedPhoneNumbersCountDesc,
    BrandDisplayName,
    BrandDisplayNameDesc,
    TcrBrandID,
    TcrBrandIDDesc,
    TcrCampaignID,
    TcrCampaignIDDesc,
    CreatedAt,
    CreatedAtDesc,
    CampaignStatus,
    CampaignStatusDesc
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "assignedPhoneNumbersCount"=>Sort.AssignedPhoneNumbersCount,
            "-assignedPhoneNumbersCount"=>Sort.AssignedPhoneNumbersCountDesc,
            "brandDisplayName"=>Sort.BrandDisplayName,
            "-brandDisplayName"=>Sort.BrandDisplayNameDesc,
            "tcrBrandId"=>Sort.TcrBrandID,
            "-tcrBrandId"=>Sort.TcrBrandIDDesc,
            "tcrCampaignId"=>Sort.TcrCampaignID,
            "-tcrCampaignId"=>Sort.TcrCampaignIDDesc,
            "createdAt"=>Sort.CreatedAt,
            "-createdAt"=>Sort.CreatedAtDesc,
            "campaignStatus"=>Sort.CampaignStatus,
            "-campaignStatus"=>Sort.CampaignStatusDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.AssignedPhoneNumbersCount=>"assignedPhoneNumbersCount",
            Sort.AssignedPhoneNumbersCountDesc=>"-assignedPhoneNumbersCount",
            Sort.BrandDisplayName=>"brandDisplayName",
            Sort.BrandDisplayNameDesc=>"-brandDisplayName",
            Sort.TcrBrandID=>"tcrBrandId",
            Sort.TcrBrandIDDesc=>"-tcrBrandId",
            Sort.TcrCampaignID=>"tcrCampaignId",
            Sort.TcrCampaignIDDesc=>"-tcrCampaignId",
            Sort.CreatedAt=>"createdAt",
            Sort.CreatedAtDesc=>"-createdAt",
            Sort.CampaignStatus=>"campaignStatus",
            Sort.CampaignStatusDesc=>"-campaignStatus",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}