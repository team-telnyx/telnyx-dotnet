using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// This endpoint is used to list all brands associated with your organization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandListParams : ParamsBase
{
    /// <summary>
    /// Filter results by the Telnyx Brand id
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

    /// <summary>
    /// Filter results by country.
    /// </summary>
    public string? Country {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("country", value);
        }
    }

    /// <summary>
    /// Filter results by display name.
    /// </summary>
    public string? DisplayName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "displayName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Filter results by entity type.
    /// </summary>
    public string? EntityType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "entityType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("entityType", value);
        }
    }

    /// <summary>
    /// Page number to retrieve (1-based).
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
    /// number of records per page. maximum of 500
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

    /// <summary>
    /// Filter results by state.
    /// </summary>
    public string? State {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("state", value);
        }
    }

    /// <summary>
    /// Filter results by the TCR Brand id
    /// </summary>
    public string? TcrBrandID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "tcrBrandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("tcrBrandId", value);
        }
    }

    public BrandListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListParams (BrandListParams brandListParams) : base(
        brandListParams
    )
    {  }
    #pragma warning restore CS8618

    public BrandListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandListParams FromRawUnchecked(
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

    public virtual bool Equals(BrandListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/10dlc/brand"
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
    AssignedCampaignsCount,
    AssignedCampaignsCountDesc,
    BrandID,
    BrandIDDesc,
    CreatedAt,
    CreatedAtDesc,
    DisplayName,
    DisplayNameDesc,
    IdentityStatus,
    IdentityStatusDesc,
    Status,
    StatusDesc,
    TcrBrandID,
    TcrBrandIDDesc
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
            "assignedCampaignsCount"=>Sort.AssignedCampaignsCount,
            "-assignedCampaignsCount"=>Sort.AssignedCampaignsCountDesc,
            "brandId"=>Sort.BrandID,
            "-brandId"=>Sort.BrandIDDesc,
            "createdAt"=>Sort.CreatedAt,
            "-createdAt"=>Sort.CreatedAtDesc,
            "displayName"=>Sort.DisplayName,
            "-displayName"=>Sort.DisplayNameDesc,
            "identityStatus"=>Sort.IdentityStatus,
            "-identityStatus"=>Sort.IdentityStatusDesc,
            "status"=>Sort.Status,
            "-status"=>Sort.StatusDesc,
            "tcrBrandId"=>Sort.TcrBrandID,
            "-tcrBrandId"=>Sort.TcrBrandIDDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.AssignedCampaignsCount=>"assignedCampaignsCount",
            Sort.AssignedCampaignsCountDesc=>"-assignedCampaignsCount",
            Sort.BrandID=>"brandId",
            Sort.BrandIDDesc=>"-brandId",
            Sort.CreatedAt=>"createdAt",
            Sort.CreatedAtDesc=>"-createdAt",
            Sort.DisplayName=>"displayName",
            Sort.DisplayNameDesc=>"-displayName",
            Sort.IdentityStatus=>"identityStatus",
            Sort.IdentityStatusDesc=>"-identityStatus",
            Sort.Status=>"status",
            Sort.StatusDesc=>"-status",
            Sort.TcrBrandID=>"tcrBrandId",
            Sort.TcrBrandIDDesc=>"-tcrBrandId",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}